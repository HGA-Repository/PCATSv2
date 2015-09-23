using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBActivityCode : COActivityCode
    {
        public void Load(int iID)
        {
            CDbActivityCode dbDt = new CDbActivityCode();
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
            COActivityCode o;

            s = new XmlSerializer(typeof(COActivityCode));
            sr = new System.IO.StringReader(strXml);

            o = new COActivityCode();
            o = (COActivityCode)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbActivityCode dbDt = new CDbActivityCode();
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
            CDbActivityCode dbDt = new CDbActivityCode();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COActivityCode o;
            XmlSerializer s;
            StringWriter sw;

            o = new COActivityCode();
            s = new XmlSerializer(typeof(COActivityCode));
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
            CDbActivityCode dbDt = new CDbActivityCode();

            return dbDt.GetList();
        }


        public static SqlDataReader GetListForBudget()
        {
            CDbActivityCode dbDt = new CDbActivityCode();

            return dbDt.GetListForBudget();
        }

        public static SqlDataReader GetDeptGroup()
        {
            CDbActivityCode dbDt = new CDbActivityCode();

            return dbDt.GetDeptGroup();
        }
    }
}
