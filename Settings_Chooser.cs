using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TrueCryptSimpleGUI
{
    public partial class Settings_Chooser : Form
    {
        public Settings_Chooser()
        {
            InitializeComponent();
            
            init_ctls();
        }

        int update_index=-1;
        public Settings_Chooser(int list_index)
        {
            InitializeComponent();
            
            init_ctls();

           this.cmb_drive.SelectedIndex=   this.cmb_drive.FindString(General.Connections[list_index].drive_letter);
            this.cmb_driveEx.SelectedIndex = General.Connections[list_index].drive_img;
            this.textBox1.Text = General.Connections[list_index].drive_file;

            update_index = list_index;
        }


        private void init_ctls()
        {
            for (int i = 65; i < 91; i++)
                cmb_drive.Items.Add(Char.ConvertFromUtf32(i));

            cmb_driveEx.ImageList = General.general_img;

            cmb_driveEx.Items.Add(new ComboBoxExItem("Type1", 0));
            cmb_driveEx.Items.Add(new ComboBoxExItem("Type2", 1));
            cmb_driveEx.Items.Add(new ComboBoxExItem("Type3", 2));
            cmb_driveEx.Items.Add(new ComboBoxExItem("Type4", 3));
            cmb_driveEx.Items.Add(new ComboBoxExItem("Type5", 4));
            cmb_driveEx.Items.Add(new ComboBoxExItem("Type6", 5));
            cmb_driveEx.Items.Add(new ComboBoxExItem("Type7", 6));
            cmb_driveEx.Items.Add(new ComboBoxExItem("Type8", 7));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_drive.SelectedIndex == -1)
            {
                General.Mes("Please select drive", MessageBoxIcon.Exclamation);
                return;
            }

            string d = textBox1.Text;

            if (d.StartsWith("{here}"))
                d = d.Replace("{here}", Application.StartupPath);

            if (!File.Exists(d))
            {
                General.Mes("File doesnt exist", MessageBoxIcon.Exclamation);
                return;
            }

            if (cmb_driveEx.SelectedIndex == -1)
            {
                General.Mes("Please select icon", MessageBoxIcon.Exclamation);
                return;
            }

            if (update_index>-1)
            {
                connection tmp = General.Connections[update_index];
                tmp.drive_file = textBox1.Text;
                tmp.drive_img = cmb_driveEx.SelectedIndex;
                tmp.drive_letter = cmb_drive.Text;
            }
            else
                General.Connections.Add(new connection(cmb_drive.Text, textBox1.Text, cmb_driveEx.SelectedIndex));
            
            if (General.SerializeList2File())
                this.DialogResult = DialogResult.OK;
        }

        #region TextBox DragDrop
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (File.Exists(FileList[0]))
                textBox1.Text = FileList[0];
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }
        #endregion

    }
}
