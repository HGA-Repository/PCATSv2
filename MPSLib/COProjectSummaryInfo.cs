using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COProjectSummaryInfo
    {
        private int miID;
        private int miProjSumID;
        private int miProjectID;
        private string msSchedule;
        private string msActHigh;
        private string msStaffNeeds;
        private string msCFeedBack;
        private decimal mdPOAmt;
        private decimal mdBilledtoDate;
        private decimal mdPaidtoDate;
        private decimal mdOutstanding;
        private string msClient;
        private string msJob;
        private string msLocation;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int ProjSumID
        {
            get { return miProjSumID; }
            set { miProjSumID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public string Schedule
        {
            get { return msSchedule; }
            set { msSchedule = value; }
        }

        public string ActHigh
        {
            get { return msActHigh; }
            set { msActHigh = value; }
        }

        public string StaffNeeds
        {
            get { return msStaffNeeds; }
            set { msStaffNeeds = value; }
        }
        public string CFeedBack
        {
            get { return msCFeedBack; }
            set { msCFeedBack = value; }
        }
        public decimal POAmt
        {
            get { return mdPOAmt; }
            set { mdPOAmt = value; }
        }
        public decimal BilledtoDate
        {
            get { return mdBilledtoDate; }
            set { mdBilledtoDate = value; }
        }
        public decimal PaidtoDate
        {
            get { return mdPaidtoDate; }
            set { mdPaidtoDate = value; }
        }
        public decimal Outstanding
        {
            get { return mdOutstanding; }
            set { mdOutstanding = value; }
        }
        public string Client
        {
            get { return msClient; }
            set { msClient = value; }
        }
        public string Job
        {
            get { return msJob; }
            set { msJob = value; }
        }
        public string Location
        {
            get { return msLocation; }
            set { msLocation = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjSumID = 0;
            miProjectID = 0;
            msSchedule = "";
            msActHigh = "";
            msStaffNeeds = "";
            msCFeedBack = "";
            mdPOAmt = 0;
            mdBilledtoDate = 0;
            mdPaidtoDate = 0;
            mdOutstanding = 0;
            msClient = "";
            msJob = "";
            msLocation = "";
        }

        public void Copy(COProjectSummaryInfo oNew)
        {
            oNew.ID = miID;
            oNew.ProjSumID = miProjSumID;
            oNew.ProjectID = miProjectID;
            oNew.Schedule = msSchedule;
            oNew.ActHigh = msActHigh;
            oNew.StaffNeeds = msStaffNeeds;
            oNew.CFeedBack = msCFeedBack;
            oNew.POAmt = mdPOAmt;
            oNew.BilledtoDate = mdBilledtoDate;
            oNew.PaidtoDate = mdPaidtoDate;
            oNew.Outstanding = mdOutstanding;
            oNew.Client = msClient;
            oNew.Job = msJob;
            oNew.Location = msLocation;
        }

        public void LoadFromObj(COProjectSummaryInfo oOrg)
        {
            miID = oOrg.ID;
            miProjSumID = oOrg.ProjSumID;
            miProjectID = oOrg.ProjectID;
            msSchedule = oOrg.Schedule;
            msActHigh = oOrg.ActHigh;
            msStaffNeeds = oOrg.StaffNeeds;
            msCFeedBack = oOrg.CFeedBack;
            mdPOAmt = oOrg.POAmt;
            mdBilledtoDate = oOrg.BilledtoDate;
            mdPaidtoDate = oOrg.PaidtoDate;
            mdOutstanding = oOrg.Outstanding;
            msClient = oOrg.Client;
            msJob = oOrg.Job;
            msLocation = oOrg.msLocation;
        }
    }
}
