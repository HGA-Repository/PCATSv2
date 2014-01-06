using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COPCIInfo
    {
        private int miID;
        private int miDepartmentID;
        private int miProjectID;
        private int miInitiatedByID;
        private string msPCINumber;
        private string msPCITitle;
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
        private bool mbAffectedMechPipe;
        private bool mbAffectedCSA;
        private bool mbAffectedProjAdmin;
        private bool mbAffectedProcess;
        private bool mbAffectedEandI;
        private int miEstimatedEngrHrs;
        private decimal mdEstimatedEngrDlrs;
        private decimal mdEstimatedEngrTIC;
        private string msEstimatedAccuracy;
        private string msScheduleImpact;
        private bool mbApprovedProceed;
        private bool mbApprovedTrack;
        private bool mbApprovedNot;
        private int miProjectManagerID;
        private DateTime mdtDateApproved;
        private bool mbIsLocked;
        private string msComments;

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

        public int InitiatedByID
        {
            get { return miInitiatedByID; }
            set { miInitiatedByID = value; }
        }

        public string PCINumber
        {
            get { return msPCINumber; }
            set { msPCINumber = value; }
        }

        public string PCITitle
        {
            get { return msPCITitle; }
            set { msPCITitle = value; }
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

        public bool AffectedMechPipe
        {
            get { return mbAffectedMechPipe; }
            set { mbAffectedMechPipe = value; }
        }

        public bool AffectedCSA
        {
            get { return mbAffectedCSA; }
            set { mbAffectedCSA = value; }
        }

        public bool AffectedProjAdmin
        {
            get { return mbAffectedProjAdmin; }
            set { mbAffectedProjAdmin = value; }
        }

        public bool AffectedProcess
        {
            get { return mbAffectedProcess; }
            set { mbAffectedProcess = value; }
        }

        public bool AffectedEandI
        {
            get { return mbAffectedEandI; }
            set { mbAffectedEandI = value; }
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

        public decimal EstimatedEngrTIC
        {
            get { return mdEstimatedEngrTIC; }
            set { mdEstimatedEngrTIC = value; }
        }

        public string EstimatedAccuracy
        {
            get { return msEstimatedAccuracy; }
            set { msEstimatedAccuracy = value; }
        }

        public string ScheduleImpact
        {
            get { return msScheduleImpact; }
            set { msScheduleImpact = value; }
        }

        public bool ApprovedProceed
        {
            get { return mbApprovedProceed; }
            set { mbApprovedProceed = value; }
        }

        public bool ApprovedTrack
        {
            get { return mbApprovedTrack; }
            set { mbApprovedTrack = value; }
        }

        public bool ApprovedNot
        {
            get { return mbApprovedNot; }
            set { mbApprovedNot = value; }
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

        public bool IsLocked
        {
            get { return mbIsLocked; }
            set { mbIsLocked = value; }
        }

        public string Comments
        {
            get { return msComments; }
            set { msComments = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miDepartmentID = 0;
            miProjectID = 0;
            miInitiatedByID = 0;
            msPCINumber = "";
            msPCITitle = "";
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
            mbAffectedMechPipe = false;
            mbAffectedCSA = false;
            mbAffectedProjAdmin = false;
            mbAffectedProcess = false;
            mbAffectedEandI = false;
            miEstimatedEngrHrs = 0;
            mdEstimatedEngrDlrs = 0;
            mdEstimatedEngrTIC = 0;
            msEstimatedAccuracy = "";
            msScheduleImpact = "";
            mbApprovedProceed = false;
            mbApprovedTrack = false;
            mbApprovedNot = false;
            miProjectManagerID = 0;
            mdtDateApproved = DateTime.Now;
            mbIsLocked = false;
            msComments = "";
        }

        public void Copy(COPCIInfo oNew)
        {
            oNew.ID = miID;
            oNew.DepartmentID = miDepartmentID;
            oNew.ProjectID = miProjectID;
            oNew.InitiatedByID = miInitiatedByID;
            oNew.PCINumber = msPCINumber;
            oNew.PCITitle = msPCITitle;
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
            oNew.AffectedMechPipe = mbAffectedMechPipe;
            oNew.AffectedCSA = mbAffectedCSA;
            oNew.AffectedProjAdmin = mbAffectedProjAdmin;
            oNew.AffectedProcess = mbAffectedProcess;
            oNew.AffectedEandI = mbAffectedEandI;
            oNew.EstimatedEngrHrs = miEstimatedEngrHrs;
            oNew.EstimatedEngrDlrs = mdEstimatedEngrDlrs;
            oNew.EstimatedEngrTIC = mdEstimatedEngrTIC;
            oNew.EstimatedAccuracy = msEstimatedAccuracy;
            oNew.ScheduleImpact = msScheduleImpact;
            oNew.ApprovedProceed = mbApprovedProceed;
            oNew.ApprovedTrack = mbApprovedTrack;
            oNew.ApprovedNot = mbApprovedNot;
            oNew.ProjectManagerID = miProjectManagerID;
            oNew.DateApproved = mdtDateApproved;
            oNew.IsLocked = mbIsLocked;
            oNew.Comments = msComments;
        }

        public void LoadFromObj(COPCIInfo oOrg)
        {
            miID = oOrg.ID;
            miDepartmentID = oOrg.DepartmentID;
            miProjectID = oOrg.ProjectID;
            miInitiatedByID = oOrg.InitiatedByID;
            msPCINumber = oOrg.PCINumber;
            msPCITitle = oOrg.PCITitle;
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
            mbAffectedMechPipe = oOrg.AffectedMechPipe;
            mbAffectedCSA = oOrg.AffectedCSA;
            mbAffectedProjAdmin = oOrg.AffectedProjAdmin;
            mbAffectedProcess = oOrg.AffectedProcess;
            mbAffectedEandI = oOrg.AffectedEandI;
            miEstimatedEngrHrs = oOrg.EstimatedEngrHrs;
            mdEstimatedEngrDlrs = oOrg.EstimatedEngrDlrs;
            mdEstimatedEngrTIC = oOrg.EstimatedEngrTIC;
            msEstimatedAccuracy = oOrg.EstimatedAccuracy;
            msScheduleImpact = oOrg.ScheduleImpact;
            mbApprovedProceed = oOrg.ApprovedProceed;
            mbApprovedTrack = oOrg.ApprovedTrack;
            mbApprovedNot = oOrg.ApprovedNot;
            miProjectManagerID = oOrg.ProjectManagerID;
            mdtDateApproved = oOrg.DateApproved;
            mbIsLocked = oOrg.IsLocked;
            msComments = oOrg.Comments;
        }
    }
}
