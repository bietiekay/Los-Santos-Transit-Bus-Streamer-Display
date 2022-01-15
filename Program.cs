using NonInvasiveKeyboardHookLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LSTBusline
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists("LST-Busline-Konfiguration.json"))
            {
                MessageBox.Show("Konfiguration LST-Busline-Konfiguration.json nicht gefunden!", "Fehler");
                return;
            }
            if (!File.Exists("LST-Busline-Font.xml"))
            {
                MessageBox.Show("Zeichensatz LST-Busline-Font.xml nicht gefunden!", "Fehler");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DisplayForm());
        }
    }
}