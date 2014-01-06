using System;
using System.Collections.Generic;
using System.Text;


using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBUtility
    {
        public void InitWeeks(int wkDay)
        {
            CDbUtility u = new CDbUtility();
            DateTime startDate;
            DateTime currDate;
            int dow;

            currDate = DateTime.Now;
            startDate = new DateTime(currDate.Year - 1, 1, 1);

            dow = DayOfWeekInt(startDate.DayOfWeek);

            while (dow != wkDay)
            {
                startDate = startDate.AddDays(1);
                dow = DayOfWeekInt(startDate.DayOfWeek);
            }

            u.InitWeeksInDb(startDate);
        }

        private int DayOfWeekInt(DayOfWeek dw)
        {
            int dow;

            switch (dw)
            {
                case DayOfWeek.Monday:
                    dow = 2;
                    break;
                case DayOfWeek.Tuesday:
                    dow = 3;
                    break;
                case DayOfWeek.Wednesday:
                    dow = 4;
                    break;
                case DayOfWeek.Thursday:
                    dow = 5;
                    break;
                case DayOfWeek.Friday:
                    dow = 6;
                    break;
                case DayOfWeek.Saturday:
                    dow = 7;
                    break;
                default:
                    dow = 1;
                    break;
            }

            return dow;
        }

        public static DataSet GetJobStatList()
        {
            CDbUtility u = new CDbUtility();

            return u.GetTestJobStat();
        }
    }
}
