using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COTransmittalDoc
    {
        private int miID;
        private int miTransmittalID;
        private int miReleaseDocID;
        private int miCopies;
        private string msDocDwgNo;
        private string msRevision;
        private DateTime mdtDateTrans;
        private string msDescription;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int TransmittalID
        {
            get { return miTransmittalID; }
            set { miTransmittalID = value; }
        }

        public int ReleaseDocID
        {
            get { return miReleaseDocID; }
            set { miReleaseDocID = value; }
        }

        public int Copies
        {
            get { return miCopies; }
            set { miCopies = value; }
        }

        public string DocDwgNo
        {
            get { return msDocDwgNo; }
            set { msDocDwgNo = value; }
        }

        public string Revision
        {
            get { return msRevision; }
            set { msRevision = value; }
        }

        public DateTime DateTrans
        {
            get { return mdtDateTrans; }
            set { mdtDateTrans = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miTransmittalID = 0;
            miReleaseDocID = 0;
            miCopies = 0;
            msDocDwgNo = "";
            msRevision = "";
            mdtDateTrans = DateTime.Now;
            msDescription = "";
        }

        public void Copy(COTransmittalDoc oNew)
        {
            oNew.ID = miID;
            oNew.TransmittalID = miTransmittalID;
            oNew.ReleaseDocID = miReleaseDocID;
            oNew.Copies = miCopies;
            oNew.DocDwgNo = msDocDwgNo;
            oNew.Revision = msRevision;
            oNew.DateTrans = mdtDateTrans;
            oNew.Description = msDescription;
        }

        public void LoadFromObj(COTransmittalDoc oOrg)
        {
            miID = oOrg.ID;
            miTransmittalID = oOrg.TransmittalID;
            miReleaseDocID = oOrg.ReleaseDocID;
            miCopies = oOrg.Copies;
            msDocDwgNo = oOrg.DocDwgNo;
            msRevision = oOrg.Revision;
            mdtDateTrans = oOrg.DateTrans;
            msDescription = oOrg.Description;
        }
    }
}
