using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using System.Threading;
using Common.Extentions;
using System.Linq;
using System.Resources;
using System.Reflection;



namespace RSMPS
{
    public partial class FBudgetPCNAddition : Form
    {
        private CBProject moProj;
        private CBBudget moBudg;
        private CBBudgetPCN moPCN;
        private dsAccts mdsAccnts;
        private dsAccts mdsExpensAccts;
        private dsAccts mdsDeptGroup;   //********************Added 9/23/2015
       // public int projID;

        public int project_ID; //************************For PCN Update Code Validation

        //private CBBudget moCurrBudget; added 6/3/15 ***************Commented
       
        public event RevSol.ItemValueChangedHandler OnPCNChanged;

        public void StartNewPCN(int projID)
        {
            ClearForm();

            moProj = new CBProject();
            moProj.Load(projID);
            moPCN.PCNNumber = moPCN.GetNextPCNNumber(projID);
            moPCN.ProjectID = projID;

            lblProjectNumber.Text = moProj.Number;
            lblProjectTitle.Text = moProj.Description;
            txtPCNNumber.Text = moPCN.PCNNumber;

            this.Text = "PCN: Job-" + moProj.Number + " PCN-" + moPCN.PCNNumber;

            project_ID = moPCN.ProjectID;
            List<CBActivityCodeDisc> _Groups = CBActivityCodeDisc.GetAllForProject(project_ID).ToList();
            foreach (var group in _Groups)
            {
                codes[i] = group.Code;
               // MessageBox.Show(_Groups.Count() + " " + i + " " + codes[i]);
                i++;

            }
            SetPCNSecurityLevel();
        }
        public void CopyPCN(int projID, int pcnID)
        {
            ClearForm();

            moProj = new CBProject();
            moBudg = new CBBudget();

            moPCN.LoadWithCopyData(pcnID);
          
            moProj.Load(moPCN.ProjectID);
            moBudg.LoadByProject(moProj.ID);

            LoadFromPCN();

            this.Text = "PCN: Job-" + moProj.Number + " PCN-" + moPCN.PCNNumber;
           
            moProj.Load(projID);
            moPCN.PCNNumber = moPCN.GetNextPCNNumber(projID);
            moPCN.ProjectID = projID;

            lblProjectNumber.Text = moProj.Number;
            lblProjectTitle.Text = moProj.Description;
            txtPCNNumber.Text = moPCN.PCNNumber;
            this.Text = "PCN: Job-" + moProj.Number + " PCN-" + moPCN.PCNNumber;
            project_ID = moPCN.ProjectID;
            List<CBActivityCodeDisc> _Groups = CBActivityCodeDisc.GetAllForProject(project_ID).ToList();
            foreach (var group in _Groups)
            {
                codes[i] = group.Code;
              //  MessageBox.Show(_Groups.Count() + " " + i + " " + codes[i]);
                i++;

            }

            SetPCNSecurityLevel();
            
            
        }
        public void EditPreviousPCN(int pcnID)
        {
            ClearForm();

            moProj = new CBProject();
            moBudg = new CBBudget();

            moPCN.LoadWithData(pcnID);
            moProj.Load(moPCN.ProjectID);
            project_ID = moPCN.ProjectID;
           
                //List<CBActivityCodeDisc> _Groups = CBActivityCodeDisc.GetAllForProject(projID).ToList();
                List<CBActivityCodeDisc> _Groups = CBActivityCodeDisc.GetAllForProject(project_ID).ToList();

                foreach (var group in _Groups)
                {
                    codes[i]=group.Code;
                    //MessageBox.Show(_Groups.Count() + " " + i + " " +codes[i]);
                    i++;

                }
          
                     
            moBudg.LoadByProject(moProj.ID);

            LoadFromPCN();

            this.Text = "PCN: Job-" + moProj.Number + " PCN-" + moPCN.PCNNumber;

            SetPCNSecurityLevel();
        }

        string[] codes = new string[13]; // Added 9/9/2015, to store Codes. The Array size needs to be increased if, no of Codes ever increases.
        public List<CBActivityCodeDisc> _Groups = null;
        int i = 0;

