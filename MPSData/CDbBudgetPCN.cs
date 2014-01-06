using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbBudgetPCN
    {
        private COBudgetPCN oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new COBudgetPCN();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.BudgetID = Convert.ToInt32(dr["BudgetID"]);
                oVar.InitiatedByID = Convert.ToInt32(dr["InitiatedByID"]);
                oVar.PCNNumber = dr["PCNNumber"].ToString();
                oVar.PCNTitle = dr["PCNTitle"].ToString();
                oVar.PCNStatusID = Convert.ToInt32(dr["PCNStatusID"]);
                oVar.DateInitiated = Convert.ToDateTime(dr["DateInitiated"]);
                oVar.RequestedBy = dr["RequestedBy"].ToString();
                oVar.DateRequested = Convert.ToDateTime(dr["DateRequested"]);
                oVar.DescOfChange = dr["DescOfChange"].ToString();
                oVar.ReasonDesignError = Convert.ToBoolean(dr["ReasonDesignError"]);
                oVar.ReasonVendorError = Convert.ToBoolean(dr["ReasonVendorError"]);
                oVar.ReasonEstimatingError = Convert.ToBoolean(dr["ReasonEstimatingError"]);
                oVar.ReasonContractorError = Convert.ToBoolean(dr["ReasonContractorError"]);
                oVar.ReasonSchedule = Convert.ToBoolean(dr["ReasonSchedule"]);
                oVar.ReasonScopeAdd = Convert.ToBoolean(dr["ReasonScopeAdd"]);
                oVar.ReasonScopeDel = Convert.ToBoolean(dr["ReasonScopeDel"]);
                oVar.ReasonDesignChange = Convert.ToBoolean(dr["ReasonDesignChange"]);
                oVar.ReasonOther = Convert.ToBoolean(dr["ReasonOther"]);
                oVar.OtherReasonDesc = dr["OtherReasonDesc"].ToString();
                oVar.EstimatedEngrHrs = Convert.ToInt32(dr["EstimatedEngrHrs"]);
                oVar.EstimatedEngrDlrs = Convert.ToDecimal(dr["EstimatedEngrDlrs"]);
                oVar.EstimatedTICDlrs = Convert.ToDecimal(dr["EstimatedTICDlrs"]);
                oVar.EstimateAccuracy = dr["EstimateAccuracy"].ToString();
                oVar.ScheduleImpact = dr["ScheduleImpact"].ToString();
                oVar.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                oVar.IsDisapproved = Convert.ToBoolean(dr["IsDisapproved"]);
                oVar.PrepareControlEstimate = Convert.ToBoolean(dr["PrepareControlEstimate"]);
                oVar.ProjectManagerID = Convert.ToInt32(dr["ProjectManagerID"]);
                oVar.DateApproved = Convert.ToDateTime(dr["DateApproved"]);
                oVar.DateSubmittedToClient = Convert.ToDateTime(dr["DateSubmittedToClient"]);
                oVar.DateReceivedFromClient = Convert.ToDateTime(dr["DateReceivedFromClient"]);
                oVar.Comments = dr["Comments"].ToString();

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
            cmd = new SqlCommand("spBudgetPCN_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@InitiatedByID", SqlDbType.Int);
            prm.Value = oVar.InitiatedByID;
            prm = cmd.Parameters.Add("@PCNNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.PCNNumber;
            prm = cmd.Parameters.Add("@PCNTitle", SqlDbType.VarChar, 100);
            prm.Value = oVar.PCNTitle;
            prm = cmd.Parameters.Add("@PCNStatusID", SqlDbType.Int);
            prm.Value = oVar.PCNStatusID;
            prm = cmd.Parameters.Add("@DateInitiated", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateInitiated;
            prm = cmd.Parameters.Add("@RequestedBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.RequestedBy;
            prm = cmd.Parameters.Add("@DateRequested", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateRequested;
            prm = cmd.Parameters.Add("@DescOfChange", SqlDbType.VarChar, 500);
            prm.Value = oVar.DescOfChange;
            prm = cmd.Parameters.Add("@ReasonDesignError", SqlDbType.Bit);
            prm.Value = oVar.ReasonDesignError;
            prm = cmd.Parameters.Add("@ReasonVendorError", SqlDbType.Bit);
            prm.Value = oVar.ReasonVendorError;
            prm = cmd.Parameters.Add("@ReasonEstimatingError", SqlDbType.Bit);
            prm.Value = oVar.ReasonEstimatingError;
            prm = cmd.Parameters.Add("@ReasonContractorError", SqlDbType.Bit);
            prm.Value = oVar.ReasonContractorError;
            prm = cmd.Parameters.Add("@ReasonSchedule", SqlDbType.Bit);
            prm.Value = oVar.ReasonSchedule;
            prm = cmd.Parameters.Add("@ReasonScopeAdd", SqlDbType.Bit);
            prm.Value = oVar.ReasonScopeAdd;
            prm = cmd.Parameters.Add("@ReasonScopeDel", SqlDbType.Bit);
            prm.Value = oVar.ReasonScopeDel;
            prm = cmd.Parameters.Add("@ReasonDesignChange", SqlDbType.Bit);
            prm.Value = oVar.ReasonDesignChange;
            prm = cmd.Parameters.Add("@ReasonOther", SqlDbType.Bit);
            prm.Value = oVar.ReasonOther;
            prm = cmd.Parameters.Add("@OtherReasonDesc", SqlDbType.VarChar, 50);
            prm.Value = oVar.OtherReasonDesc;
            prm = cmd.Parameters.Add("@EstimatedEngrHrs", SqlDbType.Int);
            prm.Value = oVar.EstimatedEngrHrs;
            prm = cmd.Parameters.Add("@EstimatedEngrDlrs", SqlDbType.Money);
            prm.Value = oVar.EstimatedEngrDlrs;
            prm = cmd.Parameters.Add("@EstimatedTICDlrs", SqlDbType.Money);
            prm.Value = oVar.EstimatedTICDlrs;
            prm = cmd.Parameters.Add("@EstimateAccuracy", SqlDbType.VarChar, 50);
            prm.Value = oVar.EstimateAccuracy;
            prm = cmd.Parameters.Add("@ScheduleImpact", SqlDbType.VarChar, 500);
            prm.Value = oVar.ScheduleImpact;
            prm = cmd.Parameters.Add("@IsApproved", SqlDbType.Bit);
            prm.Value = oVar.IsApproved;
            prm = cmd.Parameters.Add("@IsDisapproved", SqlDbType.Bit);
            prm.Value = oVar.IsDisapproved;
            prm = cmd.Parameters.Add("@PrepareControlEstimate", SqlDbType.Bit);
            prm.Value = oVar.PrepareControlEstimate;
            prm = cmd.Parameters.Add("@ProjectManagerID", SqlDbType.Int);
            prm.Value = oVar.ProjectManagerID;
            prm = cmd.Parameters.Add("@DateApproved", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateApproved;
            prm = cmd.Parameters.Add("@DateSubmittedToClient", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateSubmittedToClient;
            prm = cmd.Parameters.Add("@DateReceivedFromClient", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateReceivedFromClient;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 5000);
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
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@InitiatedByID", SqlDbType.Int);
            prm.Value = oVar.InitiatedByID;
            prm = cmd.Parameters.Add("@PCNNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.PCNNumber;
            prm = cmd.Parameters.Add("@PCNTitle", SqlDbType.VarChar, 100);
            prm.Value = oVar.PCNTitle;
            prm = cmd.Parameters.Add("@PCNStatusID", SqlDbType.Int);
            prm.Value = oVar.PCNStatusID;
            prm = cmd.Parameters.Add("@DateInitiated", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateInitiated;
            prm = cmd.Parameters.Add("@RequestedBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.RequestedBy;
            prm = cmd.Parameters.Add("@DateRequested", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateRequested;
            prm = cmd.Parameters.Add("@DescOfChange", SqlDbType.VarChar, 500);
            prm.Value = oVar.DescOfChange;
            prm = cmd.Parameters.Add("@ReasonDesignError", SqlDbType.Bit);
            prm.Value = oVar.ReasonDesignError;
            prm = cmd.Parameters.Add("@ReasonVendorError", SqlDbType.Bit);
            prm.Value = oVar.ReasonVendorError;
            prm = cmd.Parameters.Add("@ReasonEstimatingError", SqlDbType.Bit);
            prm.Value = oVar.ReasonEstimatingError;
            prm = cmd.Parameters.Add("@ReasonContractorError", SqlDbType.Bit);
            prm.Value = oVar.ReasonContractorError;
            prm = cmd.Parameters.Add("@ReasonSchedule", SqlDbType.Bit);
            prm.Value = oVar.ReasonSchedule;
            prm = cmd.Parameters.Add("@ReasonScopeAdd", SqlDbType.Bit);
            prm.Value = oVar.ReasonScopeAdd;
            prm = cmd.Parameters.Add("@ReasonScopeDel", SqlDbType.Bit);
            prm.Value = oVar.ReasonScopeDel;
            prm = cmd.Parameters.Add("@ReasonDesignChange", SqlDbType.Bit);
            prm.Value = oVar.ReasonDesignChange;
            prm = cmd.Parameters.Add("@ReasonOther", SqlDbType.Bit);
            prm.Value = oVar.ReasonOther;
            prm = cmd.Parameters.Add("@OtherReasonDesc", SqlDbType.VarChar, 50);
            prm.Value = oVar.OtherReasonDesc;
            prm = cmd.Parameters.Add("@EstimatedEngrHrs", SqlDbType.Int);
            prm.Value = oVar.EstimatedEngrHrs;
            prm = cmd.Parameters.Add("@EstimatedEngrDlrs", SqlDbType.Money);
            prm.Value = oVar.EstimatedEngrDlrs;
            prm = cmd.Parameters.Add("@EstimatedTICDlrs", SqlDbType.Money);
            prm.Value = oVar.EstimatedTICDlrs;
            prm = cmd.Parameters.Add("@EstimateAccuracy", SqlDbType.VarChar, 50);
            prm.Value = oVar.EstimateAccuracy;
            prm = cmd.Parameters.Add("@ScheduleImpact", SqlDbType.VarChar, 500);
            prm.Value = oVar.ScheduleImpact;
            prm = cmd.Parameters.Add("@IsApproved", SqlDbType.Bit);
            prm.Value = oVar.IsApproved;
            prm = cmd.Parameters.Add("@IsDisapproved", SqlDbType.Bit);
            prm.Value = oVar.IsDisapproved;
            prm = cmd.Parameters.Add("@PrepareControlEstimate", SqlDbType.Bit);
            prm.Value = oVar.PrepareControlEstimate;
            prm = cmd.Parameters.Add("@ProjectManagerID", SqlDbType.Int);
            prm.Value = oVar.ProjectManagerID;
            prm = cmd.Parameters.Add("@DateApproved", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateApproved;
            prm = cmd.Parameters.Add("@DateSubmittedToClient", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateSubmittedToClient;
            prm = cmd.Parameters.Add("@DateReceivedFromClient", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateReceivedFromClient;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 5000);
            prm.Value = oVar.Comments;

            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;
            s = new XmlSerializer(typeof(COBudgetPCN));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBudgetPCN));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBudgetPCN();
            oVar = (COBudgetPCN)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }

        public bool Delete(int iID)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_Delete", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;
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
            cmd = new SqlCommand("spBudgetPCN_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByProject(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_ListAllByProject", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public int GetCountByProject(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int currCount = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_GetCountByProject", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                currCount = Convert.ToInt32(dr["Cnt"]);
            }

            dr.Close();
            cnn.CloseConnection();

            return currCount;
        }

        public DataSet GetBudgetPCNInfoForReport(int pcnID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_BudgetPCNInfo", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = pcnID;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public int GetBudgetPCNHours(int pcnID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int totHrs = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_GetTotalHours", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = pcnID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                totHrs = Convert.ToInt32(dr["TotHrs"]);
            }
            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return totHrs;
        }

        public decimal GetBudgetPCNDollars(int pcnID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            decimal totDlrs = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_GetTotalDollars", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = pcnID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                totDlrs = Convert.ToDecimal(dr["TotDlrs"]);
            }
            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return totDlrs;
        }

        public DataSet GetPCNLogByProjID(int projID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_LogListByProjID", cnn.GetConnection());
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

        public void SetClientDate(int pcnID, DateTime clientSubmitted, DateTime clientReceived, string comments)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_UpdateClientDates", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = pcnID;
            prm = cmd.Parameters.Add("@ClientSubmitted", SqlDbType.SmallDateTime);
            prm.Value = clientSubmitted;
            prm = cmd.Parameters.Add("@ClientReceived", SqlDbType.SmallDateTime);
            prm.Value = clientReceived;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500);
            prm.Value = comments;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public void GetPCILogTotalByProjID(int projID, ref int hours, ref decimal estTIC, ref int mhAdd, ref decimal dlrAdd, ref decimal trend)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            hours = 0;
            estTIC = 0;
            mhAdd = 0;
            dlrAdd = 0;
            trend = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_LogTotalsByProjID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                hours = RevSol.RSMath.IsIntegerEx(dr["EstimatedEngrHrs"]);
                estTIC = RevSol.RSMath.IsDecimalEx(dr["EstimatedEngrDlrs"]);
                mhAdd = RevSol.RSMath.IsIntegerEx(dr["BudgetMHAdd"]);
                dlrAdd = RevSol.RSMath.IsDecimalEx(dr["BudgetDollarAdd"]);
                trend = RevSol.RSMath.IsDecimalEx(dr["TrendValue"]);
            }

            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public int GetBudgetsWithPCN(int pcnID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int cnt = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_GetCountByPCN", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@PCNID", SqlDbType.Int);
            prm.Value = pcnID;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cnt = Convert.ToInt32(dr["Cnt"]);
            }

            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return cnt;
        }

        public void SetCurrentStatus(int pcnID, int statusID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetPCN_UpdateStatus", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = pcnID;
            prm = cmd.Parameters.Add("@StatusID", SqlDbType.Int);
            prm.Value = statusID;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }
    }
}
