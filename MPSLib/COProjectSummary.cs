using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COProjectSummary
    {
        private int miID;
        private int miEmployeeID;
        private string msClientFeedback;
        private string msQualityImp;
        private string msNewWorkProp;
        private string msDistribution;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int EmployeeID
        {
            get { return miEmployeeID; }
            set { miEmployeeID = value; }
        }

        public string ClientFeedback
        {
            get { return msClientFeedback; }
            set { msClientFeedback = value; }
        }

        public string QualityImp
        {
            get { return msQualityImp; }
            set { msQualityImp = value; }
        }

        public string NewWorkProp
        {
            get { return msNewWorkProp; }
            set { msNewWorkProp = value; }
        }

        public string Distribution
        {
            get { return msDistribution; }
            set { msDistribution = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miEmployeeID = 0;
            msClientFeedback = "";
            msQualityImp = "";
            msNewWorkProp = "";
            msDistribution = "";
        }

        public void Copy(COProjectSummary oNew)
        {
            oNew.ID = miID;
            oNew.EmployeeID = miEmployeeID;
            oNew.ClientFeedback = msClientFeedback;
            oNew.QualityImp = msQualityImp;
            oNew.NewWorkProp = msNewWorkProp;
            oNew.Distribution = msDistribution;
        }

        public void LoadFromObj(COProjectSummary oOrg)
        {
            miID = oOrg.ID;
            miEmployeeID = oOrg.EmployeeID;
            msClientFeedback = oOrg.ClientFeedback;
            msQualityImp = oOrg.QualityImp;
            msNewWorkProp = oOrg.NewWorkProp;
            msDistribution = oOrg.Distribution;
        }
    }
}
