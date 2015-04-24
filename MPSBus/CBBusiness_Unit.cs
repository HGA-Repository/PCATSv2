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
    public class CBBusiness_Unit : COBusiness_Unit
    {
        public void Load(int iID)
        {
            CDbBusiness_Unit dbDt = new CDbBusiness_Unit();
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
            COBusiness_Unit o;

            s = new XmlSerializer(typeof(COBusiness_Unit));
            sr = new System.IO.StringReader(strXml);

            o = new COBusiness_Unit();
            o = (COBusiness_Unit)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        //public int Save()
        //{
        //    CDbDepartment dbDt = new CDbDepartment();
        //    string tmpDat;
        //    int retVal;

        //    tmpDat = GetDataString();

        //    if (base.ID > 0)
        //    {
        //        dbDt.SavePrev(tmpDat);
        //        retVal = base.ID;
        //    }
        //    else
        //    {
        //        retVal = dbDt.SaveNew(tmpDat);
        //        base.ID = retVal;
        //    }

        //    dbDt = null;

        //    return retVal;
        //}


        public int Save()
        {
            CDbBusiness_Unit dbDt = new CDbBusiness_Unit();
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
            CDbBusiness_Unit dbDt = new CDbBusiness_Unit();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBusiness_Unit o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBusiness_Unit();
            s = new XmlSerializer(typeof(COBusiness_Unit));
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
            CDbBusiness_Unit dbDt = new CDbBusiness_Unit();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListForDisp()
        {
            CDbBusiness_Unit dbDt = new CDbBusiness_Unit();

            return dbDt.GetListForDisp();
        }
    }
}
