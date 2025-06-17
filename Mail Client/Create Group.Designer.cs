namespace Mail_Client
{
    partial class Create_Group
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create_Group));
            this.label_Enter_Group_Name = new System.Windows.Forms.Label();
            this.textBox_Group_Name = new System.Windows.Forms.TextBox();
            this.checkedListBox_Group_Email_IDs = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_New_Group_ID_Collection = new System.Windows.Forms.CheckedListBox();
            this.button_Create_Group = new System.Windows.Forms.Button();
            this.comboBox_Group_Name = new System.Windows.Forms.ComboBox();
            this.label_Select_Group_Name = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Enter_Group_Name
            // 
            this.label_Enter_Group_Name.AutoSize = true;
            this.label_Enter_Group_Name.Location = new System.Drawing.Point(12, 11);
            this.label_Enter_Group_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Enter_Group_Name.Name = "label_Enter_Group_Name";
            this.label_Enter_Group_Name.Size = new System.Drawing.Size(119, 16);
            this.label_Enter_Group_Name.TabIndex = 0;
            this.label_Enter_Group_Name.Text = "Enter Group Name";
            // 
            // textBox_Group_Name
            // 
            this.textBox_Group_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_Group_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Group_Name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_Group_Name.Location = new System.Drawing.Point(147, 11);
            this.textBox_Group_Name.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Group_Name.Name = "textBox_Group_Name";
            this.textBox_Group_Name.Size = new System.Drawing.Size(328, 22);
            this.textBox_Group_Name.TabIndex = 3;
            this.textBox_Group_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Group_Name_KeyPress);
            // 
            // checkedListBox_Group_Email_IDs
            // 
            this.checkedListBox_Group_Email_IDs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBox_Group_Email_IDs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox_Group_Email_IDs.CheckOnClick = true;
            this.checkedListBox_Group_Email_IDs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedListBox_Group_Email_IDs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBox_Group_Email_IDs.FormattingEnabled = true;
            this.checkedListBox_Group_Email_IDs.HorizontalScrollbar = true;
            this.checkedListBox_Group_Email_IDs.Location = new System.Drawing.Point(599, 43);
            this.checkedListBox_Group_Email_IDs.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBox_Group_Email_IDs.Name = "checkedListBox_Group_Email_IDs";
            this.checkedListBox_Group_Email_IDs.Size = new System.Drawing.Size(329, 410);
            this.checkedListBox_Group_Email_IDs.Sorted = true;
            this.checkedListBox_Group_Email_IDs.TabIndex = 2;
            this.checkedListBox_Group_Email_IDs.ThreeDCheckBoxes = true;
            this.checkedListBox_Group_Email_IDs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_Group_Email_IDs_ItemCheck);
            // 
            // checkedListBox_New_Group_ID_Collection
            // 
            this.checkedListBox_New_Group_ID_Collection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBox_New_Group_ID_Collection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox_New_Group_ID_Collection.CheckOnClick = true;
            this.checkedListBox_New_Group_ID_Collection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedListBox_New_Group_ID_Collection.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBox_New_Group_ID_Collection.FormattingEnabled = true;
            this.checkedListBox_New_Group_ID_Collection.HorizontalScrollbar = true;
            this.checkedListBox_New_Group_ID_Collection.Location = new System.Drawing.Point(147, 43);
            this.checkedListBox_New_Group_ID_Collection.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBox_New_Group_ID_Collection.Name = "checkedListBox_New_Group_ID_Collection";
            this.checkedListBox_New_Group_ID_Collection.Size = new System.Drawing.Size(329, 410);
            this.checkedListBox_New_Group_ID_Collection.Sorted = true;
            this.checkedListBox_New_Group_ID_Collection.TabIndex = 4;
            this.checkedListBox_New_Group_ID_Collection.ThreeDCheckBoxes = true;
            // 
            // button_Create_Group
            // 
            this.button_Create_Group.BackColor = System.Drawing.Color.Transparent;
            this.button_Create_Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Create_Group.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Create_Group.Location = new System.Drawing.Point(147, 474);
            this.button_Create_Group.Margin = new System.Windows.Forms.Padding(4);
            this.button_Create_Group.Name = "button_Create_Group";
            this.button_Create_Group.Size = new System.Drawing.Size(167, 53);
            this.button_Create_Group.TabIndex = 5;
            this.button_Create_Group.Text = "Create Group";
            this.button_Create_Group.UseVisualStyleBackColor = false;
            this.button_Create_Group.Click += new System.EventHandler(this.button_Create_Group_Click);
            // 
            // comboBox_Group_Name
            // 
            this.comboBox_Group_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox_Group_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_Group_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Group_Name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_Group_Name.FormattingEnabled = true;
            this.comboBox_Group_Name.Location = new System.Drawing.Point(599, 10);
            this.comboBox_Group_Name.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Group_Name.Name = "comboBox_Group_Name";
            this.comboBox_Group_Name.Size = new System.Drawing.Size(328, 24);
            this.comboBox_Group_Name.Sorted = true;
            this.comboBox_Group_Name.TabIndex = 1;
            this.comboBox_Group_Name.SelectedValueChanged += new System.EventHandler(this.comboBox_Group_Name_SelectedValueChanged);
            // 
            // label_Select_Group_Name
            // 
            this.label_Select_Group_Name.AutoSize = true;
            this.label_Select_Group_Name.Location = new System.Drawing.Point(499, 11);
            this.label_Select_Group_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Select_Group_Name.Name = "label_Select_Group_Name";
            this.label_Select_Group_Name.Size = new System.Drawing.Size(86, 16);
            this.label_Select_Group_Name.TabIndex = 0;
            this.label_Select_Group_Name.Text = "Select Group";
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Transparent;
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Close.Location = new System.Drawing.Point(785, 475);
            this.button_Close.Margin = new System.Windows.Forms.Padding(4);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(143, 52);
            this.button_Close.TabIndex = 6;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = false;
            // 
            // Create_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.button_Close;
            this.ClientSize = new System.Drawing.Size(967, 542);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_Select_Group_Name);
            this.Controls.Add(this.comboBox_Group_Name);
            this.Controls.Add(this.button_Create_Group);
            this.Controls.Add(this.checkedListBox_New_Group_ID_Collection);
            this.Controls.Add(this.checkedListBox_Group_Email_IDs);
            this.Controls.Add(this.textBox_Group_Name);
            this.Controls.Add(this.label_Enter_Group_Name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Create_Group";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Group";
            this.Load += new System.EventHandler(this.Form4_Create_Group_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Enter_Group_Name;
        private System.Windows.Forms.TextBox textBox_Group_Name;
        private System.Windows.Forms.CheckedListBox checkedListBox_Group_Email_IDs;
        private System.Windows.Forms.CheckedListBox checkedListBox_New_Group_ID_Collection;
        private System.Windows.Forms.Button button_Create_Group;
        private System.Windows.Forms.ComboBox comboBox_Group_Name;
        private System.Windows.Forms.Label label_Select_Group_Name;
        private System.Windows.Forms.Button button_Close;
    }
}