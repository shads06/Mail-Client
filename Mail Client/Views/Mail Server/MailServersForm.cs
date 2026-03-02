using MailClient.DAL.XMLManagers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Mail_Client.Views
{
    public partial class MailServersForm : Form
    {

        MailServerRepository mailServerManager = new MailServerRepository();

        public MailServersForm()
        {
            InitializeComponent();
        }

        private async void MailServers_Load(object sender, EventArgs e)
        {

            try
            {

                var AllServers = await mailServerManager.GetAllAsync();

                var AllServersList = AllServers.ToList();

                MailServersDataGridView.DataSource = AllServersList;
                MailServersDataGridView.AutoGenerateColumns = true;
                MailServersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                DataGridViewButtonColumn viewServer = new DataGridViewButtonColumn();
                viewServer.Text = "View";
                viewServer.Name = "ViewServerButton";
                viewServer.HeaderText = "View Operation";
                viewServer.UseColumnTextForButtonValue = true;
                viewServer.FlatStyle = FlatStyle.Flat;

                MailServersDataGridView.CellClick += MailServersDataGridView_CellClick;

                MailServersDataGridView.Columns.Add(viewServer);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong. Failed to retrieve Mail Servers", ex.Message);

            }

        }

        void MailServersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == MailServersDataGridView.Columns["ViewServerButton"].Index)
            {

                var row = e.RowIndex;

                if (row != -1)
                {

                    var ServerID = Convert.ToInt32(MailServersDataGridView.Rows[row].Cells["ID"].Value);

                    ViewMailServerForm viewMailServer = new ViewMailServerForm(ServerID);
                    viewMailServer.ShowDialog();

                }

            }

        }

        private void AddMailServerButton_Click(object sender, EventArgs e)
        {

            try
            {

                AddMailServerForm NewMailServerScreen = new AddMailServerForm();
                NewMailServerScreen.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to show Add Mail Server Screen");

            }

        }

        private async void ReloadMailServersButton_Click(object sender, EventArgs e)
        {

            try
            {
                
                var Servers = await mailServerManager.GetAllAsync();

                var data = Servers.ToList();

                MailServersDataGridView.DataSource = data;

                MailServersDataGridView.Update();

                MailServersDataGridView.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to reload servers data grid", ex.Message);

            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            try
            {

                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to close Mail Servers View", ex.Message);

            }

        }

        private async void MailServers_Activated(object sender, EventArgs e)
        {

            try
            {

                var Servers = await mailServerManager.GetAllAsync();

                var data = Servers.ToList();

                MailServersDataGridView.DataSource = data;

                MailServersDataGridView.Update();

                MailServersDataGridView.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to reload servers data grid", ex.Message);

            }

        }

    }
}
