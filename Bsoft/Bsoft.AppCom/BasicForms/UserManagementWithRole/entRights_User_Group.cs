using Friuts;
using System;

namespace Bsoft.AppCom.UserMgtWithRole
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class entRights_User_Group : Bsoft.Design.EntryFromDesignBase
    {
        public entRights_User_Group()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void entRights_User_Group_Load(object sender, EventArgs e)
        {
            TableName = "SuperAdmin_Rights_Roles";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("Title", ColumnTypes.String, txtTitle, true, "Role Name", "Role Required");
            ColumnList.AddNewEditColumn("Remarks", ColumnTypes.String, txtRemarks);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}