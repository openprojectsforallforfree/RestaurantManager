using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Forms;
using System;
using System.Windows.Forms;

namespace RestoSys.RestaurantBilling
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmApplicationSetting : Bsoft.Design.EntryFromDesignBase
    {
        public frmApplicationSetting()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ApplicationSetting.PrintBilll = chkPrintBill.Checked;
            ApplicationSetting.VatPercent = txtVat.Text.ToInt();
            ApplicationSetting.ServiceChargePercent = txtService.Text.ToInt();
            if (!System.IO.Directory.Exists(txtBackupFolder.Text))
            {
                MessageBoxMy.Show("The backup folder does not exits ,Please select an existing folder.");
                return;
            }
            else
            {
                ApplicationSetting.BackUpFolder = txtBackupFolder.Text;
            }
            ConstantValues.Print_NoOfCopies = numCopies.Value.ToInt();
            ConstantValues.Print_SavePDF = chkPDFCopy.Checked;
            if (rdoA4.Checked)
            {
                ConstantValues.Print_PrinterType = PrinterTypes.A4Printer;
            }
            else
            {
                ConstantValues.Print_PrinterType = PrinterTypes.RollPrinter;
            }
            ApplicationSetting.SetData();
            Close();
        }

        private void frmApplicationSetting_Load(object sender, EventArgs e)
        {
            chkPrintBill.Checked = ApplicationSetting.PrintBilll;
            txtVat.Text = ApplicationSetting.VatPercent.ToString();
            txtService.Text = ApplicationSetting.ServiceChargePercent.ToString();
            txtBackupFolder.Text = ApplicationSetting.BackUpFolder;

            numCopies.Value = ConstantValues.Print_NoOfCopies;
            chkPDFCopy.Checked = ConstantValues.Print_SavePDF;
            PrinterTypes pt = ConstantValues.Print_PrinterType;
            if (pt == PrinterTypes.A4Printer)
            {
                rdoA4.Checked = true;
            }
            else
            {
                rdoRoll.Checked = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(txtBackupFolder.Text))
            {
                folderBackup.SelectedPath = txtBackupFolder.Text;
            }
            if (folderBackup.ShowDialog() == DialogResult.OK)
            {
                string FileName = folderBackup.SelectedPath;
                txtBackupFolder.Text = FileName;
            }
        }
    }
}