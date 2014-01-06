using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class CODepartment
    {
        private int miID;
        private string msName;
        private string msDescription;
        private int miNumber;
        private int miEmployeeID;

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

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public int Number
        {
            get { return miNumber; }
            set { miNumber = value; }
        }

        public int EmployeeID
        {
            get { return miEmployeeID; }
            set { miEmployeeID = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msName = "";
            msDescription = "";
            miNumber = 0;
            miEmployeeID = 0;
        }

        public void Copy(CODepartment oNew)
        {
            oNew.ID = miID;
            oNew.Name = msName;
            oNew.Description = msDescription;
            oNew.Number = miNumber;
            oNew.EmployeeID = miEmployeeID;
        }

        public void LoadFromObj(CODepartment oOrg)
        {
            miID = oOrg.ID;
            msName = oOrg.Name;
            msDescription = oOrg.Description;
            miNumber = oOrg.Number;
            miEmployeeID = oOrg.EmployeeID;
        }
    }
}
