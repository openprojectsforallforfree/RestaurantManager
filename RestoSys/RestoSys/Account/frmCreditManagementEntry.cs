using Bsoft.AppCom;
using Bsoft.Data;
using Bsoft.Forms;
using Friuts;
using RestoSys.Tags;
using System;
using System.Text;
using System.Windows.Forms;

namespace RestoSys.Account
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmCreditManagementEntry : Bsoft.Design.EntryFromDesignBase
    {
        private string creditId;
        private decimal dueamount, creditamount;

        public frmCreditManagementEntry()
        {
            InitializeComponent();
        }

        public frmCreditManagementEntry(string _creditId, string _cust_userid, string _CreditAmount, string _dueAmount, string _cust_name, string _cust_address)
        {
            InitializeComponent();
            creditId = _creditId;

            lblcust_address.Text = _cust_address;
            lblcust_name.Text = _cust_name;
            lblcust_userid.Text = _cust_userid;
            lblsale_dueAmount.Text = _dueAmount;
            lblsale_CreditAmount.Text = _CreditAmount;
            dueamount = Convert.ToDecimal(_dueAmount);
            creditamount = Convert.ToDecimal(_CreditAmount);
            dueamount = Math.Round(dueamount, 2);
            creditamount = Math.Round(creditamount, 2);

            lblsale_dueAmount.Text = dueamount.ToString();
            lblsale_CreditAmount.Text = creditamount.ToString();

            FormType = FormTypes.EntryForm;
        }

        private void frmCreditManagementEntry_Load(object sender, EventArgs e)
        {
            TableName = "Acc_CreditPayBack";
            ColumnList.AddNewEditColumn("id", ColumnTypes.Number, txtid, true, false);
            ColumnList.AddNewEditColumn("fk_Acc_Sale", ColumnTypes.Number, creditId);
            ColumnList.AddNewEditColumn("PayBackAmount", ColumnTypes.Number, txtPayBackAmount);
            ColumnList.AddNewEditColumn("Remarks", ColumnTypes.String, txtRemarks);
            //ColumnList.AddNewEditColumn("fk_Master_Customer", ColumnTypes.Number, txtcustomerId.Text);
            ColumnList.AddNewEditColumn("UserId", ColumnTypes.String, GlobalValues.LoginUserName);
            ColumnList.AddNewEditColumn("Date", ColumnTypes.EnglishDate, DateTime.Now.ToString("yyyyMMdd"));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            decimal paybackAmount = 0;
            paybackAmount = Convert.ToDecimal(txtPayBackAmount.Text);
            if (paybackAmount == 0)
            {
                MessageBoxMy.Show("Please put in the paybackAmount.", MessageBoxButtons.OK);
                return;
            }
            if (paybackAmount > dueamount)
            {
                MessageBoxMy.Show("Please dont put a pay back amount more than due amount.", MessageBoxButtons.OK);
                return;
            }

            if (Save())
            {
                UpdatePaymentToAccSale(paybackAmount);
                DialogResult = DialogResult.OK;
            }
        }

        private void UpdatePaymentToAccSale(decimal paybackAmount)
        {
            dueamount -= paybackAmount;

            //double quantityinstore = quantity - damageqty;

            //double totaldamagequantity;

            //totaldamagequantity = Convert.ToDouble(getDamagequantity(id));
          clsDataAccess.  UpdateAccoount(dueamount ,creditamount ,creditId  );

            //totaldamagequantity += damageqty;

            //StringBuilder SQL1 = new StringBuilder();
            //SQL1.Append("UPDATE Master_Product set quantity_damage = ");
            //SQL1.AppendFormat(" {0} ", totaldamagequantity);
            //SQL1.AppendFormat("where id = {0} ", id.ToString());
            //GlobalResources.SelectDBConnection.ExecuteNonQuery(SQL1.ToString()).ToString();
        }

     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}