        public FBudgetPCNAddition()
        {
            InitializeComponent();
        }
     
	 
        public void ViewForm() //*******************Added 5/28
        {
            moPCN = new CBBudgetPCN();
            //moPCN.Clear();

            txtInitiatedBy.Enabled = false;
            lblProjectNumber.Enabled = false;
            lblProjectTitle.Enabled = false;
            txtPCNTitle.Enabled = false;

            dtpDateInitiated.Enabled = false;
            txtRequestedBy.Enabled = false;
            dtpDateRequested.Enabled = false;
            txtDescription.Enabled = false;
            chkDesignError.Enabled = false;
            chkVendorError.Enabled = false;
            chkEstimatingError.Enabled = false;
            chkContractorError.Enabled = false;
            chkScheduleDelay.Enabled = false;
            chkScopeAdd.Enabled = false;
            chkScopeDel.Enabled = false;
            chkDesignChange.Enabled = false;
            chkOther.Enabled = false;
            txtOtherReason.Enabled = false;
            txtOtherReason.Enabled = false;
            txtEstimatedHrs.Enabled = false;
            txtEstimatedDollars.Enabled = false;
            txtEstimTIC.Enabled = false;
            txtEstimateAccuracy.Enabled = false;
            txtScheduleImpact.Enabled = false;
            chkApproved.Enabled = false;
            chkDisapproved.Enabled = false;
            chkPrepareControlEstimate.Enabled = false;
            txtProjMngr.Enabled = false;
            lblDateApproved.Enabled = false;
            txtPCNNumber.Enabled = false;
            tdbgHours.Enabled = false;
            tdbgExpenses.Enabled = false;
            rtbComments.Enabled = false;
            //c1CommandLink1.Enabled = false;
            tlbbClear.Enabled = false;
            tlbbSave.Enabled = false;
                    }



