using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmMaster_Unit : Friuts.EntryFormBase
    {
        public frmMaster_Unit()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmMaster_Unit_Load(object sender, EventArgs e)
        {
            //<Entry>
            TableName = "Master_Unit";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.String, txtId, true, false);
            ColumnList.AddNewEditColumn("Unit", ColumnTypes.String, txtUnit);
            ColumnList.AddNewEditColumn("Symbol", ColumnTypes.String, txtSymbol);
            ColumnList.AddNewEditColumn("Master_UnitCategoryId", ColumnTypes.Number, cmbMaster_UnitCategoryId);
            ColumnList.AddNewEditColumn("Factor", ColumnTypes.String, txtFactor);
        }
    }
}