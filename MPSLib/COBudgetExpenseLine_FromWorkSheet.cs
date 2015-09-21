using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudgetExpenseLine_FromWorkSheet
    {
        private int miID;
        private int miBudgetID;
        private int miDeptGroup;
        private int miEntryLevel;
        private string msCode;
        private string msDescription;
        private decimal mdMarkUp;
        private int miUOMID;
        private decimal mdDollarsEach;
        private int miQuantity;
        private decimal mdMarkupDollars;
        private decimal mdTotalDollars;

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

        public string Code
        {
            get { return msCode; }
            set { msCode = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public decimal MarkUp
        {
            get { return mdMarkUp; }
            set { mdMarkUp = value; }
        }

        public int UOMID
        {
            get { return miUOMID; }
            set { miUOMID = value; }
        }

        public decimal DollarsEach
        {
            get { return mdDollarsEach; }
            set { mdDollarsEach = value; }
        }

        public int Quantity
        {
            get { return miQuantity; }
            set { miQuantity = value; }
        }

        public decimal MarkupDollars
        {
            get { return mdMarkupDollars; }
            set { mdMarkupDollars = value; }
        }

        public decimal TotalDollars
        {
            get { return mdTotalDollars; }
            set { mdTotalDollars = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miBudgetID = 0;
            miDeptGroup = 0;
            miEntryLevel = 0;
            msCode = "";
            msDescription = "";
            mdMarkUp = 0;
            miUOMID = 0;
            mdDollarsEach = 0;
            miQuantity = 0;
            mdMarkupDollars = 0;
            mdTotalDollars = 0;
        }

        public void Copy(COBudgetExpenseLine_FromWorkSheet oNew)
        {
            oNew.ID = miID;
            oNew.BudgetID = miBudgetID;
            oNew.DeptGroup = miDeptGroup;
            oNew.EntryLevel = miEntryLevel;
            oNew.Code = msCode;
            oNew.Description = msDescription;
            oNew.MarkUp = mdMarkUp;
            oNew.UOMID = miUOMID;
            oNew.DollarsEach = mdDollarsEach;
            oNew.Quantity = miQuantity;
            oNew.MarkupDollars = mdMarkupDollars;
            oNew.TotalDollars = mdTotalDollars;
        }

        public void LoadFromObj(COBudgetExpenseLine_FromWorkSheet oOrg)
        {
            miID = oOrg.ID;
            miBudgetID = oOrg.BudgetID;
            miDeptGroup = oOrg.DeptGroup;
            miEntryLevel = oOrg.EntryLevel;
            msCode = oOrg.Code;
            msDescription = oOrg.Description;
            mdMarkUp = oOrg.MarkUp;
            miUOMID = oOrg.UOMID;
            mdDollarsEach = oOrg.DollarsEach;
            miQuantity = oOrg.Quantity;
            mdMarkupDollars = oOrg.MarkupDollars;
            mdTotalDollars = oOrg.TotalDollars;
        }
    }
}
