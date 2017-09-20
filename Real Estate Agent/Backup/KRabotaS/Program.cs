using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KRabotaS
{
    static class Program //glaVNIQ CLASS
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() //glavnata funkciq
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
