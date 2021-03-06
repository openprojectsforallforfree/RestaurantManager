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
namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class MainForm : Friuts.FormBase
    {
        #region General Requirement in all
        public string companyname = string.Empty;
        public string UserID;
        public const bool UseMenuRights = false;
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginOrChangeUser();
            LoadOrganaizationDetails();
        }

        public MainForm()
        {
            InitializeComponent();
            //lblUserName.Text = Language.User;
            mnuMasterEntry.Text = Language.MasterEntry;
            MnuRestore.Text = Language.Restore;
            MnuBackup.Text = Language.Backup;
            MnuChangeUserLoging.Text = Language.LogOff;
            MnuExit.Text = Language.Close;
        }


        #region Generic funtions
        //    http://innovatetech.blogspot.com/2008/01/handling-net-toolstrip-merge-and.html
        /// <summary>
        /// way to get the form if not instantiated gets new 
        /// If instattiaged returns old.
        /// </summary>
        /// <author>Dhiraj's </author>
        /// <typeparam name="T"></typeparam>
        /// <param name="frm"></param>
        /// <returns></returns>
        void getForm<T>(ref T frm) where T : Form, new()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new T();
                frm.Owner = this;
                //frm.MdiParent = this;//for mdi child way
            }

        }
        //still better
        void showForm<T>(ref T frm) where T : Form, new()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new T();
                frm.Owner = this;
                //frm.MdiParent = this;//for mdi child way
            }
            frm.Show();
            frm.Activate();
        }

        //to merge toolstrip
        //protected override void OnMdiChildActivate(EventArgs e)
        //{
        //    base.OnMdiChildActivate(e); //REQUIRED
        //    HandleChildMerge(); //Handle merging
        //}
        //private void HandleChildMerge()
        //{
        //    ToolStripManager.RevertMerge(tsMain);
        //    IChildForm ChildForm = ActiveMdiChild as IChildForm;
        //    if (ChildForm != null && ChildForm.ChildToolStrip != null)
        //    {
        //        ToolStripManager.Merge(ChildForm.ChildToolStrip, tsMain);
        //    }
        //}
        #endregion

        #region "General Events"

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                return;
            }
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }

        private void MnuChangePassword_Click(object sender, EventArgs e)
        {
            UEMS.Forms.UserLogin.frmChangePassword cp = new UEMS.Forms.UserLogin.frmChangePassword();
            cp.ShowDialog();
        }
        private void MnuChangeUserLoging_Click(object sender, EventArgs e)
        {

            LoginOrChangeUser();
            //DialogResult result = MessageBoxMy.Show(this,Bsoft.Common.Language.Messages.DoYouWantToLogOff,Bsoft.Common.Language.Language .AttentionPlease , MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //     this.Hide();
            //    UEMS.Forms.UserLogin.frmAuthentication frm = new UEMS.Forms.UserLogin.frmAuthentication(true );
            //    frm.AcceptButton = frm.cmdOk;
            //    frm.ShowDialog(this);
            //     this.Dispose();
            //}
        }

        private void MnuBackup_Click(object sender, EventArgs e)
        {
            BrowseAndBackupDataBase();
        }
        private string BrowseAndBackupDataBase()
        {

            string dBpATH;

            dBpATH = UEMS.Properties.Settings.Default.DataPath;

            try
            {
                dBpATH = UEMS.Properties.Settings.Default.DataPath + "\\thaili";
                SaveFileDialog save = new SaveFileDialog();

                if (save.ShowDialog(this) == DialogResult.OK)
                {
                    System.IO.File.Copy(dBpATH, save.FileName + "");
                }
                return "";
            }
            catch (Exception e)
            {
                ///throw new ApplicationException("Failed loading image");
                MessageBox.Show(e.Message);
                return "";
            }
        }
        private void MnuRestore_Click(object sender, EventArgs e)
        {
            RestoreDataBase();
        }
        private string RestoreDataBase()
        {


            //if (CrudeFx.MsgBoxNepali.Show("पुरानो तथ्याँक संचयन गर्ने हो ?", MessageBoxButtons.YesNoCancel) == DialogResult.OK)
            //{
            //    BrowseAndBackupDataBase();
            //}
            //else  
            //{

            //    return "";
            //}


            string dBpATH;
            dBpATH = UEMS.Properties.Settings.Default.DataPath;
            try
            {
                System.IO.File.Copy(dBpATH + "\\thaili", dBpATH + "\\Prerestore" + DateTime.Today.ToShortTimeString().ToString() + "");
            }
            catch { }
            try
            {

                //if (!System.IO.File.Exists(dBpATH))
                //{
                //    MessageBox.Show("फाइल हाल्ने ठाउँ मिलेन ।");
                //    return "";
                //}

                OpenFileDialog open = new OpenFileDialog();

                if (open.ShowDialog(this) == DialogResult.OK)
                {
                    System.IO.File.Copy(open.FileName, dBpATH + "\\thaili", true);
                }
                return "";
            }

            catch
            {

                MessageBox.Show("पुरानो तथ्याँक संचयन भएन ।");
                ///throw new ApplicationException("Failed loading image");
                //   MessageBox.Show(e.Message);
                return "";

            }
            MessageBox.Show("पुरानो तथ्याँक संचयन भयो ।");
        }
        private void mnuChangeableDetails_Click(object sender, EventArgs e)
        {

            MasterEntry.frmCompany frm = new MasterEntry.frmCompany();
            frm.ShowDialog();
            LoadOrganaizationDetails();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
           // DialogResult result = MessageBoxMy.Show(Language.DoYouWantToClose, MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
                System.Windows.Forms.Application.Exit();
            //}
        }

        private void MnuRightsAssign_Click(object sender, EventArgs e)
        {
            //UEMS.MasterEntry.frmUserListing frm = new UEMS.MasterEntry.frmUserListing();
            //frm.ShowDialog();
            UEMS.Rights_Users_Lst frm = new UEMS.Rights_Users_Lst();
            frm.ShowDialog();
        }
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox abt = new frmAboutBox(false);
            abt.ShowDialog();
        }
        #endregion

        private void LoadOrganaizationDetails()
        {
            lblOrgName.Text   = ConstantValues.Org_Name;
            lblLocalBody.Text = ConstantValues.Org_Name  ;
            lblDistrict.Text = ConstantValues.Org_District;
            lblFiscalYear.Text = OrganizationDetail.CurrentFiscalYear.ToString();
            if (ConstantValues.Org_Name !=UEMS.BasicForms.Messages .TestCompany  )
            {
                this.Visible = false;
                UEMS.BasicForms.frmRegister frmreg = new UEMS.BasicForms.frmRegister();
                if (frmreg.ShowDialog( ) != DialogResult.OK)
                {
                    Application.Exit();
                }
                this.Visible = true;
            }
            
        }
        #region "Menu Rigts Functions"
        private void LoginOrChangeUser()
        {
            this.Visible = false;
            UEMS.BasicForms.UserLogin.frmNewAuthentication f = new UEMS.BasicForms.UserLogin.frmNewAuthentication();
            if (f.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                f.ChangeGloblaResources();
                f.SaveUserId();
                StatusBarUserName.Text = BLL.GlobalResources.UserFullName.ToString();
                fiscYearText.Text = OrganizationDetail.CurrentFiscalYear.ToString();
                statusDateTodaysText.Text = CrudeFx.NepaliDate.NepaliDate.Today.ToString(CrudeFx.NepaliDate.DateFormatTypes.yyyyMMdd);
                if (f.password == "3mlJcyGH6312vDYaUbAe+A==")
                {
                    UEMS.Forms.UserLogin.frmChangePassword cp = new UEMS.Forms.UserLogin.frmChangePassword();
                    cp.ShowDialog();
                }
                this.Visible = true;
                setRights();
                //  StatusBarUserName.Text += BLL.GlobalResources.OrganisationDetail.CompanyName;
            }
        }

        private void setRights()
        {
            string grp;
            grp = BLL.GlobalResources.LoginUserID;
            if (grp == "")
            {
                MessageBoxMy.Show("Your roles are not assigend .Please Contact the administrator.", MessageBoxButtons.OK);
                Application.Exit();
            }
            setRights(grp);
        }
        private void setRights(string grp)
        {
            try
            {
                string sql = string.Format(
                    @"select  rm.Name,rm.TEXT,rmu.giveright
 from Rights_Menu rm 
 left join Rights_Menu_Users rmu
 on rmu.fk_Rights_Menu =rm.id where rmu.fk_Rights_Users ={0}", grp
                    );
                DataRow drMenu;
                DataTable dtMenu = BLL.GlobalResources.SelectDBConnection.ExecuteDataTable(sql.ToString());

                DataColumn[] dcPrimary = { dtMenu.Columns["name"] };
                dtMenu.PrimaryKey = dcPrimary;//For find function to work

                foreach (System.Windows.Forms.ToolStripMenuItem mainmenu in menuStrip1.Items)
                {

                    drMenu = dtMenu.Rows.Find(mainmenu.Name);
                    setRight(mainmenu, drMenu);

                    foreach (System.Windows.Forms.ToolStripItem submenu in mainmenu.DropDownItems)
                    {
                        drMenu = dtMenu.Rows.Find(submenu.Name);
                        setRight(submenu, drMenu);
                    }
                }
                if (BLL.GlobalResources.LoginUserName.ToUpper() != "ADMIN")
                {
                    //mnuTables.Visible = false;
                }
            }
            catch { }
        }
        private void setRight(System.Windows.Forms.ToolStripItem mnuItem, DataRow drMenu)
        {
            if (mnuItem is ToolStripMenuItem)
            {
                //Dont set the disabled menus these are application wise
                if (mnuItem.Enabled == false)
                {
                    return;
                }
                string right = Conversion.ToString(drMenu, "giveright");
                if (right == "1")
                {
                    mnuItem.Visible = true;
                }
                else
                {
                    mnuItem.Visible = false;
                }
            }
        }
        #endregion

        #endregion


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
        UEMS.IndividualPerson_Lst frmpers;
        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getForm(ref frmpers);
            frmpers.Show();
            frmpers.Activate();
        }
        #endregion
       

    

       
    }
}

