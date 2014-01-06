using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Common.Extentions
{
    public static class StringExtentions
    {


        public static int? ToInt(this string str)
        {
            int i;
            if (int.TryParse(str, out i)) return i;
            try { return (int)ToDecimal(str); }
            catch { return null; }
        }

        public static decimal? ToDecimal(this string str)
        {
            decimal i;
            if (decimal.TryParse(str, out i)) return i;
            return null;
        }



        public static string Grep(this string data, string pattern)
        {
            Regex matcher = new Regex(pattern);

            string result = null;
            if (matcher.IsMatch(data))
            {
                result = matcher.Match(data).Value;
            }

            return result;
        }

        public static string Gsub(this string data, string pattern, string replacement)
        {
            if (data == null) { return null; }
            var match = data.Grep(pattern);
            if (match == null) { return data; }
            return data.Replace(match, replacement);
        }



        public static string TryToString(this object str)
        {
            if (str == null) return "";
            return str.ToString();
        }



    }


}
