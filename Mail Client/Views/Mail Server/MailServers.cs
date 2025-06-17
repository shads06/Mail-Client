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

namespace Mail_Client.Views.Mail_Server
{
    public partial class MailServers : Form
    {

        MailServerManager mailServerManager = new MailServerManager();

        public MailServers()
        {
            InitializeComponent();
        }

        private void MailServers_Load(object sender, EventArgs e)
        {

            try
            {

                var AllServers = mailServerManager.GetAll();

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

                    ViewMailServer viewMailServer = new ViewMailServer(ServerID);
                    viewMailServer.ShowDialog();

                }

            }

        }

        private void AddMailServerButton_Click(object sender, EventArgs e)
        {

            try
            {

                AddMailServer NewMailServerScreen = new AddMailServer();
                NewMailServerScreen.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to show Add Mail Server Screen");

            }

        }

        private void ReloadMailServersButton_Click(object sender, EventArgs e)
        {

            try
            {
                
                var Servers = mailServerManager.GetAll();

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

        private void MailServers_Activated(object sender, EventArgs e)
        {

            try
            {

                var Servers = mailServerManager.GetAll();

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
