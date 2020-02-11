using Bsoft;
using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Data;
using Bsoft.Forms;
using Bsoft.Languages;
using System;
using System.Data;
using System.Windows.Forms;

///It will have the information of
///loginid,UserId,UserName,Pw
///User login will be a dialog box now
///It will not save any thing any where
namespace UEMS.BasicForms.UserLogin
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmNewAuthentication : Bsoft.Design.EntryFromDesignBase
    {
        public frmNewAuthentication()
        {
            InitializeComponent();
            Text = Language.LanguageString.Login;
            cmdOk.Text = Language.LanguageString.Ok;
            cmdExit.Text = Language.LanguageString.CancelGoBack;
            label6.Text = Language.LanguageString.UserName;
            label7.Text = Language.LanguageString.PassWord;
            this.AcceptButton = cmdOk;
            this.CancelButton = cmdExit;
            LoadUserId();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            DataTable dt = null;

            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBoxMy.Show(Language.LanguageString.UserNameCannotbeEmpty, MessageBoxButtons.OK);
                txtUserName.Focus();
            }
            else if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBoxMy.Show(Language.LanguageString.PasswordCannotbeEmpty, MessageBoxButtons.OK);
                txtUserName.Focus();
            }

            else if (IsUserName(ref dt) && IsPw(dt))
            {
                NewMethod();
                ConstantValues.LastLoginDate = DateTime.Now.ToString("yyyyMMdd");
                UpdateLoginDate();
                DialogResult = DialogResult.OK;
            }
        }

        private void NewMethod()
        {
            string message = "";
            bool b = keys.stopApplication(GlobalValues.Limits, keys.GetGegLockMachine(ConstantValues.Org_Name, ConstantValues.Org_LocalBody, ConstantValues.ProductName, ConstantValues.ProductVersion), ConstantValues.RegistrationKey, ref message);
            if (message.Length > 0)
            {
                MessageBoxMy.Show(message, "Alert");
            }
            if (b)
            {
                frmAboutBox abt = new frmAboutBox(false);
                abt.ShowDialog();
                Visible = false;
                Close();
                Application.Exit();
                Dispose();
            }
        }

        private bool IsPw(DataTable dt)
        {
            Bsoft.Common.clsEncryptorDecryptor enc = new Bsoft.Common.clsEncryptorDecryptor();
            String Upassword = string.Empty;
            Upassword = dt.Rows[0]["pw"].ToString();
            if (Upassword != string.Empty) //Checking Blank Password..
            {
                Upassword = enc.Decrypt(Upassword.Trim()); //Encrypted Password to Decrypte
                if (Upassword == txtPassword.Text) //Checking Upwd and db Upwd
                {
                    GlobalValues.LoginUserIDPk = dt.Rows[0]["ID"].ToString();
                    GlobalValues.UserFullNepName = dt.Rows[0]["NEPNAME"].ToString();
                    GlobalValues.UserFullEngName = dt.Rows[0]["ENGNAME"].ToString();
                    GlobalValues.LoginUserName = dt.Rows[0]["UserId"].ToString();
                    password = dt.Rows[0]["pw"].ToString();
                    return true;
                }
                else
                {
                    //Invalid Password.
                    MessageBoxMy.Show(Language.LanguageString.InvalidPassword, MessageBoxButtons.OK);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return false;
                }
            }
            return false;
        }

        private void UpdateLoginDate()
        {
            string sql = "";
            sql = @"UPDATE SuperAdmin_Rights_Users set LASTLOGGEDOUT = '{0}'
                        Where UserId ='{1}'".With(DateTime.Now.ToString("yyyyMMdd"), txtUserName.Text.ToLower());

            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql.ToString());
            sql = @"UPDATE SuperAdmin_Rights_Users set LASTLOGGEDON = '{0}'
                        Where UserId ='{1}'".With(DateTime.Now.ToString("yyyyMMdd"), txtUserName.Text.ToLower());

            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql.ToString());
        }

        private bool IsUserName(ref DataTable dt)
        {
            string sql = @"SELECT
	DISTINCT *
FROM
	SuperAdmin_Rights_Users
WHERE
	 UserId ='{0}'".With(txtUserName.Text.Trim());

            dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sql.ToString());
            if (dt.Rows.Count < 1)
            {
                //Message Display Invalid User name
                txtUserName.Focus();
                txtUserName.SelectAll();
                MessageBoxMy.Show(Language.LanguageString.InvalidUserName, MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        public string password = string.Empty;

        public void LoadUserId()
        {
            try
            {
                txtUserName.Text = Bsoft.AppCom.Properties.Settings.Default.LastLoginBy;
            }
            catch { }
        }

        public void SaveUserId()
        {
            try
            {
                Bsoft.AppCom.Properties.Settings.Default.LastLoginBy = txtUserName.Text;
                Bsoft.AppCom.Properties.Settings.Default.Save();
            }
            catch { }
        }

        private void frmNewAuthentication_Load(object sender, EventArgs e)
        {
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}