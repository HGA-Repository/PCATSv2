using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBBudgetPCNHour : COBudgetPCNHour
    {
        public void Load(int iID)
        {
            CDbBudgetPCNHour dbDt = new CDbBudgetPCNHour();
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
            COBudgetPCNHour o;

            s = new XmlSerializer(typeof(COBudgetPCNHour));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetPCNHour();
            o = (COBudgetPCNHour)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudgetPCNHour dbDt = new CDbBudgetPCNHour();
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
            CDbBudgetPCNHour dbDt = new CDbBudgetPCNHour();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudgetPCNHour o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetPCNHour();
            s = new XmlSerializer(typeof(COBudgetPCNHour));
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
            CDbBudgetPCNHour dbDt = new CDbBudgetPCNHour();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByPCN(int pcnID)
        {
            CDbBudgetPCNHour dbDt = new CDbBudgetPCNHour();

            return dbDt.GetListByPCNID(pcnID);
        }

    }
}
