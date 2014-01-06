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
    public class CBBudgetExpenseLine : COBudgetExpenseLine
    {
        public void Load(int iID)
        {
            CDbBudgetExpenseLine dbDt = new CDbBudgetExpenseLine();
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
            COBudgetExpenseLine o;

            s = new XmlSerializer(typeof(COBudgetExpenseLine));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetExpenseLine();
            o = (COBudgetExpenseLine)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudgetExpenseLine dbDt = new CDbBudgetExpenseLine();
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
            CDbBudgetExpenseLine dbDt = new CDbBudgetExpenseLine();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudgetExpenseLine o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetExpenseLine();
            s = new XmlSerializer(typeof(COBudgetExpenseLine));
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
            CDbBudgetExpenseLine exp = new CDbBudgetExpenseLine();
            exp.AddMissingLines(budID, groupID, wbsCode);
        }

        public static SqlDataReader GetList()
        {
            CDbBudgetExpenseLine dbDt = new CDbBudgetExpenseLine();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByBudget(int budID, int groupID)
        {
            CDbBudgetExpenseLine dbDt = new CDbBudgetExpenseLine();

            return dbDt.GetListByBudget(budID, groupID);
        }

        public static void CopyExpenseLines(int originalID, int newBudID)
        {
            CDbBudgetExpenseLine dbDt = new CDbBudgetExpenseLine();
            
            dbDt.CopyExpenseLines(originalID, newBudID);
        }
    }
}
