using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FDDWeb.Utility
{
    internal static class DBExtension
    {
        public static T GetFieldValue<T>(this DbDataReader reader, string name)
        {
            var value = reader[name];
            if (value == DBNull.Value && default(T) == null) return default(T);
            else return (T)value;
        }
    }
}