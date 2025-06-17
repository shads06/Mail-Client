namespace Mail_Client
{
    partial class Add_Contact
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Contact));
            this.label_email_id = new System.Windows.Forms.Label();
            this.button_add_mail_id = new System.Windows.Forms.Button();
            this.textBox_email_id = new System.Windows.Forms.TextBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_email_id
            // 
            this.label_email_id.AutoSize = true;
            this.label_email_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_email_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email_id.ForeColor = System.Drawing.Color.Black;
            this.label_email_id.Location = new System.Drawing.Point(17, 16);
            this.label_email_id.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_email_id.Name = "label_email_id";
            this.label_email_id.Size = new System.Drawing.Size(63, 18);
            this.label_email_id.TabIndex = 8;
            this.label_email_id.Text = "Email ID";
            // 
            // button_add_mail_id
            // 
            this.button_add_mail_id.BackColor = System.Drawing.Color.Transparent;
            this.button_add_mail_id.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_add_mail_id.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_add_mail_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_mail_id.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_add_mail_id.Location = new System.Drawing.Point(761, 16);
            this.button_add_mail_id.Margin = new System.Windows.Forms.Padding(5);
            this.button_add_mail_id.Name = "button_add_mail_id";
            this.button_add_mail_id.Size = new System.Drawing.Size(133, 34);
            this.button_add_mail_id.TabIndex = 12;
            this.button_add_mail_id.Text = "Add";
            this.button_add_mail_id.UseVisualStyleBackColor = false;
            this.button_add_mail_id.Click += new System.EventHandler(this.button_add_mail_id_Click);
            // 
            // textBox_email_id
            // 
            this.textBox_email_id.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_email_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_email_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email_id.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_email_id.Location = new System.Drawing.Point(124, 16);
            this.textBox_email_id.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_email_id.Name = "textBox_email_id";
            this.textBox_email_id.Size = new System.Drawing.Size(614, 22);
            this.textBox_email_id.TabIndex = 0;
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.Transparent;
            this.button_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_exit.Location = new System.Drawing.Point(905, 16);
            this.button_exit.Margin = new System.Windows.Forms.Padding(5);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(133, 34);
            this.button_exit.TabIndex = 13;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Add_Contact
            // 
            this.AcceptButton = this.button_add_mail_id;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.button_exit;
            this.ClientSize = new System.Drawing.Size(1052, 62);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.textBox_email_id);
            this.Controls.Add(this.button_add_mail_id);
            this.Controls.Add(this.label_email_id);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_Contact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Contact";
            this.Load += new System.EventHandler(this.Form2_Add_Email_ID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_email_id;
        private System.Windows.Forms.Button button_add_mail_id;
        private System.Windows.Forms.TextBox textBox_email_id;
        private System.Windows.Forms.Button button_exit;
    }
}