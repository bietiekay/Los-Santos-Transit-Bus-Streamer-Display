/*****************************************************************************/
/* Project  : LedMatrix                                                      */
/* File     : DisplayForm.cs                                                 */
/* Version  : 1                                                              */
/* Language : C#                                                             */
/* Summary  : Implementation of the demonstration interface                  */
/* Creation : 23/02/2010                                                     */
/* Autor    : Guillaume CHOUTEAU                                             */
/* History  :                                                                */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LedMatrixControlNamespace;
using LST_Busline.Settings;
using Newtonsoft.Json;
using NonInvasiveKeyboardHookLibrary;
using UpdaterService.Diagnostics.Update;


namespace LSTBusline
{
    /// <summary>
    /// Definition of the demonstration interface
    /// </summary>
    public partial class DisplayForm : Form
    {
        #region Thread-Safe Status + Progressbar
        private delegate void SafeSetTextBoxText(string text);
        private delegate void SafeSetProgressBarValue(int value);

        private void SplitAndUpdateStatusTextAndProgressbar(string InputText)
        {
            String[] SplitUp = InputText.Split('#');

            if (SplitUp.Length > 1)
            {
                WriteTextSafe(SplitUp[0]);
                SetProgressBarValueSafe(Convert.ToInt16(SplitUp[1]));
            }


        }
        private void WriteTextSafe(string text)
        {
            if (UpdateStatusTextbox.InvokeRequired)
            {
                var d = new SafeSetTextBoxText(WriteTextSafe);
                UpdateStatusTextbox.Invoke(d, new object[] { text });
            }
            else
            {
                UpdateStatusTextbox.Text = text;
            }
        }
        private void SetProgressBarValueSafe(int value)
        {
            /*if (SplashProgressBar.InvokeRequired)
            {
                var d = new SafeSetProgressBarValue(SetProgressBarValueSafe);
                SplashProgressBar.Invoke(d, new object[] { value });
            }
            else
            {
                SplashProgressBar.Value = value;
            }*/
        }
        #endregion

        private readonly object lockObject = new object();

        int idText_Line1;     
        int idText_Line2;
        int idLogo;
        int idCurrentTime;
        int idNextStopTime;
        bool even_or_uneven = false; // Hilfsvariable um regelm�ssig zwischen zwei Zust�nden hin und her zu schalten
        DateTime lastrun = DateTime.Now;
        bool m_bIsOn;   
        bool m_bIsHide;
        KeyboardHookManager _kManager;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;

        String BusLine =  "###############";
        String NextStop = "###############";
        int MaxLineCharacters = 20;

        int currentMode = 0; // aktueller Modus
        int currentLine = 0; // aktuelle Linie im aktuellen Modus
        int currentStop = 0; // aktueller Halt der aktuellen Linie im aktuellen Modus


        int savedStatisticMode = int.MaxValue;
        int savedStatisticLine = int.MaxValue;
        int savedStatisticStop = int.MaxValue;
        DateTime savedStatisticStopTime = DateTime.MinValue;

        bool invalidated = false;

        SettingsRoot Konfiguration;
        //-------------------------------//
        //         CONSTRUCTOR           //
        //-------------------------------//
        #region Constuctor

