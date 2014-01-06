using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Common.Extentions
{

    public static class SqlDataReaderExtentions
    {

        public static List<string> Columns(this SqlDataReader reader)
        {
            List<string> cols = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            { cols.Add(reader.GetName(i)); }
            return cols;
        }

        public static object GetOrDefault(this SqlDataReader reader, string column)
        {
            if (reader.Columns().Contains(column)) return reader[column];
            return null;
        }



    }
}
