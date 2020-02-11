using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestoSys.Tags
{
    public static class clsTag
    {
    
        public static DataTable GetTagGroup()
        {
            string sql = "select * from taggroup";
            DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sql);
            return dt;
        }

        private static DataTable _TagGroups = new DataTable();

        static clsTag()
        {
            string sql = @"
                select tg.id Id,tg.title title, tg.remarks Remarks, tt.Title Type from taggroup tg
                left join  TagType  tt on
                tt.Id = tg.TagTypeId ";
            _TagGroups = GlobalResources.SelectDBConnection.ExecuteDataTable(sql);
        }

        public static DataTable TagGroups
        {
            get
            {
                return _TagGroups;
            }
        }

        public static DataTable tags(string grpID)
        {
            string sql = "select Value from  tag where TagGroupId =" + grpID;
            DataTable tags = GlobalResources.SelectDBConnection.ExecuteDataTable(sql);
            return tags;
        }

        public static bool SaveData(string ItemId, DataTable dt)
        {
            string sql = "DELETE FROM Item_Tag where ItemId = " + ItemId;
            SetTagId(dt);
            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                sql = "INSERT INTO Item_Tag (TagId,ItemId) VALUES({0},{1})".With(dr["TagId"].ToString(), ItemId);
                GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
            }
            return true;
        }

        private static void SetTagId(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string sqlSelect = "SELECT Id FROM TAG WHERE TagGroupId ='{0}' and Value ='{1}' ".With(dr["TagGrpId"].ToString(), dr["TagValue"].ToString());
                string tagid = string.Empty;
                try
                {
                    tagid = GlobalResources.SelectDBConnection.ExecuteScalar(sqlSelect).ToString();
                }
                catch
                {
                    string sqlInsert = @"INSERT INTO Tag
    (  TagGroupId, Value)
VALUES
    ( '{0}','{1}')".With(dr["TagGrpId"].ToString(), dr["TagValue"].ToString());
                    GlobalResources.SelectDBConnection.ExecuteNonQuery(sqlInsert).ToString();
                    tagid = GlobalResources.SelectDBConnection.ExecuteScalar(sqlSelect).ToString();
                }
                dr["TagId"] = tagid;
            }
        }

        public static DataTable GetTags(string ItemId)
        {
            string sql = @"select it.id,it.TagId tagid,t.TagGroupId Taggroupid,t.value value from item_tag it
left join tag t on t.id = it.TagId
where it.ItemId =" + ItemId;
            DataTable tags = GlobalResources.SelectDBConnection.ExecuteDataTable(sql);
            return tags;
        }
    }

    public static class clsDataAccess
    {
        public static int GetRecordCount(string table)
        {
            return GlobalResources.SelectDBConnection.GetRecordCount(table).ToInt();
        }
        public static bool IsNewCode(string GroupId, string code)
        {
            //return true;
            //returns if the code is valid ( unique )
            // code should be unique for the selected group but can repeat in itself
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select * from Master_Product where fk_Group = {0} and code = '{1}' ", GroupId, code);


            DataTable dt = new DataTable();
            dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sql.ToString());
            if (dt == null || dt.Rows.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable GetDataForTree(string parentTable, string childTable, string parentCol, string childCol, string parentReferenceIdCol, string parentdisplayCol, string childdisplayCol)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT p.{0} p_{0},c.{1} c_{1},p.{2} p_{2} ,c.{3} c_{3}  ", parentCol, childCol, parentdisplayCol, childdisplayCol);
            //select p.id  pid, c.id cid,p.Title ,c.Unit
            // from units c left join Master_UnitCategory p on p.id = c.Master_UnitCategoryId

            sb.AppendFormat(" FROM {0} c left join {1} p on p.{2}  = c.{3}", childTable, parentTable, parentCol, parentReferenceIdCol);
            sb.AppendFormat(" ORDER BY p.{0}", parentCol);
            DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sb.ToString());
            return dt;
        }
        public static DataTable GetHotelBookingList(List<string> accids)
        {
            string newSql = @"
            select
            --accid,
            CustomerName as 'Customer Name',
            ProductName as 'Room',
            bookingstaus as 'Booking Status',
            rate as 'Rate',
            Quantity as 'PAX',
            amount as 'Amount',
            discount as 'Discount',
            --vat,
            --servicecharge,
            netamount as 'Net',
            dueamt as 'Currently Due',
            netamount-dueamt as 'Total Paid Amount'
            --date as 'Date',
            --UserId as 'User'
            from Hotel_Sales_View
            where  1=2 or {0}".With(string.Join(" or ", accids.ToArray()));
            DataTable dtnew = GlobalResources.SelectDBConnection.ExecuteDataTable(newSql);
            return dtnew;
        }


        public static int UpdateRefundSalesReturn(string salesId, double CumulativeSalesReturn, double refundAmount)
        {
            string updateSql = string.Format("update inv_sale set salesreturn = '{0}' where id = {1}", CumulativeSalesReturn, salesId);
            int retval = GlobalResources.SelectDBConnection.ExecuteNonQuery(updateSql.ToString());

            // enter in Acc_Sale

            string accSql = @"  INSERT INTO Acc_Sale ( Amount,Discount,TenderAmount,ReturnAmount,ServiceCharge,VAT,Date,UserId )
                                    values 
                                    ({0},{1},{2},{3},{4},{5},'{6}','{7}') ".With(-1 * refundAmount, 0, -1 * refundAmount, 0, 0, 0, GlobalValues.CurrentDate, GlobalValues.LoginUserName);

            GlobalResources.SelectDBConnection.ExecuteNonQuery(accSql);
            return retval;
        }

        public static void UpdateAccoount(decimal dueamount, decimal creditamount, string creditId)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Append("UPDATE Acc_Sale set DueAmount = ");
            SQL.AppendFormat(" {0} ", dueamount.ToString());
            SQL.AppendFormat("where id = {0} ", creditId);
            GlobalResources.SelectDBConnection.ExecuteNonQuery(SQL.ToString()).ToString();
        }
        public static DataSet isProductExist(string productId)
        {
            DataSet product;
            StringBuilder SQL = new StringBuilder();

            SQL.Append("SELECT * from Master_Product where id = " + productId);
            try
            {
                product = GlobalResources.SelectDBConnection.ExecuteDataSet(SQL.ToString());
            }
            catch { product = null; }
            return product;
        }

        public static void UpdateRoom()
        {
            DataTable dttypes = GlobalResources.SelectDBConnection.ExecuteDataTable("select * from Hotel_RoomType");
            foreach (DataRow item in dttypes.Rows)
            {
                string sql = string.Format("update hotel_master_room set fk_hotel_roomtype = {0} where remarks = '{1}'",
                    item["id"].ToString(), item["Title"].ToString());
                GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
            }
        }


        public static double getquantity(string id)
        {
            string quantity;
            StringBuilder SQL = new StringBuilder();

            SQL.Append("SELECT quantity_instore from Master_Product where id = " + id.ToString());
            quantity = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            if (quantity != "")
            {
                return Convert.ToDouble(quantity);
            }
            return 0;
        }

        public static string getDamagequantity(string id)
        {
            string quantity;
            StringBuilder SQL = new StringBuilder();
            try
            {
                SQL.Append("SELECT quantity_damage from Master_Product where id = " + id.ToString());
                quantity = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
                if (quantity != "")
                {
                    return quantity;
                }
            }
            catch
            {
                return "0";
            }
            return "0";
        }
        public static void UpdateDamaged(string id, double totaldamagequantity)
        {
            StringBuilder SQL1 = new StringBuilder();
            SQL1.Append("UPDATE Master_Product set quantity_damage = ");
            SQL1.AppendFormat(" {0} ", totaldamagequantity);
            SQL1.AppendFormat("where id = {0} ", id.ToString());
            GlobalResources.SelectDBConnection.ExecuteNonQuery(SQL1.ToString()).ToString();
        }

        public static void UpdateProduct(string id, double quantityinstore)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Append("UPDATE Master_Product set quantity_instore = ");
            SQL.AppendFormat(" {0} ", quantityinstore);
            SQL.AppendFormat("where id = {0} ", id.ToString());
            GlobalResources.SelectDBConnection.ExecuteNonQuery(SQL.ToString()).ToString();
        }

        public static string GetCode(string prodid)
        {
            StringBuilder SQL;
            SQL = new StringBuilder();
            string itemCode;
            SQL.Remove(0, SQL.Length);
            SQL.Append("select code from Master_Product");
            SQL.AppendFormat("\n WHERE  id = {0}", prodid);
            itemCode = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            return itemCode;
        }

        public static string GetGroupCode(string GroupId)
        {
            StringBuilder SQL;
            SQL = new StringBuilder();
            string groupCode;
            SQL.Remove(0, SQL.Length);
            SQL.Append("select code from Master_Product_Group");
            SQL.AppendFormat("\n WHERE  id = {0}", GroupId);
            groupCode = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            return groupCode;
        }

        public static string GetGroupId(string prodid)
        {
            StringBuilder SQL;
            SQL = new StringBuilder();
            SQL.Append("select fk_Group from Master_Product");
            SQL.AppendFormat("\n WHERE  Master_Product.id = {0}", prodid);
            string GroupId = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            return GroupId;
        }

        public static DataTable GetDataProduct(string productId)
        {
            string sql = @"
SELECT
PurchaseRptView.Inv_PurchaseId as purchaseid,
PurchaseRptView.Inv_Purchase_entrydate  as [Purchage Date],
cast (PurchaseRptView.MRP as decimal(10,2))  as MRP,
cast (PurchaseRptView.Cost  as decimal(10,2))  as costprice,
cast (PurchaseRptView.purchageQuantity  as decimal(10,2))  as QTY,
cast ( PurchaseRptView.SoldQuantity  as decimal(10,2))*-1 as SOLD ,
PurchaseRptView.stock   as Stock,
PurchaseRptView.ManufactureDate as [Mnf Date],
PurchaseRptView.ExpiryDate  as [Ex Date],
PurchaseRptView.VendorName [vendor Name],
PurchaseRptView.purchageRemarks  as  remarks from PurchaseRptView
where PurchaseRptView.ProductId ={0} and  stock > 0

                ".With(productId);

            DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sql.ToString());
            return dt;
        }

        public static DataTable GetDataForLoadTree(string tableName, string parentCol)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * from {0} order by {1}", tableName, parentCol);
            DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sb.ToString());
            return dt;
        }


        public static string GetDetails(string id)
        {
            return GlobalResources.SelectDBConnection.ExecuteScalar("select remarks from {0} where id = '{1}'".With("Dev_Item_Type", id)).ToString();
        }
        public static string GetDetail(string value)
        {
            string detail = GlobalResources.SelectDBConnection.ExecuteScalar("Select Remarks from taggroup where id = " + value).ToString();
            if (detail.Trim() == "")
            {
                detail = GlobalResources.SelectDBConnection.ExecuteScalar("Select Title from taggroup where id = " + value).ToString();
            }
            return detail;
        }
    }
}