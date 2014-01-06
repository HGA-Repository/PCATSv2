using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class CORateSchedule
    {
        private int miID;
        private string msName;
        private string msDescription;
        private decimal mdDefaultRate;
        private decimal mdMultiplier;
        private decimal mdOverlay;
        private bool mbIsMultiplier;
        private int miOrdinal;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Name
        {
            get { return msName; }
            set { msName = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public decimal DefaultRate
        {
            get { return mdDefaultRate; }
            set { mdDefaultRate = value; }
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

        public bool IsMultiplier
        {
            get { return mbIsMultiplier; }
            set { mbIsMultiplier = value; }
        }

        public int Ordinal
        {
            get { return miOrdinal; }
            set { miOrdinal = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msName = "";
            msDescription = "";
            mdDefaultRate = 0;
            mdMultiplier = 0;
            mdOverlay = 0;
            mbIsMultiplier = false;
            miOrdinal = 0;
        }

        public void Copy(CORateSchedule oNew)
        {
            oNew.ID = miID;
            oNew.Name = msName;
            oNew.Description = msDescription;
            oNew.DefaultRate = mdDefaultRate;
            oNew.Multiplier = mdMultiplier;
            oNew.Overlay = mdOverlay;
            oNew.IsMultiplier = mbIsMultiplier;
            oNew.Ordinal = miOrdinal;
        }

        public void LoadFromObj(CORateSchedule oOrg)
        {
            miID = oOrg.ID;
            msName = oOrg.Name;
            msDescription = oOrg.Description;
            mdDefaultRate = oOrg.DefaultRate;
            mdMultiplier = oOrg.Multiplier;
            mdOverlay = oOrg.Overlay;
            mbIsMultiplier = oOrg.IsMultiplier;
            miOrdinal = oOrg.Ordinal;
        }
    }
}
