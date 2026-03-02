#region .Net Base Library Namespaces
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MailClient.DAL.Managers;
using MailClient.Core.Models;
using System.Linq;
#endregion

namespace Mail_Client.Views
{
    public partial class AddMultipleContactsForm : Form
    {
        ContactListRepository contactListRepository = new ContactListRepository();
        public AddMultipleContactsForm()
        {
            InitializeComponent();
        }

        private async void button_Add_Bulk_Email_IDs_Click(object sender, EventArgs e)
        {
            string path = null;
            int counter = 0;
            int counter2 = 0;
            string[] Mail_IDs_Collection = richTextBox_Bulk_Email_IDs.Lines;
            int Total_Email_IDs = Mail_IDs_Collection.Length;
            int Total_Group = 0;
            int Mail_ID_Number = 0;
            bool Is_Last_Group_Have_Less_Than_90_Emails;
            progressBar1.Maximum = Total_Email_IDs - 1;

            if (Total_Email_IDs % 90 == 0)
            {
                Total_Group = Total_Email_IDs / 90;
                Is_Last_Group_Have_Less_Than_90_Emails = false;
            }
            else
            {
                Total_Group = (Total_Email_IDs / 90) + 1;
                Is_Last_Group_Have_Less_Than_90_Emails = true;
            }

            for (counter = 1; counter <= Total_Group;counter++)
            {
                string listName = textBox_Groups_Name.Text + " " + counter.ToString();
                if (counter == Total_Group && Is_Last_Group_Have_Less_Than_90_Emails)
                    listName += "_(Contains " + (Total_Email_IDs - ((counter - 1) * 90)).ToString() + " Mail IDs)";
                await contactListRepository.AddAsync(new ContactList { Name = listName });
                await contactListRepository.AddContactsToListAsync(listName, Mail_IDs_Collection.Skip((counter - 1) * 90).Take(90).ToList());
                progressBar1.PerformStep();
            }

            MessageBox.Show("All Mail Ids Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox_Groups_Name.Clear();
            richTextBox_Bulk_Email_IDs.Clear();
            progressBar1.Value = 0;
        }

        private void Form3_Add_Bulk_Email_IDs_Load(object sender, EventArgs e)
        {
            System.Drawing.Color y = Color.FromArgb(31, 65, 119);


        }

        private void textBox_Groups_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            char[] str = Path.GetInvalidFileNameChars();

            for(int counter = 0; counter<str.Length;counter++)
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
