using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COLog
    {
        private int miID;
        private string msName;

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

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msName = "";
        }

       // public void Copy(COEmployeeTitle oNew)
            public void Copy(COLog oNew)
        {
            oNew.ID = miID;
            oNew.Name = msName;
        }

        public void LoadFromObj(COLog oOrg)
        {
            miID = oOrg.ID;
            msName = oOrg.Name;
        }
    }
}

