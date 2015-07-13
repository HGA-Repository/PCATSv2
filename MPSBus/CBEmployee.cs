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
    public class CBEmployee : COEmployee
    {
        public void Load(int iID)
        {
            CDbEmployee dbDt = new CDbEmployee();
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
            COEmployee o;

            s = new XmlSerializer(typeof(COEmployee));
            sr = new System.IO.StringReader(strXml);

            o = new COEmployee();
            o = (COEmployee)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbEmployee dbDt = new CDbEmployee();
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
            CDbEmployee dbDt = new CDbEmployee();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COEmployee o;
            XmlSerializer s;
            StringWriter sw;

            o = new COEmployee();
            s = new XmlSerializer(typeof(COEmployee));
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
            CDbEmployee dbDt = new CDbEmployee();

            return dbDt.GetList();
        }


        public static SqlDataReader GetRelationshipManagerList() //***********************Added 7/13/2015
        {
            CDbEmployee dbDt = new CDbEmployee();

            return dbDt.GetRelationshipManagerList();
        }

        public static SqlDataReader GetListProjectManagers()
        {
            CDbEmployee dbDt = new CDbEmployee();

            return dbDt.GetListProjectManagers();
        }

        public static DataSet GetListForCombo()
        {
            CDbEmployee dbDt = new CDbEmployee();

            return dbDt.GetListForCombo();
        }

        public static SqlDataReader GetListByDept(int deptID)
        {
            CDbEmployee dbDt = new CDbEmployee();

            return dbDt.GetListByDept(deptID);
        }

        public static DataSet GetListForComboByDept(int deptID)
        {
            CDbEmployee dbDt = new CDbEmployee();

            return dbDt.GetListByDeptForCombo(deptID);
        }
    }
}
