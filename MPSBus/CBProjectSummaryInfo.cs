using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBProjectSummaryInfo : COProjectSummaryInfo
    {
        public void Load(int iID)
        {
            CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();
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
            COProjectSummaryInfo o;

            s = new XmlSerializer(typeof(COProjectSummaryInfo));
            sr = new System.IO.StringReader(strXml);

            o = new COProjectSummaryInfo();
            o = (COProjectSummaryInfo)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();
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
       


        //public int Save_From_ProjAddEdit_PM_Update() //***********************Added 7/28/2015
        //{
        //    CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();
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
        //        retVal = dbDt.SaveNew_From_ProjAddEdit_PM_Update(tmpDat);
        //        base.ID = retVal;

        //    }

        //    dbDt = null;

        //    return retVal;
        //}

        public static void Delete(int cID)
        {
            CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();

            dbDt.Delete(cID);
        }



        

public static void Delete_SummaryInfo(int sumID, int projID)    //***********************7/30/2015
        {
            CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();

            dbDt.Delete_SummaryInfo(sumID,projID);
        }




        public string GetDataString()
        {
            string tmpStr;
            COProjectSummaryInfo o;
            XmlSerializer s;
            StringWriter sw;

            o = new COProjectSummaryInfo();
            s = new XmlSerializer(typeof(COProjectSummaryInfo));
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
            CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByProjSum(int projSumID)
        {
            CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();

            return dbDt.GetListByProjSum(projSumID);
        }



        public static SqlDataReader GetListByProjMngr(int projMngrID) //**************Added 7/27/2015
        {
            CDbProjectSummaryInfo dbDt = new CDbProjectSummaryInfo();

            return dbDt.GetListByProjMngr(projMngrID);
        }


    }
}
