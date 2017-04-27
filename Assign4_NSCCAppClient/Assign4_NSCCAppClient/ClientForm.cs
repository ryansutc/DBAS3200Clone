using Assign4_NSCCAppClient;
using Assign4_NSCCAppClient.NSCCModelDB;
using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign4_NSCCAppClient
{
    public partial class ClientForm : Form
    {
        string serviceUri = @"http://nsccwebservicew0143446.azurewebsites.net/";
        Default.Container container;
        DataServiceContext context;
        bool FormError;
        /// <summary>
        /// This form uses WCF Data Services; formally ADO .NET data services (https://msdn.microsoft.com/en-us/library/cc668794(v=vs.110).aspx)
        /// which uses Open Data Protocol OData to get data. It is based on the Entity Data Model conventions (Entity Framework)
        /// </summary>
        public ClientForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form and initialize all form elements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientForm_Load(object sender, EventArgs e)
        {
            this.Text = "NSCC Application Form Viewer";
            ResetLabels();
            container = new Default.Container(new Uri(serviceUri));

            //Bind Data Sources
            AcademicYearCbo.DisplayMember = "Description";
            AcademicYearCbo.ValueMember = "AcademicYearId";
            AcademicYearCbo.DataSource = container.AcademicYears.OrderBy(ay => ay.Description).ToList();

            //Gender Values Hardcoded

            CountryCbo.DisplayMember = "CountryName";
            CountryCbo.ValueMember = "CountryCode";
            CountryCbo.DataSource = container.Countries.OrderBy(ay => ay.CountryName).ToList();
            CountryCbo.SelectedValue = "CA";
            CountryCbo_SelectedIndexChanged(this, null);

            ProvinceStateCbo.DisplayMember = "Name";
            //Province State has composite key. How to set value member
            ProvinceStateCbo.DataSource = container.ProvinceStates.Where(ps => ps.CountryCode == "CA").ToList();

            CitizenshipCbo.DisplayMember = "Description";
            CitizenshipCbo.DataSource = container.Citizenships.ToList();

           
            CitizenshipOtherCbo.Enabled = false;

            ProgramChoice1Cbo.DataSource = container.Programs.ToList();
            ProgramChoice1Cbo.DisplayMember = "Name";
            ProgramChoice1Cbo.ValueMember = "ProgramId";

            CampusChoice1Cbo.DataSource = container.Campuses.ToList();
            CampusChoice1Cbo.DisplayMember = "Name";
            CampusChoice1Cbo.ValueMember = "CampusId";
            

            ProgramChoice2Cbo.DisplayMember = "Name";
            ProgramChoice2Cbo.DataSource = container.Programs.ToList();
            ProgramChoice2Cbo.ValueMember = "ProgramId";

            CampusChoice2Cbo.DisplayMember = "Name";
            CampusChoice2Cbo.ValueMember = "CampusId";
            CampusChoice2Cbo.DataSource = container.Campuses.ToList();
           
        }
      
        /// <summary>
        /// Update Campus Options when user changes selected Program 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramChoice1Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CampusChoice1Cbo.DataSource = null;
            CampusChoice1Cbo.Items.Clear();
            if(ProgramChoice1Cbo.SelectedIndex != 0)
            {
                foreach (Campus c in container.Campuses.Expand("Programs"))
                {
                    foreach (var p in c.Programs)
                    {
                        if (p.ProgramId == (int)ProgramChoice1Cbo.SelectedValue)
                        {
                            ComboBoxItem item = new ComboBoxItem();
                            item.Text = c.Name;
                            item.Value = c.CampusId;
                            CampusChoice1Cbo.Items.Add(item);
                        }
                    }
                }
            }
           
        }
        /// <summary>
        /// Update Campus Options when user selects new program 2 choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramChoice2Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CampusChoice2Cbo.DataSource = null;
            CampusChoice2Cbo.Items.Clear();
            foreach (Campus c in container.Campuses.Expand("Programs"))
            {
                foreach (var p in c.Programs)
                {
                    if (p.ProgramId == (int)ProgramChoice1Cbo.SelectedValue)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Text = c.Name;
                        item.Value = c.CampusId;
                        CampusChoice2Cbo.Items.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Update Province/State Options when user selects their Country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountryCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountryCbo.SelectedValue.ToString() == "CA" ||
                CountryCbo.SelectedValue.ToString() == "US")
            {
                ProvinceStateCbo.DisplayMember = "Name";
                ProvinceStateCbo.ValueMember = "ProvinceStateCode";
                ProvinceStateOtherCbo.Clear();
                ProvinceStateOtherCbo.Enabled = false;
                ProvinceStateCbo.Enabled = true;
                ProvinceStateCbo.DataSource =
                    container.ProvinceStates.Where(ps => ps.CountryCode ==
                    CountryCbo.SelectedValue.ToString()).ToList();
            }
            else
            {
                ProvinceStateCbo.DataSource = null;
                ProvinceStateCbo.Enabled = false;
                ProvinceStateOtherCbo.Enabled = true;
            }
        }

        /// <summary>
        /// Update Citizenshup other value when Citizenship is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CitizenshipCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Validation
            CitizenshipCbo.BackColor = Color.White;
            if (CitizenshipCbo.Text == "Other")
            {
                CitizenshipOtherCbo.Enabled = true;
            }
            else
            {
                CitizenshipOtherCbo.Enabled = false;
                CitizenshipOtherCbo.SelectedItem = -1;
            }

            //Update CitizenshipOther combobox if this value is Other
            if(((Citizenship)CitizenshipCbo.SelectedItem).CitizenshipId == 5)
            {
                CitizenshipOtherCbo.Enabled = true;
                CitizenshipOtherCbo.DisplayMember = "CountryName";
                CitizenshipOtherCbo.ValueMember = "CountryCode";
                CitizenshipOtherCbo.DataSource = container.Countries.OrderBy(ay => ay.CountryName).ToList();
                //CountryCbo_SelectedIndexChanged(this, null);
            }
            else
            {
                CitizenshipOtherCbo.Enabled = false;
                CitizenshipOtherCbo.DataSource = null;
               CitizenshipOtherCbo.SelectedItem = -1;
            }
            
        }


        /// <summary>
        /// How to validate email.
        /// From MSDN: https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        private bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))  return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Fires when the email field is changed to call validation and change background color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTxt_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmail(EmailTxt.Text))
            {
                EmailTxt.BackColor = Color.White;
            }
            else
            {
                EmailTxt.BackColor = Color.LightSalmon;
            }
        }

        /// <summary>
        /// This is called on text leave and text changed to validate. Make sure not empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CitizenshipOtherTxt_TextChanged(object sender, EventArgs e)
        {
            CitizenshipOtherCbo.BackColor = Color.White;
            if (String.IsNullOrWhiteSpace(CitizenshipOtherCbo.Text))
            {
                CitizenshipOtherCbo.BackColor = Color.LightSalmon;
            }
            else
            {
                CitizenshipOtherCbo.BackColor = Color.White;
            }
        }


        /// <summary>
        /// When submit button on form is clicked submit record
        /// to REST database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!FormInvalid())
            {
                Applicant newApplicant = new Applicant();
                newApplicant.FirstName = FirstNameTxt.Text;
                newApplicant.MiddleName = MiddleNameTxt.Text;
                newApplicant.LastName = LastNameTxt.Text;
                newApplicant.DOB = DataOfBirthDateTimePicker.Value;
                newApplicant.Gender = GenderCbo.Text.Substring(0,1);
                newApplicant.StreetAddress1 = StreetAddressTxt.Text;
                newApplicant.City = CityTxt.Text;
                newApplicant.CountryCode = ((Country) CountryCbo.SelectedItem).CountryCode;
                newApplicant.PhoneHome = "5555555555";
                newApplicant.Email = EmailTxt.Text;
                newApplicant.Citizenship = ((Citizenship)CitizenshipCbo.SelectedItem).CitizenshipId;
                if (((Citizenship) CitizenshipCbo.SelectedItem).CitizenshipId == 5)
                {              
                    newApplicant.CitizenshipOther = ((Country)CitizenshipOtherCbo.SelectedItem).CountryCode;
                }

                newApplicant.HasCriminalConviction = PastCriminalConvictionChk.Checked;
                newApplicant.OnChildAbuseRegistry = ChildAbuseRegChk.Checked;
                newApplicant.HasDisciplinaryAction = PastDiscActionChk.Checked;
                newApplicant.IsAfricanCanadian = AfricanCanadianChk.Checked;
                newApplicant.IsFirstNations = FirstNationsChk.Checked;
                newApplicant.IsCurrentALP = ALPStudentChk.Checked;
                newApplicant.HasDisability = DocumentedDisabilityChk.Checked;
                newApplicant.Password = "password";
                try{
                    container.AddToApplicants(newApplicant);
                    container.SaveChanges();

                    NSCCModelDB.Application newApplication = new NSCCModelDB.Application();
                    newApplication.ApplicationDate = DateTime.Now;
                    newApplication.ApplicantId = newApplicant.ApplicantId;
                    newApplication.Paid = false;

                    container.AddToApplications(newApplication);
                    container.SaveChanges();

                    ProgramChoice newProgramChoice = new ProgramChoice();
                    newProgramChoice.ApplicationId = newApplication.ApplicationId;
                    newProgramChoice.CampusId = ((ComboBoxItem) CampusChoice1Cbo.SelectedItem).Value;
                    // newProgramChoice.ProgramId = ((Program) ProgramChoice1Cbo.SelectedItem).ProgramId; //dont work?
                    newProgramChoice.ProgramId = (int) ProgramChoice1Cbo.SelectedValue;
                    newProgramChoice.Preference = 1;
                    container.AddToProgramChoices(newProgramChoice);
                    container.SaveChanges();

                    ProgramChoice newProgramChoice2 = new ProgramChoice();
                    newProgramChoice2.ApplicationId = newApplication.ApplicationId;
                    newProgramChoice2.CampusId = ((ComboBoxItem)CampusChoice2Cbo.SelectedItem).Value;
                    // newProgramChoice2.ProgramId = ((Program) ProgramChoice1Cbo.SelectedItem).ProgramId; //dont work?
                    newProgramChoice2.ProgramId = (int)ProgramChoice2Cbo.SelectedValue;
                    newProgramChoice2.Preference = 2;
                    container.AddToProgramChoices(newProgramChoice2);
                    container.SaveChanges();
                    ErrorLbl.Text = "Successfully Added new Record";
                }
                catch (Exception ex)
                {
                    ErrorLbl.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// Check that all form values are valid (not empty or invalid)
        /// before submit is called.
        /// Will update label formatting if invalid.
        /// </summary>
        /// <returns></returns>
        public bool FormInvalid()
        {
            FormError = false;
            if(AcademicYearCbo.Text == "")
            {
                AcademicYearCbo.BackColor = Color.Salmon;
                AcademicYearLbl.Font = new Font(AcademicYearLbl.Font, FontStyle.Bold);
                FormError = true;    
            }
            else
            {
                AcademicYearCbo.BackColor = Color.White;
                AcademicYearLbl.Font = new Font(AcademicYearLbl.Font, FontStyle.Regular);
            }

            if (String.IsNullOrWhiteSpace(FirstNameTxt.Text))
            {
                FirstNameTxt.BackColor = Color.Salmon;
                FirstNameLbl.Font = new Font(FirstNameLbl.Font, FontStyle.Bold);
                FormError = true;
            }
            else
            {
                FirstNameTxt.BackColor = Color.White;
                FirstNameLbl.Font = new Font(FirstNameLbl.Font, FontStyle.Regular);
            }

            if (String.IsNullOrWhiteSpace(MiddleNameTxt.Text))
            {
                MiddleNameTxt.BackColor = Color.Salmon;
                MiddleNameLbl.Font = new Font(MiddleNameLbl.Font, FontStyle.Bold);
                FormError = true;
            }
            else
            {
                MiddleNameLbl.Font = new Font(MiddleNameLbl.Font, FontStyle.Regular);
                MiddleNameTxt.BackColor = Color.White;
            }

            if (String.IsNullOrWhiteSpace(LastNameTxt.Text))
            {
                LastNameTxt.BackColor = Color.Salmon;
                LastNameLbl.Font = new Font(LastNameLbl.Font, FontStyle.Bold);
                FormError = true;
            }
            else
            {
                LastNameLbl.Font = new Font(LastNameLbl.Font, FontStyle.Regular);
                LastNameTxt.BackColor = Color.White;
            }

            //DataOfBirthDateTimePicker.Value Dont worry

            if(GenderCbo.Text == "")
            {
                GenderCbo.BackColor = Color.Salmon;
                GenderLbl.Font = new Font(GenderLbl.Font, FontStyle.Bold);
                FormError = true;
            }
            else
            {
                GenderCbo.BackColor = Color.White;
                GenderLbl.Font = new Font(GenderLbl.Font, FontStyle.Regular);
            }

            if(CountryCbo.Text == "")
            {
                CountryCbo.BackColor = Color.Salmon;
                CountryLbl.Font = new Font(CountryLbl.Font, FontStyle.Bold);
                FormError = true;
            }
            else
            {
                CountryCbo.BackColor = Color.White;
                CountryLbl.Font = new Font(CountryLbl.Font, FontStyle.Regular);
            }

            if (String.IsNullOrWhiteSpace(StreetAddressTxt.Text))
            {
                StreetAddressTxt.BackColor = Color.Salmon;
                StreetAddressLbl.Font = new Font(StreetAddressLbl.Font, FontStyle.Bold);
                FormError = true;
            }
            else
            {
                StreetAddressTxt.BackColor = Color.White;
                StreetAddressLbl.Font = new Font(StreetAddressLbl.Font, FontStyle.Regular);
            }

            if(String.IsNullOrWhiteSpace(CityTxt.Text))
            {
                CityLbl.Font = new Font(CityLbl.Font, FontStyle.Bold);
                CityTxt.BackColor = Color.Salmon;
                FormError = true;
            }
            else
            {
                CityLbl.Font = new Font(CityLbl.Font, FontStyle.Regular);
                CityTxt.BackColor = Color.White;
            }
            /*
            if(ProvinceStateCbo.Text == "" && String.IsNullOrWhiteSpace(ProvinceStateOtherLbl.Text))
            {
                //DO SOMETHING
            }
            */
            if (!IsValidEmail(EmailTxt.Text))
            {
                EmailLbl.Font = new Font(EmailLbl.Font, FontStyle.Bold);
                EmailTxt.BackColor = Color.Salmon;
                FormError = true;
            }
            else
            {
                EmailLbl.Font = new Font(EmailLbl.Font, FontStyle.Regular);
                EmailTxt.BackColor = Color.White;
            }

            if(CitizenshipCbo.Text == "" && String.IsNullOrWhiteSpace(CitizenshipOtherCbo.Text))
            {
                CitizenshipLbl.Font = new Font(CitizenshipLbl.Font, FontStyle.Bold);
                CitizenshipCbo.BackColor = Color.Salmon;
                FormError = true;
            }
            else
            {
                CitizenshipLbl.Font = new Font(CitizenshipLbl.Font, FontStyle.Regular);
                CitizenshipCbo.BackColor = Color.White;
            }



            if (FormError)
            {
                ErrorLbl.Text = "Please fill out all required fields properly";
            }
            else
            {
                ErrorLbl.Text = "";
            }

            return FormError;

        }


        //VALIDATION
        private void AcademicYearCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcademicYearCbo.BackColor = Color.White;
            AcademicYearLbl.Font = new Font(AcademicYearLbl.Font, FontStyle.Regular);

        }

        private void FirstNameTxt_TextChanged(object sender, EventArgs e)
        {
            FirstNameTxt.BackColor = Color.White;
        }

        private void MiddleNameTxt_TextChanged(object sender, EventArgs e)
        {
            MiddleNameTxt.BackColor = Color.White;
        }

        private void LastNameTxt_TextChanged(object sender, EventArgs e)
        {
            LastNameTxt.BackColor = Color.White;
        }

        private void DataOfBirthDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DataOfBirthDateTimePicker.BackColor = Color.White;
        }

        private void GenderCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenderCbo.BackColor = Color.White;
        }

        private void StreetAddressTxt_TextChanged(object sender, EventArgs e)
        {
            StreetAddressTxt.BackColor = Color.White;
        }

        private void CityTxt_TextChanged(object sender, EventArgs e)
        {
            CityTxt.BackColor = Color.White;
        }

        private void ProvinceStateCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProvinceStateCbo.BackColor = Color.White;
        }

        private void ProvinceStateOtherCbo_TextChanged(object sender, EventArgs e)
        {
            ProvinceStateOtherCbo.BackColor = Color.White;
        }

        /// <summary>
        /// Used to format the Applicants List box with first & last name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatApplicantsListBox(object sender, ListControlConvertEventArgs e)
        {
            // Assuming your class called Employee , and Firstname & Lastname are the fields
            string lastname = ((Applicant)e.ListItem).FirstName;
            string firstname = ((Applicant)e.ListItem).LastName;
            e.Value = lastname + " " + firstname;
        }

        /// <summary>
        /// Update Applicants Details when a different value selected in listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicantsListListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SubmittedApplicationsListbox.DataSource = "";
            SubmittedApplicationsListbox.DisplayMember = "ApplicationDate";
            SubmittedApplicationsListbox.ValueMember = "ApplicationId";
            var values = container.Applications.Where(a => a.ApplicantId ==
                ((Applicant)ApplicantsListListbox.SelectedItem).ApplicantId).ToList();
            SubmittedApplicationsListbox.DataSource = values;

            //Populate fields:
            if(ApplicantsListListbox.SelectedIndex != -1)
            {
                //function to restore label values first to just the field name
                ResetLabels();
                //function to convert boolean to string Yes/No
                
                //process to check citizenship
                Applicant selApplicant = ((Applicant)ApplicantsListListbox.SelectedItem);
                SubApplicantIdLbl.Text += selApplicant.ApplicantId;
                SubFirstNameLbl.Text += selApplicant.FirstName;
                subMiddleNameLbl.Text += selApplicant.MiddleName;
                SubLastNameLbl.Text += selApplicant.LastName;

                SubDateOfBirthLbl.Text += selApplicant.DOB;
                SubGenderLbl.Text += selApplicant.Gender;
                SubCountryLbl.Text += selApplicant.Country;
                SubStreetAddressLbl.Text += selApplicant.StreetAddress1;
                SubCityLbl.Text += selApplicant.City;
                if (!String.IsNullOrWhiteSpace(selApplicant.ProvinceStateCode))
                {
                    SubProvStateLbl.Text += container.ProvinceStates.Where(ps => ps.ProvinceStateCode == selApplicant.ProvinceStateCode).First();
                }
                else
                {
                    SubProvStateLbl.Text += selApplicant.ProvinceStateOther;
                }
                
                SubEmailLbl.Text += selApplicant.Email;
                SubCitizenshipLbl.Text += selApplicant.Citizenship;
                SubCPastCriminalConvictionLbl.Text += ConvertBoolean(selApplicant.HasCriminalConviction);
                SubOnChildAbuseRegistryLbl.Text += ConvertBoolean(selApplicant.OnChildAbuseRegistry);
                SubDisciplinaryActionLbl.Text += ConvertBoolean(selApplicant.HasDisciplinaryAction);
                SubAfricanCanadianLbl.Text += ConvertBoolean(selApplicant.IsAfricanCanadian);
                SubFirstNationsLbl.Text += ConvertBoolean(selApplicant.IsFirstNations);
                SubCurrentALPStudentLbl.Text += ConvertBoolean(selApplicant.IsCurrentALP);
                SubDocumentedDisabilityLbl.Text += ConvertBoolean(selApplicant.HasDisability);

                PopulateSubmittedApplicationsLabels();
            }

        }

        /// <summary>
        /// Populate Applications Labels when Applicant is changed
        /// </summary>
        private void PopulateSubmittedApplicationsLabels()
        {
            if(SubmittedApplicationsListbox.SelectedIndex != -1)
            {
                NSCCModelDB.Application selApplication = (NSCCModelDB.Application)SubmittedApplicationsListbox.SelectedItem;
                SubApplicationIdLbl.Text += selApplication.ApplicationId.ToString();
                int appId = Int32.Parse(selApplication.ApplicationId.ToString());
                var myProgramChoices = container.ProgramChoices.Expand("Campus").Expand("Program").Where(pc => pc.ApplicationId == appId).ToList();
                foreach(var pc in myProgramChoices)
                {
                    if(pc.Preference == 1)
                    {
                        SubProgramChoice1Lbl.Text += pc.Program.Name;
                        SubCampusChoice1Lbl.Text += pc.Campus.Name;
                    }
                    else
                    {
                        SubProgramChoice2Lbl.Text += pc.Program.Name;
                        SubCampusChoice2Lbl.Text += pc.Campus.Name;
                    }
                }
            }
        }


        /// <summary>
        /// Reset labels to empty (except title) if the user switches selection.
        /// </summary>
        private void ResetLabels()
        {
            //Get All Controls
            List<Control> c = Controls.OfType<TextBox>().Cast<Control>().ToList();

            List<Control> controlList = new List<Control>();
            foreach (Control ctl in tabPage2.Controls)
            {
                if (ctl is Label)
                {
                    String text = ctl.Text.Substring(0, ctl.Text.IndexOf(":") + 1);
                    ctl.Text = text + " ";
                }
            }
        }


        /// <summary>
        /// Reformat Boolean to Yes/No for form
        /// </summary>
        /// <param name="mybool"></param>
        /// <returns></returns>
        private string ConvertBoolean(bool mybool)
        {
            if (mybool)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }


        /// <summary>
        /// Load Applicants Data when entering the second tab. Note, refreshes container w. database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmittedApplicantsTab_OnEnter(object sender, EventArgs e)
        {
            // Load Elements on Submitted Applicants TabPage
            container = new Default.Container(new Uri(serviceUri)); //reload container to get updated records?
            ApplicantsListListbox.DisplayMember = "FirstName";
            ApplicantsListListbox.ValueMember = "ApplicationId";
            ApplicantsListListbox.DataSource = container.Applicants.ToList();
        }
    }


    
}
