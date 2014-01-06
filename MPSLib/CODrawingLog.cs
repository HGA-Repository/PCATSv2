using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class CODrawingLog
    {
        private int miID;
        private int miDepartmentID;
        private int miProjectID;
        private int miProjectLeadID;
        private string msWBS;
        private string msHGANumber;
        private string msClientNumber;
        private string msCADNumber;
        private int miActCodeID;
        private int miIsTaskDrwSpec;
        private int miDrawingSizeID;
        private decimal mdBudgetHrs;
        private decimal mdPercentComplete;
        private decimal mdRemainingHrs;
        private decimal mdEarnedHrs;
        private string msTitle1;
        private bool mbTitle1IsTitle;
        private bool mbTitle1IsDesc;
        private string msTitle2;
        private bool mbTitle2IsTitle;
        private bool mbTitle2IsDesc;
        private string msTitle3;
        private bool mbTitle3IsTitle;
        private bool mbTitle3IsDesc;
        private string msTitle4;
        private bool mbTitle4IsTitle;
        private bool mbTitle4IsDesc;
        private string msTitle5;
        private bool mbTitle5IsTitle;
        private bool mbTitle5IsDesc;
        private string msTitle6;
        private bool mbTitle6IsTitle;
        private bool mbTitle6IsDesc;
        private string msRevision;
        private int miReleasedDrawingID;
        private DateTime mdDateRevised;
        private DateTime mdDateDue;
        private DateTime mdDateLate;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int DepartmentID
        {
            get { return miDepartmentID; }
            set { miDepartmentID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public int ProjectLeadID
        {
            get { return miProjectLeadID; }
            set { miProjectLeadID = value; }
        }

        public string WBS
        {
            get { return msWBS; }
            set { msWBS = value; }
        }

        public string HGANumber
        {
            get { return msHGANumber; }
            set { msHGANumber = value; }
        }

        public string ClientNumber
        {
            get { return msClientNumber; }
            set { msClientNumber = value; }
        }

        public string CADNumber
        {
            get { return msCADNumber; }
            set { msCADNumber = value; }
        }

        public int ActCodeID
        {
            get { return miActCodeID; }
            set { miActCodeID = value; }
        }

        public int IsTaskDrwgSpec
        {
            get { return miIsTaskDrwSpec; }
            set { miIsTaskDrwSpec = value; }
        }

        public int DrawingSizeID
        {
            get { return miDrawingSizeID; }
            set { miDrawingSizeID = value; }
        }

        public decimal BudgetHrs
        {
            get { return mdBudgetHrs; }
            set { mdBudgetHrs = value; }
        }

        public decimal PercentComplete
        {
            get { return mdPercentComplete; }
            set { mdPercentComplete = value; }
        }

        public decimal RemainingHrs
        {
            get { return mdRemainingHrs; }
            set { mdRemainingHrs = value; }
        }

        public decimal EarnedHrs
        {
            get { return mdEarnedHrs; }
            set { mdEarnedHrs = value; }
        }

        public string Title1
        {
            get { return msTitle1; }
            set { msTitle1 = value; }
        }

        public bool Title1IsTitle
        {
            get { return mbTitle1IsTitle; }
            set { mbTitle1IsTitle = value; }
        }

        public bool Title1IsDesc
        {
            get { return mbTitle1IsDesc; }
            set { mbTitle1IsDesc = value; }
        }

        public string Title2
        {
            get { return msTitle2; }
            set { msTitle2 = value; }
        }

        public bool Title2IsTitle
        {
            get { return mbTitle2IsTitle; }
            set { mbTitle2IsTitle = value; }
        }

        public bool Title2IsDesc
        {
            get { return mbTitle2IsDesc; }
            set { mbTitle2IsDesc = value; }
        }

        public string Title3
        {
            get { return msTitle3; }
            set { msTitle3 = value; }
        }

        public bool Title3IsTitle
        {
            get { return mbTitle3IsTitle; }
            set { mbTitle3IsTitle = value; }
        }

        public bool Title3IsDesc
        {
            get { return mbTitle3IsDesc; }
            set { mbTitle3IsDesc = value; }
        }

        public string Title4
        {
            get { return msTitle4; }
            set { msTitle4 = value; }
        }

        public bool Title4IsTitle
        {
            get { return mbTitle4IsTitle; }
            set { mbTitle4IsTitle = value; }
        }

        public bool Title4IsDesc
        {
            get { return mbTitle4IsDesc; }
            set { mbTitle4IsDesc = value; }
        }

        public string Title5
        {
            get { return msTitle5; }
            set { msTitle5 = value; }
        }

        public bool Title5IsTitle
        {
            get { return mbTitle5IsTitle; }
            set { mbTitle5IsTitle = value; }
        }

        public bool Title5IsDesc
        {
            get { return mbTitle5IsDesc; }
            set { mbTitle5IsDesc = value; }
        }

        public string Title6
        {
            get { return msTitle6; }
            set { msTitle6 = value; }
        }

        public bool Title6IsTitle
        {
            get { return mbTitle6IsTitle; }
            set { mbTitle6IsTitle = value; }
        }

        public bool Title6IsDesc
        {
            get { return mbTitle6IsDesc; }
            set { mbTitle6IsDesc = value; }
        }

        public string Revision
        {
            get { return msRevision; }
            set { msRevision = value; }
        }

        public int ReleasedDrawingID
        {
            get { return miReleasedDrawingID; }
            set { miReleasedDrawingID = value; }
        }

        public DateTime DateRevised
        {
            get { return mdDateRevised; }
            set { mdDateRevised = value; }
        }

        public DateTime DateDue
        {
            get { return mdDateDue; }
            set { mdDateDue = value; }
        }

        public DateTime DateLate
        {
            get { return mdDateLate; }
            set { mdDateLate = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miDepartmentID = 0;
            miProjectID = 0;
            miProjectLeadID = 0;
            msWBS = "";
            msHGANumber = "";
            msClientNumber = "";
            msCADNumber = "";
            miActCodeID = 0;
            miIsTaskDrwSpec = 1;
            miDrawingSizeID = 0;
            mdBudgetHrs = 0;
            mdPercentComplete = 0;
            mdRemainingHrs = 0;
            mdEarnedHrs = 0;
            msTitle1 = "";
            mbTitle1IsTitle = false;
            mbTitle1IsDesc = false;
            msTitle2 = "";
            mbTitle2IsTitle = false;
            mbTitle2IsDesc = false;
            msTitle3 = "";
            mbTitle3IsTitle = false;
            mbTitle3IsDesc = false;
            msTitle4 = "";
            mbTitle4IsTitle = false;
            mbTitle4IsDesc = false;
            msTitle5 = "";
            mbTitle5IsTitle = false;
            mbTitle5IsDesc = false;
            msTitle6 = "";
            mbTitle6IsTitle = false;
            mbTitle6IsDesc = false;
            msRevision = "";
            miReleasedDrawingID = 0;
            mdDateRevised = DateTime.Now;
            mdDateDue = DateTime.Now;
            mdDateLate = DateTime.Now;
        }

        public void Copy(CODrawingLog oNew)
        {
            oNew.ID = miID;
            oNew.DepartmentID = miDepartmentID;
            oNew.ProjectID = miProjectID;
            oNew.ProjectLeadID = miProjectLeadID;
            oNew.WBS = msWBS;
            oNew.HGANumber = msHGANumber;
            oNew.ClientNumber = msClientNumber;
            oNew.CADNumber = msCADNumber;
            oNew.ActCodeID = miActCodeID;
            oNew.IsTaskDrwgSpec = miIsTaskDrwSpec;
            oNew.DrawingSizeID = miDrawingSizeID;
            oNew.BudgetHrs = mdBudgetHrs;
            oNew.PercentComplete = mdPercentComplete;
            oNew.RemainingHrs = mdRemainingHrs;
            oNew.EarnedHrs = mdEarnedHrs;
            oNew.Title1 = msTitle1;
            oNew.Title1IsTitle = mbTitle1IsTitle;
            oNew.Title1IsDesc = mbTitle1IsDesc;
            oNew.Title2 = msTitle2;
            oNew.Title2IsTitle = mbTitle2IsTitle;
            oNew.Title2IsDesc = mbTitle2IsDesc;
            oNew.Title3 = msTitle3;
            oNew.Title3IsTitle = mbTitle3IsTitle;
            oNew.Title3IsDesc = mbTitle3IsDesc;
            oNew.Title4 = msTitle4;
            oNew.Title4IsTitle = mbTitle4IsTitle;
            oNew.Title4IsDesc = mbTitle4IsDesc;
            oNew.Title5 = msTitle5;
            oNew.Title5IsTitle = mbTitle5IsTitle;
            oNew.Title5IsDesc = mbTitle5IsDesc;
            oNew.Title6 = msTitle6;
            oNew.Title6IsTitle = mbTitle6IsTitle;
            oNew.Title6IsDesc = mbTitle6IsDesc; 
            oNew.Revision = msRevision;
            oNew.ReleasedDrawingID = miReleasedDrawingID;
            oNew.DateRevised = mdDateRevised;
            oNew.DateDue = mdDateDue;
            oNew.DateLate = mdDateLate;
        }

        public void LoadFromObj(CODrawingLog oOrg)
        {
            miID = oOrg.ID;
            miDepartmentID = oOrg.DepartmentID;
            miProjectID = oOrg.ProjectID;
            miProjectLeadID = oOrg.ProjectLeadID;
            msWBS = oOrg.WBS;
            msHGANumber = oOrg.HGANumber;
            msClientNumber = oOrg.ClientNumber;
            msCADNumber = oOrg.CADNumber;
            miActCodeID = oOrg.ActCodeID;
            miIsTaskDrwSpec = oOrg.IsTaskDrwgSpec;
            miDrawingSizeID = oOrg.DrawingSizeID;
            mdBudgetHrs = oOrg.BudgetHrs;
            mdPercentComplete = oOrg.PercentComplete;
            mdRemainingHrs = oOrg.RemainingHrs;
            mdEarnedHrs = oOrg.EarnedHrs;
            msTitle1 = oOrg.Title1;
            mbTitle1IsTitle = oOrg.Title1IsTitle;
            mbTitle1IsDesc = oOrg.Title1IsDesc;
            msTitle2 = oOrg.Title2;
            mbTitle2IsTitle = oOrg.Title2IsTitle;
            mbTitle2IsDesc = oOrg.Title2IsDesc;
            msTitle3 = oOrg.Title3;
            mbTitle3IsTitle = oOrg.Title3IsTitle;
            mbTitle3IsDesc = oOrg.Title3IsDesc;
            msTitle4 = oOrg.Title4;
            mbTitle4IsTitle = oOrg.Title4IsTitle;
            mbTitle4IsDesc = oOrg.Title4IsDesc;
            msTitle5 = oOrg.Title5;
            mbTitle5IsTitle = oOrg.Title5IsTitle;
            mbTitle5IsDesc = oOrg.Title5IsDesc;
            msTitle6 = oOrg.Title6;
            mbTitle6IsTitle = oOrg.Title6IsTitle;
            mbTitle6IsDesc = oOrg.Title6IsDesc; 
            msRevision = oOrg.Revision;
            miReleasedDrawingID = oOrg.ReleasedDrawingID;
            mdDateRevised = oOrg.DateRevised;
            mdDateDue = oOrg.DateDue;
            mdDateLate = oOrg.DateLate;
        }
    }
}
