using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtPCIInformation.
    /// </summary>
    public partial class rprtPCIInformation : DataDynamics.ActiveReports.ActiveReport3
    {

        public rprtPCIInformation()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public void SetInformation(CBPCIInfo info)
        {
            CBDepartment dept;
            CBProject proj;
            CBEmployee emp;
            CBCustomer cust;

            dept = new CBDepartment();
            proj = new CBProject();
            emp = new CBEmployee();
            cust = new CBCustomer();

            dept.Load(info.DepartmentID);
            emp.Load(info.InitiatedByID);
            proj.Load(info.ProjectID);
            cust.Load(proj.CustomerID);

            txtDiscipline.Text = dept.Number.ToString();
            txtPCINumber.Text = info.PCINumber;
            txtInitiatedBy.Text = emp.Name;
            txtHGAProject.Text = proj.Number;
            txtProjectTitle.Text = proj.Description;
            txtClientNumber.Text = proj.CustomerProjNumber;
            txtClient.Text = cust.Name;
            txtPCITitle.Text = info.PCITitle;
            txtDateInitiated.Text = info.DateInitiated.ToShortDateString();
            txtChangeRequestedBy.Text = info.RequestedBy;
            txtDateChangeRequested.Text = info.DateRequested.ToShortDateString();
            txtDescOfChange.Text = info.DescOfChange;
            chkDesignError.Checked = info.ReasonDesignError;
            chkVendorError.Checked = info.ReasonVendorError;
            chkEstimError.Checked = info.ReasonEstimatingError;
            chkContrError.Checked = info.ReasonContractorError;
            chkSchedDelay.Checked = info.ReasonSchedule;
            chkScopeAdd.Checked = info.ReasonScopeAdd;
            chkScopeDel.Checked = info.ReasonScopeDel;
            chkDesignChange.Checked = info.ReasonDesignChange;
            chkReasonOther.Checked = info.ReasonOther;
            txtReasonOther.Text = info.OtherReasonDesc;
            chkMechPiping.Checked = info.AffectedMechPipe;
            chkCSA.Checked = info.AffectedCSA;
            chkProjAdmin.Checked = info.AffectedProjAdmin;
            chkProcess.Checked = info.AffectedProcess;
            chkElectInst.Checked = info.AffectedEandI;
            txtEngrHrs.Text = info.EstimatedEngrHrs.ToString();
            txtEngrCost.Text = info.EstimatedEngrDlrs.ToString("#,##0");
            txtEngrTIC.Text = info.EstimatedEngrTIC.ToString("#,##0");
            txtEngAcc.Text = info.EstimatedAccuracy;
            txtScheduleImpact.Text = info.ScheduleImpact;
            chkApprovedProceed.Checked = info.ApprovedProceed;
            chkApprovedTrack.Checked = info.ApprovedTrack;
            chkNotApproved.Checked = info.ApprovedNot;
        }

        private void rprtPCIInformation_ReportStart(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
