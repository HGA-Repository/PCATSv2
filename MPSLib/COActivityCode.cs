using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COActivityCode
    {
        private int miID;
        private string msCode;
        private string msName;

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

        public string Name
        {
            get { return msName; }
            set { msName = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msCode = "";
            msName = "";
        }

        public void Copy(COActivityCode oNew)
        {
            oNew.ID = miID;
            oNew.Code = msCode;
            oNew.Name = msName;
        }

        public void LoadFromObj(COActivityCode oOrg)
        {
            miID = oOrg.ID;
            msCode = oOrg.Code;
            msName = oOrg.Name;
        }
    }
}
