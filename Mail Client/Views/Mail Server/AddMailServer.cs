using Mail_Client.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mail_Client.Models;
using Mail_Client.Helpers;
using Mail_Client.Core;

namespace Mail_Client.Views.Mail_Server
{
    public partial class AddMailServer : Form
    {

        MailServerManager mailServerManager = new MailServerManager();

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

                mailServerManager.Add(NewServer);

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

                mailServerManager.Add(NewServer);

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
