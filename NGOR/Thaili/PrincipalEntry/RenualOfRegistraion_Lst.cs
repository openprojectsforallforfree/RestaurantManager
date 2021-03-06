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
using Bsoft.Data;
namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class RenualOfRegistraion_Lst : Friuts.ListingFormBase
    {
        public RenualOfRegistraion_Lst()
        {
            InitializeComponent();
            FormType = FormTypes.ListingForm;
            ListingDataGridView = grid;

            ChangeLanguage();
        }
        public void ChangeLanguage()
        {
            //btnCancel.Text = Language.Cancel;
            //btnOk.Text = Language.Ok;
            newToolbar.Text = Language. LanguageString.NewAdd;
            EditToolbar.Text = Language. LanguageString.Edit;
            DeleteToolbar.Text = Language. LanguageString.Delete;
            // ExportToolbar.Text = Language. LanguageString.ExporttoExcel;
        }
        string _NgoId = string.Empty;
        public RenualOfRegistraion_Lst(string NgoId):this()
        {
            _NgoId = NgoId;
            string NgoName =GlobalResources .SelectDBConnection .ExecuteScalar ( string .Format ("SELECT Name From NGO where id = {0}",_NgoId )).ToString ();
            Text = NgoName + "को " + Text;
        }

        private void List_Load(object sender, EventArgs e)
        {
            //<Listing>
            TableName = "RenualOfRegistraion";
            DataTableColumns.Add("Id", ColumnTypes.Number, "colId", true, true);
            DataTableColumns.Add("fk_NGO", ColumnTypes.Number, "colfk_NGO");
            //DataTableColumns.Add("FiscalyearId", ColumnTypes.Number, "colFiscalyearId");
            RelationList.Add("FiscalyearId", "FISCALYEARS", "sn", "FISCALYEAR", "colFiscalyearId", TableJoinTypes.LEFT_JOIN);
            DataTableColumns.Add("D_RenalDate", ColumnTypes.String, "colD_RenalDate");
            DataTableColumns.Add("D_RenualTill", ColumnTypes.String, "colD_RenualTill");
            //DataTableColumns.Add("RenewBy", ColumnTypes.Number, "colRenewBy");
            RelationList.Add("RenewBy", "IndividualPerson", "id", "FirstName || ' ' || LastName As Name", "colRenewBy", TableJoinTypes.LEFT_JOIN);
           

        }
        public override bool GenerateSelectSQL()
        {
            SearchConditionList.Clear();
            SearchConditionList.AddCriteria(ColumnTypes.Number, "fk_NGO", ComparisionTypes.EQUAL, _NgoId);
            return base.GenerateSelectSQL();
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
            return base.OpenEditForm(new RenualOfRegistraion_Ent(_NgoId ));
        }

        public override bool OpenNewForm()
        {
            return base.OpenNewForm(new RenualOfRegistraion_Ent(_NgoId));
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
