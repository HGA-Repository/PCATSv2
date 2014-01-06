using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBReleaseDrawing : COReleaseDrawing
    {
        public void Load(int iID)
        {
            CDbReleaseDrawing dbDt = new CDbReleaseDrawing();
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
            COReleaseDrawing o;

            s = new XmlSerializer(typeof(COReleaseDrawing));
            sr = new System.IO.StringReader(strXml);

            o = new COReleaseDrawing();
            o = (COReleaseDrawing)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbReleaseDrawing dbDt = new CDbReleaseDrawing();
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
            CDbReleaseDrawing dbDt = new CDbReleaseDrawing();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COReleaseDrawing o;
            XmlSerializer s;
            StringWriter sw;

            o = new COReleaseDrawing();
            s = new XmlSerializer(typeof(COReleaseDrawing));
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
            CDbReleaseDrawing dbDt = new CDbReleaseDrawing();

            return dbDt.GetList();
        }
    }
}
