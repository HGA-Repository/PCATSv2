using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudget
    {
        private int miID;
        private int miProjectID;
        private int miRevision;
        private int miPCNID;
        private bool mbIsDefault;
        private bool mbIsActive;
        private bool mbIsLocked;
        private string msDescription;
        private string msPreparedBy;
        private decimal mdContingency;
        private string msClarification11000;
        private string msClarification12000;
        private string msClarification13000;
        private string msClarification14000;
        private string msClarification15000;
        private string msClarification16000;
        private string msClarification17000;
        private string msClarification18000;
        private string msClarification50000;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public int Revision
        {
            get { return miRevision; }
            set { miRevision = value; }
        }

        public int PCNID
        {
            get { return miPCNID; }
            set { miPCNID = value; }
        }

        public bool IsDefault
        {
            get { return mbIsDefault; }
            set { mbIsDefault = value; }
        }

        public bool IsActive
        {
            get { return mbIsActive; }
            set { mbIsActive = value; }
        }

        public bool IsLocked
        {
            get { return mbIsLocked; }
            set { mbIsLocked = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public string PreparedBy
        {
            get { return msPreparedBy; }
            set { msPreparedBy = value; }
        }

        public decimal Contingency
        {
            get { return mdContingency; }
            set { mdContingency = value; }
        }
        
        public string Clarification11000
        {
            get { return msClarification11000; }
            set { msClarification11000 = value; }
        }
        public string Clarification12000
        {
            get { return msClarification12000; }
            set { msClarification12000 = value; }
        }
        public string Clarification13000
        {
            get { return msClarification13000; }
            set { msClarification13000 = value; }
        }
        public string Clarification14000
        {
            get { return msClarification14000; }
            set { msClarification14000 = value; }
        }
        public string Clarification15000
        {
            get { return msClarification15000; }
            set { msClarification15000 = value; }
        }
        public string Clarification16000
        {
            get { return msClarification16000; }
            set { msClarification16000 = value; }
        }
        public string Clarification17000
        {
            get { return msClarification17000; }
            set { msClarification17000 = value; }
        }
        public string Clarification18000
        {
            get { return msClarification18000; }
            set { msClarification18000 = value; }
        }
        public string Clarification50000
        {
            get { return msClarification50000; }
            set { msClarification50000 = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjectID = 0;
            miRevision = 0;
            miPCNID = 0;
            mbIsDefault = false;
            mbIsActive = false;
            mbIsLocked = false;
            msDescription = "";
            msPreparedBy = "";
            mdContingency = 0;
            msClarification11000 = "";
            msClarification12000 = "";
            msClarification13000 = "";
            msClarification14000 = "";
            msClarification15000 = "";
            msClarification16000 = "";
            msClarification17000 = "";
            msClarification18000 = "";
            msClarification50000 = "";
        }

        public void Copy(COBudget oNew)
        {
            oNew.ID = miID;
            oNew.ProjectID = miProjectID;
            oNew.Revision = miRevision;
            oNew.PCNID = miPCNID;
            oNew.IsDefault = mbIsDefault;
            oNew.IsActive = mbIsActive;
            oNew.IsLocked = mbIsLocked;
            oNew.Description = msDescription;
            oNew.PreparedBy = msPreparedBy;
            oNew.Contingency = mdContingency;
            oNew.Clarification11000 = msClarification11000;
            oNew.Clarification12000 = msClarification12000;
            oNew.Clarification13000 = msClarification13000;
            oNew.Clarification14000 = msClarification14000;
            oNew.Clarification15000 = msClarification15000;
            oNew.Clarification16000 = msClarification16000;
            oNew.Clarification17000 = msClarification17000;
            oNew.Clarification18000 = msClarification18000;
            oNew.Clarification50000 = msClarification50000;
                    }

        public void LoadFromObj(COBudget oOrg)
        {
            miID = oOrg.ID;
            miProjectID = oOrg.ProjectID;
            miRevision = oOrg.Revision;
            miPCNID = oOrg.PCNID;
            mbIsDefault = oOrg.IsDefault;
            mbIsActive = oOrg.IsActive;
            mbIsLocked = oOrg.IsLocked;
            msDescription = oOrg.Description;
            msPreparedBy = oOrg.PreparedBy;
            mdContingency = oOrg.Contingency;
            msClarification11000 = oOrg.Clarification11000;
            msClarification12000 = oOrg.Clarification12000;
            msClarification13000 = oOrg.Clarification13000;
            msClarification14000 = oOrg.Clarification14000;
            msClarification15000 = oOrg.Clarification15000;
            msClarification16000 = oOrg.Clarification16000;
            msClarification17000 = oOrg.Clarification17000;
            msClarification18000 = oOrg.Clarification18000;
            msClarification50000 = oOrg.Clarification50000;
        }
    }
}
