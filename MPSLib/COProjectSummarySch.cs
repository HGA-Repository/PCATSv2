using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COProjectSummarySch
    {
        private int miID;
        private int miProjSumID;
        private int miProjectID;
        private string msDescription;
        private string msInitialTarget;
        private string msProjected;
        private string msActual;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int ProjSumID
        {
            get { return miProjSumID; }
            set { miProjSumID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public String InitialTarget
        {
            get { return msInitialTarget; }
            set { msInitialTarget = value; }
        }

        public String Projected
        {
            get { return msProjected; }
            set { msProjected = value; }
        }
        public String Actual
        {
            get { return msActual; }
            set { msActual = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjSumID = 0;
            miProjectID = 0;
            msDescription = "";
            msInitialTarget = "";
            msProjected = "";
            msActual = "";
        }

        public void Copy(COProjectSummarySch oNew)
        {
            oNew.ID = miID;
            oNew.ProjSumID = miProjSumID;
            oNew.ProjectID = miProjectID;
            oNew.Description = msDescription;
            oNew.InitialTarget = msInitialTarget;
            oNew.Projected = msProjected;
            oNew.Actual = msActual;
        }

        public void LoadFromObj(COProjectSummarySch oOrg)
        {
            miID = oOrg.ID;
            miProjSumID = oOrg.ProjSumID;
            miProjectID = oOrg.ProjectID;
            msDescription = oOrg.Description;
            msInitialTarget = oOrg.InitialTarget;
            msProjected = oOrg.Projected;
            msActual = oOrg.Actual;
        }
    }
}
