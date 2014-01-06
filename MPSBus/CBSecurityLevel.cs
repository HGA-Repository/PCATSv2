using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace RSMPS
{
    public class CBSecurityLevel : COSecurityLevel
    {
        public void Load(int iID)
        {
            CDbSecurityLevel dbDt = new CDbSecurityLevel();
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
            COSecurityLevel o;

            s = new XmlSerializer(typeof(COSecurityLevel));
            sr = new System.IO.StringReader(strXml);

            o = new COSecurityLevel();
            o = (COSecurityLevel)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbSecurityLevel dbDt = new CDbSecurityLevel();
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
            CDbSecurityLevel dbDt = new CDbSecurityLevel();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COSecurityLevel o;
            XmlSerializer s;
            StringWriter sw;

            o = new COSecurityLevel();
            s = new XmlSerializer(typeof(COSecurityLevel));
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
            CDbSecurityLevel dbDt = new CDbSecurityLevel();

            return dbDt.GetList();
        }
    }
}
