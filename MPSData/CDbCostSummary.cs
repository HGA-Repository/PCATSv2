using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

using RevSol;

namespace RSMPS
{
    public class CDbCostSummary
    {
        private COCostSummary oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spCostSummary_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COCostSummary();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.Number = dr["Number"].ToString();
                oVar.Manager = dr["Manager"].ToString();
                oVar.Title = dr["Title"].ToString();
                oVar.ShowDollars = Convert.ToBoolean(dr["ShowDollars"]);
                oVar.Comments = dr["Comments"].ToString();
                tmpStr = GetDataString();
            }

            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }

        public string GetByProject(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spCostSummary_ByProjectID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COCostSummary();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.Number = dr["Number"].ToString();
                oVar.Manager = dr["Manager"].ToString();
                oVar.Title = dr["Title"].ToString();
                oVar.ShowDollars = Convert.ToBoolean(dr["ShowDollars"]);
                oVar.Comments = dr["Comments"].ToString();
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
            cmd = new SqlCommand("spCostSummary_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@Number", SqlDbType.VarChar, 50);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Manager", SqlDbType.VarChar, 50);
            prm.Value = oVar.Manager;
            prm = cmd.Parameters.Add("@Title", SqlDbType.VarChar, 200);
            prm.Value = oVar.Title;
            prm = cmd.Parameters.Add("@ShowDollars", SqlDbType.Bit);
            prm.Value = oVar.ShowDollars;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.Text);
            prm.Value = oVar.Comments;
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
            cmd = new SqlCommand("spCostSummary_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@Number", SqlDbType.VarChar, 50);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Manager", SqlDbType.VarChar, 50);
            prm.Value = oVar.Manager;
            prm = cmd.Parameters.Add("@Title", SqlDbType.VarChar, 200);
            prm.Value = oVar.Title;
            prm = cmd.Parameters.Add("@ShowDollars", SqlDbType.Bit);
            prm.Value = oVar.ShowDollars;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.Text);
            prm.Value = oVar.Comments;
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

            s = new XmlSerializer(typeof(COCostSummary));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COCostSummary));
            sr = new System.IO.StringReader(strXml);

            oVar = new COCostSummary();
            oVar = (COCostSummary)s.Deserialize(sr);

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
            cmd = new SqlCommand("spCostSummary_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spCostSummary_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

    }
}
