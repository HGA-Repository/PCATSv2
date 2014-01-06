using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBProjectSummary : COProjectSummary
    {
        public void Load(int iID)
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadByEmp(int iID)
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();
            string tmpDat;

            tmpDat = dbDt.GetByEmployeeID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COProjectSummary o;

            s = new XmlSerializer(typeof(COProjectSummary));
            sr = new System.IO.StringReader(strXml);

            o = new COProjectSummary();
            o = (COProjectSummary)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();
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


        public static void Delete(int cID)
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COProjectSummary o;
            XmlSerializer s;
            StringWriter sw;

            o = new COProjectSummary();
            s = new XmlSerializer(typeof(COProjectSummary));
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
            CDbProjectSummary dbDt = new CDbProjectSummary();

            return dbDt.GetList();
        }

        public static DataSet GetPMReport(int empID)
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();

            return dbDt.GetPMReport(empID);
        }

        public static DataSet GetVarianceReport(int indx, int pmID)
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();

            return dbDt.GetVarianceReport(indx, pmID);
        }

        public static DataSet GetVarianceReportSummary()
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();

            return dbDt.GetVarianceReportSummary();
        }

        public static DataSet GetForecastRemaining(bool usePipe)
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();

            return dbDt.GetForecastRemaining(usePipe);
        }
        public static DataSet GetForecastRemainingNew(int EngPLSPM)
        {
            CDbProjectSummary dbDt = new CDbProjectSummary();

            return dbDt.GetForecastRemainingNew(EngPLSPM);
        }
    }
}
