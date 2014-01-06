using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudgetPCNExpense
    {
        private int miID;
        private int miPCNID;
        private string msCode;
        private string msDescription;
        private decimal mdDlrsPerItem;
        private int miNumItems;
        private decimal mdMUPerc;
        private decimal mdMarkUp;
        private decimal mdTotalCost;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int PCNID
        {
            get { return miPCNID; }
            set { miPCNID = value; }
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

        public decimal DlrsPerItem
        {
            get { return mdDlrsPerItem; }
            set { mdDlrsPerItem = value; }
        }

        public int NumItems
        {
            get { return miNumItems; }
            set { miNumItems = value; }
        }

        public decimal MUPerc
        {
            get { return mdMUPerc; }
            set { mdMUPerc = value; }
        }

        public decimal MarkUp
        {
            get { return mdMarkUp; }
            set { mdMarkUp = value; }
        }

        public decimal TotalCost
        {
            get { return mdTotalCost; }
            set { mdTotalCost = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miPCNID = 0;
            msCode = "";
            msDescription = "";
            mdDlrsPerItem = 0;
            miNumItems = 0;
            mdMUPerc = 0;
            mdMarkUp = 0;
            mdTotalCost = 0;
        }

        public void Copy(COBudgetPCNExpense oNew)
        {
            oNew.ID = miID;
            oNew.PCNID = miPCNID;
            oNew.Code = msCode;
            oNew.Description = msDescription;
            oNew.DlrsPerItem = mdDlrsPerItem;
            oNew.NumItems = miNumItems;
            oNew.MUPerc = mdMUPerc;
            oNew.MarkUp = mdMarkUp;
            oNew.TotalCost = mdTotalCost;
        }

        public void LoadFromObj(COBudgetPCNExpense oOrg)
        {
            miID = oOrg.ID;
            miPCNID = oOrg.PCNID;
            msCode = oOrg.Code;
            msDescription = oOrg.Description;
            mdDlrsPerItem = oOrg.DlrsPerItem;
            miNumItems = oOrg.NumItems;
            mdMUPerc = oOrg.MUPerc;
            mdMarkUp = oOrg.MarkUp;
            mdTotalCost = oOrg.TotalCost;
        }
    }
}
