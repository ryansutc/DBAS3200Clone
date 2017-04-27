namespace BugTrackerApp
{
    partial class BugTrackerForm
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
            this.BugTrackerTabControl = new System.Windows.Forms.TabControl();
            this.IdentityTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameButton = new System.Windows.Forms.Button();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.ApplicationsTab = new System.Windows.Forms.TabPage();
            this.AppIDTextBox = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AppSaveEditButton = new System.Windows.Forms.Button();
            this.AppCancelButton = new System.Windows.Forms.Button();
            this.AppFormValidationLabel = new System.Windows.Forms.Label();
            this.NewAppButton = new System.Windows.Forms.Button();
            this.ApplicationListBox = new System.Windows.Forms.ListBox();
            this.AppDescTextBox = new System.Windows.Forms.TextBox();
            this.AppVersionTextBox = new System.Windows.Forms.TextBox();
            this.ApplicationNameTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.AppVersionLabel = new System.Windows.Forms.Label();
            this.ApplicationNameLabel = new System.Windows.Forms.Label();
            this.ApplicationIDLabel = new System.Windows.Forms.Label();
            this.ApplicationManagerLabel = new System.Windows.Forms.Label();
            this.BugsTab = new System.Windows.Forms.TabPage();
            this.CancelStatusButton = new System.Windows.Forms.Button();
            this.UpdateSaveStatusButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BugNewStatusComboBox = new System.Windows.Forms.ComboBox();
            this.BugIDTextBox = new System.Windows.Forms.TextBox();
            this.BugFormValidationLabel = new System.Windows.Forms.Label();
            this.BugCancelButton = new System.Windows.Forms.Button();
            this.DeleteBugButton = new System.Windows.Forms.Button();
            this.NewBugButton = new System.Windows.Forms.Button();
            this.SaveEditBugsButton = new System.Windows.Forms.Button();
            this.UpdateCommentsLabel = new System.Windows.Forms.Label();
            this.UpdateCommentsTextBox = new System.Windows.Forms.TextBox();
            this.BugActivityLogDataGridView = new System.Windows.Forms.DataGridView();
            this.BugActivityLogLabel = new System.Windows.Forms.Label();
            this.FixDateLabel = new System.Windows.Forms.Label();
            this.BugRepStepsTextBox = new System.Windows.Forms.TextBox();
            this.RepStepsLabel = new System.Windows.Forms.Label();
            this.BugDetailsTextBox = new System.Windows.Forms.TextBox();
            this.DetailsLabel = new System.Windows.Forms.Label();
            this.BugDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.BugDescriptionLabel = new System.Windows.Forms.Label();
            this.SubmitDateLabel = new System.Windows.Forms.Label();
            this.BugIDLabel = new System.Windows.Forms.Label();
            this.BugListListBox = new System.Windows.Forms.ListBox();
            this.BugListLabel = new System.Windows.Forms.Label();
            this.StatusFilterComboBox = new System.Windows.Forms.ComboBox();
            this.StatusFilterLabel = new System.Windows.Forms.Label();
            this.BugAppComboBox = new System.Windows.Forms.ComboBox();
            this.ApplicationLabel = new System.Windows.Forms.Label();
            this.UsersTab = new System.Windows.Forms.TabPage();
            this.CancelUsersButton = new System.Windows.Forms.Button();
            this.UsersDeleteButton = new System.Windows.Forms.Button();
            this.UsersNewUserButton = new System.Windows.Forms.Button();
            this.EditSaveUsersButton = new System.Windows.Forms.Button();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.UserPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.UserEmailTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.SelectUserLabel = new System.Windows.Forms.Label();
            this.SelectUserListBox = new System.Windows.Forms.ListBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.UsersUserNameLabel = new System.Windows.Forms.Label();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.UserManagerLabel = new System.Windows.Forms.Label();
            this.BugTrackerTabControl.SuspendLayout();
            this.IdentityTab.SuspendLayout();
            this.ApplicationsTab.SuspendLayout();
            this.BugsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BugActivityLogDataGridView)).BeginInit();
            this.UsersTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // BugTrackerTabControl
            // 
            this.BugTrackerTabControl.Controls.Add(this.IdentityTab);
            this.BugTrackerTabControl.Controls.Add(this.ApplicationsTab);
            this.BugTrackerTabControl.Controls.Add(this.BugsTab);
            this.BugTrackerTabControl.Controls.Add(this.UsersTab);
            this.BugTrackerTabControl.Location = new System.Drawing.Point(1, 6);
            this.BugTrackerTabControl.Name = "BugTrackerTabControl";
            this.BugTrackerTabControl.SelectedIndex = 0;
            this.BugTrackerTabControl.Size = new System.Drawing.Size(814, 424);
            this.BugTrackerTabControl.TabIndex = 8;
            // 
            // IdentityTab
            // 
            this.IdentityTab.Controls.Add(this.label1);
            this.IdentityTab.Controls.Add(this.UserNameButton);
            this.IdentityTab.Controls.Add(this.UserNameTextBox);
            this.IdentityTab.Controls.Add(this.UserNameLabel);
            this.IdentityTab.Location = new System.Drawing.Point(4, 22);
            this.IdentityTab.Name = "IdentityTab";
            this.IdentityTab.Padding = new System.Windows.Forms.Padding(3);
            this.IdentityTab.Size = new System.Drawing.Size(806, 398);
            this.IdentityTab.TabIndex = 0;
            this.IdentityTab.Text = "Identity";
            this.IdentityTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Please Identify Yourself";
            // 
            // UserNameButton
            // 
            this.UserNameButton.Location = new System.Drawing.Point(537, 194);
            this.UserNameButton.Name = "UserNameButton";
            this.UserNameButton.Size = new System.Drawing.Size(75, 23);
            this.UserNameButton.TabIndex = 9;
            this.UserNameButton.Text = "Go";
            this.UserNameButton.UseVisualStyleBackColor = true;
            this.UserNameButton.Click += new System.EventHandler(this.UserNameButton_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(251, 196);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(269, 20);
            this.UserNameTextBox.TabIndex = 8;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(182, 199);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(63, 13);
            this.UserNameLabel.TabIndex = 7;
            this.UserNameLabel.Text = "User Name:";
            // 
            // ApplicationsTab
            // 
            this.ApplicationsTab.Controls.Add(this.AppIDTextBox);
            this.ApplicationsTab.Controls.Add(this.DeleteButton);
            this.ApplicationsTab.Controls.Add(this.AppSaveEditButton);
            this.ApplicationsTab.Controls.Add(this.AppCancelButton);
            this.ApplicationsTab.Controls.Add(this.AppFormValidationLabel);
            this.ApplicationsTab.Controls.Add(this.NewAppButton);
            this.ApplicationsTab.Controls.Add(this.ApplicationListBox);
            this.ApplicationsTab.Controls.Add(this.AppDescTextBox);
            this.ApplicationsTab.Controls.Add(this.AppVersionTextBox);
            this.ApplicationsTab.Controls.Add(this.ApplicationNameTextBox);
            this.ApplicationsTab.Controls.Add(this.DescriptionLabel);
            this.ApplicationsTab.Controls.Add(this.AppVersionLabel);
            this.ApplicationsTab.Controls.Add(this.ApplicationNameLabel);
            this.ApplicationsTab.Controls.Add(this.ApplicationIDLabel);
            this.ApplicationsTab.Controls.Add(this.ApplicationManagerLabel);
            this.ApplicationsTab.Location = new System.Drawing.Point(4, 22);
            this.ApplicationsTab.Name = "ApplicationsTab";
            this.ApplicationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ApplicationsTab.Size = new System.Drawing.Size(806, 398);
            this.ApplicationsTab.TabIndex = 1;
            this.ApplicationsTab.Text = "Applications";
            this.ApplicationsTab.UseVisualStyleBackColor = true;
            // 
            // AppIDTextBox
            // 
            this.AppIDTextBox.Enabled = false;
            this.AppIDTextBox.Location = new System.Drawing.Point(486, 96);
            this.AppIDTextBox.Name = "AppIDTextBox";
            this.AppIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.AppIDTextBox.TabIndex = 26;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Sienna;
            this.DeleteButton.Location = new System.Drawing.Point(183, 349);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 25;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AppSaveEditButton
            // 
            this.AppSaveEditButton.Location = new System.Drawing.Point(637, 349);
            this.AppSaveEditButton.Name = "AppSaveEditButton";
            this.AppSaveEditButton.Size = new System.Drawing.Size(75, 23);
            this.AppSaveEditButton.TabIndex = 24;
            this.AppSaveEditButton.Text = "Edit";
            this.AppSaveEditButton.UseVisualStyleBackColor = true;
            this.AppSaveEditButton.Click += new System.EventHandler(this.AppSaveEditButton_Click);
            // 
            // AppCancelButton
            // 
            this.AppCancelButton.Enabled = false;
            this.AppCancelButton.Location = new System.Drawing.Point(485, 349);
            this.AppCancelButton.Name = "AppCancelButton";
            this.AppCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AppCancelButton.TabIndex = 23;
            this.AppCancelButton.Text = "Cancel";
            this.AppCancelButton.UseVisualStyleBackColor = true;
            this.AppCancelButton.Click += new System.EventHandler(this.AppCancelButton_Click);
            // 
            // AppFormValidationLabel
            // 
            this.AppFormValidationLabel.AutoSize = true;
            this.AppFormValidationLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.AppFormValidationLabel.Location = new System.Drawing.Point(401, 336);
            this.AppFormValidationLabel.Name = "AppFormValidationLabel";
            this.AppFormValidationLabel.Size = new System.Drawing.Size(0, 13);
            this.AppFormValidationLabel.TabIndex = 22;
            // 
            // NewAppButton
            // 
            this.NewAppButton.BackColor = System.Drawing.Color.Maroon;
            this.NewAppButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NewAppButton.Location = new System.Drawing.Point(71, 349);
            this.NewAppButton.Name = "NewAppButton";
            this.NewAppButton.Size = new System.Drawing.Size(75, 23);
            this.NewAppButton.TabIndex = 20;
            this.NewAppButton.Text = "New";
            this.NewAppButton.UseVisualStyleBackColor = false;
            this.NewAppButton.Click += new System.EventHandler(this.NewAppButton_Click);
            // 
            // ApplicationListBox
            // 
            this.ApplicationListBox.FormattingEnabled = true;
            this.ApplicationListBox.Location = new System.Drawing.Point(71, 97);
            this.ApplicationListBox.Name = "ApplicationListBox";
            this.ApplicationListBox.Size = new System.Drawing.Size(187, 238);
            this.ApplicationListBox.TabIndex = 19;
            this.ApplicationListBox.SelectedIndexChanged += new System.EventHandler(this.ApplicationListBox_SelectedIndexChanged);
            // 
            // AppDescTextBox
            // 
            this.AppDescTextBox.Enabled = false;
            this.AppDescTextBox.Location = new System.Drawing.Point(485, 235);
            this.AppDescTextBox.Multiline = true;
            this.AppDescTextBox.Name = "AppDescTextBox";
            this.AppDescTextBox.Size = new System.Drawing.Size(227, 93);
            this.AppDescTextBox.TabIndex = 18;
            // 
            // AppVersionTextBox
            // 
            this.AppVersionTextBox.Enabled = false;
            this.AppVersionTextBox.Location = new System.Drawing.Point(485, 188);
            this.AppVersionTextBox.Name = "AppVersionTextBox";
            this.AppVersionTextBox.Size = new System.Drawing.Size(227, 20);
            this.AppVersionTextBox.TabIndex = 17;
            // 
            // ApplicationNameTextBox
            // 
            this.ApplicationNameTextBox.Enabled = false;
            this.ApplicationNameTextBox.Location = new System.Drawing.Point(485, 139);
            this.ApplicationNameTextBox.Name = "ApplicationNameTextBox";
            this.ApplicationNameTextBox.Size = new System.Drawing.Size(227, 20);
            this.ApplicationNameTextBox.TabIndex = 16;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(416, 235);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 15;
            this.DescriptionLabel.Text = "Description:";
            // 
            // AppVersionLabel
            // 
            this.AppVersionLabel.AutoSize = true;
            this.AppVersionLabel.Location = new System.Drawing.Point(412, 191);
            this.AppVersionLabel.Name = "AppVersionLabel";
            this.AppVersionLabel.Size = new System.Drawing.Size(67, 13);
            this.AppVersionLabel.TabIndex = 14;
            this.AppVersionLabel.Text = "App Version:";
            // 
            // ApplicationNameLabel
            // 
            this.ApplicationNameLabel.AutoSize = true;
            this.ApplicationNameLabel.Location = new System.Drawing.Point(386, 142);
            this.ApplicationNameLabel.Name = "ApplicationNameLabel";
            this.ApplicationNameLabel.Size = new System.Drawing.Size(93, 13);
            this.ApplicationNameLabel.TabIndex = 13;
            this.ApplicationNameLabel.Text = "Application Name:";
            // 
            // ApplicationIDLabel
            // 
            this.ApplicationIDLabel.AutoSize = true;
            this.ApplicationIDLabel.Location = new System.Drawing.Point(403, 96);
            this.ApplicationIDLabel.Name = "ApplicationIDLabel";
            this.ApplicationIDLabel.Size = new System.Drawing.Size(76, 13);
            this.ApplicationIDLabel.TabIndex = 12;
            this.ApplicationIDLabel.Text = "Application ID:";
            // 
            // ApplicationManagerLabel
            // 
            this.ApplicationManagerLabel.AutoSize = true;
            this.ApplicationManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationManagerLabel.Location = new System.Drawing.Point(66, 35);
            this.ApplicationManagerLabel.Name = "ApplicationManagerLabel";
            this.ApplicationManagerLabel.Size = new System.Drawing.Size(209, 25);
            this.ApplicationManagerLabel.TabIndex = 11;
            this.ApplicationManagerLabel.Text = "Application Manager";
            // 
            // BugsTab
            // 
            this.BugsTab.Controls.Add(this.CancelStatusButton);
            this.BugsTab.Controls.Add(this.UpdateSaveStatusButton);
            this.BugsTab.Controls.Add(this.label2);
            this.BugsTab.Controls.Add(this.BugNewStatusComboBox);
            this.BugsTab.Controls.Add(this.BugIDTextBox);
            this.BugsTab.Controls.Add(this.BugFormValidationLabel);
            this.BugsTab.Controls.Add(this.BugCancelButton);
            this.BugsTab.Controls.Add(this.DeleteBugButton);
            this.BugsTab.Controls.Add(this.NewBugButton);
            this.BugsTab.Controls.Add(this.SaveEditBugsButton);
            this.BugsTab.Controls.Add(this.UpdateCommentsLabel);
            this.BugsTab.Controls.Add(this.UpdateCommentsTextBox);
            this.BugsTab.Controls.Add(this.BugActivityLogDataGridView);
            this.BugsTab.Controls.Add(this.BugActivityLogLabel);
            this.BugsTab.Controls.Add(this.FixDateLabel);
            this.BugsTab.Controls.Add(this.BugRepStepsTextBox);
            this.BugsTab.Controls.Add(this.RepStepsLabel);
            this.BugsTab.Controls.Add(this.BugDetailsTextBox);
            this.BugsTab.Controls.Add(this.DetailsLabel);
            this.BugsTab.Controls.Add(this.BugDescriptionTextBox);
            this.BugsTab.Controls.Add(this.BugDescriptionLabel);
            this.BugsTab.Controls.Add(this.SubmitDateLabel);
            this.BugsTab.Controls.Add(this.BugIDLabel);
            this.BugsTab.Controls.Add(this.BugListListBox);
            this.BugsTab.Controls.Add(this.BugListLabel);
            this.BugsTab.Controls.Add(this.StatusFilterComboBox);
            this.BugsTab.Controls.Add(this.StatusFilterLabel);
            this.BugsTab.Controls.Add(this.BugAppComboBox);
            this.BugsTab.Controls.Add(this.ApplicationLabel);
            this.BugsTab.Location = new System.Drawing.Point(4, 22);
            this.BugsTab.Name = "BugsTab";
            this.BugsTab.Padding = new System.Windows.Forms.Padding(3);
            this.BugsTab.Size = new System.Drawing.Size(806, 398);
            this.BugsTab.TabIndex = 2;
            this.BugsTab.Text = "Bugs";
            this.BugsTab.UseVisualStyleBackColor = true;
            // 
            // CancelStatusButton
            // 
            this.CancelStatusButton.BackColor = System.Drawing.Color.LightSalmon;
            this.CancelStatusButton.Enabled = false;
            this.CancelStatusButton.Location = new System.Drawing.Point(561, 360);
            this.CancelStatusButton.Name = "CancelStatusButton";
            this.CancelStatusButton.Size = new System.Drawing.Size(94, 23);
            this.CancelStatusButton.TabIndex = 34;
            this.CancelStatusButton.Text = "Cancel";
            this.CancelStatusButton.UseVisualStyleBackColor = false;
            // 
            // UpdateSaveStatusButton
            // 
            this.UpdateSaveStatusButton.BackColor = System.Drawing.Color.LightSalmon;
            this.UpdateSaveStatusButton.Location = new System.Drawing.Point(704, 358);
            this.UpdateSaveStatusButton.Name = "UpdateSaveStatusButton";
            this.UpdateSaveStatusButton.Size = new System.Drawing.Size(94, 23);
            this.UpdateSaveStatusButton.TabIndex = 33;
            this.UpdateSaveStatusButton.Text = "Update Status";
            this.UpdateSaveStatusButton.UseVisualStyleBackColor = false;
            this.UpdateSaveStatusButton.Click += new System.EventHandler(this.UpdateSaveStatusButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "New Status:";
            // 
            // BugNewStatusComboBox
            // 
            this.BugNewStatusComboBox.Enabled = false;
            this.BugNewStatusComboBox.FormattingEnabled = true;
            this.BugNewStatusComboBox.Location = new System.Drawing.Point(558, 243);
            this.BugNewStatusComboBox.Name = "BugNewStatusComboBox";
            this.BugNewStatusComboBox.Size = new System.Drawing.Size(240, 21);
            this.BugNewStatusComboBox.TabIndex = 31;
            // 
            // BugIDTextBox
            // 
            this.BugIDTextBox.Enabled = false;
            this.BugIDTextBox.Location = new System.Drawing.Point(324, 21);
            this.BugIDTextBox.Name = "BugIDTextBox";
            this.BugIDTextBox.Size = new System.Drawing.Size(187, 20);
            this.BugIDTextBox.TabIndex = 30;
            // 
            // BugFormValidationLabel
            // 
            this.BugFormValidationLabel.AutoSize = true;
            this.BugFormValidationLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.BugFormValidationLabel.Location = new System.Drawing.Point(258, 360);
            this.BugFormValidationLabel.Name = "BugFormValidationLabel";
            this.BugFormValidationLabel.Size = new System.Drawing.Size(0, 13);
            this.BugFormValidationLabel.TabIndex = 29;
            // 
            // BugCancelButton
            // 
            this.BugCancelButton.Location = new System.Drawing.Point(309, 360);
            this.BugCancelButton.Name = "BugCancelButton";
            this.BugCancelButton.Size = new System.Drawing.Size(75, 23);
            this.BugCancelButton.TabIndex = 28;
            this.BugCancelButton.Text = "Cancel";
            this.BugCancelButton.UseVisualStyleBackColor = true;
            this.BugCancelButton.Click += new System.EventHandler(this.BugCancelButton_Click);
            // 
            // DeleteBugButton
            // 
            this.DeleteBugButton.BackColor = System.Drawing.Color.Sienna;
            this.DeleteBugButton.Location = new System.Drawing.Point(134, 360);
            this.DeleteBugButton.Name = "DeleteBugButton";
            this.DeleteBugButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteBugButton.TabIndex = 27;
            this.DeleteBugButton.Text = "Delete";
            this.DeleteBugButton.UseVisualStyleBackColor = false;
            this.DeleteBugButton.Click += new System.EventHandler(this.DeleteBugButton_Click);
            // 
            // NewBugButton
            // 
            this.NewBugButton.BackColor = System.Drawing.Color.Maroon;
            this.NewBugButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NewBugButton.Location = new System.Drawing.Point(17, 360);
            this.NewBugButton.Name = "NewBugButton";
            this.NewBugButton.Size = new System.Drawing.Size(75, 23);
            this.NewBugButton.TabIndex = 26;
            this.NewBugButton.Text = "New";
            this.NewBugButton.UseVisualStyleBackColor = false;
            this.NewBugButton.Click += new System.EventHandler(this.NewBugButton_Click);
            // 
            // SaveEditBugsButton
            // 
            this.SaveEditBugsButton.Location = new System.Drawing.Point(436, 360);
            this.SaveEditBugsButton.Name = "SaveEditBugsButton";
            this.SaveEditBugsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveEditBugsButton.TabIndex = 24;
            this.SaveEditBugsButton.Text = "Edit";
            this.SaveEditBugsButton.UseVisualStyleBackColor = true;
            this.SaveEditBugsButton.Click += new System.EventHandler(this.SaveEditBugsButton_Click);
            // 
            // UpdateCommentsLabel
            // 
            this.UpdateCommentsLabel.AutoSize = true;
            this.UpdateCommentsLabel.Location = new System.Drawing.Point(555, 281);
            this.UpdateCommentsLabel.Name = "UpdateCommentsLabel";
            this.UpdateCommentsLabel.Size = new System.Drawing.Size(97, 13);
            this.UpdateCommentsLabel.TabIndex = 23;
            this.UpdateCommentsLabel.Text = "Update Comments:";
            // 
            // UpdateCommentsTextBox
            // 
            this.UpdateCommentsTextBox.Enabled = false;
            this.UpdateCommentsTextBox.Location = new System.Drawing.Point(558, 297);
            this.UpdateCommentsTextBox.Multiline = true;
            this.UpdateCommentsTextBox.Name = "UpdateCommentsTextBox";
            this.UpdateCommentsTextBox.Size = new System.Drawing.Size(240, 55);
            this.UpdateCommentsTextBox.TabIndex = 22;
            // 
            // BugActivityLogDataGridView
            // 
            this.BugActivityLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BugActivityLogDataGridView.Location = new System.Drawing.Point(558, 50);
            this.BugActivityLogDataGridView.Name = "BugActivityLogDataGridView";
            this.BugActivityLogDataGridView.Size = new System.Drawing.Size(240, 164);
            this.BugActivityLogDataGridView.TabIndex = 21;
            // 
            // BugActivityLogLabel
            // 
            this.BugActivityLogLabel.AutoSize = true;
            this.BugActivityLogLabel.Location = new System.Drawing.Point(555, 24);
            this.BugActivityLogLabel.Name = "BugActivityLogLabel";
            this.BugActivityLogLabel.Size = new System.Drawing.Size(87, 13);
            this.BugActivityLogLabel.TabIndex = 20;
            this.BugActivityLogLabel.Text = "Bug Activity Log:";
            // 
            // FixDateLabel
            // 
            this.FixDateLabel.AutoSize = true;
            this.FixDateLabel.Location = new System.Drawing.Point(273, 70);
            this.FixDateLabel.Name = "FixDateLabel";
            this.FixDateLabel.Size = new System.Drawing.Size(49, 13);
            this.FixDateLabel.TabIndex = 18;
            this.FixDateLabel.Text = "Fix Date:";
            // 
            // BugRepStepsTextBox
            // 
            this.BugRepStepsTextBox.Enabled = false;
            this.BugRepStepsTextBox.Location = new System.Drawing.Point(324, 220);
            this.BugRepStepsTextBox.Multiline = true;
            this.BugRepStepsTextBox.Name = "BugRepStepsTextBox";
            this.BugRepStepsTextBox.Size = new System.Drawing.Size(187, 132);
            this.BugRepStepsTextBox.TabIndex = 15;
            // 
            // RepStepsLabel
            // 
            this.RepStepsLabel.AutoSize = true;
            this.RepStepsLabel.Location = new System.Drawing.Point(261, 220);
            this.RepStepsLabel.Name = "RepStepsLabel";
            this.RepStepsLabel.Size = new System.Drawing.Size(60, 13);
            this.RepStepsLabel.TabIndex = 14;
            this.RepStepsLabel.Text = "Rep Steps:";
            // 
            // BugDetailsTextBox
            // 
            this.BugDetailsTextBox.Enabled = false;
            this.BugDetailsTextBox.Location = new System.Drawing.Point(324, 118);
            this.BugDetailsTextBox.Multiline = true;
            this.BugDetailsTextBox.Name = "BugDetailsTextBox";
            this.BugDetailsTextBox.Size = new System.Drawing.Size(187, 96);
            this.BugDetailsTextBox.TabIndex = 13;
            // 
            // DetailsLabel
            // 
            this.DetailsLabel.AutoSize = true;
            this.DetailsLabel.Location = new System.Drawing.Point(264, 118);
            this.DetailsLabel.Name = "DetailsLabel";
            this.DetailsLabel.Size = new System.Drawing.Size(42, 13);
            this.DetailsLabel.TabIndex = 12;
            this.DetailsLabel.Text = "Details:";
            // 
            // BugDescriptionTextBox
            // 
            this.BugDescriptionTextBox.Enabled = false;
            this.BugDescriptionTextBox.Location = new System.Drawing.Point(331, 91);
            this.BugDescriptionTextBox.Name = "BugDescriptionTextBox";
            this.BugDescriptionTextBox.Size = new System.Drawing.Size(180, 20);
            this.BugDescriptionTextBox.TabIndex = 11;
            // 
            // BugDescriptionLabel
            // 
            this.BugDescriptionLabel.AutoSize = true;
            this.BugDescriptionLabel.Location = new System.Drawing.Point(261, 91);
            this.BugDescriptionLabel.Name = "BugDescriptionLabel";
            this.BugDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.BugDescriptionLabel.TabIndex = 10;
            this.BugDescriptionLabel.Text = "Description:";
            // 
            // SubmitDateLabel
            // 
            this.SubmitDateLabel.AutoSize = true;
            this.SubmitDateLabel.Location = new System.Drawing.Point(255, 50);
            this.SubmitDateLabel.Name = "SubmitDateLabel";
            this.SubmitDateLabel.Size = new System.Drawing.Size(68, 13);
            this.SubmitDateLabel.TabIndex = 9;
            this.SubmitDateLabel.Text = "Submit Date:";
            // 
            // BugIDLabel
            // 
            this.BugIDLabel.AutoSize = true;
            this.BugIDLabel.Location = new System.Drawing.Point(261, 25);
            this.BugIDLabel.Name = "BugIDLabel";
            this.BugIDLabel.Size = new System.Drawing.Size(43, 13);
            this.BugIDLabel.TabIndex = 7;
            this.BugIDLabel.Text = "Bug ID:";
            // 
            // BugListListBox
            // 
            this.BugListListBox.FormattingEnabled = true;
            this.BugListListBox.Location = new System.Drawing.Point(17, 127);
            this.BugListListBox.Name = "BugListListBox";
            this.BugListListBox.Size = new System.Drawing.Size(196, 225);
            this.BugListListBox.TabIndex = 5;
            this.BugListListBox.SelectedIndexChanged += new System.EventHandler(this.BugListListBox_SelectedIndexChanged);
            // 
            // BugListLabel
            // 
            this.BugListLabel.AutoSize = true;
            this.BugListLabel.Location = new System.Drawing.Point(14, 106);
            this.BugListLabel.Name = "BugListLabel";
            this.BugListLabel.Size = new System.Drawing.Size(48, 13);
            this.BugListLabel.TabIndex = 4;
            this.BugListLabel.Text = "Bug List:";
            // 
            // StatusFilterComboBox
            // 
            this.StatusFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusFilterComboBox.FormattingEnabled = true;
            this.StatusFilterComboBox.Location = new System.Drawing.Point(92, 69);
            this.StatusFilterComboBox.Name = "StatusFilterComboBox";
            this.StatusFilterComboBox.Size = new System.Drawing.Size(121, 21);
            this.StatusFilterComboBox.TabIndex = 3;
            this.StatusFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.StatusFilterComboBox_SelectedIndexChanged);
            // 
            // StatusFilterLabel
            // 
            this.StatusFilterLabel.AutoSize = true;
            this.StatusFilterLabel.Location = new System.Drawing.Point(11, 69);
            this.StatusFilterLabel.Name = "StatusFilterLabel";
            this.StatusFilterLabel.Size = new System.Drawing.Size(65, 13);
            this.StatusFilterLabel.TabIndex = 2;
            this.StatusFilterLabel.Text = "Status Filter:";
            // 
            // BugAppComboBox
            // 
            this.BugAppComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BugAppComboBox.FormattingEnabled = true;
            this.BugAppComboBox.Location = new System.Drawing.Point(92, 25);
            this.BugAppComboBox.Name = "BugAppComboBox";
            this.BugAppComboBox.Size = new System.Drawing.Size(121, 21);
            this.BugAppComboBox.TabIndex = 1;
            this.BugAppComboBox.SelectedIndexChanged += new System.EventHandler(this.BugAppComboBox_SelectedIndexChanged);
            // 
            // ApplicationLabel
            // 
            this.ApplicationLabel.AutoSize = true;
            this.ApplicationLabel.Location = new System.Drawing.Point(8, 25);
            this.ApplicationLabel.Name = "ApplicationLabel";
            this.ApplicationLabel.Size = new System.Drawing.Size(62, 13);
            this.ApplicationLabel.TabIndex = 0;
            this.ApplicationLabel.Text = "Application:";
            // 
            // UsersTab
            // 
            this.UsersTab.Controls.Add(this.CancelUsersButton);
            this.UsersTab.Controls.Add(this.UsersDeleteButton);
            this.UsersTab.Controls.Add(this.UsersNewUserButton);
            this.UsersTab.Controls.Add(this.EditSaveUsersButton);
            this.UsersTab.Controls.Add(this.PhoneLabel);
            this.UsersTab.Controls.Add(this.UserPhoneNumberTextBox);
            this.UsersTab.Controls.Add(this.UserEmailTextBox);
            this.UsersTab.Controls.Add(this.NameTextBox);
            this.UsersTab.Controls.Add(this.UserIDTextBox);
            this.UsersTab.Controls.Add(this.SelectUserLabel);
            this.UsersTab.Controls.Add(this.SelectUserListBox);
            this.UsersTab.Controls.Add(this.EmailLabel);
            this.UsersTab.Controls.Add(this.UsersUserNameLabel);
            this.UsersTab.Controls.Add(this.UserIDLabel);
            this.UsersTab.Controls.Add(this.UserManagerLabel);
            this.UsersTab.Location = new System.Drawing.Point(4, 22);
            this.UsersTab.Name = "UsersTab";
            this.UsersTab.Padding = new System.Windows.Forms.Padding(3);
            this.UsersTab.Size = new System.Drawing.Size(806, 398);
            this.UsersTab.TabIndex = 3;
            this.UsersTab.Text = "Users";
            this.UsersTab.UseVisualStyleBackColor = true;
            // 
            // CancelUsersButton
            // 
            this.CancelUsersButton.Location = new System.Drawing.Point(443, 355);
            this.CancelUsersButton.Name = "CancelUsersButton";
            this.CancelUsersButton.Size = new System.Drawing.Size(75, 23);
            this.CancelUsersButton.TabIndex = 28;
            this.CancelUsersButton.Text = "Cancel";
            this.CancelUsersButton.UseVisualStyleBackColor = true;
            // 
            // UsersDeleteButton
            // 
            this.UsersDeleteButton.BackColor = System.Drawing.Color.Sienna;
            this.UsersDeleteButton.Location = new System.Drawing.Point(141, 355);
            this.UsersDeleteButton.Name = "UsersDeleteButton";
            this.UsersDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.UsersDeleteButton.TabIndex = 27;
            this.UsersDeleteButton.Text = "Delete";
            this.UsersDeleteButton.UseVisualStyleBackColor = false;
            this.UsersDeleteButton.Click += new System.EventHandler(this.UsersDeleteButton_Click);
            // 
            // UsersNewUserButton
            // 
            this.UsersNewUserButton.BackColor = System.Drawing.Color.Maroon;
            this.UsersNewUserButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UsersNewUserButton.Location = new System.Drawing.Point(29, 355);
            this.UsersNewUserButton.Name = "UsersNewUserButton";
            this.UsersNewUserButton.Size = new System.Drawing.Size(75, 23);
            this.UsersNewUserButton.TabIndex = 26;
            this.UsersNewUserButton.Text = "New";
            this.UsersNewUserButton.UseVisualStyleBackColor = false;
            this.UsersNewUserButton.Click += new System.EventHandler(this.UsersNewUserButton_Click);
            // 
            // EditSaveUsersButton
            // 
            this.EditSaveUsersButton.Location = new System.Drawing.Point(602, 355);
            this.EditSaveUsersButton.Name = "EditSaveUsersButton";
            this.EditSaveUsersButton.Size = new System.Drawing.Size(75, 23);
            this.EditSaveUsersButton.TabIndex = 11;
            this.EditSaveUsersButton.Text = "Edit";
            this.EditSaveUsersButton.UseVisualStyleBackColor = true;
            this.EditSaveUsersButton.Click += new System.EventHandler(this.EditSaveUsersButton_Click);
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(394, 196);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(81, 13);
            this.PhoneLabel.TabIndex = 10;
            this.PhoneLabel.Text = "Phone Number:";
            // 
            // UserPhoneNumberTextBox
            // 
            this.UserPhoneNumberTextBox.Enabled = false;
            this.UserPhoneNumberTextBox.Location = new System.Drawing.Point(489, 193);
            this.UserPhoneNumberTextBox.Name = "UserPhoneNumberTextBox";
            this.UserPhoneNumberTextBox.Size = new System.Drawing.Size(188, 20);
            this.UserPhoneNumberTextBox.TabIndex = 9;
            // 
            // UserEmailTextBox
            // 
            this.UserEmailTextBox.Enabled = false;
            this.UserEmailTextBox.Location = new System.Drawing.Point(489, 151);
            this.UserEmailTextBox.Name = "UserEmailTextBox";
            this.UserEmailTextBox.Size = new System.Drawing.Size(188, 20);
            this.UserEmailTextBox.TabIndex = 8;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Enabled = false;
            this.NameTextBox.Location = new System.Drawing.Point(489, 109);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(188, 20);
            this.NameTextBox.TabIndex = 7;
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Enabled = false;
            this.UserIDTextBox.Location = new System.Drawing.Point(489, 73);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(188, 20);
            this.UserIDTextBox.TabIndex = 6;
            // 
            // SelectUserLabel
            // 
            this.SelectUserLabel.AutoSize = true;
            this.SelectUserLabel.Location = new System.Drawing.Point(26, 67);
            this.SelectUserLabel.Name = "SelectUserLabel";
            this.SelectUserLabel.Size = new System.Drawing.Size(119, 13);
            this.SelectUserLabel.TabIndex = 5;
            this.SelectUserLabel.Text = "Select an Existing User:";
            // 
            // SelectUserListBox
            // 
            this.SelectUserListBox.FormattingEnabled = true;
            this.SelectUserListBox.Location = new System.Drawing.Point(26, 86);
            this.SelectUserListBox.Name = "SelectUserListBox";
            this.SelectUserListBox.Size = new System.Drawing.Size(187, 251);
            this.SelectUserListBox.TabIndex = 4;
            this.SelectUserListBox.SelectedIndexChanged += new System.EventHandler(this.SelectUserListBox_SelectedIndexChanged);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(440, 154);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Email:";
            // 
            // UsersUserNameLabel
            // 
            this.UsersUserNameLabel.AutoSize = true;
            this.UsersUserNameLabel.Location = new System.Drawing.Point(412, 112);
            this.UsersUserNameLabel.Name = "UsersUserNameLabel";
            this.UsersUserNameLabel.Size = new System.Drawing.Size(63, 13);
            this.UsersUserNameLabel.TabIndex = 2;
            this.UsersUserNameLabel.Text = "User Name:";
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(429, 76);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(46, 13);
            this.UserIDLabel.TabIndex = 1;
            this.UserIDLabel.Text = "User ID:";
            // 
            // UserManagerLabel
            // 
            this.UserManagerLabel.AutoSize = true;
            this.UserManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserManagerLabel.Location = new System.Drawing.Point(8, 7);
            this.UserManagerLabel.Name = "UserManagerLabel";
            this.UserManagerLabel.Size = new System.Drawing.Size(148, 25);
            this.UserManagerLabel.TabIndex = 0;
            this.UserManagerLabel.Text = "User Manager";
            // 
            // BugTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 430);
            this.Controls.Add(this.BugTrackerTabControl);
            this.Name = "BugTrackerForm";
            this.Text = "Bug Tracker";
            this.Load += new System.EventHandler(this.BugTrackerForm_Load);
            this.BugTrackerTabControl.ResumeLayout(false);
            this.IdentityTab.ResumeLayout(false);
            this.IdentityTab.PerformLayout();
            this.ApplicationsTab.ResumeLayout(false);
            this.ApplicationsTab.PerformLayout();
            this.BugsTab.ResumeLayout(false);
            this.BugsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BugActivityLogDataGridView)).EndInit();
            this.UsersTab.ResumeLayout(false);
            this.UsersTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl BugTrackerTabControl;
        private System.Windows.Forms.TabPage IdentityTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UserNameButton;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TabPage ApplicationsTab;
        private System.Windows.Forms.Label ApplicationManagerLabel;
        private System.Windows.Forms.ListBox ApplicationListBox;
        private System.Windows.Forms.TextBox AppDescTextBox;
        private System.Windows.Forms.TextBox AppVersionTextBox;
        private System.Windows.Forms.TextBox ApplicationNameTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label AppVersionLabel;
        private System.Windows.Forms.Label ApplicationNameLabel;
        private System.Windows.Forms.Label ApplicationIDLabel;
        private System.Windows.Forms.Button NewAppButton;
        private System.Windows.Forms.TabPage BugsTab;
        private System.Windows.Forms.Label ApplicationLabel;
        private System.Windows.Forms.ComboBox BugAppComboBox;
        private System.Windows.Forms.TextBox BugDetailsTextBox;
        private System.Windows.Forms.Label DetailsLabel;
        private System.Windows.Forms.TextBox BugDescriptionTextBox;
        private System.Windows.Forms.Label BugDescriptionLabel;
        private System.Windows.Forms.Label SubmitDateLabel;
        private System.Windows.Forms.Label BugIDLabel;
        private System.Windows.Forms.ListBox BugListListBox;
        private System.Windows.Forms.Label BugListLabel;
        private System.Windows.Forms.ComboBox StatusFilterComboBox;
        private System.Windows.Forms.Label StatusFilterLabel;
        private System.Windows.Forms.TextBox BugRepStepsTextBox;
        private System.Windows.Forms.Label RepStepsLabel;
        private System.Windows.Forms.Button SaveEditBugsButton;
        private System.Windows.Forms.Label UpdateCommentsLabel;
        private System.Windows.Forms.TextBox UpdateCommentsTextBox;
        private System.Windows.Forms.DataGridView BugActivityLogDataGridView;
        private System.Windows.Forms.Label BugActivityLogLabel;
        private System.Windows.Forms.Label FixDateLabel;
        private System.Windows.Forms.TabPage UsersTab;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label UsersUserNameLabel;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label UserManagerLabel;
        private System.Windows.Forms.Label AppFormValidationLabel;
        private System.Windows.Forms.Button AppCancelButton;
        private System.Windows.Forms.Button AppSaveEditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox AppIDTextBox;
        private System.Windows.Forms.Button DeleteBugButton;
        private System.Windows.Forms.Button NewBugButton;
        private System.Windows.Forms.Button BugCancelButton;
        private System.Windows.Forms.Label BugFormValidationLabel;
        private System.Windows.Forms.TextBox BugIDTextBox;
        private System.Windows.Forms.Button UpdateSaveStatusButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BugNewStatusComboBox;
        private System.Windows.Forms.Button CancelStatusButton;
        private System.Windows.Forms.Button CancelUsersButton;
        private System.Windows.Forms.Button UsersNewUserButton;
        private System.Windows.Forms.Button EditSaveUsersButton;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox UserPhoneNumberTextBox;
        private System.Windows.Forms.TextBox UserEmailTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.Label SelectUserLabel;
        private System.Windows.Forms.ListBox SelectUserListBox;
        private System.Windows.Forms.Button UsersDeleteButton;
    }
}

