using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Friuts;
using Bsoft.Controls;
using Bsoft.Common.Language;
using Bsoft.Languages;
using UEMS.BLL;
using Bsoft.Data;
using Bsoft.AppCom;
namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class RenualOfRegistraion_Ent : Friuts.EntryFormBase
    {
        public RenualOfRegistraion_Ent()
        {
            InitializeComponent();
            this.FirstControl = btnOk;
            //Target Audience  
            nGO_Document_Lst = new NGO_Document_Lst();
            nGO_Document_Lst.panel1.Parent = grpIncludedDocument;
            nGO_Document_Lst.ConfirmationRequired = false;

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
        NGO_Document_Lst nGO_Document_Lst;
        string _NgoId = string.Empty;
        public RenualOfRegistraion_Ent(string NgoId)
            : this()
        {
            txtfk_NGO.Text = NgoId;
            _NgoId = NgoId;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Save();
            //LoadData();
            if (FormType == FormTypes.EditForm)
            {

                Save();
            }
            if (FormType == FormTypes.EntryForm)
            {
                Save(false);
                PrimaryKeyValue = getLatestIdFromSQL("Id");
                txtId.Text = PrimaryKeyValue.ToString();
                FormType = FormTypes.EditForm;
                // grpTargetAudience_NGO.Visible = true;
                LoadData();
            }
        }

        private void RenualOfRegistraion_Ent_Load(object sender, EventArgs e)
        {
            //<Entry>
            TableName = "RenualOfRegistraion";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("fk_NGO", ColumnTypes.Number, txtfk_NGO);
            ColumnList.AddNewEditColumn("FiscalyearId", ColumnTypes.Number, cmbFiscalyearId);
            ComboBoxDataLoader cmbloader = new ComboBoxDataLoader();
            cmbloader.ComboboxOrderBy = "sn desc";
            cmbloader.ComboLoadinfoItems.Add("sn", "FISCALYEAR", "FISCALYEARS", cmbFiscalyearId, true);
            cmbloader.LoadDataInComboBoxes();
            ColumnList.AddNewEditColumn("D_RenalDate", ColumnTypes.String, txtD_RenalDate);
            ColumnList.AddNewEditColumn("D_RenualTill", ColumnTypes.String, txtD_RenualTill);
            ColumnList.AddNewEditColumn("RenewBy", ColumnTypes.Number, txtContactPerson);
            // FiscalYearLoader.LoadData(cmbFiscalyearId);
            ComboUtilities.LoadData("sn", "Fiscalyear", "Fiscalyears", cmbFiscalyearId, true, string.Empty);
            ComboUtilities.SelectComboBoxItemUsingValue(cmbFiscalyearId, ConstantValues.CurrentFiscalYearValue);
            txtD_RenalDate.Value = CrudeFx.NepaliDate.NepaliDate.Today;
            if (FormType == FormTypes.EntryForm)
            {

                ComboUtilities.SelectComboBoxItemUsingKey(cmbFiscalyearId, ConstantValues.CurrentFiscalYearValue);
                //grpTargetAudience_NGO.Visible = false;
            }
            //else 
            //{
            //    FiscalYearLoader.SetSelectedFinancialYear(cmbFiscalyearId, );
            //}



        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            IndividualPerson_Lst frm = new IndividualPerson_Lst();
            frm.FormType = FormTypes.SelectionForm;
            frm.valueSelected += new ListingFormBase.ValueSelected(frm_valueSelected);
            frm.ShowDialog();

        }
        public override bool LoadData()
        {
            base.LoadData();
            if (FormType == FormTypes.EditForm)
            {
                Bsoft.Utility.FormUtility.adjustHt(this, flowLayoutPanel1, grpIncludedDocument, true);
                nGO_Document_Lst.LoadData(txtId.Text);
                loadPerson(txtContactPerson.Text, lstGrdContactPeson);

            }
            return true;
        }
       

        void frm_valueSelected(object sender, string SelectedPrimaryKey)
        {
            string key = SelectedPrimaryKey;
            loadPerson(key, lstGrdContactPeson);
            txtContactPerson.Text = key;
        }
        private void loadPerson(string KEY, ListingGrid lstGrdPerson)
        {
            if (KEY != "")
            {
                string SQL = "";
                SQL = string.Format("select firstname || ' ' || lastname as नाम FROM IndividualPerson  where id={0}", KEY);
                DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(SQL.ToString());
                lstGrdPerson.data = dt;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void RenualOfRegistraion_Ent_Shown(object sender, EventArgs e)
        {
            if (FormType == FormTypes.EditForm)
            {
                Bsoft.Utility.FormUtility.adjustHt(this, flowLayoutPanel1, grpIncludedDocument, true);
            }
            else
            {
                Bsoft.Utility.FormUtility.adjustHt(this, flowLayoutPanel1, grpIncludedDocument, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bsoft.Utility.FormUtility.adjustHt(this, flowLayoutPanel1, grpIncludedDocument, !grpIncludedDocument.Visible);
        }
    }
}
