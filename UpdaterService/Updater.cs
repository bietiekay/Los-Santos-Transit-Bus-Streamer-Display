using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using UpdaterService.Net;
using Timer = System.Threading.Timer;

namespace UpdaterService.Diagnostics.Update
{
    public class Updater
    {
        #region Constants
        /// <summary>
        /// The default check interval
        /// </summary>
        public const int DefaultCheckInterval = 900; // 900s == 15 min
        public const int FirstCheckDelay = 15;

        /// <summary>
        /// The default configuration file
        /// </summary>
        public const string DefaultConfigFile = "update.xml";
        
        public const string WorkPath = "work";
        #endregion

        #region Fields
        private Timer _timer;
        private volatile bool _updating;
        private Manifest _localConfig;
        private Manifest _remoteConfig;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Updater"/> class.
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        public Updater (String UpdateFileContents)
        {
            Log.Debug = true;

            //_localConfigFile = configFile;
            //Log.Write("Loaded.");
            //Log.Write("Initializing using file '{0}'.", configFile.FullName);
            //if (!configFile.Exists)
            //{
            //    Log.Write("Config file '{0}' does not exist, stopping.", configFile.Name);
            //    return;
            //}

            //string data = File.ReadAllText(configFile.FullName);

            this._localConfig = new Manifest(UpdateFileContents);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts the monitoring.
        /// </summary>
        public void StartMonitoring ()
        {
            Log.Write("Prüfe auf Update...#11");
            _timer = new Timer(Check, null, 100, this._localConfig.CheckInterval * 1000);
        }

        /// <summary>
        /// Stops the monitoring.
        /// </summary>
        public void StopMonitoring ()
        {
            //Log.Write("Stopping monitoring.#100");
            if (_timer == null)
            {
                //Log.Write("Monitoring was already stopped.");
                return;
            }
            _timer.Dispose();
        }

        /// <summary>
        /// Checks the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        private void Check (object state)
        {
            //Log.Write("Check starting.#12");

            if (_updating)
            {
                //Log.Write("Updater is already updating.");
                //Log.Write("Check ending.");
                return;
            }
            var remoteUri = new Uri(this._localConfig.RemoteConfigUri);

            Log.Write("Hole Update Informationen...#25");
            var http = new Fetch { Retries = 5, RetrySleep = 30000, Timeout = 30000 };
            http.Load(remoteUri.AbsoluteUri);
            if (!http.Success)
            {
                Log.Write("Update Fehler: {0}", http.Response.StatusDescription);
                this._remoteConfig = null;
                return;
            }

            string data = Encoding.UTF8.GetString(http.ResponseData);
            this._remoteConfig = new Manifest(data);

            if (this._remoteConfig == null)
                return;

            if (this._localConfig.SecurityToken != this._remoteConfig.SecurityToken)
            {
                Log.Write("Update Fehler: Sicherheitstoken.#100");
                return;
            }
            //Log.Write("Remote config is valid.");
            //Log.Write("Lokale Version ist {0}  {1}.#27", this._localConfig.Version, this._remoteConfig.Version);

            if (this._remoteConfig.Version == this._localConfig.Version)
            {
                Log.Write("Kein Update verfügbar.#100");
                //Log.Write("Check ending.");
                StopMonitoring();
                return;
            }
            if (this._remoteConfig.Version < this._localConfig.Version)
            {
                Log.Write("Kein neueres Update verfügbar.#100");
                //Log.Write("Remote version is older. That's weird.#100");
                //Log.Write("Check ending.");
                StopMonitoring();
                return;
            }
            Log.Write("Update auf {1}.#27", this._remoteConfig.AppVersion);
            //Log.Write("#30");
            _updating = true;
            Update();
            _updating = false;
            //Log.Write("Check ending.");
            StopMonitoring();
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update ()
        {

            //Log.Write("Updating '{0}' files.#60", this._remoteConfig.Payloads.Length);

            // Clean up failed attempts.
            if (Directory.Exists(WorkPath))
            {
                //Log.Write("WARNING: Work directory already exists.");
                try { Directory.Delete(WorkPath, true); }
                catch (IOException)
                {
                    Log.Write("Fehler: Kann Verzeichniss nicht aktualisieren: '{0}'.#100", WorkPath);
                    return;
                }
            }

            Directory.CreateDirectory(WorkPath);
            
            // Download files in manifest.
            foreach (string update in this._remoteConfig.Payloads)
            {
                Log.Write("Downloade neue Version.#75");
                //Log.Write("Fetching '{0}'.#75", update);
                var url = this._remoteConfig.BaseUri + update;
                var file = Fetch.Get(url);
                if (file == null)
                {
                    Log.Write("Fehler: Download fehlgeschlagen.#100");
                    return;
                }
                var info = new FileInfo(Path.Combine(WorkPath, update));
                Directory.CreateDirectory(info.DirectoryName);
                File.WriteAllBytes(Path.Combine(WorkPath, update), file);

                // Unzip
                if ( Regex.IsMatch(update, @"\.zip"))
                {
                    try
                    {
                        var zipfile = Path.Combine(WorkPath, update);
                        ZipFile.ExtractToDirectory(zipfile, WorkPath);
                        //using (var zip = ZipFile.Read(zipfile))
                        //    zip.ExtractAll(WorkPath, ExtractExistingFileAction.Throw);
                        File.Delete(zipfile);
                    }
                    catch (Exception ex)
                    {
                        Log.Write("Fehler: Entpacken gescheitert - {0}", ex.Message);                        
                        return;
                    }
                }
            }

            // Change the currently running executable so it can be overwritten.
            Process thisprocess = Process.GetCurrentProcess();
            string me = thisprocess.MainModule.FileName;
            string bak = me + ".bak";
            //Log.Write("Renaming running process to '{0}'.#90", bak);
            if(File.Exists(bak))
                File.Delete(bak);
            File.Move(me, bak);
            File.Copy(bak, me);

            // Write out the new manifest.
            //_remoteConfig.Write(Path.Combine(WorkPath, _localConfigFile.Name));
            _localConfig = _remoteConfig;

            // Copy everything.
            var directory = new DirectoryInfo(WorkPath);
            var files = directory.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                string destination = file.FullName.Replace(directory.FullName+@"\", "");
                Log.Write("Installiere neue Version.#95");
                Directory.CreateDirectory(new FileInfo(destination).DirectoryName);
                file.CopyTo(destination, true);
            }

            // Clean up.
            Log.Write("Räume auf.#96");
            Directory.Delete(WorkPath, true);

            //Log.Write("Deleting update.xml.#97");
            File.Delete("update.xml");

            // Restart.
            Log.Write("Starte die neue Version.#98");
            var spawn = Process.Start(me);
            //Log.Write("New process ID is {0}#99", spawn.Id);
            //Log.Write("Closing old running process {0}.#100", thisprocess.Id);
            thisprocess.CloseMainWindow();
            thisprocess.Close();
            thisprocess.Dispose();
        }
        #endregion
    }
}
