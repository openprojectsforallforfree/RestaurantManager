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
    public partial class HelpingOrganization_Lst: Friuts.ListingFormBase
    {
        public HelpingOrganization_Lst()
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
            newToolbar.Text = Language.LanguageString.NewAdd;
            EditToolbar.Text = Language.LanguageString.Edit;
            DeleteToolbar.Text = Language.LanguageString.Delete;
            // ExportToolbar.Text = Language. LanguageString.ExporttoExcel;
        }

        private void List_Load(object sender, EventArgs e)
        {
            //<Listing>
TableName = "HelpingOrganization";
DataTableColumns.Add( "Id",ColumnTypes.Number,"colId",true ,true);
DataTableColumns.Add( "Name",ColumnTypes.String,"colName");
//DataTableColumns.Add( "TypeLocal",ColumnTypes.String,"colTypeLocal");
            //स्थानीय / बाह्य (INGO / Donor)
DataTableColumns.AddListColumn("(CASE WHEN TypeLocal='I' THEN 'बाह्य' WHEN TypeLocal='L' THEN 'स्थानीय' END) AS typelocal", ColumnTypes.String, "colTypeLocal", false, false, true, "typelocal");
DataTableColumns.Add( "fk_Address",ColumnTypes.Number,"colfk_Address");
DataTableColumns.Add( "Objective",ColumnTypes.String,"colObjective");


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
            return base.OpenEditForm(new HelpingOrganization_Ent (TableName));
        }

        public override bool OpenNewForm()
        {
            return base.OpenNewForm(new HelpingOrganization_Ent(TableName));
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
