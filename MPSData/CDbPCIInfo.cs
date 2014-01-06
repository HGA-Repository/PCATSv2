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
    public class CDbPCIInfo
    {
        private COPCIInfo oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new COPCIInfo();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.InitiatedByID = Convert.ToInt32(dr["InitiatedByID"]);
                oVar.PCINumber = dr["PCINumber"].ToString();
                oVar.PCITitle = dr["PCITitle"].ToString();
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
                oVar.AffectedMechPipe = Convert.ToBoolean(dr["AffectedMechPipe"]);
                oVar.AffectedCSA = Convert.ToBoolean(dr["AffectedCSA"]);
                oVar.AffectedProjAdmin = Convert.ToBoolean(dr["AffectedProjAdmin"]);
                oVar.AffectedProcess = Convert.ToBoolean(dr["AffectedProcess"]);
                oVar.AffectedEandI = Convert.ToBoolean(dr["AffectedEandI"]);
                oVar.EstimatedEngrHrs = Convert.ToInt32(dr["EstimatedEngrHrs"]);
                oVar.EstimatedEngrDlrs = Convert.ToDecimal(dr["EstimatedEngrDlrs"]);
                oVar.EstimatedEngrTIC = Convert.ToDecimal(dr["EstimatedEngrTIC"]);
                oVar.EstimatedAccuracy = dr["EstimatedAccuracy"].ToString();
                oVar.ScheduleImpact = dr["ScheduleImpact"].ToString();
                oVar.ApprovedProceed = Convert.ToBoolean(dr["ApprovedProceed"]);
                oVar.ApprovedTrack = Convert.ToBoolean(dr["ApprovedTrack"]);
                oVar.ApprovedNot = Convert.ToBoolean(dr["ApprovedNot"]);
                oVar.ProjectManagerID = Convert.ToInt32(dr["ProjectManagerID"]);
                oVar.DateApproved = Convert.ToDateTime(dr["DateApproved"]);
                oVar.IsLocked = Convert.ToBoolean(dr["IsLocked"]);
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
            cmd = new SqlCommand("spPCIInfo_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@InitiatedByID", SqlDbType.Int);
            prm.Value = oVar.InitiatedByID;
            prm = cmd.Parameters.Add("@PCINumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.PCINumber;
            prm = cmd.Parameters.Add("@PCITitle", SqlDbType.VarChar, 100);
            prm.Value = oVar.PCITitle;
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
            prm = cmd.Parameters.Add("@AffectedMechPipe", SqlDbType.Bit);
            prm.Value = oVar.AffectedMechPipe;
            prm = cmd.Parameters.Add("@AffectedCSA", SqlDbType.Bit);
            prm.Value = oVar.AffectedCSA;
            prm = cmd.Parameters.Add("@AffectedProjAdmin", SqlDbType.Bit);
            prm.Value = oVar.AffectedProjAdmin;
            prm = cmd.Parameters.Add("@AffectedProcess", SqlDbType.Bit);
            prm.Value = oVar.AffectedProcess;
            prm = cmd.Parameters.Add("@AffectedEandI", SqlDbType.Bit);
            prm.Value = oVar.AffectedEandI;
            prm = cmd.Parameters.Add("@EstimatedEngrHrs", SqlDbType.Int);
            prm.Value = oVar.EstimatedEngrHrs;
            prm = cmd.Parameters.Add("@EstimatedEngrDlrs", SqlDbType.Money);
            prm.Value = oVar.EstimatedEngrDlrs;
            prm = cmd.Parameters.Add("@EstimatedEngrTIC", SqlDbType.Money);
            prm.Value = oVar.EstimatedEngrTIC;
            prm = cmd.Parameters.Add("@EstimatedAccuracy", SqlDbType.VarChar, 50);
            prm.Value = oVar.EstimatedAccuracy;
            prm = cmd.Parameters.Add("@ScheduleImpact", SqlDbType.VarChar, 500);
            prm.Value = oVar.ScheduleImpact;
            prm = cmd.Parameters.Add("@ApprovedProceed", SqlDbType.Bit);
            prm.Value = oVar.ApprovedProceed;
            prm = cmd.Parameters.Add("@ApprovedTrack", SqlDbType.Bit);
            prm.Value = oVar.ApprovedTrack;
            prm = cmd.Parameters.Add("@ApprovedNot", SqlDbType.Bit);
            prm.Value = oVar.ApprovedNot;
            prm = cmd.Parameters.Add("@ProjectManagerID", SqlDbType.Int);
            prm.Value = oVar.ProjectManagerID;
            prm = cmd.Parameters.Add("@DateApproved", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateApproved;
            prm = cmd.Parameters.Add("@IsLocked", SqlDbType.Bit);
            prm.Value = oVar.IsLocked;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500);
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
            cmd = new SqlCommand("spPCIInfo_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@InitiatedByID", SqlDbType.Int);
            prm.Value = oVar.InitiatedByID;
            prm = cmd.Parameters.Add("@PCINumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.PCINumber;
            prm = cmd.Parameters.Add("@PCITitle", SqlDbType.VarChar, 100);
            prm.Value = oVar.PCITitle;
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
            prm = cmd.Parameters.Add("@AffectedMechPipe", SqlDbType.Bit);
            prm.Value = oVar.AffectedMechPipe;
            prm = cmd.Parameters.Add("@AffectedCSA", SqlDbType.Bit);
            prm.Value = oVar.AffectedCSA;
            prm = cmd.Parameters.Add("@AffectedProjAdmin", SqlDbType.Bit);
            prm.Value = oVar.AffectedProjAdmin;
            prm = cmd.Parameters.Add("@AffectedProcess", SqlDbType.Bit);
            prm.Value = oVar.AffectedProcess;
            prm = cmd.Parameters.Add("@AffectedEandI", SqlDbType.Bit);
            prm.Value = oVar.AffectedEandI;
            prm = cmd.Parameters.Add("@EstimatedEngrHrs", SqlDbType.Int);
            prm.Value = oVar.EstimatedEngrHrs;
            prm = cmd.Parameters.Add("@EstimatedEngrDlrs", SqlDbType.Money);
            prm.Value = oVar.EstimatedEngrDlrs;
            prm = cmd.Parameters.Add("@EstimatedEngrTIC", SqlDbType.Money);
            prm.Value = oVar.EstimatedEngrTIC;
            prm = cmd.Parameters.Add("@EstimatedAccuracy", SqlDbType.VarChar, 50);
            prm.Value = oVar.EstimatedAccuracy;
            prm = cmd.Parameters.Add("@ScheduleImpact", SqlDbType.VarChar, 500);
            prm.Value = oVar.ScheduleImpact;
            prm = cmd.Parameters.Add("@ApprovedProceed", SqlDbType.Bit);
            prm.Value = oVar.ApprovedProceed;
            prm = cmd.Parameters.Add("@ApprovedTrack", SqlDbType.Bit);
            prm.Value = oVar.ApprovedTrack;
            prm = cmd.Parameters.Add("@ApprovedNot", SqlDbType.Bit);
            prm.Value = oVar.ApprovedNot;
            prm = cmd.Parameters.Add("@ProjectManagerID", SqlDbType.Int);
            prm.Value = oVar.ProjectManagerID;
            prm = cmd.Parameters.Add("@DateApproved", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateApproved;
            prm = cmd.Parameters.Add("@IsLocked", SqlDbType.Bit);
            prm.Value = oVar.IsLocked;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500);
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
            s = new XmlSerializer(typeof(COPCIInfo));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COPCIInfo));
            sr = new System.IO.StringReader(strXml);

            oVar = new COPCIInfo();
            oVar = (COPCIInfo)s.Deserialize(sr);

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
            cmd = new SqlCommand("spPCIInfo_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spPCIInfo_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByProjAllDepts(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_ListAllByProjAllDepts", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByProjDept(int projID, int deptID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_ListAllByProjDept", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public int GetCountByProjectID(int projectID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int pciCnt = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_GetPCICountByProject", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projectID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pciCnt = Convert.ToInt32(dr["PCICount"]);
            }

            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return pciCnt;
        }

        public void SetLockOnPCI(int pciID, bool lockState)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_UpdateLockedState", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = pciID;
            prm = cmd.Parameters.Add("@IsLocked", SqlDbType.Bit);
            prm.Value = lockState;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public void CreatePCNFromPCI(int projID, int pciID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_CreatePCNFromPCI", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@PCIID", SqlDbType.Int);
            prm.Value = pciID;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public DataSet GetPCILogByProjID(int projID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_LogListByProjID", cnn.GetConnection());
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

        public void GetPCILogTotalByProjID(int projID, ref int hours, ref decimal estTIC)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            hours = 0;
            estTIC = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_LogTotalsByProjID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                hours = RevSol.RSMath.IsIntegerEx(dr["TotalEstimatedEngrHrs"]);
                estTIC = RevSol.RSMath.IsDecimalEx(dr["TotalEstimatedEngrTIC"]);
            }

            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public void SetPCIComments(int pciID, string comments)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spPCIInfo_UpdateComments", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = pciID;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 500);
            prm.Value = comments;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }
    }
}
