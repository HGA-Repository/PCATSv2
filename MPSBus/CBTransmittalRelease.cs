using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBTransmittalRelease : COTransmittalRelease
    {
        public void Load(int iID)
        {
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();
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
            COTransmittalRelease o;

            s = new XmlSerializer(typeof(COTransmittalRelease));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittalRelease();
            o = (COTransmittalRelease)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();
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
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();

            dbDt.Delete(cID);
        }

        public static void SetPrintDate(int iID)
        {
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();

            dbDt.SetPrintDate(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COTransmittalRelease o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittalRelease();
            s = new XmlSerializer(typeof(COTransmittalRelease));
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
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListForStatus()
        {
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();

            return dbDt.GetListForStatus();
        }

        public static SqlDataReader GetListForIssuance()
        {
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();

            return dbDt.GetListForIssuances();
        }

        public static SqlDataReader GetListForTransmittal()
        {
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();

            return dbDt.GetListForTransmittals();
        }

        public static SqlDataReader GetListForManagerList(int projectID)
        {
            CDbTransmittalRelease db = new CDbTransmittalRelease();

            return db.GetListForManagerList(projectID);
        }

        public static DataSet GetIssueReleaseForReport(int issueID)
        {
            CDbTransmittalRelease dbDt = new CDbTransmittalRelease();

            return dbDt.GetIssueReleaseForReport(issueID);
        }

        public static int GetReleaseCountByProject(int projectID)
        {
            CDbTransmittalRelease db = new CDbTransmittalRelease();

            return db.GetReleaseCountByProject(projectID);
        }

        public static DataSet GetTransmittalReleaseForReport(int releaseID)
        {
            CDbTransmittalRelease db = new CDbTransmittalRelease();

            return db.GetTransmittalReleaseForReport(releaseID);
        }

        public static int CopyExistingRelease(int releaseID)
        {
            CDbTransmittalRelease db = new CDbTransmittalRelease();

            return db.CopyExistingRelease(releaseID);
        }

        public static bool CopyToNewProject(int currRelease, int newProjecID)
        {
            CDbTransmittalRelease db = new CDbTransmittalRelease();

            return db.CopyToNewProject(currRelease, newProjecID);
        }
    }
}
