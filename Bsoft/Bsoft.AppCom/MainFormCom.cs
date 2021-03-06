using Bsoft.Date;
using Bsoft.Languages;
using System;
using System.Windows.Forms;
using UEMS.MasterEntry;

namespace Bsoft.AppCom
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class MainFormCom : Bsoft.Design.MainFormDesginBase
    {
        #region General Requirement in all

        public string companyname = string.Empty;
        public string UserID;
        public const bool UseMenuRights = false;

        public MainFormCom()
        {
            InitializeComponent();

            txtlFiscalYear.Font = Bsoft.Design.EntryFromDesignBase.DigitFont;
            txtstatusDateTodaysText.Font = Bsoft.Design.EntryFromDesignBase.DigitFont;
            txtStatusBarUserName.Font = Bsoft.Design.EntryFromDesignBase.MainFont;

            lblFiscYear.Font = Bsoft.Design.EntryFromDesignBase.MainFont;
            lblDate.Font = Bsoft.Design.EntryFromDesignBase.MainFont;
            lblStatusBarUserName.Font = Bsoft.Design.EntryFromDesignBase.MainFont;

            lblStatusBarUserName.Text = Language.LanguageString.UserId + " : ";
            lblDate.Text = Language.LanguageString.Date + " : ";
            lblFiscYear.Text = Language.LanguageString.FiscalYear + " : ";
        }

        #region "General Events"

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                return;
            }
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }

        protected void MnuChangePassword_Click(object sender, EventArgs e)
        {
            UEMS.Forms.UserLogin.frmChangePassword cp = new UEMS.Forms.UserLogin.frmChangePassword();
            cp.ShowDialog();
        }

        protected void MnuChangeUserLoging_Click(object sender, EventArgs e)
        {
            if (!LoginOrChangeUser())
            {
                Application.Exit();
            }
        }

        private string BrowseAndBackupDataBase()
        {
            string dBpATH;

            dBpATH = GlobalValues.DbPath;

            try
            {
                dBpATH = dBpATH + "\\thaili";
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

        protected void MnuRestore_Click(object sender, EventArgs e)
        {
            RestoreDataBase();
        }

        private string RestoreDataBase()
        {
            //if (MsgBoxNepali.Show("पुरानो तथ्याँक संचयन गर्ने हो ?", MessageBoxButtons.YesNoCancel) == DialogResult.OK)
            //{
            //    BrowseAndBackupDataBase();
            //}
            //else
            //{
            //    return "";
            //}

            string dBpATH;
            dBpATH = GlobalValues.DbPath;
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
        }

        protected void mnuChangeableDetails_Click(object sender, EventArgs e)
        {
            frmCompany frm = new frmCompany();
            frm.ShowDialog();
            LoadOrganaizationDetails();
        }

        protected void MnuExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        protected void MnuRightsAssign_Click(object sender, EventArgs e)
        {
            Bsoft.AppCom.UserMgtWithRole.frmUserListing frm = new Bsoft.AppCom.UserMgtWithRole.frmUserListing();
            frm.ShowDialog();
        }

        protected void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAboutBox abt = new frmAboutBox(false);
            //abt.ShowDialog();
        }

        #endregion "General Events"

        protected void LoadOrganaizationDetails()
        {
            lblOrgName.Text = ConstantValues.Org_Name;
            lblLocalBody.Text = ConstantValues.Org_Name;
            lblDistrict.Text = ConstantValues.Org_District;
            txtlFiscalYear.Text = ConstantValues.CurrentFiscalYearValue;
        }

        public virtual bool LoginOrChangeUser()
        {
            this.Visible = false;
            UEMS.BasicForms.UserLogin.frmNewAuthentication f = new UEMS.BasicForms.UserLogin.frmNewAuthentication();
            if (f.ShowDialog() != DialogResult.OK)
            {
                //this.Visible = true;
                return false;
            }
            else
            {
                // f.ChangeGloblaResources();
                f.SaveUserId();

                if (LanguageChoice.Nepali == Language.currentLanguage)
                {
                    txtStatusBarUserName.Text = GlobalValues.UserFullNepName;
                }
                else
                {
                    txtStatusBarUserName.Text = GlobalValues.UserFullEngName;
                }

                txtstatusDateTodaysText.Text = "BS: " + NepaliDate.Today.ToString("yyyy/MM/Dd");
                txtstatusDateTodaysText.Text = txtstatusDateTodaysText.Text + "   AD: " + DateTime.Now.ToString("yyyy/MM/dd");
                if (f.password == "3mlJcyGH6312vDYaUbAe+A==")
                {
                    UEMS.Forms.UserLogin.frmChangePassword cp = new UEMS.Forms.UserLogin.frmChangePassword();
                    cp.ShowDialog();
                }
                this.Visible = true;
                return true;
                //  StatusBarUserName.Text += GlobalResources.OrganisationDetail.CompanyName;
            }
        }

        #endregion General Requirement in all
    }
}