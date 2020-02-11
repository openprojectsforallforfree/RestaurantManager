using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Common.Utilities;
using Bsoft.Design;
using Bsoft.Forms;
using Friuts;
using RestoSys.Account;
using RestoSys.BLL;
using RestoSys.DAl;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UEMS;

namespace RestoSys.Inventory
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmHotelBill : Bsoft.Design.EntryFromDesignBase
    {
        //private DataGridViewCellStyle dueRemaining = new DataGridViewCellStyle();
        private DataGridViewCellStyle dueRefundable = new DataGridViewCellStyle();

        private DataGridViewCellStyle dueCleared = new DataGridViewCellStyle();

        public frmHotelBill()
        {
            InitializeComponent();
            dueRefundable.BackColor = Color.Maroon;
            dueRefundable.ForeColor = Color.White;

            dueCleared.BackColor = Color.Green;
            dueCleared.ForeColor = Color.White;
            new ListingFromDesignBase().SetDataGridViewProperties(customerGrid);
            new ListingFromDesignBase().SetDataGridViewProperties(gridSummary);
        }

        private Bookings_Lst bookinglist = new Bookings_Lst();
        private Hotel_Sales_Lst hotel_Sales = new Hotel_Sales_Lst();

        private void frmHotelBill_Load(object sender, EventArgs e)
        {
            Text = "Room Booking Form ({0})".With(GlobalValues.LoginUserName);
            customerGrid.ReadOnly = true;
            LoadOnce();
            btnSave.Visible = false;
            // TableView.lblMenu.Text = "Customers";
            // TableView.ItemIsClicked += new Bsoft.Controls.menuView.refreshHandler(TableView_ItemIsClicked);
            LoadCustomers1("");
            customerGrid.AllowUserToResizeRows = false;
            customerGrid.AllowUserToResizeColumns = true;
        }

        #region Customers

        private DataTable cusotmers = new DataTable();

        private void LoadCustomers1(string searchString)
        {
            customerGrid.Rows.Clear();
            //populate customers
            DataTable dt = RestoSys.DAl.CustomerDAL.GetCurrentCustomers2();
            var v = from DataRow dr in dt.Rows
                    group dr by dr["id"].ToString() into grp
                    select new
                    {
                        Id = grp.Key,
                        dueAmount = (from DataRow dr in dt.Rows
                                     where dr["id"].ToString() == grp.Key
                                     select dr["dueamt"].ToDouble()).Sum(),
                        customerName = (from DataRow dr in dt.Rows
                                        where dr["id"].ToString() == grp.Key
                                        select dr["customerName"].ToString()).First(),
                        IdNumber = (from DataRow dr in dt.Rows
                                    where dr["id"].ToString() == grp.Key
                                    select dr["IdNumber"].ToString()).First(),
                        Rooms = string.Join(",", (from drs in grp select drs["ProductName"].ToString()).ToArray()),
                    };
            if (searchString.Trim().Length > 0)
            {
                foreach (var o in v)
                {
                    if (o.customerName.ToLower().Contains(searchString.ToLower()) || o.Rooms.ToLower().Contains(searchString.ToLower()) || o.IdNumber.Contains(searchString))
                    {
                        customerGrid.Rows.Add(o.Id, o.customerName, o.Rooms, o.IdNumber, o.dueAmount);
                    }
                }
            }
            else
            {
                foreach (var o in v)
                {
                    customerGrid.Rows.Add(o.Id, o.customerName, o.Rooms, o.IdNumber, o.dueAmount);
                }
            }
            double sumDue = 0;
            foreach (DataGridViewRow item in customerGrid.Rows)
            {
                double due = item.Cells["dueamt"].Value.ToDouble();
                if (due < 0)
                {
                    item.DefaultCellStyle = dueRefundable;
                }
                else if (due == 0)
                {
                    item.DefaultCellStyle = dueCleared;
                }
                sumDue += due;
            }
            lblSumDue.Text = "Total Remaining Due = Rs.{0}".With(StringUtilities.GetMoneyFromat(sumDue));
        }

        private string CustomerId = "";

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearch.Text .Length > 0)
            //{
            //    DataRow[] drs = cusotmers.Select("CustomerName like '%" + txtSearch.Text  + "%'");
            //    customerGrid.Rows.Clear();
            //    foreach (DataRow dr in drs)
            //    {
            //        customerGrid.Rows.Add(dr["Id"].ToString(), dr["CustomerName"].ToString(), dr["Phone"].ToString());
            //    }
            //}
            //else
            //{
            //    customerGrid.Rows.Clear();
            //    foreach (DataRow dr in cusotmers.Rows)
            //    {
            //        customerGrid.Rows.Add(dr["Id"].ToString(), dr["CustomerName"].ToString(), dr["Phone"].ToString());
            //    }
            //}
            LoadCustomers1(txtSearch.Text);
        }

        private void customerGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CustomerId = customerGrid.SelectedRows[0].Cells["id"].Value.ToString();
                ShowDataForCustomer(CustomerId);

                lblCustomerName.Text = "Bookings for customer : " + CustomerDAL.GetCustomerName(CustomerId) + " ({0})".With(CustomerDAL.GetCustomeType(CustomerId));
            }
            catch
            {
                CustomerId = "";
            }
        }

        private void LoadOnce()
        {
            foreach (Control item in panelBooking.Controls)
            {
                panelBooking.Controls.Remove(item);
                item.Dispose();
            }

            foreach (Control item in panelRestaurant.Controls)
            {
                panelRestaurant.Controls.Remove(item);
                item.Dispose();
            }

            bookinglist = new Bookings_Lst();
            bookinglist.GridChanged += new Bookings_Lst.gridChanged(hotel_GridChanged);

            bookinglist.panelBooking.Parent = panelBooking;
            bookinglist.Size = panelBooking.Size;

            hotel_Sales = new Hotel_Sales_Lst();
            hotel_Sales.GridChanged += new Hotel_Sales_Lst.gridChanged(hotel_GridChanged);
            hotel_Sales.Size = panelRestaurant.Size;
            hotel_Sales.panelBooking.Parent = panelRestaurant;
        }

        private void ShowDataForCustomer(string _customerID)
        {
            bookinglist.LoadData(_customerID);
            hotel_Sales.LoadData(_customerID);
        }

        private void hotel_GridChanged(DataGridView grid)
        {
            DisplaySummaryGrid();
            btnSave.Visible = true;
        }

        #region Display Summary

        public enum summaryRows
        {
            TOTAL, Discount, SUBTOTAL, SCharge, TaxableAmount, VAT, GRANDTOTAL
        }

        public void DisplaySummaryGrid()
        {
            //sum(Amount) Amount ,
            //              sum(Discount) Discount,
            //              sum( VAT) VAT,
            //              sum( ServiceCharge) ServiceCharge,
            //              sum( NetAmount) NetAmount,
            //              sum(dueamt)  dueamt

            CalculateAmounts calculateAmounts = CalculateAmounts.GetTotals(PaymentDAL.GetSummaryofPayableItems(CustomerId));
            DataTable dtSummary = new DataTable();
            dtSummary.Columns.Add("Heading");
            dtSummary.Columns.Add("Value");
            dtSummary.Rows.Add("Amount", StringUtilities.GetMoneyFromat(calculateAmounts.Amount));
            dtSummary.Rows.Add("Total Discount", StringUtilities.GetMoneyFromat(calculateAmounts.Discount));

            if (calculateAmounts.Servicecharge > 0)
            {
                dtSummary.Rows.Add("Total Service Charge", StringUtilities.GetMoneyFromat(calculateAmounts.Servicecharge));
            }
            if (calculateAmounts.VAT > 0 || calculateAmounts.Servicecharge > 0)
            {
                dtSummary.Rows.Add("Taxable Amount", StringUtilities.GetMoneyFromat(calculateAmounts.TaxableamountCalc));
            }
            if (calculateAmounts.VAT > 0)
            {
                dtSummary.Rows.Add("Total VAT", StringUtilities.GetMoneyFromat(calculateAmounts.VAT));
            }
            dtSummary.Rows.Add("Net Amount", StringUtilities.GetMoneyFromat(calculateAmounts.Netamount));
            dtSummary.Rows.Add("Paid Amount", StringUtilities.GetMoneyFromat(calculateAmounts.Netamount - calculateAmounts.Dueamount));
            dtSummary.Rows.Add("Due Amount", StringUtilities.GetMoneyFromat(calculateAmounts.Dueamount));

            if (calculateAmounts.Dueamount >= 0)
            {
                btnSave.Text = "Receive Payment";
            }
            else
            {
                btnSave.Text = "Refund Payment";
            }
            gridSummary.DataSource = dtSummary;

            gs.AdjustHeight(gridSummary);
            gridSummary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSummary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSummary.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private GridSizeUtility gs = new GridSizeUtility();

        #endregion Display Summary

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtDetails = PaymentDAL.GetPayableItems(CustomerId);
            //add check in chek out columns

            if (dtDetails.Rows.Count > 0)
            {
                CalculateAmounts calculateAmounts = CalculateAmounts.GetTotals(PaymentDAL.GetSummaryofPayableItems(CustomerId));
                PaymentDetails frm = new PaymentDetails(dtDetails, CustomerId);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bookinglist.LoadData(CustomerId);
                    hotel_Sales.LoadData(CustomerId);
                }
            }
            else
            {
                MessageBoxMy.Show("No dues to collect");
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            CalculateAmounts calculateAmounts = CalculateAmounts.GetTotals(PaymentDAL.GetSummaryofPayableItems(CustomerId));
            if (calculateAmounts.Dueamount > 0)
            {
                MessageBoxMy.Show("Due amount Rs. {0} is remaining please recieve the due first.".With(StringUtilities.GetMoneyFromat(calculateAmounts.Dueamount)));
            }
            else if (calculateAmounts.Dueamount < 0)
            {
                MessageBoxMy.Show("Due amount Rs. {0} is yet to be refunded please refund the amount first.".With(StringUtilities.GetMoneyFromat(calculateAmounts.Dueamount)));
            }
            else
            {
                DataTable dtDetails = PaymentDAL.GetPayableItems(CustomerId);
                if (dtDetails.Rows.Count > 0)
                {
                    if (PaymentDAL.CheckOut(CustomerId, dtDetails) > 0)
                    {
                        MessageBoxMy.Show("The customer {0} is checked out succesfully,All dues are clear.".With(CustomerDAL.GetCustomerName(CustomerId)), "Thank you!");
                    }
                    bookinglist.LoadData(CustomerId);
                    hotel_Sales.LoadData(CustomerId);
                }
                else
                {
                    MessageBoxMy.Show("No rooms to checked.");
                }
            }
        }

        #endregion Customers

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            Bookings_Ent b = new Bookings_Ent();
            b.FormType = FormTypes.EntryForm;

            if (b.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers1("");
                CustomerId = b.CustomerId;
                foreach (DataGridViewRow item in customerGrid.Rows)
                {
                    if (item.Cells["Id"].Value.ToString() == CustomerId)
                    {
                        item.Selected = true;
                        return;
                    }
                }
            }
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmHotelBill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnNewBooking_Click(this, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                txtSearch.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnSave_Click(this, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnCheckOut_Click(this, null);
            }
        }

        private void picCancelSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private SetHelpLable s = new SetHelpLable();

        private void ImgHelp_Click(object sender, EventArgs e)
        {
            s.SetHelp(this);
        }
    }
}