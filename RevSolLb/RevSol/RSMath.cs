using System;
namespace RevSol
{
	public class RSMath
	{
        //public const decimal STAINLESS_STEEL_DENSITY_LBPERCUBICIN = 0.285m;
        //public static bool IsNumberEven(object val)
        //{
        //    decimal d = RSMath.IsDecimalEx(val);
        //    return d % 2m == 0m;
        //}
		public static bool IsInteger(object val)
		{
			bool result;
			try
			{
				Convert.ToInt32(val);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static int IsIntegerEx(object val)
		{
			//string value = RSMath.RemoveSpecialCharacters(val);
            string value = Convert.ToString(val);
			int result;
			try
			{
				result = Convert.ToInt32(value);
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public static bool IsDecimal(object val)
		{
			bool result;
			try
			{
				Convert.ToDecimal(val);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static decimal IsDecimalEx(object val)
		{
			decimal result;
			try
			{
				result = Convert.ToDecimal(val);
			}
			catch
			{
				result = 0m;
			}
			return result;
		}
        //public static bool IsDateTime(object val)
        //{
        //    bool result;
        //    try
        //    {
        //        Convert.ToDateTime(val);
        //        result = true;
        //    }
        //    catch
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
        //public static DateTime IsDateTimeEx(object val)
        //{
        //    DateTime result;
        //    try
        //    {
        //        result = Convert.ToDateTime(val);
        //    }
        //    catch
        //    {
        //        result = RSUtility.DefaultDate();
        //    }
        //    return result;
        //}
        //public void SolveTriDiag(float[] sub, float[] diag, float[] sup, ref float[] b, int n)
        //{
        //    for (int i = 2; i <= n; i++)
        //    {
        //        sub[i] /= diag[i - 1];
        //        diag[i] -= sub[i] * sup[i - 1];
        //        b[i] -= sub[i] * b[i - 1];
        //    }
        //    b[n] /= diag[n];
        //    for (int i = n - 1; i >= 1; i--)
        //    {
        //        b[i] = (b[i] - sup[i] + b[i + 1]) / diag[i];
        //    }
        //}
        //public void GetBAndMForPointArray(double[][] pnts, ref double bVal, ref double mVal)
        //{
        //    bVal = this.GetBVal(pnts);
        //    mVal = this.GetMVal(pnts);
        //}
        //private double GetBVal(double[][] pnts)
        //{
        //    int length = pnts.GetLength(0);
        //    double num = 0.0;
        //    double num2 = 0.0;
        //    double num3 = 0.0;
        //    double num4 = 0.0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        num += pnts[i][0];
        //        num2 += pnts[i][1];
        //        num3 += pnts[i][0] * pnts[i][0];
        //        num4 += pnts[i][0] * pnts[i][1];
        //    }
        //    double num5 = num / (double)length;
        //    double num6 = num2 / (double)length;
        //    double num7 = num3 - (double)length * (num5 * num5);
        //    double result;
        //    if (num7 != 0.0)
        //    {
        //        result = (num6 * num3 - num5 * num4) / num7;
        //    }
        //    else
        //    {
        //        result = 0.0;
        //    }
        //    return result;
        //}
        //private double GetMVal(double[][] pnts)
        //{
        //    int length = pnts.GetLength(0);
        //    double num = 0.0;
        //    double num2 = 0.0;
        //    double num3 = 0.0;
        //    double num4 = 0.0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        num += pnts[i][0];
        //        num2 += pnts[i][1];
        //        num3 += pnts[i][0] * pnts[i][0];
        //        num4 += pnts[i][0] * pnts[i][1];
        //    }
        //    double num5 = num / (double)length;
        //    double num6 = num2 / (double)length;
        //    double num7 = num5 * num6;
        //    double num8 = num3 - (double)length * (num5 * num5);
        //    double result;
        //    if (num8 != 0.0)
        //    {
        //        result = (num4 - (double)length * num7) / num8;
        //    }
        //    else
        //    {
        //        result = 0.0;
        //    }
        //    return result;
        //}
        //public double GetYUsingMB(double xVal, double mVal, double bVal)
        //{
        //    return mVal * xVal + bVal;
        //}
        //public static decimal ConvertFracStringToDecimal(string fracVal)
        //{
        //    string text = fracVal.Trim();
        //    string key;
        //    decimal result;
        //    switch (key = text)
        //    {
        //    case "1/16":
        //        result = 0.0625m;
        //        return result;
        //    case "1/8":
        //        result = 0.125m;
        //        return result;
        //    case "3/16":
        //        result = 0.1875m;
        //        return result;
        //    case "1/4":
        //        result = 0.25m;
        //        return result;
        //    case "5/16":
        //        result = 0.3125m;
        //        return result;
        //    case "3/8":
        //        result = 0.375m;
        //        return result;
        //    case "7/16":
        //        result = 0.4375m;
        //        return result;
        //    case "1/2":
        //        result = 0.5m;
        //        return result;
        //    case "9/16":
        //        result = 0.5625m;
        //        return result;
        //    case "5/8":
        //        result = 0.625m;
        //        return result;
        //    case "11/16":
        //        result = 0.6875m;
        //        return result;
        //    case "3/4":
        //        result = 0.75m;
        //        return result;
        //    case "13/16":
        //        result = 0.8125m;
        //        return result;
        //    case "7/8":
        //        result = 0.875m;
        //        return result;
        //    case "15/16":
        //        result = 0.9375m;
        //        return result;
        //    }
        //    result = 0m;
        //    return result;
        //}
        //public static string ConvertFracDecimalToString(decimal fracVal)
        //{
        //    return "Empty";
        //}
        //public static string RemoveSpecialCharacters(object val)
        //{
        //    string text;
        //    if (val == null)
        //    {
        //        text = "";
        //    }
        //    else
        //    {
        //        text = val.ToString();
        //        text = text.Replace("$", "");
        //        text = text.Replace(",", "");
        //        text = text.Replace("#", "");
        //    }
        //    return text;
        //}
	}
}
