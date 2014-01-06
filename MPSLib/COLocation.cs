using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COLocation
    {
        private int miID;
        private int miCustomerID;
        private string msCity;
        private int miStateID;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int CustomerID
        {
            get { return miCustomerID; }
            set { miCustomerID = value; }
        }

        public string City
        {
            get { return msCity; }
            set { msCity = value; }
        }

        public int StateID
        {
            get { return miStateID; }
            set { miStateID = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miCustomerID = 0;
            msCity = "";
            miStateID = 0;
        }

        public void Copy(COLocation oNew)
        {
            oNew.ID = miID;
            oNew.CustomerID = miCustomerID;
            oNew.City = msCity;
            oNew.StateID = miStateID;
        }

        public void LoadFromObj(COLocation oOrg)
        {
            miID = oOrg.ID;
            miCustomerID = oOrg.CustomerID;
            msCity = oOrg.City;
            miStateID = oOrg.StateID;
        }
    }
}
