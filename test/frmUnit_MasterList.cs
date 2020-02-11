using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmUnit_MasterList : Friuts.ListingFormBase
    {
        public frmUnit_MasterList()
        {
            InitializeComponent();
            FormType = FormTypes.ListingForm;
            ListingDataGridView = grid;
            toolstrip = toolStrip1;
        }

        private void Listing_Load(object sender, EventArgs e)
        {
            TableName = "Master_Unit";
            DataTableColumns.Add("Id", ColumnTypes.String, "colId", true, true);
            DataTableColumns.Add("Unit", ColumnTypes.String, "colUnit");
            DataTableColumns.Add("Symbol", ColumnTypes.String, "colSymbol");
            DataTableColumns.Add("Factor", ColumnTypes.Number, "colFactor");

            // RelationList.Add("ParentId", TableName, "Unit", "colParentId");
        }

        public override bool OpenEditForm()
        {
            return base.OpenEditForm(new frmMaster_Unit());
        }

        public override bool OpenNewForm()
        {
            return base.OpenNewForm(new frmMaster_Unit());
        }

        private void newToolbar_Click_1(object sender, EventArgs e)
        {
            OpenNewForm();
        }

        private void EditToolbar_Click_1(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        private void DeleteToolbar_Click_1(object sender, EventArgs e)
        {
            Delete();
        }

        private void ExportToolbar_Click_1(object sender, EventArgs e)
        {
        }
    }
}