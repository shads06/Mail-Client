using System;
using System.Windows.Forms;
using MailClient.Core;
using MailClient.Core.Models;
using MailClient.DAL;
using MailClient.DAL.XMLManagers;

namespace Mail_Client.Views
{
    public partial class AddMailServer : Form
    {

        MailServerRepository mailServerManager = new MailServerRepository();

        public AddMailServer()
        {
            InitializeComponent();
        }

        private void AddAndCloseButton_Click(object sender, EventArgs e)
        {

            try
            {

                XMLHelper helper = new XMLHelper();

                MailServer NewServer = new MailServer()
                {
                    ID = helper.LastElementUniqueID(XMLDataStorage.Location + "MailServers.xml", "Server") + 1,
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Host = HostTextBox.Text,
                    Port = Convert.ToInt32(PortTextBox.Text),
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    FromAddress = FromAddressTextBox.Text,
                    IsSecured = IsSecuredCheckbox.Checked
                };

                mailServerManager.AddAsync(NewServer);

                MessageBox.Show("Mail Server is successfully added");

                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to add new mail server", ex.Message);

            }

        }

        private void AddAndAddAnotherButton_Click(object sender, EventArgs e)
        {

            try
            {

                XMLHelper helper = new XMLHelper();

                MailServer NewServer = new MailServer()
                {
                    ID = helper.LastElementUniqueID(XMLDataStorage.Location + "MailServers.xml", "Server") + 1,
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Host = HostTextBox.Text,
                    Port = Convert.ToInt32(PortTextBox.Text),
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    FromAddress = FromAddressTextBox.Text,
                    IsSecured = IsSecuredCheckbox.Checked
                };

                mailServerManager.AddAsync(NewServer);

                MessageBox.Show("Mail Server is successfully added");

                NameTextBox.Clear();
                DescriptionTextBox.Clear();
                HostTextBox.Clear();
                PortTextBox.Clear();
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
                FromAddressTextBox.Clear();
                IsSecuredCheckbox.Checked = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to add new mail server", ex.Message);

            }

        }

    }
}
