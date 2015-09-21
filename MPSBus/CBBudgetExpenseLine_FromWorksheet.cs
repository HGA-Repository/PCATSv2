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
    public class CBBudgetExpenseLine_FromWorkSheet : COBudgetExpenseLine_FromWorkSheet
    {
        public void Load(int iID)
        {
            CDbBudgetExpenseLine_FromWorkSheet dbDt = new CDbBudgetExpenseLine_FromWorkSheet();
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
            COBudgetExpenseLine_FromWorkSheet o;

            s = new XmlSerializer(typeof(COBudgetExpenseLine_FromWorkSheet));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetExpenseLine_FromWorkSheet();
            o = (COBudgetExpenseLine_FromWorkSheet)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudgetExpenseLine_FromWorkSheet dbDt = new CDbBudgetExpenseLine_FromWorkSheet();
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
            CDbBudgetExpenseLine_FromWorkSheet dbDt = new CDbBudgetExpenseLine_FromWorkSheet();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudgetExpenseLine_FromWorkSheet o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetExpenseLine_FromWorkSheet();
            s = new XmlSerializer(typeof(COBudgetExpenseLine_FromWorkSheet));
            sw = new StringWriter();

            base.Copy(o);
            s.Serialize(sw, o);

            tmpStr = sw.ToString();

            o = null;
            s = null;
            sw = null;

            return tmpStr;
        }



        public static void AddMissingLines(int budID, int groupID, string wbsCode)
        {
            CDbBudgetExpenseLine_FromWorkSheet exp = new CDbBudgetExpenseLine_FromWorkSheet();
            exp.AddMissingLines(budID, groupID, wbsCode);
        }

        public static SqlDataReader GetList()
        {
            CDbBudgetExpenseLine_FromWorkSheet dbDt = new CDbBudgetExpenseLine_FromWorkSheet();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByBudget(int budID, int groupID)
        {
            CDbBudgetExpenseLine_FromWorkSheet dbDt = new CDbBudgetExpenseLine_FromWorkSheet();

            return dbDt.GetListByBudget(budID, groupID);
        }

        public static void CopyExpenseLines(int originalID, int newBudID)
        {
            CDbBudgetExpenseLine_FromWorkSheet dbDt = new CDbBudgetExpenseLine_FromWorkSheet();
            
            dbDt.CopyExpenseLines(originalID, newBudID);
        }
    }
}
