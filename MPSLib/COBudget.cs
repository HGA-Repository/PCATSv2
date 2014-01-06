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
        }
    }
}
