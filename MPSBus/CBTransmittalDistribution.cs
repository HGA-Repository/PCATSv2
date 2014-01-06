using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBTransmittalDistribution : COTransmittalDistribution
    {
        public void Load(int iID)
        {
            CDbTransmittalDistribution dbDt = new CDbTransmittalDistribution();
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
            COTransmittalDistribution o;

            s = new XmlSerializer(typeof(COTransmittalDistribution));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittalDistribution();
            o = (COTransmittalDistribution)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbTransmittalDistribution dbDt = new CDbTransmittalDistribution();
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
            CDbTransmittalDistribution dbDt = new CDbTransmittalDistribution();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COTransmittalDistribution o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittalDistribution();
            s = new XmlSerializer(typeof(COTransmittalDistribution));
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
            CDbTransmittalDistribution db = new CDbTransmittalDistribution();

            return db.GetList();
        }

        public static SqlDataReader GetListOfTo(int releaseID)
        {
            CDbTransmittalDistribution db = new CDbTransmittalDistribution();

            return db.GetListOfTo(releaseID);
        }

        public static SqlDataReader GetListOfCc(int releaseID)
        {
            CDbTransmittalDistribution db = new CDbTransmittalDistribution();

            return db.GetListOfCc(releaseID);
        }
    }
}
