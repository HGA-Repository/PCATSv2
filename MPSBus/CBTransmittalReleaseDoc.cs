using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBTransmittalReleaseDoc : COTransmittalReleaseDocOld
    {
        public void Load(int iID)
        {
            CDbTransmittalReleaseDoc dbDt = new CDbTransmittalReleaseDoc();
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
            COTransmittalReleaseDocOld o;

            s = new XmlSerializer(typeof(COTransmittalReleaseDocOld));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittalReleaseDocOld();
            o = (COTransmittalReleaseDocOld)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public static int GetDocIDByID(int lID)
        {
            CDbTransmittalReleaseDoc db = new CDbTransmittalReleaseDoc();

            return db.GetDocIDByID(lID);
        }

        public int Save()
        {
            CDbTransmittalReleaseDoc dbDt = new CDbTransmittalReleaseDoc();
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
            CDbTransmittalReleaseDoc dbDt = new CDbTransmittalReleaseDoc();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COTransmittalReleaseDocOld o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittalReleaseDocOld();
            s = new XmlSerializer(typeof(COTransmittalReleaseDocOld));
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
            CDbTransmittalReleaseDoc dbDt = new CDbTransmittalReleaseDoc();

            return dbDt.GetList();
        }

        public static SqlDataReader GetList(int transID)
        {
            CDbTransmittalReleaseDoc dbDt = new CDbTransmittalReleaseDoc();

            return dbDt.GetList(transID);
        }
    }
}
