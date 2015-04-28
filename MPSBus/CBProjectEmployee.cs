using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBProjectEmployee : COProjectEmployee
    {
        public void Load(int iID)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();
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
            COProjectEmployee o;

            s = new XmlSerializer(typeof(COProjectEmployee));
            sr = new System.IO.StringReader(strXml);

            o = new COProjectEmployee();
            o = (COProjectEmployee)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();
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

        public static void Swap(int projID, int empID, int deptID, int newID)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            dbDt.Swap(projID, empID, deptID, newID);
        }

        public static void Delete(int cID)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            dbDt.Delete(cID);
        }

        public static void Delete(int projID, int empID, int deptID)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            dbDt.Delete(projID,empID,deptID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COProjectEmployee o;
            XmlSerializer s;
            StringWriter sw;

            o = new COProjectEmployee();
            s = new XmlSerializer(typeof(COProjectEmployee));
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
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListActive()
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActive();
        }

        public static SqlDataReader GetListActiveWithHours(int deptID, DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHours(deptID, startDate, endDate);
        }

        //********************************************************Added*********MZ
        public static SqlDataReader GetListActiveWithHoursENG(int deptID, DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHoursENG(deptID, startDate, endDate);
        }

        public static SqlDataReader GetListActiveWithHoursPGM(int deptID, DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHoursPGM(deptID, startDate, endDate);
        }
        
        public static SqlDataReader GetListActiveWithHoursPLS(int deptID, DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHoursPLS(deptID, startDate, endDate);
        }

        public static SqlDataReader GetListActiveWithHoursSTAFF(int deptID, DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHoursSTAFF(deptID, startDate, endDate);
        }


        public static SqlDataReader GetListActiveWithHoursProp(int deptID, DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHoursProp(deptID, startDate, endDate);
        }

        public static SqlDataReader GetListActiveWithHoursProject(int Proj_ID, DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHoursProject(Proj_ID, startDate, endDate);
        }





        public static SqlDataReader GetListActiveWithHoursAllDept(DateTime startDate, DateTime endDate)
        {
            CDbProjectEmployee dbDt = new CDbProjectEmployee();

            return dbDt.GetListActiveWithHoursAllDept(startDate, endDate);
        }
    }
}