        /// <summary>
        /// Class constructor
        /// </summary>
        public DisplayForm()
        {
            InitializeComponent();
            SplitAndUpdateStatusTextAndProgressbar("Starte...#0");

            Log.Event += (sender, e) => SplitAndUpdateStatusTextAndProgressbar(e.Message);


            #region read configuration
            Konfiguration = ReadConfiguration();
            WriteConfiguration(Konfiguration);
            #endregion

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            versionlabel.Text = String.Format("{0}", version);

            InitializeAllElements();

            HotkeysActive.Checked = true;

            // Set the font collection
            ledMatrixControl.LoadFontCollectionFromResource("LST-Busline-Font.xml");
            nudLedSize.Value = (decimal)ledMatrixControl.SizeCoeff;

            // Add the text item to the conrol
            //idLogo = ledMatrixControl.AddTextItem(tbxTx1.Text, new Point(0, 0), ItemDirection.Right, ItemSpeed.Idle);
            idCurrentTime =  ledMatrixControl.AddTextItem(GenerateCurrentTimeString(), new Point(165, 0), ItemDirection.Right, ItemSpeed.Idle);
            idNextStopTime = ledMatrixControl.AddTextItem(GenerateNextSelectedStopTime(), new Point(165, 8), ItemDirection.Right, ItemSpeed.Idle);
            idLogo = ledMatrixControl.AddTextItem(GenerateLogo(), new Point(0, 0), ItemDirection.Right, ItemSpeed.Idle);

            idText_Line1 = ledMatrixControl.AddTextItem(GenerateLine1(), new Point(25, 0), ItemDirection.Right, ItemSpeed.Idle);
            idText_Line2 = ledMatrixControl.AddTextItem(GenerateLine2(), new Point(25, 8), ItemDirection.Right, ItemSpeed.Idle);


            // Init the flags
            m_bIsOn = false;
            m_bIsHide = false;

            // Register Hotkeys
            _kManager = new KeyboardHookManager();
            _kManager.Start();
           
            RegisterHotkeys(_kManager);
            invalidated = true;
            InitTimer();

            var updater = new UpdaterService.Diagnostics.Update.Updater(StartUpAndUpdate.ReadResourceHelper.ReadResource("update.xml"));
            updater.StartMonitoring();
            HandleHotKey_Reset();
        }

        private void InitializeAllElements()
        {
            ledMatrixControl.LedOnColor = Color.FromArgb(Konfiguration?.settings?.style?.led_on_color ?? -256);
            ledMatrixControl.LedOffColor = Color.FromArgb(Konfiguration?.settings?.style?.led_off_color ?? -12566464);
            ledMatrixControl.BackColor = Color.FromArgb(Konfiguration?.settings?.style?.led_background_color ?? -16777216);
            ledMatrixControl.SizeCoeff = (double)Konfiguration.settings.style.led_size_coefficient;
            invertLogoCheckbox.Checked = Konfiguration.settings.style.logoinverted;
            currentTimeStopOnLineChange.Checked = Konfiguration.settings.autosuggeststoponlinechange;
            autoSwitchAfterFirst.Checked = Konfiguration.settings.autoforwardlineafterfirst;
            if (autoSwitchAfterFirst.Checked)
                LinienAbbruchZeitUpDownControl.Enabled = false;
            else
                LinienAbbruchZeitUpDownControl.Enabled = true;
            if (Konfiguration.settings.style?.ledtype == 0)
            {
                ledMatrixControl.SetLedStyle(LedSyle.Round);
                cbxDisplayLedStyle.SelectedIndex = 0;
            }
            else
            {
                ledMatrixControl.SetLedStyle(LedSyle.Square);
                cbxDisplayLedStyle.SelectedIndex = 1;
            }

            // Get the color from the control
            pbtDisplayLedOn.BackColor = ledMatrixControl.LedOnColor;
            pbtDisplayLedOff.BackColor = ledMatrixControl.LedOffColor;
            pbtLEDBackgroundButton.BackColor = ledMatrixControl.BackColor;


            // Get the size from the control
            ledMatrixControl.SetMatrixSize(Konfiguration.settings?.style?.lines ?? 200, Konfiguration.settings?.style?.rows ?? 17);



            // Line Abort Window
            LinienAbbruchZeitUpDownControl.Value = Konfiguration.settings.lineabortwindow;

        }

        #region Konfiguration
        public SettingsRoot ReadConfiguration()
        {
            return JsonConvert.DeserializeObject<SettingsRoot>(File.ReadAllText("LST-Busline-Konfiguration.json")) ?? new SettingsRoot();
        }

        public void WriteConfiguration(SettingsRoot Konfiguration)
        {
            // write it
            File.WriteAllText("LST-Busline-Konfiguration.json", JsonConvert.SerializeObject(Konfiguration, Formatting.Indented));

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Fensterposition wiederherstellen
            Location = new Point(Konfiguration.settings.style.windowposition_x, Konfiguration.settings.style.windowposition_y);
            Size = new Size(Konfiguration.settings.style.windowwidth, Konfiguration.settings.style.windowheight);

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Fensterposition speichern...
            Konfiguration.settings.style.windowposition_x = Location.X;
            Konfiguration.settings.style.windowposition_y = Location.Y;
            Konfiguration.settings.style.windowheight = Size.Height;
            Konfiguration.settings.style.windowwidth = Size.Width;
            WriteConfiguration(Konfiguration);
        }

