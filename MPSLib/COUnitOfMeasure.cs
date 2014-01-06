using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COUnitOfMeasure
    {
        private int miID;
        private string msUseCode;
        private string msCode;
        private string msDescription;
        private int miOrdinal;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string UseCode
        {
            get { return msUseCode; }
            set { msUseCode = value; }
        }

        public string Code
        {
            get { return msCode; }
            set { msCode = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
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
            msUseCode = "";
            msCode = "";
            msDescription = "";
            miOrdinal = 0;
        }

        public void Copy(COUnitOfMeasure oNew)
        {
            oNew.ID = miID;
            oNew.UseCode = msUseCode;
            oNew.Code = msCode;
            oNew.Description = msDescription;
            oNew.Ordinal = miOrdinal;
        }

        public void LoadFromObj(COUnitOfMeasure oOrg)
        {
            miID = oOrg.ID;
            msUseCode = oOrg.UseCode;
            msCode = oOrg.Code;
            msDescription = oOrg.Description;
            miOrdinal = oOrg.Ordinal;
        }
    }
}
