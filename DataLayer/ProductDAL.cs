using Bsoft.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataLayer
{
  public static   class ProductDAL
    {
      public static DataTable GetDataForSalesReturn(string productId)
      {
          string sql = string.Format(@"
                            select t1.id salesid,
                            Inv_Purchase.id as purchaseid  ,
                            t1.date as [Selling
                            Date],
                            cast (t1.quantity as decimal(10,2)) as Quantity,
                            cast (t1.salesreturn as decimal(10,2))  as [Sales
                            Return],
                            cast (t1.rate as decimal(10,2))  as MRP ,
                            cast (t1.discount as decimal(10,2)) as [Discount
                            Given],
                            cast (t1.netamount as decimal(10,2)) as Amount,
                            SuperAdmin_Rights_Users.ENGNAME as username ,
                            t1.remarks from Inv_Sale t1
                             left outer join Inv_Purchase on
                             Inv_Purchase.id = t1.fk_Purchage
                             left outer join Master_Product on
                             Master_Product.id = Inv_Purchase.fk_Product
                             left outer join SuperAdmin_Rights_Users on
                             SuperAdmin_Rights_Users.id = t1.UserId
                             where t1.date >= '{0}'
                            AND t1.date <= '{1}'
                            and t1.fk_product = {2}
                        ", DateTime.Now.AddDays(-30).ToString("yyyyMMdd"),
                   DateTime.Now.ToString("yyyyMMdd"),
                  productId);

          DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sql);
          
          return dt;
      }
      public static DataTable GetProductDt(string productId)
      {
          StringBuilder SQL = new StringBuilder();
          SQL.Append("SELECT * from Master_Product where id = " + productId);
          DataTable productddt = GlobalResources.SelectDBConnection.ExecuteDataTable(SQL.ToString());
          return productddt;
      }
        public static string GetCode(string KEY)
        {
            string code;
            StringBuilder SQL = new StringBuilder ();
            SQL.Remove(0, SQL.Length);
            SQL.Append("select code from Master_Product");
            SQL.AppendFormat("\n WHERE  id = {0}", KEY);
            code = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            return code;
        }

        public static string GetGroupCode(string GroupId)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Remove(0, SQL.Length);
            SQL.Append("select code from Master_Product_Group");
            SQL.AppendFormat("\n WHERE  id = {0}", GroupId);
            string GroupCode = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            return GroupCode;
        }

        public static string GetGroupId(string KEY)
        {
            var SQL = new StringBuilder();

            //Group  id
            SQL.Remove(0, SQL.Length);
            SQL.Append("select fk_Group from Master_Product");
            SQL.AppendFormat("\n WHERE  id = {0}", KEY);
         string    GroupId = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            return GroupId;
        }
    }
}
