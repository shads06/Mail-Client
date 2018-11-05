using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Security.AccessControl;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System.Threading;
using System.Net.Mail;

using MimeKit;

namespace Mail_Client
{
    public partial class Send_Mail : Form
    {
        Button button_name;
        bool click = true;

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailCompose, GmailService.Scope.GmailLabels };
        static string ApplicationName = "Consultax";

        // User Credential Declaration
        UserCredential credential;
        string credPath;

        // Variables to use in form
        bool flag = false;
        string FileNameBeforeEditing = null;
        int Total_Mail_Sent = 0;
        uint count = 0;
        public Send_Mail()
        {
            InitializeComponent();
        }


        public void Reload_ComboBox_Of_Form1()
        {
            
        }

        private void fillChart()
        {
            chart1.Series["Mail"].Points.Clear();

            //AddXY value in chart1 in series named as Salary  
            chart1.Series["Mail"].Points.AddXY("February", "2000");
            chart1.Series["Mail"].Points.AddXY("March", "800");
            chart1.Series["Mail"].Points.AddXY("April", "400");
            chart1.Series["Mail"].Points.AddXY("May", "100");
            chart1.Series["Mail"].Points.AddXY("June", "900");
            chart1.Series["Mail"].Points.AddXY("July", "900");
            //chart title  
           // chart1.Titles.Add("Mail Chart");
          
        }  

