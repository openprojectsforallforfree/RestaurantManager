using Bsoft.Common;
using Bsoft.Data;
using System.Text;

namespace RestoSys.MasterEntry
{
    public  class staticClasses
    {
        public static void SetConnectionString(string conString)
        {
            GlobalResources.ConnectionString = conString;
        }

        public static string GetUnit(string id)
        {
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

        public static string GetGroupCode(string groupId)
        {
            string code = GlobalResources.SelectDBConnection.ExecuteScalar("select code from Master_Product_Group where id = {0} ".With(groupId)).ToString() ?? "";
            return code;
        }
    }
}