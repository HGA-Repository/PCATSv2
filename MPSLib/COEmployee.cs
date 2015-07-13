using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COEmployee
    {
        private int miID;
        private string msNumber;
        private string msName;
        private string msAbbrev;
        private int miEmpTitleID;
        private decimal mdMinHrs;
        private decimal mdMaxRegHrs;
        private decimal mdMaxAllHrs;
        private bool mbIsActive;
        private bool mbIsProjectManager;
        private bool mbIsRelManager; //*******************Added*********7/13/2015
        private int miLocation;
        private bool mbContractor;
        private int miType;
        private string msOfficeLocation;
        private string msEngineerType;
       

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

        public string Name
        {
            get { return msName; }
            set { msName = value; }
        }

        public string Abbrev
        {
            get { return msAbbrev; }
            set { msAbbrev = value; }
        }

        public int EmpTitleID
        {
            get { return miEmpTitleID; }
            set { miEmpTitleID = value; }
        }

        public decimal MinHrs
        {
            get { return mdMinHrs; }
            set { mdMinHrs = value; }
        }

        public decimal MaxRegHrs
        {
            get { return mdMaxRegHrs; }
            set { mdMaxRegHrs = value; }
        }

        public decimal MaxAllHrs
        {
            get { return mdMaxAllHrs; }
            set { mdMaxAllHrs = value; }
        }

        public bool IsActive
        {
            get { return mbIsActive; }
            set { mbIsActive = value; }
        }

        public bool IsProjectManager
        {
            get { return mbIsProjectManager; }
            set { mbIsProjectManager = value; }
        }

        public bool IsRelManager //*****************************Added 7/13/2015
        {
            get { return mbIsRelManager; }
            set { mbIsRelManager = value; }
        }

        

        public int Location
        {
            get { return miLocation; }
            set { miLocation = value; }
        }
        
        public bool Contractor
        {
            get { return mbContractor; }
            set { mbContractor = value; }
        }
        public int Type
        {
            get { return miType; }
            set { miType = value; }
        }
        public string OfficeLocation
        {
            get { return msOfficeLocation; }
            set { msOfficeLocation = value; }
        }
        public string EngineerType
        {
            get { return msEngineerType; }
            set { msEngineerType = value; }
        }
        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msNumber = "";
            msName = "";
            msAbbrev = "";
            miEmpTitleID = 0;
            mdMinHrs = 0;
            mdMaxRegHrs = 0;
            mdMaxAllHrs = 0;
            mbIsActive = false;
            mbIsProjectManager = false;
            mbIsRelManager = false; //*******************Added*********7/13/2015

            miLocation = 0;
            mbContractor = false;
            miType = 0;
            msOfficeLocation = "";
            msEngineerType = "";
      
            
        }

        public void Copy(COEmployee oNew)
        {
            oNew.ID = miID;
            oNew.Number = msNumber;
            oNew.Name = msName;
            oNew.Abbrev = msAbbrev;
            oNew.EmpTitleID = miEmpTitleID;
            oNew.MinHrs = mdMinHrs;
            oNew.MaxRegHrs = mdMaxRegHrs;
            oNew.MaxAllHrs = mdMaxAllHrs;
            oNew.IsActive = mbIsActive;
            oNew.IsProjectManager = mbIsProjectManager;
            oNew.IsRelManager = mbIsRelManager; //****************Added 7/13/2015

            oNew.Contractor = mbContractor;
            oNew.OfficeLocation = msOfficeLocation;
            oNew.EngineerType = msEngineerType;

        
            
            
            }

        public void LoadFromObj(COEmployee oOrg)
        {
            miID = oOrg.ID;
            msNumber = oOrg.Number;
            msName = oOrg.Name;
            msAbbrev = oOrg.Abbrev;
            miEmpTitleID = oOrg.EmpTitleID;
            mdMinHrs = oOrg.MinHrs;
            mdMaxRegHrs = oOrg.MaxRegHrs;
            mdMaxAllHrs = oOrg.MaxAllHrs;
            mbIsActive = oOrg.IsActive;
            mbIsProjectManager = oOrg.IsProjectManager;
            mbIsRelManager = oOrg.IsRelManager;//****************Added 7/13/2015
            mbContractor = oOrg.Contractor;
            msOfficeLocation = oOrg.OfficeLocation;
            msEngineerType = oOrg.EngineerType;
            
        }
    }
}
