using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COState
    {
        private int miID;
        private string msName;
        private string msAbbrev;

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

        public string Abbrev
        {
            get { return msAbbrev; }
            set { msAbbrev = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msName = "";
            msAbbrev = "";
        }

        public void Copy(COState oNew)
        {
            oNew.ID = miID;
            oNew.Name = msName;
            oNew.Abbrev = msAbbrev;
        }

        public void LoadFromObj(COState oOrg)
        {
            miID = oOrg.ID;
            msName = oOrg.Name;
            msAbbrev = oOrg.Abbrev;
        }
    }
}
