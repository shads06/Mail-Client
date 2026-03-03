#region .Net Base Library Namespaces
using MailClient.DAL.Managers;
using System;
using System.Linq;
using System.Windows.Forms;
#endregion

namespace Mail_Client.Views
{
    public partial class ViewGroupForm : Form
    {
        ContactListRepository contactListRepository = new ContactListRepository();
        public ViewGroupForm()
        {
            InitializeComponent();
        }

        private async void Form5_View_Group_Load(object sender, EventArgs e)
        {
            var cl = await contactListRepository.GetAllAsync();
            FileReadWrite.PopulateCombobox(comboBox_Group_Name, cl.Select(x => x.Name));
            comboBox_Group_Name.SelectedIndex = 0;
        }

        private async void comboBox_Group_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView_Group_Email_IDs_Collection.Rows.Clear();
            var contacts = await contactListRepository.GetContactsInListAsync(comboBox_Group_Name.SelectedItem.ToString());
            foreach (var contact in contacts)
            {
                dataGridView_Group_Email_IDs_Collection.Rows.Add(contact.Email);
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
