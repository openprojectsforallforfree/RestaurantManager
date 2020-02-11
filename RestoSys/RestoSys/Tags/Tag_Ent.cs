using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class Tag_Ent : Bsoft.Design.EntryFromDesignBase
    {
        public Tag_Ent()
        {
            InitializeComponent();
        }

        private string _grpId = string.Empty;

        public Tag_Ent(string TableName_, string grpId)
        {
            _grpId = grpId;
            TableName = TableName_;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Tag_Ent_Load(object sender, EventArgs e)
        {
            //<Entry>
            TableName = "Tag";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("TagGroupId", ColumnTypes.Number, _grpId);
            //ComboBoxDataLoader.LoadData("Id","Title","TagGroup", cmbTagGroupId, true);
            ColumnList.AddNewEditColumn("Value", ColumnTypes.String, txtValue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}