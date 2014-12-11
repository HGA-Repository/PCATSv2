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
        private int miE281;
        private int miE282;
        private int miE283;
        private int miE284;
        private int miE290;
        private int miE310;
        private int miE320;
        private int miE330;
        private int miE340;
        private int miE350;
        private int miE541;
        private int miE542;
        private int miE543;
        private int miE561;
        private int miE562;
        private int miE580;
        private int miE591;
        private int miE592;
        private int miE593;
        private int miE594;
        private int miE595;
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

        public int E281
        {
            get { return miE281; }
            set { miE281 = value; }
        }
        public int E282
        {
            get { return miE282; }
            set { miE282 = value; }
        }
        public int E283
        {
            get { return miE283; }
            set { miE283 = value; }
        }
        public int E284
        {
            get { return miE284; }
            set { miE284 = value; }
        }
        public int E290
        {
            get { return miE290; }
            set { miE290 = value; }
        }
        public int E310
        {
            get { return miE310; }
            set { miE310 = value; }
        }
        public int E320
        {
            get { return miE320; }
            set { miE320 = value; }
        }
        public int E330
        {
            get { return miE330; }
            set { miE330 = value; }
        }
        public int E340
        {
            get { return miE340; }
            set { miE340 = value; }
        }
        public int E350
        {
            get { return miE350; }
            set { miE350 = value; }
        }
        public int E541
        {
            get { return miE541; }
            set { miE541 = value; }
        }
        public int E542
        {
            get { return miE542; }
            set { miE542 = value; }
        }
        public int E543
        {
            get { return miE543; }
            set { miE543 = value; }
        }
        public int E561
        {
            get { return miE561; }
            set { miE561 = value; }
        }
        public int E562
        {
            get { return miE562; }
            set { miE562 = value; }
        }
        public int E580
        {
            get { return miE580; }
            set { miE580 = value; }
        }
        public int E591
        {
            get { return miE591; }
            set { miE591 = value; }
        }
        public int E592
        {
            get { return miE592; }
            set { miE592 = value; }
        }
        public int E593
        {
            get { return miE593; }
            set { miE593 = value; }
        }
        public int E594
        {
            get { return miE594; }
            set { miE594 = value; }
        }
        public int E595
        {
            get { return miE595; }
            set { miE595 = value; }
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
            miE281 = 0;
            miE282 = 0;
            miE283 = 0;
            miE284 = 0;
            miE290 = 0;
            miE310 = 0;
            miE320 = 0;
            miE330 = 0;
            miE340 = 0;
            miE350 = 0;
            miE541 = 0;
            miE542 = 0;
            miE543 = 0;
            miE561 = 0;
            miE561 = 0;
            miE580 = 0;
            miE591 = 0;
            miE592 = 0;
            miE593 = 0;
            miE594 = 0;
            miE595 = 0;
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
            oNew.E281 = miE281;
            oNew.E282 = miE282;
            oNew.E283 = miE283;
            oNew.E284 = miE284;
            oNew.E290 = miE290;
            oNew.E310 = miE310;
            oNew.E320 = miE320;
            oNew.E330 = miE330;
            oNew.E340 = miE340;
            oNew.E350 = miE350;
            oNew.E541 = miE541;
            oNew.E542 = miE542;
            oNew.E543 = miE543;
            oNew.E561 = miE561;
            oNew.E562 = miE562;
            oNew.E580 = miE580;
            oNew.E591 = miE591;
            oNew.E592 = miE592;
            oNew.E593 = miE593;
            oNew.E594 = miE594;
            oNew.E595 = miE595;
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
            miE281 = oOrg.E281;
            miE282 = oOrg.E282;
            miE283 = oOrg.E283;
            miE284 = oOrg.E284;
            miE290 = oOrg.E290;
            miE310 = oOrg.E310;
            miE320 = oOrg.E320;
            miE330 = oOrg.E330;
            miE340 = oOrg.E340;
            miE350 = oOrg.E350;
            miE541 = oOrg.E541;
            miE542 = oOrg.E542;
            miE543 = oOrg.E543;
            miE561 = oOrg.E561;
            miE562 = oOrg.E562;
            miE580 = oOrg.E580;
            miE591 = oOrg.E591;
            miE592 = oOrg.E592;
            miE593 = oOrg.E593;
            miE594 = oOrg.E594;
            miE595 = oOrg.E595;
            msRemarks = oOrg.Remarks;
        }
    }
}
