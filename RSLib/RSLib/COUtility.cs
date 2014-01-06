using System;
namespace RSLib
{
	public class COUtility
	{
		public static DateTime DEFAULTDATE = new DateTime(1900, 1, 1);
		public static int NumberWeeksInRange(DateTime sDate, DateTime eDate)
		{
			Convert.ToDateTime(sDate.ToShortDateString());
			Convert.ToDateTime(eDate.ToShortDateString());
			int days = (eDate - sDate).Days;
			decimal value = Convert.ToDecimal(days) / 7.0m;
			int num = (int)value;
			return num + 1;
		}
		public static DateTime StartWeekRange(DateTime sDate)
		{
			DayOfWeek dayOfWeek = sDate.DayOfWeek;
			int num = (int)dayOfWeek;
			return sDate.AddDays((double)(-(double)num));
		}
		public static string CheckSpecialCharacter(string txt)
		{
			string result = txt;
			if (txt.IndexOf("'") > 0)
			{
				result = txt.Replace("'", "''");
			}
			if (txt.IndexOf("%") > 0)
			{
				result = txt.Replace("%", "%%");
			}
			return result;
		}
	}
}
