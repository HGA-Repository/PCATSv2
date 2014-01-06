using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COTransmittalSendTo
    {
        private int miID;
        private int miTransRelID;
        private string msName;
        private int miTypeID;
        private int miQuantity;
        private bool mbIsOther;

        public COTransmittalSendTo()
        {
            Clear();
        }

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int TransRelID
        {
            get { return miTransRelID; }
            set { miTransRelID = value; }
        }

        public string Name
        {
            get { return msName; }
            set { msName = value; }
        }

        public int TypeID
        {
            get { return miTypeID; }
            set { miTypeID = value; }
        }

        public int Quantity
        {
            get { return miQuantity; }
            set { miQuantity = value; }
        }

        public bool IsOther
        {
            get { return mbIsOther; }
            set { mbIsOther = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miTransRelID = 0;
            msName = "";
            miTypeID = 0;
            miQuantity = 0;
            mbIsOther = false;
        }

        public void Copy(COTransmittalSendTo oNew)
        {
            oNew.ID = miID;
            oNew.TransRelID = miTransRelID;
            oNew.Name = msName;
            oNew.TypeID = miTypeID;
            oNew.Quantity = miQuantity;
            oNew.IsOther = mbIsOther;
        }

        public void LoadFromObj(COTransmittalSendTo oOrg)
        {
            miID = oOrg.ID;
            miTransRelID = oOrg.TransRelID;
            msName = oOrg.Name;
            miTypeID = oOrg.TypeID;
            miQuantity = oOrg.Quantity;
            mbIsOther = oOrg.IsOther;
        }
    }
}
