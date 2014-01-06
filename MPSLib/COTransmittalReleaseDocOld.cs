using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COTransmittalReleaseDocOld
    {
        private int miID;
        private int miTransRelID;
        private int miDocID;
        private string msDocNum;
        private string msDescription;
        private int miRevision;
        private DateTime mdDateReleased;

        public COTransmittalReleaseDocOld()
        {
            Clear();
        }

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int TransRelID
        {
            get { return miTransRelID; }
            set { miTransRelID = value; }
        }

        public int DocID
        {
            get { return miDocID; }
            set { miDocID = value; }
        }

        public string DocNum
        {
            get { return msDocNum; }
            set { msDocNum = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public int Revision
        {
            get { return miRevision; }
            set { miRevision = value; }
        }

        public DateTime DateReleased
        {
            get { return mdDateReleased; }
            set { mdDateReleased = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miTransRelID = 0;
            miDocID = 0;
            msDocNum = "";
            msDescription = "";
            miRevision = 0;
            mdDateReleased = DateTime.Now;
        }

        public void Copy(COTransmittalReleaseDocOld oNew)
        {
            oNew.ID = miID;
            oNew.TransRelID = miTransRelID;
            oNew.DocID = miDocID;
            oNew.DocNum = msDocNum;
            oNew.Description = msDescription;
            oNew.Revision = miRevision;
            oNew.DateReleased = mdDateReleased;
        }

        public void LoadFromObj(COTransmittalReleaseDocOld oOrg)
        {
            miID = oOrg.ID;
            miTransRelID = oOrg.TransRelID;
            miDocID = oOrg.DocID;
            msDocNum = oOrg.DocNum;
            msDescription = oOrg.Description;
            miRevision = oOrg.Revision;
            mdDateReleased = oOrg.DateReleased;
        }
    }
}
