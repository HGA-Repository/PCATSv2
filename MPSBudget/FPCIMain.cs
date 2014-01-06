using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FPCIMain : Form
    {
        public event RevSol.ItemValueChangedHandler OnPCIChanged;

        private CBPCIInfo moPci;
        private int miDiscipline = 0;
        private int miProject = 0;

        private bool mbNewPCNNeeded = false;

        public void SetPCI(int pciID)
        {
            moPci = new CBPCIInfo();

            moPci.Load(pciID);
            LoadObjectToScreen();

            tlbbSave.Enabled = false;
        }

        public FPCIMain()
        {
            InitializeComponent();
        }

        public FPCIMain(int deptID, int projID)
        {
            InitializeComponent();

            miDiscipline = deptID;
            miProject = projID;

            ClearForm(false);
        }

        public void ClearForm(bool forceClear)
        {
            if (moPci != null && forceClear == false)
            {
                return;
            }

            moPci = new CBPCIInfo();

            txtDiscipline.Text = "";
            lblPCINumber.Text = CBPCIInfo.GetNextPCINumber(miDiscipline, miProject);
            txtInitiatedBy.Text = "";
            lblProjectNumber.Text = "";
            lblProjectTitle.Text = "";
            txtPCITitle.Text = "";
            dtpDateInitiated.Value = DateTime.Now;
            txtRequestedBy.Text = "";
            dtpDateRequested.Value = DateTime.Now;
            txtDescription.Text = "";
            rdoDesignError.Checked = false;
            rdoVendorError.Checked = false;
            rdoEstimatingError.Checked = false;
            rdoContractorError.Checked = false;
            rdoScheduleDelay.Checked = false;
            rdoScopeAddition.Checked = false;
            rdoScopeDeletion.Checked = false;
            rdoDesignChange.Checked = false;
            rdoOther.Checked = false;
            txtOtherReason.Text = "";
            txtOtherReason.Enabled = false;
            chkMechPiping.Checked = false;
            chkCSA.Checked = false;
            chkProjAdmin.Checked = false;
            chkProcess.Checked = false;
            chkElectInst.Checked = false;
            txtEstimatedHrs.Text = "";
            txtEstimatedCost.Text = "";
            txtEstimatedTIC.Text = "";
            txtEstimatedAccuracy.Text = "";
            
            txtScheduleImpact.Text = "";
            chkAppvProceed.Checked = false;
            chkAppvTrack.Checked = false;
            chkNotAppvDNP.Checked = false;
            txtProjMngr.Text = "";
            lblDateApproved.Text = "";

            if (miDiscipline != 0)
            {
                CBDepartment dept = new CBDepartment();

                dept.Load(miDiscipline);
                txtDiscipline.Text = dept.Name;
                moPci.DepartmentID = miDiscipline;
            }

            if (miProject != 0)
            {
                CBProject proj = new CBProject();
                CBEmployee emp = new CBEmployee();

                proj.Load(miProject);
                emp.Load(proj.ProjMngrID);

                lblProjectNumber.Text = proj.Number;
                lblProjectTitle.Text = proj.Description;
                txtProjMngr.Text = emp.Name;

                moPci.ProjectID = miProject;
                moPci.ProjectManagerID = proj.ProjMngrID;
            }

            mbNewPCNNeeded = false;
        }

        private void tlbbExit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void FPCIMain_Load(object sender, EventArgs e)
        {
            ClearForm(false);
        }

        private void bttDiscipline_Click(object sender, EventArgs e)
        {
            FDepartmentListForPCN dl = new FDepartmentListForPCN();

            dl.OnDeptSelected += new RevSol.ItemSelectedHandler(dl_OnDeptSelected);
            dl.LoadForDepartmentList();
            dl.ShowDialog();
        }

        void dl_OnDeptSelected(int itmID)
        {
            CBDepartment dept = new CBDepartment();

            dept.Load(itmID);

            //txtDiscipline.Text = dept.Number.ToString();
            txtDiscipline.Text = dept.Name;
            txtDiscipline.Tag = dept.ID;
            moPci.DepartmentID = itmID;

            EnablePCISave();
        }

        private void bttInitiatedBy_Click(object sender, EventArgs e)
        {
            FBudEmp_List el = new FBudEmp_List();

            el.IsSelectOnly = true;
            el.OnItemSelected += new RSLib.ListItemAction(el_OnItemSelected);
            el.ShowDialog();
        }

        void el_OnItemSelected(int itmID)
        {
            CBEmployee emp = new CBEmployee();

            emp.Load(itmID);

            txtInitiatedBy.Text = emp.Name;
            txtInitiatedBy.Tag = emp.ID;
            moPci.InitiatedByID = itmID;

            EnablePCISave();
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            txtOtherReason.Enabled = rdoOther.Checked;

            EnablePCISave();
        }

        private void tlbbLockUnlock_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            if (tlbbLockUnlock.Text == "Locked")
            {
                tlbbLockUnlock.Text = "Unlocked";

                moPci.IsLocked = false;
                CBPCIInfo.SetLockOnPCI(moPci.ID, false);
                SetLockedState(true);
            }
            else
            {
                if (tlbbSave.Enabled == true)
                {
                    MessageBox.Show("Please save PCI before locking", "Unsaved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tlbbLockUnlock.Text = "Locked";

                    moPci.IsLocked = true;
                    CBPCIInfo.SetLockOnPCI(moPci.ID, true);
                    SetLockedState(false);
                }
            }
        }

        private void tlbbNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            ClearForm(true);
        }

        private void LoadScreenToObject()
        {
            moPci.PCINumber = lblPCINumber.Text;
            moPci.PCITitle = txtPCITitle.Text;
            moPci.DateInitiated = dtpDateInitiated.Value;
            moPci.RequestedBy = txtRequestedBy.Text;
            moPci.DateRequested = dtpDateRequested.Value;
            moPci.DescOfChange = txtDescription.Text;
            moPci.ReasonDesignError = rdoDesignError.Checked;
            moPci.ReasonVendorError = rdoVendorError.Checked;
            moPci.ReasonEstimatingError = rdoEstimatingError.Checked;
            moPci.ReasonContractorError = rdoContractorError.Checked;
            moPci.ReasonSchedule = rdoScheduleDelay.Checked;
            moPci.ReasonScopeAdd = rdoScopeAddition.Checked;
            moPci.ReasonScopeDel = rdoScopeDeletion.Checked;
            moPci.ReasonDesignChange = rdoDesignChange.Checked;
            moPci.ReasonOther = rdoOther.Checked;
            moPci.OtherReasonDesc = txtOtherReason.Text;
            moPci.AffectedMechPipe = chkMechPiping.Checked;
            moPci.AffectedCSA = chkCSA.Checked;
            moPci.AffectedProjAdmin = chkProjAdmin.Checked;
            moPci.AffectedProcess = chkProcess.Checked;
            moPci.AffectedEandI = chkElectInst.Checked;
            moPci.EstimatedEngrHrs = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(txtEstimatedHrs.Text));
            moPci.EstimatedEngrDlrs = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(txtEstimatedCost.Text));
            moPci.EstimatedEngrTIC = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(txtEstimatedTIC.Text));
            moPci.EstimatedAccuracy = txtEstimatedAccuracy.Text;
            moPci.ScheduleImpact = txtScheduleImpact.Text;
            moPci.ApprovedProceed = chkAppvProceed.Checked;
            moPci.ApprovedTrack = chkAppvTrack.Checked;
            moPci.ApprovedNot = chkNotAppvDNP.Checked;

            moPci.DateApproved = GetApprovedDate();

            moPci.Comments = "";
        }

        private DateTime GetApprovedDate()
        {
            DateTime retVal;

            if (chkAppvProceed.Checked == true)
            {
                retVal = Convert.ToDateTime(lblDateApproved.Text);
            }
            else if (chkAppvTrack.Checked == true)
            {
                retVal = Convert.ToDateTime(lblDateApproved.Text);
            }
            else if (chkNotAppvDNP.Checked == true)
            {
                retVal = Convert.ToDateTime(lblDateApproved.Text);
            }
            else
            {
                retVal = RevSol.RSUtility.DefaultDate();
            }

            return retVal;
        }

        private void LoadObjectToScreen()
        {
            CBDepartment dept = new CBDepartment();
            CBEmployee emp = new CBEmployee();
            CBProject proj = new CBProject();

            dept.Load(moPci.DepartmentID);
            emp.Load(moPci.InitiatedByID);
            proj.Load(moPci.ProjectID);

            txtDiscipline.Text = dept.Name;
            lblPCINumber.Text = moPci.PCINumber;
            txtPCITitle.Text = moPci.PCITitle;
            txtInitiatedBy.Text = emp.Name;
            dtpDateInitiated.Value = moPci.DateInitiated;
            lblProjectNumber.Text = proj.Number;
            lblProjectTitle.Text = proj.Description;
            txtRequestedBy.Text = moPci.RequestedBy;
            dtpDateRequested.Value = moPci.DateRequested;
            txtDescription.Text = moPci.DescOfChange;
            rdoDesignError.Checked = moPci.ReasonDesignError;
            rdoVendorError.Checked = moPci.ReasonVendorError;
            rdoEstimatingError.Checked = moPci.ReasonEstimatingError;
            rdoContractorError.Checked = moPci.ReasonContractorError;
            rdoScheduleDelay.Checked = moPci.ReasonSchedule;
            rdoScopeAddition.Checked = moPci.ReasonScopeAdd;
            rdoScopeDeletion.Checked = moPci.ReasonScopeDel;
            rdoDesignChange.Checked = moPci.ReasonDesignChange;
            rdoOther.Checked = moPci.ReasonOther;
            txtOtherReason.Text = moPci.OtherReasonDesc;
            chkMechPiping.Checked = moPci.AffectedMechPipe;
            chkCSA.Checked = moPci.AffectedCSA;
            chkProjAdmin.Checked = moPci.AffectedProjAdmin;
            chkProcess.Checked = moPci.AffectedProcess;
            chkElectInst.Checked = moPci.AffectedEandI;
            txtEstimatedHrs.Text = moPci.EstimatedEngrHrs.ToString();
            txtEstimatedCost.Text = moPci.EstimatedEngrDlrs.ToString("#,##0");
            txtEstimatedTIC.Text = moPci.EstimatedEngrTIC.ToString("#,##0");
            txtEstimatedAccuracy.Text = moPci.EstimatedAccuracy;

            txtScheduleImpact.Text = moPci.ScheduleImpact;
            chkAppvProceed.Checked = moPci.ApprovedProceed;
            chkAppvTrack.Checked = moPci.ApprovedTrack;
            chkNotAppvDNP.Checked = moPci.ApprovedNot;

            emp.Load(moPci.ProjectManagerID);
            txtProjMngr.Text = emp.Name;

            if (moPci.DateApproved == RevSol.RSUtility.DefaultDate())
                lblDateApproved.Text = "";
            else
               lblDateApproved.Text = moPci.DateApproved.ToShortDateString();

            mbNewPCNNeeded = false;
        }

        private void tlbbSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            if (IsValidPCI() == true)
            {
                LoadScreenToObject();

                moPci.Save();

                tlbbSave.Enabled = false;

                if (mbNewPCNNeeded == true)
                {
                    string msg = "Do you wish to create a PCN for this PCI?";

                    if (MessageBox.Show(msg, "New PCN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CBPCIInfo.CreatePCNFromPCI(moPci.ProjectID, moPci.ID);
                    }
                }

                if (OnPCIChanged != null)
                    OnPCIChanged(moPci.ID, "Saved");
            }
        }

        private bool IsValidPCI()
        {
            return true;
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            if (IsValidPCI() == true)
            {
                CPBudget pbud = new CPBudget();

                LoadScreenToObject();

                moPci.Save();

                tlbbSave.Enabled = false;

                pbud.PreviewPCI(moPci.ID);

                if (OnPCIChanged != null)
                    OnPCIChanged(moPci.ID, "Printed");
            }
        }

        private void chkAppvProceed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAppvProceed.Checked == true)
            {
                chkAppvTrack.Checked = false;
                chkNotAppvDNP.Checked = false;

                lblDateApproved.Text = DateTime.Now.ToShortDateString();

                mbNewPCNNeeded = true;
                tlbbSave.Enabled = true;
            }
        }

        private void chkAppvTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAppvTrack.Checked == true)
            {
                chkAppvProceed.Checked = false;
                chkNotAppvDNP.Checked = false;

                lblDateApproved.Text = DateTime.Now.ToShortDateString();

                mbNewPCNNeeded = true;
                tlbbSave.Enabled = true;
            }
        }

        private void chkNotAppvDNP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotAppvDNP.Checked == true)
            {
                chkAppvProceed.Checked = false;
                chkAppvTrack.Checked = false;

                lblDateApproved.Text = DateTime.Now.ToShortDateString();
                tlbbSave.Enabled = true;
            }
        }

        private void SetLockedState(bool lockState)
        {
            txtDiscipline.Enabled = lockState;
            bttDiscipline.Enabled = lockState;
            txtPCITitle.Enabled = lockState;
            txtInitiatedBy.Enabled = lockState;
            bttInitiatedBy.Enabled = lockState;
            dtpDateInitiated.Enabled = lockState;
            txtRequestedBy.Enabled = lockState;
            dtpDateRequested.Enabled = lockState;
            txtDescription.Enabled = lockState;
            rdoDesignError.Enabled = lockState;
            rdoVendorError.Enabled = lockState;
            rdoEstimatingError.Enabled = lockState;
            rdoContractorError.Enabled = lockState;
            rdoScheduleDelay.Enabled = lockState;
            rdoScopeAddition.Enabled = lockState;
            rdoScopeDeletion.Enabled = lockState;
            rdoDesignChange.Enabled = lockState;
            rdoOther.Enabled = lockState;
            txtOtherReason.Enabled = lockState;
            chkMechPiping.Enabled = lockState;
            chkCSA.Enabled = lockState;
            chkProjAdmin.Enabled = lockState;
            chkProcess.Enabled = lockState;
            chkElectInst.Enabled = lockState;
            txtEstimatedHrs.Enabled = lockState;
            txtEstimatedCost.Enabled = lockState;
            txtEstimatedTIC.Enabled = lockState;
            txtEstimatedAccuracy.Enabled = lockState;
            txtScheduleImpact.Enabled = lockState;
            chkAppvProceed.Enabled = lockState;
            chkAppvTrack.Enabled = lockState;
            chkNotAppvDNP.Enabled = lockState;
            txtProjMngr.Enabled = lockState;
        }

        private void EnablePCISave()
        {
            tlbbSave.Enabled = true;
        }

        private void txtPCITitle_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void dtpDateInitiated_ValueChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtRequestedBy_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void dtpDateRequested_ValueChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoDesignError_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoVendorError_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoEstimatingError_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoContractorError_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoScheduleDelay_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoScopeAddDelete_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoDesignChange_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtOtherReason_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void chkMechPiping_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void chkCSA_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void chkProjAdmin_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void chkProcess_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void chkElectInst_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtOtherAffected_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtEstimatedHrs_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtEstimatedDollars_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtEstEngrTIC_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtScheduleImpact_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtProjMngr_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void rdoScopeDeletion_CheckedChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void txtEstimatedCost_TextChanged(object sender, EventArgs e)
        {
            EnablePCISave();
        }

        private void FPCIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
