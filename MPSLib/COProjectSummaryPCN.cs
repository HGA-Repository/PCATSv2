using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COProjectSummaryPCN
    {
        private int miID;
        private int miProjSumID;
        private int miProjectID;
        private int miNumber;
        private string msDescription;
        private decimal mdHours;
        private decimal mdDollars;

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

        public int Number
        {
            get { return miNumber; }
            set { miNumber = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public decimal Hours
        {
            get { return mdHours; }
            set { mdHours = value; }
        }

        public decimal Dollars
        {
            get { return mdDollars; }
            set { mdDollars = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjSumID = 0;
            miProjectID = 0;
            miNumber = 0;
            msDescription = "";
            mdHours = 0;
            mdDollars = 0;
        }

        public void Copy(COProjectSummaryPCN oNew)
        {
            oNew.ID = miID;
            oNew.ProjSumID = miProjSumID;
            oNew.ProjectID = miProjectID;
            oNew.Number = miNumber;
            oNew.Description = msDescription;
            oNew.Hours = mdHours;
            oNew.Dollars = mdDollars;
        }

        public void LoadFromObj(COProjectSummaryPCN oOrg)
        {
            miID = oOrg.ID;
            miProjSumID = oOrg.ProjSumID;
            miProjectID = oOrg.ProjectID;
            miNumber = oOrg.Number;
            msDescription = oOrg.Description;
            mdHours = oOrg.Hours;
            mdDollars = oOrg.Dollars;
        }
    }
}
