﻿#region .Net Base Library Namespaces
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net.Mail;
using System.Text;
using System.Net;
using _Form = System.Windows.Forms;
#endregion

#region Gmail API Libraries
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading.Tasks;
#endregion

namespace Mail_Client
{
    public partial class Send_Mail : Form
    {
        private Gmail _gmail = new Gmail();
        Form appLoadForm = new Form();
        // Variables to use in form
        bool flag = false;
        string FileNameBeforeEditing = null;
        int Total_Mail_Sent = 0;
        uint count = 0;
        UserCredential credential;
        string applicationDirectory = "MailClient";
        public Send_Mail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Check for Internet Connectivity on System.
        /// </summary>
        /// <returns>
        /// Exceptions:
        /// </returns>
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void Reload_ComboBox_Of_Form1()
        {
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if(!CheckForInternetConnection())   //Check for "system is not connected to the internet" is true
            {
                MessageBox.Show("No Internet Connection. Data will be saved offline.","No Internet",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            var userCredential = _gmail.Authorize();

            UpdateDesign();

            ShowLoadingMessageForm();

            await Task.Delay(10000);

            await userCredential;

            appLoadForm.Close();

            // Loading 
            FileReadWrite.path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Group Names.txt";

            FileReadWrite.LoadDataFromFileInComboBox(comboBox_to);

            // Reading Total Mail Sent Quota and storing in variable
            string path1 = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Total Mails Sent Quota.txt";

            //Open the file to read from.
            using (StreamReader sr = File.OpenText(path1))
            {
                Total_Mail_Sent = Convert.ToInt32(sr.ReadLine());
            }
        }

        private void ShowLoadingMessageForm()
        {
            _Form.Label appLoadFormLabel = new _Form.Label();
            appLoadFormLabel.Text = "Application is Loading. Please Wait ...";
            appLoadFormLabel.AutoSize = true;
            appLoadFormLabel.Location = new Point(20, 20);

            appLoadForm = new Form();
            appLoadForm.Width = 500;
            appLoadForm.Height = 100;
            appLoadForm.StartPosition = FormStartPosition.CenterScreen;
            appLoadForm.Controls.Add(appLoadFormLabel);
            appLoadForm.BackColor = Color.Linen;
            appLoadForm.MinimizeBox = false;
            appLoadForm.MaximizeBox = false;
            appLoadForm.Show();
        }

        private void UpdateDesign()
        {
            Color y = Color.FromArgb(31, 65, 119);
            //label_step1.ForeColor = y;
            //label_step2.ForeColor = y;
            label_to.ForeColor = y;
            label_subject.ForeColor = y;
            label_content.ForeColor = y;

            button_authorize.FlatAppearance.BorderColor = y;
            button_authorize.ForeColor = y;

            button_edit_group_list.FlatAppearance.BorderColor = y;
            button_edit_group_list.ForeColor = y;

            button_send_mail.FlatAppearance.BorderColor = y;
            button_send_mail.ForeColor = y;

            button_clear.FlatAppearance.BorderColor = y;
            button_clear.ForeColor = y;

            button_exit.FlatAppearance.BorderColor = y;
            button_exit.ForeColor = y;

            send_mail_menu.ForeColor = y;

            comboBox_to.ForeColor = y;

            textBox_subject.ForeColor = y;

            richTextBox_content.ForeColor = y;

            Color x = Color.FromArgb(140, 197, 67);
            //menuStrip1.BackColor = x;
        }

        /******************* Form Events Start *******************/
        /******************* Form Events Start *******************/

        /******************* Form Controls Events Start *******************/

        private async void button_authorize_Click(object sender, EventArgs e)
        {
            await _gmail.Authorize();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /******************* Form Controls Events End *******************/

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string[] RetrieveDataFromFile(string FilePath)
        {
            string[] RecipientNames = new string[90];
            string NextLine;
            ushort Count = 0;

            using (StreamReader sr = File.OpenText(FilePath))
            {
                while (!sr.EndOfStream)
                {
                    NextLine = sr.ReadLine();

                    if (System.String.IsNullOrEmpty(NextLine))
                        continue;
                    else
                        RecipientNames[Count++] = NextLine;
                }
            }
            
            return RecipientNames;
        }

        private void button_edit_group_list_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox_Edit_Recipients.Items.Clear();

                string GroupName = comboBox_to.SelectedItem.ToString();
                string FilePath = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Groups\\" + GroupName + ".txt";
                string[] RecipientNames = new string[90];
                StreamReader sr = File.OpenText(FilePath);

                if (sr.EndOfStream)
                {
                    MessageBox.Show("Group has no recipient", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sr.Close();
                }
                else
                {
                    Array.Copy(RetrieveDataFromFile(FilePath),RecipientNames,90);

                    foreach(string RN in RecipientNames)
                    {
                        if (RN == null)
                            break;
                        count++;                 
                        checkedListBox_Edit_Recipients.Items.Add(RN);
                        checkedListBox_Edit_Recipients.SetItemChecked(checkedListBox_Edit_Recipients.Items.IndexOf(RN), true);
                    }

                    button_edit_group_list.Enabled = false;
                    button_Save_Edit_List.Enabled = false;
                    button_Save_Edit_List.Visible = true;
                    button_Close_Editing.Visible = true;
                    checkedListBox_Edit_Recipients.Visible = true;
                }
            }
            catch (FileNotFoundException t)
            {
                MessageBox.Show("Group not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(NullReferenceException t)
            {
                MessageBox.Show("No Group Selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception t)
            {
                MessageBox.Show("Group Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private void comboBox_to_SelectedValueChanged(object sender, EventArgs e)
        {
            string path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_to.SelectedItem.ToString() + ".txt";

            if (checkedListBox_Edit_Recipients.Visible == true & button_Save_Edit_List.Visible == true & button_Close_Editing.Visible == true)
            {
               checkedListBox_Edit_Recipients.Items.Clear();

                try
                {
                    //Open the file to read from.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            checkedListBox_Edit_Recipients.Items.Add(s);
                            checkedListBox_Edit_Recipients.SetItemChecked(checkedListBox_Edit_Recipients.Items.IndexOf(s), true);
                        }
                    }
                }
                catch (Exception t)
                {
                    MessageBox.Show("Something went wrong. Please check carefully", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void checkedListBox_Edit_Recipients_Click(object sender, EventArgs e)
        {
            button_Save_Edit_List.Enabled = true;
        }

        private void button_Save_Edit_List_Click(object sender, EventArgs e)
        {
            flag = true;

            FileNameBeforeEditing = comboBox_to.SelectedItem.ToString();

            FileReadWrite.path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Groups\\__" + comboBox_to.SelectedItem.ToString() + "(Edited).txt";

            FileReadWrite.WriteInFileFromCheckListBox(checkedListBox_Edit_Recipients.CheckedItems);

            comboBox_to.Items.Add("__" + comboBox_to.SelectedItem.ToString() + "(Edited)");
            comboBox_to.SelectedIndex = 0;

            checkedListBox_Edit_Recipients.Visible = false;
            button_Save_Edit_List.Visible = false;
            button_Close_Editing.Visible = false;
            button_edit_group_list.Enabled = true;
        }

        private void button_Close_Editing_Click(object sender, EventArgs e)
        {
            checkedListBox_Edit_Recipients.Items.Clear();
            button_edit_group_list.Enabled = true;
            checkedListBox_Edit_Recipients.Visible = false;
            button_Save_Edit_List.Visible = false;
            button_Close_Editing.Visible = false;
        }

        private void button_send_mail_Click(object sender, EventArgs e)
        {
            

            int count_mail_ids = 0;

            try
            {
                string path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_to.SelectedItem.ToString() + ".txt";

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    
                    while((s = sr.ReadLine()) != null)
                    {
                        count_mail_ids++;
                    }
                }

                //Open the file to read from.
                using (StreamReader sr = File.OpenText(path))
                {
                    progressBar1.Maximum = count_mail_ids - 1;

                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        MailAddress adrs = new MailAddress(s);

                        //Creating Message
                        MailMessage mail = new MailMessage();
                        mail.To.Add(adrs);
                        mail.Subject = textBox_subject.Text;
                        mail.Body = richTextBox_content.Text;
                        mail.From = new MailAddress(textBox_From_Email_ID.Text);
                        mail.IsBodyHtml = true;

                        MimeKit.MimeMessage mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);

                        //Sending Mail
                        _gmail.SendMail(mimeMessage.ToString(), "me");

                        progressBar1.PerformStep();
                    }
                }

                Save_Sent_Mail();

                MessageBox.Show("Mail Sent Succesfully and Saved Locally");

                textBox_subject.Clear();
                richTextBox_content.Clear();

                progressBar1.Value = 0;
            }
            catch (Exception t)
            {
                MessageBox.Show("Something went wrong. Please check carefully", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Save_Sent_Mail()
        {
            // Creating New Directory for last Sent Mail as named "Mail <mail number>"
            DirectoryInfo di = new DirectoryInfo(FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + ++Total_Mail_Sent);
            di.Create();

            // Setting Path for File to read where contacts are stored of last sent mail
            string path1 = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_to.SelectedItem.ToString() + ".txt";

            // Setting Path for storing last mail sent reciepients ID
            string path2 = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + Total_Mail_Sent.ToString() + "\\To.txt";

            // Create a file to write to Reciepients of last mail.
            using (StreamWriter sw = File.CreateText(path2))
            {
                //Open the file to read from.
                using (StreamReader sr = File.OpenText(path1))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        sw.WriteLine(s);
                    }
                }
            }


            FileReadWrite.path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + Total_Mail_Sent.ToString() + "\\Subject.txt";
            FileReadWrite.WriteInFileTextBoxContent(textBox_subject.Text);

            FileReadWrite.path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + Total_Mail_Sent.ToString() + "\\Content.txt";
            FileReadWrite.WriteInFileFromRichTextBox(richTextBox_content.Lines);

            // Writing of Total Mails Sent in "Total Mail Sent Quota File"
            string path3 = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Total Mails Sent Quota.txt";

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path3))
            {
                sw.WriteLine(Total_Mail_Sent.ToString());
            }
        }

        private void Form1_Main_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                string path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Groups\\__" + FileNameBeforeEditing + "(Edited).txt";

                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        private void viewGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Group View_Group_Form = new View_Group();
            View_Group_Form.ShowDialog();
        }

        private void createGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_Group Create_Group_Form = new Create_Group();
            Create_Group_Form.ShowDialog();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_From_Email_ID.Clear();
            textBox_subject.Clear();
            richTextBox_content.Clear();
        }

        private void comboBox_to_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox_Edit_Recipients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        

        private void view_group_Click(object sender, EventArgs e)
        {
            View_Group VG = new View_Group();
            VG.ShowDialog();
        }

        private void create_group_Click(object sender, EventArgs e)
        {
            Create_Group CG = new Create_Group();
            CG.ShowDialog();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        

        #region Menu Items Click Events Definition

        private void add_contact_Click(object sender, EventArgs e)
        {
            Add_Contact NewContact = new Add_Contact();
            NewContact.ShowDialog();
        }

        private void add_multiple_contacts_Click(object sender, EventArgs e)
        {
            Add_Multiple_Contacts AMC = new Add_Multiple_Contacts();
            AMC.ShowDialog();

            // Loading group names in combobox
            FileReadWrite.path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Group Names.txt";

            comboBox_to.Items.Clear();
            FileReadWrite.LoadDataFromFileInComboBox(comboBox_to);
        }

        private void about_Click(object sender, EventArgs e)
        {
            About AboutApplication = new About();
            AboutApplication.ShowDialog();
        }

        #endregion

        private void comboBox_to_DropDown(object sender, EventArgs e)
        {
            comboBox_to.Items.Clear();
            FileReadWrite.LoadDataFromFileInComboBox(comboBox_to);
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contacts contactsWindows = new Contacts();
            contactsWindows.ShowDialog();
        }

        private void mailServersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                Mail_Client.Views.Mail_Server.MailServers mailServers = new Views.Mail_Server.MailServers();
                mailServers.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong. Mail Servers can't be open");

            }
            
        }
    }
}
