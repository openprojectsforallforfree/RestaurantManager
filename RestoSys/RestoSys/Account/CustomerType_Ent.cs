using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class CustomerType_Ent : Bsoft.Design.EntryFromDesignBase
    {
        public CustomerType_Ent()
        {
            InitializeComponent();
        }

        public CustomerType_Ent(string TableName_)
        {
            TableName = TableName_;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void CustomerType_Ent_Load(object sender, EventArgs e)
        {
            //<Entry>
            TableName = "Master_CustomerType";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("Title", ColumnTypes.String, txtTitle);
            ColumnList.AddNewEditColumn("DiscountPercent", ColumnTypes.Number, txtDiscountPercent);
            ColumnList.AddNewEditColumn("Remarks", ColumnTypes.String, txtRemarks);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}