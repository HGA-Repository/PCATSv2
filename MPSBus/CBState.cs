using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBState : COState
    {
        public void Load(int iID)
        {
            CDbState dbDt = new CDbState();
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
            COState o;

            s = new XmlSerializer(typeof(COState));
            sr = new System.IO.StringReader(strXml);

            o = new COState();
            o = (COState)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbState dbDt = new CDbState();
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
            CDbState dbDt = new CDbState();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COState o;
            XmlSerializer s;
            StringWriter sw;

            o = new COState();
            s = new XmlSerializer(typeof(COState));
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
            CDbState dbDt = new CDbState();

            return dbDt.GetList();
        }

        public static string GetName(int stateID)
        {
            CDbState dbDt = new CDbState();

            return dbDt.GetName(stateID);
        }

        public static string GetAbbrev(int stateID)
        {
            CDbState dbDt = new CDbState();

            return dbDt.GetAbbrev(stateID);
        }
    }
}
