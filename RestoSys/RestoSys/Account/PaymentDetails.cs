using Bsoft.Account;
using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Design;
using Bsoft.Forms;
using Friuts;
using RestoSys.DAl;
using RestoSys.Reports;
using RestoSys.Reports.Hotel;
using System;
using System.Data;
using System.Windows.Forms;

namespace RestoSys.Account
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class PaymentDetails : Bsoft.Design.ListingFromDesignBase
    {
        public PaymentDetails()
        {
            InitializeComponent();
            TableName = "aa";
            ListingDataGridView = grid;
            LoadDataInFormLoad = false;
            FormType = FormTypes.MultipleSelect;
        }

        private string CustomerId = "";
        private DataTable DtItems = new DataTable();

        public PaymentDetails(DataTable _dtItems, string _customerId)
        {
            CustomerId = _customerId;
            DtItems = _dtItems;
            InitializeComponent();
            TableName = "aa";
            ListingDataGridView = grid;
            LoadDataInFormLoad = false;
            FormType = FormTypes.MultipleSelect;

            DataTableColumns.Add("id", ColumnTypes.Number, "bookingid");
            DataTableColumns.Add("fk_product", ColumnTypes.Number, "productId");
            DataTableColumns.Add("ProductName", ColumnTypes.String, "description");
            DataTableColumns.Add("quantity", ColumnTypes.AmountRound, "quantity");
            DataTableColumns.Add("indate", ColumnTypes.String, "colIndate");
            DataTableColumns.Add("outdate", ColumnTypes.String, "colOutDate");
            DataTableColumns.Add("PAX", ColumnTypes.String, "colPAX");
            DataTableColumns.Add("rate", ColumnTypes.AmountRound, "rate");
            DataTableColumns.Add("amount", ColumnTypes.AmountRound, "amount");
            DataTableColumns.Add("discount", ColumnTypes.AmountRound, "discount");
            DataTableColumns.Add("netamount", ColumnTypes.AmountRound, "netamount");
            DataTableColumns.Add("dueamt", ColumnTypes.AmountRound2, "dueamount");
            DataTableColumns.Add("tableName", ColumnTypes.String, "colTableName");
            DataTableColumns.Add("vat", ColumnTypes.AmountRound2, "vat");
            DataTableColumns.Add("servicecharge", ColumnTypes.AmountRound2, "ServiceCharge");
            LoadDataTable(_dtItems);
            MultiSelectSelectAll();
            Text = "Pay ment details for customer : {0}".With(CustomerDAL.GetCustomerName(_customerId));
            new ListingFromDesignBase().SetDataGridViewProperties(gridSummary);
        }

        private DataGridViewCellStyle dataGridRowStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridColumnHeaderCellStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridCellStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridViewRowHeaderCellStyle = new DataGridViewCellStyle();

        //override this to make sure the multi select works properly
        public override void SetDataGridViewProperties(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.RowHeadersWidth = 54;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.MultiSelect = false;
            dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(223)))), ((int)(((byte)(224)))));

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView.StandardTab = true; //required...
            ////Column Header Style
            dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridColumnHeaderCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridColumnHeaderCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(65)))), ((int)(((byte)(109)))));
            dataGridColumnHeaderCellStyle.Font = dataGridView.ColumnHeadersDefaultCellStyle.Font;
            dataGridColumnHeaderCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridColumnHeaderCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridColumnHeaderCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridColumnHeaderCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridColumnHeaderCellStyle;

            ////Cell Style
            dataGridCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(223)))), ((int)(((byte)(224)))));
            dataGridCellStyle.Font = dataGridView.DefaultCellStyle.Font;
            dataGridCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridCellStyle.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridCellStyle.NullValue = string.Empty;
            dataGridView.DefaultCellStyle = dataGridCellStyle;

            dataGridRowStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));

            dataGridView.AlternatingRowsDefaultCellStyle = dataGridRowStyle;

            //Row Header Style
            dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewRowHeaderCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewRowHeaderCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(65)))), ((int)(((byte)(109)))));

            dataGridViewRowHeaderCellStyle.Font = Bsoft.Design.ListingFromDesignBase.DigitFont;
            dataGridViewRowHeaderCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewRowHeaderCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewRowHeaderCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewRowHeaderCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewRowHeaderCellStyle;
        }

        private void fsButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void txtTender_TextChanged(object sender, EventArgs e)
        {
            //pay.Tenderamount = txtTender.Text.ToDecimal();
            //sevenReturn.Value = pay.ReturnAmount.ToString ();
        }

        private PayMent pay = null;
        private DataTable cDataTable = new DataTable();

        // amount is amount paid by customer or amount refunded
        private void Calculate()
        {
            cDataTable = GetMultiSelectDataTable();
            pay = new PayMent(cDataTable, txtAmountPaid.Text.ToDecimal());
            sevenTotalDue.Value = pay.SumdueAmount.ToString();

            DataTable summary = new DataTable();
            summary.Columns.Add("Heading");
            summary.Columns.Add("Value");
            summary.Rows.Add("Amount", StringUtilities.GetMoneyFromat(pay.SumAmount));
            summary.Rows.Add("Discount", pay.SumDiscount);
            if (pay.Sumservicecharge > 0)
            {
                summary.Rows.Add("Service Charge", StringUtilities.GetMoneyFromat(pay.Sumservicecharge));
                summary.Rows.Add("Taxable Amount", StringUtilities.GetMoneyFromat(pay.TaxableAmount));
            }
            if (pay.Sumvat > 0)
            {
                summary.Rows.Add("VAT", StringUtilities.GetMoneyFromat(pay.Sumvat));
            }

            summary.Rows.Add("NetAmount", StringUtilities.GetMoneyFromat(pay.SumnetAmount));
            if (pay.SumnetAmount - pay.SumdueAmount > 0)
            {
                summary.Rows.Add("Paid Amount", StringUtilities.GetMoneyFromat(pay.SumnetAmount - pay.SumdueAmount));
                summary.Rows.Add("Due Amount", StringUtilities.GetMoneyFromat(pay.SumdueAmount));
            }

            gridSummary.DataSource = summary;
            gridSummary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSummary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSummary.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sevenDueAmount.Value = (sevenTotalDue.Value.ToDecimal() - txtAmountPaid.Text.ToDecimal()).ToString();
            txtAmountPaid.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text.ToDecimal() == 0)
            {
                MessageBoxMy.Show("Please enter some amount first.");
                txtAmountPaid.Focus();
                return;
            }
            string message = "Did you receive Rs {0}?";
            if (txtAmountPaid.Text.ToDecimal() < 0)
            {
                message = "Did you refund Rs {0}.?";
            }
            if (MessageBoxMy.Show(message.With(StringUtilities.GetMoneyFromat(txtAmountPaid.Text)), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string billno = PaymentDAL.Savetransaction(CustomerId, pay, cDataTable);
                pay.BillNumber = billno;
                pay.CustomerName = CustomerDAL.GetCustomerName(CustomerId);
                pay.Cashier = GlobalValues.LoginUserName;
                pay.Date = DateTime.Now.Date.ToString(DateUtility.DisplayDateFormat);
                if (ApplicationSetting.PrintBilll)
                {
                    if (ApplicationSetting.PrinterType == PrinterTypes.RollPrinter)
                    {
                        Hotel_Invoice prnt = new Hotel_Invoice();
                        for (int i = 0; i < ApplicationSetting.Print_NoOfCopies; i++)
                        {
                            prnt.printBillGDI(
                                pay
                                );
                        }
                        if (ApplicationSetting.Print_SavePDF)
                        {
                            prnt.PrintFile("a.jpg");
                        }
                    }
                    else
                    {
                        Hotel_Invoice_holder prnt = new Hotel_Invoice_holder(pay);
                        prnt.Show();
                        prnt.Visible = false;
                        prnt.printBillHTML();
                        if (ApplicationSetting.Print_SavePDF)
                        {
                            prnt.saveBillPDF();
                        }
                    }
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grid.IsCurrentCellDirty)
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                Calculate();
            }
        }

        private void lblcopy_Click(object sender, EventArgs e)
        {
            txtAmountPaid.Text = sevenTotalDue.Value.ToString();
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            if (txtAmountPaid.Value.Contains("-"))
            {
                lblPayamount.Text = "Refunded Amount";
            }
            else
            {
                lblPayamount.Text = "Received Amount";
            }

            if (sevenDueAmount.Value.ToDecimal() < 0)
            {
                lblDue.Text = "Amount to Refund";
            }
            else
            {
                lblDue.Text = "Due Amount";
            }
            try
            {
                lblInWords.Text = new Bsoft.Common.NumberInWords().inWords(txtAmountPaid.Text);
            }
            catch { }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (ActiveControl is TextBox)
                {
                    TextBox MultiLine = (TextBox)ActiveControl;
                    if (MultiLine.Multiline)
                    {
                        return; //do noing
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
            }

            if (e.KeyCode == Keys.Tab)
            {
                if (ActiveControl is TextBox)
                {
                    TextBox TxtBox = (TextBox)ActiveControl;
                    TxtBox.SelectAll(); //Text higlighted..
                }
            }
        }

        private void PaymentDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                lblcopy_Click(null, null);
            }
        }
    }
}