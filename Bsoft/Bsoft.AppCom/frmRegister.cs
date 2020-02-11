using Bsoft.Common;
using Bsoft.Forms;
using Bsoft.Languages;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bsoft.AppCom
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmRegister : Bsoft.Design.EntryFromDesignBase
    {
        public bool IsMachine = true;

        public frmRegister()
        {
            InitializeComponent();
            Label4.Text = Language.LanguageString.Register;
            btnCancel.Text = Language.LanguageString.Cancel;
            btnOk.Text = Language.LanguageString.Ok;
            Text = Language.LanguageString.Register;
            btnOk.Font = MainFont;
            btnCancel.Font = MainFont;
            txtRegistrationKey.Font = new Font("Verdana", 10);
        }

        private string reglc = string.Empty;

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConstantValues.RegistrationKey = txtRegistrationKey.Text;
            if (IsMachine)
            {
                if (keys.getRegType(reglc, txtRegistrationKey.Text) != RegType.Unreg)
                {
                    ConstantValues.RegistrationKey = txtRegistrationKey.Text;
                    ConstantValues.BuildDetail = skgen.GetBuildDetail();

                    picIsRegistered.Visible = true;
                    MessageBoxMy.Show("Registered Successfully", MessageBoxButtons.OK);
                    Close();
                }
                else
                {
                    picIsRegistered.Visible = false;
                    txtRegistrationKey.Text = "";
                    MyInputBox msg = new MyInputBox("Registraion key is not Correct \nPlease email or convey following text to the Author.\nEmail : bajrasoft@gmail.com \n", reglc);
                    msg.ShowDialog();
                }
            }
            else
            {
                if ((skgenNoMachine.isKey(ConstantValues.RegistrationKey, reglc)))
                {
                    ConstantValues.RegistrationKey = txtRegistrationKey.Text;
                    ConstantValues.BuildDetail = skgen.GetBuildDetail();
                    picIsRegistered.Visible = true;
                    MessageBoxMy.Show("Registered Successfully", MessageBoxButtons.OK);
                    Close();
                }
                else
                {
                    picIsRegistered.Visible = false;
                    txtRegistrationKey.Text = "";
                    MyInputBox msg = new MyInputBox("Registraion key is not Correct \nPlease email or convey following text to the Author.\n", reglc);
                    msg.ShowDialog();
                }
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            reglc = keys.GetGegLockMachine(ConstantValues.Org_Name, ConstantValues.Org_LocalBody, ConstantValues.ProductName, ConstantValues.ProductVersion);
            try
            {
                txtRegistrationKey.Text = ConstantValues.RegistrationKey;
            }
            catch { }
            if (keys.getRegType(reglc, txtRegistrationKey.Text) != RegType.Unreg)
            {
                picIsRegistered.Visible = true;
            }
            else
            {
                picIsRegistered.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}