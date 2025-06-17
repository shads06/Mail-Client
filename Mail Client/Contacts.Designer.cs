namespace Mail_Client
{
    partial class Contacts
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ExitContactsForm = new System.Windows.Forms.Button();
            this.ReloadContactsButton = new System.Windows.Forms.Button();
            this.SearchContactButton = new System.Windows.Forms.Button();
            this.AddContactButton = new System.Windows.Forms.Button();
            this.ContactsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ExitContactsForm);
            this.splitContainer1.Panel1.Controls.Add(this.ReloadContactsButton);
            this.splitContainer1.Panel1.Controls.Add(this.SearchContactButton);
            this.splitContainer1.Panel1.Controls.Add(this.AddContactButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ContactsGrid);
            this.splitContainer1.Size = new System.Drawing.Size(762, 457);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 1;
            // 
            // ExitContactsForm
            // 
            this.ExitContactsForm.AutoSize = true;
            this.ExitContactsForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitContactsForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitContactsForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitContactsForm.Location = new System.Drawing.Point(512, 25);
            this.ExitContactsForm.Name = "ExitContactsForm";
            this.ExitContactsForm.Size = new System.Drawing.Size(36, 25);
            this.ExitContactsForm.TabIndex = 0;
            this.ExitContactsForm.Text = "Exit";
            this.ExitContactsForm.UseVisualStyleBackColor = true;
            this.ExitContactsForm.Click += new System.EventHandler(this.ExitContactsForm_Click);
            // 
            // ReloadContactsButton
            // 
            this.ReloadContactsButton.AutoSize = true;
            this.ReloadContactsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ReloadContactsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReloadContactsButton.Location = new System.Drawing.Point(554, 25);
            this.ReloadContactsButton.Name = "ReloadContactsButton";
            this.ReloadContactsButton.Size = new System.Drawing.Size(53, 25);
            this.ReloadContactsButton.TabIndex = 0;
            this.ReloadContactsButton.Text = "Reload";
            this.ReloadContactsButton.UseVisualStyleBackColor = true;
            this.ReloadContactsButton.Click += new System.EventHandler(this.ReloadContactsButton_Click);
            // 
            // SearchContactButton
            // 
            this.SearchContactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchContactButton.Location = new System.Drawing.Point(613, 25);
            this.SearchContactButton.Name = "SearchContactButton";
            this.SearchContactButton.Size = new System.Drawing.Size(70, 25);
            this.SearchContactButton.TabIndex = 0;
            this.SearchContactButton.Text = "Search";
            this.SearchContactButton.UseVisualStyleBackColor = true;
            this.SearchContactButton.Visible = false;
            // 
            // AddContactButton
            // 
            this.AddContactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddContactButton.Location = new System.Drawing.Point(689, 25);
            this.AddContactButton.Name = "AddContactButton";
            this.AddContactButton.Size = new System.Drawing.Size(70, 25);
            this.AddContactButton.TabIndex = 0;
            this.AddContactButton.Text = "Add";
            this.AddContactButton.UseVisualStyleBackColor = true;
            this.AddContactButton.Click += new System.EventHandler(this.AddContactButton_Click);
            // 
            // ContactsGrid
            // 
            this.ContactsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContactsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContactsGrid.Location = new System.Drawing.Point(0, 0);
            this.ContactsGrid.Name = "ContactsGrid";
            this.ContactsGrid.Size = new System.Drawing.Size(762, 388);
            this.ContactsGrid.TabIndex = 0;
            // 
            // Contacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitContactsForm;
            this.ClientSize = new System.Drawing.Size(762, 457);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Contacts";
            this.Text = "Contacts";
            this.Activated += new System.EventHandler(this.Contacts_Activated);
            this.Load += new System.EventHandler(this.Contacts_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContactsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button SearchContactButton;
        private System.Windows.Forms.Button AddContactButton;
        private System.Windows.Forms.DataGridView ContactsGrid;
        private System.Windows.Forms.Button ReloadContactsButton;
        private System.Windows.Forms.Button ExitContactsForm;

    }
}