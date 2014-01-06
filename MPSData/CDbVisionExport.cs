using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbVisionExport
    {
        public void ResetStagingTables()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_ClearTables_S1", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
            cmd = null;
            cnn = null;
        }

        public SqlDataReader GetBudgetLinesForStaging(int budID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_GetLinesByBudgetID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void RecordExportedBudgetLInes()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_RecordExportedLines", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;
        }

        public void InsertLineForStaging(int BudgetID, string BudgetNumber, int DeptGroup, int Task, int Category, int Activity,
                                            string WBS, string Description, int Quantity, int HoursEach, int TotalHours, decimal LoadedRate,
                                            decimal TotalDollars, decimal BareRate, decimal BareDollars, string LineGUID, bool Planned,
                                            string WBSType, string ResourceID, string OutlineNumber, string AssignmentID, DateTime ExportStartDate, DateTime ExportEndDate, string budgetType)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_InsertStageData", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = BudgetID;
            prm = cmd.Parameters.Add("@BudgetNumber", SqlDbType.VarChar, 50);
            prm.Value = BudgetNumber;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = DeptGroup;
            prm = cmd.Parameters.Add("@Task", SqlDbType.Int);
            prm.Value = Task;
            prm = cmd.Parameters.Add("@Category", SqlDbType.Int);
            prm.Value = Category;
            prm = cmd.Parameters.Add("@Activity", SqlDbType.Int);
            prm.Value = Activity;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = WBS;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            prm.Value = Description;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = Quantity;
            prm = cmd.Parameters.Add("@HoursEach", SqlDbType.Int);
            prm.Value = HoursEach;
            prm = cmd.Parameters.Add("@TotalHours", SqlDbType.Int);
            prm.Value = TotalHours;
            prm = cmd.Parameters.Add("@LoadedRate", SqlDbType.Money);
            prm.Value = LoadedRate;
            prm = cmd.Parameters.Add("@TotalDollars", SqlDbType.Money);
            prm.Value = TotalDollars;
            prm = cmd.Parameters.Add("@BareRate", SqlDbType.Money);
            prm.Value = BareRate;
            prm = cmd.Parameters.Add("@BareDollars", SqlDbType.Money);
            prm.Value = BareDollars;
            prm = cmd.Parameters.Add("@LineGUID", SqlDbType.VarChar, 50);
            prm.Value = LineGUID;
            prm = cmd.Parameters.Add("@Planned", SqlDbType.Bit);
            prm.Value = Planned;
            prm = cmd.Parameters.Add("@WBSType", SqlDbType.VarChar, 4);
            prm.Value = WBSType;
            prm = cmd.Parameters.Add("@ResourceID", SqlDbType.VarChar, 4);
            prm.Value = ResourceID;
            prm = cmd.Parameters.Add("@OutlineNumber", SqlDbType.VarChar, 50);
            prm.Value = OutlineNumber;
            prm = cmd.Parameters.Add("@AssignmentID", SqlDbType.VarChar, 32);
            prm.Value = AssignmentID;
            prm = cmd.Parameters.Add("@ExportStartDate", SqlDbType.SmallDateTime);
            prm.Value = ExportStartDate;
            prm = cmd.Parameters.Add("@ExportEndDate", SqlDbType.SmallDateTime);
            prm.Value = ExportEndDate;
            prm = cmd.Parameters.Add("@LineType", SqlDbType.VarChar, 1);
            prm.Value = budgetType;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
            cmd = null;
            cnn = null;
        }


        public void InsertPlanInformation(string project, string planName, string planNumber, DateTime startDate, DateTime endDate)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_InsertPlanInfo", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
            prm = cmd.Parameters.Add("@PlanName", SqlDbType.VarChar, 200);
            prm.Value = planName;
            prm = cmd.Parameters.Add("@PlanNumber", SqlDbType.VarChar, 50);
            prm.Value = planNumber;
            prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
            prm.Value = startDate;
            prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            prm.Value = endDate;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
            cmd = null;
            cnn = null;
        }

        public void InsertWBS1Outline(string planNumber, string planName, string project, DateTime startDate, DateTime endDate)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_InsertWBS1Outline", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
            prm = cmd.Parameters.Add("@PlanName", SqlDbType.VarChar, 200);
            prm.Value = planName;
            prm = cmd.Parameters.Add("@PlanNumber", SqlDbType.VarChar, 50);
            prm.Value = planNumber;
            prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
            prm.Value = startDate;
            prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            prm.Value = endDate;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
            cmd = null;
            cnn = null;
        }

        public SqlDataReader GetWBS2Levels()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_GetWBS2Levels", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void InsertWBS2Outline(string PlanNumber, string OutlineNumber, string Name, string WBS1, string WBS2, string ParentOutlineNumber, DateTime DateStart, DateTime DateEnd, int ChildrenCount)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_InsertWBS2Outline", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@PlanNumber", SqlDbType.VarChar, 50);
            prm.Value = PlanNumber;
            prm = cmd.Parameters.Add("@OutlineNumber", SqlDbType.VarChar, 50);
            prm.Value = OutlineNumber;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255);
            prm.Value = Name;
            prm = cmd.Parameters.Add("@WBS1", SqlDbType.VarChar, 50);
            prm.Value = WBS1;
            prm = cmd.Parameters.Add("@WBS2", SqlDbType.VarChar, 50);
            prm.Value = WBS2;
            prm = cmd.Parameters.Add("@ParentOutlineNumber", SqlDbType.VarChar, 50);
            prm.Value = ParentOutlineNumber;
            prm = cmd.Parameters.Add("@DateStart", SqlDbType.SmallDateTime);
            prm.Value = DateStart;
            prm = cmd.Parameters.Add("@DateEnd", SqlDbType.SmallDateTime);
            prm.Value = DateEnd;
            prm = cmd.Parameters.Add("@ChildrenCount", SqlDbType.Int);
            prm.Value = ChildrenCount;


            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
            cmd = null;
            cnn = null;

        }

        public SqlDataReader GetWBS3Levels()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_GetWBS3Levels", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void InsertWBS3Outline(string PlanNumber, string OutlineNumber, string Name, string WBS1, string WBS2, string WBS3, string ParentOutlineNumber, DateTime DateStart, DateTime DateEnd, int ChildrenCount, int stageID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_InsertWBS3Outline", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@PlanNumber", SqlDbType.VarChar, 50);
            prm.Value = PlanNumber;
            prm = cmd.Parameters.Add("@OutlineNumber", SqlDbType.VarChar, 50);
            prm.Value = OutlineNumber;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255);
            prm.Value = Name;
            prm = cmd.Parameters.Add("@WBS1", SqlDbType.VarChar, 50);
            prm.Value = WBS1;
            prm = cmd.Parameters.Add("@WBS2", SqlDbType.VarChar, 50);
            prm.Value = WBS2;
            prm = cmd.Parameters.Add("@WBS3", SqlDbType.VarChar, 50);
            prm.Value = WBS3;
            prm = cmd.Parameters.Add("@ParentOutlineNumber", SqlDbType.VarChar, 50);
            prm.Value = ParentOutlineNumber;
            prm = cmd.Parameters.Add("@DateStart", SqlDbType.SmallDateTime);
            prm.Value = DateStart;
            prm = cmd.Parameters.Add("@DateEnd", SqlDbType.SmallDateTime);
            prm.Value = DateEnd;
            prm = cmd.Parameters.Add("@ChildrenCount", SqlDbType.Int);
            prm.Value = ChildrenCount;
            prm = cmd.Parameters.Add("@StageID", SqlDbType.Int);
            prm.Value = stageID;


            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
            cmd = null;
            cnn = null;

        }

        public void UpdateStagingWithOutline()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spExport_UpdateStagingWithOutline", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
            cmd = null;
            cnn = null;
        }

        public void UpdateStagingForPreviousExport(string number)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spVision_ProcessPreviousImport", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 50);
            prm.Value = number;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        public void VisionPullPreviousLoc(string number)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spVision_PullPreviousToLoc", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 50);
            prm.Value = number;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        public void VisionProcessPrevious(string number)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spVision_ProcessPrevToTable", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 50);
            prm.Value = number;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        public void VisionPrepareWBS2()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spVision_PrepareWBS2ForPrev", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        public void VisionPrepareWBS3()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spVision_PrepareWBS3ForPrev", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        public void VisionSyncPrevious()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spVision_SyncPrevToStage", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }
    }
}
  