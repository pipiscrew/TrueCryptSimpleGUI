using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrueCryptSimpleGUI
{
    public partial class SettingsFRM : Form
    {
        public SettingsFRM()
        {
            InitializeComponent();

            lstv.SmallImageList = General.general_img;

            fill_list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings_Chooser c = new Settings_Chooser();
            c.Text = "Add Drive";

            if (c.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                fill_list();
          
        }

        private void fill_list()
        {
            lstv.Items.Clear();

            foreach (connection item in General.Connections)
            {
                lstv.Items.Add(item.drive_letter + ":\\", item.drive_img).SubItems.Add(item.drive_file);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;

            if (General.Mes("Would you like to delete from list the :\r\n" + lstv.SelectedItems[0].Text + " ?", MessageBoxIcon.Information, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            General.Connections.RemoveAt(lstv.SelectedItems[0].Index);

            General.SerializeList2File();

            fill_list();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;

            Settings_Chooser c = new Settings_Chooser(lstv.SelectedItems[0].Index);
            c.Text = "Update Drive";

            if (c.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                fill_list();
        }
    }
}
