using System;
using MailClient.DAL;
using System.Windows.Forms;
using MailClient.Core;
using MailClient.DAL.Managers;
using MailClient.Core.Models;

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
                Contact NewContact = new Contact()
                {
                    Name = NameTextbox.Text,
                    Email = EmailIDTextbox.Text
                };
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
                Contact NewContact = new Contact();
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
