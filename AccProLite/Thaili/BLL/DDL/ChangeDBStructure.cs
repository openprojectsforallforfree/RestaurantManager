using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Bsoft.Common;
using Bsoft.Controls;
using Friuts;
using Bsoft.Data;
using System.Data;
using UEMS.BLL.View;
using Bsoft.Forms;

//Help use following syntax for the ANSI standard
//CREATE TABLE Orders
//(
//O_Id int NOT NULL,
//OrderNo int NOT NULL,
//P_Id int,
//PRIMARY KEY (O_Id),
//CONSTRAINT fk_PerOrders FOREIGN KEY (p_id)
//REFERENCES questiontype(Id)
//)


namespace UEMS.BLL
{
    public partial  class ChangeDBStructure
    {
        #region Member variables.Constructors & Finalizers.
        StringBuilder SQL = new StringBuilder();

       
        public ChangeDBStructure()
        {
             
            //Dhirajdb
            switch (Properties.Settings.Default.DbEngine.ToLower().Trim())
            {
                case "sqlite":
                    // GlobalResources.DbStruct.dbengine = DataBaseEngine.SQLite;
                    ConversionSql .dbKind  = databaseKind .SQLite;
                    break;
                case "oracle":
                    //  GlobalResources.DbStruct.dbengine = DataBaseEngine.Oracle;
                    ConversionSql.dbKind = databaseKind.Oracle;
                    break;
                case "sqlserver":
                    // GlobalResources.DbStruct.dbengine = DataBaseEngine.SQLServer;
                    ConversionSql.dbKind = databaseKind.SQLServer;
                    break;
                case "msaccess":
                    // GlobalResources.DbStruct.dbengine = DataBaseEngine.MsAccess;
                    ConversionSql.dbKind = databaseKind.MsAccess;
                    break;
            }
        }
        #endregion

        #region Methods


        

