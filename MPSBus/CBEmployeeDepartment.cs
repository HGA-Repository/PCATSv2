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
    public class CBEmployeeDepartment : COEmployeeDepartment
    {
        public void Load(int iID)
        {
            CDbEmployeeDepartment dbDt = new CDbEmployeeDepartment();
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
            COEmployeeDepartment o;

            s = new XmlSerializer(typeof(COEmployeeDepartment));
            sr = new System.IO.StringReader(strXml);

            o = new COEmployeeDepartment();
            o = (COEmployeeDepartment)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbEmployeeDepartment dbDt = new CDbEmployeeDepartment();
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
            CDbEmployeeDepartment dbDt = new CDbEmployeeDepartment();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COEmployeeDepartment o;
            XmlSerializer s;
            StringWriter sw;

            o = new COEmployeeDepartment();
            s = new XmlSerializer(typeof(COEmployeeDepartment));
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
            CDbEmployeeDepartment dbDt = new CDbEmployeeDepartment();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByEmpID(int empID)
        {
            CDbEmployeeDepartment dbDt = new CDbEmployeeDepartment();

            return dbDt.GetListByEmpID(empID);
        }
    }
}
