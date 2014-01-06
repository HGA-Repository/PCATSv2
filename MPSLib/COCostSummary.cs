using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COCostSummary
    {
        private int miID;
        private int miProjectID;
        private string msNumber;
        private string msManager;
        private string msTitle;
        private bool mbShowDollars;
        private string msComments;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int ProjectID
        {
            get { return miProjectID; }
            set { miProjectID = value; }
        }

        public string Number
        {
            get { return msNumber; }
            set { msNumber = value; }
        }

        public string Manager
        {
            get { return msManager; }
            set { msManager = value; }
        }

        public string Title
        {
            get { return msTitle; }
            set { msTitle = value; }
        }

        public bool ShowDollars
        {
            get { return mbShowDollars; }
            set { mbShowDollars = value; }
        }

        public string Comments
        {
            get { return msComments; }
            set { msComments = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miProjectID = 0;
            msNumber = "";
            msManager = "";
            msTitle = "";
            mbShowDollars = false;
            msComments = "";
        }

        public void Copy(COCostSummary oNew)
        {
            oNew.ID = miID;
            oNew.ProjectID = miProjectID;
            oNew.Number = msNumber;
            oNew.Manager = msManager;
            oNew.Title = msTitle;
            oNew.ShowDollars = mbShowDollars;
            oNew.Comments = msComments;
        }

        public void LoadFromObj(COCostSummary oOrg)
        {
            miID = oOrg.ID;
            miProjectID = oOrg.ProjectID;
            msNumber = oOrg.Number;
            msManager = oOrg.Manager;
            msTitle = oOrg.Title;
            mbShowDollars = oOrg.ShowDollars;
            msComments = oOrg.Comments;
        }
    }
}
