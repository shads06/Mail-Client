using System;
using MailClient.DAL;
using System.Windows.Forms;
using MailClient.Core;
using MailClient.DAL.XMLManagers;

namespace Mail_Client.Views
{
    public partial class AddContactForm : Form
    {

        string _location = XMLDataStorage.Location;

        ContactRepository contactManager = new ContactRepository();

        public AddContactForm()
        {
            InitializeComponent();
        }

        private void SaveContactButton_Click(object sender, EventArgs e)
        {

            try
            {
                XMLHelper helper = new XMLHelper();

                MailClient.Core.Models.Contact NewContact = new MailClient.Core.Models.Contact();
                NewContact.ID = helper.LastElementUniqueID(_location + "Contacts.xml", "Contact") + 1;
                NewContact.Name = NameTextbox.Text;
                NewContact.Email = EmailIDTextbox.Text;

                contactManager.AddAsync(NewContact);

                MessageBox.Show("New Contact: " + NewContact.Name + " Added Successfully");

                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Some Unexpected error has occured while adding new contact. Please try again after sometime.");

            }

        }

        private void SaveAndAddAnotherContactButton_Click(object sender, EventArgs e)
        {

            try
            {
                XMLHelper helper = new XMLHelper();

                MailClient.Core.Models.Contact NewContact = new MailClient.Core.Models.Contact();
                NewContact.ID = helper.LastElementUniqueID(_location + "Contacts.xml", "Contact") + 1;
                NewContact.Name = NameTextbox.Text;
                NewContact.Email = EmailIDTextbox.Text;

                contactManager.AddAsync(NewContact);

                MessageBox.Show("New Contact: " + NewContact.Name + " Added Successfully");

                NameTextbox.Clear();
                EmailIDTextbox.Clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Some Unexpected error has occured while adding new contact. Please try again after sometime.");

            }

        }

    }
}
