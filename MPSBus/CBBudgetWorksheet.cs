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
    public class CBBudgetWorksheet : COBudgetWorksheet
    {
        public CBBudgetWorksheet()
        {
            Clear();
        }

        public void Load(int iID)
        {
            CDbBudgetWorksheet dbDt = new CDbBudgetWorksheet();
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
            COBudgetWorksheet o;

            s = new XmlSerializer(typeof(COBudgetWorksheet));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetWorksheet();
            o = (COBudgetWorksheet)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudgetWorksheet dbDt = new CDbBudgetWorksheet();
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
            CDbBudgetWorksheet dbDt = new CDbBudgetWorksheet();

            dbDt.Delete(cID);
        }

        public static void Delete(int budgetID, int group)
        {
            CDbBudgetWorksheet dbDt = new CDbBudgetWorksheet();

            dbDt.Delete(budgetID, group);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudgetWorksheet o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetWorksheet();
            s = new XmlSerializer(typeof(COBudgetWorksheet));
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
            CDbBudgetWorksheet dbDt = new CDbBudgetWorksheet();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByBudgetGroup(int budgetID, int group)
        {
            CDbBudgetWorksheet dbDt = new CDbBudgetWorksheet();

            return dbDt.GetListByBudgetGroup(budgetID, group);
        }

        public static void CopyBudgetWorksheet(int originalID, int newBudID)
        {
            CDbBudgetWorksheet dbDt = new CDbBudgetWorksheet();

            dbDt.CopyBudgetWorksheet(originalID, newBudID);
        }
    }
}
