using System;
using System.Windows.Forms;

namespace RestoSys
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class FrmTablesSelector : Bsoft.Design.EntryFromDesignBase
    {
        public FrmTablesSelector()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public void AddTable(string tableName)
        {
            CheckBox b = new CheckBox();
            b.Text = tableName;
            b.Visible = true;
            flwTables.Controls.Add(b);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTablesSelector_Load(object sender, EventArgs e)
        {
        }
    }
}