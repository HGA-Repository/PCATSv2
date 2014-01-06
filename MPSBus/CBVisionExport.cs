using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBVisionExport
    {
        public void ResetStagingTables()
        {
            CDbVisionExport db = new CDbVisionExport();

            db.ResetStagingTables();
        }

        public SqlDataReader GetBudgetLinesForStaging(int budID)
        {
            CDbVisionExport db = new CDbVisionExport();

            return db.GetBudgetLinesForStaging(budID);
        }

        public void RecordExportedBudgetLInes()
        {
            CDbVisionExport db = new CDbVisionExport();

            db.RecordExportedBudgetLInes();
        }

        public void InsertLineForStaging(int BudgetID, string BudgetNumber, int DeptGroup, int Task, int Category, int Activity,
                                            string WBS, string Description, int Quantity, int HoursEach, int TotalHours, decimal LoadedRate,
                                            decimal TotalDollars, decimal BareRate, decimal BareDollars, string LineGUID, bool Planned,
                                            string OutlineNumber, DateTime ExportStartDate, DateTime ExportEndDate, string budgetType)
        {
            CDbVisionExport db = new CDbVisionExport();

            string wbsType = "WBS3";
            string resourceID = "PCAT";
            string assignmentID = "";

            assignmentID = LineGUID.Replace("-", "");

            db.InsertLineForStaging(BudgetID, BudgetNumber, DeptGroup, Task, Category, Activity, WBS, Description, Quantity, HoursEach, TotalHours,
                                    LoadedRate, TotalDollars, BareRate, BareDollars, LineGUID, Planned, wbsType, resourceID, OutlineNumber, assignmentID, ExportStartDate, ExportEndDate, budgetType);
        }

        public void InsertPlanInformation(int budID)
        {
            CDbVisionExport db = new CDbVisionExport();
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();

            bud.Load(budID);
            proj.Load(bud.ProjectID);

            db.InsertPlanInformation(proj.Number, proj.Description, proj.Number, proj.DateStart, proj.DateEnd);
        }

        public void InsertWBS1Outline(int budID)
        {
            CDbVisionExport db = new CDbVisionExport();
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();

            bud.Load(budID);
            proj.Load(bud.ProjectID);

            db.InsertWBS1Outline(proj.Number, proj.Description, proj.Number, proj.DateStart, proj.DateEnd);
        }

        public SqlDataReader GetWBS2Levels()
        {
            CDbVisionExport db = new CDbVisionExport();

            return db.GetWBS2Levels();
        }

        public void InsertWBS2Outline(int budID, string OutlineNumber, string Name, string WBS2, string ParentOutlineNumber,
                                        DateTime DateStart, DateTime DateEnd, int ChildrenCount)
        {
            CDbVisionExport db = new CDbVisionExport();
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();

            bud.Load(budID);
            proj.Load(bud.ProjectID);

            db.InsertWBS2Outline(proj.Number, OutlineNumber, Name, proj.Number, WBS2, ParentOutlineNumber, DateStart, DateEnd, ChildrenCount);
        }

        public SqlDataReader GetWBS3Levels()
        {
            CDbVisionExport db = new CDbVisionExport();

            return db.GetWBS3Levels();
        }

        public void InsertWBS3Outline(int budID, string OutlineNumber, string Name, string WBS2, string WBS3, string ParentOutlineNumber,
                                        DateTime DateStart, DateTime DateEnd, int ChildrenCount, int stageID)
        {
            CDbVisionExport db = new CDbVisionExport();
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();

            bud.Load(budID);
            proj.Load(bud.ProjectID);

            db.InsertWBS3Outline(proj.Number, OutlineNumber, Name, proj.Number, WBS2, WBS3, ParentOutlineNumber, DateStart, DateEnd, ChildrenCount, stageID);
        }

        public void UpdateStagingWithOutline()
        {
            CDbVisionExport db = new CDbVisionExport();

            db.UpdateStagingWithOutline();
        }

        public void UpdateStagingForPreviousExport(string number)
        {
            CDbVisionExport db = new CDbVisionExport();

            db.UpdateStagingForPreviousExport(number);
        }

        public void VisionPullPreviousLoc(string number)
        {
            CDbVisionExport db = new CDbVisionExport();

            db.VisionPullPreviousLoc(number);
        }

        public void VisionProcessPrevious(string number)
        {
            CDbVisionExport db = new CDbVisionExport();

            db.VisionProcessPrevious(number);
        }

        public void VisionPrepareWBS2()
        {
            CDbVisionExport db = new CDbVisionExport();

            db.VisionPrepareWBS2();
        }

        public void VisionPrepareWBS3()
        {
            CDbVisionExport db = new CDbVisionExport();

            db.VisionPrepareWBS3();
        }

        public void VisionSyncPrevious()
        {
            CDbVisionExport db = new CDbVisionExport();

            db.VisionSyncPrevious();
        }
    }
}
