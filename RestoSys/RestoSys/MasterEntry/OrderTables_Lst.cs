using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class OrderTables_Lst : Bsoft.Design.ListingFromDesignBase
    {
        public OrderTables_Lst()
        {
            InitializeComponent();
            FormType = FormTypes.ListingForm;
            ListingDataGridView = grid;
        }

        private void List_Load(object sender, EventArgs e)
        {
            //<Listing>
            TableName = "OrderTables";
            DataTableColumns.Add("Id", ColumnTypes.Number, "colId", true, true);
            DataTableColumns.Add("Name", ColumnTypes.String, "colName");
            DataTableColumns.Add("Remarks", ColumnTypes.String, "colRemarks");
        }

        private void newToolbar_Click(object sender, EventArgs e)
        {
            OpenNewForm();
        }

        private void EditToolbar_Click(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        public override bool OpenEditForm()
        {
            return base.OpenEditForm(new OrderTables_Ent(TableName));
        }

        public override bool OpenNewForm()
        {
            return base.OpenNewForm(new OrderTables_Ent(TableName));
        }

        private void DeleteToolbar_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void ExportToolbar_Click(object sender, EventArgs e)
        {
            Reports.ExcelReport excel = new Reports.ExcelReport(this.Text, 4, grid);
        }

        private void ExitToolbar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}