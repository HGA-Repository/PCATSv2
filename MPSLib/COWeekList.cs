using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COWeekList
    {
        private int miID;
        private DateTime mdStartOfWeek;
        private DateTime mdEndOfWeek;
        private int miNumber;
        private string msDisplayVal;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public DateTime StartOfWeek
        {
            get { return mdStartOfWeek; }
            set { mdStartOfWeek = value; }
        }

        public DateTime EndOfWeek
        {
            get { return mdEndOfWeek; }
            set { mdEndOfWeek = value; }
        }

        public int Number
        {
            get { return miNumber; }
            set { miNumber = value; }
        }

        public string DisplayVal
        {
            get { return msDisplayVal; }
            set { msDisplayVal = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            mdStartOfWeek = DateTime.Now;
            mdEndOfWeek = DateTime.Now;
            miNumber = 0;
            msDisplayVal = "";
        }

        public void Copy(COWeekList oNew)
        {
            oNew.ID = miID;
            oNew.StartOfWeek = mdStartOfWeek;
            oNew.EndOfWeek = mdEndOfWeek;
            oNew.Number = miNumber;
            oNew.DisplayVal = msDisplayVal;
        }

        public void LoadFromObj(COWeekList oOrg)
        {
            miID = oOrg.ID;
            mdStartOfWeek = oOrg.StartOfWeek;
            mdEndOfWeek = oOrg.EndOfWeek;
            miNumber = oOrg.Number;
            msDisplayVal = oOrg.DisplayVal;
        }
    }
}
