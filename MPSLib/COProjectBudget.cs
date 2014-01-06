using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COProjectBudget
    {
        private int miID;
        private int miProjectID;
        private int miDepartmentID;
        private decimal mdBudgetHrs;

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

        public int DepartmentID
        {
            get { return miDepartmentID; }
            set { miDepartmentID = value; }
        }

        public decimal BudgetHrs
        {
            get { return mdBudgetHrs; }
            set { mdBudgetHrs = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjectID = 0;
            miDepartmentID = 0;
            mdBudgetHrs = 0;
        }

        public void Copy(COProjectBudget oNew)
        {
            oNew.ID = miID;
            oNew.ProjectID = miProjectID;
            oNew.DepartmentID = miDepartmentID;
            oNew.BudgetHrs = mdBudgetHrs;
        }

        public void LoadFromObj(COProjectBudget oOrg)
        {
            miID = oOrg.ID;
            miProjectID = oOrg.ProjectID;
            miDepartmentID = oOrg.DepartmentID;
            mdBudgetHrs = oOrg.BudgetHrs;
        }
    }
}
