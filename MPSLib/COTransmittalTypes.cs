using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COTransmittalTypes
    {
        private int miID;
        private string msCode;
        private string msName;
        private int miOrdinal;

        public COTransmittalTypes()
        {
            Clear();
        }

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Code
        {
            get { return msCode; }
            set { msCode = value; }
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
            msCode = "";
            msName = "";
            miOrdinal = 0;
        }

        public void Copy(COTransmittalTypes oNew)
        {
            oNew.ID = miID;
            oNew.Code = msCode;
            oNew.Name = msName;
            oNew.Ordinal = miOrdinal;
        }

        public void LoadFromObj(COTransmittalTypes oOrg)
        {
            miID = oOrg.ID;
            msCode = oOrg.Code;
            msName = oOrg.Name;
            miOrdinal = oOrg.Ordinal;
        }
    }
}
