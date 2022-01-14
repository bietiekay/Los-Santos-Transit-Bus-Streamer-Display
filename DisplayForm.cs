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

namespace LSTBusline
{
    /// <summary>
    /// Definition of the demonstration interface
    /// </summary>
    public partial class DisplayForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        int idText_Line1;     
        int idText_Line2;
        int idLogo;
        int idCurrentTime;
        int idNextStopTime;
        bool even_or_uneven = false; // Hilfsvariable um regelmässig zwischen zwei Zuständen hin und her zu schalten
        DateTime lastrun = DateTime.Now;
        bool m_bIsOn;   
        bool m_bIsHide; 
        private System.Windows.Forms.Timer timer1;

        String BusLine =  "###############";
        String NextStop = "###############";
        int MaxLineCharacters = 20;

        int currentMode = 0; // aktueller Modus
        int currentLine = 0; // aktuelle Linie im aktuellen Modus
        int currentStop = 0; // aktueller Halt der aktuellen Linie im aktuellen Modus

        SettingsRoot Konfiguration;
        //-------------------------------//
        //         CONSTRUCTOR           //
        //-------------------------------//
        #region Constuctor

        /// <summary>
        /// Class constructor
        /// </summary>
        public DisplayForm(KeyboardHookManager kManager)
        {
            InitializeComponent();

            #region read configuration
            Konfiguration = JsonConvert.DeserializeObject<SettingsRoot>(File.ReadAllText("LST-Busline-Konfiguration.json")) ?? new SettingsRoot();
            #endregion

            ledMatrixControl.LedOnColor = Color.FromArgb(Konfiguration.settings.style.led_on_color);
            ledMatrixControl.LedOffColor = Color.FromArgb(Konfiguration.settings.style.led_off_color);
            ledMatrixControl.SizeCoeff = (double)Konfiguration.settings.style.led_size_coefficient;

            // Get the color from the control
            pbtDisplayLedOn.BackColor = ledMatrixControl.LedOnColor;
            pbtDisplayLedOff.BackColor = ledMatrixControl.LedOffColor;
            

            // Get the size from the control
            nudDisplayNbLine.Value = 17;
            nudDisplayNbRow.Value = 200;
            nudLedSize.Value = (decimal)ledMatrixControl.SizeCoeff;

            // Set the font collection
            ledMatrixControl.LoadFontCollectionFromResource("LST-Busline-Font.xml");

            // Add the text item to the conrol
            //idLogo = ledMatrixControl.AddTextItem(tbxTx1.Text, new Point(0, 0), ItemDirection.Right, ItemSpeed.Idle);
            idCurrentTime =  ledMatrixControl.AddTextItem(GenerateCurrentTimeString(), new Point(165, 0), ItemDirection.Right, ItemSpeed.Idle);
            idNextStopTime = ledMatrixControl.AddTextItem(GenerateNextStopTime(), new Point(165, 8), ItemDirection.Right, ItemSpeed.Idle);
            idLogo = ledMatrixControl.AddTextItem(GenerateLogo(), new Point(0, 0), ItemDirection.Right, ItemSpeed.Idle);

            idText_Line1 = ledMatrixControl.AddTextItem(GenerateLine1(), new Point(25, 0), ItemDirection.Right, ItemSpeed.Idle);
            idText_Line2 = ledMatrixControl.AddTextItem(GenerateLine2(), new Point(25, 8), ItemDirection.Right, ItemSpeed.Idle);


            // Init the flags
            m_bIsOn = false;
            m_bIsHide = false;

            #region register hotkeys
            //Boolean NextStop        = RegisterHotKey(this.Handle, 1, 0x0000, Konfiguration.settings.hotkeys.nextstop);
            //    if (!NextStop) { MessageBox.Show("Nächster Halt Hotkey konnte nicht aktiviert werden!"); }
            //Boolean PreviousStop    = RegisterHotKey(this.Handle, 2, 0x0000, Konfiguration.settings.hotkeys.previousstop);
            //    if (!PreviousStop) { MessageBox.Show("Vorheriger Halt Hotkey konnte nicht aktiviert werden!"); }
            //Boolean ResetLine       = RegisterHotKey(this.Handle, 3, 0x0000, Konfiguration.settings.hotkeys.resetline);
            //    if (!ResetLine) { MessageBox.Show("Reset Hotkey konnte nicht aktiviert werden!"); }
            //Boolean SwitchLine      = RegisterHotKey(this.Handle, 4, 0x0000, Konfiguration.settings.hotkeys.switchline);
            //    if (!SwitchLine) { MessageBox.Show("Linienwechsel Hotkey konnte nicht aktiviert werden!"); }
            //Boolean SwitchMode      = RegisterHotKey(this.Handle, 5, 0x0000, Konfiguration.settings.hotkeys.switchmode);
            //    if (!SwitchMode) { MessageBox.Show("Moduswechsel Hotkey konnte nicht aktiviert werden!"); }

            // Nächster Halt
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys.nextstop, () =>
            {
                HandleHotKey_NextStop();
            });
            // Vorheriger Halt
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys.previousstop, () =>
            {
                HandleHotKey_PreviousStop();
            });
            // Reset
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys.resetline, () =>
            {
                HandleHotKey_Reset();
            });
            // Linienwechsel
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys.switchline, () =>
            {
                HandleHotKey_LineChange();
            });
            // Moduswechsel
            kManager.RegisterHotkey(Konfiguration.settings.hotkeys.switchmode, () =>
            {
                HandleHotKey_ModeChange();
            });
            #endregion

            InitTimer();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Code            
        }

        #endregion

        #region Hotkeys behandeln und reagieren
        protected void HandleHotKey_NextStop()
        {
            Debug.WriteLine("Nächster Halt");
            if ((currentStop+1) > Konfiguration.modes[currentMode].lines[currentLine].stops.Count() - 1) {
                // hochzählen geht nicht, wir fangen bei 0 an
                currentStop = 0;
            } else
            {
                // eins hochzählen
                currentStop += 1;
            }            
        }
        protected void HandleHotKey_PreviousStop()
        {
            Debug.WriteLine("Vorheriger Halt");

            if ((currentStop - 1) < 0)
            {
                // runterzählen geht nicht, wir schalten auf den letzten Stop
                currentStop = Konfiguration.modes[currentMode].lines[currentLine].stops.Count() - 1;
            }
            else
            {
                // eins runterzählen
                currentStop -= 1;
            }
        }
        protected void HandleHotKey_Reset()
        {
            Debug.WriteLine("Reset");
            currentLine = 0;
            currentMode = 0;
            currentStop = 0;
        }
        protected void HandleHotKey_LineChange()
        {
            Debug.WriteLine("Linienwechsel");

            if ((currentLine + 1) > Konfiguration.modes[currentMode].lines.Count() - 1)
            {
                // hochzählen geht nicht, wir fangen bei 0 an
                currentLine = 0;
            }
            else
            {
                // eins hochzählen
                currentLine += 1;
            }

            // reset der Stops
            currentStop = 0;
        }
        protected void HandleHotKey_ModeChange()
        {
            Debug.WriteLine("Moduswechsel");

            if ((currentMode + 1) > Konfiguration.modes.Count() - 1)
            {
                // hochzählen geht nicht, wir fangen bei 0 an
                currentMode = 0;
            }
            else
            {
                // eins hochzählen
                currentMode += 1;
            }

            // reset der anderen Werte
            currentLine = 0;
            currentStop = 0;

        }

        //protected override void WndProc(ref Message m)
        //{
        //    // 5. Catch when a HotKey is pressed !
        //    if (m.Msg == 0x0312)
        //    {
        //        int id = m.WParam.ToInt32();
        //        //MessageBox.Show(string.Format("Hotkey #{0} pressed", id));
        //        switch (id)
        //        {
        //            case 1:
        //                Debug.WriteLine("Nächster Halt");
        //                break;
        //            case 2:
        //                Debug.WriteLine("Vorheriger Halt");
        //                break;
        //            case 3:
        //                Debug.WriteLine("Reset");
        //                break;
        //            case 4:
        //                Debug.WriteLine("Linienwechsel");
        //                break;
        //            case 5:
        //                Debug.WriteLine("Moduswechsel");
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    base.WndProc(ref m);
        //}
        #endregion

        #region Timer Display Update
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(UpdateDisplayCycle);
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }

        /// <summary>
        /// wird regelmässig aufgerufen um das Display zu aktualisieren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDisplayCycle(object sender, EventArgs e)
        {
            //Debug.WriteLine("Tick Tock");

            // Update Uhrzeit
            ledMatrixControl.SetItemText(idCurrentTime,GenerateCurrentTimeString());
            // Update Line1
            ledMatrixControl.SetItemText(idText_Line1, GenerateLine1());
            // Update Line2
            ledMatrixControl.SetItemText(idText_Line2, GenerateLine2());
            // Update Nächster Halt
            ledMatrixControl.SetItemText(idNextStopTime, GenerateNextStopTime());

            Debug.WriteLine("Mode: " + currentMode + " Line: " + currentLine + " Stop:" + currentStop);
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
                return "¥" + DateTime.Now.ToString("H:mm");
            else
                return "¥" + DateTime.Now.ToString("H¦mm");
        }
        public String GenerateNextStopTime()
        {
            int nearestStopTime = Konfiguration.modes[currentMode].lines[currentLine].stops[currentStop].leavetimes_hourly?[0] ?? 0;

            // alle Haltezeiten des nächsten Stops durchstöbern und die die am nächsten dran ist (in der Zukunft) raussuchen
            foreach(int plannedStopTime in Konfiguration.modes[currentMode].lines[currentLine].stops[currentStop].leavetimes_hourly)
            {
                // plannedStopTime repräsentiert Minuten in der Stunde. Hier finden wir raus wie weit das von gerade weg ist...
                // wenn die Distanz kleiner ist als vom ersten Element zu gerade, dann übernehmen wir das Element...
                if (TimeDistance(DateTime.Now.Minute,plannedStopTime) <= TimeDistance(DateTime.Now.Minute, nearestStopTime))
                {
                    nearestStopTime = plannedStopTime;
                }
            }

            return "¦¦¦ :" + nearestStopTime.ToString("D2");
        }
        public String GenerateLogo()
        {
            return "¢";
        }
        public String GenerateLine1()
        {
            String currentLineName = "###############"; // Standardwert wenn Fehler
            // aktuellen Modus hernehmen und die daraus selektierte Linienbezeichnung anzeigen
            try
            {
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
                nextStopName = Konfiguration.modes[currentMode].lines[currentLine].stops[currentStop].name;

            }
            catch (Exception)
            {

            }

            return PadCenter(nextStopName, MaxLineCharacters);
        }
        #endregion


        #region Zeit Helper
        public int TimeDistance(int Minutes, int Minutes2)
        {
            if (Minutes < Minutes2)
                return Minutes2 - Minutes;
            else 
                return Minutes- Minutes2; 
        }
        #endregion

        #region String helper
        static string PadCenter(string text, int newWidth)
        {
            const char filler = '¡';
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
        }

        private void pbtDisplayLedOn_Click(object sender, EventArgs e)
        {
            ColorDialog cdLedOnColorDlg = new ColorDialog();

            if (cdLedOnColorDlg.ShowDialog() == DialogResult.OK)
            {
                pbtDisplayLedOn.BackColor = cdLedOnColorDlg.Color;
                ledMatrixControl.LedOnColor = cdLedOnColorDlg.Color;
            }
        }

        private void pbtDisplayLedOff_Click(object sender, EventArgs e)
        {
            ColorDialog cdLedOffColorDlg = new ColorDialog();

            if (cdLedOffColorDlg.ShowDialog() == DialogResult.OK)
            {
                pbtDisplayLedOff.BackColor = cdLedOffColorDlg.Color;
                ledMatrixControl.LedOffColor = cdLedOffColorDlg.Color;
            }

        }

        private void nudDisplayNbLine_ValueChanged(object sender, EventArgs e)
        {
            ledMatrixControl.SetMatrixSize((int)nudDisplayNbLine.Value, (int)nudDisplayNbRow.Value);
        }

        private void nudDisplayNbRow_ValueChanged(object sender, EventArgs e)
        {
            ledMatrixControl.SetMatrixSize((int)nudDisplayNbLine.Value, (int)nudDisplayNbRow.Value);
        }

        private void bptHide_Click(object sender, EventArgs e)
        {
            if (m_bIsHide == false)
            {
                groupBox2.Visible = false;
                pbtHide.Text = "Show";
                panel1.Height = 35;
                m_bIsHide = true;
            }
            else
            {
                groupBox2.Visible = true;
                pbtHide.Text = "Hide";
                panel1.Height = 147;
                m_bIsHide = false;
            }

        }

        private void nudLedSize_ValueChanged(object sender, EventArgs e)
        {
            ledMatrixControl.SizeCoeff = (double)nudLedSize.Value;
        }

        #endregion

    }
}