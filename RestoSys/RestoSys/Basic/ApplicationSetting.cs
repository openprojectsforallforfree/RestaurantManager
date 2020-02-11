using Bsoft.AppCom;
using Bsoft.Common;

namespace RestoSys
{
    public static class ApplicationSetting
    {
        private static int vatPercent = -1;
        private static int serviceChargePercent = -1;
        private static bool printBill;
        private static string backupFolder;
        private static PrinterTypes printerType;
        private static int print_NoOfCopies = 0;
        private static bool print_SavePDF;

        static ApplicationSetting()
        {
            SetData();
        }

        public static void SetData()
        {
            printBill = ConstantValuesUtility.GetData("PrintBilll").ToLower() == "true" ? true : false;
            vatPercent = ConstantValuesUtility.GetData("VATPercent").ToInt();
            serviceChargePercent = ConstantValuesUtility.GetData("ServiceChargePercent").ToInt();
            backupFolder = ConstantValuesUtility.GetData("BackupFolder").ToString();
            printerType = ConstantValues.Print_PrinterType;
            print_NoOfCopies = ConstantValues.Print_NoOfCopies;
            print_SavePDF = ConstantValues.Print_SavePDF;
        }

        public static PrinterTypes PrinterType
        {
            get { return printerType; }
        }

        public static int Print_NoOfCopies
        {
            get { return print_NoOfCopies; }
        }

        public static bool Print_SavePDF
        {
            get { return print_SavePDF; }
        }

        public static int VatPercent
        {
            get
            {
                return vatPercent;
            }
            set
            {
                vatPercent = value;
                ConstantValuesUtility.SetData("VATPercent", vatPercent.ToString());
            }
        }

        public static int ServiceChargePercent
        {
            get
            {
                return serviceChargePercent;
            }
            set
            {
                serviceChargePercent = value;
                ConstantValuesUtility.SetData("ServiceChargePercent", serviceChargePercent.ToString());
            }
        }

        public static bool PrintBilll
        {
            get
            {
                return printBill;
            }
            set
            {
                printBill = value;
                ConstantValuesUtility.SetData("PrintBilll", value.ToString());
            }
        }

        public static string BackUpFolder
        {
            get
            {
                return backupFolder;
            }
            set
            {
                backupFolder = value;
                ConstantValuesUtility.SetData("BackupFolder", value.ToString());
            }
        }
    }
}