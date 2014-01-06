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
    public class CBDepartment : CODepartment
    {
        public void Load(int iID)
        {
            CDbDepartment dbDt = new CDbDepartment();
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
            CODepartment o;

            s = new XmlSerializer(typeof(CODepartment));
            sr = new System.IO.StringReader(strXml);

            o = new CODepartment();
            o = (CODepartment)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbDepartment dbDt = new CDbDepartment();
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
            CDbDepartment dbDt = new CDbDepartment();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            CODepartment o;
            XmlSerializer s;
            StringWriter sw;

            o = new CODepartment();
            s = new XmlSerializer(typeof(CODepartment));
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
            CDbDepartment dbDt = new CDbDepartment();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListForDisp()
        {
            CDbDepartment dbDt = new CDbDepartment();

            return dbDt.GetListForDisp();
        }
    }
}
