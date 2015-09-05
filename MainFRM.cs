using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrueCryptSimpleGUI;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MainFRM : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        public MainFRM()
        {
            InitializeComponent();

            this.Text = Application.ProductName + " v" + Application.ProductVersion;
            this.Icon = trayIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            General.general_img = new ImageList();
            General.general_img.ImageSize = new Size(32, 32);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd1);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd2);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd3);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd4);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd5);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd6);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd7);
            General.general_img.Images.Add(TrueCryptSimpleGUI.Properties.Resources.hdd8);

            lstv.LargeImageList = General.general_img;

            if (General.DeSerializeFile2List())
            {
                fill_list();
            }



            string[] args = Environment.GetCommandLineArgs();
            if (args.Length>1 && args[1] == "-a" && args.Length >= 3)
            {
                if (File.Exists(args[2]))
                {
                    if (args.Length > 3)
                        if (args[3] == "-e")
                            load_cmd(args[2], true);
                        else
                            load_cmd(args[2], false);

                    else
                        load_cmd(args[2], false);
                }
            }
            else 
                this.WindowState = FormWindowState.Normal;

            if (General.Connections.Count==0)
                trayIcon.ShowBalloonTip(5000, "No configuration", "Shift + Right Click - Open App \r\nShift + Left Click - Close App", ToolTipIcon.Info);
        }

        private void load_cmd(string file, bool show_explorer)
        {
            int res = General.Connections.FindIndex(delegate(connection x) { return x.drive_file.Contains(file); });

            if (res > -1)
                load_image(General.Connections[res].drive_file, General.Connections[res].drive_letter, show_explorer);
            else
                load_image(file, null, show_explorer);

        }

        private void fill_list()
        {
            lstv.Items.Clear();

            foreach (connection item in General.Connections)
            {
                lstv.Items.Add(item.drive_letter + ":\\", item.drive_img);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsFRM c = new SettingsFRM();
            c.Text = "Config";
            c.ShowDialog();

            fill_list();
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;

                // Set foreground window.
                SetForegroundWindow(this.Handle);
            }
            else if (Control.ModifierKeys == Keys.Shift && e.Button == System.Windows.Forms.MouseButtons.Left)
                Application.Exit();

        }

        private void MainFRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }

        }

        private void MainFRM_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //to minimize window
                this.WindowState = FormWindowState.Minimized;

                //to hide from taskbar
                this.Hide();
            }
        }



        delegate void r_ExitCodeReceived_Callback(int value, string filepath, int state);
        private void r_ExitCodeReceived(int value, string filepath, int state)
        {
            if (lbl_status.InvokeRequired)
            {
                lbl_status.BeginInvoke(new r_ExitCodeReceived_Callback(this.r_ExitCodeReceived), new object[] { value, filepath, state });
            }
            else
            {

                if (value != 0)
                    lbl_status.ForeColor = Color.Red;
                else
                    lbl_status.ForeColor = Color.Black;

                lbl_status.Text = "Exit code " + value.ToString();

                //if (state == 0 && value != 0)
                //{
                //lbl_status.Text = "Exited code " + value.ToString();
                //}
                //else if (state == 0 && value == 0)
                //{
                //    //button2.Visible = true;
                //}

                //Console.WriteLine(value);
                //Console.WriteLine(filepath);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbl_status.Text = "";
            RunTool r = null;
            r = new RunTool(Application.StartupPath + "\\TrueCrypt.exe", " /q /d");
            r.ExitCodeReceived += new RunTool.exitCodeReceived(r_ExitCodeReceived);
            r.RunAndGetOutput2();
        }

        private void lstv_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                lstv_context.Show(System.Windows.Forms.Cursor.Position);
                return;
            }

            bool show_explorer=false;

            if (Control.ModifierKeys == Keys.Shift && e.Button == System.Windows.Forms.MouseButtons.Left)
                show_explorer = true;

            int sel_index = lstv.SelectedItems[0].Index;

            string drive_letter = General.Connections[sel_index].drive_letter;
            string file = General.Connections[sel_index].drive_file;

            load_image(file, drive_letter,show_explorer);
        }

        private void load_image(string file, string drive_letter = null, bool show_explorer=false)
        {
            lbl_status.Text = "";

            if (file.StartsWith("{here}"))
                file = file.Replace("{here}", Application.StartupPath);

            if (!File.Exists(file))
            {
                General.Mes("file doesnt exist", MessageBoxIcon.Error);
                return;
            }


            RunTool r = null;

            if (String.IsNullOrEmpty(drive_letter))
                r = new RunTool(Application.StartupPath + "\\TrueCrypt.exe", " /q /v " + (show_explorer ? " /explore " : "") + " \"" + file + "\"");
            else
                r = new RunTool(Application.StartupPath + "\\TrueCrypt.exe", " /q /v " + (show_explorer ? " /explore " : "") + " \"" + file + "\" /l " + drive_letter);
            r.ExitCodeReceived += new RunTool.exitCodeReceived(r_ExitCodeReceived);
            r.RunAndGetOutput2();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;


            int sel_index = lstv.SelectedItems[0].Index;

            string drive_letter = General.Connections[sel_index].drive_letter;

            lbl_status.Text = "";
            RunTool r = null;
            r = new RunTool(Application.StartupPath + "\\TrueCrypt.exe", " /q /d " + drive_letter);
            r.ExitCodeReceived += new RunTool.exitCodeReceived(r_ExitCodeReceived);
            r.RunAndGetOutput2();
        }
    }
}
