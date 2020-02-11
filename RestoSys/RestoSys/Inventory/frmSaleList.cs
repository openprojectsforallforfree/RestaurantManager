using Bsoft.Forms;
using Friuts;
using System;
using System.Windows.Forms;

//using RestoSys.Reports;
namespace RestoSys.Inventory
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmSaleList : Bsoft.Design.EntryFromDesignBase
    {
        public static long count = 0;
        public static long CartNumber = 0;

        public frmSaleList()
        {
            InitializeComponent();
            FormType = FormTypes.ListingForm;
        }

        private void frmSaleList_Load(object sender, EventArgs e)
        {
            if (count > 5)
            {
                MessageBoxMy.Show("Too Many Shopping Carts,Please Close some Shopping Carts.");
            }
            if (count == 0)
            {
                CartNumber = 0;
            }
            count++;
            CartNumber++;
            Text = "Shopping Cart " + CartNumber.ToString();
            TableName = "Inv_Sale";
        }

        private void frmSaleList_FormClosed(object sender, FormClosedEventArgs e)
        {
            count--;
        }
    }
}