        private void createATable(string Query)
        {
            //SQLCreate.Append(" \n, fk_UserID number ");
            //SQLCreate.Append(" \n, fk_UserIDE number ");
            //SQLCreate.Append(" \n, DATAENTRYVSDATE NVARCHAR2 (10)");
            //SQLCreate.Append(" \n, DATAENTRYADDATETIME NVARCHAR2 (10)");
            string tableName = "";
            tableName = Query.Substring(0, Query.IndexOf('(')).ToLower();
            tableName = tableName.Replace("create", "");
            tableName = tableName.Replace("table", "");
            tableName = tableName.Trim();
            StringBuilder SQLCreate = new StringBuilder();

            int Rslt = 0;

            Rslt = GlobalResources.SelectDBConnection .ExecuteNonQuery(Query);
            if (Rslt != -1)
                LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, tableName + " table created Successfully. ");
            else
            {
                MessageBoxMy.Show(tableName + " could not be created");
                LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name,"Not created ==================>"+ tableName + "  ");
                
            }

        }
              
        public void createBasicDataStructure()
        {
            StringBuilder SQLCreate = new StringBuilder();
           
            int Rslt = 0;



          
            if (!GlobalResources.DbStruct.DoesTableExists("Organization"))
            {
                SQLCreate.Remove(0, SQLCreate.Length);
                SQLCreate.AppendLine(" CREATE TABLE Organization( ");
                SQLCreate.AppendLine("Id Varchar(32) primary key  ,");
                SQLCreate.AppendLine(" Name varchar(150) Unique,");
                SQLCreate.AppendLine(" Phone varchar(50),");
                SQLCreate.AppendLine(" Fax varchar(50),");
                SQLCreate.AppendLine(" Url varchar(50),");
                SQLCreate.AppendLine(" Email varchar(50),");
                SQLCreate.AppendLine(" AddressLine1 varchar(50),");
                SQLCreate.AppendLine(" AddressLine2 varchar(50),");
                SQLCreate.AppendLine(" AddressLine3 varchar(50),");
                SQLCreate.AppendLine(" AddressLine4 varchar(50))");
                createATable(SQLCreate.ToString());
            }
            //if (!GlobalResources.DbStruct.DoesTableExists("ConstantValues"))
            //{
            //    SQLCreate.Remove(0, SQLCreate.Length);
            //    SQLCreate.Append(" CREATE TABLE ConstantValues(");
            //    SQLCreate.Append("\n  SN number (4) unique");
            //    SQLCreate.Append("\n , VarName VARCHAR2 (50)");
            //    SQLCreate.Append("\n , StrValue VARCHAR2 (100))");
            //    Rslt = GlobalResources.SelectDBConnection  .ExecuteNonQuery(SQLCreate.ToString());
            //    Status = true;
            //    LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "ConstantValues table created Successfully.  ");
            //}
            if (!GlobalResources.DbStruct.DoesTableExists("ConstantValues"))
            {
                SQLCreate.Remove(0, SQLCreate.Length);
                SQLCreate.Append(" CREATE TABLE ConstantValues( ");
                SQLCreate.Append(" \n Id INTEGER primary key AUTOINCREMENT ");
                SQLCreate.Append(" \n, VariableName varchar(50) ");
                SQLCreate.Append(" \n, Value varchar(150) )");
                createATable(SQLCreate.ToString());
                SQLCreate.Remove(0, SQLCreate.Length);
                SQLCreate.Append("INSERT INTO ConstantValues (VariableName,Value)  VALUES('RegistrationKey','Un-Registered')");
                SQLCreate.Append("INSERT INTO ConstantValues (VariableName,Value)  VALUES('FirstKey','Un-Registered')");
                GlobalResources.SelectDBConnection .ExecuteNonQuery(SQLCreate.ToString());
            }

            //if (!GlobalResources.DbStruct.DoesTableExists("Rights_Users"))
            //{
            //    SQLCreate.Remove(0, SQLCreate.Length);
            //    SQLCreate.AppendLine(" CREATE TABLE Rights_Users( ");
            //    SQLCreate.AppendLine("Id integer primary key AUTOINCREMENT ,");
            //    SQLCreate.AppendLine(" Name varchar(50),");
            //    SQLCreate.AppendLine(" LastName varchar(50),");
            //    SQLCreate.AppendLine(" Userid varchar(50) Unique,");
            //    SQLCreate.AppendLine(" Email varchar(50),");
            //    SQLCreate.AppendLine(" Phone varchar(50),");
            //    SQLCreate.AppendLine(" Pw varchar(50),");
            //    SQLCreate.AppendLine(" Address varchar(150))");
            //    //SQLCreate.AppendLine(" fk_Group int,");
            //    //SQLCreate.AppendLine(" CONSTRAINT c1_fk_Group FOREIGN KEY (fk_Group) REFERENCES Rights_Group_Master (id)) ");
            //    createATable(SQLCreate.ToString());

            //    SQLCreate.Remove(0, SQLCreate.Length);
            //    SQLCreate.Append("INSERT INTO Rights_Users (Name,LastName,Userid,Email,Phone,Pw,Address)  VALUES('Admin','','ADMIN','','', '3mlJcyGH6312vDYaUbAe+A==','')");
            //    GlobalResources.SelectDBConnection .ExecuteNonQuery(SQLCreate.ToString());


               

            //}
            if (!GlobalResources.DbStruct.DoesTableExists("Objective"))
            {
                SQLCreate.Remove(0, SQLCreate.Length);
                SQLCreate.AppendLine(" CREATE TABLE Objective( ");
                SQLCreate.AppendLine("Id integer primary key AUTOINCREMENT ,");
                SQLCreate.AppendLine(" Title Varchar(32))");
                Rslt = GlobalResources.SelectDBConnection .ExecuteNonQuery(SQLCreate.ToString());
                LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Objective table created Successfully. ");
             
            }

            if (!GlobalResources.DbStruct.DoesTableExists("NGO"))
            {
                SQLCreate.Remove(0, SQLCreate.Length);
                SQLCreate.AppendLine(" CREATE TABLE NGO( ");
                SQLCreate.AppendLine("Id Integer primary key AUTOINCREMENT ,");
                SQLCreate.AppendLine(" Guid Varchar(32),");
                SQLCreate.AppendLine(" Name varchar(50),");
                SQLCreate.AppendLine(" EnglishName varchar(50),");
                SQLCreate.AppendLine(" Address varchar(150),");
                SQLCreate.AppendLine(" Date varchar(15),");
                SQLCreate.AppendLine(" WorkingArea varchar(150),");
                SQLCreate.AppendLine(" Acronym varchar(50),");
                SQLCreate.AppendLine(" Phone varchar(50),");
                SQLCreate.AppendLine(" Fax varchar(50),");
                SQLCreate.AppendLine(" Email varchar(50),");
                SQLCreate.AppendLine(" WebSite varchar(50),");
                SQLCreate.AppendLine(" MobileNo varchar(50),");
                SQLCreate.AppendLine(" President Integer,");
                SQLCreate.AppendLine(" ContactPerson Integer,");
                SQLCreate.AppendLine(" EstablishedDate varchar(15),");
                SQLCreate.AppendLine(" LastAgmDate varchar(15),");
                SQLCreate.AppendLine(" Parikalpana varchar(250),");
                SQLCreate.AppendLine(" Dhyaye varchar(250),");
                SQLCreate.AppendLine(" Lakshya varchar(250),");
                SQLCreate.AppendLine(" Udeshya varchar(250),"); SQLCreate.AppendLine("  CONSTRAINT FK_Unique_Guid FOREIGN KEY (Guid) REFERENCES Unique (Id))");
                Rslt = GlobalResources.SelectDBConnection .ExecuteNonQuery((SQLCreate.ToString()));
                LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "NGO table created Successfully. ");
              
            }

           
        }

        public void UpdateStructure()
        {
           // CreateFiscalYearData();
           // createBasicDataStructure();
           // createNgorMasterDataStructure();
           // otherMaster();
           // createAddressDataStructure();
           // BasicDb();
           //JoinDb();
           CreateUserRightsSimple();
           NGORView view = new NGORView();
           view.createViewsForNGOR();
           // NgorprincpalDb();
            //createSchoolDataStructure();
            //createThailiDataStructure();
            //createViews();

            #region Previous
            //this below example is pass the table name and colun where not sn column and id column
            //only pass table column sequence create..
            // NOT REQUIRED GlobalResources.DbStruct.AddNumberColumn("PeSummaryLedgers", "DepreciationAmount", 12, 2);
            //if (GlobalResources.DbStruct.DoesTableExists("USERS"))
            //{
            //    string exist = "yes";
            //    if (!GlobalResources.DbStruct.DoesColumnExists("IPTADDTIONALCHARGES", "Service_Charge_percent"))
            //    {
            //        GlobalResources.DbStruct.AddNumberColumn("IPTADDTIONALCHARGES", "Service_Charge_percent", 5, 3);
            //        GlobalResources.DbStruct.AddNumberColumn("IPTADDTIONALCHARGES", "flat_charge_rate", 10, 3);
            //        GlobalResources.DbStruct.AddNumberColumn("IPTADDTIONALCHARGES", "isapplicableforhouse", 3, 0);
            //    }
            //}
            //else
            //{
            //    string exist = "no";
            //}


            //all the table Sequenc is created           
            //if (GlobalResources.DbStruct.AllTableGenerateSequence())
            //{
            //    LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name
            //    , "All the Have SN/ID Column table Sequence Create Successfully");
            //}
            ////===================================================26-May-2009

            GlobalResources.DbStruct.GetServerDate();

            #endregion
           
        }
        #endregion

        //private void createDb()
        //{
        //    String str;
        //    SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

        //    str = "CREATE DATABASE MyDatabase ON PRIMARY " +
        //        "(NAME = MyDatabase_Data, " +
        //        "FILENAME = 'C:\\MyDatabaseData.mdf', " +
        //        "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
        //        "LOG ON (NAME = MyDatabase_Log, " +
        //        "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
        //        "SIZE = 1MB, " +
        //        "MAXSIZE = 5MB, " +
        //        "FILEGROWTH = 10%)";

        //    SqlCommand myCommand = new SqlCommand(str, myConn);
        //    try
        //    {
        //        myConn.Open();
        //        myCommand.ExecuteNonQuery();
        //        MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    finally
        //    {
        //        if (myConn.State == ConnectionState.Open)
        //        {
        //            myConn.Close();
        //        }
        //    }


        //}

    }
}





