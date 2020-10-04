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
using Mail_Client.Constants;

namespace Mail_Client.Views.Contact
{
    public partial class ViewContact : Form
    {

        int ContactID { get; set; }

        ContactManager contactManager = new ContactManager();

        public ViewContact()
        {
            InitializeComponent();
        }

        public ViewContact(int ContactID)
        {

            InitializeComponent();

            this.ContactID = ContactID;

        }

        private void ViewContact_Load(object sender, EventArgs e)
        {

            try
            {

                StatusCombobox.DataSource = Enum.GetValues(typeof(Status));

                var Contact = contactManager.GetSingle(ContactID);

                this.Text += Contact.Name;

                IDValueLabel.Text = Contact.ID.ToString();
                NameTextbox.Text = Contact.Name;
                EmailIDTextbox.Text = Contact.Email;
                StatusCombobox.SelectedItem = Contact.Status;
                CreatedOnValueLabel.Text = Contact.CreatedOn.ToString();
                LastUpdatedOnValueLabel.Text = Contact.LastUpdatedOn.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to initialize contact data.");

                throw;

            }

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                Mail_Client.Models.Contact Contact = new Models.Contact();
                Contact.ID = Convert.ToInt32(IDValueLabel.Text);
                Contact.Name = NameTextbox.Text;
                Contact.Email = EmailIDTextbox.Text;
                Contact.Status = (Status)StatusCombobox.SelectedItem;
                Contact.LastUpdatedOn = DateTime.UtcNow;

                contactManager.Update(Contact);

                MessageBox.Show("Successfully Updated Contact");

                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to update contact");

                throw;

            }
        }

    }

}
