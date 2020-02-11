using System;
using System.Windows.Forms;
using UEMS;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //   MessageBox .Show ( button1.TabStop.ToString());
            frmUnit_MasterList a = new frmUnit_MasterList();
            a.ShowDialog();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Tab}");
        }
    }
}