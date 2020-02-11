using System;

namespace Bsoft.CrystalReport
{
    public static class CommonReportClass
    {
        #region Member Variables

        #endregion Member Variables

        #region Properties

        #endregion Properties

        //Assign as single quote in a string
        public static string SQuote(string strToQuote)
        {
            if (strToQuote.Trim().Length > 0)
            {
                return "'" + strToQuote.Replace(Environment.NewLine, "  ") + "'";
            }
            else
            {
                return "''";
            }
        }

        public static string SQuote(object strToQuote)
        {
            if (strToQuote.ToString().Trim().Length > 0)
            {
                return "'" + strToQuote.ToString().Replace(Environment.NewLine, "  ") + "'";
            }
            else
            {
                return "''";
            }
        }

        //Takes decimal value and sends Crystal Report as numeric value
        public static string CrNumber(string numericValue)
        {
            if (numericValue.Trim().Length > 0)
            {
                return "'" + numericValue + "'";
            }
            else
            {
                return "'" + 0 + "'";
            }
        }

        public static string CrNumber(object numericValue)
        {
            if (numericValue.ToString().Trim().Length > 0)
            {
                return "'" + numericValue.ToString() + "'";
            }
            else
            {
                return "'" + 0 + "'";
            }
        }

        #region Supressing Repeated Data From DataTable

        #endregion Supressing Repeated Data From DataTable
    }

    #region Enum for Crystal Reports Formula Field Types

    public enum FieldTypes
    {
        String = 0,
        Numeric,
        NepaliDate,
        Others
    }

    #endregion Enum for Crystal Reports Formula Field Types
}