        public void RegisterHotkeys(KeyboardHookManager kManager)
        {

            #region register hotkeys
            //Boolean NextStop        = RegisterHotKey(this.Handle, 1, 0x0000, Konfiguration.settings.hotkeys.nextstop);
            //    if (!NextStop) { MessageBox.Show("N�chster Halt Hotkey konnte nicht aktiviert werden!"); }
            //Boolean PreviousStop    = RegisterHotKey(this.Handle, 2, 0x0000, Konfiguration.settings.hotkeys.previousstop);
            //    if (!PreviousStop) { MessageBox.Show("Vorheriger Halt Hotkey konnte nicht aktiviert werden!"); }
            //Boolean ResetLine       = RegisterHotKey(this.Handle, 3, 0x0000, Konfiguration.settings.hotkeys.resetline);
            //    if (!ResetLine) { MessageBox.Show("Reset Hotkey konnte nicht aktiviert werden!"); }
            //Boolean SwitchLine      = RegisterHotKey(this.Handle, 4, 0x0000, Konfiguration.settings.hotkeys.switchline);
            //    if (!SwitchLine) { MessageBox.Show("Linienwechsel Hotkey konnte nicht aktiviert werden!"); }
            //Boolean SwitchMode      = RegisterHotKey(this.Handle, 5, 0x0000, Konfiguration.settings.hotkeys.switchmode);
            //    if (!SwitchMode) { MessageBox.Show("Moduswechsel Hotkey konnte nicht aktiviert werden!"); }
            kManager.Stop();
            kManager.Start();
            kManager.UnregisterAll();

            // N�chster Halt
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys?.nextstop ?? (int)Keys.D9, () =>
            {
                HandleHotKey_NextStop();
            });
            // Vorheriger Halt
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys?.previousstop ?? (int)Keys.D8, () =>
            {
                HandleHotKey_PreviousStop();
            });
            // Reset
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys?.resetline ?? (int)Keys.D7, () =>
            {
                HandleHotKey_Reset();
            });
            // Linienwechsel
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys?.switchline ?? (int)Keys.D6, () =>
            {
                HandleHotKey_LineChange();
            });
            // Moduswechsel
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys?.switchmode ?? (int)Keys.D5, () =>
            {
                HandleHotKey_ModeChange();
            });
            #endregion

        }

        #endregion

        #region Hotkeys behandeln und reagieren
        protected void HandleHotKey_NextStop()
        {
            Debug.WriteLine("N�chster Halt");            
            lock (lockObject)
            {
                if ((currentStop + 1) > Konfiguration.modes[currentMode].lines[currentLine].stops.Count() - 1)
                {
                    // hochz�hlen geht nicht, wir fangen bei 0 an
                    currentStop = 0;
                }
                else
                {
                    // eins hochz�hlen
                    currentStop += 1;
                }
            }
            invalidated = true;
        }
        protected void HandleHotKey_PreviousStop()
        {
            Debug.WriteLine("Vorheriger Halt");
            lock (lockObject)
            {
                if ((currentStop - 1) < 0)
                {
                    // runterz�hlen geht nicht, wir schalten auf den letzten Stop
                    currentStop = Konfiguration.modes[currentMode].lines[currentLine].stops.Count() - 1;
                }
                else
                {
                    // eins runterz�hlen
                    currentStop -= 1;
                }
            }

            invalidated = true;
        }
        protected void HandleHotKey_Reset()
        {
            Debug.WriteLine("Reset");
            invalidated = true;
            lock (lockObject)
            {
                currentLine = Konfiguration.modes[currentMode].lines.Count() - 1;
                currentMode = 0;
                currentStop = 0;
            }
            HandleHotKey_LineChange();
            invalidated = true;
        }
        protected void HandleHotKey_LineChange()
        {
            Debug.WriteLine("Linienwechsel");            
            lock (lockObject)
            {
                if ((currentLine + 1) > Konfiguration.modes[currentMode].lines.Count() - 1)
                {
                    // hochz�hlen geht nicht, wir fangen bei 0 an
                    currentLine = 0;
                }
                else
                {
                    // eins hochz�hlen
                    currentLine += 1;
                }

                if (!Konfiguration.settings.autosuggeststoponlinechange)
                {
                    // reset der Stops - wir starten beim ersten Stop
                    currentStop = 0;
                }
                else
                {
                    // den richtigen Stop vorausw�hlen - das ist der n�chstm�gliche entsprechend der aktuellen Uhrzeit
                    for (int i = 0; i <= Konfiguration.modes[currentMode].lines[currentLine].stops.Count() - 1; i++)
                    {

                        DateTime stoptime = GenerateNextStopTime(currentMode, currentLine, i,false);
                        if (stoptime <= DateTime.Now)
                        {
                            //do something
                            //Debug.WriteLine(Konfiguration.modes[currentMode].lines[currentLine].stops[i].name);
                            //Debug.WriteLine(stoptime);
                            currentStop = i;
                        }
                    }
                }
            }

            invalidated = true;
        }

        protected void HandleHotKey_ModeChange()
        {
            Debug.WriteLine("Moduswechsel");
            lock (lockObject)
            {
                if ((currentMode + 1) > Konfiguration.modes.Count() - 1)
                {
                    // hochz�hlen geht nicht, wir fangen bei 0 an
                    currentMode = 0;
                }
                else
                {
                    // eins hochz�hlen
                    currentMode += 1;
                }

                // reset der anderen Werte
                currentLine = 0;
                currentStop = 0;
            }
            invalidated = true;

        }
        #endregion

        #region Timer Display Update
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(UpdateDisplayCycle);
            timer1.Interval = 200; // in miliseconds
            timer1.Start();

            timer2 = new System.Windows.Forms.Timer();
            timer2.Tick += new EventHandler(ReRegisterHotkeys);
            timer2.Interval = 10000;
            timer2.Start();

            timer3 = new System.Windows.Forms.Timer();
            timer3.Tick += new EventHandler(AutoForward);
            timer3.Interval = 1000;
            timer3.Start();

            timer4 = new System.Windows.Forms.Timer();
            timer4.Tick += new EventHandler(UpdateStatistics);
            timer4.Interval = 1000;
            timer4.Start();


        }
        private void UpdateStatistics(object sender, EventArgs e)
        {
            if ( (savedStatisticMode != currentMode) || (savedStatisticLine != currentLine) || (savedStatisticStop != currentStop) )
            {
                // es wurde umgeschaltet
                // hole n�chste Stop Zeit
                savedStatisticStopTime = GenerateNextStopTime(currentMode, currentLine, currentStop, false);
            }

            if (savedStatisticStopTime != DateTime.MinValue)
            {
                String prefix = "";
                String suffix = "";
                if (savedStatisticStopTime >= DateTime.Now)
                {
                    //Debug.WriteLine("early");
                    prefix = "-";
                    suffix = "fr�h";
                }
                else
                {
                    if ((DateTime.Now - savedStatisticStopTime).TotalMinutes <= 1)
                    {
                        //Debug.WriteLine("ontime");
                        prefix = "";
                        suffix = "p�nktlich";
                    }
                    else
                    {
                        //Debug.WriteLine("late");                        
                        prefix = "+";
                        suffix = "versp�tet";
                    }

                }

                //tooLateTime.Text = ;
                timeToNextStop.Text = prefix + (savedStatisticStopTime - DateTime.Now).ToString(@"mm\:ss")+ " - "+ suffix;
                //Debug.WriteLine(stopTime);

            }
        }

        private bool IsCurrentlineLineInformationOnly()
        {
            /*int stoptime = int.MinValue;
            // Pr�ft ob alle Halts in der Linie identische Zeiten haben

            // alle stops
            for (int stop=0;stop <= Konfiguration.modes[currentMode].lines[currentLine].stops.Count() -1; stop++)
            {
                // alle haltezeiten dieses stops
                foreach (int thisstoptime in Konfiguration.modes[currentMode].lines[currentLine].stops[stop].leavetimes_hourly)
                {
                    if (stoptime == int.MinValue)
                        stoptime = thisstoptime;

                    if (stoptime != thisstoptime)
                        return false;
                }
            }
            return true;*/
            return Konfiguration.modes[currentMode].lines[currentLine].isInformationOnly;
        }

        private void AutoForward(object sender, EventArgs e)
        {            
            if ((Konfiguration.settings.autoforwardlineafterfirst) && currentStop > 0 && !IsCurrentlineLineInformationOnly())
            {

                //Debug.WriteLine("AutoForward");
                // auto forward...
                int tempstop = 0;
                //Debug.WriteLine("-----");
                // den n�chsten Stop vorausw�hlen - das ist der n�chstm�gliche entsprechend der aktuellen Uhrzeit
                lock (lockObject)
                {
                    for (int i = 0; i <= Konfiguration.modes[currentMode].lines[currentLine].stops.Count() - 1; i++)
                    {
                        //Debug.WriteLine(Konfiguration.modes[currentMode].lines[currentLine].stops[i].name + " - " + GenerateNextStopTime(currentMode, currentLine, i, false));
                        DateTime stoptime = GenerateNextStopTime(currentMode, currentLine, i, false);
                        if (stoptime < DateTime.Now)
                        {
                            //do something
                            tempstop = i;
                        }
                    }
                    if (tempstop > currentStop)
                    {
                        currentStop = tempstop;
                        invalidated = true;
                    }
                }
            }
        }

        private void ReRegisterHotkeys(object sender, EventArgs e)
        {
            //Debug.WriteLine("Hotkeys re-register");
            if (HotkeysActive.Checked)            
                RegisterHotkeys(_kManager);
        }

        /// <summary>
        /// wird regelm�ssig aufgerufen um das Display zu aktualisieren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDisplayCycle(object sender, EventArgs e)
        {
            //Debug.WriteLine("Tick Tock");

            // Update Uhrzeit
            ledMatrixControl.SetItemText(idCurrentTime,GenerateCurrentTimeString());

            // nur updaten wenn wir m�ssen
            if (invalidated)
            {
                // Update Line1
                ledMatrixControl.SetItemText(idText_Line1, GenerateLine1());
                // Update Line2
                ledMatrixControl.SetItemText(idText_Line2, GenerateLine2());
                // Update N�chster Halt
                ledMatrixControl.SetItemText(idNextStopTime, GenerateNextSelectedStopTime());
                
                // stop updating
                invalidated = false;
            }           

            //Debug.WriteLine("Mode: " + currentMode + " Line: " + currentLine + " Stop:" + currentStop);
        }
        #endregion

        #region Dynamische Anzeigen Erzeugung
        public String GenerateCurrentTimeString()
        {
            // umschalten...
            if ((DateTime.Now - lastrun).TotalSeconds >= 1)
            {
                lastrun = DateTime.Now;

                even_or_uneven = !even_or_uneven;
            }

            if (even_or_uneven)
                return "�" + DateTime.Now.ToString("HH:mm");
            else
                return "�" + DateTime.Now.ToString("HH�mm");
        }

        public DateTime GetNearestTimeInTheFutureForMinute(int MinuteInput,bool ignoreAbortWindow)
        {            
            int Minute = MinuteInput + Konfiguration.settings.lineabortwindow;

            if (ignoreAbortWindow) Minute = MinuteInput;

            if (Minute > 60) { Minute = 60 - Minute; }

            DateTime output = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day, DateTime.Now.Hour, MinuteInput, 0);

            if (DateTime.Now.Minute > Minute)
                output = output.AddHours(1);

            return output;
        }

        public String GenerateNextSelectedStopTime()
        {
            if (IsCurrentlineLineInformationOnly())
                return "";
            else
                return "��� :" + GenerateNextStopTime(currentMode, currentLine, currentStop, false).Minute.ToString("D2");
        }

        public DateTime GenerateNextStopTime(int mode, int line, int stop, bool ignoreAbortWindow)
        {
            TimeSpan TimeDistance = TimeSpan.MaxValue;
            DateTime Abfahrtzeit = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

            lock (lockObject)
            {
                foreach (int Abfahrtszeit in Konfiguration.modes[mode].lines[line].stops[stop].leavetimes_hourly)
                {
                    DateTime nearestTimeForAbfahrzeit = GetNearestTimeInTheFutureForMinute(Abfahrtszeit, ignoreAbortWindow);

                    // qualifiziert weil in der Zukunft?
                    if (TimeDistance == TimeSpan.MaxValue)
                        TimeDistance = nearestTimeForAbfahrzeit - DateTime.Now;

                    if (TimeDistance < nearestTimeForAbfahrzeit - DateTime.Now)
                    {
                        TimeDistance = nearestTimeForAbfahrzeit - DateTime.Now;                        
                    }
                    else
                    {
                        TimeDistance = nearestTimeForAbfahrzeit - DateTime.Now;
                        Abfahrtzeit = nearestTimeForAbfahrzeit;
                    }

                }
            }
            return new DateTime(Abfahrtzeit.Year,Abfahrtzeit.Month,Abfahrtzeit.Day,Abfahrtzeit.Hour,Abfahrtzeit.Minute,0);
        }
        public String GenerateLogo()
        {
            if (Konfiguration.settings.style.logoinverted)
                return "�";
            else
                return "�";
        }
        public String GenerateLine1()
        {
            String currentLineName = "###############"; // Standardwert wenn Fehler
            // aktuellen Modus hernehmen und die daraus selektierte Linienbezeichnung anzeigen
            try
            {
                lock(lockObject)
                    currentLineName = Konfiguration.modes[currentMode].lines[currentLine].name;

            } catch(Exception)
            {

            }            

            return PadCenter(currentLineName, MaxLineCharacters);
        }
        public String GenerateLine2()
        {
            String nextStopName = "###############"; // Standardwert wenn Fehler
            // aktuellen Modus hernehmen und die daraus selektierte Linienbezeichnung anzeigen
            try
            {
                lock(lockObject)
                    nextStopName = Konfiguration.modes[currentMode].lines[currentLine].stops[currentStop].name;

            }
            catch (Exception)
            {

            }

            return PadCenter(nextStopName, MaxLineCharacters);
        }
        #endregion

        #region String helper
        static string PadCenter(string text, int newWidth)
        {
            const char filler = '�';
            int length = text.Length;
            int charactersToPad = newWidth - length;
            if (charactersToPad < 0) return text;// throw new ArgumentException("New width must be greater than string length.", "newWidth");
            int padLeft = charactersToPad / 2 + charactersToPad % 2;
            //add a space to the left if the string is an odd number
            int padRight = charactersToPad / 2;

            StringBuilder resultBuilder = new StringBuilder(newWidth);
            for (int i = 0; i < padLeft; i++) resultBuilder.Insert(i, filler);
            for (int i = 0; i < length; i++) resultBuilder.Insert(i + padLeft, text[i]);
            for (int i = newWidth - padRight; i < newWidth; i++) resultBuilder.Insert(i, filler);
            return resultBuilder.ToString();
        }
        #endregion

        //-------------------------------//
        // Display properties events     //00
        //-------------------------------//
        #region Display

        private void cbxDisplayLedStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDisplayLedStyle.SelectedIndex == 0)
            {
                ledMatrixControl.SetLedStyle(LedSyle.Round);
            }
            else if (cbxDisplayLedStyle.SelectedIndex == 1)
            {
                ledMatrixControl.SetLedStyle(LedSyle.Square);
            }
            Konfiguration.settings.style.ledtype = cbxDisplayLedStyle.SelectedIndex;              
            WriteConfiguration(Konfiguration);

        }

        private void pbtDisplayLedOn_Click(object sender, EventArgs e)
        {
            ColorDialog cdLedOnColorDlg = new ColorDialog();

            if (cdLedOnColorDlg.ShowDialog() == DialogResult.OK)
            {
                pbtDisplayLedOn.BackColor = cdLedOnColorDlg.Color;
                ledMatrixControl.LedOnColor = cdLedOnColorDlg.Color;
                Konfiguration.settings.style.led_on_color = cdLedOnColorDlg.Color.ToArgb();
                WriteConfiguration(Konfiguration);
            }
            

        }

        private void pbtLEDBackgroundButton_Click(object sender, EventArgs e)
        {
            ColorDialog cdLedOnColorDlg = new ColorDialog();

            if (cdLedOnColorDlg.ShowDialog() == DialogResult.OK)
            {
                pbtLEDBackgroundButton.BackColor = cdLedOnColorDlg.Color;
                ledMatrixControl.BackColor = cdLedOnColorDlg.Color;
                Konfiguration.settings.style.led_background_color = cdLedOnColorDlg.Color.ToArgb();
                WriteConfiguration(Konfiguration);
            }
        }

        private void pbtDisplayLedOff_Click(object sender, EventArgs e)
        {
            ColorDialog cdLedOffColorDlg = new ColorDialog();

            if (cdLedOffColorDlg.ShowDialog() == DialogResult.OK)
            {
                pbtDisplayLedOff.BackColor = cdLedOffColorDlg.Color;
                ledMatrixControl.LedOffColor = cdLedOffColorDlg.Color;
                Konfiguration.settings.style.led_off_color = cdLedOffColorDlg.Color.ToArgb();
                WriteConfiguration(Konfiguration);
            }
        }

        private void bptHide_Click(object sender, EventArgs e)
        {
            if (m_bIsHide == false)
            {
                groupBox3.Visible = false;
                groupBox2.Visible = false;
                groupBox1.Visible = false;
                pbtHide.Text = "Ausklappen";
                panel1.Height = 35;
                m_bIsHide = true;
            }
            else
            {
                groupBox3.Visible = true;
                groupBox2.Visible = true;
                groupBox1.Visible = true;
                pbtHide.Text = "Einklappen";
                panel1.Height = 170;
                m_bIsHide = false;
            }

        }

        private void nudLedSize_ValueChanged(object sender, EventArgs e)
        {
            ledMatrixControl.SizeCoeff = (double)nudLedSize.Value;

            Konfiguration.settings.style.led_size_coefficient = (double)nudLedSize.Value;
            WriteConfiguration(Konfiguration);

        }

        #endregion

        #region Kurzwahltasten
        private void button_switchmode_Click(object sender, EventArgs e)
        {
            HandleHotKey_ModeChange();
        }

        private void button_switchline_Click(object sender, EventArgs e)
        {
            HandleHotKey_LineChange();
        }

        private void button_previousstop_Click(object sender, EventArgs e)
        {
            HandleHotKey_PreviousStop();
        }

        private void button_nextstop_Click(object sender, EventArgs e)
        {
            HandleHotKey_NextStop();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            HandleHotKey_Reset();
        }

        private void Lizenzen_Click(object sender, EventArgs e)
        {
            var myForm = new ReleaseNotesCopyrightsAndLicenses();
            myForm.Show();
        }
        #endregion

        #region Einstellungen
        private void LinienAbbruchZeitUpDownControl_ValueChanged(object sender, EventArgs e)
        {
            Konfiguration.settings.lineabortwindow = Convert.ToInt32(LinienAbbruchZeitUpDownControl.Value);
            WriteConfiguration(Konfiguration);
        }

        private void currentTimeStopOnLineChange_CheckedChanged(object sender, EventArgs e)
        {
            Konfiguration.settings.autosuggeststoponlinechange = currentTimeStopOnLineChange.Checked;
            WriteConfiguration(Konfiguration);
        }

        private void autoSwitchAfterFirst_CheckedChanged(object sender, EventArgs e)
        {
            Konfiguration.settings.autoforwardlineafterfirst = autoSwitchAfterFirst.Checked;
            if (autoSwitchAfterFirst.Checked)
                LinienAbbruchZeitUpDownControl.Enabled = false;
            else
                LinienAbbruchZeitUpDownControl.Enabled = true;
            WriteConfiguration(Konfiguration);
        }

        private void invertLogoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Konfiguration.settings.style.logoinverted = invertLogoCheckbox.Checked;
            ledMatrixControl.SetItemText(idLogo, GenerateLogo());
            WriteConfiguration(Konfiguration);
        }
        #endregion

        private void HotkeysActive_CheckedChanged(object sender, EventArgs e)
        {
            if (!HotkeysActive.Checked)
            {
                _kManager.UnregisterAll();
            }
        }

        private void ResetConfiguration_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Soll die Konfiguration wirklich neu geladen und auf Lieferzustand zur�ckgesetzt werden? Damit werden auch alle Linien zur�ckgesetzt.", "Konfiguration auf Lieferzustand zur�cksetzen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (File.Exists("LST-Busline-Konfiguration.bak"))
                    File.Delete("LST-Busline-Konfiguration.bak");

                // backup machen
                File.Move("LST-Busline-Konfiguration.json", "LST-Busline-Konfiguration.bak");

                var konfiguration = StartUpAndUpdate.ReadResourceHelper.ReadResource("LST-Busline-Konfiguration.json");

                File.WriteAllText("LST-Busline-Konfiguration.json", konfiguration);

                // neu einlesen
                Konfiguration = ReadConfiguration();
                WriteConfiguration(Konfiguration);
                InitializeAllElements();

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}