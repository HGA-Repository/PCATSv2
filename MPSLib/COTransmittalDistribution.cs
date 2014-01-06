using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class COTransmittalDistribution
    {
        private int miID;
        private int miReleaseID;
        private int miEmployeeID;
        private string msName;
        private int miReleaseTypeID;
        private string msReleaseType;
        private int miDocCount;
        private bool mbIsCC;

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

        public int EmployeeID
        {
            get { return miEmployeeID; }
            set { miEmployeeID = value; }
        }

        public string Name
        {
            get { return msName; }
            set { msName = value; }
        }

        public int ReleaseTypeID
        {
            get { return miReleaseTypeID; }
            set { miReleaseTypeID = value; }
        }

        public string ReleaseType
        {
            get { return msReleaseType; }
            set { msReleaseType = value; }
        }

        public int DocCount
        {
            get { return miDocCount; }
            set { miDocCount = value; }
        }

        public bool IsCC
        {
            get { return mbIsCC; }
            set { mbIsCC = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miReleaseID = 0;
            miEmployeeID = 0;
            msName = "";
            miReleaseTypeID = 0;
            msReleaseType = "";
            miDocCount = 0;
            mbIsCC = false;
        }

        public void Copy(COTransmittalDistribution oNew)
        {
            oNew.ID = miID;
            oNew.ReleaseID = miReleaseID;
            oNew.EmployeeID = miEmployeeID;
            oNew.Name = msName;
            oNew.ReleaseTypeID = miReleaseTypeID;
            oNew.ReleaseType = msReleaseType;
            oNew.DocCount = miDocCount;
            oNew.IsCC = mbIsCC;
        }

        public void LoadFromObj(COTransmittalDistribution oOrg)
        {
            miID = oOrg.ID;
            miReleaseID = oOrg.ReleaseID;
            miEmployeeID = oOrg.EmployeeID;
            msName = oOrg.Name;
            miReleaseTypeID = oOrg.ReleaseTypeID;
            msReleaseType = oOrg.ReleaseType;
            miDocCount = oOrg.DocCount;
            mbIsCC = oOrg.IsCC;
        }
    }
}
