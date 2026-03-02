#region .Net Base Library Namespaces
using System;
using System.Windows.Forms;
using System.IO;
using MailClient.DAL.Managers;
using System.Threading.Tasks;
using System.Linq;
#endregion

namespace Mail_Client.Views
{
    public partial class CreateGroupForm : Form
    {
        bool click = true;
        ContactListRepository contactListRepository = new ContactListRepository();

        public CreateGroupForm()
        {
            InitializeComponent();
        }

        private async void Form4_Create_Group_Load(object sender, EventArgs e)
        {
            var cl = await contactListRepository.GetAllAsync();
            FileReadWrite.PopulateCombobox(comboBox_Group_Name, cl.Select(x => x.Name));
            comboBox_Group_Name.SelectedIndex = 0;
        }

        private async void comboBox_Group_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            checkedListBox_Group_Email_IDs.Items.Clear();
            var contacts = await contactListRepository.GetContactsInListAsync(comboBox_Group_Name.SelectedItem.ToString());

            // S3267: Use LINQ Select to simplify loop
            var emails = contacts.Select(contact => contact.Email);
            foreach (var email in emails)
            {
                checkedListBox_Group_Email_IDs.Items.Add(email);

                if (checkedListBox_New_Group_ID_Collection.Items.Contains(email))
                {
                    click = false;
                    checkedListBox_Group_Email_IDs.SetItemChecked(checkedListBox_Group_Email_IDs.Items.IndexOf(email), true);
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

        private async void button_Create_Group_Click(object sender, EventArgs e)
        {
            await contactListRepository.AddAsync(new MailClient.Core.Models.ContactList()
            {
                Name = textBox_Group_Name.Text,
                CreatedOn = DateTime.Now
            });

            // Fix: Convert CheckedItems to IEnumerable<string>
            var checkedEmails = checkedListBox_Group_Email_IDs.CheckedItems
                .OfType<string>()
                .ToList();

            await contactListRepository.AddContactsToListAsync(textBox_Group_Name.Text, checkedEmails);

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

        private void Create_Group_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }
    }
}
