namespace Mail_Client.Views.Contact
{
    partial class ViewContact
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
            this.IDLabel = new System.Windows.Forms.Label();
            this.IDValueLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.EmailIDLabel = new System.Windows.Forms.Label();
            this.EmailIDTextbox = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusCombobox = new System.Windows.Forms.ComboBox();
            this.CreatedOnLabel = new System.Windows.Forms.Label();
            this.CreatedOnValueLabel = new System.Windows.Forms.Label();
            this.LastUpdatedOnLabel = new System.Windows.Forms.Label();
            this.LastUpdatedOnValueLabel = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(34, 35);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            // 
            // IDValueLabel
            // 
            this.IDValueLabel.AutoSize = true;
            this.IDValueLabel.Location = new System.Drawing.Point(204, 35);
            this.IDValueLabel.Name = "IDValueLabel";
            this.IDValueLabel.Size = new System.Drawing.Size(39, 13);
            this.IDValueLabel.TabIndex = 1;
            this.IDValueLabel.Text = "[value]";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(34, 68);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name";
            // 
            // NameTextbox
            // 
            this.NameTextbox.Location = new System.Drawing.Point(207, 68);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(201, 20);
            this.NameTextbox.TabIndex = 3;
            // 
            // EmailIDLabel
            // 
            this.EmailIDLabel.AutoSize = true;
            this.EmailIDLabel.Location = new System.Drawing.Point(34, 107);
            this.EmailIDLabel.Name = "EmailIDLabel";
            this.EmailIDLabel.Size = new System.Drawing.Size(43, 13);
            this.EmailIDLabel.TabIndex = 4;
            this.EmailIDLabel.Text = "EmailID";
            // 
            // EmailIDTextbox
            // 
            this.EmailIDTextbox.Location = new System.Drawing.Point(207, 107);
            this.EmailIDTextbox.Name = "EmailIDTextbox";
            this.EmailIDTextbox.Size = new System.Drawing.Size(201, 20);
            this.EmailIDTextbox.TabIndex = 5;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(34, 147);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Status";
            // 
            // StatusCombobox
            // 
            this.StatusCombobox.FormattingEnabled = true;
            this.StatusCombobox.Location = new System.Drawing.Point(207, 147);
            this.StatusCombobox.Name = "StatusCombobox";
            this.StatusCombobox.Size = new System.Drawing.Size(201, 21);
            this.StatusCombobox.TabIndex = 7;
            // 
            // CreatedOnLabel
            // 
            this.CreatedOnLabel.AutoSize = true;
            this.CreatedOnLabel.Location = new System.Drawing.Point(34, 193);
            this.CreatedOnLabel.Name = "CreatedOnLabel";
            this.CreatedOnLabel.Size = new System.Drawing.Size(61, 13);
            this.CreatedOnLabel.TabIndex = 8;
            this.CreatedOnLabel.Text = "Created On";
            // 
            // CreatedOnValueLabel
            // 
            this.CreatedOnValueLabel.AutoSize = true;
            this.CreatedOnValueLabel.Location = new System.Drawing.Point(204, 193);
            this.CreatedOnValueLabel.Name = "CreatedOnValueLabel";
            this.CreatedOnValueLabel.Size = new System.Drawing.Size(40, 13);
            this.CreatedOnValueLabel.TabIndex = 9;
            this.CreatedOnValueLabel.Text = "[Value]";
            // 
            // LastUpdatedOnLabel
            // 
            this.LastUpdatedOnLabel.AutoSize = true;
            this.LastUpdatedOnLabel.Location = new System.Drawing.Point(34, 232);
            this.LastUpdatedOnLabel.Name = "LastUpdatedOnLabel";
            this.LastUpdatedOnLabel.Size = new System.Drawing.Size(88, 13);
            this.LastUpdatedOnLabel.TabIndex = 10;
            this.LastUpdatedOnLabel.Text = "Last Updated On";
            // 
            // LastUpdatedOnValueLabel
            // 
            this.LastUpdatedOnValueLabel.AutoSize = true;
            this.LastUpdatedOnValueLabel.Location = new System.Drawing.Point(204, 232);
            this.LastUpdatedOnValueLabel.Name = "LastUpdatedOnValueLabel";
            this.LastUpdatedOnValueLabel.Size = new System.Drawing.Size(40, 13);
            this.LastUpdatedOnValueLabel.TabIndex = 11;
            this.LastUpdatedOnValueLabel.Text = "[Value]";
            // 
            // UpdateButton
            // 
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Location = new System.Drawing.Point(207, 280);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(106, 23);
            this.UpdateButton.TabIndex = 12;
            this.UpdateButton.Text = "Update && Close";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ViewContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 332);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.LastUpdatedOnValueLabel);
            this.Controls.Add(this.LastUpdatedOnLabel);
            this.Controls.Add(this.CreatedOnValueLabel);
            this.Controls.Add(this.CreatedOnLabel);
            this.Controls.Add(this.StatusCombobox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.EmailIDTextbox);
            this.Controls.Add(this.EmailIDLabel);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IDValueLabel);
            this.Controls.Add(this.IDLabel);
            this.Name = "ViewContact";
            this.Text = "View Contact: ";
            this.Load += new System.EventHandler(this.ViewContact_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label IDValueLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label EmailIDLabel;
        private System.Windows.Forms.TextBox EmailIDTextbox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ComboBox StatusCombobox;
        private System.Windows.Forms.Label CreatedOnLabel;
        private System.Windows.Forms.Label CreatedOnValueLabel;
        private System.Windows.Forms.Label LastUpdatedOnLabel;
        private System.Windows.Forms.Label LastUpdatedOnValueLabel;
        private System.Windows.Forms.Button UpdateButton;
    }
}