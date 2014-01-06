using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbBudgetLine
    {
        private COBudgetLine oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COBudgetLine();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.BudgetID = Convert.ToInt32(dr["BudgetID"]);
                oVar.DeptGroup = Convert.ToInt32(dr["DeptGroup"]);
                oVar.EntryLevel = Convert.ToInt32(dr["EntryLevel"]);
                oVar.Task = Convert.ToInt32(dr["Task"]);
                oVar.Category = Convert.ToInt32(dr["Category"]);
                oVar.Activity = Convert.ToInt32(dr["Activity"]);
                oVar.WBS = dr["WBS"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.Quantity = Convert.ToInt32(dr["Quantity"]);
                oVar.HoursEach = Convert.ToInt32(dr["HoursEach"]);
                oVar.TotalHours = Convert.ToInt32(dr["TotalHours"]);
                oVar.LoadedRate = Convert.ToDecimal(dr["LoadedRate"]);
                oVar.TotalDollars = Convert.ToDecimal(dr["TotalDollars"]);
                oVar.BareRate = Convert.ToDecimal(dr["BareRate"]);
                oVar.BareDollars = Convert.ToDecimal(dr["BareDollars"]);
                tmpStr = GetDataString();
            }

            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }


        public int SaveNew(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@EntryLevel", SqlDbType.Int);
            prm.Value = oVar.EntryLevel;
            prm = cmd.Parameters.Add("@Task", SqlDbType.Int);
            prm.Value = oVar.Task;
            prm = cmd.Parameters.Add("@Category", SqlDbType.Int);
            prm.Value = oVar.Category;
            prm = cmd.Parameters.Add("@Activity", SqlDbType.Int);
            prm.Value = oVar.Activity;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@HoursEach", SqlDbType.Int);
            prm.Value = oVar.HoursEach;
            prm = cmd.Parameters.Add("@TotalHours", SqlDbType.Int);
            prm.Value = oVar.TotalHours;
            prm = cmd.Parameters.Add("@LoadedRate", SqlDbType.Money);
            prm.Value = oVar.LoadedRate;
            prm = cmd.Parameters.Add("@TotalDollars", SqlDbType.Money);
            prm.Value = oVar.TotalDollars;
            prm = cmd.Parameters.Add("@BareRate", SqlDbType.Money);
            prm.Value = oVar.BareRate;
            prm = cmd.Parameters.Add("@BareDollars", SqlDbType.Money);
            prm.Value = oVar.BareDollars;
            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }


        public int SavePrev(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@EntryLevel", SqlDbType.Int);
            prm.Value = oVar.EntryLevel;
            prm = cmd.Parameters.Add("@Task", SqlDbType.Int);
            prm.Value = oVar.Task;
            prm = cmd.Parameters.Add("@Category", SqlDbType.Int);
            prm.Value = oVar.Category;
            prm = cmd.Parameters.Add("@Activity", SqlDbType.Int);
            prm.Value = oVar.Activity;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@HoursEach", SqlDbType.Int);
            prm.Value = oVar.HoursEach;
            prm = cmd.Parameters.Add("@TotalHours", SqlDbType.Int);
            prm.Value = oVar.TotalHours;
            prm = cmd.Parameters.Add("@LoadedRate", SqlDbType.Money);
            prm.Value = oVar.LoadedRate;
            prm = cmd.Parameters.Add("@TotalDollars", SqlDbType.Money);
            prm.Value = oVar.TotalDollars;
            prm = cmd.Parameters.Add("@BareRate", SqlDbType.Money);
            prm.Value = oVar.BareRate;
            prm = cmd.Parameters.Add("@BareDollars", SqlDbType.Money);
            prm.Value = oVar.BareDollars;
            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return oVar.ID;
        }


        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(COBudgetLine));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBudgetLine));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBudgetLine();
            oVar = (COBudgetLine)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }


        public bool Delete(int lID)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_Delete", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            try
            {
                cmd.ExecuteNonQuery();

                retVal = true;
            }
            catch
            {
                retVal = false;
            }

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }


        public SqlDataReader GetList()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader AddMissingLines(int budID, int groupID, string wbs)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_AddMissingLines", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budID;
            prm = cmd.Parameters.Add("@GroupID", SqlDbType.Int);
            prm.Value = groupID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = wbs;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader GetListByBudget(int budID, int groupID, string wbs)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_ListByBudget", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budID;
            prm = cmd.Parameters.Add("@GroupID", SqlDbType.Int);
            prm.Value = groupID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = wbs;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByBudgetWithWBS(int budID, int groupID, string wbs)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_ListByBudgetWithWBS", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budID;
            prm = cmd.Parameters.Add("@GroupID", SqlDbType.Int);
            prm.Value = groupID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = wbs;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void CopyBudgetLines(int originalID, int newBudID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_CopyToNewID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@OriginalID", SqlDbType.Int);
            prm.Value = originalID;
            prm = cmd.Parameters.Add("@NewBudgetID", SqlDbType.Int);
            prm.Value = newBudID;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public string GetDescriptionByCode(int code)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_GetActivityByCode", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@Code", SqlDbType.Int);
            prm.Value = code;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                tmpStr = dr["Description"].ToString();
            }

            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }

        public SqlDataReader GetExportListByBudget(int budID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_BudgetExcelExport1", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetWBSListByBudget(int budID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetLine_GetWBSListForBudget", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            cmd = null;

            return dr;
        }
    }
}
