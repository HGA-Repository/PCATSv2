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
    public class CBCustomer : COCustomer
    {
        public void Load(int iID)
        {
            CDbCustomer dbDt = new CDbCustomer();
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
            COCustomer o;

            s = new XmlSerializer(typeof(COCustomer));
            sr = new System.IO.StringReader(strXml);

            o = new COCustomer();
            o = (COCustomer)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbCustomer dbDt = new CDbCustomer();
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
            CDbCustomer dbDt = new CDbCustomer();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COCustomer o;
            XmlSerializer s;
            StringWriter sw;

            o = new COCustomer();
            s = new XmlSerializer(typeof(COCustomer));
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
            CDbCustomer dbDt = new CDbCustomer();

            return dbDt.GetList();
        }
    }
}
