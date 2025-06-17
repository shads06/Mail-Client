using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mail_Client.Managers;
using Mail_Client.Models;
using Mail_Client.Core;
using Mail_Client.Helpers;

namespace Mail_Client.Views
{
    public partial class AddContactForm : Form
    {

        string _location = XMLDataStorage.Location;

        ContactManager contactManager = new ContactManager();

        public AddContactForm()
        {
            InitializeComponent();
        }

        private void SaveContactButton_Click(object sender, EventArgs e)
        {

            try
            {
                XMLHelper helper = new XMLHelper();

                Mail_Client.Models.Contact NewContact = new Models.Contact();
                NewContact.ID = helper.LastElementUniqueID(_location + "Contacts.xml", "Contact") + 1;
                NewContact.Name = NameTextbox.Text;
                NewContact.Email = EmailIDTextbox.Text;

                contactManager.Add(NewContact);

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

                Mail_Client.Models.Contact NewContact = new Models.Contact();
                NewContact.ID = helper.LastElementUniqueID(_location + "Contacts.xml", "Contact") + 1;
                NewContact.Name = NameTextbox.Text;
                NewContact.Email = EmailIDTextbox.Text;

                contactManager.Add(NewContact);

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
