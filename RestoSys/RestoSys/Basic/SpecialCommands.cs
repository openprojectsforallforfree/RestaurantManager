using RestoSys.Inventory;
using System;
using System.Windows.Forms;

namespace RestoSys.Basic
{
    public partial class SpecialCommands : Form
    {
        public SpecialCommands()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.TruncateTransactionTables();
        }
    }
}