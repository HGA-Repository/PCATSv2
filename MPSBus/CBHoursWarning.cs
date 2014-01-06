using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public delegate void HoursWarningThread(COScheduleHour.GridHoursLevel hourLvl);

    public class CBHoursWarning
    {
        public HoursWarningThread OnHoursWarning;

        private int miEmployeeID;
        private int miWeekID;
        //private int miWarnLvl;
        private COScheduleHour.ScheduleHourType moHrsType;

        public void SetWarningVals(int empID, int weekID, CBScheduleHour.HourTypeEnum hte)
        {
            miEmployeeID = empID;
            miWeekID = weekID;
            //miWarnLvl = 0;

            switch (hte)
            {
                case CBScheduleHour.HourTypeEnum.enForecast:
                    moHrsType = COScheduleHour.ScheduleHourType.enForecast;
                    break;
                default:
                    moHrsType = COScheduleHour.ScheduleHourType.enPlanned;
                    break;
            }
        }
 
        public void CheckCurrentHours()
        {
            //miWarnLvl = 0;
            COScheduleHour.GridHoursLevel ghl = CBScheduleHour.GetEmployeeTimeLevel(miEmployeeID, miWeekID, moHrsType);

            if (OnHoursWarning != null)
                OnHoursWarning(ghl);
        }
    }
}
