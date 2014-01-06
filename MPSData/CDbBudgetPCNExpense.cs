using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbBudgetPCNExpense
    {
        private COBudgetPCNExpense oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCNExpense_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COBudgetPCNExpense();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.PCNID = Convert.ToInt32(dr["PCNID"]);
                oVar.Code = dr["Code"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.DlrsPerItem = Convert.ToDecimal(dr["DlrsPerItem"]);
                oVar.NumItems = Convert.ToInt32(dr["NumItems"]);
                oVar.MUPerc = Convert.ToDecimal(dr["MUPerc"]);
                oVar.MarkUp = Convert.ToDecimal(dr["MarkUp"]);
                oVar.TotalCost = Convert.ToDecimal(dr["TotalCost"]);
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
            cmd = new SqlCommand("spBudgetPCNExpense_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = oVar.PCNID;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@DlrsPerItem", SqlDbType.Money);
            prm.Value = oVar.DlrsPerItem;
            prm = cmd.Parameters.Add("@NumItems", SqlDbType.Int);
            prm.Value = oVar.NumItems;
            prm = cmd.Parameters.Add("@MUPerc", SqlDbType.Money);
            prm.Value = oVar.MUPerc;
            prm = cmd.Parameters.Add("@MarkUp", SqlDbType.Money);
            prm.Value = oVar.MarkUp;
            prm = cmd.Parameters.Add("@TotalCost", SqlDbType.Money);
            prm.Value = oVar.TotalCost;
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
            cmd = new SqlCommand("spBudgetPCNExpense_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = oVar.PCNID;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@DlrsPerItem", SqlDbType.Money);
            prm.Value = oVar.DlrsPerItem;
            prm = cmd.Parameters.Add("@NumItems", SqlDbType.Int);
            prm.Value = oVar.NumItems;
            prm = cmd.Parameters.Add("@MUPerc", SqlDbType.Money);
            prm.Value = oVar.MUPerc;
            prm = cmd.Parameters.Add("@MarkUp", SqlDbType.Money);
            prm.Value = oVar.MarkUp;
            prm = cmd.Parameters.Add("@TotalCost", SqlDbType.Money);
            prm.Value = oVar.TotalCost;
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

            s = new XmlSerializer(typeof(COBudgetPCNExpense));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBudgetPCNExpense));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBudgetPCNExpense();
            oVar = (COBudgetPCNExpense)s.Deserialize(sr);

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
            cmd = new SqlCommand("spBudgetPCNExpense_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spBudgetPCNExpense_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByPCN(int pcnID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCNExpense_ListAllByPCN", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = pcnID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

    }
}
