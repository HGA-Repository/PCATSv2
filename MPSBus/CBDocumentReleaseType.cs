using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBDocumentReleaseType : CODocumentReleaseType
    {
        public void Load(int iID)
        {
            CDbDocumentReleaseType dbDt = new CDbDocumentReleaseType();
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
            CODocumentReleaseType o;

            s = new XmlSerializer(typeof(CODocumentReleaseType));
            sr = new System.IO.StringReader(strXml);

            o = new CODocumentReleaseType();
            o = (CODocumentReleaseType)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbDocumentReleaseType dbDt = new CDbDocumentReleaseType();
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
            CDbDocumentReleaseType dbDt = new CDbDocumentReleaseType();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            CODocumentReleaseType o;
            XmlSerializer s;
            StringWriter sw;

            o = new CODocumentReleaseType();
            s = new XmlSerializer(typeof(CODocumentReleaseType));
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
            CDbDocumentReleaseType db = new CDbDocumentReleaseType();

            return db.GetList();
        }

        public static DataSet GetListDS()
        {
            CDbDocumentReleaseType db = new CDbDocumentReleaseType();

            return db.GetListDS();
        }
    }
}
