using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class entAddress : Bsoft.Design.EntryFromDesignBase
    {
        public entAddress()
        {
            InitializeComponent();
        }

        public entAddress(string TableName_)
        {
            TableName = TableName_;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void entAddress_Load(object sender, EventArgs e)
        {
            //<Entry>
            TableName = "Address";
            FormType = FormTypes.EditForm;
            PrimaryKeyValue = 1;
            //FormType = FormTypes.EntryForm;
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("Tole", ColumnTypes.String, txtTole);

            ColumnList.AddNewEditColumn("LocalBody", ColumnTypes.String, txtLocalBody);

            ColumnList.AddNewEditColumn("District", ColumnTypes.String, txtDistrict);

            ColumnList.AddNewEditColumn("Zone", ColumnTypes.String, txtZone);

            ColumnList.AddNewEditColumn("Country", ColumnTypes.String, txtCountry);

            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}