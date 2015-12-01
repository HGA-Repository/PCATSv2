using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
//using System.Windows.Forms; //***************Added 6/11/15*****MZ
namespace RSMPS
{
    public class CBBudgetPCN : COBudgetPCN
    {
        public CBBudgetPCN()
        {
            base.Clear();
        }

        public static int TotalHours(int pcnID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();

            return dbDt.GetBudgetPCNHours(pcnID);
        }

        public static decimal TotalDollars(int pcnID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();

            return dbDt.GetBudgetPCNDollars(pcnID);
        }

        public void Load(int iID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadWithData(int iID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;

            base.PCNData = new dsPCN();

            SqlDataReader dr;
            DataRow d;

            dr = CBBudgetPCNHour.GetListByPCN(iID);

            while (dr.Read())
            {
                d = base.PCNData.Tables["PCNHours"].NewRow();

                d["ID"] = dr["ID"];
                d["PCNID"] = dr["PCNID"];
                d["Code"] = dr["Code"];
                d["WBS"] = dr["WBS"];
                d["Description"] = dr["Description"];
                d["Quantity"] = dr["Quantity"];
                d["HoursPerItem"] = dr["HoursPerItem"];
                d["Rate"] = dr["Rate"];
                d["SubtotalHrs"] = dr["SubtotalHrs"];
                d["SubtotalDlrs"] = dr["SubtotalDlrs"];

                base.PCNData.Tables["PCNHours"].Rows.Add(d);
            }

            dr.Close();

            dr = CBBudgetPCNExpense.GetListByPCN(iID);

            while (dr.Read())
            {
                d = base.PCNData.Tables["PCNExpenses"].NewRow();

                d["ID"] = dr["ID"];
                d["PCNID"] = dr["PCNID"];
                d["Code"] = dr["Code"];
                d["Description"] = dr["Description"];
                d["DeptGroup"] = dr["DeptGroup"]; //****************************Added 9/22/2015
                d["DlrsPerItem"] = dr["DlrsPerItem"];
                d["NumItems"] = dr["NumItems"];
                d["MUPerc"] = dr["MUPerc"];
                d["MarkUp"] = dr["MarkUp"];
                d["TotalCost"] = dr["TotalCost"];

                base.PCNData.Tables["PCNExpenses"].Rows.Add(d);
            }

            dr.Close();
           
        }

        public void LoadWithCopyData(int iID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;

            base.PCNData = new dsPCN();

            SqlDataReader dr;
            DataRow d;

            dr = CBBudgetPCNHour.GetListByPCN(iID);

            while (dr.Read())
            {
                d = base.PCNData.Tables["PCNHours"].NewRow();

                d["ID"] = 0;
                d["PCNID"] = dr["PCNID"];
                d["Code"] = dr["Code"];
                d["WBS"] = dr["WBS"];
                d["Description"] = dr["Description"];
                d["Quantity"] = dr["Quantity"];
                d["HoursPerItem"] = dr["HoursPerItem"];
                d["Rate"] = dr["Rate"];
                d["SubtotalHrs"] = dr["SubtotalHrs"];
                d["SubtotalDlrs"] = dr["SubtotalDlrs"];

                base.PCNData.Tables["PCNHours"].Rows.Add(d);
            }

            dr.Close();

            dr = CBBudgetPCNExpense.GetListByPCN(iID);

            while (dr.Read())
            {
                d = base.PCNData.Tables["PCNExpenses"].NewRow();

                d["ID"] = 0;
                d["PCNID"] = dr["PCNID"];
                d["Code"] = dr["Code"];
                d["Description"] = dr["Description"];
                d["DeptGroup"] = dr["DeptGroup"]; //****************************Added 9/22/2015
                d["DlrsPerItem"] = dr["DlrsPerItem"];
                d["NumItems"] = dr["NumItems"];
                d["MUPerc"] = dr["MUPerc"];
                d["MarkUp"] = dr["MarkUp"];
                d["TotalCost"] = dr["TotalCost"];

                base.PCNData.Tables["PCNExpenses"].Rows.Add(d);
            }

            dr.Close();

        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COBudgetPCN o;

            s = new XmlSerializer(typeof(COBudgetPCN));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetPCN();
            o = (COBudgetPCN)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();
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

        public int InitialCopySave()
        {
            //Saves the new line it can now be edited

            CDbBudgetPCN dbDt = new CDbBudgetPCN();
            string tmpDat;
            int retVal;

            tmpDat = GetDataString();

            retVal = dbDt.SaveNew(tmpDat);
            base.ID = retVal;
            dbDt = null;

            return retVal;

        }

        public int SaveWithData()
        {
            int retVal = Save();

            CBBudgetPCNHour hr;
            CBBudgetPCNExpense exp;

            foreach (DataRow dr in base.PCNData.Tables["PCNHours"].Rows)
            {
                hr = new CBBudgetPCNHour();
                Console.WriteLine("The ID and the PCNID in the CBBudgetPCNfile are: ");
                hr.ID = Convert.ToInt32(dr["ID"]);
                Console.WriteLine(hr.ID);
                hr.PCNID = retVal;
                Console.WriteLine(hr.PCNID);
                hr.Code = dr["Code"].ToString();
                hr.WBS = dr["WBS"].ToString();
                hr.Description = dr["Description"].ToString();
                //try                                 //*********************Added 6/11/15*************MZ
                //{
                //    hr.Quantity = Convert.ToInt32(dr["Quantity"]);
                //    hr.HoursPerItem = Convert.ToInt32(dr["HoursPerItem"]);
                //    hr.Rate = Convert.ToDecimal(dr["Rate"]);
                //}
                //catch { 
                    
                //}



                if (dr["Quantity"] == DBNull.Value) hr.Quantity = 0; //****************************Added/Edited 9/22/2015, 
                else hr.Quantity = Convert.ToInt32(dr["Quantity"]);

                if (dr["HoursPerItem"] == DBNull.Value) hr.HoursPerItem = 0; //****************************Added/Edited 9/22/2015, 
                else hr.HoursPerItem = Convert.ToInt32(dr["HoursPerItem"]);


                if (dr["Rate"] == DBNull.Value) hr.Rate= 0; //****************************Added/Edited 9/22/2015, 
                else  hr.Rate = Convert.ToDecimal(dr["Rate"]);
                


                hr.SubtotalHrs = Convert.ToInt32(dr["SubtotalHrs"]);
                hr.SubtotalDlrs = Convert.ToDecimal(dr["SubtotalDlrs"]);

                hr.Save();

                if (Convert.ToInt32(dr["ID"]) < 1)
                {
                    dr["ID"] = hr.ID;
                    dr["PCNID"] = retVal;
                }
            }

            foreach (DataRow dr in base.PCNData.Tables["PCNHoursDeleted"].Rows)
            {
                CBBudgetPCNHour.Delete(Convert.ToInt32(dr["ID"]));
            }

            foreach (DataRow dr in base.PCNData.Tables["PCNExpenses"].Rows)
            {
                exp = new CBBudgetPCNExpense();

                exp.ID = Convert.ToInt32(dr["ID"]);
                exp.PCNID = retVal;
                exp.Code = dr["Code"].ToString();
                exp.Description = dr["Description"].ToString();
                if (dr["DeptGroup"] == DBNull.Value) exp.DeptGroup = 11000; //****************************Added 9/22/2015, Default DeptGroup = 11000, May revisit
                else exp.DeptGroup = Convert.ToInt32(dr["DeptGroup"]);

                //try                             //*********************Added 6/11/15*************MZ
                //{
                //    exp.DlrsPerItem = Convert.ToDecimal(dr["DlrsPerItem"]);
                //    exp.NumItems = Convert.ToInt32(dr["NumItems"]);
                //    exp.MUPerc = Convert.ToDecimal(dr["MUPerc"]);
                //}
                //catch { 
                //}

                if (dr["DlrsPerItem"] == DBNull.Value) exp.DlrsPerItem = 0;//****************************Added/Edited 9/22/2015,
                else exp.DlrsPerItem = Convert.ToDecimal(dr["DlrsPerItem"]);


                if (dr["NumItems"] == DBNull.Value) exp.NumItems = 0;//****************************Added/Edited 9/22/2015,
                else exp.NumItems = Convert.ToInt32(dr["NumItems"]);

                if (dr["NumItems"] == DBNull.Value) exp.MUPerc = 0;//****************************Added/Edited 9/22/2015,
                else exp.MUPerc = Convert.ToDecimal(dr["MUPerc"]);



                exp.MarkUp = Convert.ToDecimal(dr["MarkUp"]);
                exp.TotalCost = Convert.ToDecimal(dr["TotalCost"]);

                exp.Save();

                if (Convert.ToInt32(dr["ID"]) < 1)
                {
                    dr["ID"] = exp.ID;
                    dr["PCNID"] = retVal;
                }
            }

            foreach (DataRow dr in base.PCNData.Tables["PCNExpensesDeleted"].Rows)
            {
                CBBudgetPCNExpense.Delete(Convert.ToInt32(dr["ID"]));
            }

            return retVal;
        }

        public int SaveWithCopyData()
        {
            int retVal = InitialCopySave();

            CBBudgetPCNHour hr;
            CBBudgetPCNExpense exp;

            foreach (DataRow dr in base.PCNData.Tables["PCNHours"].Rows)
            {
                hr = new CBBudgetPCNHour();
                Console.WriteLine("The ID and the PCNID in the CBBudgetPCNfile are: ");
                hr.ID = Convert.ToInt32(dr["ID"]);
                Console.WriteLine(hr.ID);
                hr.PCNID = retVal;
                Console.WriteLine(hr.PCNID);
                hr.Code = dr["Code"].ToString();
                hr.WBS = dr["WBS"].ToString();
                hr.Description = dr["Description"].ToString();
                hr.Quantity = Convert.ToInt32(dr["Quantity"]);
                hr.HoursPerItem = Convert.ToInt32(dr["HoursPerItem"]);
                hr.Rate = Convert.ToDecimal(dr["Rate"]);
                hr.SubtotalHrs = Convert.ToInt32(dr["SubtotalHrs"]);
                hr.SubtotalDlrs = Convert.ToDecimal(dr["SubtotalDlrs"]);

                hr.Save();

                if (Convert.ToInt32(dr["ID"]) < 1)
                {
                    dr["ID"] = hr.ID;
                    dr["PCNID"] = retVal;
                }
            }

            foreach (DataRow dr in base.PCNData.Tables["PCNHoursDeleted"].Rows)
            {
                CBBudgetPCNHour.Delete(Convert.ToInt32(dr["ID"]));
            }

            foreach (DataRow dr in base.PCNData.Tables["PCNExpenses"].Rows)
            {
                exp = new CBBudgetPCNExpense();

                exp.ID = Convert.ToInt32(dr["ID"]);
                exp.PCNID = retVal;
                exp.Code = dr["Code"].ToString();
                exp.Description = dr["Description"].ToString();
               // exp.DeptGroup = Convert.ToInt32(dr["DeptGroup"]); //****************************Added 9/22/2015
                if (dr["DeptGroup"] == DBNull.Value) exp.DeptGroup = 11000; //****************************Added 9/22/2015, Default DeptGroup = 11000, May revisit
                else exp.DeptGroup = Convert.ToInt32(dr["DeptGroup"]);
                exp.DlrsPerItem = Convert.ToDecimal(dr["DlrsPerItem"]);
                exp.NumItems = Convert.ToInt32(dr["NumItems"]);
                exp.MUPerc = Convert.ToDecimal(dr["MUPerc"]);
                exp.MarkUp = Convert.ToDecimal(dr["MarkUp"]);
                exp.TotalCost = Convert.ToDecimal(dr["TotalCost"]);

                exp.Save();

                if (Convert.ToInt32(dr["ID"]) < 1)
                {
                    dr["ID"] = exp.ID;
                    dr["PCNID"] = retVal;
                }
            }

            foreach (DataRow dr in base.PCNData.Tables["PCNExpensesDeleted"].Rows)
            {
                CBBudgetPCNExpense.Delete(Convert.ToInt32(dr["ID"]));
            }

            return retVal;
        }

        public static void Delete(int iID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COBudgetPCN o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetPCN();
            s = new XmlSerializer(typeof(COBudgetPCN));
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
            CDbBudgetPCN dbDt = new CDbBudgetPCN();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByProject(int projID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();

            return dbDt.GetListByProject(projID);
        }

        public string GetNextPCNNumber(int projID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();
            int currCount;
            string newNum;

            currCount = dbDt.GetCountByProject(projID);
            currCount++;

            newNum = Convert.ToDecimal(currCount).ToString("00");

            return newNum;
        }

        public static DataSet GetBudgetPCNInfoForReport(int pcnID)
        {
            CDbBudgetPCN dbDt = new CDbBudgetPCN();

            return dbDt.GetBudgetPCNInfoForReport(pcnID);
        }

        public static DataSet GetPCNLogByProjID(int projID)
        {
            CDbBudgetPCN db = new CDbBudgetPCN();

            return db.GetPCNLogByProjID(projID);
        }

        public static void SetClientDate(int pcnID, DateTime clientSubmitted, DateTime clientReceived, string comments)
        {
            CDbBudgetPCN db = new CDbBudgetPCN();

            db.SetClientDate(pcnID, clientSubmitted, clientReceived, comments);
        }

        public static void GetPCILogTotalByProjID(int projID, ref int hours, ref decimal estTIC, ref int mhAdd, ref decimal dlrAdd, ref decimal trend)
        {
            CDbBudgetPCN db = new CDbBudgetPCN();

            db.GetPCILogTotalByProjID(projID, ref hours, ref estTIC, ref mhAdd, ref dlrAdd, ref trend);
        }

        public static void SetCurrentStatus(int pcnID, int statusID)
        {
            CDbBudgetPCN db = new CDbBudgetPCN();

            db.SetCurrentStatus(pcnID, statusID);
        }

        public static int GetBudgetsWithPCN(int pcnID)
        {
            CDbBudgetPCN db = new CDbBudgetPCN();

            return db.GetBudgetsWithPCN(pcnID);
        }

       
    }
}
