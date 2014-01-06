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
    public class CBUnitOfMeasure : COUnitOfMeasure
    {
        public void Load(int iID)
        {
            CDbUnitOfMeasure dbDt = new CDbUnitOfMeasure();
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
            COUnitOfMeasure o;

            s = new XmlSerializer(typeof(COUnitOfMeasure));
            sr = new System.IO.StringReader(strXml);

            o = new COUnitOfMeasure();
            o = (COUnitOfMeasure)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbUnitOfMeasure dbDt = new CDbUnitOfMeasure();
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
            CDbUnitOfMeasure dbDt = new CDbUnitOfMeasure();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COUnitOfMeasure o;
            XmlSerializer s;
            StringWriter sw;

            o = new COUnitOfMeasure();
            s = new XmlSerializer(typeof(COUnitOfMeasure));
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
            CDbUnitOfMeasure dbDt = new CDbUnitOfMeasure();

            return dbDt.GetList();
        }
    }
}
