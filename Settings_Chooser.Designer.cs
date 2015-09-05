namespace TrueCryptSimpleGUI
{
    partial class Settings_Chooser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_drive = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_driveEx = new TrueCryptSimpleGUI.ComboBoxEx();
            this.SuspendLayout();
            // 
            // cmb_drive
            // 
            this.cmb_drive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_drive.FormattingEnabled = true;
            this.cmb_drive.Location = new System.Drawing.Point(15, 15);
            this.cmb_drive.Name = "cmb_drive";
            this.cmb_drive.Size = new System.Drawing.Size(238, 23);
            this.cmb_drive.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(15, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "drag&drop the file container";
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "use {here} for app current dir";
            // 
            // cmb_driveEx
            // 
            this.cmb_driveEx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_driveEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_driveEx.FormattingEnabled = true;
            this.cmb_driveEx.ImageList = null;
            this.cmb_driveEx.IntegralHeight = false;
            this.cmb_driveEx.ItemHeight = 34;
            this.cmb_driveEx.Location = new System.Drawing.Point(15, 109);
            this.cmb_driveEx.Name = "cmb_driveEx";
            this.cmb_driveEx.Size = new System.Drawing.Size(121, 40);
            this.cmb_driveEx.TabIndex = 3;
            // 
            // Settings_Chooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 161);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_driveEx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmb_drive);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Settings_Chooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_drive;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private ComboBoxEx cmb_driveEx;
        private System.Windows.Forms.Label label1;
    }
}