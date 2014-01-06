using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace RSMPS
{
    public delegate void NewItemCreated(int itmID);

    public class COUtility
    {
        public string GetCurrentLocation()
        {
            string currPath;

            currPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            return currPath;
        }

        public static DateTime GetWeekEndingForDate(DateTime currDate)
        {
            DateTime weekEnd;
            int fromEnding;

            switch (currDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    fromEnding = -1;
                    break;
                case DayOfWeek.Tuesday:
                    fromEnding = -2;
                    break;
                case DayOfWeek.Wednesday:
                    fromEnding = -3;
                    break;
                case DayOfWeek.Thursday:
                    fromEnding = -4;
                    break;
                case DayOfWeek.Friday:
                    fromEnding = -5;
                    break;
                case DayOfWeek.Saturday:
                    fromEnding = -6;
                    break;
                default:
                    fromEnding = 0;
                    break;
            }

            weekEnd = currDate.AddDays(fromEnding);

            return weekEnd;
        }
    }
}
