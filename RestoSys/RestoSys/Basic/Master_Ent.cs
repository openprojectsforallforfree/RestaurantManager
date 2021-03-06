using Bsoft.Languages;
using Friuts;
using System;

namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class Master_Ent : Bsoft.Design.EntryFromDesignBase
    {
        public Master_Ent()
        {
            InitializeComponent();
            this.FirstControl = txtTitle;
            this.AcceptButton = btnOk;
            btnCancel.Text = Language.LanguageString.Cancel;
            btnOk.Text = Language.LanguageString.Ok;
            lblTitle.Text = Language.LanguageString.Details;
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

        public Master_Ent(string TableName_, string title_)
            : this()
        {
            TableName = TableName_;
            Text = title_;
            btnCancel.Text = Language.LanguageString.Cancel;
            btnOk.Text = Language.LanguageString.Ok;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Master_Ent_Load(object sender, EventArgs e)
        {
            //<Entry>

            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("Title", ColumnTypes.String, txtTitle);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}