using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBLocation : COLocation
    {
        public string FullName
        {
            get
            {
                if (base.StateID > 0)
                {
                    CBState s = new CBState();
                    s.Load(base.StateID);

                    return base.City + ", " + s.Abbrev;
                }
                else
                {
                    return "";
                }
            }

        }

        public void Load(int iID)
        {
            CDbLocation dbDt = new CDbLocation();
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
            COLocation o;

            s = new XmlSerializer(typeof(COLocation));
            sr = new System.IO.StringReader(strXml);

            o = new COLocation();
            o = (COLocation)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbLocation dbDt = new CDbLocation();
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
            CDbLocation dbDt = new CDbLocation();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COLocation o;
            XmlSerializer s;
            StringWriter sw;

            o = new COLocation();
            s = new XmlSerializer(typeof(COLocation));
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
            CDbLocation dbDt = new CDbLocation();

            return dbDt.GetList();
        }

        public static SqlDataReader GetList(int custID)
        {
            CDbLocation dbDt = new CDbLocation();

            return dbDt.GetList(custID);
        }
    }
}
