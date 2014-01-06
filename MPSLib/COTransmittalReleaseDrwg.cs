using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COTransmittalReleaseDrwg
    {
        private int miID;
        private int miReleaseID;
        private int miDrawingID;
        private string msHGANumber;
        private string msCADNumber;
        private string msTitleDesc;
        private string msRevision;
        private DateTime mdtDateReleased;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int ReleaseID
        {
            get { return miReleaseID; }
            set { miReleaseID = value; }
        }

        public int DrawingID
        {
            get { return miDrawingID; }
            set { miDrawingID = value; }
        }

        public string HGANumber
        {
            get { return msHGANumber; }
            set { msHGANumber = value; }
        }

        public string CADNumber
        {
            get { return msCADNumber; }
            set { msCADNumber = value; }
        }

        public string TitleDesc
        {
            get { return msTitleDesc; }
            set { msTitleDesc = value; }
        }

        public string Revision
        {
            get { return msRevision; }
            set { msRevision = value; }
        }

        public DateTime DateReleased
        {
            get { return mdtDateReleased; }
            set { mdtDateReleased = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miReleaseID = 0;
            miDrawingID = 0;
            msHGANumber = "";
            msCADNumber = "";
            msTitleDesc = "";
            msRevision = "";
            mdtDateReleased = DateTime.Now;
        }

        public void Copy(COTransmittalReleaseDrwg oNew)
        {
            oNew.ID = miID;
            oNew.ReleaseID = miReleaseID;
            oNew.DrawingID = miDrawingID;
            oNew.HGANumber = msHGANumber;
            oNew.CADNumber = msCADNumber;
            oNew.TitleDesc = msTitleDesc;
            oNew.Revision = msRevision;
            oNew.DateReleased = mdtDateReleased;
        }

        public void LoadFromObj(COTransmittalReleaseDrwg oOrg)
        {
            miID = oOrg.ID;
            miReleaseID = oOrg.ReleaseID;
            miDrawingID = oOrg.DrawingID;
            msHGANumber = oOrg.HGANumber;
            msCADNumber = oOrg.CADNumber;
            msTitleDesc = oOrg.TitleDesc;
            msRevision = oOrg.Revision;
            mdtDateReleased = oOrg.DateReleased;
        }
    }
}
