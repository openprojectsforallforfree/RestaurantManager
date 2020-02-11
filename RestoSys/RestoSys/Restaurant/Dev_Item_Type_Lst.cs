using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class Dev_Item_Type_Lst : Bsoft.Design.ListingFromDesignBase
    {
        public Dev_Item_Type_Lst()
        {
            InitializeComponent();
            FormType = FormTypes.ListingForm;
            ListingDataGridView = grid;
        }

        private void List_Load(object sender, EventArgs e)
        {
            //<Listing>
            TableName = "Dev_Item_Type";
            DataTableColumns.Add("id", ColumnTypes.Number, "colid", true, true);
            DataTableColumns.Add("Name", ColumnTypes.String, "colName");
            DataTableColumns.Add("Remarks", ColumnTypes.String, "colRemarks");
        }
    }
}