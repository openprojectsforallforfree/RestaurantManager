using Friuts;
using System;

namespace RestoSys.MasterEntry
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmUnitEntry : Bsoft.Design.EntryFromDesignBase
    {
        //  string _which;
        public frmUnitEntry()
        {
            InitializeComponent();
        }

        //public frmUnitEntry(string which)
        //{
        //    InitializeComponent();
        //    //FormType = FormTypes.EntryForm ;
        //    _which = which;
        //}

        private void frmUnitEntry_Load(object sender, EventArgs e)
        {
            TableName = "Master_Unit";
            Text = "Units";
            this.FirstControl = txtName;
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.Add("Name", ColumnTypes.String, txtName, true, "Name", string.Empty);
            ColumnList.AddNewEditColumn("Symbol", ColumnTypes.String, txtSymbol);
            ColumnList.AddNewEditColumn("Type", ColumnTypes.String, cboType.Text);
            txtName.Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}