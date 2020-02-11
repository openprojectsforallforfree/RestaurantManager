using Bsoft.Controls;
using System;
using System.Windows.Forms;

namespace RestoSys.UserControls
{
    public partial class ProductSearchCriteria : UserControl
    {
        public ProductSearchCriteria()
        {
            InitializeComponent();
        }

        private void ProductSearchCriteria_Load(object sender, EventArgs e)
        {
            LblGeneric.LableWidth = 150;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }
    }
}