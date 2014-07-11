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
        private DateTime mdtInitialTarget;
        private DateTime mdtProjected;
        private DateTime mdtActual;

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

        public DateTime InitialTarget
        {
            get { return mdtInitialTarget; }
            set { mdtInitialTarget = value; }
        }

        public DateTime Projected
        {
            get { return mdtProjected; }
            set { mdtProjected = value; }
        }
        public DateTime Actual
        {
            get { return mdtActual; }
            set { mdtActual = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjSumID = 0;
            miProjectID = 0;
            msDescription = "";
            mdtInitialTarget = DateTime.Now;
            mdtProjected = DateTime.Now;
            mdtActual = DateTime.Now;
        }

        public void Copy(COProjectSummarySch oNew)
        {
            oNew.ID = miID;
            oNew.ProjSumID = miProjSumID;
            oNew.ProjectID = miProjectID;
            oNew.Description = msDescription;
            oNew.InitialTarget = mdtInitialTarget;
            oNew.Projected = mdtProjected;
            oNew.Actual = mdtActual;
        }

        public void LoadFromObj(COProjectSummarySch oOrg)
        {
            miID = oOrg.ID;
            miProjSumID = oOrg.ProjSumID;
            miProjectID = oOrg.ProjectID;
            msDescription = oOrg.Description;
            mdtInitialTarget = oOrg.InitialTarget;
            mdtProjected = oOrg.Projected;
            mdtActual = oOrg.Actual;
        }
    }
}
