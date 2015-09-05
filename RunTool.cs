using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace TrueCryptSimpleGUI
{
    public class RunTool
    {
        //STATE :
        //0-mount
        //1-unmount

        public delegate void exitCodeReceived(int value,string filepath, int state);
        public event exitCodeReceived ExitCodeReceived;

        private string pathName;
        private string arg;
        private int state;



        public RunTool(string pathName, string arg)
        {
            this.pathName = pathName;
            this.arg = arg;
        }

        public  void RunAndGetOutput2()
        {
            if (!File.Exists(Application.StartupPath + "\\TrueCrypt.exe"))
            {
                General.Mes("TrueCrypt not found at " + Application.StartupPath + "\\TrueCrypt.exe", MessageBoxIcon.Information);
                return;
            }

            ProcessStartInfo ProcessInfo;
            ProcessInfo = new ProcessStartInfo(pathName, arg);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WorkingDirectory = Application.StartupPath;

            Process process = Process.Start(ProcessInfo);

            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_Exited);
        }

        void process_Exited(object sender, EventArgs e)
        {
            if (ExitCodeReceived != null)
                ExitCodeReceived((sender as Process).ExitCode, pathName, state);
        }

    }
}
