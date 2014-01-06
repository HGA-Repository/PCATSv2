using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COPCNStatus
    {
        private int miID;
        private string msStatus;
        private string msDescription;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Status
        {
            get { return msStatus; }
            set { msStatus = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msStatus = "";
            msDescription = "";
        }

        public void Copy(COPCNStatus oNew)
        {
            oNew.ID = miID;
            oNew.Status = msStatus;
            oNew.Description = msDescription;
        }

        public void LoadFromObj(COPCNStatus oOrg)
        {
            miID = oOrg.ID;
            msStatus = oOrg.Status;
            msDescription = oOrg.Description;
        }
    }
}
