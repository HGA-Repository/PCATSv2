using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COSecurityLevel
    {
        private int miID;
        private string msName;
        private decimal mdPassLevel;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Name
        {
            get { return msName; }
            set { msName = value; }
        }

        public decimal PassLevel
        {
            get { return mdPassLevel; }
            set { mdPassLevel = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msName = "";
            mdPassLevel = 0;
        }

        public void Copy(COSecurityLevel oNew)
        {
            oNew.ID = miID;
            oNew.Name = msName;
            oNew.PassLevel = mdPassLevel;
        }

        public void LoadFromObj(COSecurityLevel oOrg)
        {
            miID = oOrg.ID;
            msName = oOrg.Name;
            mdPassLevel = oOrg.PassLevel;
        }
    }
}
