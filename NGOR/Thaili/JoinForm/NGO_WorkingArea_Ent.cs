using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Friuts;
using Bsoft.Common.Language;
using Bsoft.Languages;
namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class NGO_WorkingArea_Ent : Friuts.EntryFormBase
    {
        public NGO_WorkingArea_Ent()
        {
            InitializeComponent();
            ChangeLanguage();
        }
        public void ChangeLanguage()
        {
            btnCancel.Text = Language.LanguageString.Cancel;
            btnOk.Text = Language.LanguageString.Ok;
            //newToolbar.Text = Language. LanguageString.NewAdd;
            //EditToolbar.Text = Language. LanguageString.Edit;
            //DeleteToolbar.Text = Language. LanguageString.Delete;
            //ExportToolbar.Text = Language. LanguageString.ExporttoExcel;
        }
        private string _NGOId = string.Empty;
        Address_Ent ae;
        public NGO_WorkingArea_Ent(string NgoId)
            : this()
        {
            _NGOId = NgoId;
            //Load Address
            ae = new Address_Ent();
            ae.pnlCountry.Visible = false;
            ae.flowLayoutPanel1.Parent = grpfk_Address;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfirmationRequired = false;
            ae.ConfirmationRequired = false;
            if (ae.Save(false ))
            {
                txtfk_Address.Text = ae.getLatestIdFromSQL("ID").ToString ();
                Save();
            }
        }

        private void NGO_WorkingArea_Ent_Load(object sender, EventArgs e)
        {
            //<Entry>
            TableName = "NGO_WorkingArea";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("fk_NGO", ColumnTypes.Number, _NGOId );
            ColumnList.AddNewEditColumn("fk_Address", ColumnTypes.Number, txtfk_Address);
            ae.FormType = FormType;
            LoadData();
            if (FormType == FormTypes.EditForm)
            {
                ae.PrimaryKeyValue = txtfk_Address.Text;
                ae.FormType = FormTypes.EditForm;
                ae.LoadData();
            }
             
        }
        //private void loadContactPerson(string KEY, ListingGrid lstGrdPerson)
        //{
        //    if (KEY != "")
        //    {
        //        string SQL = "";
        //        SQL = string.Format("select firstname || ' ' || lastname as नाम FROM IndividualPerson  where id={0}", KEY);
        //        DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(SQL.ToString());
        //        lstGrdPerson.data = dt;
        //    }
        //}
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
