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
    public class CBUserLevel : COUserLevel
    {
        public void Load(int iID)
        {
            CDbUserLevel dbDt = new CDbUserLevel();
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
            COUserLevel o;

            s = new XmlSerializer(typeof(COUserLevel));
            sr = new System.IO.StringReader(strXml);

            o = new COUserLevel();
            o = (COUserLevel)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbUserLevel dbDt = new CDbUserLevel();
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
            CDbUserLevel dbDt = new CDbUserLevel();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COUserLevel o;
            XmlSerializer s;
            StringWriter sw;

            o = new COUserLevel();
            s = new XmlSerializer(typeof(COUserLevel));
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
            CDbUserLevel dbDt = new CDbUserLevel();

            return dbDt.GetList();
        }

        public static DataSet GetListOfDepartmentLevels(int userID)
        {
            CDbUserLevel dbDt = new CDbUserLevel();

            return dbDt.GetListOfDepartmentLevels(userID);
        }

        public static decimal GetLevelForDepartment(int userID, int deptID)
        {
            CDbUserLevel dbDt = new CDbUserLevel();

            return dbDt.GetLevelForDepartment(userID, deptID);
        }

        public static decimal GetMaxLevelForUser(int userID)
        {
            CDbUserLevel dbDt = new CDbUserLevel();

            return dbDt.GetMaxLevelForUser(userID);
        }
    }
}
