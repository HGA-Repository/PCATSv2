using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBPCNStatus : COPCNStatus
    {
        public void Load(int iID)
        {
            CDbPCNStatus dbDt = new CDbPCNStatus();
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
            COPCNStatus o;

            s = new XmlSerializer(typeof(COPCNStatus));
            sr = new System.IO.StringReader(strXml);

            o = new COPCNStatus();
            o = (COPCNStatus)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbPCNStatus dbDt = new CDbPCNStatus();
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
            CDbPCNStatus dbDt = new CDbPCNStatus();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COPCNStatus o;
            XmlSerializer s;
            StringWriter sw;

            o = new COPCNStatus();
            s = new XmlSerializer(typeof(COPCNStatus));
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
            CDbPCNStatus dbDt = new CDbPCNStatus();

            return dbDt.GetList();
        }

    }
}
