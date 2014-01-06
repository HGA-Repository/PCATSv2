using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COReleaseDrawing
    {
        private int miID;
        private string msName;
        private int miOrdinal;

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

        public int Ordinal
        {
            get { return miOrdinal; }
            set { miOrdinal = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msName = "";
            miOrdinal = 0;
        }

        public void Copy(COReleaseDrawing oNew)
        {
            oNew.ID = miID;
            oNew.Name = msName;
            oNew.Ordinal = miOrdinal;
        }

        public void LoadFromObj(COReleaseDrawing oOrg)
        {
            miID = oOrg.ID;
            msName = oOrg.Name;
            miOrdinal = oOrg.Ordinal;
        }
    }
}
