using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UEMS;
using Bsoft.Languages ;
using Bsoft.Common;
using Friuts;
using UEMS.BLL;
using Bsoft.Forms;
using Bsoft.AppCom;
using Bsoft.Data;
using Bsoft.AppCom.UserMgtSimple;
namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class MainForm : Bsoft.AppCom.MainFormCom 
    {
        public string companyname = string.Empty;
        public string UserID;
        public const bool UseMenuRights = false;
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginOrChangeUser();
            LoadOrganaizationDetails();
        }

        #region General Requirement in all

        public MainForm()
        {
            InitializeComponent();
            //lblUserName.Text = Language.LanguageString .User;
            mnuMasterEntry.Text = Language.LanguageString .MasterEntry;
            MnuRestore.Text = Language.LanguageString .Restore;
            MnuBackup.Text = Language.LanguageString .Backup;
            MnuChangeUserLoging.Text = Language.LanguageString .LogOff;
            MnuExit.Text = Language.LanguageString .Close;
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

             
            //DialogResult result = MessageBoxMy.Show(this,Bsoft.Common.Language.LanguageString .Messages.DoYouWantToLogOff,Bsoft.Common.Language.LanguageString .Language.LanguageString  .AttentionPlease , MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //     this.Hide();
            //    UEMS.Forms.UserLogin.frmAuthentication frm = new UEMS.Forms.UserLogin.frmAuthentication(true );
            //    frm.AcceptButton = frm.cmdOk;
            //    frm.ShowDialog(this);
            //     this.Dispose();
            //}
        }

        //private void MnuBackup_Click(object sender, EventArgs e)
        //{
        //    BrowseAndBackupDataBase();
        //}
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
               // return "";

            }
            MessageBox.Show("पुरानो तथ्याँक संचयन भयो ।");
            return "";
        }
        private void mnuChangeableDetails_Click(object sender, EventArgs e)
        {

            MasterEntry.frmCompany frm = new MasterEntry.frmCompany();
            frm.ShowDialog();
            LoadOrganaizationDetails();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxMy.Show(Language.LanguageString .DoYouWantToClose, MessageBoxButtons.YesNo);
             if (result == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void MnuRightsAssign_Click(object sender, EventArgs e)
        {
            //UEMS.MasterEntry.frmUserListing frm = new UEMS.MasterEntry.frmUserListing();
            //frm.ShowDialog();
            Rights_Users_Lst frm = new Rights_Users_Lst();
            frm.ShowDialog();
        }
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox abt = new frmAboutBox(false);
            abt.ShowDialog();
        }
        #endregion

        
        #region "Menu Rigts Functions"
       

        private void setRights()
        {
            string grp;
            grp = GlobalValues.LoginUserID;
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
                DataTable dtMenu = GlobalResources.SelectDBConnection.ExecuteDataTable(sql.ToString());

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
                if (GlobalValues.LoginUserName.ToUpper() != "ADMIN")
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


      

    

       
    }
}

