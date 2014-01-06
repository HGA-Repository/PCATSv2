using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COEmployeeDepartment
    {
        private int miID;
        private int miEmployeeID;
        private int miDepartmentID;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
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
            miEmployeeID = 0;
            miDepartmentID = 0;
        }

        public void Copy(COEmployeeDepartment oNew)
        {
            oNew.ID = miID;
            oNew.EmployeeID = miEmployeeID;
            oNew.DepartmentID = miDepartmentID;
        }

        public void LoadFromObj(COEmployeeDepartment oOrg)
        {
            miID = oOrg.ID;
            miEmployeeID = oOrg.EmployeeID;
            miDepartmentID = oOrg.DepartmentID;
        }
    }
}
