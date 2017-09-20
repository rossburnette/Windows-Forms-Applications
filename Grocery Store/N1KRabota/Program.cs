using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace N1KRabota
{
    static class Program //glavniq clas
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
