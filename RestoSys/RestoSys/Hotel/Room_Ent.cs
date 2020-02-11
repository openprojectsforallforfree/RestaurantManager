using Bsoft.Data;
using Friuts;
using RestoSys.Tags;
using System;
using System.Data;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class Room_Ent : Bsoft.Design.EntryFromDesignBase
    {
        public Room_Ent()
        {
            InitializeComponent();
            //<Entry>
            TableName = "Hotel_Master_Room";
            ColumnList.AddNewEditColumn("id", ColumnTypes.Number, txtid, true, false);
            ColumnList.AddNewEditColumn("Name", ColumnTypes.String, txtName);
            //For dormitory room rate will be mulitplied by no of cusotmers
            ColumnList.AddNewEditColumn("isDormitory", ColumnTypes.String, txtIsDormitory);
            ColumnList.AddNewEditColumn("PerPersonRate", ColumnTypes.AmountRound, txtPerPersonRate, true, "per Person rate", "Per person rate required");
            ColumnList.AddNewEditColumn("PerRoomRate", ColumnTypes.AmountRound, txtPerRoomRate, true, "per Room rate", "Per  room rate required");
            ColumnList.AddNewEditColumn("facilities", ColumnTypes.String, txtfacilities);
            ColumnList.AddNewEditColumn("maxnos", ColumnTypes.Number, txtmaxnos);
            ColumnList.AddNewEditColumn("remarks", ColumnTypes.String, txtremarks);
            ColumnList.AddNewEditColumn("fk_Hotel_RoomType", ColumnTypes.Number, cboRoomType);
            chkDormitory.Checked = false;
            ComboBoxDataLoader loader = new ComboBoxDataLoader();
            loader.FormName = this;
            loader.ComboLoadinfoItems.Add("ID", "Title", "Hotel_RoomType", cboRoomType, true);
            loader.LoadDataInComboBoxes();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Room_Ent_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsDataAccess.UpdateRoom();

            Close();
        }


        private void txtIsDormitory_TextChanged(object sender, EventArgs e)
        {
        }

        public override bool LoadData()
        {
            bool b = base.LoadData();
            if (txtIsDormitory.Text == "1")
            {
                chkDormitory.Checked = true;
            }
            else
            {
                chkDormitory.Checked = false;
            }
            return b;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDormitory.Checked)
            {
                lblMEssage.Text = "Dormitory is selected,Default Rate is Per Person.";
                txtIsDormitory.Text = "1";
            }
            else
            {
                lblMEssage.Text = "Dormitory is not selected,Default Rate is Per Room.";
                txtIsDormitory.Text = "0";
            }
        }

        private void lblCtype_Click(object sender, EventArgs e)
        {
            UEMS.Hotel_RoomType_Lst frm = new Hotel_RoomType_Lst();
            frm.ShowDialog();
            ComboBoxDataLoader loader = new ComboBoxDataLoader();
            loader.ComboLoadinfoItems.Add("ID", "Title", "Hotel_RoomType", cboRoomType, true);
            loader.LoadDataInComboBoxes();
        }
    }
}