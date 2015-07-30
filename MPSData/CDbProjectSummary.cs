using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CDbProjectSummary
    {
        private COProjectSummary oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummary_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProjectSummary();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                oVar.ClientFeedback = dr["ClientFeedback"].ToString();
                oVar.QualityImp = dr["QualityImp"].ToString();
                oVar.NewWorkProp = dr["NewWorkProp"].ToString();
                oVar.Distribution = dr["DistributionList"].ToString();
                tmpStr = GetDataString();
            }

            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }

        public string GetByEmployeeID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummary_ByEmployeeID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProjectSummary();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                oVar.ClientFeedback = dr["ClientFeedback"].ToString();
                oVar.QualityImp = dr["QualityImp"].ToString();
                oVar.NewWorkProp = dr["NewWorkProp"].ToString();
                oVar.Distribution = dr["DistributionList"].ToString();
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
            cmd = new SqlCommand("spProjectSummary_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@ClientFeedback", SqlDbType.Text);
            prm.Value = oVar.ClientFeedback;
            prm = cmd.Parameters.Add("@QualityImp", SqlDbType.Text);
            prm.Value = oVar.QualityImp;
            prm = cmd.Parameters.Add("@NewWorkProp", SqlDbType.Text);
            prm.Value = oVar.NewWorkProp;
            prm = cmd.Parameters.Add("@DistributionList", SqlDbType.Text);
            prm.Value = oVar.Distribution;

            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

                                //public int SaveNew_From_PMUpdate(string strXml)       //********************Added 7/27/2015
                                //{
                                //    RSLib.CDbConnection cnn;
                                //    SqlCommand cmd;
                                //    SqlParameter prm;
                                //    int retVal = 0;

                                //    LoadVals(strXml);

                                //    cnn = new RSLib.CDbConnection();
                                //    cmd = new SqlCommand("spProjectSummary_Insert_From_ProjAddEdit_PM_Update", cnn.GetConnection());
                                //    cmd.CommandType = CommandType.StoredProcedure;


                                //    prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
                                //    prm.Direction = ParameterDirection.Output;

                                //    prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                                //    prm.Value = oVar.EmployeeID;
                                //    //prm = cmd.Parameters.Add("@ClientFeedback", SqlDbType.Text);
                                //    //prm.Value = oVar.ClientFeedback;
                                //    //prm = cmd.Parameters.Add("@QualityImp", SqlDbType.Text);
                                //    //prm.Value = oVar.QualityImp;
                                //    //prm = cmd.Parameters.Add("@NewWorkProp", SqlDbType.Text);
                                //    //prm.Value = oVar.NewWorkProp;
                                //    //prm = cmd.Parameters.Add("@DistributionList", SqlDbType.Text);
                                //    //prm.Value = oVar.Distribution;

                                //    cmd.ExecuteNonQuery();

                                //    retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                                //    prm = null;
                                //    cmd = null;
                                //    cnn.CloseConnection();
                                //    cnn = null;

                                //    return retVal;
                                //}







        public int SavePrev(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummary_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@ClientFeedback", SqlDbType.Text);
            prm.Value = oVar.ClientFeedback;
            prm = cmd.Parameters.Add("@QualityImp", SqlDbType.Text);
            prm.Value = oVar.QualityImp;
            prm = cmd.Parameters.Add("@NewWorkProp", SqlDbType.Text);
            prm.Value = oVar.NewWorkProp;
            prm = cmd.Parameters.Add("@DistributionList", SqlDbType.Text);
            prm.Value = oVar.Distribution;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return oVar.ID;
        }

                                    //        public int SavePrev_PMUpdate(string strXml,int prevID, int newID, int projID)  //************Added*****7/28/2015
                                    //{
                                    //    RSLib.CDbConnection cnn;
                                    //    SqlCommand cmd;
                                    //    SqlParameter prm;

                                    //    LoadVals(strXml);

                                    //    cnn = new RSLib.CDbConnection();
                                    //    cmd = new SqlCommand("spProjectSummary_PM_Update", cnn.GetConnection());
                                    //    cmd.CommandType = CommandType.StoredProcedure;


                                    //    prm = cmd.Parameters.Add("@PrevPMID", SqlDbType.Int);
                                    //    prm.Value = prevID;
                                    //    prm = cmd.Parameters.Add("@NewPMID", SqlDbType.Int);
                                    //    prm.Value = newID;

                                    //    prm = cmd.Parameters.Add("@projectID", SqlDbType.Int);
                                    //    prm.Value = projID;
            

                                    //    cmd.ExecuteNonQuery();

                                    //    prm = null;
                                    //    cmd = null;
                                    //    cnn.CloseConnection();
                                    //    cnn = null;

                                    //    return oVar.ID;
                                    //}





        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(COProjectSummary));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COProjectSummary));
            sr = new System.IO.StringReader(strXml);

            oVar = new COProjectSummary();
            oVar = (COProjectSummary)s.Deserialize(sr);

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
            cmd = new SqlCommand("spProjectSummary_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spProjectSummary_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetPMReport(int empID)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_PMReport1", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetPMCustReport(int empID)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_PMReportCust1", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetVarianceReport(int indx, int pmID)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            switch (indx)
            {
                case 0:     // all
                    cmd = new SqlCommand("spRPRT_ResourceVariance", cnn.GetConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60 * 2;
            
                    break;
                case 1:     // pm
                    cmd = new SqlCommand("spRPRT_ResourceVarianceByPM", cnn.GetConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60 * 2;
                    prm = cmd.Parameters.Add("@ProjMngrID", SqlDbType.Int);
                    prm.Value = pmID;
                    break;
                case 2:          // summary
                    cmd = new SqlCommand("spRPRT_ResourceVarianceSummary", cnn.GetConnection());
                    cmd.CommandTimeout = 60 * 2;
                    cmd.CommandType = CommandType.StoredProcedure;
                  
                    break;
                case 3:     // all, pipeline
                    cmd = new SqlCommand("spRPRT_ResourceVarianceForPipeline", cnn.GetConnection());
                    cmd.CommandTimeout = 60 * 2;
                    cmd.CommandType = CommandType.StoredProcedure;
                  
                    break;
                case 4:    // summary, pipeline
                    cmd = new SqlCommand("spRPRT_ResourceVarianceSummaryForPipeline", cnn.GetConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60 * 2;
                   
                    break;
                default:         // all Dept Groups
                    cmd = new SqlCommand("spRPRT_ResourceVarianceByDeptGroup", cnn.GetConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
                    prm.Value = indx;
                    break;
            }

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }


        public DataSet GetVarianceReportSummary()
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_ResourceVarianceSummary", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetForecastRemaining(bool usePipe)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            if (usePipe == true)
                cmd = new SqlCommand("spRPRT_ForecastRemainingForPipeline", cnn.GetConnection(120));
            else
                cmd = new SqlCommand("spRPRT_ForecastRemaining", cnn.GetConnection(120));
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60 * 2;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
        public DataSet GetForecastRemainingNew(int ENGPLSPM)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            if (ENGPLSPM == 3)
                cmd = new SqlCommand("spRPRT_ForecastRemainingPGM", cnn.GetConnection(120));
            else
                cmd = new SqlCommand("spRPRT_ForecastRemaining", cnn.GetConnection(120));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60 * 2;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

    }
}
