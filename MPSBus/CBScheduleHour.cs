using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBScheduleHour : COScheduleHour
    {
        public enum HourTypeEnum
        {
            enPlanning,
            enForecast,
            enActual
        }

        public void Load(int iID)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COScheduleHour o;

            s = new XmlSerializer(typeof(COScheduleHour));
            sr = new System.IO.StringReader(strXml);

            o = new COScheduleHour();
            o = (COScheduleHour)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();
            string tmpDat;
            int retVal;

            tmpDat = GetDataString();

            if (base.ID > 0)
            {
                dbDt.SavePrev(tmpDat);
                retVal = base.ID;
            }
            else
            {
                retVal = dbDt.SaveNew(tmpDat);
                base.ID = retVal;
            }

            dbDt = null;

            return retVal;
        }

        public int Save(HourTypeEnum hrType)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();
            int retVal;

            switch (hrType)
            {
                case HourTypeEnum.enForecast:
                    retVal = dbDt.SaveHoursForecast(base.DepartmentID, base.ProjectID, base.EmployeeID, base.WeekID, base.FHrs);
                    break;
                case HourTypeEnum.enActual:
                    retVal = dbDt.SaveHoursActual(base.DepartmentID, base.ProjectID, base.EmployeeID, base.WeekID, base.AHrs);
                    break;
                default:
                    retVal = dbDt.SaveHoursPlan(base.DepartmentID, base.ProjectID, base.EmployeeID, base.WeekID, base.PHrs);
                    break;
            }

            return retVal;
        }


        public static void Delete(int cID)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COScheduleHour o;
            XmlSerializer s;
            StringWriter sw;

            o = new COScheduleHour();
            s = new XmlSerializer(typeof(COScheduleHour));
            sw = new StringWriter();

            base.Copy(o);
            s.Serialize(sw, o);

            tmpStr = sw.ToString();

            o = null;
            s = null;
            sw = null;

            return tmpStr;
        }


        public static SqlDataReader GetList()
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByRange(int deptID, DateTime sDate, DateTime eDate)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();

            return dbDt.GetListByRange(deptID, sDate, eDate);
        }

        public static COScheduleHour.GridHoursLevel GetEmployeeTimeLevel(int empID, int wkID, COScheduleHour.ScheduleHourType type)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();

            return dbDt.GetEmployeeTimeLevel(empID, wkID, type);
        }

        public void GetProjectTotalByDate(int deptID, int projID, int weekID, ref decimal PTot, ref decimal FTot, ref decimal ATot)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();

            dbDt.GetProjectTotalByDate(deptID, projID, weekID, ref PTot, ref FTot, ref ATot);
        }

        public static void MoveEmployeeTimeByWeek(int deptID, int projID, int empID, int wkID, int wkMove)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();

            dbDt.MoveEmployeeTimeByWeek(deptID, projID, empID, wkID, wkMove);
        }

        public static void MoveAllTimeByWeek(int deptID, int projID, int wkID, int wkMove)
        {
            CDbScheduleHour dbDt = new CDbScheduleHour();

            dbDt.MoveAllTimeByWeek(deptID, projID, wkID, wkMove);
        }
    }
}
