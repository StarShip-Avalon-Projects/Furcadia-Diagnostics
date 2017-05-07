using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dream_Runtime_Analyzer
{
    static class Program
    {
        public static Properties.Settings Settings = Properties.Settings.Default;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
