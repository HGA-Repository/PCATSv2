using System;
using System.Collections.Generic;
using System.Text;

namespace RSMPS
{
    public class COBudgetWorksheet
    {
        private int miID;
        private int miBudgetID;
        private int miDeptGroup;
        private string msWorkGuid;
        private string msWBS;
        private string msItemDescription;
        private int miQuantity;
        private int miSpec211;
        private int miSpec212;
        private int miSpec213;
        private int miSpec214;
        private int miSpec215;
        private int miProc221;
        private int miProc222;
        private int miProc223;
        private int miProc224;
        private int miProc225;
        private int miProc226;
        private int miProc227;
        private int miProc229;

        #region Properties

        public int ID
        {
            get { return miID; }
            set { miID = value; }
        }

        public int BudgetID
        {
            get { return miBudgetID; }
            set { miBudgetID = value; }
        }

        public int DeptGroup
        {
            get { return miDeptGroup; }
            set { miDeptGroup = value; }
        }

        public string WorkGuid
        {
            get { return msWorkGuid; }
            set { msWorkGuid = value; }
        }

        public string WBS
        {
            get { return msWBS; }
            set { msWBS = value; }
        }

        public string ItemDescription
        {
            get { return msItemDescription; }
            set { msItemDescription = value; }
        }

        public int Quantity
        {
            get { return miQuantity; }
            set { miQuantity = value; }
        }

        public int Spec211
        {
            get { return miSpec211; }
            set { miSpec211 = value; }
        }

        public int Spec212
        {
            get { return miSpec212; }
            set { miSpec212 = value; }
        }

        public int Spec213
        {
            get { return miSpec213; }
            set { miSpec213 = value; }
        }

        public int Spec214
        {
            get { return miSpec214; }
            set { miSpec214 = value; }
        }

        public int Spec215
        {
            get { return miSpec215; }
            set { miSpec215 = value; }
        }

        public int Proc221
        {
            get { return miProc221; }
            set { miProc221 = value; }
        }

        public int Proc222
        {
            get { return miProc222; }
            set { miProc222 = value; }
        }

        public int Proc223
        {
            get { return miProc223; }
            set { miProc223 = value; }
        }

        public int Proc224
        {
            get { return miProc224; }
            set { miProc224 = value; }
        }

        public int Proc225
        {
            get { return miProc225; }
            set { miProc225 = value; }
        }

        public int Proc226
        {
            get { return miProc226; }
            set { miProc226 = value; }
        }

        public int Proc227
        {
            get { return miProc227; }
            set { miProc227 = value; }
        }

        public int Proc229
        {
            get { return miProc229; }
            set { miProc229 = value; }
        }

        #endregion

        public virtual void Clear()
        {
            miID = 0;
            miBudgetID = 0;
            miDeptGroup = 0;
            msWorkGuid = "";
            msWBS = "";
            msItemDescription = "";
            miQuantity = 0;
            miSpec211 = 0;
            miSpec212 = 0;
            miSpec213 = 0;
            miSpec214 = 0;
            miSpec215 = 0;
            miProc221 = 0;
            miProc222 = 0;
            miProc223 = 0;
            miProc224 = 0;
            miProc225 = 0;
            miProc226 = 0;
            miProc227 = 0;
            miProc229 = 0;
        }

        public void Copy(COBudgetWorksheet oNew)
        {
            oNew.ID = miID;
            oNew.BudgetID = miBudgetID;
            oNew.DeptGroup = miDeptGroup;
            oNew.WorkGuid = msWorkGuid;
            oNew.WBS = msWBS;
            oNew.ItemDescription = msItemDescription;
            oNew.Quantity = miQuantity;
            oNew.Spec211 = miSpec211;
            oNew.Spec212 = miSpec212;
            oNew.Spec213 = miSpec213;
            oNew.Spec214 = miSpec214;
            oNew.Spec215 = miSpec215;
            oNew.Proc221 = miProc221;
            oNew.Proc222 = miProc222;
            oNew.Proc223 = miProc223;
            oNew.Proc224 = miProc224;
            oNew.Proc225 = miProc225;
            oNew.Proc226 = miProc226;
            oNew.Proc227 = miProc227;
            oNew.Proc229 = miProc229;
        }

        public void LoadFromObj(COBudgetWorksheet oOrg)
        {
            miID = oOrg.ID;
            miBudgetID = oOrg.BudgetID;
            miDeptGroup = oOrg.DeptGroup;
            msWorkGuid = oOrg.WorkGuid;
            msWBS = oOrg.WBS;
            msItemDescription = oOrg.ItemDescription;
            miQuantity = oOrg.Quantity;
            miSpec211 = oOrg.Spec211;
            miSpec212 = oOrg.Spec212;
            miSpec213 = oOrg.Spec213;
            miSpec214 = oOrg.Spec214;
            miSpec215 = oOrg.Spec215;
            miProc221 = oOrg.Proc221;
            miProc222 = oOrg.Proc222;
            miProc223 = oOrg.Proc223;
            miProc224 = oOrg.Proc224;
            miProc225 = oOrg.Proc225;
            miProc226 = oOrg.Proc226;
            miProc227 = oOrg.Proc227;
            miProc229 = oOrg.Proc229;
        }
    }
}
