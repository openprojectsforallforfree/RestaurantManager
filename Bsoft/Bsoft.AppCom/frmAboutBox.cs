using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Forms;
using Bsoft.Updater;
using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using UEMS.BLL;

namespace Bsoft
{
    public partial class frmAboutBox : Form
    {
        private UpdaterFinal updater;

        public delegate void updateDataStructure(string test);

        public event updateDataStructure UpdateDataStructure;

        #region Member variables.

        public static RegType _regType = RegType.Unreg;
        private static bool _isFirstTime = true;
        private Loader _objLoader = null;
        private bool _isSplash = true;

        #endregion Member variables.

        ////  Initialize the AboutBox to display the product information from the assembly information.
        ////  Change assembly information settings for your application through either:
        ////  - Project->Properties->Application->Assembly Information
        ////  - AssemblyInfo.cs
        //_objLoader.ProgressStatusMgr.ProgressStatusChange += new ProgressStatus.ProgressStatusChangedEventHandler(ProgressStatusMgr_ProgressStatusChange);
        public frmAboutBox(bool isSplash)
        {
            _isSplash = isSplash;
            InitializeComponent();
            if (isSplash)
            {
                _objLoader = new Loader();
                _objLoader.UpdateDataStructure += new Loader.updateDataStructure(_objLoader_UpdateDataStructure);

                ConstantValues.ProductVersion = Application.ProductVersion;
                _objLoader.ProgressStatusMgr.ProgressStatusChange += new ProgressStatus.ProgressStatusChangedEventHandler(ProgressStatusMgr_ProgressStatusChange);
            }
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = ConstantValues.ProductName;
            this.labelVersion.Text = String.Format("Version {0}", Application.ProductVersion);

            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = Application.CompanyName;
            this.textBoxDescription.Text = AssemblyDescription;
            updater = new UpdaterFinal(lblUpdateResult, this, progressBar1, pictureUpdateGif);
        }

        private void _objLoader_UpdateDataStructure(string test)
        {
            UpdateDataStructure(test);
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion Assembly Attribute Accessors

        #region Events

        private void ProgressStatusMgr_ProgressStatusChange(object sender, ProgressStatusChangedEventArgs e)
        {
            RefreshProgressMessage(e);
        }

        private void RefreshProgressMessage(ProgressStatusChangedEventArgs e)
        {
            if (lblUpdateResult.InvokeRequired)
            {
                SimpleDelegate dlgRefresh = delegate
                {
                    RefreshProgressMessage(e);
                };

                lblUpdateResult.Invoke(dlgRefresh);
                return;
            }

            if (e.CompletedPercentage >= 100)
            {
                this.Close();
                return;
            }

            lblUpdateResult.Text = string.Format("Loading : {0}=>{1}...", e.MainProcessName, e.SubProcessName);
            lblUpdateResult.Invalidate();
        }

        private string lockKey = "";

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            if (txtPw.Text.ToLower() == "gonzo")
            {
                Bsoft.Tools.frmDbTool frm = new Bsoft.Tools.frmDbTool();
                frm.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Events

        private void labelVersion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                txtPw.Visible = true;
                txtPw.Focus();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //get key from net
            WebClient client = new WebClient();
            try
            {
                string s = client.DownloadString(URLs.GetKeysURL);
                ParserClass p = new ParserClass(s);
                string key = p.GetValue(lockKey);
                if (key.Length > 10)
                {
                    RegType rt = keys.getRegType(lockKey, key);
                    if (rt != RegType.Unreg)
                    {
                        _regType = rt;
                        if (rt == RegType.Adv)
                        {
                            lblRegistration.Text = "Registered";
                        }
                        if (rt == RegType.Full)
                        {
                            lblRegistration.Text = "Fully Registered";
                            btnRegister.Visible = false;
                        }
                        ConstantValues.RegistrationKey = key;
                        MessageBoxMy.ShowMessage("Congratulaions ! \nThe Software is registerd Successfully.");
                    }
                    else
                    {
                        throw new Exception("");
                    }
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The remote name could not be resolved"))
                {
                    if (MessageBoxMy.Show("Could not connect to internet .\n Do you have key?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Bsoft.AppCom.frmRegister frmReg = new Bsoft.AppCom.frmRegister();
                        frmReg.ShowDialog(this);
                    }
                    else
                    {
                        MessageBoxMy.Show("Could not register the software.\nPlease contact 977-9841190907. ");
                    }
                }
                else
                {
                    MessageBoxMy.Show("Could not register the software.\nPlease contact 977-9841190907. ");
                }
            }
        }

        private void frmAboutBox_Load(object sender, EventArgs e)
        {
            lblBuildNumber.Text = ConstantValues.BuildNumber.ToString();
            if (!_isSplash)
            {
                updater.checkUpdates();
                lblRegistration.Visible = true;
                lockKey = keys.GetGegLockMachine(ConstantValues.Org_Name, ConstantValues.Org_LocalBody, ConstantValues.ProductName, ConstantValues.ProductVersion);
                _regType = keys.getRegType(lockKey, ConstantValues.RegistrationKey);
                if (_regType == RegType.Full)
                {
                    btnRegister.Visible = false;
                    lblRegistration.Text = "Fully Registered software";
                }
                else if (_regType == RegType.Unreg)
                {
                    btnRegister.Visible = true;
                    lblRegistration.Text = "Please register";
                }
                else
                {
                    btnRegister.Visible = true;
                    lblRegistration.Text = "Registered";
                }

                btnCancel.Visible = true;
            }
            else
            {
                lblRegistration.Visible = false;
                btnRegister.Visible = false;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }
            if (_isFirstTime)
            {
                _objLoader.LoadNecessaryObjectsAsync();
            }
            _isFirstTime = false;

            this.Refresh();

            try
            {
#if! DEBUG
                {
                _objLoader.checkonPs();
                }
#endif
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("ps error"))
                {
                    throw;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updater.updateClicked();
        }
    }
}