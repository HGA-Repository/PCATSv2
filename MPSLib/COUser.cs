using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COUser
    {
        private string PWRDKEY = "2434287644232400";
        private string VECTOR = "!REVSOL!";

        private int miID;
        private string msUsername;
        private string msDescription;
        private string msPassword;
        private bool mbIsAdministrator;
        private bool mbIsEngineerAdmin;
        private bool mbIsManager;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public string Username
        {
            get { return msUsername; }
            set { msUsername = value; }
        }

        public string Description
        {
            get { return msDescription; }
            set { msDescription = value; }
        }

        public string Password
        {
            get { return RSLib.COCryptography.DecryptString(msPassword, PWRDKEY, VECTOR); }
            set { msPassword = RSLib.COCryptography.EncryptString(value, PWRDKEY, VECTOR); }

        }

        public bool IsAdministrator
        {
            get { return mbIsAdministrator; }
            set { mbIsAdministrator = value; }
        }

        public bool IsEngineerAdmin
        {
            get { return mbIsEngineerAdmin; }
            set { mbIsEngineerAdmin = value; }
        }

        public bool IsManager
        {
            get { return mbIsManager; }
            set { mbIsManager = value; }
        }
        
        #endregion

        public virtual void Clear()
        {
            miID = 0;
            msUsername = "";
            msDescription = "";
            msPassword = "";
            mbIsAdministrator = false;
            mbIsEngineerAdmin = false;
            mbIsManager = false;
        }

        public void Copy(COUser oNew)
        {
            oNew.ID = miID;
            oNew.Username = msUsername;
            oNew.Description = msDescription;
            oNew.Password = msPassword;
            oNew.IsAdministrator = mbIsAdministrator;
            oNew.IsEngineerAdmin = mbIsEngineerAdmin;
            oNew.IsManager = mbIsManager;
        }

        public void LoadFromObj(COUser oOrg)
        {
            miID = oOrg.ID;
            msUsername = oOrg.Username;
            msDescription = oOrg.Description;
            msPassword = oOrg.Password;
            mbIsAdministrator = oOrg.IsAdministrator;
            mbIsEngineerAdmin = oOrg.IsEngineerAdmin;
            mbIsManager = oOrg.IsManager;
        }

        public string EncryptPassword(string pwrd)
        {
            //end user password
            return RSLib.COCryptography.EncryptStringPassword(pwrd, PWRDKEY, VECTOR);
        }
    }
}
