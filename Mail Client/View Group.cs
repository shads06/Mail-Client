using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Mail_Client
{
    public partial class View_Group : Form
    {
        public View_Group()
        {
            InitializeComponent();
        }

        private void Form5_View_Group_Load(object sender, EventArgs e)
        {
            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

            FunctionCollection.LoadDataFromFileInComboBox(comboBox_Group_Name);

            comboBox_Group_Name.SelectedIndex = 0;
        }

        private void comboBox_Group_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView_Group_Email_IDs_Collection.Rows.Clear();
            string path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_Group_Name.SelectedItem.ToString() + ".txt";

            //Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    dataGridView_Group_Email_IDs_Collection.Rows.Add(s);
                }
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
