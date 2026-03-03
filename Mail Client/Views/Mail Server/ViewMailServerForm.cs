using MailClient.Core;
using MailClient.Core.Models;
using MailClient.DAL.Managers;
using System;
using System.Windows.Forms;

namespace Mail_Client.Views
{
    public partial class ViewMailServerForm : Form
    {

        MailServerRepository mailServerManager = new MailServerRepository();

        int serverID { get; set; }

        public ViewMailServerForm()
        {
            InitializeComponent();
        }

        public ViewMailServerForm(int serverID)
        {

            InitializeComponent();

            this.serverID = serverID;

        }

        private async void ViewMailServer_Load(object sender, EventArgs e)
        {

            try
            {

                StatusCombobox.DataSource = Enum.GetValues(typeof(Status));

                var server = await mailServerManager.GetSingleAsync(serverID);

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

                mailServerManager.UpdateAsync(UpdateServer);

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
