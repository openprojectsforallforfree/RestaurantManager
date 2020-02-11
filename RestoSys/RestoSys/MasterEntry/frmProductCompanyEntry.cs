using Friuts;
using System;

namespace RestoSys.MasterEntry
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmProductCompanyEntry : Bsoft.Design.EntryFromDesignBase
    {
        public frmProductCompanyEntry()
        {
            InitializeComponent();

            TableName = "Master_Product_Company";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.Add("Name", ColumnTypes.String, txtName, true, "Name", string.Empty);
            ColumnList.AddNewEditColumn("Address", ColumnTypes.String, txtAddress);
            ColumnList.AddNewEditColumn("Phone", ColumnTypes.String, txtPhone);
            ColumnList.AddNewEditColumn("Email", ColumnTypes.String, txtEmail);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmProductCompanyEntry_Load(object sender, EventArgs e)
        {
            this.FirstControl = txtName;
            txtName.Focus();
            txtName.Select();
        }
    }
}