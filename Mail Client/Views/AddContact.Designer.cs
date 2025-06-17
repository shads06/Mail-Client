namespace Mail_Client.Views
{
    partial class AddContactForm
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
            this.AddContactGroupBox_BasicDetails = new System.Windows.Forms.GroupBox();
            this.SaveAndAddAnotherContactButton = new System.Windows.Forms.Button();
            this.SaveContactButton = new System.Windows.Forms.Button();
            this.EmailIDTextbox = new System.Windows.Forms.TextBox();
            this.EmailIDLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AddContactGroupBox_BasicDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddContactGroupBox_BasicDetails
            // 
            this.AddContactGroupBox_BasicDetails.Controls.Add(this.SaveAndAddAnotherContactButton);
            this.AddContactGroupBox_BasicDetails.Controls.Add(this.SaveContactButton);
            this.AddContactGroupBox_BasicDetails.Controls.Add(this.EmailIDTextbox);
            this.AddContactGroupBox_BasicDetails.Controls.Add(this.EmailIDLabel);
            this.AddContactGroupBox_BasicDetails.Controls.Add(this.NameTextbox);
            this.AddContactGroupBox_BasicDetails.Controls.Add(this.NameLabel);
            this.AddContactGroupBox_BasicDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddContactGroupBox_BasicDetails.Location = new System.Drawing.Point(0, 0);
            this.AddContactGroupBox_BasicDetails.Name = "AddContactGroupBox_BasicDetails";
            this.AddContactGroupBox_BasicDetails.Size = new System.Drawing.Size(526, 160);
            this.AddContactGroupBox_BasicDetails.TabIndex = 0;
            this.AddContactGroupBox_BasicDetails.TabStop = false;
            this.AddContactGroupBox_BasicDetails.Text = "Basic Information";
            // 
            // SaveAndAddAnotherContactButton
            // 
            this.SaveAndAddAnotherContactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAndAddAnotherContactButton.Location = new System.Drawing.Point(207, 122);
            this.SaveAndAddAnotherContactButton.Name = "SaveAndAddAnotherContactButton";
            this.SaveAndAddAnotherContactButton.Size = new System.Drawing.Size(121, 23);
            this.SaveAndAddAnotherContactButton.TabIndex = 4;
            this.SaveAndAddAnotherContactButton.Text = "Save && Add Another";
            this.SaveAndAddAnotherContactButton.UseVisualStyleBackColor = true;
            this.SaveAndAddAnotherContactButton.Click += new System.EventHandler(this.SaveAndAddAnotherContactButton_Click);
            // 
            // SaveContactButton
            // 
            this.SaveContactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveContactButton.Location = new System.Drawing.Point(114, 122);
            this.SaveContactButton.Name = "SaveContactButton";
            this.SaveContactButton.Size = new System.Drawing.Size(87, 23);
            this.SaveContactButton.TabIndex = 4;
            this.SaveContactButton.Text = "Save && Close";
            this.SaveContactButton.UseVisualStyleBackColor = true;
            this.SaveContactButton.Click += new System.EventHandler(this.SaveContactButton_Click);
            // 
            // EmailIDTextbox
            // 
            this.EmailIDTextbox.Location = new System.Drawing.Point(114, 75);
            this.EmailIDTextbox.Name = "EmailIDTextbox";
            this.EmailIDTextbox.Size = new System.Drawing.Size(214, 20);
            this.EmailIDTextbox.TabIndex = 3;
            // 
            // EmailIDLabel
            // 
            this.EmailIDLabel.AutoSize = true;
            this.EmailIDLabel.Location = new System.Drawing.Point(43, 75);
            this.EmailIDLabel.Name = "EmailIDLabel";
            this.EmailIDLabel.Size = new System.Drawing.Size(46, 13);
            this.EmailIDLabel.TabIndex = 2;
            this.EmailIDLabel.Text = "Email ID";
            // 
            // NameTextbox
            // 
            this.NameTextbox.Location = new System.Drawing.Point(114, 33);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(214, 20);
            this.NameTextbox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(43, 33);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // AddContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 376);
            this.Controls.Add(this.AddContactGroupBox_BasicDetails);
            this.Name = "AddContactForm";
            this.Text = "Add Contact";
            this.AddContactGroupBox_BasicDetails.ResumeLayout(false);
            this.AddContactGroupBox_BasicDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddContactGroupBox_BasicDetails;
        private System.Windows.Forms.Button SaveContactButton;
        private System.Windows.Forms.TextBox EmailIDTextbox;
        private System.Windows.Forms.Label EmailIDLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button SaveAndAddAnotherContactButton;
    }
}