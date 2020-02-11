using Bsoft.Common;
using System;
using System.Collections.Generic;

//Consist of all global variables
//No access to db
//For db access use constantvalues

namespace Bsoft.AppCom
{
    public delegate void SimpleDelegate();

    /// <summary>
    /// Gets and sets the variables that is used globally
    /// </summary>
    public static class GlobalValues
    {
        public static string DbPath;
        public static string DbServerName;
        public static string DbUserName;
        public static string DbUserPassword;
        public static bool DiscountInTotal;
        public static List<CheckerObject> Limits = new List<CheckerObject>();
        public static string LoginRoleGroup;
        public static string LoginUserIDPk;
        public static string LoginUserName;
        public static int PSError = 100;
        public static bool UseOrder;
        public static string UserFullEngName;
        public static string UserFullNepName;
        public static UserInfo UserInfo;

        public static string CurrentDate
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
        }
    }
}