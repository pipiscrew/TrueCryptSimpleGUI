using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace TrueCryptSimpleGUI
{
    public static class General
    {
        public static ImageList general_img;
        public static List<connection> Connections;

        #region " Serialize / De List2File "

        public static bool SerializeList2File()
        {
            try
            {
                TextWriter textWriter = new StreamWriter(Application.StartupPath + "\\connections.dat");
                XmlSerializer serializer = new XmlSerializer(typeof(List<connection>));
                serializer.Serialize(textWriter, Connections);
                textWriter.Close();
                textWriter.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeSerializeFile2List()
        {
            try
            {
                Connections = null;
                TextReader textReader = new StreamReader(Application.StartupPath + "\\connections.dat");
                XmlSerializer deserializer = new XmlSerializer(typeof(List<connection>));
                Connections = (List<connection>)deserializer.Deserialize(textReader);

                textReader.Close();
                textReader.Dispose();

                return true;
            }
            catch { return false; }
            finally
            {
                if (Connections == null)
                    Connections = new List<connection>();
            }
        }

        #endregion

        public static DialogResult Mes(string descr, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons butt = MessageBoxButtons.OK)
        {
            if (descr.Length > 0)
                return MessageBox.Show(descr, Application.ProductName, butt, icon);
            else
                return DialogResult.OK;

        }

    }
}
