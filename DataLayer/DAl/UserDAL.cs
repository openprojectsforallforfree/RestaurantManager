using Bsoft.Data;
using System.Text;

namespace RestoSys.DAl
{
    public static class UserDAL
    {
        public static string GetUserId(string Id)
        {
            string name = "";
            if (Id.Length > 0)
            {
                try
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append(string.Format("SELECT userID  FROM SuperAdmin_Rights_Users where id='{0}'", Id));
                    name = GlobalResources.SelectDBConnection.ExecuteScalar(SQL.ToString()).ToString();
                }
                catch
                {
                    throw;
                }
            }

            return name;
        }
    }
}