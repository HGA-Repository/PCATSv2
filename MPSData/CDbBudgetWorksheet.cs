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
    public class CDbBudgetWorksheet
    {
        private COBudgetWorksheet oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetWorksheet_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COBudgetWorksheet();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.BudgetID = Convert.ToInt32(dr["BudgetID"]);
                oVar.DeptGroup = Convert.ToInt32(dr["DeptGroup"]);
                oVar.WorkGuid = dr["WorkGuid"].ToString();
                oVar.WBS = dr["WBS"].ToString();
                oVar.ItemDescription = dr["ItemDescription"].ToString();
                oVar.Quantity = Convert.ToInt32(dr["Quantity"]);
                oVar.Spec211 = Convert.ToInt32(dr["Spec211"]);
                oVar.Spec212 = Convert.ToInt32(dr["Spec212"]);
                oVar.Spec213 = Convert.ToInt32(dr["Spec213"]);
                oVar.Spec214 = Convert.ToInt32(dr["Spec214"]);
                oVar.Spec215 = Convert.ToInt32(dr["Spec215"]);
                oVar.Proc221 = Convert.ToInt32(dr["Proc221"]);
                oVar.Proc222 = Convert.ToInt32(dr["Proc222"]);
                oVar.Proc223 = Convert.ToInt32(dr["Proc223"]);
                oVar.Proc224 = Convert.ToInt32(dr["Proc224"]);
                oVar.Proc225 = Convert.ToInt32(dr["Proc225"]);
                oVar.Proc226 = Convert.ToInt32(dr["Proc226"]);
                oVar.Proc227 = Convert.ToInt32(dr["Proc227"]);
                oVar.Proc229 = Convert.ToInt32(dr["Proc229"]);
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
            cmd = new SqlCommand("spBudgetWorksheet_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@WorkGuid", SqlDbType.VarChar, 50);
            prm.Value = oVar.WorkGuid;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@ItemDescription", SqlDbType.VarChar, 100);
            prm.Value = oVar.ItemDescription;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@Spec211", SqlDbType.Int);
            prm.Value = oVar.Spec211;
            prm = cmd.Parameters.Add("@Spec212", SqlDbType.Int);
            prm.Value = oVar.Spec212;
            prm = cmd.Parameters.Add("@Spec213", SqlDbType.Int);
            prm.Value = oVar.Spec213;
            prm = cmd.Parameters.Add("@Spec214", SqlDbType.Int);
            prm.Value = oVar.Spec214;
            prm = cmd.Parameters.Add("@Spec215", SqlDbType.Int);
            prm.Value = oVar.Spec215;
            prm = cmd.Parameters.Add("@Proc221", SqlDbType.Int);
            prm.Value = oVar.Proc221;
            prm = cmd.Parameters.Add("@Proc222", SqlDbType.Int);
            prm.Value = oVar.Proc222;
            prm = cmd.Parameters.Add("@Proc223", SqlDbType.Int);
            prm.Value = oVar.Proc223;
            prm = cmd.Parameters.Add("@Proc224", SqlDbType.Int);
            prm.Value = oVar.Proc224;
            prm = cmd.Parameters.Add("@Proc225", SqlDbType.Int);
            prm.Value = oVar.Proc225;
            prm = cmd.Parameters.Add("@Proc226", SqlDbType.Int);
            prm.Value = oVar.Proc226;
            prm = cmd.Parameters.Add("@Proc227", SqlDbType.Int);
            prm.Value = oVar.Proc227;
            prm = cmd.Parameters.Add("@Proc229", SqlDbType.Int);
            prm.Value = oVar.Proc229;
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
            cmd = new SqlCommand("spBudgetWorksheet_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@WorkGuid", SqlDbType.VarChar, 50);
            prm.Value = oVar.WorkGuid;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@ItemDescription", SqlDbType.VarChar, 100);
            prm.Value = oVar.ItemDescription;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@Spec211", SqlDbType.Int);
            prm.Value = oVar.Spec211;
            prm = cmd.Parameters.Add("@Spec212", SqlDbType.Int);
            prm.Value = oVar.Spec212;
            prm = cmd.Parameters.Add("@Spec213", SqlDbType.Int);
            prm.Value = oVar.Spec213;
            prm = cmd.Parameters.Add("@Spec214", SqlDbType.Int);
            prm.Value = oVar.Spec214;
            prm = cmd.Parameters.Add("@Spec215", SqlDbType.Int);
            prm.Value = oVar.Spec215;
            prm = cmd.Parameters.Add("@Proc221", SqlDbType.Int);
            prm.Value = oVar.Proc221;
            prm = cmd.Parameters.Add("@Proc222", SqlDbType.Int);
            prm.Value = oVar.Proc222;
            prm = cmd.Parameters.Add("@Proc223", SqlDbType.Int);
            prm.Value = oVar.Proc223;
            prm = cmd.Parameters.Add("@Proc224", SqlDbType.Int);
            prm.Value = oVar.Proc224;
            prm = cmd.Parameters.Add("@Proc225", SqlDbType.Int);
            prm.Value = oVar.Proc225;
            prm = cmd.Parameters.Add("@Proc226", SqlDbType.Int);
            prm.Value = oVar.Proc226;
            prm = cmd.Parameters.Add("@Proc227", SqlDbType.Int);
            prm.Value = oVar.Proc227;
            prm = cmd.Parameters.Add("@Proc229", SqlDbType.Int);
            prm.Value = oVar.Proc229;
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

            s = new XmlSerializer(typeof(COBudgetWorksheet));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBudgetWorksheet));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBudgetWorksheet();
            oVar = (COBudgetWorksheet)s.Deserialize(sr);

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
            cmd = new SqlCommand("spBudgetWorksheet_Delete", cnn.GetConnection());
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


        public bool Delete(int budgetID, int group)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetWorksheet_DeleteBudgetGroup", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budgetID;
            prm = cmd.Parameters.Add("@Group", SqlDbType.Int);
            prm.Value = group;

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
            cmd = new SqlCommand("spBudgetWorksheet_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByBudgetGroup(int budgetID, int group)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetWorksheet_ListAllByBudgetGroup", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budgetID;
            prm = cmd.Parameters.Add("@Group", SqlDbType.Int);
            prm.Value = group;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void CopyBudgetWorksheet(int originalID, int newBudID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetWorksheet_CopyToNewID", cnn.GetConnection());
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
    }
}
