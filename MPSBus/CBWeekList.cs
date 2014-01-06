using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;



namespace RSMPS
{
    public class CBWeekList : COWeekList
    {
        public void Load(int iID)
        {
            CDbWeekList dbDt = new CDbWeekList();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public bool IsCurrentPlus(int iID)
        {
            bool retVal = false;

            Load(iID);

            if (base.EndOfWeek > DateTime.Now)
                retVal = true;
            else
                retVal = false;

            return retVal;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COWeekList o;

            s = new XmlSerializer(typeof(COWeekList));
            sr = new System.IO.StringReader(strXml);

            o = new COWeekList();
            o = (COWeekList)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbWeekList dbDt = new CDbWeekList();
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
            CDbWeekList dbDt = new CDbWeekList();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COWeekList o;
            XmlSerializer s;
            StringWriter sw;

            o = new COWeekList();
            s = new XmlSerializer(typeof(COWeekList));
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
            CDbWeekList dbDt = new CDbWeekList();

            return dbDt.GetList();
        }

        public static DataSet GetList(DateTime startDate, DateTime endDate)
        {
            CDbWeekList dbDt = new CDbWeekList();

            return dbDt.GetList(startDate, endDate);
        }
    }
}
