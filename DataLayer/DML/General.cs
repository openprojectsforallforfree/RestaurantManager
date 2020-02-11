﻿using Bsoft.Data;
using System.Text;

namespace RestoSys.BLL
{
    internal class General
    {
        public void createGeneral_unit2()
        {
            int Rslt = 0;
            if (!GlobalResources.DbStruct.DoesTableExists("Master_UnitCategory"))
            {
                StringBuilder SQLCreate = new StringBuilder();
                SQLCreate.Remove(0, SQLCreate.Length);
                SQLCreate.AppendLine(" CREATE TABLE Master_UnitCategory( ");
                SQLCreate.AppendLine(" \n Id Integer primary key autoincrement ");
                SQLCreate.AppendLine(" \n, Title varchar(50) UNIQUE");
                SQLCreate.AppendLine(" \n, Remarks varchar(150) )");
                DbHelpers.CreateATable(SQLCreate.ToString());
                //Insert some default values
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_UnitCategory (Title,Remarks)  VALUES('Category NA','Not Applicable')");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_UnitCategory (Title,Remarks)  VALUES('Weight','')");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_UnitCategory (Title,Remarks)  VALUES('Length','')");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_UnitCategory (Title,Remarks)  VALUES('Volume','')");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_UnitCategory (Title,Remarks)  VALUES('Quantity','To measure Packets ,Numbers etc')");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_UnitCategory (Title,Remarks)  VALUES('Area','')");
            }
            if (!GlobalResources.DbStruct.DoesTableExists("Master_Unit"))
            {
                DbHelpers.CreateATable(@"
                        CREATE TABLE Master_Unit(
                        Id Integer primary key autoincrement ,
                        Unit varchar(15),
                        Symbol varchar(15),
                        Master_UnitCategoryId Integer,
                        Factor varchar(15),
                        ParentId Integer,CONSTRAINT FK_Master_UnitCategory_Master_UnitCategoryId FOREIGN KEY (Master_UnitCategoryId) REFERENCES Master_UnitCategory (Id),
                        CONSTRAINT FK__ParentId FOREIGN KEY (ParentId) REFERENCES  Master_Unit(Id))");

                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Unit NA','', 1,'Not Applicable')");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('KiloGram','Kg', 2,1)");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Gram','gm', 2,0.001)");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('MiliGram','mg', 2,0.001)");

                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Centimeter','Cm',3,1)");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Meter','m', 3,100)");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Kilometer','Km', 3,1000)");

                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Liter','lt', 4,1)");

                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Packets','Pkt', 5,1)");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Numbers','Nos', 5,1)");
                Rslt = GlobalResources.DbStruct.Con.ExecuteNonQuery("INSERT INTO Master_Unit (Unit,Symbol,Master_UnitCategoryId,Factor)  VALUES('Plates','Plt', 5,1)");
            }

            if (!GlobalResources.DbStruct.DoesViewExists("UnitView"))
            {
                DbHelpers.createAView("UnitView", @"
                        SELECT
                          t1.Id Id,
                          t1.Unit Unit,
                          t1.Symbol Symbol,
                          t3.Title Categogy,
                          t1.Factor Factor
                          FROM Master_Unit t1
                          left join Master_UnitCategory t3 on t1.Master_UnitCategoryId = t3.Id
                        ");
            }
        }
    }
}