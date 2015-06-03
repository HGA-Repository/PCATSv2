using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBBudgetLine : COBudgetLine
    {
        public void Load(int iID)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();
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
            COBudgetLine o;

            s = new XmlSerializer(typeof(COBudgetLine));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetLine();
            o = (COBudgetLine)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();
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
            CDbBudgetLine dbDt = new CDbBudgetLine();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudgetLine o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetLine();
            s = new XmlSerializer(typeof(COBudgetLine));
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
            CDbBudgetLine dbDt = new CDbBudgetLine();

            return dbDt.GetList();
        }



        public static void AddMissingLines(int budID, int groupID, string wbsCode)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();
            dbDt.AddMissingLines( budID, groupID, wbsCode );
        }


        public static SqlDataReader GetListByBudget(int budID, int groupID, string wbsCode)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();
            return dbDt.GetListByBudget(budID, groupID, wbsCode);
        }

        public static SqlDataReader GetListByBudgetWithWBS(int budID, int groupID, string wbsCode)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();
            return dbDt.GetListByBudgetWithWBS(budID, groupID, wbsCode);
        }

        public static void CopyBudgetLines(int originalID, int newBudID)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();

            dbDt.CopyBudgetLines(originalID, newBudID);
        }

        public static string GetDescriptionByCode(int code)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();

            return dbDt.GetDescriptionByCode(code);
        }

        public static SqlDataReader GetExportListByBudget(int budID)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();

            return dbDt.GetExportListByBudget(budID);
        }


        public static SqlDataReader GetExportList_Hour_ByPCNID(int PCNID) //*********************Added 6/3/15
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();

            return dbDt.GetExportList_Hour_PCN(PCNID);
        }



        public static SqlDataReader GetExportList_Expense_ByPCNID(int PCNID) //*********************Added 6/3/15
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();

            return dbDt.GetExportList_Expense_PCN(PCNID);
        }









        public static SqlDataReader GetWBSListByBudget(int budID)
        {
            CDbBudgetLine dbDt = new CDbBudgetLine();

            return dbDt.GetWBSListByBudget(budID);
        }

       





    }
}
