using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbBudgetPCNHour
    {
        private COBudgetPCNHour oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCNHour_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COBudgetPCNHour();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.PCNID = Convert.ToInt32(dr["PCNID"]);
                oVar.Code = dr["Code"].ToString();
                oVar.WBS = dr["WBS"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.Quantity = Convert.ToInt32(dr["Quantity"]);
                oVar.HoursPerItem = Convert.ToInt32(dr["HoursPerItem"]);
                oVar.Rate = Convert.ToDecimal(dr["Rate"]);
                oVar.SubtotalHrs = Convert.ToInt32(dr["SubtotalHrs"]);
                oVar.SubtotalDlrs = Convert.ToDecimal(dr["SubtotalDlrs"]);
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
            cmd = new SqlCommand("spBudgetPCNHour_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = oVar.PCNID;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 50);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@HoursPerItem", SqlDbType.Int);
            prm.Value = oVar.HoursPerItem;
            prm = cmd.Parameters.Add("@Rate", SqlDbType.Money);
            prm.Value = oVar.Rate;
            prm = cmd.Parameters.Add("@SubtotalHrs", SqlDbType.Int);
            prm.Value = oVar.SubtotalHrs;
            prm = cmd.Parameters.Add("@SubtotalDlrs", SqlDbType.Money);
            prm.Value = oVar.SubtotalDlrs;
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
            cmd = new SqlCommand("spBudgetPCNHour_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = oVar.PCNID;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 50);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@HoursPerItem", SqlDbType.Int);
            prm.Value = oVar.HoursPerItem;
            prm = cmd.Parameters.Add("@Rate", SqlDbType.Money);
            prm.Value = oVar.Rate;
            prm = cmd.Parameters.Add("@SubtotalHrs", SqlDbType.Int);
            prm.Value = oVar.SubtotalHrs;
            prm = cmd.Parameters.Add("@SubtotalDlrs", SqlDbType.Money);
            prm.Value = oVar.SubtotalDlrs;
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

            s = new XmlSerializer(typeof(COBudgetPCNHour));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBudgetPCNHour));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBudgetPCNHour();
            oVar = (COBudgetPCNHour)s.Deserialize(sr);

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
            cmd = new SqlCommand("spBudgetPCNHour_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spBudgetPCNHour_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByPCNID(int pcnID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCNHour_ListAllByPCN", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = pcnID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
