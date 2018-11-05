namespace Mail_Client
{
    partial class Add_Multiple_Contacts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Multiple_Contacts));
            this.label_Enter_Bulk_Email_IDs = new System.Windows.Forms.Label();
            this.richTextBox_Bulk_Email_IDs = new System.Windows.Forms.RichTextBox();
            this.button_Add_Bulk_Email_IDs = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.textBox_Groups_Name = new System.Windows.Forms.TextBox();
            this.label_Groups_Name = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label_Enter_Bulk_Email_IDs
            // 
            this.label_Enter_Bulk_Email_IDs.AutoSize = true;
            this.label_Enter_Bulk_Email_IDs.Location = new System.Drawing.Point(16, 11);
            this.label_Enter_Bulk_Email_IDs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Enter_Bulk_Email_IDs.Name = "label_Enter_Bulk_Email_IDs";
            this.label_Enter_Bulk_Email_IDs.Size = new System.Drawing.Size(99, 16);
            this.label_Enter_Bulk_Email_IDs.TabIndex = 0;
            this.label_Enter_Bulk_Email_IDs.Text = "Enter Email IDs";
            // 
            // richTextBox_Bulk_Email_IDs
            // 
            this.richTextBox_Bulk_Email_IDs.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_Bulk_Email_IDs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Bulk_Email_IDs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox_Bulk_Email_IDs.Location = new System.Drawing.Point(139, 11);
            this.richTextBox_Bulk_Email_IDs.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Bulk_Email_IDs.Name = "richTextBox_Bulk_Email_IDs";
            this.richTextBox_Bulk_Email_IDs.Size = new System.Drawing.Size(355, 379);
            this.richTextBox_Bulk_Email_IDs.TabIndex = 1;
            this.richTextBox_Bulk_Email_IDs.Text = "";
            this.richTextBox_Bulk_Email_IDs.WordWrap = false;
            // 
            // button_Add_Bulk_Email_IDs
            // 
            this.button_Add_Bulk_Email_IDs.BackColor = System.Drawing.Color.Transparent;
            this.button_Add_Bulk_Email_IDs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Add_Bulk_Email_IDs.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Add_Bulk_Email_IDs.Location = new System.Drawing.Point(139, 434);
            this.button_Add_Bulk_Email_IDs.Margin = new System.Windows.Forms.Padding(4);
            this.button_Add_Bulk_Email_IDs.Name = "button_Add_Bulk_Email_IDs";
            this.button_Add_Bulk_Email_IDs.Size = new System.Drawing.Size(153, 28);
            this.button_Add_Bulk_Email_IDs.TabIndex = 2;
            this.button_Add_Bulk_Email_IDs.Text = "Add All Email IDs";
            this.button_Add_Bulk_Email_IDs.UseVisualStyleBackColor = false;
            this.button_Add_Bulk_Email_IDs.Click += new System.EventHandler(this.button_Add_Bulk_Email_IDs_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Transparent;
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Close.Location = new System.Drawing.Point(301, 434);
            this.button_Close.Margin = new System.Windows.Forms.Padding(4);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(100, 28);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = false;
            // 
            // textBox_Groups_Name
            // 
            this.textBox_Groups_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_Groups_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Groups_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Groups_Name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_Groups_Name.Location = new System.Drawing.Point(139, 399);
            this.textBox_Groups_Name.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_Groups_Name.Name = "textBox_Groups_Name";
            this.textBox_Groups_Name.Size = new System.Drawing.Size(355, 22);
            this.textBox_Groups_Name.TabIndex = 4;
            this.textBox_Groups_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Groups_Name_KeyPress);
            // 
            // label_Groups_Name
            // 
            this.label_Groups_Name.AutoSize = true;
            this.label_Groups_Name.Location = new System.Drawing.Point(16, 402);
            this.label_Groups_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Groups_Name.Name = "label_Groups_Name";
            this.label_Groups_Name.Size = new System.Drawing.Size(119, 16);
            this.label_Groups_Name.TabIndex = 5;
            this.label_Groups_Name.Text = "Enter Group Name";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(139, 469);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(355, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            // 
            // Add_Multiple_Contacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.button_Close;
            this.ClientSize = new System.Drawing.Size(655, 501);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_Groups_Name);
            this.Controls.Add(this.textBox_Groups_Name);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Add_Bulk_Email_IDs);
            this.Controls.Add(this.richTextBox_Bulk_Email_IDs);
            this.Controls.Add(this.label_Enter_Bulk_Email_IDs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_Multiple_Contacts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Multiple Contacts";
            this.Load += new System.EventHandler(this.Form3_Add_Bulk_Email_IDs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Enter_Bulk_Email_IDs;
        private System.Windows.Forms.RichTextBox richTextBox_Bulk_Email_IDs;
        private System.Windows.Forms.Button button_Add_Bulk_Email_IDs;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TextBox textBox_Groups_Name;
        private System.Windows.Forms.Label label_Groups_Name;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}