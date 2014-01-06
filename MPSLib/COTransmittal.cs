using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COTransmittal
    {
        private int miID;
        private int miProjectID;
        private int miReleaseID;
        private string msTransmittalNumber;
        private string msProjectClient;
        private DateTime mdtDateTransmittal;
        private string msProjectTitle;
        private string msTransmittalTo;
        private bool mbWeTransmitHereWith;
        private bool mbUnderSeperateCover;
        private bool mbSentDrawings;
        private bool mbSentSpecifications;
        private bool mbSentSchedule;
        private bool mbSentBrochure;
        private bool mbSentCorrespondence;
        private bool mbForPreliminary;
        private bool mbForApproval;
        private bool mbForBidding;
        private bool mbForConstruction;
        private bool mbForNoted;
        private string msForNotedOther;
        private bool mbByUSPS;
        private bool mbByEmail;
        private bool mbByOvernight;
        private bool mbBySecondDay;
        private bool mbByMessenger;
        private string msGeneralDesc;
        private string msComments;
        private string msPC;
        private string msReleasedBy;
        private string msSentBy;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public int ReleaseID
        {
            get { return miReleaseID; }
            set { miReleaseID = value; }
        }

        public string TransmittalNumber
        {
            get { return msTransmittalNumber; }
            set { msTransmittalNumber = value; }
        }

        public string ProjectClient
        {
            get { return msProjectClient; }
            set { msProjectClient = value; }
        }

        public DateTime DateTransmittal
        {
            get { return mdtDateTransmittal; }
            set { mdtDateTransmittal = value; }
        }

        public string ProjectTitle
        {
            get { return msProjectTitle; }
            set { msProjectTitle = value; }
        }

        public string TransmittalTo
        {
            get { return msTransmittalTo; }
            set { msTransmittalTo = value; }
        }

        public bool WeTransmitHereWith
        {
            get { return mbWeTransmitHereWith; }
            set { mbWeTransmitHereWith = value; }
        }

        public bool UnderSeperateCover
        {
            get { return mbUnderSeperateCover; }
            set { mbUnderSeperateCover = value; }
        }

        public bool SentDrawings
        {
            get { return mbSentDrawings; }
            set { mbSentDrawings = value; }
        }

        public bool SentSpecifications
        {
            get { return mbSentSpecifications; }
            set { mbSentSpecifications = value; }
        }

        public bool SentSchedule
        {
            get { return mbSentSchedule; }
            set { mbSentSchedule = value; }
        }

        public bool SentBrochure
        {
            get { return mbSentBrochure; }
            set { mbSentBrochure = value; }
        }

        public bool SentCorrespondence
        {
            get { return mbSentCorrespondence; }
            set { mbSentCorrespondence = value; }
        }

        public bool ForPreliminary
        {
            get { return mbForPreliminary; }
            set { mbForPreliminary = value; }
        }

        public bool ForApproval
        {
            get { return mbForApproval; }
            set { mbForApproval = value; }
        }

        public bool ForBidding
        {
            get { return mbForBidding; }
            set { mbForBidding = value; }
        }

        public bool ForConstruction
        {
            get { return mbForConstruction; }
            set { mbForConstruction = value; }
        }

        public bool ForNoted
        {
            get { return mbForNoted; }
            set { mbForNoted = value; }
        }

        public string ForNotedOther
        {
            get { return msForNotedOther; }
            set { msForNotedOther = value; }
        }

        public bool ByUSPS
        {
            get { return mbByUSPS; }
            set { mbByUSPS = value; }
        }

        public bool ByEmail
        {
            get { return mbByEmail; }
            set { mbByEmail = value; }
        }

        public bool ByOvernight
        {
            get { return mbByOvernight; }
            set { mbByOvernight = value; }
        }

        public bool BySecondDay
        {
            get { return mbBySecondDay; }
            set { mbBySecondDay = value; }
        }

        public bool ByMessenger
        {
            get { return mbByMessenger; }
            set { mbByMessenger = value; }
        }

        public string GeneralDesc
        {
            get { return msGeneralDesc; }
            set { msGeneralDesc = value; }
        }

        public string Comments
        {
            get { return msComments; }
            set { msComments = value; }
        }

        public string PC
        {
            get { return msPC; }
            set { msPC = value; }
        }

        public string ReleasedBy
        {
            get { return msReleasedBy; }
            set { msReleasedBy = value; }
        }

        public string SentBy
        {
            get { return msSentBy; }
            set { msSentBy = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjectID = 0;
            miReleaseID = 0;
            msTransmittalNumber = "";
            msProjectClient = "";
            mdtDateTransmittal = DateTime.Now;
            msProjectTitle = "";
            msTransmittalTo = "";
            mbWeTransmitHereWith = false;
            mbUnderSeperateCover = false;
            mbSentDrawings = false;
            mbSentSpecifications = false;
            mbSentSchedule = false;
            mbSentBrochure = false;
            mbSentCorrespondence = false;
            mbForPreliminary = false;
            mbForApproval = false;
            mbForBidding = false;
            mbForConstruction = false;
            mbForNoted = false;
            msForNotedOther = "";
            mbByUSPS = false;
            mbByEmail = false;
            mbByOvernight = false;
            mbBySecondDay = false;
            mbByMessenger = false;
            msGeneralDesc = "";
            msComments = "";
            msPC = "";
            msReleasedBy = "";
            msSentBy = "";
        }

        public void Copy(COTransmittal oNew)
        {
            oNew.ID = miID;
            oNew.ProjectID = miProjectID;
            oNew.ReleaseID = miReleaseID;
            oNew.TransmittalNumber = msTransmittalNumber;
            oNew.ProjectClient = msProjectClient;
            oNew.DateTransmittal = mdtDateTransmittal;
            oNew.ProjectTitle = msProjectTitle;
            oNew.TransmittalTo = msTransmittalTo;
            oNew.WeTransmitHereWith = mbWeTransmitHereWith;
            oNew.UnderSeperateCover = mbUnderSeperateCover;
            oNew.SentDrawings = mbSentDrawings;
            oNew.SentSpecifications = mbSentSpecifications;
            oNew.SentSchedule = mbSentSchedule;
            oNew.SentBrochure = mbSentBrochure;
            oNew.SentCorrespondence = mbSentCorrespondence;
            oNew.ForPreliminary = mbForPreliminary;
            oNew.ForApproval = mbForApproval;
            oNew.ForBidding = mbForBidding;
            oNew.ForConstruction = mbForConstruction;
            oNew.ForNoted = mbForNoted;
            oNew.ForNotedOther = msForNotedOther;
            oNew.ByUSPS = mbByUSPS;
            oNew.ByEmail = mbByEmail;
            oNew.ByOvernight = mbByOvernight;
            oNew.BySecondDay = mbBySecondDay;
            oNew.ByMessenger = mbByMessenger;
            oNew.GeneralDesc = msGeneralDesc;
            oNew.Comments = msComments;
            oNew.PC = msPC;
            oNew.ReleasedBy = msReleasedBy;
            oNew.SentBy = msSentBy;
        }

        public void LoadFromObj(COTransmittal oOrg)
        {
            miID = oOrg.ID;
            miProjectID = oOrg.ProjectID;
            miReleaseID = oOrg.ReleaseID;
            msTransmittalNumber = oOrg.TransmittalNumber;
            msProjectClient = oOrg.ProjectClient;
            mdtDateTransmittal = oOrg.DateTransmittal;
            msProjectTitle = oOrg.ProjectTitle;
            msTransmittalTo = oOrg.TransmittalTo;
            mbWeTransmitHereWith = oOrg.WeTransmitHereWith;
            mbUnderSeperateCover = oOrg.UnderSeperateCover;
            mbSentDrawings = oOrg.SentDrawings;
            mbSentSpecifications = oOrg.SentSpecifications;
            mbSentSchedule = oOrg.SentSchedule;
            mbSentBrochure = oOrg.SentBrochure;
            mbSentCorrespondence = oOrg.SentCorrespondence;
            mbForPreliminary = oOrg.ForPreliminary;
            mbForApproval = oOrg.ForApproval;
            mbForBidding = oOrg.ForBidding;
            mbForConstruction = oOrg.ForConstruction;
            mbForNoted = oOrg.ForNoted;
            msForNotedOther = oOrg.ForNotedOther;
            mbByUSPS = oOrg.ByUSPS;
            mbByEmail = oOrg.ByEmail;
            mbByOvernight = oOrg.ByOvernight;
            mbBySecondDay = oOrg.BySecondDay;
            mbByMessenger = oOrg.ByMessenger;
            msGeneralDesc = oOrg.GeneralDesc;
            msComments = oOrg.Comments;
            msPC = oOrg.PC;
            msReleasedBy = oOrg.ReleasedBy;
            msSentBy = oOrg.SentBy;
        }
    }
}
