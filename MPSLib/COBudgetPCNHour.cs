using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudgetPCNHour
    {
        private int miID;
        private int miPCNID;
        private string msCode;
        private string msWBS;
        private string msDescription;
        private int miQuantity;
        private int miHoursPerItem;
        private decimal mdRate;
        private int miSubtotalHrs;
        private decimal mdSubtotalDlrs;

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

        public int HoursPerItem
        {
            get { return miHoursPerItem; }
            set { miHoursPerItem = value; }
        }

        public decimal Rate
        {
            get { return mdRate; }
            set { mdRate = value; }
        }

        public int SubtotalHrs
        {
            get { return miSubtotalHrs; }
            set { miSubtotalHrs = value; }
        }

        public decimal SubtotalDlrs
        {
            get { return mdSubtotalDlrs; }
            set { mdSubtotalDlrs = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miPCNID = 0;
            msCode = "";
            msWBS = "";
            msDescription = "";
            miQuantity = 0;
            miHoursPerItem = 0;
            mdRate = 0;
            miSubtotalHrs = 0;
            mdSubtotalDlrs = 0;
        }

        public void Copy(COBudgetPCNHour oNew)
        {
            oNew.ID = miID;
            oNew.PCNID = miPCNID;
            oNew.Code = msCode;
            oNew.WBS = msWBS;
            oNew.Description = msDescription;
            oNew.Quantity = miQuantity;
            oNew.HoursPerItem = miHoursPerItem;
            oNew.Rate = mdRate;
            oNew.SubtotalHrs = miSubtotalHrs;
            oNew.SubtotalDlrs = mdSubtotalDlrs;
        }

        public void LoadFromObj(COBudgetPCNHour oOrg)
        {
            miID = oOrg.ID;
            miPCNID = oOrg.PCNID;
            msCode = oOrg.Code;
            msWBS = oOrg.WBS;
            msDescription = oOrg.Description;
            miQuantity = oOrg.Quantity;
            miHoursPerItem = oOrg.HoursPerItem;
            mdRate = oOrg.Rate;
            miSubtotalHrs = oOrg.SubtotalHrs;
            mdSubtotalDlrs = oOrg.SubtotalDlrs;
        }
    }
}
