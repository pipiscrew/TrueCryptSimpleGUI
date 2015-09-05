using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrueCryptSimpleGUI
{
    public class connection
    {
        public string drive_letter { get; set; }
        public string drive_file { get; set; }
        public int drive_img { get; set; }

        public connection() { }
        public connection(string drive_letter, string drive_file, int drive_img)
        {
            this.drive_letter = drive_letter;
            this.drive_file = drive_file;
            this.drive_img = drive_img;

        }
    }
}
