using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBProjectSummaryPCN : COProjectSummaryPCN
    {
        public void Load(int iID)
        {
            CDbProjectSummaryPCN dbDt = new CDbProjectSummaryPCN();
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
            COProjectSummaryPCN o;

            s = new XmlSerializer(typeof(COProjectSummaryPCN));
            sr = new System.IO.StringReader(strXml);

            o = new COProjectSummaryPCN();
            o = (COProjectSummaryPCN)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbProjectSummaryPCN dbDt = new CDbProjectSummaryPCN();
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
            CDbProjectSummaryPCN dbDt = new CDbProjectSummaryPCN();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COProjectSummaryPCN o;
            XmlSerializer s;
            StringWriter sw;

            o = new COProjectSummaryPCN();
            s = new XmlSerializer(typeof(COProjectSummaryPCN));
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
            CDbProjectSummaryPCN dbDt = new CDbProjectSummaryPCN();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByProjectSum(int projSumID)
        {
            CDbProjectSummaryPCN dbDt = new CDbProjectSummaryPCN();

            return dbDt.GetListByProjectSum(projSumID);
        }

        public static SqlDataReader GetListByProject(int projSumID, int projID)
        {
            CDbProjectSummaryPCN dbDt = new CDbProjectSummaryPCN();

            return dbDt.GetListByProject(projSumID, projID);
        }
    }
}
