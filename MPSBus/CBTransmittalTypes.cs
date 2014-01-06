using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBTransmittalTypes : COTransmittalTypes
    {
        public void Load(int iID)
        {
            CDbTransmittalTypes dbDt = new CDbTransmittalTypes();
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
            COTransmittalTypes o;

            s = new XmlSerializer(typeof(COTransmittalTypes));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittalTypes();
            o = (COTransmittalTypes)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbTransmittalTypes dbDt = new CDbTransmittalTypes();
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
            CDbTransmittalTypes dbDt = new CDbTransmittalTypes();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COTransmittalTypes o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittalTypes();
            s = new XmlSerializer(typeof(COTransmittalTypes));
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
            CDbTransmittalTypes dbDt = new CDbTransmittalTypes();

            return dbDt.GetList();
        }

        public static DataSet GetListDS()
        {
            CDbTransmittalTypes dbDt = new CDbTransmittalTypes();

            return dbDt.GetListDS();
        }
    }
}
