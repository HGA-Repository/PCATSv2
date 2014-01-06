using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudgetExpenseSheet
    {
        private int miID;
        private int miBudgetID;
        private int miDeptGroup;
        private string msWorkGuid;
        private string msDescription;
        private int miQuantity;
        private int miRoundTrips;
        private int miPeople;
        private int miNumDays;
        private int miNumNights;
        private int miHoursPerDay;
        private int miTravelHours;
        private int miE110;
        private int miE120;
        private int miE130;
        private int miE140;
        private int miE150;
        private int miE160;
        private int miE170;
        private int miE180;
        private int miE190;
        private string msRemarks;

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

        public string WorkGuid
        {
            get { return msWorkGuid; }
            set { msWorkGuid = value; }
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

        public int RoundTrips
        {
            get { return miRoundTrips; }
            set { miRoundTrips = value; }
        }

        public int People
        {
            get { return miPeople; }
            set { miPeople = value; }
        }

        public int NumDays
        {
            get { return miNumDays; }
            set { miNumDays = value; }
        }

        public int NumNights
        {
            get { return miNumNights; }
            set { miNumNights = value; }
        }

        public int HoursPerDay
        {
            get { return miHoursPerDay; }
            set { miHoursPerDay = value; }
        }

        public int TravelHours
        {
            get { return miTravelHours; }
            set { miTravelHours = value; }
        }

        public int E110
        {
            get { return miE110; }
            set { miE110 = value; }
        }

        public int E120
        {
            get { return miE120; }
            set { miE120 = value; }
        }

        public int E130
        {
            get { return miE130; }
            set { miE130 = value; }
        }

        public int E140
        {
            get { return miE140; }
            set { miE140 = value; }
        }

        public int E150
        {
            get { return miE150; }
            set { miE150 = value; }
        }

        public int E160
        {
            get { return miE160; }
            set { miE160 = value; }
        }

        public int E170
        {
            get { return miE170; }
            set { miE170 = value; }
        }

        public int E180
        {
            get { return miE180; }
            set { miE180 = value; }
        }

        public int E190
        {
            get { return miE190; }
            set { miE190 = value; }
        }

        public string Remarks
        {
            get { return msRemarks; }
            set { msRemarks = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miBudgetID = 0;
            miDeptGroup = 0;
            msWorkGuid = "";
            msDescription = "";
            miQuantity = 0;
            miRoundTrips = 0;
            miPeople = 0;
            miNumDays = 0;
            miNumNights = 0;
            miHoursPerDay = 0;
            miTravelHours = 0;
            miE110 = 0;
            miE120 = 0;
            miE130 = 0;
            miE140 = 0;
            miE150 = 0;
            miE160 = 0;
            miE170 = 0;
            miE180 = 0;
            miE190 = 0;
            msRemarks = "";
        }

        public void Copy(COBudgetExpenseSheet oNew)
        {
            oNew.ID = miID;
            oNew.BudgetID = miBudgetID;
            oNew.DeptGroup = miDeptGroup;
            oNew.WorkGuid = msWorkGuid;
            oNew.Description = msDescription;
            oNew.Quantity = miQuantity;
            oNew.RoundTrips = miRoundTrips;
            oNew.People = miPeople;
            oNew.NumDays = miNumDays;
            oNew.NumNights = miNumNights;
            oNew.HoursPerDay = miHoursPerDay;
            oNew.TravelHours = miTravelHours;
            oNew.E110 = miE110;
            oNew.E120 = miE120;
            oNew.E130 = miE130;
            oNew.E140 = miE140;
            oNew.E150 = miE150;
            oNew.E160 = miE160;
            oNew.E170 = miE170;
            oNew.E180 = miE180;
            oNew.E190 = miE190;
            oNew.Remarks = msRemarks;
        }

        public void LoadFromObj(COBudgetExpenseSheet oOrg)
        {
            miID = oOrg.ID;
            miBudgetID = oOrg.BudgetID;
            miDeptGroup = oOrg.DeptGroup;
            msWorkGuid = oOrg.WorkGuid;
            msDescription = oOrg.Description;
            miQuantity = oOrg.Quantity;
            miRoundTrips = oOrg.RoundTrips;
            miPeople = oOrg.People;
            miNumDays = oOrg.NumDays;
            miNumNights = oOrg.NumNights;
            miHoursPerDay = oOrg.HoursPerDay;
            miTravelHours = oOrg.TravelHours;
            miE110 = oOrg.E110;
            miE120 = oOrg.E120;
            miE130 = oOrg.E130;
            miE140 = oOrg.E140;
            miE150 = oOrg.E150;
            miE160 = oOrg.E160;
            miE170 = oOrg.E170;
            miE180 = oOrg.E180;
            miE190 = oOrg.E190;
            msRemarks = oOrg.Remarks;
        }
    }
}
