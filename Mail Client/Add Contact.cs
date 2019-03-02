#region .Net Base Library Namespaces
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Mail_Client
{
    public partial class Add_Contact : Form
    {
        public Add_Contact()
        {
            InitializeComponent();
        }

        private void Form2_Add_Email_ID_Load(object sender, EventArgs e)
        {
            System.Drawing.Color y = Color.FromArgb(31, 65, 119);
            
            label_email_id.ForeColor = y;
            
            button_add_mail_id.FlatAppearance.BorderColor = y;
            button_add_mail_id.ForeColor = y;
            
            button_exit.FlatAppearance.BorderColor = y;
            button_exit.ForeColor = y;
            
            textBox_email_id.ForeColor = y;
        }

        private void button_add_mail_id_Click(object sender, EventArgs e)
        {
            //FileReadWrite.path = FileReadWrite.GetCurrentDirectoryPath + "\\Data\\Groups\\__All Mail IDs.txt";
            //FileReadWrite.WriteInFileTextBoxContent(textBox_email_id.Text);
            MessageBox.Show("Mail Id Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox_email_id.Clear();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
