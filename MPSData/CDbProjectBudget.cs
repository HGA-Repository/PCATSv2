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
    public class CDbProjectBudget
    {
        COProjectBudget oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectBudget_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProjectBudget();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                oVar.BudgetHrs = Convert.ToDecimal(dr["BudgetHrs"]);
                tmpStr = GetDataString();
            }

            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }

        public string GetByDeptProj(int deptID, int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectBudget_ByDeptProj", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProjectBudget();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                oVar.BudgetHrs = Convert.ToDecimal(dr["BudgetHrs"]);
                tmpStr = GetDataString();
            }

            dr.Close();
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
            cmd = new SqlCommand("spProjectBudget_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@BudgetHrs", SqlDbType.Money);
            prm.Value = oVar.BudgetHrs;
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
            cmd = new SqlCommand("spProjectBudget_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@BudgetHrs", SqlDbType.Money);
            prm.Value = oVar.BudgetHrs;
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

            s = new XmlSerializer(typeof(COProjectBudget));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COProjectBudget));
            sr = new System.IO.StringReader(strXml);

            oVar = new COProjectBudget();
            oVar = (COProjectBudget)s.Deserialize(sr);

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
            cmd = new SqlCommand("spProjectBudget_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spProjectBudget_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByProjID(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectBudget_ListByProjID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetListDSByProjID(int projID)
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectBudget_ListByProjID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetCostReport(string project, int rprtCase, bool isRollup)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;
            string currDate;

            currDate = DateTime.Now.ToShortDateString();

            cnn = new RSLib.CDbConnection();

            if (isRollup == true)
            {
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2ForRollup_Vision", cnn.GetConnection());
            }
            else
            {
                if (UseNewCodes(project) == true)
                    cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision", cnn.GetConnection());
                   
                else
                    cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision", cnn.GetConnection());
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60 * 3;

            prm = cmd.Parameters.Add("@records", SqlDbType.Int); //*******Added 7/24/2015, because, it was throwing exception in PM Report
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
            prm = cmd.Parameters.Add("@Rprtdate", SqlDbType.SmallDateTime);
            prm.Value = currDate;
            prm = cmd.Parameters.Add("@ReportCase", SqlDbType.Int);
            prm.Value = rprtCase;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            FtcCalculator.UpdateCalculatedField(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetCostReport_ForPM(string project, int rprtCase, bool isRollup) // Added 2/1/16
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;
            string currDate;

            currDate = DateTime.Now.ToShortDateString();

            cnn = new RSLib.CDbConnection();

            if (isRollup == true)
            {
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2ForRollup_Vision", cnn.GetConnection());
            }
            else
            {
                if (UseNewCodes(project) == true)
                  
                 cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision_TestOnFeb", cnn.GetConnection());
                else
                    cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision", cnn.GetConnection());
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60 * 3;

            prm = cmd.Parameters.Add("@records", SqlDbType.Int); //*******Added 7/24/2015, because, it was throwing exception in PM Report
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
            prm = cmd.Parameters.Add("@Rprtdate", SqlDbType.SmallDateTime);
            prm.Value = currDate;
            prm = cmd.Parameters.Add("@ReportCase", SqlDbType.Int);
            prm.Value = rprtCase;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            FtcCalculator.UpdateCalculatedField(ds);

            cnn.CloseConnection();

            return ds;
        }

        private bool UseNewCodes(string project)
        {
            bool retVal;

            try
            {
                if (project == "06031E-OG")
                {
                    retVal = true;
                }
                else if (Convert.ToInt32(project.Substring(0, 2)) < 6)
                {
                    retVal = false;
                }
                else if (Convert.ToInt32(project.Substring(0, 2)) > 96)
                {
                    retVal = false;
                }
                else if (Convert.ToInt32(project.Substring(2, 3)) < 79 && Convert.ToInt32(project.Substring(0, 2)) < 7)
                {
                    retVal = false;
                }
                else
                {
                    retVal = true;
                }
            }
            catch
            {
                retVal = true;
            }

            return retVal;
        }

        public DataSet GetPCNByProject(int projSumID, int projID)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            //cmd = new SqlCommand("spProjectSummaryPCN_ListByProjectID", cnn.GetConnection());
            cmd = new SqlCommand("spProjectSummaryPCN_ListByProjectID1", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = projSumID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
        public DataSet GetSchByProject(int projSumID, int projID)
        {
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummarySch_ListByProjectID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = projSumID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
        public SqlDataReader GetAccountGroupByDiscipline(int discipline)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetGetAccountCodes", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Discipline", SqlDbType.Int);
            prm.Value = discipline;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetAccountGroupByDisciplineForGovernment(int discipline)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetGetAccountCodesForGovernment", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Discipline", SqlDbType.Int);
            prm.Value = discipline;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetExpenseGroupByDiscipline(int discipline)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetGetExpenseCodes", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetExistingVisionExport()
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            //SSS 20131104 SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudget_ExportWBS3List", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetExistingVisionPlan(string number)
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spVision_GetTaskstFromNumber", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@PlanNumber", SqlDbType.VarChar, 50);
            prm.Value = number;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
    }

}
