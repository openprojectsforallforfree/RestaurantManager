using Bsoft.Data;
using System;
using System.Data;

namespace RestoSys.BLL
{
    public class ExpiryAlert
    {
        public static DataTable GetExpringItemsDetails(DateTime date)
        {
            string sql = string.Format(@"SELECT * FROM PurchaseRptView where ExpiryDate >= '{0}'", date.ToString("yyyyMMdd"));
            DataTable dt = GlobalResources.SelectDBConnection.ExecuteDataTable(sql);
            return dt;
        }
    }
}