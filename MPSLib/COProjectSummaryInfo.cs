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

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjSumID = 0;
            miProjectID = 0;
            msSchedule = "";
            msActHigh = "";
            msStaffNeeds = "";
        }

        public void Copy(COProjectSummaryInfo oNew)
        {
            oNew.ID = miID;
            oNew.ProjSumID = miProjSumID;
            oNew.ProjectID = miProjectID;
            oNew.Schedule = msSchedule;
            oNew.ActHigh = msActHigh;
            oNew.StaffNeeds = msStaffNeeds;
        }

        public void LoadFromObj(COProjectSummaryInfo oOrg)
        {
            miID = oOrg.ID;
            miProjSumID = oOrg.ProjSumID;
            miProjectID = oOrg.ProjectID;
            msSchedule = oOrg.Schedule;
            msActHigh = oOrg.ActHigh;
            msStaffNeeds = oOrg.StaffNeeds;
        }
    }
}
