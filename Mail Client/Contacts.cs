using System;
using System.Linq;
using System.Windows.Forms;
using Mail_Client.Views;
using MailClient.DAL.Managers;

namespace Mail_Client
{
    public partial class Contacts : Form
    {

        ContactRepository contactManager = new ContactRepository();

        public Contacts()
        {
            InitializeComponent();
        }

        private async void Contacts_Load(object sender, EventArgs e)
        {

            try
            {
                var Contacts = await contactManager.GetAllAsync();

                var data = Contacts.ToList();

                ContactsGrid.DataSource = data;
                ContactsGrid.AutoGenerateColumns = true;
                ContactsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                DataGridViewButtonColumn viewContact = new DataGridViewButtonColumn();
                viewContact.Text = "View";
                viewContact.Name = "ViewContactButton";
                viewContact.HeaderText = "View Operation";
                viewContact.UseColumnTextForButtonValue = true;
                viewContact.FlatStyle = FlatStyle.Flat;

                ContactsGrid.CellClick += ContactsGrid_CellClick;

                ContactsGrid.Columns.Add(viewContact);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: Failed to retrieve all contacts");

            }

        }

        void ContactsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == ContactsGrid.Columns["ViewContactButton"].Index)
            {

                var row = e.RowIndex;

                if (row != -1)
                {

                    var ContactID = Convert.ToInt32(ContactsGrid.Rows[row].Cells["ID"].Value);

                    Mail_Client.Views.Contact.ViewContact viewContact = new Views.Contact.ViewContact(ContactID);
                    viewContact.ShowDialog();

                }
                
            }

        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {

            try
            {


                AddContactForm AddNewContactForm = new AddContactForm();
                AddNewContactForm.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to start the process: Add New Contact");

            }

        }

        private async void ReloadContactsButton_Click(object sender, EventArgs e)
        {

            try
            {

                var Contacts = await contactManager.GetAllAsync();

                var data = Contacts.ToList();

                ContactsGrid.DataSource = data;

                ContactsGrid.Update();

                ContactsGrid.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to reload contacts. Please try again");

            }

        }

        private void ExitContactsForm_Click(object sender, EventArgs e)
        {

            try
            {

                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to close the Contacts windows");

            }

        }

        private async void Contacts_Activated(object sender, EventArgs e)
        {

            try
            {

                var Contacts = await contactManager.GetAllAsync();

                var data = Contacts.ToList();

                ContactsGrid.DataSource = data;

                ContactsGrid.Update();

                ContactsGrid.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to reload contacts. Please click reload button and try again");

            }

        }

    }

}
