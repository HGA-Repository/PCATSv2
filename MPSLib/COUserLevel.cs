using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COUserLevel
    {
        private int miID;
        private int miUserID;
        private int miDepartmentID;
        private int miSecurityLevelID;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int UserID
        {
            get { return miUserID; }
            set { miUserID = value; }
        }

        public int DepartmentID
        {
            get { return miDepartmentID; }
            set { miDepartmentID = value; }
        }

        public int SecurityLevelID
        {
            get { return miSecurityLevelID; }
            set { miSecurityLevelID = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miUserID = 0;
            miDepartmentID = 0;
            miSecurityLevelID = 0;
        }

        public void Copy(COUserLevel oNew)
        {
            oNew.ID = miID;
            oNew.UserID = miUserID;
            oNew.DepartmentID = miDepartmentID;
            oNew.SecurityLevelID = miSecurityLevelID;
        }

        public void LoadFromObj(COUserLevel oOrg)
        {
            miID = oOrg.ID;
            miUserID = oOrg.UserID;
            miDepartmentID = oOrg.DepartmentID;
            miSecurityLevelID = oOrg.SecurityLevelID;
        }
    }
}
