using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBusiness_Unit
    {
        //private int miID;
        //private string msName;
        //private string msDescription;
        //private int miNumber;
        //private int miEmployeeID;

        private int miBus_Unit_ID;

        private string msBus_Unit_Description;





        #region Properties

        //public int ID
        //{
        //    get { return miID; }
        //    set { miID = value; }
        //}

        //public string Name
        //{
        //    get { return msName; }
        //    set { msName = value; }
        //}

        //public string Description
        //{
        //    get { return msDescription; }
        //    set { msDescription = value; }
        //}

        //public int Number
        //{
        //    get { return miNumber; }
        //    set { miNumber = value; }
        //}

        //public int EmployeeID
        //{
        //    get { return miEmployeeID; }
        //    set { miEmployeeID = value; }
        //}


        public int ID
        {
            get { return miBus_Unit_ID; }
            set { miBus_Unit_ID = value; }
        }

        

        public string Description
        {
            get { return msBus_Unit_Description; }
            set { msBus_Unit_Description = value; }
        }

       





        #endregion

        public virtual void Clear()
        {
            //miID = 0;
            //msName = "";
            //msDescription = "";
            //miNumber = 0;
            //miEmployeeID = 0;
            miBus_Unit_ID = 0;
            msBus_Unit_Description = "";
            


        }

        //public void Copy(CODepartment oNew)
        //{
        //    oNew.ID = miID;
        //    oNew.Name = msName;
        //    oNew.Description = msDescription;
        //    oNew.Number = miNumber;
        //    oNew.EmployeeID = miEmployeeID;
        //}

        public void Copy(COBusiness_Unit oNew)
        {
            oNew.miBus_Unit_ID = miBus_Unit_ID;

            oNew.msBus_Unit_Description = msBus_Unit_Description;
            
        }



        //public void LoadFromObj(CODepartment oOrg)
        //{
        //    miID = oOrg.ID;
        //    msName = oOrg.Name;
        //    msDescription = oOrg.Description;
        //    miNumber = oOrg.Number;
        //    miEmployeeID = oOrg.EmployeeID;
        //}

        public void LoadFromObj(COBusiness_Unit oOrg)
        {
            miBus_Unit_ID = oOrg.miBus_Unit_ID;

            msBus_Unit_Description = oOrg.msBus_Unit_Description;
            
        }



    }
}
