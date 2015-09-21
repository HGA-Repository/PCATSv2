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
    public class CDbBudgetExpenseLine_FromWorkSheet
    {
        private COBudgetExpenseLine_FromWorkSheet oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetExpenseLine_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COBudgetExpenseLine_FromWorkSheet();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.BudgetID = Convert.ToInt32(dr["BudgetID"]);
                oVar.DeptGroup = Convert.ToInt32(dr["DeptGroup"]);
                oVar.EntryLevel = Convert.ToInt32(dr["EntryLevel"]);
                oVar.Code = dr["Code"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.MarkUp = Convert.ToDecimal(dr["MarkUp"]);
                oVar.UOMID = Convert.ToInt32(dr["UOMID"]);
                oVar.DollarsEach = Convert.ToDecimal(dr["DollarsEach"]);
                oVar.Quantity = Convert.ToInt32(dr["Quantity"]);
                oVar.MarkupDollars = Convert.ToDecimal(dr["MarkupDollars"]);
                oVar.TotalDollars = Convert.ToDecimal(dr["TotalDollars"]);
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
            cmd = new SqlCommand("spBudgetExpenseLine_FromWorkSheet_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@EntryLevel", SqlDbType.Int);
            prm.Value = oVar.EntryLevel;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@MarkUp", SqlDbType.Money);
            prm.Value = oVar.MarkUp;
            prm = cmd.Parameters.Add("@UOMID", SqlDbType.Int);
            prm.Value = oVar.UOMID;
            prm = cmd.Parameters.Add("@DollarsEach", SqlDbType.Money);
            prm.Value = oVar.DollarsEach;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@MarkupDollars", SqlDbType.Money);
            prm.Value = oVar.MarkupDollars;
            prm = cmd.Parameters.Add("@TotalDollars", SqlDbType.Money);
            prm.Value = oVar.TotalDollars;
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
            cmd = new SqlCommand("spBudgetExpenseLine_FromWorkSheet_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@EntryLevel", SqlDbType.Int);
            prm.Value = oVar.EntryLevel;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@MarkUp", SqlDbType.Money);
            prm.Value = oVar.MarkUp;
            prm = cmd.Parameters.Add("@UOMID", SqlDbType.Int);
            prm.Value = oVar.UOMID;
            prm = cmd.Parameters.Add("@DollarsEach", SqlDbType.Money);
            prm.Value = oVar.DollarsEach;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@MarkupDollars", SqlDbType.Money);
            prm.Value = oVar.MarkupDollars;
            prm = cmd.Parameters.Add("@TotalDollars", SqlDbType.Money);
            prm.Value = oVar.TotalDollars;
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

            s = new XmlSerializer(typeof(COBudgetExpenseLine_FromWorkSheet));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBudgetExpenseLine_FromWorkSheet));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBudgetExpenseLine_FromWorkSheet();
            oVar = (COBudgetExpenseLine_FromWorkSheet)s.Deserialize(sr);

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
            cmd = new SqlCommand("spBudgetExpenseLine_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spBudgetExpenseLine_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader GetListByBudget(int budID, int groupID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetExpenseLine_ListByBudget", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budID;
            prm = cmd.Parameters.Add("@GroupID", SqlDbType.Int);
            prm.Value = groupID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void CopyExpenseLines(int originalID, int newBudID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetExpenseLine_CopyToNewID", cnn.GetConnection());
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



        public SqlDataReader AddMissingLines(int budID, int groupID, string wbs)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetExpenseLine_AddMissingLines", cnn.GetConnection());
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


    }
}
