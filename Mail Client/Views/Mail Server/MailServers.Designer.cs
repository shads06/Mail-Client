namespace Mail_Client.Views.Mail_Server
{
    partial class MailServers
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.ReloadMailServersButton = new System.Windows.Forms.Button();
            this.SearchMailServerButton = new System.Windows.Forms.Button();
            this.AddMailServerButton = new System.Windows.Forms.Button();
            this.MailServersDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MailServersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ExitButton);
            this.splitContainer1.Panel1.Controls.Add(this.ReloadMailServersButton);
            this.splitContainer1.Panel1.Controls.Add(this.SearchMailServerButton);
            this.splitContainer1.Panel1.Controls.Add(this.AddMailServerButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MailServersDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(759, 420);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(499, 29);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(36, 25);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ReloadMailServersButton
            // 
            this.ReloadMailServersButton.AutoSize = true;
            this.ReloadMailServersButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ReloadMailServersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReloadMailServersButton.Location = new System.Drawing.Point(541, 29);
            this.ReloadMailServersButton.Name = "ReloadMailServersButton";
            this.ReloadMailServersButton.Size = new System.Drawing.Size(53, 25);
            this.ReloadMailServersButton.TabIndex = 2;
            this.ReloadMailServersButton.Text = "Reload";
            this.ReloadMailServersButton.UseVisualStyleBackColor = true;
            this.ReloadMailServersButton.Click += new System.EventHandler(this.ReloadMailServersButton_Click);
            // 
            // SearchMailServerButton
            // 
            this.SearchMailServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchMailServerButton.Location = new System.Drawing.Point(600, 30);
            this.SearchMailServerButton.Name = "SearchMailServerButton";
            this.SearchMailServerButton.Size = new System.Drawing.Size(75, 23);
            this.SearchMailServerButton.TabIndex = 1;
            this.SearchMailServerButton.Text = "Search";
            this.SearchMailServerButton.UseVisualStyleBackColor = true;
            this.SearchMailServerButton.Visible = false;
            // 
            // AddMailServerButton
            // 
            this.AddMailServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMailServerButton.Location = new System.Drawing.Point(681, 30);
            this.AddMailServerButton.Name = "AddMailServerButton";
            this.AddMailServerButton.Size = new System.Drawing.Size(75, 23);
            this.AddMailServerButton.TabIndex = 0;
            this.AddMailServerButton.Text = "Add";
            this.AddMailServerButton.UseVisualStyleBackColor = true;
            this.AddMailServerButton.Click += new System.EventHandler(this.AddMailServerButton_Click);
            // 
            // MailServersDataGridView
            // 
            this.MailServersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MailServersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MailServersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MailServersDataGridView.Name = "MailServersDataGridView";
            this.MailServersDataGridView.Size = new System.Drawing.Size(759, 346);
            this.MailServersDataGridView.TabIndex = 0;
            // 
            // MailServers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(759, 420);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MailServers";
            this.Text = "Mail Servers";
            this.Activated += new System.EventHandler(this.MailServers_Activated);
            this.Load += new System.EventHandler(this.MailServers_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MailServersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView MailServersDataGridView;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ReloadMailServersButton;
        private System.Windows.Forms.Button SearchMailServerButton;
        private System.Windows.Forms.Button AddMailServerButton;
    }
}