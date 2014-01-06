using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBTransmittalDoc : COTransmittalDoc
    {
        public void Load(int iID)
        {
            CDbTransmittalDoc dbDt = new CDbTransmittalDoc();
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
            COTransmittalDoc o;

            s = new XmlSerializer(typeof(COTransmittalDoc));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittalDoc();
            o = (COTransmittalDoc)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbTransmittalDoc dbDt = new CDbTransmittalDoc();
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

        public static void Delete(int iID)
        {
            CDbTransmittalDoc dbDt = new CDbTransmittalDoc();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COTransmittalDoc o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittalDoc();
            s = new XmlSerializer(typeof(COTransmittalDoc));
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
            CDbTransmittalDoc db = new CDbTransmittalDoc();

            return db.GetList();
        }

        public static SqlDataReader GetListByTransmittal(int transmittalID)
        {
            CDbTransmittalDoc db = new CDbTransmittalDoc();

            return db.GetListByTransmittal(transmittalID);
        }
    }
}
