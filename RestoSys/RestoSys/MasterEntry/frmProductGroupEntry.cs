using Bsoft.Common;
using Bsoft.Data;
using Friuts;
using RestoSys.Tags;
using System;

namespace RestoSys.MasterEntry
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmProductGroupEntry : Bsoft.Design.EntryFromDesignBase
    {
        public frmProductGroupEntry()
        {
            InitializeComponent();
            ComboBoxDataLoader loader = new ComboBoxDataLoader();
            loader.ComboLoadinfoItems.Add("ID", "Name", "Dev_Item_Type", cboGroupType, true, ColumnTypes.String, "");
            loader.LoadDataInComboBoxes();

            TableName = "Master_Product_Group";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.Add("Name", ColumnTypes.String, txtName, true, "Name", string.Empty);
            ColumnList.AddNewEditColumn("Description", ColumnTypes.String, txtDescription);
            ColumnList.AddNewEditColumn("code", ColumnTypes.String, txtCode);
            ColumnList.AddNewEditColumn("fk_ItemType", ColumnTypes.String, cboGroupType);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();

            string a = InsertSQL;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductGroupEntry_Load(object sender, EventArgs e)
        {
            this.FirstControl = cboGroupType;
            cboGroupType.Select();
        }

        private void lblfk_Group_Click(object sender, EventArgs e)
        {
            UEMS.Dev_Item_Type_Lst d = new UEMS.Dev_Item_Type_Lst();
            d.ShowDialog();
        }

        private void cboGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem ci = (ComboItem)cboGroupType.SelectedItem;
            lblDetail.Text =clsDataAccess. GetDetails(ci.Key);
        }

        
    }
}