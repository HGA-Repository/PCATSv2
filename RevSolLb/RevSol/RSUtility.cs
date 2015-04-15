using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
namespace RevSol
{
	public class RSUtility
	{
        public static readonly string DefaultXMLFilePath = Environment.GetEnvironmentVariable("temp");
		public static DateTime DefaultDate()
		{
			return new DateTime(1900, 1, 1);
		}
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
		public static string GetLocation()
		{
			//return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return DefaultXMLFilePath;
		}
		public static string GetComputerName()
		{
			return Environment.MachineName;
		}
		public bool DoesFolderExist(string folderLoc)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folderLoc);
			bool result;
			try
			{
				result = directoryInfo.Exists;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public bool DoesFolderExist(string folderLoc, bool create)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folderLoc);
			bool flag;
			try
			{
				flag = directoryInfo.Exists;
				if (!flag)
				{
					this.CreateFolder(folderLoc);
				}
			}
			catch
			{
				flag = false;
			}
			return flag;
		}
		public bool DoesFileExist(string fileLoc)
		{
			FileInfo fileInfo = new FileInfo(fileLoc);
			bool result;
			try
			{
				result = fileInfo.Exists;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public void CreateFolder(string folder)
		{
			int length = folder.LastIndexOf("\\");
			string text = folder.Substring(0, length);
			DirectoryInfo directoryInfo = new DirectoryInfo(text);
			if (!directoryInfo.Exists)
			{
				this.CreateFolder(text);
			}
			this.CreateNewFolder(folder);
		}
		private void CreateNewFolder(string newFolder)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(newFolder);
			directoryInfo.Create();
		}
		public static bool GetBoolean(object val)
		{
			bool result;
			try
			{
				result = Convert.ToBoolean(val);
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static DateTime GetDate(object val)
		{
			DateTime result;
			try
			{
				result = Convert.ToDateTime(val);
			}
			catch
			{
				result = RSUtility.DefaultDate();
			}
			return result;
		}
		public static void WaitForSeconds(int millisecs)
		{
			Thread.Sleep(millisecs);
		}
		public static bool IsValidEmail(string strIn)
		{
			return Regex.IsMatch(strIn, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
		}
	}
}
