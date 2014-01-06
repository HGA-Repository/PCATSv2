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
    public class CBEmployeeTitle : COEmployeeTitle
    {
        public void Load(int iID)
        {
            CDbEmployeeTitle dbDt = new CDbEmployeeTitle();
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
            COEmployeeTitle o;

            s = new XmlSerializer(typeof(COEmployeeTitle));
            sr = new System.IO.StringReader(strXml);

            o = new COEmployeeTitle();
            o = (COEmployeeTitle)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbEmployeeTitle dbDt = new CDbEmployeeTitle();
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
            CDbEmployeeTitle dbDt = new CDbEmployeeTitle();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COEmployeeTitle o;
            XmlSerializer s;
            StringWriter sw;

            o = new COEmployeeTitle();
            s = new XmlSerializer(typeof(COEmployeeTitle));
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
            CDbEmployeeTitle dbDt = new CDbEmployeeTitle();

            return dbDt.GetList();
        }
    }
}
