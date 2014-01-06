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
    public class CBBudgetExpenseSheet : COBudgetExpenseSheet
    {
        public CBBudgetExpenseSheet()
        {
            base.Clear();
        }

        public void Load(int iID)
        {
            CDbBudgetExpenseSheet dbDt = new CDbBudgetExpenseSheet();
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
            COBudgetExpenseSheet o;

            s = new XmlSerializer(typeof(COBudgetExpenseSheet));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetExpenseSheet();
            o = (COBudgetExpenseSheet)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudgetExpenseSheet dbDt = new CDbBudgetExpenseSheet();
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
            CDbBudgetExpenseSheet dbDt = new CDbBudgetExpenseSheet();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudgetExpenseSheet o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetExpenseSheet();
            s = new XmlSerializer(typeof(COBudgetExpenseSheet));
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
            CDbBudgetExpenseSheet dbDt = new CDbBudgetExpenseSheet();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByBudgetGroup(int budgetID, int group)
        {
            CDbBudgetExpenseSheet dbDt = new CDbBudgetExpenseSheet();

            return dbDt.GetListByBudgetGroup(budgetID, group);
        }

        public static void CopyBudgetExpenseWorksheet(int originalID, int newBudID)
        {
            CDbBudgetExpenseSheet dbDt = new CDbBudgetExpenseSheet();

            dbDt.CopyBudgetExpenseWorksheet(originalID, newBudID);
        }
    }
}
