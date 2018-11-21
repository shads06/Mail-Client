namespace Mail_Client
{
    partial class Send_Mail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Send_Mail));
            this.send_mail_menu = new System.Windows.Forms.MenuStrip();
            this.Quick_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.add_contact = new System.Windows.Forms.ToolStripMenuItem();
            this.add_multiple_contacts = new System.Windows.Forms.ToolStripMenuItem();
            this.view_group = new System.Windows.Forms.ToolStripMenuItem();
            this.create_group = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.quickMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_authorize = new System.Windows.Forms.Button();
            this.label_to = new System.Windows.Forms.Label();
            this.comboBox_to = new System.Windows.Forms.ComboBox();
            this.button_edit_group_list = new System.Windows.Forms.Button();
            this.label_subject = new System.Windows.Forms.Label();
            this.textBox_subject = new System.Windows.Forms.TextBox();
            this.label_content = new System.Windows.Forms.Label();
            this.richTextBox_content = new System.Windows.Forms.RichTextBox();
            this.button_send_mail = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.checkedListBox_Edit_Recipients = new System.Windows.Forms.CheckedListBox();
            this.button_Save_Edit_List = new System.Windows.Forms.Button();
            this.button_Close_Editing = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox_From_Email_ID = new System.Windows.Forms.TextBox();
            this.label_Form_Email_ID = new System.Windows.Forms.Label();
            this.send_mail_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // send_mail_menu
            // 
            this.send_mail_menu.BackColor = System.Drawing.Color.DarkGray;
            this.send_mail_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Quick_Menu,
            this.help});
            this.send_mail_menu.Location = new System.Drawing.Point(0, 0);
            this.send_mail_menu.Name = "send_mail_menu";
            this.send_mail_menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.send_mail_menu.Size = new System.Drawing.Size(1362, 24);
            this.send_mail_menu.TabIndex = 0;
            this.send_mail_menu.Text = "Menu";
            // 
            // Quick_Menu
            // 
            this.Quick_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Quick_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_contact,
            this.add_multiple_contacts,
            this.view_group,
            this.create_group,
            this.exit});
            this.Quick_Menu.Image = global::Mail_Client.Properties.Resources.down_arrow;
            this.Quick_Menu.Name = "Quick_Menu";
            this.Quick_Menu.Size = new System.Drawing.Size(100, 20);
            this.Quick_Menu.Text = "Quick Menu";
            // 
            // add_contact
            // 
            this.add_contact.BackColor = System.Drawing.Color.WhiteSmoke;
            this.add_contact.Image = global::Mail_Client.Properties.Resources.add_contact1;
            this.add_contact.Name = "add_contact";
            this.add_contact.ShortcutKeyDisplayString = "";
            this.add_contact.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.add_contact.Size = new System.Drawing.Size(238, 22);
            this.add_contact.Text = "Add Contact";
            this.add_contact.Click += new System.EventHandler(this.add_contact_Click);
            // 
            // add_multiple_contacts
            // 
            this.add_multiple_contacts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.add_multiple_contacts.Image = global::Mail_Client.Properties.Resources.add_multiple_contacts1;
            this.add_multiple_contacts.Name = "add_multiple_contacts";
            this.add_multiple_contacts.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.add_multiple_contacts.Size = new System.Drawing.Size(238, 22);
            this.add_multiple_contacts.Text = "Add Multiple Contacts";
            this.add_multiple_contacts.Click += new System.EventHandler(this.add_multiple_contacts_Click);
            // 
            // view_group
            // 
            this.view_group.BackColor = System.Drawing.Color.WhiteSmoke;
            this.view_group.Image = global::Mail_Client.Properties.Resources.search_group1;
            this.view_group.Name = "view_group";
            this.view_group.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.view_group.Size = new System.Drawing.Size(238, 22);
            this.view_group.Text = "View Group";
            this.view_group.Click += new System.EventHandler(this.view_group_Click);
            // 
            // create_group
            // 
            this.create_group.BackColor = System.Drawing.Color.WhiteSmoke;
            this.create_group.Image = global::Mail_Client.Properties.Resources.create_group1;
            this.create_group.Name = "create_group";
            this.create_group.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.create_group.Size = new System.Drawing.Size(238, 22);
            this.create_group.Text = "Create Group";
            this.create_group.Click += new System.EventHandler(this.create_group_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.exit.Image = global::Mail_Client.Properties.Resources.exit;
            this.exit.Name = "exit";
            this.exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exit.Size = new System.Drawing.Size(238, 22);
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // help
            // 
            this.help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.help.Image = global::Mail_Client.Properties.Resources.help_tire;
            this.help.Name = "help";
            this.help.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.help.Size = new System.Drawing.Size(60, 20);
            this.help.Text = "Help";
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.WhiteSmoke;
            this.about.Image = global::Mail_Client.Properties.Resources.info;
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(152, 22);
            this.about.Text = "About";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // quickMenuToolStripMenuItem
            // 
            this.quickMenuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quickMenuToolStripMenuItem.Image")));
            this.quickMenuToolStripMenuItem.Name = "quickMenuToolStripMenuItem";
            this.quickMenuToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.quickMenuToolStripMenuItem.Text = "Quick Menu";
            // 
            // viewGroupsToolStripMenuItem
            // 
            this.viewGroupsToolStripMenuItem.BackColor = System.Drawing.Color.Linen;
            this.viewGroupsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewGroupsToolStripMenuItem.Image")));
            this.viewGroupsToolStripMenuItem.Name = "viewGroupsToolStripMenuItem";
            this.viewGroupsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.viewGroupsToolStripMenuItem.Text = "View Group";
            this.viewGroupsToolStripMenuItem.Click += new System.EventHandler(this.viewGroupsToolStripMenuItem_Click);
            // 
            // createGroupsToolStripMenuItem
            // 
            this.createGroupsToolStripMenuItem.BackColor = System.Drawing.Color.Linen;
            this.createGroupsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createGroupsToolStripMenuItem.Image")));
            this.createGroupsToolStripMenuItem.Name = "createGroupsToolStripMenuItem";
            this.createGroupsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.createGroupsToolStripMenuItem.Text = "Create Group";
            this.createGroupsToolStripMenuItem.Click += new System.EventHandler(this.createGroupsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.Linen;
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // button_authorize
            // 
            this.button_authorize.BackColor = System.Drawing.Color.Transparent;
            this.button_authorize.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_authorize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_authorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_authorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_authorize.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_authorize.Location = new System.Drawing.Point(10, 64);
            this.button_authorize.Margin = new System.Windows.Forms.Padding(4);
            this.button_authorize.Name = "button_authorize";
            this.button_authorize.Size = new System.Drawing.Size(146, 76);
            this.button_authorize.TabIndex = 2;
            this.button_authorize.Text = "Re-Authorize";
            this.button_authorize.UseVisualStyleBackColor = false;
            this.button_authorize.Click += new System.EventHandler(this.button_authorize_Click);
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_to.Location = new System.Drawing.Point(244, 99);
            this.label_to.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(26, 18);
            this.label_to.TabIndex = 4;
            this.label_to.Text = "To";
            // 
            // comboBox_to
            // 
            this.comboBox_to.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox_to.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_to.FormattingEnabled = true;
            this.comboBox_to.Location = new System.Drawing.Point(340, 99);
            this.comboBox_to.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_to.Name = "comboBox_to";
            this.comboBox_to.Size = new System.Drawing.Size(482, 24);
            this.comboBox_to.Sorted = true;
            this.comboBox_to.TabIndex = 5;
            this.comboBox_to.SelectedIndexChanged += new System.EventHandler(this.comboBox_to_SelectedIndexChanged);
            this.comboBox_to.SelectedValueChanged += new System.EventHandler(this.comboBox_to_SelectedValueChanged);
            // 
            // button_edit_group_list
            // 
            this.button_edit_group_list.BackColor = System.Drawing.Color.Transparent;
            this.button_edit_group_list.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_edit_group_list.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_edit_group_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_edit_group_list.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_edit_group_list.Location = new System.Drawing.Point(832, 99);
            this.button_edit_group_list.Margin = new System.Windows.Forms.Padding(4);
            this.button_edit_group_list.Name = "button_edit_group_list";
            this.button_edit_group_list.Size = new System.Drawing.Size(132, 28);
            this.button_edit_group_list.TabIndex = 6;
            this.button_edit_group_list.Text = "Edit Group List";
            this.button_edit_group_list.UseVisualStyleBackColor = false;
            this.button_edit_group_list.Click += new System.EventHandler(this.button_edit_group_list_Click);
            // 
            // label_subject
            // 
            this.label_subject.AutoSize = true;
            this.label_subject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_subject.Location = new System.Drawing.Point(244, 151);
            this.label_subject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_subject.Name = "label_subject";
            this.label_subject.Size = new System.Drawing.Size(57, 18);
            this.label_subject.TabIndex = 7;
            this.label_subject.Text = "Subject";
            // 
            // textBox_subject
            // 
            this.textBox_subject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox_subject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_subject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_subject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_subject.ForeColor = System.Drawing.Color.Brown;
            this.textBox_subject.Location = new System.Drawing.Point(340, 153);
            this.textBox_subject.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_subject.Name = "textBox_subject";
            this.textBox_subject.Size = new System.Drawing.Size(623, 22);
            this.textBox_subject.TabIndex = 8;
            // 
            // label_content
            // 
            this.label_content.AutoSize = true;
            this.label_content.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_content.Location = new System.Drawing.Point(244, 203);
            this.label_content.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_content.Name = "label_content";
            this.label_content.Size = new System.Drawing.Size(60, 18);
            this.label_content.TabIndex = 9;
            this.label_content.Text = "Content";
            // 
            // richTextBox_content
            // 
            this.richTextBox_content.AutoWordSelection = true;
            this.richTextBox_content.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox_content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_content.EnableAutoDragDrop = true;
            this.richTextBox_content.ForeColor = System.Drawing.Color.Brown;
            this.richTextBox_content.Location = new System.Drawing.Point(340, 204);
            this.richTextBox_content.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_content.Name = "richTextBox_content";
            this.richTextBox_content.ShowSelectionMargin = true;
            this.richTextBox_content.Size = new System.Drawing.Size(623, 316);
            this.richTextBox_content.TabIndex = 10;
            this.richTextBox_content.Text = "";
            // 
            // button_send_mail
            // 
            this.button_send_mail.BackColor = System.Drawing.Color.Transparent;
            this.button_send_mail.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_send_mail.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_send_mail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_send_mail.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_send_mail.Location = new System.Drawing.Point(340, 527);
            this.button_send_mail.Margin = new System.Windows.Forms.Padding(4);
            this.button_send_mail.Name = "button_send_mail";
            this.button_send_mail.Size = new System.Drawing.Size(100, 28);
            this.button_send_mail.TabIndex = 11;
            this.button_send_mail.Text = "Send Mail";
            this.button_send_mail.UseVisualStyleBackColor = false;
            this.button_send_mail.Click += new System.EventHandler(this.button_send_mail_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.Transparent;
            this.button_clear.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_clear.Location = new System.Drawing.Point(473, 527);
            this.button_clear.Margin = new System.Windows.Forms.Padding(4);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(100, 28);
            this.button_clear.TabIndex = 12;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.Transparent;
            this.button_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_exit.Location = new System.Drawing.Point(606, 527);
            this.button_exit.Margin = new System.Windows.Forms.Padding(4);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(100, 28);
            this.button_exit.TabIndex = 13;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // checkedListBox_Edit_Recipients
            // 
            this.checkedListBox_Edit_Recipients.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBox_Edit_Recipients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox_Edit_Recipients.CheckOnClick = true;
            this.checkedListBox_Edit_Recipients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedListBox_Edit_Recipients.FormattingEnabled = true;
            this.checkedListBox_Edit_Recipients.Location = new System.Drawing.Point(971, 108);
            this.checkedListBox_Edit_Recipients.Name = "checkedListBox_Edit_Recipients";
            this.checkedListBox_Edit_Recipients.Size = new System.Drawing.Size(263, 410);
            this.checkedListBox_Edit_Recipients.Sorted = true;
            this.checkedListBox_Edit_Recipients.TabIndex = 15;
            this.checkedListBox_Edit_Recipients.ThreeDCheckBoxes = true;
            this.checkedListBox_Edit_Recipients.Visible = false;
            this.checkedListBox_Edit_Recipients.Click += new System.EventHandler(this.checkedListBox_Edit_Recipients_Click);
            this.checkedListBox_Edit_Recipients.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_Edit_Recipients_SelectedIndexChanged);
            // 
            // button_Save_Edit_List
            // 
            this.button_Save_Edit_List.BackColor = System.Drawing.Color.Transparent;
            this.button_Save_Edit_List.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Save_Edit_List.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_Save_Edit_List.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_Save_Edit_List.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save_Edit_List.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Save_Edit_List.Location = new System.Drawing.Point(971, 527);
            this.button_Save_Edit_List.Margin = new System.Windows.Forms.Padding(4);
            this.button_Save_Edit_List.Name = "button_Save_Edit_List";
            this.button_Save_Edit_List.Size = new System.Drawing.Size(100, 28);
            this.button_Save_Edit_List.TabIndex = 16;
            this.button_Save_Edit_List.Text = "Save Editted List (Temporary)";
            this.button_Save_Edit_List.UseVisualStyleBackColor = false;
            this.button_Save_Edit_List.Visible = false;
            this.button_Save_Edit_List.Click += new System.EventHandler(this.button_Save_Edit_List_Click);
            // 
            // button_Close_Editing
            // 
            this.button_Close_Editing.BackColor = System.Drawing.Color.Transparent;
            this.button_Close_Editing.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close_Editing.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.button_Close_Editing.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_Close_Editing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close_Editing.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Close_Editing.Location = new System.Drawing.Point(1133, 527);
            this.button_Close_Editing.Margin = new System.Windows.Forms.Padding(4);
            this.button_Close_Editing.Name = "button_Close_Editing";
            this.button_Close_Editing.Size = new System.Drawing.Size(100, 28);
            this.button_Close_Editing.TabIndex = 17;
            this.button_Close_Editing.Text = "Close Editing (Editing Without Saving)";
            this.button_Close_Editing.UseVisualStyleBackColor = false;
            this.button_Close_Editing.Visible = false;
            this.button_Close_Editing.Click += new System.EventHandler(this.button_Close_Editing_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Location = new System.Drawing.Point(739, 527);
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(221, 28);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 18;
            // 
            // textBox_From_Email_ID
            // 
            this.textBox_From_Email_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox_From_Email_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_From_Email_ID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_From_Email_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_From_Email_ID.ForeColor = System.Drawing.Color.Brown;
            this.textBox_From_Email_ID.Location = new System.Drawing.Point(341, 64);
            this.textBox_From_Email_ID.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_From_Email_ID.Name = "textBox_From_Email_ID";
            this.textBox_From_Email_ID.Size = new System.Drawing.Size(623, 22);
            this.textBox_From_Email_ID.TabIndex = 19;
            // 
            // label_Form_Email_ID
            // 
            this.label_Form_Email_ID.AutoSize = true;
            this.label_Form_Email_ID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Form_Email_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Form_Email_ID.Location = new System.Drawing.Point(244, 64);
            this.label_Form_Email_ID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Form_Email_ID.Name = "label_Form_Email_ID";
            this.label_Form_Email_ID.Size = new System.Drawing.Size(44, 18);
            this.label_Form_Email_ID.TabIndex = 20;
            this.label_Form_Email_ID.Text = "From";
            // 
            // Send_Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.button_exit;
            this.ClientSize = new System.Drawing.Size(1362, 562);
            this.Controls.Add(this.label_Form_Email_ID);
            this.Controls.Add(this.textBox_From_Email_ID);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_Close_Editing);
            this.Controls.Add(this.button_Save_Edit_List);
            this.Controls.Add(this.checkedListBox_Edit_Recipients);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_send_mail);
            this.Controls.Add(this.richTextBox_content);
            this.Controls.Add(this.label_content);
            this.Controls.Add(this.textBox_subject);
            this.Controls.Add(this.label_subject);
            this.Controls.Add(this.button_edit_group_list);
            this.Controls.Add(this.comboBox_to);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.button_authorize);
            this.Controls.Add(this.send_mail_menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.send_mail_menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Send_Mail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Mail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Main_Window_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.send_mail_menu.ResumeLayout(false);
            this.send_mail_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip send_mail_menu;
        private System.Windows.Forms.ToolStripMenuItem quickMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button button_authorize;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.Button button_edit_group_list;
        private System.Windows.Forms.Label label_subject;
        private System.Windows.Forms.TextBox textBox_subject;
        private System.Windows.Forms.Label label_content;
        private System.Windows.Forms.RichTextBox richTextBox_content;
        private System.Windows.Forms.Button button_send_mail;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.CheckedListBox checkedListBox_Edit_Recipients;
        private System.Windows.Forms.Button button_Save_Edit_List;
        private System.Windows.Forms.Button button_Close_Editing;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox_to;
        private System.Windows.Forms.TextBox textBox_From_Email_ID;
        private System.Windows.Forms.Label label_Form_Email_ID;
        private System.Windows.Forms.ToolStripMenuItem Quick_Menu;
        private System.Windows.Forms.ToolStripMenuItem add_contact;
        private System.Windows.Forms.ToolStripMenuItem add_multiple_contacts;
        private System.Windows.Forms.ToolStripMenuItem view_group;
        private System.Windows.Forms.ToolStripMenuItem create_group;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.ToolStripMenuItem about;
    }
}

