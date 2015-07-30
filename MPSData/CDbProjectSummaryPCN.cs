using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CDbProjectSummaryPCN
    {
        private COProjectSummaryPCN oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryPCN_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProjectSummaryPCN();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ProjSumID = Convert.ToInt32(dr["ProjSumID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.Number = Convert.ToInt32(dr["Number"]);
                oVar.Description = dr["Description"].ToString();
                oVar.Hours = Convert.ToDecimal(dr["Hours"]);
                oVar.Dollars = Convert.ToDecimal(dr["Dollars"]);
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
            cmd = new SqlCommand("spProjectSummaryPCN_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = oVar.ProjSumID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@Number", SqlDbType.Int);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Hours", SqlDbType.Money);
            prm.Value = oVar.Hours;
            prm = cmd.Parameters.Add("@Dollars", SqlDbType.Money);
            prm.Value = oVar.Dollars;
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
            cmd = new SqlCommand("spProjectSummaryPCN_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = oVar.ProjSumID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@Number", SqlDbType.Int);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Hours", SqlDbType.Money);
            prm.Value = oVar.Hours;
            prm = cmd.Parameters.Add("@Dollars", SqlDbType.Money);
            prm.Value = oVar.Dollars;
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

            s = new XmlSerializer(typeof(COProjectSummaryPCN));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COProjectSummaryPCN));
            sr = new System.IO.StringReader(strXml);

            oVar = new COProjectSummaryPCN();
            oVar = (COProjectSummaryPCN)s.Deserialize(sr);

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
            cmd = new SqlCommand("spProjectSummaryPCN_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spProjectSummaryPCN_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByProjectSum(int projSumID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryPCN_ListBySumID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = projSumID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

                                        //public SqlDataReader GetPCNListByProjectMngr(int EmpID)
                                        //{
                                        //    SqlDataReader dr;
                                        //    RSLib.CDbConnection cnn;
                                        //    SqlCommand cmd;
                                        //    SqlParameter prm;

                                        //    cnn = new RSLib.CDbConnection();
                                        //    cmd = new SqlCommand("spProjectSummaryPCN_ListBySumID", cnn.GetConnection());
                                        //    cmd.CommandType = CommandType.StoredProcedure;

                                        //    prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
                                        //    prm.Value = EmpID;

                                        //    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                                        //    cmd = null;

                                        //    return dr;
                                        //}



        public SqlDataReader GetListByProject(int projSumID, int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryPCN_ListByProjectID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = projSumID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
