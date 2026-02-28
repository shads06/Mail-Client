using System;
using System.Windows.Forms;
using MailClient.Core;
using MailClient.DAL.XMLManagers;

namespace Mail_Client.Views.Contact
{
    public partial class ViewContact : Form
    {

        int ContactID { get; set; }

        ContactRepository contactManager = new ContactRepository();

        public ViewContact()
        {
            InitializeComponent();
        }

        public ViewContact(int ContactID)
        {

            InitializeComponent();

            this.ContactID = ContactID;

        }

        private async void ViewContact_Load(object sender, EventArgs e)
        {

            try
            {

                StatusCombobox.DataSource = Enum.GetValues(typeof(Status));

                var Contact = await contactManager.GetSingleAsync(ContactID);

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
                
                MailClient.Core.Models.Contact Contact = new MailClient.Core.Models.Contact();
                Contact.ID = Convert.ToInt32(IDValueLabel.Text);
                Contact.Name = NameTextbox.Text;
                Contact.Email = EmailIDTextbox.Text;
                Contact.Status = (Status)StatusCombobox.SelectedItem;
                Contact.LastUpdatedOn = DateTime.UtcNow;

                contactManager.UpdateAsync(Contact);

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
