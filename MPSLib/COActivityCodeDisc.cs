using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COActivityCodeDisc
    {


        #region Properties

        public string Code { get; set; }
        public string Name { get; set; }

        #endregion

        public virtual void Clear()
        {
            Code = "";
            Name = "";
        }

        public void Copy(COActivityCodeDisc oNew)
        {
            oNew.Code = Code;
            oNew.Name = Name;
        }

        public void LoadFromObj(COActivityCodeDisc oOrg)
        {
            Code = oOrg.Code;
            Name = oOrg.Name;
        }
    }
}
