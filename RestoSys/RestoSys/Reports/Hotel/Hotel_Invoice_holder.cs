using Bsoft.Account;
using Bsoft.Common;
using Bsoft.PDF;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace RestoSys.Reports.Hotel
{
    public partial class Hotel_Invoice_holder : Form
    {
        public Hotel_Invoice_holder(PayMent pay)
        {
            _pay = pay;
            finalBill = GetFinalBill();
            InitializeComponent();
            myWebBrowser.DocumentCompleted += myWebBrowser_DocumentCompleted;
        }

        private PayMent _pay = new PayMent();
        private string finalBill = "";

        private void myWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            myWebBrowser.Print();
        }

        public void printBillHTML()
        {
            System.Threading.Thread t;
            t = new Thread(new ThreadStart(Printit));
            t.IsBackground = true;// the main form will close (when closing child form) if this is set .
            //t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public void saveBillPDF()
        {
            System.Threading.Thread t;
            t = new Thread(new ThreadStart(PrintitPDF));
            t.IsBackground = true;// the main form will close (when closing child form) if this is set .
            //t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void PrintitPDF()
        {
            PDFGenerator.GeneratePDFromHtml(finalBill, ApplicationSetting.BackUpFolder + @"\{0}.pdf".With(_pay.BillNumber));
        }

        private string GetFinalBill()
        {
            if (!_pay.PaymentData.Columns.Contains("Sno"))
            {
                _pay.PaymentData.Columns.Add("Sno");
            }
            int rn = 1;
            foreach (DataRow dr in _pay.PaymentData.Rows)
            {
                dr["Sno"] = rn++;
            }
            //formatDates
            if (!_pay.PaymentData.Columns.Contains("Days"))
            {
                _pay.PaymentData.Columns.Add("Days");
            }
            foreach (DataRow item in _pay.PaymentData.Rows)
            {
                int days = DateUtility.DateDiff(item[PayMent.PaymentColumns.OutDate].ToString(), item[PayMent.PaymentColumns.InDate].ToString()).Days;
                item["Days"] = days == 0 ? 1 : days;
                item[PayMent.PaymentColumns.InDate] = DateUtility.GetFormatedDate(item[PayMent.PaymentColumns.InDate], DateUtility.DisplayDateFormat);
                item[PayMent.PaymentColumns.OutDate] = DateUtility.GetFormatedDate(item[PayMent.PaymentColumns.OutDate], DateUtility.DisplayDateFormat);
            }

            Dictionary<string, string> replaces = new Dictionary<string, string>();
            List<string> conditionalRemove = new List<string>();
            replaces.Add("BillNo", _pay.BillNumber);
            replaces.Add("Date", _pay.Date);

            replaces.Add("CustomerName", _pay.CustomerName);
            replaces.Add("Cashier", _pay.Cashier);

            //summary
            replaces.Add("Total", StringUtilities.GetMoneyFromat(_pay.SumAmount.ToString()));
            replaces.Add("SumVAT", StringUtilities.GetMoneyFromat(_pay.Sumvat.ToString()));
            replaces.Add("SumSc", StringUtilities.GetMoneyFromat(_pay.Sumservicecharge.ToString()));
            replaces.Add("SumDiscount", StringUtilities.GetMoneyFromat(_pay.SumDiscount.ToString()));
            replaces.Add("SumNet", StringUtilities.GetMoneyFromat(_pay.SumnetAmount.ToString()));
            replaces.Add("SumDue", StringUtilities.GetMoneyFromat(_pay.SumdueAmount.ToString()));
            replaces.Add("Remainig", StringUtilities.GetMoneyFromat(_pay.RemainingAmount.ToString()));
            replaces.Add("Paid", StringUtilities.GetMoneyFromat(_pay.PaidAmount.ToString()));
            replaces.Add("Tax", StringUtilities.GetMoneyFromat(_pay.Sumvat.ToString()));

            if (!(_pay.Sumvat > 0))
            {
                conditionalRemove.Add("Tax");
            }
            //replaces.Add("Advance", _pay.);
            //replaces.Add("AdvanceRefund", _pay.BillNumber);
            //replaces.Add("Net", _pay.BillNumber);
            DataSet ds = new DataSet();
            ds.Tables.Add(_pay.PaymentData);
            // string template = ResourceHelper.ReadString("hotl.htm"); //System.IO.File.ReadAllText(@"hotl.fdb");
            string template = System.IO.File.ReadAllText(@"hotl.htm");
            string output = TemplateFiller.GetFilledText(template, replaces, ds, conditionalRemove);
            return output;
        }

        public void Printit()
        {
            string finalOutput = "";
            for (int i = 0; i < ApplicationSetting.Print_NoOfCopies; i++)
            {
                finalOutput = finalOutput + finalBill;
            }
            myWebBrowser.DocumentText = finalOutput;
        }
    }
}