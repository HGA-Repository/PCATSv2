using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COProjectEmployee
    {
        private int miID;
        private int miProjectID;
        private int miEmployeeID;
        private int miDepartmentID;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public int EmployeeID
        {
            get { return miEmployeeID; }
            set { miEmployeeID = value; }
        }

        public int DepartmentID
        {
            get { return miDepartmentID; }
            set { miDepartmentID = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjectID = 0;
            miEmployeeID = 0;
            miDepartmentID = 0;
        }

        public void Copy(COProjectEmployee oNew)
        {
            oNew.ID = miID;
            oNew.ProjectID = miProjectID;
            oNew.EmployeeID = miEmployeeID;
            oNew.DepartmentID = miDepartmentID;
        }

        public void LoadFromObj(COProjectEmployee oOrg)
        {
            miID = oOrg.ID;
            miProjectID = oOrg.ProjectID;
            miEmployeeID = oOrg.EmployeeID;
            miDepartmentID = oOrg.DepartmentID;
        }
    }
}
