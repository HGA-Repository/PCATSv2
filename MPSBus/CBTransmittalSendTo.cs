using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBTransmittalSendTo : COTransmittalSendTo
    {
        public void Load(int iID)
        {
            CDbTransmittalSendTo dbDt = new CDbTransmittalSendTo();
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
            COTransmittalSendTo o;

            s = new XmlSerializer(typeof(COTransmittalSendTo));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittalSendTo();
            o = (COTransmittalSendTo)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbTransmittalSendTo dbDt = new CDbTransmittalSendTo();
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
            CDbTransmittalSendTo dbDt = new CDbTransmittalSendTo();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COTransmittalSendTo o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittalSendTo();
            s = new XmlSerializer(typeof(COTransmittalSendTo));
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
            CDbTransmittalSendTo dbDt = new CDbTransmittalSendTo();

            return dbDt.GetList();
        }

        public static SqlDataReader GetList(int tranID, bool isOther)
        {
            CDbTransmittalSendTo dbDt = new CDbTransmittalSendTo();

            return dbDt.GetList(tranID, isOther);
        }
    }
}
