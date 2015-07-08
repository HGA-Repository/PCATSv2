using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COProject
    {
        private int miID;
        private string msNumber;
        private string msDescription;
        private int miCustomerID;
        private string msCustomerProjNumber;
        private int miLocationID;
        private int miProjMngrID;
        private int miLeadProjMngrID;
        private int miRelationshipMngrID;
        private int miRateSchedID;
        private decimal mdMultiplier;
        private decimal mdOverlay;
        private string msNotes;
        private DateTime mdDateStart;
        private DateTime mdDateEnd;
        private bool mbIsProposal;
        private bool mbIsBooked;
        private bool mbIsActive;
        private bool mbIsGovernment;
        private bool mbIsmaster;
        private int miMasterID;
        private int miReportingStatus;
        private decimal mdBudget;
        private string msPOAmnt;

        private string msCustomerName;  //******************************Added 7/8/2015
        private string msCity;
        private string msState;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Number
        {
            get { return msNumber; }
            set { msNumber = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public int CustomerID
        {
            get { return miCustomerID; }
            set { miCustomerID = value; }
        }

        public string CustomerProjNumber
        {
            get { return msCustomerProjNumber; }
            set { msCustomerProjNumber = value; }
        }

        public int LocationID
        {
            get { return miLocationID; }
            set { miLocationID = value; }
        }

        public int ProjMngrID
        {
            get { return miProjMngrID; }
            set { miProjMngrID = value; }
        }
        public int LeadProjMngrID
        {
            get { return miLeadProjMngrID; }
            set { miLeadProjMngrID = value; }
        }
        public int RelationshipMngrID
        {
            get { return miRelationshipMngrID; }
            set { miRelationshipMngrID = value; }
        }

        public int RateSchedID
        {
            get { return miRateSchedID; }
            set { miRateSchedID = value; }
        }

        public decimal Multiplier
        {
            get { return mdMultiplier; }
            set { mdMultiplier = value; }
        }

        public decimal Overlay
        {
            get { return mdOverlay; }
            set { mdOverlay = value; }
        }

        public string Notes
        {
            get { return msNotes; }
            set { msNotes = value; }
        }

        public DateTime DateStart
        {
            get { return mdDateStart; }
            set { mdDateStart = value; }
        }

        public DateTime DateEnd
        {
            get { return mdDateEnd; }
            set { mdDateEnd = value; }
        }

        public bool IsProposal
        {
            get { return mbIsProposal; }
            set { mbIsProposal = value; }
        }

        public bool IsBooked
        {
            get { return mbIsBooked; }
            set { mbIsBooked = value; }
        }

        public bool IsActive
        {
            get { return mbIsActive; }
            set { mbIsActive = value; }
        }

        public bool IsGovernment
        {
            get { return mbIsGovernment; }
            set { mbIsGovernment = value; }
        }

        public bool IsMaster
        {
            get { return mbIsmaster; }
            set { mbIsmaster = value; }
        }

        public int MasterID
        {
            get { return miMasterID; }
            set { miMasterID = value; }
        }

        public int ReportingStatus
        {
            get { return miReportingStatus; }
            set { miReportingStatus = value; }
        }

        public decimal Budget
        {
            get { return mdBudget; }
            set { mdBudget = value; }
        }

        public string POAmount
        {
            get { return msPOAmnt; }
            set { msPOAmnt = value; }
        }


        public string CustomerName  //******************************Added 7/8/2015
        {
            get { return msCustomerName; }
            set { msCustomerName = value; }
        }

        public string City
        {
            get { return msCity; }
            set { msCity = value; }
        }

        public string State
        {
            get { return msState; }
            set { msState = value; }
        }


        



        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msNumber = "";
            msDescription = "";
            miCustomerID = 0;
            msCustomerProjNumber = "";
            miLocationID = 0;
            miProjMngrID = 0;
            miLeadProjMngrID = 0;
            miRelationshipMngrID = 0;
            miRateSchedID = 0;
            mdMultiplier = 0;
            mdOverlay = 0;
            msNotes = "";
            mdDateStart = DateTime.Now;
            mdDateEnd = DateTime.Now;
            mbIsProposal = false;
            mbIsBooked = false;
            mbIsActive = false;
            mbIsGovernment = false;
            mbIsmaster = false;
            miMasterID = 0;
            miReportingStatus = 0;
            mdBudget = 0;
            msPOAmnt = "";
        }

        public void Copy(COProject oNew)
        {
            oNew.ID = miID;
            oNew.Number = msNumber;
            oNew.Description = msDescription;
            oNew.CustomerID = miCustomerID;
            oNew.CustomerProjNumber = msCustomerProjNumber;
            oNew.LocationID = miLocationID;
            oNew.ProjMngrID = miProjMngrID;
            oNew.LeadProjMngrID = miLeadProjMngrID;
            oNew.RelationshipMngrID = miRelationshipMngrID;
            oNew.RateSchedID = miRateSchedID;
            oNew.Multiplier = mdMultiplier;
            oNew.Overlay = mdOverlay;
            oNew.Notes = msNotes;
            oNew.DateStart = mdDateStart;
            oNew.DateEnd = mdDateEnd;
            oNew.IsProposal = mbIsProposal;
            oNew.IsBooked = mbIsBooked;
            oNew.IsActive = mbIsActive;
            oNew.IsGovernment = mbIsGovernment;
            oNew.IsMaster = mbIsmaster;
            oNew.MasterID = miMasterID;
            oNew.ReportingStatus = miReportingStatus;
            oNew.Budget = mdBudget;
            oNew.POAmount = msPOAmnt;
        }

        public void LoadFromObj(COProject oOrg)
        {
            miID = oOrg.ID;
            msNumber = oOrg.Number;
            msDescription = oOrg.Description;
            miCustomerID = oOrg.CustomerID;
            msCustomerProjNumber = oOrg.CustomerProjNumber;
            miLocationID = oOrg.LocationID;
            miProjMngrID = oOrg.ProjMngrID;
            miLeadProjMngrID = oOrg.LeadProjMngrID;
            miRelationshipMngrID = oOrg.RelationshipMngrID;
            miRateSchedID = oOrg.RateSchedID;
            mdMultiplier = oOrg.Multiplier;
            mdOverlay = oOrg.Overlay;
            msNotes = oOrg.Notes;
            mdDateStart = oOrg.DateStart;
            mdDateEnd = oOrg.DateEnd;
            mbIsProposal = oOrg.IsProposal;
            mbIsBooked = oOrg.IsBooked;
            mbIsActive = oOrg.IsActive;
            mbIsGovernment = oOrg.IsGovernment;
            mbIsmaster = oOrg.IsMaster;
            miMasterID = oOrg.MasterID;
            miReportingStatus = oOrg.ReportingStatus;
            mdBudget = oOrg.Budget;
            msPOAmnt = oOrg.POAmount;
        }

        public void LoadFromObj_Description(COProject oOrg) //*************************Added 7/8/2015
        {
            miID = oOrg.ID;
            msNumber = oOrg.Number;
            msDescription = oOrg.Description;
            miCustomerID = oOrg.CustomerID;
            msCustomerName = oOrg.CustomerName;
            miLocationID = oOrg.LocationID;
            msCity = oOrg.City;
            msState = oOrg.State;
           
        }




    }
}
