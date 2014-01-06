using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudgetPCN
    {
        private int miID;
        private int miDepartmentID;
        private int miProjectID;
        private int miBudgetID;
        private int miInitiatedByID;
        private string msPCNNumber;
        private string msPCNTitle;
        private int miPCNStatusID;
        private DateTime mdtDateInitiated;
        private string msRequestedBy;
        private DateTime mdtDateRequested;
        private string msDescOfChange;
        private bool mbReasonDesignError;
        private bool mbReasonVendorError;
        private bool mbReasonEstimatingError;
        private bool mbReasonContractorError;
        private bool mbReasonSchedule;
        private bool mbReasonScopeAdd;
        private bool mbReasonScopeDel;
        private bool mbReasonDesignChange;
        private bool mbReasonOther;
        private string msOtherReasonDesc;
        private int miEstimatedEngrHrs;
        private decimal mdEstimatedEngrDlrs;
        private decimal mdEstimatedTICDlrs;
        private string msEstimateAccuracy;
        private string msScheduleImpact;
        private bool mbIsApproved;
        private bool mbIsDisapproved;
        private bool mbPrepareControlEstimate;
        private int miProjectManagerID;
        private DateTime mdtDateApproved;
        private DateTime mdtDateSubmittedToClient;
        private DateTime mdtDateReceivedFromClient;
        private string msComments;

        private dsPCN mdsPCNData;

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

        public int BudgetID
        {
            get { return miBudgetID; }
            set { miBudgetID = value; }
        }

        public int InitiatedByID
        {
            get { return miInitiatedByID; }
            set { miInitiatedByID = value; }
        }

        public string PCNNumber
        {
            get { return msPCNNumber; }
            set { msPCNNumber = value; }
        }

        public string PCNTitle
        {
            get { return msPCNTitle; }
            set { msPCNTitle = value; }
        }

        public int PCNStatusID
        {
            get { return miPCNStatusID; }
            set { miPCNStatusID = value; }
        }

        public DateTime DateInitiated
        {
            get { return mdtDateInitiated; }
            set { mdtDateInitiated = value; }
        }

        public string RequestedBy
        {
            get { return msRequestedBy; }
            set { msRequestedBy = value; }
        }

        public DateTime DateRequested
        {
            get { return mdtDateRequested; }
            set { mdtDateRequested = value; }
        }

        public string DescOfChange
        {
            get { return msDescOfChange; }
            set { msDescOfChange = value; }
        }

        public bool ReasonDesignError
        {
            get { return mbReasonDesignError; }
            set { mbReasonDesignError = value; }
        }

        public bool ReasonVendorError
        {
            get { return mbReasonVendorError; }
            set { mbReasonVendorError = value; }
        }

        public bool ReasonEstimatingError
        {
            get { return mbReasonEstimatingError; }
            set { mbReasonEstimatingError = value; }
        }

        public bool ReasonContractorError
        {
            get { return mbReasonContractorError; }
            set { mbReasonContractorError = value; }
        }

        public bool ReasonSchedule
        {
            get { return mbReasonSchedule; }
            set { mbReasonSchedule = value; }
        }

        public bool ReasonScopeAdd
        {
            get { return mbReasonScopeAdd; }
            set { mbReasonScopeAdd = value; }
        }

        public bool ReasonScopeDel
        {
            get { return mbReasonScopeDel; }
            set { mbReasonScopeDel = value; }
        }

        public bool ReasonDesignChange
        {
            get { return mbReasonDesignChange; }
            set { mbReasonDesignChange = value; }
        }

        public bool ReasonOther
        {
            get { return mbReasonOther; }
            set { mbReasonOther = value; }
        }

        public string OtherReasonDesc
        {
            get { return msOtherReasonDesc; }
            set { msOtherReasonDesc = value; }
        }

        public int EstimatedEngrHrs
        {
            get { return miEstimatedEngrHrs; }
            set { miEstimatedEngrHrs = value; }
        }

        public decimal EstimatedEngrDlrs
        {
            get { return mdEstimatedEngrDlrs; }
            set { mdEstimatedEngrDlrs = value; }
        }

        public decimal EstimatedTICDlrs
        {
            get { return mdEstimatedTICDlrs; }
            set { mdEstimatedTICDlrs = value; }
        }

        public string EstimateAccuracy
        {
            get { return msEstimateAccuracy; }
            set { msEstimateAccuracy = value; }
        }

        public string ScheduleImpact
        {
            get { return msScheduleImpact; }
            set { msScheduleImpact = value; }
        }

        public bool IsApproved
        {
            get { return mbIsApproved; }
            set { mbIsApproved = value; }
        }

        public bool IsDisapproved
        {
            get { return mbIsDisapproved; }
            set { mbIsDisapproved = value; }
        }

        public bool PrepareControlEstimate
        {
            get { return mbPrepareControlEstimate; }
            set { mbPrepareControlEstimate = value; }
        }

        public int ProjectManagerID
        {
            get { return miProjectManagerID; }
            set { miProjectManagerID = value; }
        }

        public DateTime DateApproved
        {
            get { return mdtDateApproved; }
            set { mdtDateApproved = value; }
        }

        public DateTime DateSubmittedToClient
        {
            get { return mdtDateSubmittedToClient; }
            set { mdtDateSubmittedToClient = value; }
        }

        public DateTime DateReceivedFromClient
        {
            get { return mdtDateReceivedFromClient; }
            set { mdtDateReceivedFromClient = value; }
        }

        public string Comments
        {
            get { return msComments; }
            set { msComments = value; }
        }

        public dsPCN PCNData
        {
            get { return mdsPCNData; }
            set { mdsPCNData = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miDepartmentID = 0;
            miProjectID = 0;
            miBudgetID = 0;
            miInitiatedByID = 0;
            msPCNNumber = "";
            msPCNTitle = "";
            miPCNStatusID = 1;
            mdtDateInitiated = DateTime.Now;
            msRequestedBy = "";
            mdtDateRequested = DateTime.Now;
            msDescOfChange = "";
            mbReasonDesignError = false;
            mbReasonVendorError = false;
            mbReasonEstimatingError = false;
            mbReasonContractorError = false;
            mbReasonSchedule = false;
            mbReasonScopeAdd = false;
            mbReasonScopeDel = false;
            mbReasonDesignChange = false;
            mbReasonOther = false;
            msOtherReasonDesc = "";
            miEstimatedEngrHrs = 0;
            mdEstimatedEngrDlrs = 0;
            mdEstimatedTICDlrs = 0;
            msEstimateAccuracy = "";
            msScheduleImpact = "";
            mbIsApproved = false;
            mbIsDisapproved = false;
            mbPrepareControlEstimate = false;
            miProjectManagerID = 0;
            mdtDateApproved = DateTime.Now;
            mdtDateSubmittedToClient = RevSol.RSUtility.DefaultDate();
            mdtDateReceivedFromClient = RevSol.RSUtility.DefaultDate();
            msComments = "";
            
            mdsPCNData = new dsPCN();
        }

        public void Copy(COBudgetPCN oNew)
        {
            oNew.ID = miID;
            oNew.DepartmentID = miDepartmentID;
            oNew.ProjectID = miProjectID;
            oNew.BudgetID = miBudgetID;
            oNew.InitiatedByID = miInitiatedByID;
            oNew.PCNNumber = msPCNNumber;
            oNew.PCNTitle = msPCNTitle;
            oNew.PCNStatusID = miPCNStatusID;
            oNew.DateInitiated = mdtDateInitiated;
            oNew.RequestedBy = msRequestedBy;
            oNew.DateRequested = mdtDateRequested;
            oNew.DescOfChange = msDescOfChange;
            oNew.ReasonDesignError = mbReasonDesignError;
            oNew.ReasonVendorError = mbReasonVendorError;
            oNew.ReasonEstimatingError = mbReasonEstimatingError;
            oNew.ReasonContractorError = mbReasonContractorError;
            oNew.ReasonSchedule = mbReasonSchedule;
            oNew.ReasonScopeAdd = mbReasonScopeAdd;
            oNew.ReasonScopeDel = mbReasonScopeDel;
            oNew.ReasonDesignChange = mbReasonDesignChange;
            oNew.ReasonOther = mbReasonOther;
            oNew.OtherReasonDesc = msOtherReasonDesc;
            oNew.EstimatedEngrHrs = miEstimatedEngrHrs;
            oNew.EstimatedEngrDlrs = mdEstimatedEngrDlrs;
            oNew.EstimatedTICDlrs = mdEstimatedTICDlrs;
            oNew.EstimateAccuracy = msEstimateAccuracy;
            oNew.ScheduleImpact = msScheduleImpact;
            oNew.IsApproved = mbIsApproved;
            oNew.IsDisapproved = mbIsDisapproved;
            oNew.PrepareControlEstimate = mbPrepareControlEstimate;
            oNew.ProjectManagerID = miProjectManagerID;
            oNew.DateApproved = mdtDateApproved;
            oNew.DateSubmittedToClient = mdtDateSubmittedToClient;
            oNew.DateReceivedFromClient = mdtDateReceivedFromClient;
            oNew.Comments = msComments;

            oNew.PCNData = mdsPCNData;
        }

        public void LoadFromObj(COBudgetPCN oOrg)
        {
            miID = oOrg.ID;
            miDepartmentID = oOrg.DepartmentID;
            miProjectID = oOrg.ProjectID;
            miBudgetID = oOrg.BudgetID;
            miInitiatedByID = oOrg.InitiatedByID;
            msPCNNumber = oOrg.PCNNumber;
            msPCNTitle = oOrg.PCNTitle;
            miPCNStatusID = oOrg.PCNStatusID;
            mdtDateInitiated = oOrg.DateInitiated;
            msRequestedBy = oOrg.RequestedBy;
            mdtDateRequested = oOrg.DateRequested;
            msDescOfChange = oOrg.DescOfChange;
            mbReasonDesignError = oOrg.ReasonDesignError;
            mbReasonVendorError = oOrg.ReasonVendorError;
            mbReasonEstimatingError = oOrg.ReasonEstimatingError;
            mbReasonContractorError = oOrg.ReasonContractorError;
            mbReasonSchedule = oOrg.ReasonSchedule;
            mbReasonScopeAdd = oOrg.ReasonScopeAdd;
            mbReasonScopeDel = oOrg.ReasonScopeDel;
            mbReasonDesignChange = oOrg.ReasonDesignChange;
            mbReasonOther = oOrg.ReasonOther;
            msOtherReasonDesc = oOrg.OtherReasonDesc;
            miEstimatedEngrHrs = oOrg.EstimatedEngrHrs;
            mdEstimatedEngrDlrs = oOrg.EstimatedEngrDlrs;
            mdEstimatedTICDlrs = oOrg.EstimatedTICDlrs;
            msEstimateAccuracy = oOrg.EstimateAccuracy;
            msScheduleImpact = oOrg.ScheduleImpact;
            mbIsApproved = oOrg.IsApproved;
            mbIsDisapproved = oOrg.IsDisapproved;
            mbPrepareControlEstimate = oOrg.PrepareControlEstimate;
            miProjectManagerID = oOrg.ProjectManagerID;
            mdtDateApproved = oOrg.DateApproved;
            mdtDateSubmittedToClient = oOrg.DateSubmittedToClient;
            mdtDateReceivedFromClient = oOrg.DateReceivedFromClient;
            msComments = oOrg.Comments;

            mdsPCNData = oOrg.PCNData;
        }
    }
}
