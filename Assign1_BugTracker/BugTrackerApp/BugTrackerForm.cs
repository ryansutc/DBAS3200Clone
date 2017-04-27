using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace BugTrackerApp
{
    public partial class BugTrackerForm : Form
    {
        private string applicationName;
        private BugTrackerDAL.User LoggedInUser;
        private string StatusMsg = ""; //holds any returned error messages or warnings from calls

        public BugTrackerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Bug Tracker form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BugTrackerForm_Load(object sender, EventArgs e)
        {
            try
            {

                //point the value of |DataDirectory| at our database in the datalayer
                string dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
                string absoluteDataDirectory = Path.GetFullPath(dataDirectory);
                AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);

                //set application name
                applicationName = ConfigurationManager.AppSettings["ApplicationName"].ToString();

                //set connection settings
                BugTrackerDAL.DB.ApplicationName = applicationName;
                BugTrackerDAL.DB.ConnectionTimeout = 30;

                LoadApplicationPageElements(); //load Application Page Stuff
                LoadBugPageElements(); //load Bug Page Stuff
               


            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message, false);
            }
        }

       /// <summary>
       /// Load, populate elements for the App Page/Tab
       /// </summary>
        private void LoadApplicationPageElements()
        {
            //Load Application values into various list elements
            LoadApplicationsList(ApplicationListBox);

            //Disable Tabs
            foreach (TabPage tab in this.BugTrackerTabControl.TabPages)
            {
                if (tab.Name != "IdentityTab")
                {
                    BugTrackerTabControl.TabPages.Remove(tab);
                }
            }
        }

        /// <summary>
        /// Load and populate all Elements on form's bug Page
        /// </summary>
        private void LoadBugPageElements()
        {
           try
            {
                LoadApplicationsList(BugAppComboBox); //populate Bug Page dropdown

                //populate status filter dropdown
                StatusFilterComboBox.Items.Add(new ListItem("ALL STATUSES", 0));
                foreach (BugTrackerDAL.StatusCode statuscode in
                    BugTrackerDAL.StatusCodes.GetList())
                {
                    StatusFilterComboBox.Items.Add(new ListItem(statuscode.StatusCodeDesc,
                        statuscode.StatusCodeID));
                }
                //populate new status dropdown
                foreach (BugTrackerDAL.StatusCode statuscode in
                    BugTrackerDAL.StatusCodes.GetList())
                {
                    BugNewStatusComboBox.Items.Add(new ListItem(statuscode.StatusCodeDesc,
                        statuscode.StatusCodeID));
                }
                //how to set the initial selected app and bug

                StatusFilterComboBox.SelectedIndex = 
                    StatusFilterComboBox.FindStringExact("ALL STATUSES"); //this will trigger selected index change?

                BugAppComboBox_SelectedIndexChanged(this, null);
               // StatusFilterComboBox_SelectedIndexChanged(this, null);

            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message, false);
            }
        }

        /// <summary>
        /// Load, populate elements for Users Page/Tab on form
        /// </summary>
        private void LoadUsersPageElements()
        {
            try
            {
                //populate users List
                BugTrackerDAL.Users users = new BugTrackerDAL.Users();
                SelectUserListBox.DataSource = users.GetUsers();
                SelectUserListBox.DisplayMember = "UserName";
                SelectUserListBox.ValueMember = "UserID";

                SelectUserListBox.SelectedIndex = 0;

                //BugAppComboBox_SelectedIndexChanged(this, null);
            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message, false);
            }
        }


        /// <summary>
        /// Loads the Application data from the database
        /// (Form Comboboxes on Application, Bug Tab call this)
        /// </summary>
        private void LoadApplicationsList(ListControl ListElement)
        {
            try
            {
                BugTrackerDAL.Applications applications = new BugTrackerDAL.Applications();

                ListElement.DataSource = applications.GetList();
                ListElement.DisplayMember = "AppName";
                ListElement.ValueMember = "AppId";
                
            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message, false);
            }
            catch (Exception e)
            {
                DisplayErrorMessage(e.Message, false);
            }
        }

        //############################################################################
        //Application Form

      /// <summary>
      /// Launches Logging in on form
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void UserNameButton_Click(object sender, EventArgs e)
        {
            //Validate Login
            LoggedInUser = BugTrackerDAL.User.ValidateUserName(UserNameTextBox.Text.Trim());

            if (LoggedInUser != null) //Valid User
            {
                BugTrackerTabControl.TabPages.Add(ApplicationsTab);
                BugTrackerTabControl.TabPages.Add(BugsTab);
                this.BugTrackerTabControl.SelectedTab = BugTrackerTabControl.TabPages["ApplicationsTab"];
                if (LoggedInUser.IsAdmin.Equals("Y"))
                {
                    BugTrackerTabControl.TabPages.Add(UsersTab);
                    if (LoggedInUser.IsAdmin.Equals("Y"))
                    {
                        LoadUsersPageElements();
                    }
                }
                this.Text += " - " + LoggedInUser.UserName;
                UserNameTextBox.Enabled = false;
                UserNameButton.Enabled = false;
            }
           
           else
            {
                MessageBox.Show("Error: That is not a valid User Name. Please try again.");
            }

        }
      

        /// <summary>
        /// updates the form elements with the fields from
        /// the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ApplicationListBox.SelectedIndex == -1) return;

            BugTrackerDAL.Application selectedApp =
            (BugTrackerDAL.Application)ApplicationListBox.SelectedItem;

            AppIDTextBox.Text = selectedApp.AppID.ToString();
            ApplicationNameTextBox.Text = selectedApp.AppName;
            AppVersionTextBox.Text = selectedApp.AppVersion;
            AppDescTextBox.Text = selectedApp.AppDesc;
           
        }

        /// <summary>
        /// Validate items on App page/tab before save/update of edits
        /// </summary>
        /// <returns></returns>
        public bool ValidateApplicationFormItems()
        {
            if (ApplicationNameTextBox.Text == "" || AppVersionTextBox.Text == "" ||
                AppDescTextBox.Text == "")
            {
                AppFormValidationLabel.Text = "Please fill out all fields.";
                return false;
            }
            else
            {
                AppFormValidationLabel.Text = "";
                return true;
            }
        }

       

        /// <summary>
        /// Handles Delete Button click on form and removes record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            BugTrackerDAL.Application selectedApp = (BugTrackerDAL.Application)ApplicationListBox.SelectedItem;
            if (BugTrackerDAL.Bugs.GetFilteredList(selectedApp, 0, true).Count > 0)
            {
                MessageBox.Show("Cannot delete app, there are bugs already created for it.");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Delete Record?", "Are you sure you want to delete this record?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DisplayErrorMessage(StatusMsg,
                    BugTrackerDAL.Applications.DeleteApp(selectedApp.AppID, out StatusMsg)
                );
                LoadApplicationsList(ApplicationListBox);
                LoadApplicationsList(BugAppComboBox);
            }            
        }

        /// <summary>
        /// Create a New Application via form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAppButton_Click(object sender, EventArgs e)
        {
            EnableEditFormItems();

            this.AppIDTextBox.Text = "";
            this.ApplicationListBox.Text = "";
            ApplicationListBox.SelectedIndex = -1;
            this.ApplicationNameTextBox.Text = "";
            this.AppVersionTextBox.Text = "";
            this.AppDescTextBox.Text = "";
        }

        /// <summary>
        /// Enable App Page Edit Application form Items
        /// </summary>
        private void EnableEditFormItems()
        {
            //enable edit form items, disable list form items
            this.ApplicationListBox.Enabled = false;   
            this.ApplicationNameTextBox.Enabled = true;  
            this.AppVersionTextBox.Enabled = true;   
            this.AppDescTextBox.Enabled = true;
            this.AppCancelButton.Enabled = true;

            this.AppSaveEditButton.Text = "Save";
            this.ApplicationNameTextBox.Focus();
        }

        /// <summary>
        /// Disable App Page Edit Application form Items
        /// </summary>
        private void DisableEditFormItems()
        {
            //leaving edit/create state
            //disable edit form items, enable list form items
            this.ApplicationListBox.Enabled = true;
            this.ApplicationNameTextBox.Enabled = false;
            this.AppVersionTextBox.Enabled = false;
            this.AppDescTextBox.Enabled = false;
            this.AppCancelButton.Enabled = false;

            this.ApplicationListBox.SelectedIndex = 0;

            this.AppSaveEditButton.Text = "Edit";
            this.ApplicationListBox.Focus();
        }
        
        /// <summary>
        /// Handles Save/Edit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppSaveEditButton_Click(object sender, EventArgs e)
        {
            if (!ValidateApplicationFormItems()){
                MessageBox.Show("Please fill out all items");
                return;
            }
            if (AppSaveEditButton.Text == "Save")
            {
                if (AppIDTextBox.Text == "") //New Record!
                {
                    BugTrackerDAL.Applications.AddNewApp(ApplicationNameTextBox.Text,
                        AppVersionTextBox.Text, AppDescTextBox.Text, out StatusMsg);

                }
                else //Existing Record update!
                {                          
                    BugTrackerDAL.Applications app = new BugTrackerDAL.Applications();
                    app.UpdateApp(Int32.Parse(AppIDTextBox.Text), ApplicationNameTextBox.Text,
                        AppVersionTextBox.Text, AppDescTextBox.Text, out StatusMsg);             
                }

                LoadApplicationsList(ApplicationListBox);
                LoadApplicationsList(BugAppComboBox);
                DisableEditFormItems();

            }
            else if (AppSaveEditButton.Text == "Edit")
            {
                EnableEditFormItems();
            }
        }

        /// <summary>
        /// Handle Cancel Button click on Application Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppCancelButton_Click(object sender, EventArgs e)
        {
            DisableEditFormItems();
            ApplicationListBox_SelectedIndexChanged(this, null);
        }


        //End Application Page Methods
        //################################################################################### 
        //Start Bug Path Methods
        /// <summary>
        /// Application Combobox Change event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void BugAppComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem statusItem = (ListItem) StatusFilterComboBox.SelectedItem;
            
            if (StatusFilterComboBox.SelectedItem != null && BugAppComboBox.SelectedItem != null)
            {
                RefilterBugCodeList((BugTrackerDAL.Application) BugAppComboBox.SelectedItem,
                    statusItem.Value, true);
            }
        }

        /// <summary>
        /// Called by BugAppComboBox on SelectedIndex Changed
        /// </summary>
        /// <param name="app">Application Class Object</param>
        /// <param name="status">statuscodeID int val</param>
        /// <param name="Refresh">bool whether to refresh full list of bugs</param>
        private void RefilterBugCodeList(BugTrackerDAL.Application app, int status, bool Refresh)
        {
            //just populating the status code combobox will change selected item.
            //if so, don't bother to try to update bug list
            if (app != null)
            {
                List<BugTrackerDAL.Bug> filteredbugs = BugTrackerDAL.Bugs.GetFilteredList(app, status, Refresh);
                BugListListBox.DataSource = filteredbugs;
                BugListListBox.DisplayMember = "BugDesc";
                BugListListBox.SelectedIndex = -1;
            }
        }
        
        
        /// <summary>
        /// Add New Bug for selected application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewBugButton_Click(object sender, EventArgs e)
        {
            EnableBugEditFormItems();

            BugIDTextBox.Text = "";
            SubmitDateLabel.Text = "";
            FixDateLabel.Text = "";
            BugDescriptionTextBox.Text = "";
            BugDetailsTextBox.Text = "";
            BugRepStepsTextBox.Text = "";

        }


        /// <summary>
        /// Handle Bug Cancel Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BugCancelButton_Click(object sender, EventArgs e)
        {
            DisableBugEditFormItems();

            StatusFilterComboBox_SelectedIndexChanged(this, null);
        }
       
        /// <summary>
        /// Save edits/new bug description and related elements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveEditBugsButton_Click(object sender, EventArgs e)
        {
            
            if (SaveEditBugsButton.Text == "Save")
            {
                if (!ValidateBugFormItems())
                {
                    MessageBox.Show("Please fill out all items");
                    return;
                }

                if (BugIDTextBox.Text == "") //New Record!
                {
                    BugTrackerDAL.Application app = 
                        (BugTrackerDAL.Application)BugAppComboBox.SelectedItem;
                    BugTrackerDAL.Bug bug = (BugTrackerDAL.Bug)BugListListBox.SelectedItem;
                    DisplayErrorMessage(StatusMsg,
                        BugTrackerDAL.Bugs.AddNewBug(app.AppID, LoggedInUser.UserID,
                            BugDescriptionTextBox.Text,
                            BugDetailsTextBox.Text, BugRepStepsTextBox.Text, out StatusMsg)
                    );
                }
                else //Existing Record update!
                {
                    BugTrackerDAL.Bug bug = new BugTrackerDAL.Bug();
                    BugTrackerDAL.Bug curBug = (BugTrackerDAL.Bug)BugListListBox.SelectedItem;
                    if (curBug.StatusCodeID == 4)
                    {
                        DialogResult dialogResult =
                        MessageBox.Show("This bug is already closed, are you sure you want to update it?",
                        "Update Closed Bug?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No) return;
                    }
                    DisplayErrorMessage(StatusMsg, 
                        bug.UpdateBug(curBug.BugID, curBug.BugSignOff, curBug.BugDate,
                        BugDescriptionTextBox.Text, BugDetailsTextBox.Text, 
                        BugRepStepsTextBox.Text, curBug.FixDate, out StatusMsg)
                    );     
                }
                

                ListItem statuscode = (ListItem)StatusFilterComboBox.SelectedItem;
                RefilterBugCodeList((BugTrackerDAL.Application)BugAppComboBox.SelectedItem,
                    statuscode.Value, true);

                DisableBugEditFormItems();

            }
            else if (AppSaveEditButton.Text == "Edit")
            {
                EnableBugEditFormItems();
            }
        }

        /// <summary>
        /// Runs after user clicks save on bug tab of form to
        /// validate data/ ensure all items are populated
        /// </summary>
        /// <returns></returns>
        public bool ValidateBugFormItems()
        {
            if (BugDescriptionTextBox.Text == "" || BugDetailsTextBox.Text == "" ||
                BugRepStepsTextBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Validate edits to buglog elements on bug tab/page
        /// </summary>
        /// <returns></returns>
        public bool ValidateBugLogItems()
        {
            if (BugNewStatusComboBox.SelectedItem == null || UpdateCommentsTextBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validate users form edits on users page/tab
        /// </summary>
        /// <returns></returns>
        public bool ValidateUsersFormItems()
        {
            if (NameTextBox.Text == null || UserEmailTextBox.Text == "" ||
                UserPhoneNumberTextBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Handle change of status filter combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem statuscode = (ListItem) StatusFilterComboBox.SelectedItem;
          
            RefilterBugCodeList((BugTrackerDAL.Application) BugAppComboBox.SelectedItem,
                statuscode.Value, false);

            if (BugListListBox.Items.Count == 0)
            {
                BugListListBox_SelectedIndexChanged(this, null);
            }
        }

        /// <summary>
        /// BugList Combobox selected item change (update bug form)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BugListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BugListListBox.SelectedIndex == -1)
            {
                BugIDTextBox.Text = "";
                SubmitDateLabel.Text = "Submit Date:";
                FixDateLabel.Text = "Fix Date:";
                BugDescriptionTextBox.Text = "";
                BugDetailsTextBox.Text = "";
                BugRepStepsTextBox.Text = "";

                SaveEditBugsButton.Enabled = false;
                BugCancelButton.Enabled = false;

                UpdateSaveStatusButton.Enabled = false;
                BugActivityLogDataGridView.Visible = false;
                return;
            }
            //populate Data
            BugTrackerDAL.Bug selectedBug =
              (BugTrackerDAL.Bug)BugListListBox.SelectedValue;

            DataTable BugLogTable = BugTrackerDAL.BugLog.GetBugLogs(selectedBug.BugID);
            BugActivityLogDataGridView.DataSource = BugLogTable;
            BugActivityLogDataGridView.Columns[2].HeaderText = "Updated By";

            BugIDTextBox.Text = String.Format("{0} ({1})", 
                selectedBug.BugID.ToString(), selectedBug.StatusCodeDesc);
            SubmitDateLabel.Text = "Submit Date: " + selectedBug.BugDate;
            if(selectedBug.StatusCodeID == 4)
            {
                FixDateLabel.Text = "Fix Date: " + selectedBug.FixDate;
            }
            BugDescriptionTextBox.Text = selectedBug.BugDesc;
            BugDetailsTextBox.Text = selectedBug.BugDetails;
            BugRepStepsTextBox.Text = selectedBug.RepSteps;
            SaveEditBugsButton.Enabled = true;
            UpdateSaveStatusButton.Enabled = true;
            BugActivityLogDataGridView.Visible = true;

        }
        
        /// <summary>
        /// Enable Bug Tab Edit Elements for a new/existing bug
        /// </summary>
        private void EnableBugEditFormItems()
        {
            //enable edit/ add new via bug form items
            this.BugDescriptionTextBox.Enabled = true;
            this.BugDetailsTextBox.Enabled = true;
            this.BugRepStepsTextBox.Enabled = true;
            

            this.SaveEditBugsButton.Enabled = true;
            this.NewBugButton.Enabled = false;
            this.DeleteBugButton.Enabled = false;
            this.BugCancelButton.Enabled = true;
            BugAppComboBox.Enabled = false;
            StatusFilterComboBox.Enabled = false;
            BugListListBox.Enabled = false;

            SaveEditBugsButton.Text = "Save";
            BugCancelButton.Enabled = true;
            this.BugDescriptionTextBox.Focus();
            BugActivityLogDataGridView.Enabled = false;
        }
        
        /// <summary>
        /// disable bug tab edit elements for a new/existing bug
        /// </summary>
        private void DisableBugEditFormItems()
        {
            //disable edit/ add new via bug form items
            this.BugDescriptionTextBox.Enabled = false;
            this.BugDetailsTextBox.Enabled = false;
            this.BugRepStepsTextBox.Enabled = false;

            this.SaveEditBugsButton.Enabled = false;
            this.NewBugButton.Enabled = true;
            this.DeleteBugButton.Enabled = true;

            
            this.BugCancelButton.Enabled = false;
            BugAppComboBox.Enabled = true;
            StatusFilterComboBox.Enabled = true;
            BugListListBox.Enabled = true;

            SaveEditBugsButton.Text = "Edit";
            BugCancelButton.Enabled = false;
            BugFormValidationLabel.Text = "";
            this.BugDescriptionTextBox.Focus();
            BugActivityLogDataGridView.Enabled = true;
        }
        //###################################################################
        //General Functions/methods

        /// <summary>
        /// A nested class to create combobox or listbox items
        /// with values and text
        /// </summary>
        private class ListItem
        {
            public string Name;
            public int Value;
            public ListItem(string Name, int Value)
            {
                this.Name = Name;
                this.Value = Value;
            }

            // override ToString() function
            public override string ToString()
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Generic function to turn error mesasges to messageboxes
        /// </summary>
        /// <param name="message"></param>
        private void DisplayErrorMessage(string message, bool ignore)
        {
            if (!ignore)
            {
                MessageBox.Show(this,
               message,
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete A bug button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBugButton_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.IsAdmin.Equals("N"))
            {
                MessageBox.Show("Sorry, you need to be admin to delete a bug");
                return;
            }
            DialogResult dialogResult = MessageBox.Show( 
                "Are you sure you want to delete this bug record and all related log activity?",
                "Delete Bug?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BugTrackerDAL.Bug bug = (BugTrackerDAL.Bug) BugListListBox.SelectedItem;
                
                DisplayErrorMessage(StatusMsg, 
                    BugTrackerDAL.Bug.DeleteBug(bug.BugID, out StatusMsg)
                );

                ListItem statusListItem = (ListItem) StatusFilterComboBox.SelectedItem;
                StatusFilterComboBox_SelectedIndexChanged(this, null);
                RefilterBugCodeList((BugTrackerDAL.Application) BugAppComboBox.SelectedItem, statusListItem.Value, true);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }


        /// <summary>
        /// Handle Toggling Edit or Triggering Save, Status Update Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSaveStatusButton_Click(object sender, EventArgs e)
        {
            BugTrackerDAL.Bug selectedBug = (BugTrackerDAL.Bug)BugListListBox.SelectedItem;
            if (UpdateSaveStatusButton.Text == "Update Status") //Edit Triggered
            {
                if (selectedBug.StatusCodeID == 4) //ie closed{
                {
                    DialogResult dialogResult = 
                        MessageBox.Show( "This bug is already closed, are you sure you want to update it?",
                        "Update Closed Bug?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No) return;
                }
                UpdateCommentsTextBox.Enabled = true;
                BugNewStatusComboBox.Enabled = true;
                CancelStatusButton.Enabled = true;
                UpdateSaveStatusButton.Text = "Save";

                BugAppComboBox.Enabled = false;
                StatusFilterComboBox.Enabled = false;
                BugListListBox.Enabled = false;         
            }
            else //Save of Edits Triggered
            {
                if (!ValidateBugLogItems())
                {
                    MessageBox.Show("Please Select a new Status and create a comment");
                    return;
                }
                //save edit
                // int StatusCodeID, int UserID, String BugLogDesc, int BugID
                BugTrackerDAL.Application selectedApp = (BugTrackerDAL.Application)BugAppComboBox.SelectedItem;
                ListItem NewStatusCode = (ListItem)BugNewStatusComboBox.SelectedItem;
                ListItem StatusCodeFilter = (ListItem)StatusFilterComboBox.SelectedItem;
                BugTrackerDAL.Bug SelectedBug = (BugTrackerDAL.Bug)BugListListBox.SelectedItem;

                DisplayErrorMessage(StatusMsg,
                    BugTrackerDAL.BugLogs.AddNewBugLog(NewStatusCode.Value, LoggedInUser.UserID,
                        UpdateCommentsTextBox.Text, SelectedBug.BugID, out StatusMsg)
                );
                
                UpdateCommentsTextBox.Enabled = false;
                UpdateCommentsTextBox.Text = "";
                BugNewStatusComboBox.Enabled = false;
                BugNewStatusComboBox.SelectedIndex = -1; //???
                CancelStatusButton.Enabled = false;
                UpdateSaveStatusButton.Text = "Update Status";
                MessageBox.Show("Status of Bug Updated!");
                RefilterBugCodeList(selectedApp, StatusCodeFilter.Value, true);
                BugListListBox_SelectedIndexChanged(this, null);

                BugAppComboBox.Enabled = true;
                StatusFilterComboBox.Enabled = true;
                BugListListBox.Enabled = true;

            }
        }
//##########################################################################################3
//User Page Methods

            /// <summary>
            /// handle selected user change, fire updates to dependent child elements
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void SelectUserListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectUserListBox.SelectedIndex == -1)
            {
                UserIDTextBox.Text = "";
                NameTextBox.Text = "";
                UserEmailTextBox.Text = "";
                UserPhoneNumberTextBox.Text = "";
            }
            else
            {
                BugTrackerDAL.User SelectedUser = (BugTrackerDAL.User)SelectUserListBox.SelectedItem;
                //When the user selected changes, update the user form elements
                UserIDTextBox.Text = SelectedUser.UserID.ToString();
                NameTextBox.Text = SelectedUser.UserName;
                UserEmailTextBox.Text = SelectedUser.UserEmail;
                UserPhoneNumberTextBox.Text = SelectedUser.UserTel;
            }
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersNewUserButton_Click(object sender, EventArgs e)
        {
            UserIDTextBox.Text = "";
            NameTextBox.Text = "";
            UserEmailTextBox.Text = "";
            UserPhoneNumberTextBox.Text = "";
            EnableUsersFormItems();
        }

        /// <summary>
        /// Enable User Edit form items
        /// </summary>
        public void EnableUsersFormItems()
        {

        
            NameTextBox.Enabled = true;
            UserEmailTextBox.Enabled = true;
            UserPhoneNumberTextBox.Enabled = true;

            SelectUserListBox.Enabled = false;
            UsersNewUserButton.Enabled = false;

            CancelUsersButton.Enabled = true;
            EditSaveUsersButton.Text = "Save";
        }

        /// <summary>
        /// Disable user form items
        /// </summary>
        public void DisableUsersFormItems()
        {
            UserIDTextBox.Text = "";
            NameTextBox.Enabled = false;
            NameTextBox.Text = "";
            UserEmailTextBox.Enabled = false;
            UserEmailTextBox.Text = "";
            UserPhoneNumberTextBox.Enabled = false;
            UserPhoneNumberTextBox.Text = "";

            SelectUserListBox.Enabled = true;
            SelectUserListBox.SelectedIndex = -1;
            UsersNewUserButton.Enabled = true;

            CancelUsersButton.Enabled = false;
            //EditSaveUsersButton.Enabled = false;
            EditSaveUsersButton.Text = "Edit";
        }

        /// <summary>
        /// Edit or Save edits of Users tab/page data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditSaveUsersButton_Click(object sender, EventArgs e)
        {
            if (!ValidateUsersFormItems())
            {
                MessageBox.Show("Please fill out all items.");
                return;
            }
            if (EditSaveUsersButton.Text == "Save")
            {
                if(UserIDTextBox.Text == "") //new record!
                {
                    if (!BugTrackerDAL.Users.AddNewUser(NameTextBox.Text, UserEmailTextBox.Text,
                    UserPhoneNumberTextBox.Text, out StatusMsg))
                    {
                        DisplayErrorMessage(StatusMsg, false); // if cannot addnew user
                        return;
                    }
                    MessageBox.Show("New User Successfully Added");
                }
                else //existing record
                {
                    if (!BugTrackerDAL.Users.UpdateUser(Int32.Parse(UserIDTextBox.Text),
                        NameTextBox.Text, UserEmailTextBox.Text,
                     UserPhoneNumberTextBox.Text, out StatusMsg))
                    {
                        DisplayErrorMessage(StatusMsg, false); // if cannot addnew user
                        return;
                    }
                }
                
                LoadUsersPageElements();
                DisableUsersFormItems();
            }

            else if (EditSaveUsersButton.Text == "Edit") //start edit session
            {
                //handle editing existing elements
                EnableUsersFormItems();
               
            }
            else //handle save of edits/new record
            {
                if(!BugTrackerDAL.Users.AddNewUser(NameTextBox.Text, UserEmailTextBox.Text, 
                    UserPhoneNumberTextBox.Text, out StatusMsg))
                {
                    DisplayErrorMessage(StatusMsg, false);
                    return;
                }
                
                
            }
        }

        /// <summary>
        /// Delete a user from user tab/page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete User?", "Are you sure you want to delete this user?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                //check if user has bugs associated with them
                //check if user is admin
                BugTrackerDAL.User selectedUser = (BugTrackerDAL.User)SelectUserListBox.SelectedItem;
                if (selectedUser.IsAdmin.Equals("Y"))
                {
                    MessageBox.Show("Sorry, you cannot delete this user because they are the admin");
                    return;
                }
                List<BugTrackerDAL.Bug> BugList = BugTrackerDAL.Bugs.GetList();
                foreach(BugTrackerDAL.Bug bug in BugList)
                {
                    if (bug.UserID == selectedUser.UserID)
                    {
                        MessageBox.Show("Sorry, you cannot delete this user because they have created bugs");
                        return;
                    }
                }
                DisplayErrorMessage(StatusMsg,
                    BugTrackerDAL.Users.DeleteUser(selectedUser.UserID, out StatusMsg)
                );
                LoadUsersPageElements();
                SelectUserListBox_SelectedIndexChanged(this, null);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
