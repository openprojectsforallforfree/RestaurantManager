using Bsoft;
using Bsoft.AppCom;
using Bsoft.AppCom.BasicForms;
using Bsoft.AppCom.UserMgtWithRole;
using Bsoft.Common;
using Bsoft.Forms;
using Bsoft.Languages;
using RestoSys.Inventory;
using RestoSys.Reports;
using System;
using System.Windows.Forms;
using UEMS;
using UEMS.Forms;
using UEMS.MasterEntry;

namespace RestoSys
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class MainForm_Department : Bsoft.AppCom.MainFormCom
    {
        

        public MainForm_Department()
        {
            InitializeComponent();
            LblTitle.Visible = false;
            ConstantValues.ProductName = "DMS";

            this.mnuChangePassWord.Click += new System.EventHandler(this.MnuChangePassword_Click);
            this.mnuChangeLogin.Click += new System.EventHandler(this.MnuChangeUserLoging_Click);
            this.mnuRestore.Click += new System.EventHandler(this.MnuRestore_Click);
            mnuBackUpDataBase.Text = Language.LanguageString.Backup;
            mnuChangeLogin.Text = Language.LanguageString.LogOff;
            mnuExit.Text = Language.LanguageString.Close;
            LoadOrganaizationDetails();
            Text = "Department Store Billing System";
            ingredientUsedToolStripMenuItem.Visible = false;
        }

        private void MainForm_Department_Load(object sender, EventArgs e)
        {
#if DEBUG
            GlobalValues.LoginUserIDPk = "1";
            GlobalValues.LoginUserName = "Admin";
#else
            if (!LoginOrChangeUser())
                {
                    Application.Exit();
                }
#endif

            Invoice.CompanyName = ConstantValues.Org_Name;
            Invoice.PanNo = ConstantValues.PANNo;
            Invoice.VatNo = ConstantValues.VATNo;
            Invoice.Address = ConstantValues.Org_Tole + "," + ConstantValues.Org_District;
        }

        public override bool LoginOrChangeUser()
        {
            if (base.LoginOrChangeUser())
            {
                UserRights.setRights(mnuStripMy);
                return true;
            }
            return false;
        }

        #region Menu Click Events

        #region Basic

        private void mnuExit_Click(object sender, EventArgs e)
        {
            _closeButton_Click(sender, e);
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxMy.Show(Language.LanguageString.DoYouWantToClose, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuSetting_Click(object sender, EventArgs e)
        {
            RestoSys.RestaurantBilling.frmApplicationSetting frm = new RestoSys.RestaurantBilling.frmApplicationSetting();
            frm.ShowDialog();
        }

        private void mnuAbout_Click_1(object sender, EventArgs e)
        {
            frmAboutBox abt = new frmAboutBox(false);
            abt.ShowDialog();
        }

        private void mnuBackUpDataBase_Click(object sender, EventArgs e)
        {
            frmBackup.BackupSQLITE(GlobalValues.DbPath, ApplicationSetting.BackUpFolder);
        }

        private void mnuOrgDetails_Click(object sender, EventArgs e)
        {
            frmCompanyOption2 frm = new frmCompanyOption2();
            frm.btnSearch.Visible = false;
            frm.ShowDialog();
            LoadOrganaizationDetails();
        }

        private void mnuUserManagement_Click(object sender, EventArgs e)
        {
            frmUserListing frm = new frmUserListing();
            frm.ShowDialog();
        }

        private void MnuUserRoleAssignment_Click(object sender, EventArgs e)
        {
            frmMnuRights frm = new frmMnuRights(mnuStripMy);
            frm.ShowDialog();
        }

        #endregion Basic

        #region Others

        private void mnuMaster_CustomerType_Click(object sender, EventArgs e)
        {
            UEMS.CustomerType_Lst frm = new UEMS.CustomerType_Lst();
            frm.ShowDialog();
        }

        private void tagTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UEMS.TagType_Lst tl = new UEMS.TagType_Lst();
            tl.ShowDialog();
        }

        private void tagGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UEMS.TagGroup_Lst tl = new UEMS.TagGroup_Lst();
            tl.ShowDialog();
        }

        private void tagItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UEMS.Tag_Lst tl = new UEMS.Tag_Lst();
            tl.ShowDialog();
        }

        private void mnuSatisfiedClients_Click(object sender, EventArgs e)
        {
        }

        private void mnuUnitDetails_Click(object sender, EventArgs e)
        {
            UEMS.frmUnit_MasterList frm = new UEMS.frmUnit_MasterList();
            frm.ShowDialog();
        }

        #endregion Others

        #region For Master Entry

        private void mnuTableDetails_Click(object sender, EventArgs e)
        {
            UEMS.OrderTables_Lst frm = new UEMS.OrderTables_Lst();
            frm.ShowDialog();
        }

        private void enterCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoSys.MasterEntry.frmProductCompanyList frm = new RestoSys.MasterEntry.frmProductCompanyList();
            frm.ShowDialog();
        }

        private void enterVendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoSys.MasterEntry.frmProductVendorList frm = new RestoSys.MasterEntry.frmProductVendorList();
            frm.ShowDialog();
        }

        private void enterEditProductGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoSys.MasterEntry.frmProductGroupList frm = new RestoSys.MasterEntry.frmProductGroupList();
            frm.ShowDialog();
        }

        private void enterEditCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoSys.Forms.frmCustomerList frm = new RestoSys.Forms.frmCustomerList();
            frm.ShowDialog();
        }

        #endregion For Master Entry

        #region Transactions

        private void mnuProductDetail_Click(object sender, EventArgs e)
        {
            RestoSys.MasterEntry.frmProductList frm = new RestoSys.MasterEntry.frmProductList();
            frm.ShowDialog();
        }

        private void mnuPurchase_Click(object sender, EventArgs e)
        {
            RestoSys.Inventory.frmPurchageList frm = new RestoSys.Inventory.frmPurchageList();
            frm.ShowDialog();
        }

        private void creditManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoSys.Forms.frmCreditManagementList frm = new RestoSys.Forms.frmCreditManagementList();
            frm.ShowDialog(this);
        }

        private void mnuSales_Click(object sender, EventArgs e)
        {
            RestoSys.Inventory.frmSalesCart frm = new RestoSys.Inventory.frmSalesCart();
            frm.ShowInTaskbar = true;
            frm.Show();
        }

        #endregion Transactions

        #region Reports

        private void mnuShowReport_Click(object sender, EventArgs e)
        {
            RestoSys.Reports.frmPurchaseReport frm = new RestoSys.Reports.frmPurchaseReport();
            frm.ShowDialog(this);
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoSys.Reports.frmSalesReport frm = new RestoSys.Reports.frmSalesReport();
            frm.ShowDialog(this);
        }

        private void mnuProductsReport_Click(object sender, EventArgs e)
        {
            RestoSys.Reports.frmStockrpt ss = new RestoSys.Reports.frmStockrpt();
            ss.ShowDialog();
        }

        #endregion Reports

        #region Stock Reports

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockModfReport frm = new frmStockModfReport(StockType.PurchaseReturn);
            frm.Text = "Purchase Retrun";
            frm.ShowDialog();
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockModfReport frm = new frmStockModfReport(StockType.SalesReturn);
            frm.Text = "Sales Retrun";
            frm.ShowDialog();
        }

        private void damagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockModfReport frm = new frmStockModfReport(StockType.Damaged);
            frm.Text = "Damaged Entry List";
            frm.ShowDialog();
        }

        private void lostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockModfReport frm = new frmStockModfReport(StockType.Lost);
            frm.Text = "Lost Items List";
            frm.ShowDialog();
        }

        private void ingredientUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockModfReport frm = new frmStockModfReport(StockType.IngredientConsumed);
            frm.Text = "Ingredient Consumtion List";
            frm.ShowDialog();
        }

        private void itemProducedManufacturedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockModfReport frm = new frmStockModfReport(StockType.StockEntry);
            frm.Text = "Production entry List";
            frm.ShowDialog();
        }

        #endregion Stock Reports

        private void mnuExpiryDetails_Click(object sender, EventArgs e)
        {
            RestoSys.Reports.frmExpiryDetails f = new frmExpiryDetails();
            f.ShowDialog();
        }

        private void mnuTransactionReport_Click(object sender, EventArgs e)
        {
            RestoSys.Reports.TransactionReport ss = new RestoSys.Reports.TransactionReport();
            ss.ShowDialog();
        }

        private void mnuCashSum_Click(object sender, EventArgs e)
        {
            Bsoft.Forms.frmMoneyCounter m = new frmMoneyCounter();
            m.Show();
        }

        #region Hotel

        private void mnuBooking_Click(object sender, EventArgs e)
        {
            RestoSys.Inventory.frmHotelBill rb = new frmHotelBill();
            rb.WindowState = FormWindowState.Maximized;
            rb.ShowDialog();
        }

        private void mnuRoom_Click(object sender, EventArgs e)
        {
            UEMS.Room_Lst frm = new UEMS.Room_Lst();
            frm.ShowDialog();
        }

        private RoomBookingView_Lst hbr = new RoomBookingView_Lst();

        private void mnuBookingReport_Click(object sender, EventArgs e)
        {
            FormUtility.ShowForm<RoomBookingView_Lst>(this, ref   hbr);
        }

        private void mnuRoomStatus_Click(object sender, EventArgs e)
        {
            Hotel_Boking_Gantt hbg = new Hotel_Boking_Gantt();
            hbg.Show();
        }

        private Hotel_AccountBooking_Lst hgb = new Hotel_AccountBooking_Lst();

        private void mnuDayBook_Click(object sender, EventArgs e)
        {
            FormUtility.ShowForm<Hotel_AccountBooking_Lst>(this, ref    hgb);
        }

        private hotel_sales_View_Lst hsl = new hotel_sales_View_Lst();

        private void mnuHotelSales_Click(object sender, EventArgs e)
        {
            FormUtility.ShowForm<hotel_sales_View_Lst>(this, ref    hsl);
        }

        #endregion Hotel

        private void mnuRoomTypes_Click(object sender, EventArgs e)
        {
            UEMS.Hotel_RoomType_Lst frm = new UEMS.Hotel_RoomType_Lst();
            frm.ShowDialog();
        }

        #endregion Menu Click Events
    }
}