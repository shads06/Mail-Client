#region .Net Base Library Namespaces
using System;
using System.IO;
using System.Windows.Forms;
#endregion

namespace Mail_Client
{
    public static class FileReadWrite
    {
        /// <summary>
        /// To store path of a file. This must be set before calling any WriteToFile or ReadFromFile functions of FileReadWrite class
        /// </summary>
        public static string path = null; //Variable to hold a path for a file to do certain operation (Create, Delete, Modify, Open, Read, Write) on file. This must be set before calling any of the function of this class.

        /*
         * Variable to hold path of directory in which executable is placed.
         * Because Data generated from this executable is also saved in sub directory of same directory ...\Data\...
         */
        private static string CurrentDirectoryPath = Path.GetDirectoryName(Application.ExecutablePath);

        public static string GetCurrentDirectoryPath
        {
            get { return CurrentDirectoryPath; }
        }

        /// <summary>
        /// Writes content of a textbox into a file. Set path before calling this function
        /// </summary>
        /// <param name="TextBoxContent"></param>
        public static void WriteInFileTextBoxContent(string TextBoxContent)
        {
            using (StreamWriter sw = File.AppendText(path))     //Creates or open an existing file to the end of a file pointer
            {
                sw.WriteLine(TextBoxContent);       //Write line to the file
            }
        }

        public static void WriteInFileFromRichTextBox(string[] ContentCollection)
        {
            ushort counter = 0;
            
            using (StreamWriter sw = File.AppendText(path))
            {
                for (counter = 0; counter < ContentCollection.Length; counter++)
                {
                    sw.WriteLine(ContentCollection[counter]);
                }
            }
        }

        public static void WriteInFileFromCheckListBox(CheckedListBox.CheckedItemCollection chk)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (object itemChecked in chk)
                    {
                        sw.WriteLine(itemChecked.ToString());
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (object itemChecked in chk)
                    {
                        sw.WriteLine(itemChecked.ToString());

                    }
                }
            }
        }
        
        public static void LoadDataFromFileInComboBox(ComboBox cmb)
        {
            //Open the file to read from.
            if (!File.Exists(path))
                MessageBox.Show("All Groups are deleted externally. No group names are available to show in drop down", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            cmb.Items.Add(s);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong. Contact Developer", "File Can not open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
