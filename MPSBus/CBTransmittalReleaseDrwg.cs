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
    public class CBTransmittalReleaseDrwg : COTransmittalReleaseDrwg
    {
        public void Load(int iID)
        {
            CDbTransmittalReleaseDrwg dbDt = new CDbTransmittalReleaseDrwg();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public static int GetDocIDByID(int iID)
        {
            CDbTransmittalReleaseDrwg db = new CDbTransmittalReleaseDrwg();

            return db.GetDocIDByID(iID);
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COTransmittalReleaseDrwg o;

            s = new XmlSerializer(typeof(COTransmittalReleaseDrwg));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittalReleaseDrwg();
            o = (COTransmittalReleaseDrwg)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbTransmittalReleaseDrwg dbDt = new CDbTransmittalReleaseDrwg();
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
            CDbTransmittalReleaseDrwg dbDt = new CDbTransmittalReleaseDrwg();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COTransmittalReleaseDrwg o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittalReleaseDrwg();
            s = new XmlSerializer(typeof(COTransmittalReleaseDrwg));
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
            CDbTransmittalReleaseDrwg db = new CDbTransmittalReleaseDrwg();

            return db.GetList();
        }

        public static SqlDataReader GetListByRelease(int releaseID)
        {
            CDbTransmittalReleaseDrwg db = new CDbTransmittalReleaseDrwg();

            return db.GetListByRelease(releaseID);
        }
    }
}
