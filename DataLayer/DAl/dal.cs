using Bsoft.Data;
using System;
using System.Text;

namespace RestoSys.Inventory
{
    public static class dal
    {
        #region getvalues

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns> stock for given Inv_purchage Id </returns>
        public static double getStock(string ItemId)
        {
            try
            {
                StringBuilder SQL = new StringBuilder();
                SQL.Append("SELECT stock  from StockSumView where fk_Master_Product =" + ItemId);
                string quantity = "";
                quantity = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
                if (quantity != "")
                {
                    return Convert.ToDouble(quantity);
                }
            }
            catch
            {
                return 0;
            }
            return 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>unit symbol from unit id</returns>
        public static string getUnit(string id)
        {
            if (id.Length < 1)
            {
                return "";
            }
            string unit = "";
            StringBuilder SQL = new StringBuilder();

            SQL.Append("SELECT symbol from Master_Unit where id = " + id);
            try
            {
                unit = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            }
            catch { return ""; }

            return unit;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id">Master_Product_Company id</param>
        /// <returns>gets name of product company </returns>
        public static string getCompany(string id)
        {
            string cmpny = "";
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT Name from Master_Product_Company where id = " + id);
            try
            {
                cmpny = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            }
            catch { return ""; }
            return cmpny;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id">Master_Product_Group id</param>
        /// <returns>name of group</returns>
        public static string getGroup(string id)
        {
            string grp = "";
            StringBuilder SQL = new StringBuilder();
            SQL.Append("SELECT Name from Master_Product_Group where id = " + id);
            try
            {
                grp = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            }
            catch { return ""; }
            return grp;
        }

        #endregion getvalues

        #region validations

        public static string GetProductIdFromCode(string groupCode, string code)
        {
            string groupid;
            string product;
            try
            {
                groupid = GlobalResources.SelectDBConnection.ExecuteScalar("select id from Master_Product_Group where code = '" + groupCode + "'").ToString();
                StringBuilder SQL = new StringBuilder();
                SQL.Append("SELECT id from Master_Product where fk_Group = " + groupid + " and Code ='" + code + "'");
                product = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
            }
            catch { product = null; }
            return product;
        }

        #endregion validations

        public static void TruncateTransactionTables()
        {
            string sql = "delete from Inv_Purchase";
            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
            sql = "delete from Inv_Sale";
            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
            sql = "delete from Inv_Stock";
            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
            sql = "delete from Acc_Sale";
            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
            sql = "delete from Acc_CreditPayBack";
            GlobalResources.SelectDBConnection.ExecuteNonQuery(sql);
        }
    }
}