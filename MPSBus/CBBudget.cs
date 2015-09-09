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
    public class CBBudget : COBudget
    {
        public CBBudget()
        {
            base.Clear();
        }

        public string GetNumber()
        {
            string tmpNumber;
            string number;
            CBProject p = new CBProject();
            CBBudgetPCN pcn = new CBBudgetPCN();

            p.Load(base.ProjectID);
            pcn.Load(base.PCNID);

            tmpNumber = p.Number;
            int test = tmpNumber.IndexOf("-");

            if (tmpNumber.IndexOf("-") > 1)
                number = tmpNumber.Substring(0, tmpNumber.IndexOf("-"));
            else
                number = tmpNumber;

            if (base.Revision > 0)
                number += " -r" + base.Revision.ToString();

            if (pcn.ID > 0)
                number += " -PCN" + pcn.PCNNumber;

            if (base.IsLocked == true)
                number = "*" + number;

            return number;
        }

        public string GetCleanNumber()
        {
            string tmpNumber;
            string number;
            CBProject p = new CBProject();
            CBBudgetPCN pcn = new CBBudgetPCN();

            p.Load(base.ProjectID);
            pcn.Load(base.PCNID);

            tmpNumber = p.Number;
            int test = tmpNumber.IndexOf("-");

            if (tmpNumber.IndexOf("-") > 1)
                number = tmpNumber.Substring(0, tmpNumber.IndexOf("-"));
            else
                number = tmpNumber;

            if (base.Revision > 0)
                number += "-r" + base.Revision.ToString();

            if (pcn.ID > 0)
                number += "-PCN" + pcn.PCNNumber;

            return number;
        }

        public void Load(int iID)
        {
            CDbBudget dbDt = new CDbBudget();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadByProject(int iProjID)
        {
            CDbBudget dbDt = new CDbBudget();
            string tmpDat;

            tmpDat = dbDt.GetByProjectID(iProjID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COBudget o;

            s = new XmlSerializer(typeof(COBudget));
            sr = new System.IO.StringReader(strXml);

            o = new COBudget();
            o = (COBudget)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudget dbDt = new CDbBudget();
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
            CDbBudget dbDt = new CDbBudget();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudget o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudget();
            s = new XmlSerializer(typeof(COBudget));
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
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByProject(int projID)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetListByProject(projID);
        }

        public static int GetNextRevision(int projID)
        {
            CDbBudget dbDt = new CDbBudget();
            int lastRev = 0;

            lastRev = dbDt.GetLastRevision(projID);

            lastRev++;

            return lastRev;
        }

        public static void MakeBudgetActive(int budID)
        {
            CDbBudget dbDt = new CDbBudget();

            dbDt.MakeBudgetActive(budID);
        }

        public static void MakeBudgetDefault(int budID)
        {
            CDbBudget dbDt = new CDbBudget();

            dbDt.MakeBudgetDefault(budID);
        }

        public static void MakeBudgetLockedUnlocked(int budID, bool isLocked)
        {
            CDbBudget dbDt = new CDbBudget();

            dbDt.MakeBudgetLockedUnlocked(budID, isLocked);
        }

        public static DataSet GetBudgetSummaryForReport(int budgetID, string wbs)
        {
            CDbBudget dbDt = new CDbBudget();
            return dbDt.GetBudgetSummaryForReport(budgetID, wbs);
        }

        public static int GetTotalBudgetHours(int budgetID, string wbs)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetTotalBudgetHours(budgetID, wbs);
        }

        public static decimal GetTotalBudgetHourDollars(int budgetID, string wbs)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetTotalBudgetHourDollars(budgetID, wbs);
        }

        public static decimal GetTotalBudgetExpenses(int budgetID)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetTotalBudgetExpenses(budgetID);
        }

        public static decimal GetContingencyForBudget(int budgetID)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetContingencyForBudget(budgetID);
        }

        public static DataSet GetBudgetDetailsForReport(int budgetID, string wbs)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetBudgetDetailsForReport(budgetID, wbs);
        }

        public static DataSet GetBudgetDetails_SpecificationProcurementForReport(int budgetID) //**********************************Added 9/1
        {
            CDbBudget dbDt = new CDbBudget();
            return dbDt.GetBudgetDetails_SpecificationProcurementForReport(budgetID);


        }

        public static DataSet GetWorksheet_TravelExpenses_DetailsForReport(int budgetID) //**********************************Added 9/1
        {
            CDbBudget dbDt = new CDbBudget();
            return dbDt.GetWorksheet_TravelExpenses_DetailsForReport(budgetID);


        }





        public static DataSet GetWorksheet_Expenses_DetailsForReport(int budgetID, string wbs) //**********************************Added 8/31
        {
            CDbBudget dbDt = new CDbBudget();
            return dbDt.GetBudgetDetails_WorkSheet_ExpenseForReport(budgetID, wbs);


        }



        public static DataSet GetBudgetDetails_WorkSheet_PCN_ExpenseForReport(int budgetID, string wbs) //**********************************Added 9/3/2015
        {
            CDbBudget dbDt = new CDbBudget();
            return dbDt.GetBudgetDetails_WorkSheet_PCN_ExpenseForReport(budgetID, wbs);


        }

        public static DataSet GetBudgetDetails_PCN(int budgetID, string wbs) //**********************************Added 9/4/2015
        {
            CDbBudget dbDt = new CDbBudget();
            return dbDt.GetBudgetDetails_PCN(budgetID, wbs);


        }

        



        public static DataSet GetWorksheet_DetailsForReport(int budgetID, string wbs) //**********************************Added 8/31
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetWorkSheet_DetailsForReport(budgetID, wbs);
           // return dbDt.GetBudgetDetailsForReport(budgetID, wbs);

           
        }

        public static DataSet GetWorksheetDetailsForReport(int budgetID, string wbs) //**********************************Added 8/26
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetWorkSheetDetailsForReport(budgetID, wbs);
        }

        public static DataSet GetExpenseDetailsForReport(int budgetID, string wbs) //**********************************Added 8/26
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetExpenseDetailsForReport(budgetID, wbs);
        }


        public static DataSet GetBudgetJobstatForReport(int budgetID, string wbs)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetBudgetJobstatForReport(budgetID, wbs);
        }

        public static DataSet GetBudgetAccountingEntryForReport(int budgetID, string wbs)
        {
            CDbBudget dbDt = new CDbBudget();

            return dbDt.GetBudgetAccountingEntryForReport(budgetID, wbs);
        }

        public static void CreateBudgetInJobStat(int budID)
        {
            CDbBudget dbDt = new CDbBudget();

            dbDt.CreateBudgetInJobStat(budID);
        }

        public static void CopyBudgetToProject(int budID, int newProjID, int rev)
        {
            CDbBudget dbDt = new CDbBudget();

            dbDt.CopyBudgetToProject(budID, newProjID, rev);
        }
    }
}
