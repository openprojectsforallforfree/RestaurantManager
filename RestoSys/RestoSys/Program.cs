//#define Ticket
//#define Restaurant
#define Hotel
//#define Department
using Bsoft;
using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Data;
using Bsoft.Languages;
using RestoSys.MasterEntry;
using System;
using System.Drawing;
using System.Windows.Forms;
using UEMS.BLL;

namespace RestoSys
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
#if Restaurant
             ConstantValues.ProductName = "RMS";
#elif Ticket
            ConstantValues.ProductName = "TMS";
#elif Department
              ConstantValues.ProductName = "DMS";
#elif Hotel
             ConstantValues.ProductName = "HMS";
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetConstantValues();
            //RestoSys.MainForm_Ticket application = new RestoSys.MainForm_Ticket();

            frmAboutBox frmSplash = new frmAboutBox(true);
            frmSplash.UpdateDataStructure += new frmAboutBox.updateDataStructure(frmSplash_UpdateDataStructure);
            frmSplash.ShowDialog();

            if (args.Length > 0)
            {
                string[] commands = args[0].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                //update build number
                if (commands[0].ToDouble() > 0)
                {
                    ConstantValues.BuildNumber = commands[0].ToDouble();
                }
            }
#if Restaurant
              var application = new RestoSys.MainForm_Restaurant ();
#elif Ticket
            var application = new RestoSys.MainForm_Ticket();
#elif Department
               var application = new RestoSys.MainForm_Department ();
#elif Hotel
             var application = new RestoSys.MainForm_Hotel ();
#endif

            Application.Run(application);
        }

        private static void SetConstantValues()
        {
            Bsoft.Design.EntryFromDesignBase.DigitFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Bsoft.Design.EntryFromDesignBase.MainFont = new Font("Verdana", 10);
            Bsoft.Design.ListingFromDesignBase.DigitFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Bsoft.Design.ListingFromDesignBase.MainFont = new Font("Verdana", 10);

            Language.currentLanguage = LanguageChoice.English;
            GlobalValues.PSError = 500;
            //Set All application wide variables
            ConversionSql.dbEngine = RestoSys.Properties.Settings.Default.dbEngine;
            GlobalValues.DbPath = Bsoft.Data.DataGeneral.GetPathFromConnectionstring(RestoSys.Properties.Settings.Default.Configstring);
            GlobalValues.UseOrder = RestoSys.Properties.Settings.Default.UseOrder;
            staticClasses.SetConnectionString(RestoSys.Properties.Settings.Default.Configstring);
            string loglevel = RestoSys.Properties.Settings.Default.LogLevel.Trim();

            //DEBUG = 3
            //ERROR =  else
            //INFORMATION = 2
            //WARNING = 1

            if (loglevel == "3")
            {
                LogTraceToFile.TraceLogLevel = eTRACELEVEL.DEBUG;
            }
            else if (loglevel == "2")
            {
                LogTraceToFile.TraceLogLevel = eTRACELEVEL.INFORMATION;
            }
            else if (loglevel == "1")
            {
                LogTraceToFile.TraceLogLevel = eTRACELEVEL.WARNING;
            }
            else //(RestoSys.Properties.Settings.Default.LogLevel.Trim() == "3")
            {
                LogTraceToFile.TraceLogLevel = eTRACELEVEL.ERROR;
            }
        }



        private static void frmSplash_UpdateDataStructure(string test)
        {
            (new DMLUserRightsSimple()).UpdateStructure((new RestoSys.MainForm()).mnuStripMy);
            (new ChangeSpecificDBStructure()).UpdateStructure();
        }
    }
}