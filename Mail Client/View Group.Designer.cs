namespace Mail_Client
{
    partial class View_Group
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Group));
            this.comboBox_Group_Name = new System.Windows.Forms.ComboBox();
            this.dataGridView_Group_Email_IDs_Collection = new System.Windows.Forms.DataGridView();
            this.Email_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Select_Group = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Group_Email_IDs_Collection)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_Group_Name
            // 
            this.comboBox_Group_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Group_Name.FormattingEnabled = true;
            this.comboBox_Group_Name.Location = new System.Drawing.Point(144, 9);
            this.comboBox_Group_Name.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Group_Name.Name = "comboBox_Group_Name";
            this.comboBox_Group_Name.Size = new System.Drawing.Size(335, 24);
            this.comboBox_Group_Name.TabIndex = 0;
            this.comboBox_Group_Name.SelectedValueChanged += new System.EventHandler(this.comboBox_Group_Name_SelectedValueChanged);
            // 
            // dataGridView_Group_Email_IDs_Collection
            // 
            this.dataGridView_Group_Email_IDs_Collection.AllowUserToAddRows = false;
            this.dataGridView_Group_Email_IDs_Collection.AllowUserToDeleteRows = false;
            this.dataGridView_Group_Email_IDs_Collection.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_Group_Email_IDs_Collection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Group_Email_IDs_Collection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Email_ID});
            this.dataGridView_Group_Email_IDs_Collection.Location = new System.Drawing.Point(16, 55);
            this.dataGridView_Group_Email_IDs_Collection.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Group_Email_IDs_Collection.Name = "dataGridView_Group_Email_IDs_Collection";
            this.dataGridView_Group_Email_IDs_Collection.ReadOnly = true;
            this.dataGridView_Group_Email_IDs_Collection.Size = new System.Drawing.Size(464, 422);
            this.dataGridView_Group_Email_IDs_Collection.TabIndex = 1;
            // 
            // Email_ID
            // 
            this.Email_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.Email_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.Email_ID.HeaderText = "Email ID";
            this.Email_ID.Name = "Email_ID";
            this.Email_ID.ReadOnly = true;
            this.Email_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Email_ID.Width = 83;
            // 
            // label_Select_Group
            // 
            this.label_Select_Group.AutoSize = true;
            this.label_Select_Group.Location = new System.Drawing.Point(12, 18);
            this.label_Select_Group.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Select_Group.Name = "label_Select_Group";
            this.label_Select_Group.Size = new System.Drawing.Size(86, 16);
            this.label_Select_Group.TabIndex = 2;
            this.label_Select_Group.Text = "Select Group";
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Transparent;
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Close.Location = new System.Drawing.Point(380, 484);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(100, 28);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // View_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.button_Close;
            this.ClientSize = new System.Drawing.Size(832, 536);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_Select_Group);
            this.Controls.Add(this.dataGridView_Group_Email_IDs_Collection);
            this.Controls.Add(this.comboBox_Group_Name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "View_Group";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Group";
            this.Load += new System.EventHandler(this.Form5_View_Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Group_Email_IDs_Collection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Group_Name;
        private System.Windows.Forms.DataGridView dataGridView_Group_Email_IDs_Collection;
        private System.Windows.Forms.Label label_Select_Group;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_ID;
    }
}