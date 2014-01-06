using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COCustomer
    {
        private int miID;
        private string msNumber;
        private string msName;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Number
        {
            get { return msNumber; }
            set { msNumber = value; }
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
            msNumber = "";
            msName = "";
        }

        public void Copy(COCustomer oNew)
        {
            oNew.ID = miID;
            oNew.Number = msNumber;
            oNew.Name = msName;
        }

        public void LoadFromObj(COCustomer oOrg)
        {
            miID = oOrg.ID;
            msNumber = oOrg.Number;
            msName = oOrg.Name;
        }
    }
}
