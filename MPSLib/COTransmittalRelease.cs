using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COTransmittalRelease
    {
        private int miID;
        private DateTime mdDateIssued;
        private string msIssuedBy;
        private string msReleaseNumber;
        private int miProjectID;
        private int miDeptID;
        private bool mbTypeTransOnly;
        private bool mbTypeFullPrint;
        private bool mbTypeReduced;
        private bool mbTypeEmail;
        private bool mbTypeERoom;
        private bool mbTypeCD;
        private bool mbRelPreliminary;
        private bool mbRelApproval;
        private bool mbRelBidding;
        private bool mbRelConstruction;
        private bool mbRelOther;
        private string msRelOtherTxt;

        private bool mbSendNextDay;
        private bool mbSendSecDay;
        private bool mbSendThirdDay;
        private bool mbSendGround;

        private bool mbSendDwg;
        private bool mbSendDxf;
        private bool mbSendPdf;
        private string msSendEmailOther;

        private bool mbSendFTPDwg;
        private bool mbSendFTPDwf;
        private bool mbSendFTPPdf;
        private string msSendFTPOther;

        private bool mbSendSPDwg;
        private bool mbSendSPDwf;
        private bool mbSendSPPdf;
        private string msSendSPOther;

        private bool mbSendRegular;
        private bool mbSendDelivery;
        private bool mbSendPickup;

        private string msGeneralDesc;
        private string msComments;


        public COTransmittalRelease()
        {
            Clear();
        }

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public DateTime DateIssued
        {
            get { return mdDateIssued; }
            set { mdDateIssued = value; }
        }

        public string IssuedBy
        {
            get { return msIssuedBy; }
            set { msIssuedBy = value; }
        }

        public string ReleaseNumber
        {
            get { return msReleaseNumber; }
            set { msReleaseNumber = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public int DeptID
        {
            get { return miDeptID; }
            set { miDeptID = value; }
        }

        public bool TypeTransOnly
        {
            get { return mbTypeTransOnly; }
            set { mbTypeTransOnly = value; }
        }

        public bool TypeFullPrint
        {
            get { return mbTypeFullPrint; }
            set { mbTypeFullPrint = value; }
        }

        public bool TypeReduced
        {
            get { return mbTypeReduced; }
            set { mbTypeReduced = value; }
        }

        public bool TypeEmail
        {
            get { return mbTypeEmail; }
            set { mbTypeEmail = value; }
        }

        public bool TypeERoom
        {
            get { return mbTypeERoom; }
            set { mbTypeERoom = value; }
        }

        public bool TypeCD
        {
            get { return mbTypeCD; }
            set { mbTypeCD = value; }
        }

        public bool RelPreliminary
        {
            get { return mbRelPreliminary; }
            set { mbRelPreliminary = value; }
        }

        public bool RelApproval
        {
            get { return mbRelApproval; }
            set { mbRelApproval = value; }
        }

        public bool RelBidding
        {
            get { return mbRelBidding; }
            set { mbRelBidding = value; }
        }

        public bool RelConstruction
        {
            get { return mbRelConstruction; }
            set { mbRelConstruction = value; }
        }

        public bool RelOther
        {
            get { return mbRelOther; }
            set { mbRelOther = value; }
        }

        public string RelOtherTxt
        {
            get { return msRelOtherTxt; }
            set { msRelOtherTxt = value; }
        }

        public bool SendNextDay
        {
            get { return mbSendNextDay; }
            set { mbSendNextDay = value; }
        }

        public bool SendSecDay
        {
            get { return mbSendSecDay; }
            set { mbSendSecDay = value; }
        }

        public bool SendThirdDay
        {
            get { return mbSendThirdDay; }
            set { mbSendThirdDay = value; }
        }

        public bool SendGround
        {
            get { return mbSendGround; }
            set { mbSendGround = value; }
        }

        public bool SendDwg
        {
            get { return mbSendDwg; }
            set { mbSendDwg = value; }
        }

        public bool SendDxf
        {
            get { return mbSendDxf; }
            set { mbSendDxf = value; }
        }

        public bool SendPdf
        {
            get { return mbSendPdf; }
            set { mbSendPdf = value; }
        }

        public string SendEmailOther
        {
            get { return msSendEmailOther; }
            set { msSendEmailOther = value; }
        }

        public bool SendFTPDwg
        {
            get { return mbSendFTPDwg; }
            set { mbSendFTPDwg = value; }
        }

        public bool SendFTPDwf
        {
            get { return mbSendFTPDwf; }
            set { mbSendFTPDwf = value; }
        }

        public bool SendFTPPdf
        {
            get { return mbSendFTPPdf; }
            set { mbSendFTPPdf = value; }
        }

        public string SendFTPOther
        {
            get { return msSendFTPOther; }
            set { msSendFTPOther = value; }
        }

        public bool SendSPDwg
        {
            get { return mbSendSPDwg; }
            set { mbSendSPDwg = value; }
        }

        public bool SendSPDwf
        {
            get { return mbSendSPDwf; }
            set { mbSendSPDwf = value; }
        }

        public bool SendSPPdf
        {
            get { return mbSendSPPdf; }
            set { mbSendSPPdf = value; }
        }

        public string SendSPOther
        {
            get { return msSendSPOther; }
            set { msSendSPOther = value; }
        }

        public bool SendRegular
        {
            get { return mbSendRegular; }
            set { mbSendRegular = value; }
        }

        public bool SendDelivery
        {
            get { return mbSendDelivery; }
            set { mbSendDelivery = value; }
        }

        public bool SendPickup
        {
            get { return mbSendPickup; }
            set { mbSendPickup = value; }
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

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            mdDateIssued = DateTime.Now;
            msIssuedBy = "";
            msReleaseNumber = "";
            miProjectID = 0;
            miDeptID = 0;
            mbTypeTransOnly = false;
            mbTypeFullPrint = false;
            mbTypeReduced = false;
            mbTypeEmail = false;
            mbTypeERoom = false;
            mbTypeCD = false;
            mbRelPreliminary = false;
            mbRelApproval = false;
            mbRelBidding = false;
            mbRelConstruction = false;
            mbRelOther = false;
            msRelOtherTxt = "";
            mbSendNextDay = false;
            mbSendSecDay = false;
            mbSendThirdDay = false;
            mbSendGround = false;
            mbSendDwg = false;
            mbSendDxf = false;
            mbSendPdf = false;
            msSendEmailOther = "";
            mbSendFTPDwg = false;
            mbSendFTPDwf = false;
            mbSendFTPPdf = false;
            msSendFTPOther = "";
            mbSendSPDwg = false;
            mbSendSPDwf = false;
            mbSendSPPdf = false;
            msSendSPOther = "";
            mbSendRegular = false;
            mbSendDelivery = false;
            mbSendPickup = false;
            msGeneralDesc = "";
            msComments = "";
        }

        public void Copy(COTransmittalRelease oNew)
        {
            oNew.ID = miID;
            oNew.DateIssued = mdDateIssued;
            oNew.IssuedBy = msIssuedBy;
            oNew.ReleaseNumber = msReleaseNumber;
            oNew.ProjectID = miProjectID;
            oNew.DeptID = miDeptID;
            oNew.TypeTransOnly = mbTypeTransOnly;
            oNew.TypeFullPrint = mbTypeFullPrint;
            oNew.TypeReduced = mbTypeReduced;
            oNew.TypeEmail = mbTypeEmail;
            oNew.TypeERoom = mbTypeERoom;
            oNew.TypeCD = mbTypeCD;
            oNew.RelPreliminary = mbRelPreliminary;
            oNew.RelApproval = mbRelApproval;
            oNew.RelBidding = mbRelBidding;
            oNew.RelConstruction = mbRelConstruction;
            oNew.RelOther = mbRelOther;
            oNew.RelOtherTxt = msRelOtherTxt;
            oNew.SendNextDay = mbSendNextDay;
            oNew.SendSecDay = mbSendSecDay;
            oNew.SendThirdDay = mbSendThirdDay;
            oNew.SendGround = mbSendGround;
            oNew.SendDwg = mbSendDwg;
            oNew.SendDxf = mbSendDxf;
            oNew.SendPdf = mbSendPdf;
            oNew.SendEmailOther = msSendEmailOther;
            oNew.SendFTPDwg = mbSendFTPDwg;
            oNew.SendFTPDwf = mbSendFTPDwf;
            oNew.SendFTPPdf = mbSendFTPPdf;
            oNew.SendFTPOther = msSendFTPOther;
            oNew.SendSPDwg = mbSendSPDwg;
            oNew.SendSPDwf = mbSendSPDwf;
            oNew.SendSPPdf = mbSendSPPdf;
            oNew.SendSPOther = msSendSPOther;
            oNew.SendRegular = mbSendRegular;
            oNew.SendDelivery = mbSendDelivery;
            oNew.SendPickup = mbSendPickup;
            oNew.GeneralDesc = msGeneralDesc;
            oNew.Comments = msComments;
        }

        public void LoadFromObj(COTransmittalRelease oOrg)
        {
            miID = oOrg.ID;
            mdDateIssued = oOrg.DateIssued;
            msIssuedBy = oOrg.IssuedBy;
            msReleaseNumber = oOrg.ReleaseNumber;
            miProjectID = oOrg.ProjectID;
            miDeptID = oOrg.DeptID;
            mbTypeTransOnly = oOrg.TypeTransOnly;
            mbTypeFullPrint = oOrg.TypeFullPrint;
            mbTypeReduced = oOrg.TypeReduced;
            mbTypeEmail = oOrg.TypeEmail;
            mbTypeERoom = oOrg.TypeERoom;
            mbTypeCD = oOrg.TypeCD;
            mbRelPreliminary = oOrg.RelPreliminary;
            mbRelApproval = oOrg.RelApproval;
            mbRelBidding = oOrg.RelBidding;
            mbRelConstruction = oOrg.RelConstruction;
            mbRelOther = oOrg.RelOther;
            msRelOtherTxt = oOrg.RelOtherTxt;
            mbSendNextDay = oOrg.SendNextDay;
            mbSendSecDay = oOrg.SendSecDay;
            mbSendThirdDay = oOrg.SendThirdDay;
            mbSendGround = oOrg.SendGround;
            mbSendDwg = oOrg.SendDwg;
            mbSendDxf = oOrg.SendDxf;
            mbSendPdf = oOrg.SendPdf;
            msSendEmailOther = oOrg.SendEmailOther;
            mbSendFTPDwg = oOrg.SendFTPDwg;
            mbSendFTPDwf = oOrg.SendFTPDwf;
            mbSendFTPPdf = oOrg.SendFTPPdf;
            msSendFTPOther = oOrg.SendFTPOther;
            mbSendSPDwg = oOrg.SendSPDwg;
            mbSendSPDwf = oOrg.SendSPDwf;
            mbSendSPPdf = oOrg.SendSPPdf;
            msSendSPOther = oOrg.SendSPOther;
            mbSendThirdDay = oOrg.SendThirdDay;
            mbSendGround = oOrg.SendGround;
            mbSendDwg = oOrg.SendDwg;
            mbSendDxf = oOrg.SendDxf;
            mbSendPdf = oOrg.SendPdf;
            msSendEmailOther = oOrg.SendEmailOther;
            mbSendFTPDwg = oOrg.SendFTPDwg;
            mbSendFTPDwf = oOrg.SendFTPDwf;
            mbSendFTPPdf = oOrg.SendFTPPdf;
            msSendFTPOther = oOrg.SendFTPOther;
            mbSendSPDwg = oOrg.SendSPDwg;
            mbSendSPDwf = oOrg.SendSPDwf;
            mbSendSPPdf = oOrg.SendSPPdf;
            msSendSPOther = oOrg.SendSPOther;
            mbSendRegular = oOrg.SendRegular;
            mbSendDelivery = oOrg.SendDelivery;
            mbSendPickup = oOrg.SendPickup;
            msGeneralDesc = oOrg.GeneralDesc;
            msComments = oOrg.Comments;
        }
    }
}
