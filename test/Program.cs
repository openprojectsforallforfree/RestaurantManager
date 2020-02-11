using Bsoft.Data;
using Bsoft.Tools;
using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConversionSql.dbKind = databaseKind.SQLite;
            GlobalResources.ConnectionString = "foreign keys=True; Data Source=ticket;";//RestoSys.Properties.Settings.Default.Configstring;

            General g = new General();
            g.createGeneral_unit2();

            Application.Run(new frmDbTool());
        }
    }

    internal class General
    {
        public void createGeneral_unit2()
        {
            if (!GlobalResources.DbStruct.DoesTableExists("Master_Unit"))
            {
                DbHelpers.CreateATable(@"
                        CREATE TABLE Master_Unit(
                        Id Integer primary key autoincrement ,
                        Unit varchar(15),
                        Symbol varchar(15),
                        Master_UnitCategoryId Integer,
                        Factor varchar(15)
                       )");

                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Unit NA','', 1,'Not Applicable')");
                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('KiloGram','Kg', 2,1)");
                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Gram','gm', 2,0.001)");
                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('MiliGram','mg', 2,0.001)");

                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Centimeter','Cm',3,1)");
                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Meter','m', 3,100)");
                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Kilometer','Km', 3,1000)");

                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Liter','lt', 4,1)");

                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Packets','Pkt', 5,1)");
                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Numbers','Nos', 5,1)");
                GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Plates','Plt', 5,1)");
            }
        }
    }
}