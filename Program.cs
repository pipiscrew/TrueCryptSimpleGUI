using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using TrueCryptSimpleGUI;

namespace WindowsFormsApplication1
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, Application.ProductName);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainFRM());
            }
            else
            {
                SingleExecution.SwitchToCurrentInstance();
            }
        }
    }
}
