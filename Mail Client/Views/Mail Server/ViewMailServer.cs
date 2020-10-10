using Mail_Client.Constants;
using Mail_Client.Managers;
using Mail_Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mail_Client.Views.Mail_Server
{
    public partial class ViewMailServer : Form
    {

        MailServerManager mailServerManager = new MailServerManager();

        int serverID { get; set; }

        public ViewMailServer()
        {
            InitializeComponent();
        }

        public ViewMailServer(int serverID)
        {

            InitializeComponent();

            this.serverID = serverID;

        }

        private void ViewMailServer_Load(object sender, EventArgs e)
        {

            try
            {

                StatusCombobox.DataSource = Enum.GetValues(typeof(Status));

                var server = mailServerManager.GetSingle(serverID);

                IDValueLabel.Text = server.ID.ToString();
                NameTextBox.Text = server.Name;
                DescriptionTextBox.Text = server.Description;
                HostTextBox.Text = server.Host;
                PortTextBox.Text = server.Port.ToString();
                UsernameTextBox.Text = server.Username;
                PasswordTextBox.Text = server.Password;
                FromAddressTextBox.Text = server.FromAddress;
                IsSecuredCheckbox.Checked = server.IsSecured;
                StatusCombobox.SelectedItem = server.Status;
                CreatedOnLabelValue.Text = server.CreatedOn.ToString();
                LastUpdatedOnLabelValue.Text = server.LastUpdatedOn.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to show the View Server Screen", ex.Message);

            }

        }

        private void UpdateandCloseButton_Click(object sender, EventArgs e)
        {

            try
            {

                MailServer UpdateServer = new MailServer()
                {
                    ID = Convert.ToInt32(IDValueLabel.Text),
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Host = HostTextBox.Text,
                    Port = Convert.ToInt32(PortTextBox.Text),
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    FromAddress = FromAddressTextBox.Text,
                    IsSecured = IsSecuredCheckbox.Checked,
                    Status = (Status)StatusCombobox.SelectedItem
                };

                mailServerManager.Update(UpdateServer);

                MessageBox.Show("Server is updated syccessfully");

                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to Update server details", ex.Message);

            }

        }


    }
}
