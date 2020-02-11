using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class TagType_Lst : Bsoft.Design.ListingFromDesignBase
    {
        public TagType_Lst()
        {
            InitializeComponent();
            FormType = FormTypes.ListingForm;
            ListingDataGridView = grid;
        }

        private void List_Load(object sender, EventArgs e)
        {
            //<Listing>
            TableName = "TagType";
            DataTableColumns.Add("Id", ColumnTypes.Number, "colId", true, true);
            DataTableColumns.Add("Title", ColumnTypes.String, "colTitle");
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
            return base.OpenEditForm(new TagType_Ent(TableName));
        }

        public override bool OpenNewForm()
        {
            return base.OpenNewForm(new TagType_Ent(TableName));
        }

        private void DeleteToolbar_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void ExportToolbar_Click(object sender, EventArgs e)
        {
            Reports.ExcelReport excel = new Reports.ExcelReport(this.Text, 4, grid);
        }
    }
}