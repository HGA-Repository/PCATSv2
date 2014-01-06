using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COScheduleHour
    {
        private int miID;
        private int miDepartmentID;
        private int miProjectID;
        private int miEmployeeID;
        private int miWeekID;
        private decimal mdPHrs;
        private decimal mdFHrs;
        private decimal mdAHrs;

        public enum ScheduleHourType
        {
            enPlanned,
            enForecast,
            enActual
        }

        public struct GridHoursLevel
        {
            public int EmployeeID;
            public int WeekID;
            public int WarnLvl;
            public ScheduleHourType HrsType;
        }

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int DepartmentID
        {
            get { return miDepartmentID; }
            set { miDepartmentID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public int EmployeeID
        {
            get { return miEmployeeID; }
            set { miEmployeeID = value; }
        }

        public int WeekID
        {
            get { return miWeekID; }
            set { miWeekID = value; }
        }

        public decimal PHrs
        {
            get { return mdPHrs; }
            set { mdPHrs = value; }
        }

        public decimal FHrs
        {
            get { return mdFHrs; }
            set { mdFHrs = value; }
        }

        public decimal AHrs
        {
            get { return mdAHrs; }
            set { mdAHrs = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miDepartmentID = 0;
            miProjectID = 0;
            miEmployeeID = 0;
            miWeekID = 0;
            mdPHrs = 0;
            mdFHrs = 0;
            mdAHrs = 0;
        }

        public void Copy(COScheduleHour oNew)
        {
            oNew.ID = miID;
            oNew.DepartmentID = miDepartmentID;
            oNew.ProjectID = miProjectID;
            oNew.EmployeeID = miEmployeeID;
            oNew.WeekID = miWeekID;
            oNew.PHrs = mdPHrs;
            oNew.FHrs = mdFHrs;
            oNew.AHrs = mdAHrs;
        }

        public void LoadFromObj(COScheduleHour oOrg)
        {
            miID = oOrg.ID;
            miDepartmentID = oOrg.DepartmentID;
            miProjectID = oOrg.ProjectID;
            miEmployeeID = oOrg.EmployeeID;
            miWeekID = oOrg.WeekID;
            mdPHrs = oOrg.PHrs;
            mdFHrs = oOrg.FHrs;
            mdAHrs = oOrg.AHrs;
        }
    }
}
