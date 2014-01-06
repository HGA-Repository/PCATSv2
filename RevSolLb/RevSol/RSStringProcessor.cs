using System;
namespace RevSol
{
	public class RSStringProcessor
	{
		public string[] ParseStringWithTextDelimiter(string seperator, string textDelimiter, string info, int intendedSize)
		{
			string[] result = new string[intendedSize];
			string text = info;
			this.GetColVal(ref text, ref result, 0, seperator, textDelimiter);
			return result;
		}
		public void GetColVal(ref string currStr, ref string[] colVals, int currVal, string seperator, string delimiter)
		{
			string text = "";
			int num = currStr.IndexOf(seperator);
			int num2 = currStr.IndexOf(delimiter);
			if (num2 == 0)
			{
				int num3 = currStr.IndexOf(delimiter, 1);
				if (num3 > num2)
				{
					text = currStr.Substring(num2 + 1, num3 - 1);
					if (currStr.Length < num3 + 2)
					{
						currStr = "";
					}
					else
					{
						currStr = currStr.Substring(num3 + 2);
					}
				}
			}
			else
			{
				if (num < 0)
				{
					text = currStr;
					currStr = "";
				}
				else
				{
					text = currStr.Substring(0, num);
					if (currStr.Length < num + 1)
					{
						currStr = "";
					}
					else
					{
						currStr = currStr.Substring(num + 1);
					}
				}
			}
			colVals[currVal] = text;
			currVal++;
			if (currStr.Length > 0)
			{
				this.GetColVal(ref currStr, ref colVals, currVal, seperator, delimiter);
			}
		}
	}
}
