#region .Net Base Library Namespaces
using System;
using System.Windows.Forms;
using System.IO;
#endregion

namespace Mail_Client
{
    public partial class Create_Group : Form
    {
        bool click = true;

        public Create_Group()
        {
            InitializeComponent();
        }

        private void Form4_Create_Group_Load(object sender, EventArgs e)
        {
            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

            FunctionCollection.LoadDataFromFileInComboBox(comboBox_Group_Name);

            comboBox_Group_Name.SelectedIndex = 0;
        }

        private void comboBox_Group_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            checkedListBox_Group_Email_IDs.Items.Clear();

            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_Group_Name.SelectedItem.ToString() + ".txt";

            //Open the file to read from.
            using (StreamReader sr = File.OpenText(FunctionCollection.path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    // Writing In CheckedListBox
                    checkedListBox_Group_Email_IDs.Items.Add(s);

                    if (checkedListBox_New_Group_ID_Collection.Items.Contains(s))
                    {
                        click = false;
                       // checkedListBox_Group_Email_IDs.SetSelected(checkedListBox_New_Group_ID_Collection.Items.IndexOf(s), true);    No need of this code
                        checkedListBox_Group_Email_IDs.SetItemChecked(checkedListBox_Group_Email_IDs.Items.IndexOf(s), true);
                    }
                }
            }
        }

        private void checkedListBox_Group_Email_IDs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (click == true)
            {
                bool value = checkedListBox_New_Group_ID_Collection.Items.Contains(checkedListBox_Group_Email_IDs.SelectedItem);

                if (value == true)
                {
                    checkedListBox_New_Group_ID_Collection.Items.Remove(checkedListBox_Group_Email_IDs.SelectedItem);
                }
                else
                {
                    if (checkedListBox_New_Group_ID_Collection.Items.Count < 89)
                    {
                        checkedListBox_New_Group_ID_Collection.Items.Add(checkedListBox_Group_Email_IDs.SelectedItem);
                        checkedListBox_New_Group_ID_Collection.SetItemChecked(checkedListBox_New_Group_ID_Collection.Items.IndexOf(checkedListBox_Group_Email_IDs.SelectedItem), true);
                    }
                    else
                        MessageBox.Show("Group ID limit exceeds. You can add only UPTO 90 Email IDs in one Group.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                click = true;
        }

        private void button_Create_Group_Click(object sender, EventArgs e)
        {
            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

            FunctionCollection.WriteInFileTextBoxContent(textBox_Group_Name.Text);

            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + textBox_Group_Name.Text + ".txt";

            FunctionCollection.WriteInFileFromCheckListBox(checkedListBox_Group_Email_IDs.CheckedItems);

            MessageBox.Show("Group Created Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboBox_Group_Name.Items.Add(textBox_Group_Name.Text);
            checkedListBox_New_Group_ID_Collection.Items.Clear();
            textBox_Group_Name.Clear();
        }

        private void textBox_Group_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            char[] str = Path.GetInvalidFileNameChars();

            for (int counter = 0; counter < str.Length; counter++)
            {
                if (ch == str[counter] && ch != 8)
                {
                    e.Handled = true;
                    MessageBox.Show("Sorry");
                }
            }
        }
    }
}
