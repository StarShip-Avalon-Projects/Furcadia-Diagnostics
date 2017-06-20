using System;
using System.Windows.Forms;

namespace AccountTest
{
    internal class Program
    {
        #region Private Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleHttpWebRequest());
        }

        #endregion Private Methods
    }
}