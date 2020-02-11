using Bsoft.Forms;
using System;
using System.Windows.Forms;

namespace RestoSys.Inventory
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmSalesCart : Bsoft.Design.EntryFromDesignBase
    {
        public static long Cartcount = 0;
        public static long CartNumber = 0;

        public frmSalesCart()
        {
            InitializeComponent();
            anOrder1.btnAddItem.Visible = true;
        }

        private void frmSaleList_Load(object sender, EventArgs e)
        {
            if (Cartcount > 5)
            {
                MessageBoxMy.Show("Too Many Shopping Carts,Please Close some Shopping Carts.");
            }
            if (Cartcount == 0)
            {
                CartNumber = 0;
            }
            Cartcount++;
            CartNumber++;
            Text = "Shopping Cart " + CartNumber.ToString();
            TableName = "Inv_Sale";
            anOrder1.cancelOrder += new RestoSys.RestaurantBilling.AnOrder.CancelOrderHandler(anOrder1_cancelOrder);
        }

        private void anOrder1_cancelOrder(object sender)
        {
            //do stuf
        }

        private void frmSaleList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cartcount--;
        }
    }
}