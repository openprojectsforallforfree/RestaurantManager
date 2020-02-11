using Bsoft.Common;
using Bsoft.Data;
using System;
using System.Data;
using System.Text;

namespace RestoSys.BLL
{
    public class PurchageTable
    {
        public static void InsertORUpdatePurchase(string productId, string costprice, string sellingprice, int quantity)
        {
            string sql = @"select count(*) from Inv_Purchase WHERE fk_Product = {0} ".With(productId);

            if (GlobalResources.SelectDBConnection.ExecuteScalar(sql).ToInt() > 0)
            {
                UpdatePurchase(productId, costprice, sellingprice, quantity);
            }
            else
            {
                InsertPurchase(productId, costprice, sellingprice, quantity);
            }
        }

        public static void InsertPurchase(string productId, string costprice, string sellingprice, int quantity)
        {
            string sql = @"INSERT INTO Inv_Purchase
                    (
                    ManufactureDate,
                    ExpiryDate,
                    fk_Product,
                    fk_Vendor,
                    Quantity,
                    CostPrice,
                    SellingPrice,
                    PurchageDate,
                    Remarks,
                    UserId,
                    entrydate
                    )
                    VALUES
                    (
                    NULL,NULL,{0},NULL,
                    {1},{2},{3},'{4}',
                    '',1,'{5}'
                    )".With(productId,
                      quantity.ToString(), costprice, sellingprice, DateTime.Now.ToString("yyyyMMdd"),
                      DateTime.Now.ToString("yyyyMMdd"));

            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
        }

        public static void UpdatePurchase(string productId, string costprice, string sellingprice, int quantity)
        {
            string sql = @"UPDATE Inv_Purchase SET
                            Quantity = {1},
                            CostPrice = {2},
                            SellingPrice = {3},
                            Remarks = '',
                            entrydate = '{4}'
                            WHERE fk_Product = {0} ".With(productId,
                      quantity.ToString(), costprice, sellingprice, DateTime.Now.ToString("yyyyMMdd"));

            int retval = GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
        }

        public static string GetProductId(string purchaseId)
        {
            string sql = @"SELECT fk_product from Inv_Purchase
                            WHERE id = {0} ".With(purchaseId);

            return GlobalResources.SelectDBConnection.ExecuteScalar(sql).ToString();
        }

        public static double Getquantity(int id)
        {
            string quantity = "";
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT quantity_instore from Master_Product where id = " + id.ToString());
            try
            {
                quantity = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            }
            catch { }
            if (quantity != "")
            {
                return Convert.ToDouble(quantity);
            }
            return 0;
        }

        public static int GetLatestID()
        {
            string id;
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT max(id) from Inv_Purchase");
            id = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            return Convert.ToInt16(id);
        }

        public static DataTable GetProduct(string productId)
        {
            ////Make changes here to get all the data using the following logic
            ////DT From inv_purchage get stock of all rows with productId
            DataTable product;
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT * from Master_Product where id = " + productId);
            try
            {
                product = GlobalResources.SelectDBConnection.ExecuteDataTable(SQL.ToString());
            }
            catch
            {
                product = null;
            }
            return product;
        }

        //public static void AddquantityTOStore(string productID,string tquantity)
        //{
        //    int id;
        //    double quantity;
        //    id =PurchageTable.GetLatestID ();
        //    id = Convert.ToInt16(productID);
        //    quantity = PurchageTable.Getquantity(id);
        //    quantity += Convert.ToDouble(tquantity);

        //    StringBuilder SQL = new StringBuilder();
        //    SQL.Append("UPDATE Master_Product set quantity_instore = ");
        //    SQL.AppendFormat(" {0} ", quantity);
        //    SQL.AppendFormat("where id = {0} ", id.ToString());
        //    GlobalResources.SelectDBConnection.ExecuteNonQuery(SQL.ToString()).ToString();

        //}
    }
}