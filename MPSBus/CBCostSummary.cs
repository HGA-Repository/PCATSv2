using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

using RevSol;

namespace RSMPS
{
    public class CBCostSummary : COCostSummary
    {
        public void Load(int iID)
        {
            CDbCostSummary dbDt = new CDbCostSummary();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadByProject(int projID)
        {
            CDbCostSummary dbDt = new CDbCostSummary();
            string tmpDat;

            tmpDat = dbDt.GetByProject(projID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;            
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COCostSummary o;

            s = new XmlSerializer(typeof(COCostSummary));
            sr = new System.IO.StringReader(strXml);

            o = new COCostSummary();
            o = (COCostSummary)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbCostSummary dbDt = new CDbCostSummary();
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
            CDbCostSummary dbDt = new CDbCostSummary();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COCostSummary o;
            XmlSerializer s;
            StringWriter sw;

            o = new COCostSummary();
            s = new XmlSerializer(typeof(COCostSummary));
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
            CDbCostSummary dbDt = new CDbCostSummary();

            return dbDt.GetList();
        }

    }
}
