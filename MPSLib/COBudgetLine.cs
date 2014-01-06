using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudgetLine
    {
        private int miID;
        private int miBudgetID;
        private int miDeptGroup;
        private int miEntryLevel;
        private int miTask;
        private int miCategory;
        private int miActivity;
        private string msWBS;
        private string msDescription;
        private int miQuantity;
        private int miHoursEach;
        private int miTotalHours;
        private decimal mdLoadedRate;
        private decimal mdTotalDollars;
        private decimal mdBareRate;
        private decimal mdBareDollars;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int BudgetID
        {
            get { return miBudgetID; }
            set { miBudgetID = value; }
        }

        public int DeptGroup
        {
            get { return miDeptGroup; }
            set { miDeptGroup = value; }
        }

        public int EntryLevel
        {
            get { return miEntryLevel; }
            set { miEntryLevel = value; }
        }

        public int Task
        {
            get { return miTask; }
            set { miTask = value; }
        }

        public int Category
        {
            get { return miCategory; }
            set { miCategory = value; }
        }

        public int Activity
        {
            get { return miActivity; }
            set { miActivity = value; }
        }

        public string WBS
        {
            get { return msWBS; }
            set { msWBS = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public int Quantity
        {
            get { return miQuantity; }
            set { miQuantity = value; }
        }

        public int HoursEach
        {
            get { return miHoursEach; }
            set { miHoursEach = value; }
        }

        public int TotalHours
        {
            get { return miTotalHours; }
            set { miTotalHours = value; }
        }

        public decimal LoadedRate
        {
            get { return mdLoadedRate; }
            set { mdLoadedRate = value; }
        }

        public decimal TotalDollars
        {
            get { return mdTotalDollars; }
            set { mdTotalDollars = value; }
        }

        public decimal BareRate
        {
            get { return mdBareRate; }
            set { mdBareRate = value; }
        }

        public decimal BareDollars
        {
            get { return mdBareDollars; }
            set { mdBareDollars = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miBudgetID = 0;
            miDeptGroup = 0;
            miEntryLevel = 0;
            miTask = 0;
            miCategory = 0;
            miActivity = 0;
            msWBS = "";
            msDescription = "";
            miQuantity = 0;
            miHoursEach = 0;
            miTotalHours = 0;
            mdLoadedRate = 0;
            mdTotalDollars = 0;
            mdBareRate = 0;
            mdBareDollars = 0;
        }

        public void Copy(COBudgetLine oNew)
        {
            oNew.ID = miID;
            oNew.BudgetID = miBudgetID;
            oNew.DeptGroup = miDeptGroup;
            oNew.EntryLevel = miEntryLevel;
            oNew.Task = miTask;
            oNew.Category = miCategory;
            oNew.Activity = miActivity;
            oNew.WBS = msWBS;
            oNew.Description = msDescription;
            oNew.Quantity = miQuantity;
            oNew.HoursEach = miHoursEach;
            oNew.TotalHours = miTotalHours;
            oNew.LoadedRate = mdLoadedRate;
            oNew.TotalDollars = mdTotalDollars;
            oNew.BareRate = mdBareRate;
            oNew.BareDollars = mdBareDollars;
        }

        public void LoadFromObj(COBudgetLine oOrg)
        {
            miID = oOrg.ID;
            miBudgetID = oOrg.BudgetID;
            miDeptGroup = oOrg.DeptGroup;
            miEntryLevel = oOrg.EntryLevel;
            miTask = oOrg.Task;
            miCategory = oOrg.Category;
            miActivity = oOrg.Activity;
            msWBS = oOrg.WBS;
            msDescription = oOrg.Description;
            miQuantity = oOrg.Quantity;
            miHoursEach = oOrg.HoursEach;
            miTotalHours = oOrg.TotalHours;
            mdLoadedRate = oOrg.LoadedRate;
            mdTotalDollars = oOrg.TotalDollars;
            mdBareRate = oOrg.BareRate;
            mdBareDollars = oOrg.BareDollars;
        }
    }
}