        void Load_Email_ID_In_Create_Group_ComboBox()
        {
            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

            FunctionCollection.LoadDataFromFileInComboBox(comboBox_Group_Name);
            FunctionCollection.LoadDataFromFileInComboBox(comboBox_Group_Names);

            comboBox_Group_Name.SelectedIndex = 0;
            comboBox_Group_Names.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_dashboard.BackColor = Color.FromArgb(60, 65, 68);
            button_name = button_dashboard;

            fillChart();
            button_Day.FlatAppearance.BorderSize = 1;

            Load_Email_ID_In_Create_Group_ComboBox();

            
            panel_Send_Mail.Hide();
            panel_Add_Contacts.Hide();
            panel_Create_Group.Hide();
            panel_View_Group.Hide();

            panel_active.Height = button_dashboard.Height;
            panel_active.Top = button_dashboard.Top;
            
            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
            l1.Text = "Application is Loading. Please Wait ...";
            l1.AutoSize = true;
            l1.Location = new Point(20, 20);

            Form f1 = new Form();
            f1.Width = 500;
            f1.Height = 100;
            f1.StartPosition = FormStartPosition.CenterScreen;
            f1.Controls.Add(l1);
            f1.BackColor = Color.Linen;
            f1.MinimizeBox = false;
            f1.MaximizeBox = false;
            f1.Show();

            //   UserCredential credential;
            try
            {
                using (var stream =
    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/main");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }
                f1.Close();
                MessageBox.Show("Authorization Completed Successfully", "Mail Client Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception t)
            {
                MessageBox.Show("Authorization Failed\n" + t.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            System.Drawing.Color y = Color.FromArgb(31, 65, 119);
            //label_step1.ForeColor = y;
            //label_step2.ForeColor = y;
            
            //Commented following code when re-design GUI
            /*
             * label_to.ForeColor = y;
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
            */
            //Design Comment Ended Above

            System.Drawing.Color x = Color.FromArgb(140, 197, 67);
            //menuStrip1.BackColor = x;

            // Loading 
            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

            FunctionCollection.LoadDataFromFileInComboBox(comboBox_to);

            // Reading Total Mail Sent Quota and storing in variable
            string path1 = FunctionCollection.CurrentDirectoryPath + "\\Data\\Total Mails Sent Quota.txt";

            //Open the file to read from.
            using (StreamReader sr = File.OpenText(path1))
            {
                Total_Mail_Sent = Convert.ToInt32(sr.ReadLine());
            }
        }

        private void button_authorize_Click(object sender, EventArgs e)
        {
            //   UserCredential credential;
            try
            {
                using (var stream =
    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/main");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                MessageBox.Show("Authorization Completed Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception t)
            {
                MessageBox.Show("Authorization Failed\n" + t.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void addEmailIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Contact add_email_id_form = new Add_Contact();
            add_email_id_form.ShowDialog();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBulkEmailIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Multiple_Contacts add_bulk_email_ids_form = new Add_Multiple_Contacts();
            add_bulk_email_ids_form.ShowDialog();

            // Loading group names in combobox
            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

            comboBox_to.Items.Clear();
            FunctionCollection.LoadDataFromFileInComboBox(comboBox_to);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_edit_group_list_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox_Edit_Recipients.Items.Clear();

                string path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_to.SelectedItem.ToString() + ".txt";

                //Open the file to read from.
                using (StreamReader sr = File.OpenText(path))
                {
                    button_edit_group_list.Enabled = false;

                    string s = "";

                    if ((s = sr.ReadLine()) != null)
                    {
                        button_Save_Edit_List.Enabled = false;

                        checkedListBox_Edit_Recipients.Visible = true;
                        button_Save_Edit_List.Visible = true;
                        button_Close_Editing.Visible = true;

                        do
                        {
                            count++;
                            checkedListBox_Edit_Recipients.Items.Add(s);
                            checkedListBox_Edit_Recipients.SetItemChecked(checkedListBox_Edit_Recipients.Items.IndexOf(s), true);
                        } while ((s = sr.ReadLine()) != null);
                    }
                    else
                        MessageBox.Show("Group doesn't have any mail address", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception t)
            {
                MessageBox.Show("Group Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_to_SelectedValueChanged(object sender, EventArgs e)
        {
            string path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_to.SelectedItem.ToString() + ".txt";

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

            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\__" + comboBox_to.SelectedItem.ToString() + "(Edited).txt";

            FunctionCollection.WriteInFileFromCheckListBox(checkedListBox_Edit_Recipients.CheckedItems);

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
            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            int count_mail_ids = 0;

            try
            {
                string path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_to.SelectedItem.ToString() + ".txt";

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

                        // Converting Message to Base64UrlEncode
                        Google.Apis.Gmail.v1.Data.Message message = new Google.Apis.Gmail.v1.Data.Message();
                        message.Raw = Base64UrlEncode(mimeMessage.ToString());

                        //Sending Mail
                        Send_Mail.SendMessage(service, "me", message);

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
            DirectoryInfo di = new DirectoryInfo(FunctionCollection.CurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + ++Total_Mail_Sent);
            di.Create();

            // Setting Path for File to read where contacts are stored of last sent mail
            string path1 = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_to.SelectedItem.ToString() + ".txt";

            // Setting Path for storing last mail sent reciepients ID
            string path2 = FunctionCollection.CurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + Total_Mail_Sent.ToString() + "\\To.txt";

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


            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + Total_Mail_Sent.ToString() + "\\Subject.txt";
            FunctionCollection.WriteInFileFromTextBox(textBox_subject.Text);

            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Sent Mails\\Mail " + Total_Mail_Sent.ToString() + "\\Content.txt";
            FunctionCollection.WriteInFileFromRichTextBox(richTextBox_content.Lines);

            // Writing of Total Mails Sent in "Total Mail Sent Quota File"
            string path3 = FunctionCollection.CurrentDirectoryPath + "\\Data\\Total Mails Sent Quota.txt";

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
                string path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\__" + FileNameBeforeEditing + "(Edited).txt";

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
            textBox_subject.Clear();
            richTextBox_content.Clear();
        }

        // ...

        /// <summary>
        /// Send an email from the user's mailbox to its recipient.
        /// </summary>
        /// <param name="service">Gmail API service instance.</param>
        /// <param name="userId">User's email address. The special value "me"
        /// can be used to indicate the authenticated user.</param>
        /// <param name="email">Email to be sent.</param>
        public static Google.Apis.Gmail.v1.Data.Message SendMessage(GmailService service, String userId, Google.Apis.Gmail.v1.Data.Message email)
        {
            try
            {
                return service.Users.Messages.Send(email, userId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return null;
        }

        // ...

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }

        private void comboBox_to_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About About_My_App_Form = new About();
            About_My_App_Form.ShowDialog();
        }

        private void checkedListBox_Edit_Recipients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void add_contact_Click(object sender, EventArgs e)
        {
            Add_Contact AC = new Add_Contact();
            AC.ShowDialog();
        }

        private void add_multiple_contacts_Click(object sender, EventArgs e)
        {
            Add_Multiple_Contacts AMC = new Add_Multiple_Contacts();
            AMC.ShowDialog();
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

        private void about_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.ShowDialog();
        }

        private void button_dashboard_Click(object sender, EventArgs e)
        {
            panel_Send_Mail.Hide();
            panel_Add_Contacts.Hide();
            panel_Create_Group.Hide();
            panel_View_Group.Hide();

            panel_Dashboard_Chart.Show();

            panel_active.Height = button_dashboard.Height;
            panel_active.Top = button_dashboard.Top;

            Back_Color_Changer(button_dashboard, button_name);
            button_name = button_dashboard;
        }

        private void Back_Color_Changer(object sender, object previous)
        {
            (sender as Button).BackColor = Color.FromArgb(60, 65, 68);
            (previous as Button).BackColor = Color.FromArgb(41, 44, 45);
        }

        private void button_SendMailSideMenuButton_Click(object sender, EventArgs e)
        {
            panel_Dashboard_Chart.Hide();
            panel_Add_Contacts.Hide();
            panel_Create_Group.Hide();
            panel_View_Group.Hide();

            panel_Send_Mail.Show();
            panel_Send_Mail.Top = button_dashboard.Top;
            
            panel_active.Height = button_SendMailSideMenuButton.Height;
            panel_active.Top = button_SendMailSideMenuButton.Top;

            Back_Color_Changer(button_SendMailSideMenuButton, button_name);
            button_name = button_SendMailSideMenuButton;
            
        }

        private void button_AddMultipleContactsSideMenuButton_Click(object sender, EventArgs e)
        {
            panel_Dashboard_Chart.Hide();
            panel_Send_Mail.Hide();
            panel_Create_Group.Hide();
            panel_View_Group.Hide();

            panel_Add_Contacts.Show();
            panel_Add_Contacts.Top = button_dashboard.Top;

            panel_active.Height = button_AddMultipleContactsSideMenuButton.Height;
            panel_active.Top = button_AddMultipleContactsSideMenuButton.Top;

            Back_Color_Changer(button_AddMultipleContactsSideMenuButton, button_name);
            button_name = button_AddMultipleContactsSideMenuButton;
        }

        private void button_CreateGroupSideMenuButton_Click(object sender, EventArgs e)
        {
            panel_Dashboard_Chart.Hide();
            panel_Send_Mail.Hide();
            panel_Add_Contacts.Hide();
            panel_View_Group.Hide();

            panel_Create_Group.Show();
            panel_Create_Group.Top = button_dashboard.Top;

            panel_active.Height = button_CreateGroupSideMenuButton.Height;
            panel_active.Top = button_CreateGroupSideMenuButton.Top;

            Back_Color_Changer(button_CreateGroupSideMenuButton, button_name);
            button_name = button_CreateGroupSideMenuButton;
        }

        private void button_ViewGroupSideMenuButton_Click(object sender, EventArgs e)
        {
            panel_Dashboard_Chart.Hide();
            panel_Send_Mail.Hide();
            panel_Add_Contacts.Hide();
            panel_Create_Group.Hide();

            panel_View_Group.Show();
            panel_View_Group.Top = button_dashboard.Top;
            
            panel_active.Height = button_ViewGroupSideMenuButton.Height;
            panel_active.Top = button_ViewGroupSideMenuButton.Top;

            Back_Color_Changer(button_ViewGroupSideMenuButton, button_name);
            button_name = button_ViewGroupSideMenuButton;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Exit_App_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            About AB = new About();
            AB.ShowDialog();
            panel_active.Height = button_About.Height;
            panel_active.Top = button_About.Top;
        }

        private void panel_Send_Mail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox_Bulk_Email_IDs_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_Create_Group_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Day_Click(object sender, EventArgs e)
        {
            button_Day.FlatAppearance.BorderSize = 1;
            button_Week.FlatAppearance.BorderSize = 0;
            button_15_Days.FlatAppearance.BorderSize = 0;
            button_Month.FlatAppearance.BorderSize = 0;
            button_6_Months.FlatAppearance.BorderSize = 0;
            button_Year.FlatAppearance.BorderSize = 0;
            fillChart();
        }

        private void button_Week_Click(object sender, EventArgs e)
        {
            button_Day.FlatAppearance.BorderSize = 0;
            button_Week.FlatAppearance.BorderSize = 1;
            button_15_Days.FlatAppearance.BorderSize = 0;
            button_Month.FlatAppearance.BorderSize = 0;
            button_6_Months.FlatAppearance.BorderSize = 0;
            button_Year.FlatAppearance.BorderSize = 0;
        }

        private void button_15_Days_Click(object sender, EventArgs e)
        {
            button_Day.FlatAppearance.BorderSize = 0;
            button_Week.FlatAppearance.BorderSize = 0;
            button_15_Days.FlatAppearance.BorderSize = 1;
            button_Month.FlatAppearance.BorderSize = 0;
            button_6_Months.FlatAppearance.BorderSize = 0;
            button_Year.FlatAppearance.BorderSize = 0;
        }

        private void button_Month_Click(object sender, EventArgs e)
        {
            button_Day.FlatAppearance.BorderSize = 0;
            button_Week.FlatAppearance.BorderSize = 0;
            button_15_Days.FlatAppearance.BorderSize = 0;
            button_Month.FlatAppearance.BorderSize = 1;
            button_6_Months.FlatAppearance.BorderSize = 0;
            button_Year.FlatAppearance.BorderSize = 0;
        }

        private void button_6_Months_Click(object sender, EventArgs e)
        {
            button_Day.FlatAppearance.BorderSize = 0;
            button_Week.FlatAppearance.BorderSize = 0;
            button_15_Days.FlatAppearance.BorderSize = 0;
            button_Month.FlatAppearance.BorderSize = 0;
            button_6_Months.FlatAppearance.BorderSize = 1;
            button_Year.FlatAppearance.BorderSize = 0;
        }

        private void button_Year_Click(object sender, EventArgs e)
        {
            button_Day.FlatAppearance.BorderSize = 0;
            button_Week.FlatAppearance.BorderSize = 0;
            button_15_Days.FlatAppearance.BorderSize = 0;
            button_Month.FlatAppearance.BorderSize = 0;
            button_6_Months.FlatAppearance.BorderSize = 0;
            button_Year.FlatAppearance.BorderSize = 1;
        }

        private void panel_Dashboard_Chart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_Group_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            checkedListBox_Group_Email_IDs.Items.Clear();

            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_Group_Name.SelectedItem.ToString() + ".txt";

            //Open the file to read from.
            using (StreamReader sr = File.OpenText(FunctionCollection.path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    // Writing In CheckedListBox
                    checkedListBox_Group_Email_IDs.Items.Add(s);

                    if (checkedListBox_New_Group_ID_Collection.Items.Contains(s))
                    {
                        click = false;
                        // checkedListBox_Group_Email_IDs.SetSelected(checkedListBox_New_Group_ID_Collection.Items.IndexOf(s), true);    No need of this code
                        checkedListBox_Group_Email_IDs.SetItemChecked(checkedListBox_Group_Email_IDs.Items.IndexOf(s), true);
                    }
                }
            }
        }

        private void checkedListBox_Group_Email_IDs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (click == true)
            {
                bool value = checkedListBox_New_Group_ID_Collection.Items.Contains(checkedListBox_Group_Email_IDs.SelectedItem);

                if (value == true)
                {
                    checkedListBox_New_Group_ID_Collection.Items.Remove(checkedListBox_Group_Email_IDs.SelectedItem);
                }
                else
                {
                    if (checkedListBox_New_Group_ID_Collection.Items.Count < 89)
                    {
                        checkedListBox_New_Group_ID_Collection.Items.Add(checkedListBox_Group_Email_IDs.SelectedItem);
                        checkedListBox_New_Group_ID_Collection.SetItemChecked(checkedListBox_New_Group_ID_Collection.Items.IndexOf(checkedListBox_Group_Email_IDs.SelectedItem), true);
                    }
                    else
                        MessageBox.Show("Group ID limit exceeds. You can add only UPTO 90 Email IDs in one Group.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                click = true;
        }

        private void button_Create_Group_Click(object sender, EventArgs e)
        {
            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

            FunctionCollection.WriteInFileFromTextBox(textBox_Group_Name.Text);

            FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + textBox_Group_Name.Text + ".txt";

            FunctionCollection.WriteInFileFromCheckListBox(checkedListBox_Group_Email_IDs.CheckedItems);

            MessageBox.Show("Group Created Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboBox_Group_Name.Items.Add(textBox_Group_Name.Text);
            checkedListBox_New_Group_ID_Collection.Items.Clear();
            textBox_Group_Name.Clear();
        }

        private void textBox_Group_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            char[] str = Path.GetInvalidFileNameChars();

            for (int counter = 0; counter < str.Length; counter++)
            {
                if (ch == str[counter] && ch != 8)
                {
                    e.Handled = true;
                    MessageBox.Show("Name is Invalid");
                }
            }
        }

        private void textBox_Groups_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            char[] str = Path.GetInvalidFileNameChars();

            for (int counter = 0; counter < str.Length; counter++)
            {
                if (ch == str[counter] && ch != 8)
                {
                    e.Handled = true;
                    MessageBox.Show("Sorry");
                }
            }
        }

        private void button_Add_Bulk_Email_IDs_Click(object sender, EventArgs e)
        {
            string path = null;
            int counter = 0;
            int counter2 = 0;
            string[] Mail_IDs_Collection = richTextBox_Bulk_Email_IDs.Lines;
            int Total_Email_IDs = Mail_IDs_Collection.Length;
            int Total_Group = 0;
            int Mail_ID_Number = 0;
            bool Is_Last_Group_Have_Less_Than_90_Emails;
            progressBar1.Maximum = Total_Email_IDs - 1;

            if (Total_Email_IDs % 90 == 0)
            {
                Total_Group = Total_Email_IDs / 90;
                Is_Last_Group_Have_Less_Than_90_Emails = false;
            }
            else
            {
                Total_Group = (Total_Email_IDs / 90) + 1;
                Is_Last_Group_Have_Less_Than_90_Emails = true;
            }

            for (counter = 1; counter <= Total_Group; counter++)
            {
                if (counter == Total_Group && Is_Last_Group_Have_Less_Than_90_Emails)
                {
                    path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + textBox_Groups_Name.Text + " " + counter.ToString() + "_(Contains " + (Total_Email_IDs - Mail_ID_Number).ToString() + " Mail IDs).txt";

                    FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

                    FunctionCollection.WriteInFileFromTextBox(textBox_Groups_Name.Text + " " + counter.ToString() + "_(Contains " + (Total_Email_IDs - Mail_ID_Number).ToString() + " Mail IDs)");
                }
                else
                {
                    path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + textBox_Groups_Name.Text + " " + counter.ToString() + ".txt";

                    FunctionCollection.path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Group Names.txt";

                    FunctionCollection.WriteInFileFromTextBox(textBox_Groups_Name.Text + " " + counter.ToString());
                }

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (counter2 = 1; counter2 <= 90; counter2++)
                    {
                        sw.WriteLine(Mail_IDs_Collection[Mail_ID_Number]);
                        Mail_ID_Number++;

                        progressBar1.PerformStep();
                        if (Mail_ID_Number == Total_Email_IDs)
                            break;
                    }
                }
            }

            MessageBox.Show("All Mail Ids Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox_Groups_Name.Clear();
            richTextBox_Bulk_Email_IDs.Clear();
            progressBar1.Value = 0;
        }

        private void comboBox_Group_Names_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView_Group_Email_IDs_Collection.Rows.Clear();
            string path = FunctionCollection.CurrentDirectoryPath + "\\Data\\Groups\\" + comboBox_Group_Name.SelectedItem.ToString() + ".txt";

            //Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    dataGridView_Group_Email_IDs_Collection.Rows.Add(s);
                }
            }
        }



    }

    public class FunctionCollection
    {
        public static string path = null; //Creating a file or reading a file at this path
        public static string CurrentDirectoryPath = Path.GetDirectoryName(Application.ExecutablePath);

        public static void WriteInFileFromTextBox(string FromTextBox)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(FromTextBox);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(FromTextBox);
                }
            }
        }

        public static void WriteInFileFromRichTextBox(string[] Mail_ID_Collection)
        {
            short counter = 0;

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (counter = 0; counter < Mail_ID_Collection.Length; counter++)
                    {
                        sw.WriteLine(Mail_ID_Collection[counter]);
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    for (counter = 0; counter < Mail_ID_Collection.Length; counter++)
                    {
                        sw.WriteLine(Mail_ID_Collection[counter]);
                    }
                }
            }
        }

        public static void WriteInFileFromCheckListBox(CheckedListBox.CheckedItemCollection chk)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (object itemChecked in chk)
                    {
                        sw.WriteLine(itemChecked.ToString());
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (object itemChecked in chk)
                    {
                        sw.WriteLine(itemChecked.ToString());

                    }
                }
            }
        }

        public static void LoadDataFromFileInComboBox(ComboBox cmb)
        {
            //Open the file to read from.
            if (!File.Exists(path))
                MessageBox.Show("All Groups are deleted externally. No group names are available to show in drop down", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            cmb.Items.Add(s);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong. Contact Developer", "File Can not open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }


}
