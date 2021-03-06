using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UEMS;
using Bsoft.Common.Language;
using Bsoft.Common;
using Friuts;
using UEMS.BLL;
using Bsoft.Forms;
using Bsoft.Languages;
using Bsoft.Data;
using Bsoft.AppCom;
namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class MainForm : Bsoft.AppCom.MainFormCom
    {
        public MainForm()
        {
            InitializeComponent();
            //lblUserName.Text = Language.LanguageString .User;
            mnuMasterEntry.Text = Language.LanguageString.MasterEntry;
            MnuRestore.Text = Language.LanguageString.Restore;
            MnuBackup.Text = Language.LanguageString.Backup;
            MnuChangeUserLoging.Text = Language.LanguageString.LogOff;
            MnuExit.Text = Language.LanguageString.Close;
        }

        public MainForm(string load)
            : this()
        {

            LblTitle.Visible = false;
            Text = UEMS.frmAboutBox.AssemblyProduct;

            // this.mnuOrgDetails.Click += new System.EventHandler(this.mnuChangeableDetails_Click);

            this.MnuRightsAssign.Click += new System.EventHandler(this.MnuRightsAssign_Click);
            this.MnuChangePassword.Click += new System.EventHandler(this.MnuChangePassword_Click);
            this.MnuChangeUserLoging.Click += new System.EventHandler(this.MnuChangeUserLoging_Click);
            this.MnuRestore.Click += new System.EventHandler(this.MnuRestore_Click);
            this.MnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            //this.MnuBackup.Click += new System.EventHandler(this.MnuBackup_Click);
            this.mnuChangeableDetails.Click += new System.EventHandler(this.mnuChangeableDetails_Click);

            //lblUserName.Text = Language.User;
            mnuMasterEntry.Text = Language.LanguageString.MasterEntry;
            MnuRestore.Text = Language.LanguageString.Restore;
            MnuBackup.Text = Language.LanguageString.Backup;
            MnuChangeUserLoging.Text = Language.LanguageString.LogOff;
            MnuExit.Text = Language.LanguageString.Close;

            //lblUserName.Text = Language.User;
            // mnuMasterEntry.Text = Language.MasterEntry;
            // mnuRestore.Text = Language.LanguageString.Restore;
            //mnuBackUpDataBase.Text = Language.LanguageString.Backup;
            //mnuChangeLogin.Text = Language.LanguageString.LogOff;
            //mnuExit.Text = Language.LanguageString.Close;


            LoadOrganaizationDetails();

          


            if (!LoginOrChangeUser())
            {
                // Close();
                Application.ExitThread();
                Application.Exit();
            }


        }

      
        //public MainForm()
        //{
        //    InitializeComponent();
        //    this.MnuRightsAssign.Click += new System.EventHandler(this.MnuRightsAssign_Click);
        //    this.MnuChangePassword.Click += new System.EventHandler(this.MnuChangePassword_Click);
        //    this.MnuChangeUserLoging.Click += new System.EventHandler(this.MnuChangeUserLoging_Click);
        //    this.MnuRestore.Click += new System.EventHandler(this.MnuRestore_Click);
        //    this.MnuExit.Click += new System.EventHandler(this.MnuExit_Click);
        //    this.MnuBackup.Click += new System.EventHandler(this.MnuBackup_Click);
        //    this.mnuChangeableDetails.Click += new System.EventHandler(this.mnuChangeableDetails_Click);

        //    //lblUserName.Text = Language.User;
        //    mnuMasterEntry.Text = Language.LanguageString.MasterEntry;
        //    MnuRestore.Text = Language.LanguageString.Restore;
        //    MnuBackup.Text = Language.LanguageString.Backup;
        //    MnuChangeUserLoging.Text = Language.LanguageString.LogOff;
        //    MnuExit.Text = Language.LanguageString.Close;
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {

         
            if (!LoginOrChangeUser())
            {
                Application.Exit();
            }
            LoadOrganaizationDetails();
//chk
           
        }


        #region NGOR Master
        UEMS.Master_Lst frmSex;
        private void mnuAanotanodjno_Click(object sender, EventArgs e)
        {
            getForm(ref frmSex);
            frmSex.TableName = "Master_Gender";
            frmSex.Show();
            frmSex.Activate();
        }



        UEMS.Master_Lst frmObjective;
        private void mnuObjective_Click(object sender, EventArgs e)
        {
            getForm(ref frmObjective);
            frmObjective.TableName = "Objective";
            frmObjective.Show();
            frmObjective.Activate();
        }


        UEMS.Master_Lst frmDocument;
        private void mnuDocument_Click(object sender, EventArgs e)
        {
            getForm(ref frmDocument);
            frmDocument.TableName = "Document";
            frmDocument.Show();
            frmDocument.Activate();
        }


        UEMS.Master_Lst frmAffiliationOrganization;
        private void mnuAffiliationOrganization_Click(object sender, EventArgs e)
        {
            getForm(ref frmAffiliationOrganization);
            frmAffiliationOrganization.TableName = "AffiliationOrganization";
            frmAffiliationOrganization.Show();
            frmAffiliationOrganization.Activate();
        }


        UEMS.Master_Lst frmSubjectiveWrk;
        private void mnuSubjectiveWrk_Click(object sender, EventArgs e)
        {
            getForm(ref frmSubjectiveWrk);
            frmSubjectiveWrk.TableName = "SubjectiveWrk";
            frmSubjectiveWrk.Show();
            frmSubjectiveWrk.Activate();
        }


        UEMS.Master_Lst frmTargetAudience;
        private void mnuTargetAudience_Click(object sender, EventArgs e)
        {
            getForm(ref frmTargetAudience);
            frmTargetAudience.TableName = "TargetAudience";
            frmTargetAudience.Show();
            frmTargetAudience.Activate();
        }


        UEMS.Master_Lst frmMajorTaskAchieved;
        private void mnuMajorTaskAchieved_Click(object sender, EventArgs e)
        {
            getForm(ref frmMajorTaskAchieved);
            frmMajorTaskAchieved.TableName = "MajorTaskAchieved";
            frmMajorTaskAchieved.Show();
            frmMajorTaskAchieved.Activate();
        }


        UEMS.Master_Lst frmMaster_Specialization;
        private void mnuMaster_Specialization_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Specialization);
            frmMaster_Specialization.TableName = "Master_Specialization";
            frmMaster_Specialization.Show();
            frmMaster_Specialization.Activate();
        }


        UEMS.Master_Lst frmMaster_Position;
        private void mnuMaster_Position_Click_1(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Position);
            frmMaster_Position.TableName = "Master_Position";
            frmMaster_Position.Show();
            frmMaster_Position.Activate();
        }


        UEMS.Master_Lst frmMaster_Sex;
        private void mnuMaster_Sex_Click_1(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Sex);
            frmMaster_Sex.TableName = "Master_Sex";
            frmMaster_Sex.Show();
            frmMaster_Sex.Activate();
        }


        UEMS.Master_Lst frmMaster_Education;
        private void mnuMaster_Education_Click_1(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Education);
            frmMaster_Education.TableName = "Master_Education";
            frmMaster_Education.Show();
            frmMaster_Education.Activate();
        }


        UEMS.Master_Lst frmMaster_MaritalStatus;
        private void mnuMaster_MaritalStatus_Click_1(object sender, EventArgs e)
        {
            getForm(ref frmMaster_MaritalStatus);
            frmMaster_MaritalStatus.TableName = "Master_MaritalStatus";
            frmMaster_MaritalStatus.Show();
            frmMaster_MaritalStatus.Activate();
        }


        UEMS.Master_Lst frmMaster_Ethnicity;
        private void mnuMaster_Ethnicity_Click_1(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Ethnicity);
            frmMaster_Ethnicity.TableName = "Master_Ethnicity";
            frmMaster_Ethnicity.Show();
            frmMaster_Ethnicity.Activate();
        }


        UEMS.Master_Lst frmMaster_Profession;
        private void mnuMaster_Profession_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Profession);
            frmMaster_Profession.TableName = "Master_Profession";
            frmMaster_Profession.Show();
            frmMaster_Profession.Activate();
        }


        UEMS.Master_Lst frmPerson_Role;
        private void mnuPerson_Role_Click(object sender, EventArgs e)
        {
            getForm(ref frmPerson_Role);
            frmPerson_Role.TableName = "Person_Role";
            frmPerson_Role.Show();
            frmPerson_Role.Activate();
        }

        UEMS.HelpingOrganization_Lst frmHelpingOrg;
        private void mnuHelpingOrg_Click(object sender, EventArgs e)
        {
            getForm(ref frmHelpingOrg);

            frmHelpingOrg.Show();
            frmHelpingOrg.Activate();
        }
        UEMS.FinancialSource_Lst frmFinancialSource;
        private void mnuFinancialSource_Click(object sender, EventArgs e)
        {
            getForm(ref frmFinancialSource);

            frmFinancialSource.Show();
            frmFinancialSource.Activate();
        }

        UEMS.NGO_Lst frmNgo;
        private void दरतToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getForm(ref frmNgo);
            frmNgo.Show();
            frmNgo.Activate();
        }
        //UEMS.IndividualPerson_Lst frmpers;
        //private void personToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    getForm(ref frmpers);
        //    frmpers.Show();
        //    frmpers.Activate();
        //}
        #endregion

        private void _closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        UEMS.NGO_Lst frmR;
        private void btnRenew_Click(object sender, EventArgs e)
        {
            getForm(ref frmR);
            frmR.typeOfNgoForm = NGO_Lst.TypeOfNgoForm.ForRenew;
            frmR.FormType = FormTypes.SelectionForm;
            frmR.RemoveToolBar();
            frmR.Show();
            frmR.Activate();
        }

        private void btnYearlyReview_Click(object sender, EventArgs e)
        {
            getForm(ref frmR);
            frmR.typeOfNgoForm = NGO_Lst.TypeOfNgoForm.ForReview ;
            frmR.FormType = FormTypes.SelectionForm;
            frmR.RemoveToolBar();
            frmR.Show();
            frmR.Activate();
        }

        private void tblRegisterReport_Click(object sender, EventArgs e)
        {
            getForm(ref frmR);
            frmR.typeOfNgoForm = NGO_Lst.TypeOfNgoForm.ForDartaReport ;
            frmR.FormType = FormTypes.SelectionForm;
            frmR.RemoveToolBar();
            frmR.Show();
            frmR.Activate();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //to make count a string ||' ' is added
            string talika1 = "select substr(D_Established,1,4) Established ,count(*)||' ' count from ngo group by Established ";
            DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(talika1);
            DataRow dr = dt.Rows .Add  ("आर्थिक बर्ष","गैसस संख्या ");
 
          
        
            //dt.Columns["count"].Caption  = "गैसस संख्या ";
            //dt.Columns["Established"].Caption = "आर्थिक बर्ष";
            frmReporter f = new frmReporter(dt);
            f.ShowDialog();
            string talika2= "select objective_title,count(*) from ngo_objectiveview group by fk_objective";

            string talika3 = @"
select title,count( * ) from workdone  w
left join objective o on o.Id = w.fk_OBJECTIVE 
group by fk_objective ";

            string talika4Male_Female = @"select distinct fk_ngo from NGO_member n
 left join individualperson p on p.id =n.fk_person  
where  fk_gender ='1' and fk_person_role='1'
intersect 
select distinct fk_ngo from NGO_member n
 left join individualperson p on p.id =n.fk_person  
where  fk_gender ='2' and fk_person_role='1' ";

            string talika4Male = @"select distinct fk_ngo from NGO_member n
 left join individualperson p on p.id =n.fk_person  
where  fk_gender ='1'";

            string talika4FeMale = @"select distinct fk_ngo from NGO_member n
 left join individualperson p on p.id =n.fk_person  
where  fk_gender ='2'";
            string talika4FeMaleIncluded =talika4Male_Female+ talika4FeMale;

            string talika4NoEmployee = @" select count(*) WitheEmpd from ngo 
 select count(*) WitheEmp from (select distinct fk_ngo from NGO_member n
 left join individualperson p on p.id =n.fk_person  
where   fk_person_role='3'
 ) ";


        }

     

     

     









    }
}