        public void ClearForm()
        { //  moProj = new CBProject();
        //MessageBox.Show("Clear started &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&" + moProj.ID.ToString());
            moPCN = new CBBudgetPCN();
            moPCN.Clear();

            txtInitiatedBy.Text = "";
            lblProjectNumber.Text = "";
            lblProjectTitle.Text = "";
            txtPCNTitle.Text = "";
            dtpDateInitiated.Value = DateTime.Now;
            txtRequestedBy.Text = "";
            dtpDateRequested.Value = DateTime.Now;
            txtDescription.Text = "";
            chkDesignError.Checked = false;
            chkVendorError.Checked = false;
            chkEstimatingError.Checked = false;
            chkContractorError.Checked = false;
            chkScheduleDelay.Checked = false;
            chkScopeAdd.Checked = false;
            chkScopeDel.Checked = false;
            chkDesignChange.Checked = false;
            chkOther.Checked = false;
            txtOtherReason.Text = "";
            txtOtherReason.Enabled = false;
            txtEstimatedHrs.Text = "";
            txtEstimatedDollars.Text = "";
            txtEstimTIC.Text = "";
            txtEstimateAccuracy.Text = "";
            txtScheduleImpact.Text = "";
            chkApproved.Checked = false;
            chkDisapproved.Checked = false;
            chkPrepareControlEstimate.Checked = false;
            txtProjMngr.Text = "";
            lblDateApproved.Text = "";
            txtPCNNumber.Text  =  "";

            tdbgHours.SetDataBinding(moPCN.PCNData, "PCNHours", true);
            tdbgExpenses.SetDataBinding(moPCN.PCNData, "PCNExpenses", true);

            SqlDataReader dr = CBActivityCode.GetListForBudget();
            DataRow d;
            mdsAccnts = new dsAccts();
            mdsExpensAccts = new dsAccts();
            mdsDeptGroup = new dsAccts();
            while (dr.Read())
            {
                d = mdsAccnts.Tables["Accounts"].NewRow();
                d["Code"] = dr["Code"];
                d["Description"] = dr["Description"];
                mdsAccnts.Tables["Accounts"].Rows.Add(d);
            }

            dr.Close();

            tdbdActivities.SetDataBinding(mdsAccnts, "Accounts", true);

            dr = CBProjectBudget.GetExpenseGroupByDiscipline(0);

            while (dr.Read())
            {
                d = mdsExpensAccts.Tables["Accounts"].NewRow();
                d["Code"] = dr["Code"];
                d["Description"] = dr["Description"];
                d["DefaultMU"] = dr["DefaultMU"];

                mdsExpensAccts.Tables["Accounts"].Rows.Add(d);
            }
            dr.Close();
            tdbdExpenseAccts.SetDataBinding(mdsExpensAccts, "Accounts", true);
            //****************************************************************************************************************

            dr = CBActivityCode.GetDeptGroup();

            while (dr.Read())
            {
                //  d = mdsDeptGroup.Tables["DepartmentGroup"].NewRow();
                d = mdsDeptGroup.Tables["Accounts"].NewRow();
                d["Code"] = dr["Code"];
                d["Description"] = dr["Description"];
                //d["DefaultMU"] = dr["DefaultMU"];

                mdsDeptGroup.Tables["Accounts"].Rows.Add(d);
            }
            dr.Close();
            tdbdDeptGroup.SetDataBinding(mdsDeptGroup, "Accounts", true);

            //*******************************************************************************************************************
        }   
        private void SetPCNSecurityLevel()
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true || u.IsEngineerAdmin == true)
                //if (u.IsAdministrator == true || u.IsEngineerAdmin == true || u.IsManager == true)
            {
            }
            else
            {
                tlbbPrint.Enabled = false;

                label10.Visible = false;
                txtEstimatedHrs.Visible = false;
                label15.Visible = false;
                txtEstimatedDollars.Visible = false;
                label2.Visible = false;
                txtEstimTIC.Visible = false;
                label1.Visible = false;
                txtEstimateAccuracy.Visible = false;

                tdbgHours.Splits[0].DisplayColumns[5].Visible = false;
                tdbgHours.Splits[0].DisplayColumns[7].Visible = false;
                /*
                tdbgExpenses.Splits[0].DisplayColumns[2].Visible = false;
                tdbgExpenses.Splits[0].DisplayColumns[4].Visible = false;
                tdbgExpenses.Splits[0].DisplayColumns[5].Visible = false;
                tdbgExpenses.Splits[0].DisplayColumns[6].Visible = false;
                */
            }
        }

        private void tlbbClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void tlbbClear_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            txtInitiatedBy.Text = "";
            lblProjectNumber.Text = "";
            lblProjectTitle.Text = "";
            txtPCNTitle.Text = "";
            dtpDateInitiated.Value = DateTime.Now;
            txtRequestedBy.Text = "";
            dtpDateRequested.Value = DateTime.Now;
            txtDescription.Text = "";
            chkDesignError.Checked = false;
            chkVendorError.Checked = false;
            chkEstimatingError.Checked = false;
            chkContractorError.Checked = false;
            chkScheduleDelay.Checked = false;
            chkScopeAdd.Checked = false;
            chkScopeDel.Checked = false;
            chkDesignChange.Checked = false;
            chkOther.Checked = false;
            txtOtherReason.Text = "";
            txtOtherReason.Enabled = false;
            txtEstimatedHrs.Text = "";
            txtEstimatedDollars.Text = "";
            txtEstimTIC.Text = "";
            txtEstimateAccuracy.Text = "";
            txtScheduleImpact.Text = "";
            chkApproved.Checked = false;
            chkDisapproved.Checked = false;
            chkPrepareControlEstimate.Checked = false;
            txtProjMngr.Text = "";
            lblDateApproved.Text = "";

            moPCN.PCNData.PCNHours.Clear();
            moPCN.PCNData.PCNExpenses.Clear();
        }

        private void tdbgHours_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (e.ColIndex != 0)
                return;

            string acct = tdbgHours.Columns[0].Value.ToString();
            string desc = IsValidAccount(acct);

            if (desc.Length < 1)
                e.Cancel = true;
            else
                tdbgHours.Columns[1].Value = desc;
        }

        private void tdbgHours_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            if (e.ColIndex < 3 || e.ColIndex > 5)
                return;


            if (tdbgHours.Columns[2].Text == "")      //**************6/11/15*************MZ
            {
                MessageBox.Show("Item Qty Field cannot be Empty");
                return;
            }

            if (tdbgHours.Columns[3].Text == "")      //**************6/11/15*************MZ
            {
                MessageBox.Show("Hours/Item Field cannot be Empty");
                return;
            }

            if (tdbgHours.Columns[4].Text == "")      //**************6/11/15*************MZ
            {
                MessageBox.Show("Rate Field cannot be Empty");
                return;
            }
            decimal quantity, hrsPer, rate;

            quantity = RevSol.RSMath.IsDecimalEx(tdbgHours.Columns[2].Value);
            hrsPer = RevSol.RSMath.IsDecimalEx(tdbgHours.Columns[3].Value);
            rate = RevSol.RSMath.IsDecimalEx(tdbgHours.Columns[4].Value);

            decimal subHrs, subDlrs;

            subHrs = quantity * hrsPer;
            subDlrs = quantity * hrsPer * rate;

            tdbgHours.Columns[5].Value = subHrs;
            tdbgHours.Columns[6].Value = subDlrs;
        }

        private void tdbgHours_AfterUpdate(object sender, EventArgs e)
        {
            //20131218 - Added Code to trap missing Activity Code which causes system crash
            string acct = tdbgHours.Columns[0].Value.ToString();

            if (acct.Length < 1)
            {
                tlbbSave.Enabled = false;
                MessageBox.Show("Input an Activity Code", "Missing Activity Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                //else
                //if (test == false)
                //{ tlbbSave.Enabled = false; }

                else   tlbbSave.Enabled = true;


            //******************** This part is probably not needed***************************************************************************



            //if (tdbgHours.Columns[2].Text == "" || tdbgHours.Columns[3].Text == "" || tdbgHours.Columns[4].Text == "")      //**************6/11/15*************MZ
            //{
            //    MessageBox.Show("Fields Cannot be Empty");
            //    return;
            //}
            TotalHoursGrid();
                          
            //tlbbSave.Enabled = true;
            
        }
        private void tdbgHours_ComboSelect(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
           // MessageBox.Show("Combo selected");

            string acct = tdbgHours.Columns[0].Value.ToString().Substring(0, 2);
            for (int j = 0; j < i; j++)
            {
                string y = codes[j].Substring(0, 2);
                
              //  MessageBox.Show(y + "         " + acct);

                if (y.Equals(acct))
                {
                    test = true;
                    break;

                }
          
            }
            MessageBox.Show(test.ToString());
            if (test == false)
            {
                
                
                int c = Convert.ToInt32(acct) * 1000;
            

               CBActivityCodeDisc.UpdateForProject(c, project_ID, true);
               mbIsCodeAdded = true;
             
                MessageBox.Show("This Expense isn't valid. Group will be Added in the budget " + c.ToString());

           //  var code_selector = new CodeGroupSelector(this.project_ID);
            // code_selector.ShowDialog();



               // this.Close();
               //tdbgExpenses.Enabled = false;
                // return;
            }
            else
            { test = false; }

        }

bool test = false; // Added 9/9 to store expense code Validating
public bool mbIsCodeAdded = false;// Added 9/21 to store, whether group is added

  /// if set to return the form will reopen when it is closed
  /// </summary>
  //public bool ReloadForm { get; private set; }
  
        private void TotalHoursGrid()
        {
            decimal hours;
            decimal dollars;

            hours = 0;
            dollars = 0;

            foreach (DataRow dr in moPCN.PCNData.PCNHours.Rows)
            {
                hours += Convert.ToDecimal(dr["SubtotalHrs"]);
                dollars += Convert.ToDecimal(dr["SubtotalDlrs"]);
            }

            tdbgHours.Columns[5].FooterText = hours.ToString("#,##0");
            tdbgHours.Columns[6].FooterText = dollars.ToString("$#,##0.00");

            txtEstimatedHrs.Text = hours.ToString("#,##0");
            txtEstimatedDollars.Text = TotalDollars().ToString("#,##0.00");
        }

        private string IsValidAccount(string acct)
        {
            string retVal = "";
            string rowVal;

            foreach (DataRow d in mdsAccnts.Tables["Accounts"].Rows)
            {
                rowVal = d["Code"].ToString();
               // MessageBox.Show(rowVal);
                if (rowVal == acct)
                {
                    retVal = d["Description"].ToString();
                    break;
                }
            }

            return retVal;
        }

        private void SaveCurrentPCN()
        {
            tdbgHours.UpdateData();
            tdbgExpenses.UpdateData();

            LoadScreenToObject();

            moPCN.SaveWithData();
        }

       public void SaveCopyPCN()
        {
            tdbgHours.UpdateData();
            tdbgExpenses.UpdateData();

            LoadScreenToObject();

            moPCN.SaveWithCopyData();
        }

        private void LoadScreenToObject()
        {
            moPCN.PCNTitle = txtPCNTitle.Text;
            moPCN.DateInitiated = dtpDateInitiated.Value;
            moPCN.RequestedBy = txtRequestedBy.Text;
            moPCN.DateRequested = dtpDateRequested.Value;
            moPCN.DescOfChange = txtDescription.Text;
            moPCN.ReasonDesignError = chkDesignError.Checked;
            moPCN.ReasonVendorError = chkVendorError.Checked;
            moPCN.ReasonEstimatingError = chkEstimatingError.Checked;
            moPCN.ReasonContractorError = chkContractorError.Checked;
            moPCN.ReasonSchedule = chkScheduleDelay.Checked;
            moPCN.ReasonScopeAdd = chkScopeAdd.Checked;
            moPCN.ReasonScopeDel = chkScopeDel.Checked;
            moPCN.ReasonDesignChange = chkDesignChange.Checked;
            moPCN.ReasonOther = chkOther.Checked;
            moPCN.OtherReasonDesc = txtOtherReason.Text;
            moPCN.EstimatedEngrHrs = RevSol.RSMath.IsIntegerEx(txtEstimatedHrs.Text);
            moPCN.EstimatedEngrDlrs = RevSol.RSMath.IsDecimalEx(txtEstimatedDollars.Text);
            moPCN.EstimatedTICDlrs = RevSol.RSMath.IsDecimalEx(txtEstimTIC.Text);
            moPCN.EstimateAccuracy = txtEstimateAccuracy.Text;
            moPCN.ScheduleImpact = txtScheduleImpact.Text;
            moPCN.IsApproved = chkApproved.Checked;
            moPCN.IsDisapproved = chkDisapproved.Checked;
            moPCN.PrepareControlEstimate = chkPrepareControlEstimate.Checked;
            moPCN.Comments = rtbComments.Rtf;
            if (moPCN.PCNNumber != null) { moPCN.PCNNumber = txtPCNNumber.Text; }
            else { moPCN.PCNNumber = moPCN.GetNextPCNNumber(moPCN.ProjectID); }
            moPCN.DateApproved = GetApprovedDate();
        }

        private DateTime GetApprovedDate()
        {
            DateTime retVal;

            if (chkApproved.Checked == true)
            {
                retVal = Convert.ToDateTime(lblDateApproved.Text);
            }
            else if (chkDisapproved.Checked == true)
            {
                retVal = Convert.ToDateTime(lblDateApproved.Text);
            }
            else if (chkPrepareControlEstimate.Checked == true)
            {
                retVal = Convert.ToDateTime(lblDateApproved.Text);
            }
            else
            {
                retVal = RevSol.RSUtility.DefaultDate();
            }

            return retVal;
        }

        private void chkAppvProceed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApproved.Checked == true)
            {
                chkDisapproved.Checked = false;
                chkPrepareControlEstimate.Checked = false;

                lblDateApproved.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void chkAppvTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisapproved.Checked == true)
            {
                chkApproved.Checked = false;
                chkPrepareControlEstimate.Checked = false;

                lblDateApproved.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void chkNotAppvDNP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrepareControlEstimate.Checked == true)
            {
                chkApproved.Checked = false;
                chkDisapproved.Checked = false;

                lblDateApproved.Text = DateTime.Now.ToShortDateString();
            }
        }

        private decimal TotalHours()
        {
            decimal hours;

            hours = 0;

            foreach (DataRow dr in moPCN.PCNData.PCNHours.Rows)
            {
                hours += Convert.ToDecimal(dr["SubtotalHrs"]);
            }

            return hours;
        }

        private decimal TotalDollars()
        {
            decimal dollars;
            decimal exps;

            dollars = 0;
            exps = 0;

            foreach (DataRow dr in moPCN.PCNData.PCNHours.Rows)
            {
                dollars += Convert.ToDecimal(dr["SubtotalDlrs"]);
            }

            foreach (DataRow dr in moPCN.PCNData.PCNExpenses.Rows)
            {
                exps += Convert.ToDecimal(dr["TotalCost"]);
                dollars += Convert.ToDecimal(dr["TotalCost"]);
            }

            return dollars;
        }

        private void tlbbSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {                      
                SaveCurrentPCN();
                //MessageBox.Show("Saved");
                tlbbSave.Enabled = false;
        }

        private void FBudgetPCNAddition_FormClosing(object sender, FormClosingEventArgs e)
        {
           // if (tlbbSave.Enabled == true)
            //    SaveCurrentPCN();
            // ********************************* Commented on 9/9/2015 to stop Saving wrong input******* MZ

            if (tlbbSave.Enabled == true)   // *********************************Added again 9/10/2015 ******* MZ
                SaveCurrentPCN();


            if (OnPCNChanged != null)
                OnPCNChanged(moPCN.ID, moPCN.PCNNumber);
        }

        private void tdbgExpenses_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (e.ColIndex != 0)
                return;

            string exps = tdbgExpenses.Columns[0].Value.ToString();
            string desc = IsValidExpense(exps);
            string mudefault = IsValidExpense1(exps);

            if (desc.Length < 1)
                e.Cancel = true;
            else
                tdbgExpenses.Columns[1].Value = desc;
                //tdbgExpenses.Columns[4].Value = mudefault;
                tdbgExpenses.Columns[5].Value = mudefault;
        }

        private void tdbgExpenses_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            //if (e.ColIndex < 2)
            //    return;

            //if (tdbgExpenses.Columns[2].Text == "")      //**************6/11/15*************MZ
            //{
            //    MessageBox.Show("Per Item Field cannot be Empty");
            //    return;
            //}

            //if (tdbgExpenses.Columns[3].Text == "")      //**************6/11/15*************MZ
            //{
            //    MessageBox.Show("#Item Field cannot be Empty");
            //    return;
            //}

            //if (tdbgExpenses.Columns[4].Text == "")      //**************6/11/15*************MZ
            //{
            //    MessageBox.Show("MarkUp Field cannot be Empty");
            //    return;
            //}



            //decimal dllrPerItem, numItems, percMU, markup, total;

            //dllrPerItem = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[2].Value);
            //numItems = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[3].Value);
            //percMU = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[4].Value);
            //markup = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[5].Value);
            //total = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[6].Value);

            //markup = dllrPerItem * numItems * (percMU / 100.0m);
            //total = (dllrPerItem * numItems) + markup;

            //tdbgExpenses.Columns[5].Value = markup;
            //tdbgExpenses.Columns[6].Value = total;

            //if (e.ColIndex < 2)
            //    return;

            //if (tdbgExpenses.Columns[2].Text == "")      //**************6/11/15*************MZ
            //{
            //    MessageBox.Show("Per Item Field cannot be Empty");
            //    return;
            //}

            //if (tdbgExpenses.Columns[3].Text == "")      //**************6/11/15*************MZ
            //{
            //    MessageBox.Show("#Item Field cannot be Empty");
            //    return;
            //}

            //if (tdbgExpenses.Columns[4].Text == "")      //**************6/11/15*************MZ
            //{
            //    MessageBox.Show("MarkUp Field cannot be Empty");
            //    return;
            //}
            //**************************************************************************************************************************************************************************
            // if (e.ColIndex < 2)
            //   return;

            if (tdbgExpenses.Columns[3].Text == "")      //**************6/11/15*************MZ
            {
                MessageBox.Show("Per Item Field cannot be Empty");
                return;
            }

            if (tdbgExpenses.Columns[4].Text == "")      //**************6/11/15*************MZ
            {
                MessageBox.Show("#Item Field cannot be Empty");
                return;
            }

            if (tdbgExpenses.Columns[5].Text == "")      //**************6/11/15*************MZ
            {
                MessageBox.Show("MarkUp Field cannot be Empty");
                return;
            }





            decimal dllrPerItem, numItems, percMU, markup, total;

            //dllrPerItem = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[2].Value);
            //numItems = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[3].Value);
            //percMU = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[4].Value);
            //markup = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[5].Value);
            //total = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[6].Value);

            //markup = dllrPerItem * numItems * (percMU / 100.0m);
            //total = (dllrPerItem * numItems) + markup;

            //tdbgExpenses.Columns[5].Value = markup;
            //tdbgExpenses.Columns[6].Value = total;

            dllrPerItem = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[3].Value);
            numItems = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[4].Value);
            percMU = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[5].Value);
            markup = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[6].Value);
            total = RevSol.RSMath.IsDecimalEx(tdbgExpenses.Columns[7].Value);

            markup = dllrPerItem * numItems * (percMU / 100.0m);
            total = (dllrPerItem * numItems) + markup;

            tdbgExpenses.Columns[6].Value = markup;
            tdbgExpenses.Columns[7].Value = total;









        }

        private void tdbgExpenses_AfterUpdate(object sender, EventArgs e)
        {
            
            TotalExpenseGrid();

            tlbbSave.Enabled = true;
        }

        private void TotalExpenseGrid()
        {
            decimal muAmnt;
            decimal dollars;

            muAmnt = 0;
            dollars = 0;

            foreach (DataRow dr in moPCN.PCNData.PCNExpenses.Rows)
            {
                muAmnt += Convert.ToDecimal(dr["MarkUp"]);
                dollars += Convert.ToDecimal(dr["TotalCost"]);
            }

            // tdbgExpenses.Columns[5].FooterText = muAmnt.ToString("$#,##0.00");
            // tdbgExpenses.Columns[6].FooterText = dollars.ToString("$#,##0.00");

            tdbgExpenses.Columns[6].FooterText = muAmnt.ToString("$#,##0.00");
        //    tdbgExpenses.Columns[7].FooterText = dollars.ToString("$#,##0.00");

            txtEstimatedDollars.Text = TotalDollars().ToString("#,##0.00");
        }

        private string IsValidExpense(string expense)
        {
            string retVal = "";
            string rowVal;

            foreach (DataRow d in mdsExpensAccts.Tables["Accounts"].Rows)
            {
                rowVal = d["Code"].ToString();

                if (rowVal == expense)
                {
                    retVal = d["Description"].ToString();
                    break;
                }
            }

            return retVal;
        }
        private string IsValidExpense1(string expense)
        {
            string retVal = "";
            string rowVal;

            foreach (DataRow d in mdsExpensAccts.Tables["Accounts"].Rows)
            {
                rowVal = d["Code"].ToString();

                if (rowVal == expense)
                {
                    retVal = d["DefaultMU"].ToString();
                    break;
                }
            }

            return retVal;
        }
        private void txtRequestedBy_TextChanged(object sender, EventArgs e)
        {
            tlbbSave.Enabled = true;
        }

        private void dtpRequestDate_ValueChanged(object sender, EventArgs e)
        {
            tlbbSave.Enabled = true;
        }

        private void LoadFromPCN()
        {
            CBEmployee emp = new CBEmployee();

            lblProjectNumber.Text = moProj.Number;
            lblProjectTitle.Text = moProj.Description;

            txtPCNTitle.Text = moPCN.PCNTitle;
            emp.Load(moPCN.InitiatedByID);
            txtInitiatedBy.Text = emp.Name;
            dtpDateInitiated.Value = moPCN.DateInitiated;
            txtRequestedBy.Text = moPCN.RequestedBy;
            dtpDateRequested.Value = moPCN.DateRequested;
            txtDescription.Text = moPCN.DescOfChange;
            chkDesignError.Checked = moPCN.ReasonDesignError;
            chkVendorError.Checked = moPCN.ReasonVendorError;
            chkEstimatingError.Checked = moPCN.ReasonEstimatingError;
            chkContractorError.Checked = moPCN.ReasonContractorError;
            chkScheduleDelay.Checked = moPCN.ReasonSchedule;
            chkScopeAdd.Checked = moPCN.ReasonScopeAdd;
            chkScopeDel.Checked = moPCN.ReasonScopeDel;
            chkDesignChange.Checked = moPCN.ReasonDesignChange;
            chkOther.Checked = moPCN.ReasonOther;
            txtOtherReason.Text = moPCN.OtherReasonDesc;
            txtEstimatedHrs.Text = moPCN.EstimatedEngrHrs.ToString();
            txtEstimatedDollars.Text = moPCN.EstimatedEngrDlrs.ToString("#,##0");
            txtEstimTIC.Text = moPCN.EstimatedTICDlrs.ToString("#,##0");
            txtEstimateAccuracy.Text = moPCN.EstimateAccuracy;
            txtScheduleImpact.Text = moPCN.ScheduleImpact;
            chkApproved.Checked = moPCN.IsApproved;
            chkDisapproved.Checked = moPCN.IsDisapproved;
            chkPrepareControlEstimate.Checked = moPCN.PrepareControlEstimate;
            if (moPCN.PCNNumber != null) { txtPCNNumber.Text = moPCN.PCNNumber; }
            else { txtPCNNumber.Text = moPCN.GetNextPCNNumber(moPCN.ProjectID); }
            

            if (moPCN.DateApproved == RevSol.RSUtility.DefaultDate())
                lblDateApproved.Text = "";
            else
                lblDateApproved.Text = moPCN.DateApproved.ToShortDateString();

            tdbgHours.SetDataBinding(moPCN.PCNData, "PCNHours", true);
            tdbgExpenses.SetDataBinding(moPCN.PCNData, "PCNExpenses", true);

            TotalHoursGrid();
            TotalExpenseGrid();

            rtbComments.Rtf = moPCN.Comments;
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            SaveCurrentPCN();

            tlbbSave.Enabled = false;


            string projNumber = moProj.Number;
            string pcnNumber = moPCN.PCNNumber;

          //  MessageBox.Show(projNumber);

            CPBudget pBud = new CPBudget();

           // pBud.PreviewPCN(moPCN.ID);

            pBud.PreviewPCN_New(projNumber,pcnNumber, moPCN.ID);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            tlbbSave.Enabled = true;
        }

        private void txtEffectSchedule_TextChanged(object sender, EventArgs e)
        {
            tlbbSave.Enabled = true;
        }

        private void txtEffectCapital_TextChanged(object sender, EventArgs e)
        {
            tlbbSave.Enabled = true;
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
            moPCN.InitiatedByID = itmID;

            SetAllowSave(true);
        }

        private void deleteLineInHours_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete the current line?", "Delete Hours", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow dr = moPCN.PCNData.PCNHours.Rows[tdbgHours.Bookmark];
                DataRow dd = moPCN.PCNData.PCNHoursDeleted.NewRow();
                dd["ID"] = dr["ID"];
                moPCN.PCNData.PCNHoursDeleted.Rows.Add(dd);

                tdbgHours.Delete();
            }
        }

        private void tdbgHours_BeforeDelete(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete the current line?", "Delete Hours", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow dr = moPCN.PCNData.PCNHours.Rows[tdbgHours.Bookmark];
                DataRow dd = moPCN.PCNData.PCNHoursDeleted.NewRow();
                dd["ID"] = dr["ID"];
                moPCN.PCNData.PCNHoursDeleted.Rows.Add(dd);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmnuHours_Opening(object sender, CancelEventArgs e)
        {
            if (tdbgHours.Bookmark < 0)
                deleteLineInHours.Enabled = false;
            else
                deleteLineInHours.Enabled = true;
        }

        private void tdbgExpenses_BeforeDelete(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete the current line?", "Delete Expenses", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow dr = moPCN.PCNData.PCNExpenses.Rows[tdbgExpenses.Bookmark];
                DataRow dd = moPCN.PCNData.PCNExpensesDeleted.NewRow();
                dd["ID"] = dr["ID"];
                moPCN.PCNData.PCNExpensesDeleted.Rows.Add(dd);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void deleteLineInExpenses_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete the current line?", "Delete Expenses", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow dr = moPCN.PCNData.PCNExpenses.Rows[tdbgExpenses.Bookmark];
                DataRow dd = moPCN.PCNData.PCNExpensesDeleted.NewRow();
                dd["ID"] = dr["ID"];
                moPCN.PCNData.PCNExpensesDeleted.Rows.Add(dd);

                tdbgExpenses.Delete();
            }
        }

        private void cmnuExpenses_Opening(object sender, CancelEventArgs e)
        {
            if (tdbgExpenses.Bookmark < 0)
                deleteLineInExpenses.Enabled = false;
            else
                deleteLineInExpenses.Enabled = true;
        }

        private void SetAllowSave(bool saveState)
        {
            tlbbSave.Enabled = saveState;
        }

        private void dtpDateInitiated_ValueChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void txtRequestedBy_TextChanged_1(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void dtpDateRequested_ValueChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void txtPCNTitle_TextChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void txtDescription_TextChanged_1(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void txtEstimTIC_TextChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void txtEstimateAccuracy_TextChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void txtScheduleImpact_TextChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoDesignError_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoVendorError_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoEstimatingError_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoContractorError_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoScheduleDelay_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoScopeAdd_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoScopeDel_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoDesignChange_CheckedChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOther.Checked == true)
            {
                txtOtherReason.Enabled = true;
            }
            else
            {
                txtOtherReason.Enabled = false;
                txtOtherReason.Text = "";
            }

            SetAllowSave(true);
        }

        private void txtOtherReason_TextChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void rtbComments_TextChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }

        private void tdbgHours_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tdbgHours.UpdateData();
            }
        }

        private void tdbgExpenses_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tdbgExpenses.UpdateData();
            }
        }

        private void txtPCNNumber_TextChanged(object sender, EventArgs e)
        {
            SetAllowSave(true);
        }


        private void tlbbHourExport_Click(object sender, C1.Win.C1Command.ClickEventArgs e) //************************Added 6/3/15
        {
           // CBudgetExport be = new CBudgetExport();
            CHourExport he = new CHourExport();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               he.ExportBudgetForPrimavera(saveFileDialog1.FileName, moPCN.ID);
            }
        }

        private void tlbbExpenseExport_Click(object sender, C1.Win.C1Command.ClickEventArgs e) //************************Added 6/3/15
        {
            
            CExpenseExport ee = new CExpenseExport();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               ee.ExportBudgetForPrimavera(saveFileDialog1.FileName, moPCN.ID);
            }
        }

        private void ClearCurrentRow_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
           MessageBox.Show("Are you sure you wish to delete the current line?");
           if (MessageBox.Show("Are you sure you wish to delete the current line?", "Delete Hours", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           {
               DataRow dr = moPCN.PCNData.PCNHours.Rows[tdbgHours.Bookmark];
               DataRow dd = moPCN.PCNData.PCNHoursDeleted.NewRow();
               dd["ID"] = dr["ID"];
               moPCN.PCNData.PCNHoursDeleted.Rows.Add(dd);

               tdbgHours.Delete();
           }
        }


        private void DeleteCurrentRow()
        {
            MessageBox.Show("Are you sure you wish to delete the current line?");
            if (MessageBox.Show("Are you sure you wish to delete the current line?", "Delete Hours", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow dr = moPCN.PCNData.PCNHours.Rows[tdbgHours.Bookmark];
                DataRow dd = moPCN.PCNData.PCNHoursDeleted.NewRow();
                dd["ID"] = dr["ID"];
                moPCN.PCNData.PCNHoursDeleted.Rows.Add(dd);

                tdbgHours.Delete();
            }
        }




     }
}