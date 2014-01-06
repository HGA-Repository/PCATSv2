using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBDrawingSize : CODrawingSize
    {
        public void Load(int iID)
        {
            CDbDrawingSize dbDt = new CDbDrawingSize();
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
            CODrawingSize o;

            s = new XmlSerializer(typeof(CODrawingSize));
            sr = new System.IO.StringReader(strXml);

            o = new CODrawingSize();
            o = (CODrawingSize)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbDrawingSize dbDt = new CDbDrawingSize();
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
            CDbDrawingSize dbDt = new CDbDrawingSize();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            CODrawingSize o;
            XmlSerializer s;
            StringWriter sw;

            o = new CODrawingSize();
            s = new XmlSerializer(typeof(CODrawingSize));
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
            CDbDrawingSize dbDt = new CDbDrawingSize();

            return dbDt.GetList();
        }
    }
}
