using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CBProjectSummarySch : COProjectSummarySch
    {
        public void Load(int iID)
        {
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();
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
            COProjectSummarySch o;

            s = new XmlSerializer(typeof(COProjectSummarySch));
            sr = new System.IO.StringReader(strXml);

            o = new COProjectSummarySch();
            o = (COProjectSummarySch)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();
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

        public int UpdateSch() //****************************Added 8/11
        {
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();
            string tmpDat;
            int retVal;

            tmpDat = GetDataString();
         
            dbDt.SavePrev(tmpDat);
            retVal = base.ID; 
             dbDt = null;
             return retVal;
        }
        public int InsertSch() //****************************Added 8/11
        {
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();
            string tmpDat;
            int retVal;

            tmpDat = GetDataString();
             retVal = dbDt.SaveNew(tmpDat);
             dbDt = null;

            return retVal;
        }




        //  public static void Delete(int cID) //****************************Edited 8/17
             public  void Delete(int cID)
        {
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COProjectSummarySch o;
            XmlSerializer s;
            StringWriter sw;

            o = new COProjectSummarySch();
            s = new XmlSerializer(typeof(COProjectSummarySch));
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
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByProjectSum(int projSumID)
        {
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();

            return dbDt.GetListByProjectSum(projSumID);
        }

        public static SqlDataReader GetListByProject(int projSumID, int projID)
        {
            CDbProjectSummarySch dbDt = new CDbProjectSummarySch();

            return dbDt.GetListByProject(projSumID, projID);
        }
    }
}
