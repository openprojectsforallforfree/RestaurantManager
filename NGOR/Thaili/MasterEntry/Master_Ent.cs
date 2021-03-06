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
    public partial class Master_Ent : Friuts.EntryFormBase
    {
        public Master_Ent()
        {
            InitializeComponent();
            this.FirstControl = txtTitle ;
            this.AcceptButton = btnOk;
            btnCancel.Text = Language.LanguageString.Cancel;
            btnOk.Text = Language.LanguageString.Ok;
            ChangeLanguage();
        }
        public void ChangeLanguage()
        {
            btnCancel.Text = Language. LanguageString.Cancel;
            btnOk.Text = Language. LanguageString.Ok;
            //newToolbar.Text = Language. LanguageString.NewAdd;
            //EditToolbar.Text = Language. LanguageString.Edit;
            //DeleteToolbar.Text = Language. LanguageString.Delete;
            //ExportToolbar.Text = Language. LanguageString.ExporttoExcel;
        }

        public Master_Ent(string TableName_)
        {
            TableName = TableName_;
            InitializeComponent();
            switch (TableName)
            {
                case "Objective":
                    Text = " संस्थाको उद्देश्यहरु ";
                    lblTitle.Text = " उद्देश्य :";
                    break;
                case "Document":
                    Text = "संलग्न विवरण ";
                    break;
                case "AffiliationOrganization":
                    Text = "आवद्धता प्रदायक निकाय ";
                    lblTitle.Text = "निकाय :";
                    break;
                case "SubjectiveWrk":
                    Text = "विषयगत कार्यक्षेत्र ";
                    break;
                case "TargetAudience":
                    Text = "लक्षित वर्ग /समुदाय ";
                    lblTitle.Text = "लक्षित वर्ग /समुदाय ";
                    break;
                case "MajorTaskAchieved":
                    Text = "संस्थाको सञ्चालन गरको प्रमुख कार्यक्रमहरु ";
                    break;
                case "Master_Specialization":
                    Text = "बिषयगत क्षेत्र";
                    break;
                case "Master_Position":
                    Text = "पद";
                    break;
                case "Master_Sex":
                    Text = "लिंग";
                    break;
                case "Master_Education":
                    Text = "शिक्षा ";
                    break;
                case "Master_MaritalStatus":
                    Text = "";
                    break;
                case "Master_Ethnicity":
                    Text = "जाति";
                    break;
                case "Master_Profession":
                    Text = "ब्यबशाये ";
                    break;
                case "Person_Role":
                    Text = "Member";
                    break;
            }
            btnCancel.Text = Language. LanguageString.Cancel;
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
