using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class CODrawingSize
    {
        private int miID;
        private string msCode;
        private string msSize;
        private int miOrdinal;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Code
        {
            get { return msCode; }
            set { msCode = value; }
        }

        public string Size
        {
            get { return msSize; }
            set { msSize = value; }
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
            msCode = "";
            msSize = "";
            miOrdinal = 0;
        }

        public void Copy(CODrawingSize oNew)
        {
            oNew.ID = miID;
            oNew.Code = msCode;
            oNew.Size = msSize;
            oNew.Ordinal = miOrdinal;
        }

        public void LoadFromObj(CODrawingSize oOrg)
        {
            miID = oOrg.ID;
            msCode = oOrg.Code;
            msSize = oOrg.Size;
            miOrdinal = oOrg.Ordinal;
        }
    }
}
