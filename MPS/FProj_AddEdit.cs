using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace RSMPS
{
    public partial class FProj_AddEdit : Form
    {
        private const string NEWCOMBOENTRY = "< New >";

        public event NewItemCreated OnNewItem;

        private bool mbItemChanged;
        private bool mbPMChanged;   //*********************Added 7/28/2017
        private CBProject moProj;
        private DataSet mdsBudget;

        private int previousPM, newPM;

        public FProj_AddEdit()
        {
            InitializeComponent();

            ClearForm();
        }

        public void LoadByID(int itmID)
        {
            ClearForm();

            moProj.Load(itmID);
            LoadObjectToScreen();

            previousPM = moProj.ProjMngrID; //************************Added 7/28/2017
            mbItemChanged = false;
            mbPMChanged = false;
        }

        private void ClearForm()
        {
            moProj = new CBProject();

            txtNumber.Text = "";
            txtDescription.Text = "";
            cboCustomer.Text = "";
            txtCustomerNumber.Text = "";
            cboManager.Text = "";
            cboManagerLead.Text = "";
            lblMultiplier.Visible = false;
            txtMultiplier.Visible = false;
            txtMultiplier.Text = "1.85";
            lblOverlay.Visible = false;
            txtOverlay.Visible = false;
            txtOverlay.Text = "6.00";
            txtPOAmount.Text = "";

            dtpStart.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            dtpEnd.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            chkActiveProposal.Checked = false;
            chkIsBooked.Checked = false;
            chkIsActive.Checked = false;
            chkIsMaster.Checked = false;
            cboMasterJobs.Text = "";

            rtbNotes.Text = "";

            LoadCustomerBox();
            LoadManagerBox();
            LoadRelationshipBox();
            LoadRateSchedBox();
            LoadMasterBox();
            LoadReportStatusBox();

            CreateBudgetDS();

            TotalBudget();
        }

        private void CreateBudgetDS()
        {
            mdsBudget = CBProjectBudget.GetListDSByProjID(0);

            tdbgBudget.SetDataBinding(mdsBudget, "Table", true);
        }

        private void LoadCustomerBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBCustomer.GetList();

            cboCustomer.Items.Clear();

            // add <new> to allow add on the fly
            //li = new RSLib.COListItem();

            //li.ID = 0;
            //li.Description = NEWCOMBOENTRY;
            //cboCustomer.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboCustomer.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadLocationBox(int custID)
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBLocation.GetList(custID);

            cboLocation.Items.Clear();

            // add <new> to allow add on the fly
            li = new RSLib.COListItem();

            li.ID = 0;
            li.Description = NEWCOMBOENTRY;
            cboLocation.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["City"].ToString() + ", " + dr["Abbrev"].ToString();

                cboLocation.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadManagerBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            //SSS 20131105 dr = CBEmployee.GetList();
             dr = CBEmployee.GetListProjectManagers();

            cboManager.Items.Clear();
            cboManagerLead.Items.Clear();
            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboManager.Items.Add(li);
                cboManagerLead.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadMasterBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBProject.GetListMaster();

            cboMasterJobs.Items.Clear();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "";
            cboMasterJobs.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Number"].ToString();

                cboMasterJobs.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadRelationshipBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            //dr = CBEmployee.GetList();

            dr = CBEmployee.GetRelationshipManagerList(); //***********************Edited 7/13/2015

            cboRelationship.Items.Clear();

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboRelationship.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadRateSchedBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBRateSchedule.GetList();

            cboRateSched.Items.Clear();

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboRateSched.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadReportStatusBox()
        {
            RSLib.COListItem li;

            cboReportStatus.Items.Clear();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "Active";
            cboReportStatus.Items.Add(li);
            li = new RSLib.COListItem();
            li.ID = 1;
            li.Description = "In Active";
            cboReportStatus.Items.Add(li);
            li = new RSLib.COListItem();
            li.ID = 2;
            li.Description = "Hold";
            cboReportStatus.Items.Add(li);

            cboReportStatus.SelectedIndex = 0;
            cboReportStatus.Text = "Active";
        }

        private void LoadObjectToScreen()
        {
            CBCustomer c = new CBCustomer();
            CBLocation l = new CBLocation();
            CBEmployee e = new CBEmployee();
            CBRateSchedule rs = new CBRateSchedule();

            txtNumber.Text = moProj.Number;
            txtDescription.Text = moProj.Description;

            c.Load(moProj.CustomerID);
            cboCustomer.Text = c.Name;
            txtCustomerNumber.Text = moProj.CustomerProjNumber;

            LoadLocationBox(moProj.CustomerID);
            l.Load(moProj.LocationID);
            cboLocation.Text = l.FullName;

            e.Load(moProj.ProjMngrID);
            cboManager.Text = e.Name;

            e.Load(moProj.LeadProjMngrID);
            cboManagerLead.Text = e.Name;

            e.Load(moProj.RelationshipMngrID);
            cboRelationship.Text = e.Name;

            rs.Load(moProj.RateSchedID);
            cboRateSched.Text = rs.Name;
            if (rs.IsMultiplier == true)
            {
                lblMultiplier.Visible = true;
                txtMultiplier.Visible = true;
                txtMultiplier.Text = moProj.Multiplier.ToString("#,##0.00");
                lblOverlay.Visible = true;
                txtOverlay.Visible = true;
                txtOverlay.Text = moProj.Overlay.ToString("#,##0.00");
            }
            else
            {
                lblMultiplier.Visible = false;
                txtMultiplier.Visible = false;
                txtMultiplier.Text = "0.00";
                lblOverlay.Visible = false;
                txtOverlay.Visible = false;
                txtOverlay.Text = "0.00";
            }

            txtPOAmount.Text = moProj.POAmount;

            dtpStart.Value = moProj.DateStart;
            dtpEnd.Value = moProj.DateEnd;
            chkActiveProposal.Checked = moProj.IsProposal;
            chkIsBooked.Checked = moProj.IsBooked;
            chkIsActive.Checked = moProj.IsActive;
            chkIsGovernment.Checked = moProj.IsGovernment;
            chkIsMaster.Checked = moProj.IsMaster;

            if (moProj.MasterID > 0)
            {
                cboMasterJobs.Text = CBProject.GetNumberByID(moProj.MasterID);
            }

            cboReportStatus.SelectedIndex = moProj.ReportingStatus;

            rtbNotes.Text = moProj.Notes;

            mdsBudget = CBProjectBudget.GetListDSByProjID(moProj.ID);
            tdbgBudget.SetDataBinding(mdsBudget, "Table", true);

            TotalBudget();

            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator != true)
            {
                chkActiveProposal.Enabled = false;
                chkIsActive.Enabled = false;
                chkIsBooked.Enabled = false;
            }
        }

        private void LoadScreenToObject()
        {
            CBCustomer c = new CBCustomer();
            CBEmployee e = new CBEmployee();
            CBRateSchedule rs = new CBRateSchedule();

            moProj.Number = txtNumber.Text;
            moProj.Description = txtDescription.Text;
            moProj.CustomerProjNumber = txtCustomerNumber.Text;

            Func<ComboBox, int?> getId = (box) => {
                var selected = ((RSLib.COListItem)box.SelectedItem);
                return (selected != null) ? selected.ID : (int?)null;
            };

            moProj.CustomerID = getId(cboCustomer) ?? moProj.CustomerID;
            moProj.LocationID = getId(cboLocation) ?? moProj.LocationID;
            moProj.ProjMngrID = getId(cboManager) ?? moProj.ProjMngrID;
            moProj.LeadProjMngrID = getId(cboManagerLead) ?? moProj.LeadProjMngrID;
            moProj.RelationshipMngrID = getId(cboRelationship) ?? moProj.RelationshipMngrID;
            moProj.RateSchedID = getId(cboRateSched) ?? moProj.RateSchedID;

            moProj.Multiplier = RevSol.RSMath.IsDecimalEx(txtMultiplier.Text);
            moProj.Overlay = RevSol.RSMath.IsDecimalEx(txtOverlay.Text);

            moProj.POAmount = txtPOAmount.Text;

            moProj.DateStart = dtpStart.Value;
            moProj.DateEnd = dtpEnd.Value;
            moProj.IsProposal = chkActiveProposal.Checked;
            moProj.IsBooked = chkIsBooked.Checked;
            moProj.IsActive = chkIsActive.Checked;
            moProj.IsGovernment = chkIsGovernment.Checked;
            moProj.IsMaster = chkIsMaster.Checked;

            if (cboMasterJobs.SelectedItem == null)
                moProj.MasterID = 0;
            else
                moProj.MasterID = ((RSLib.COListItem)cboMasterJobs.SelectedItem).ID;

            moProj.ReportingStatus = cboReportStatus.SelectedIndex;

            moProj.Notes = rtbNotes.Text;
        }

        private void TotalBudget()
        {
            decimal tmpVal;

            tmpVal = 0;

            foreach (DataRow d in mdsBudget.Tables[0].Rows)
            {
                tmpVal += Convert.ToDecimal(d["BudgetHrs"]);
            }

            txtBudgetTotal.Text = tmpVal.ToString("###0.00");
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true || u.IsEngineerAdmin)
            {
                if (mbItemChanged == true && IsValid() == true)
                {
                    LoadScreenToObject();
                    moProj.Save();
                    SaveBudgets(moProj.ID);
                    //*************************** update dt_ProjectSummarys and DT_ProjectSummaryInfos, added 7/28/2015

                    newPM = moProj.ProjMngrID;
                    MessageBox.Show(moProj.ID.ToString());
                    
                    if (OnNewItem != null)
                    {
                        OnNewItem(moProj.ID);
                        MessageBox.Show("New Project Added"+newPM.ToString() + "  " + moProj.ID.ToString());
                        Save_Summary_NewProject(newPM, moProj.ID);
                    }

                    else
                    {
                        if (mbPMChanged == true)
                        {
                            MessageBox.Show(previousPM.ToString());
                            MessageBox.Show(newPM.ToString()); 
                            Save_PMUpdate(previousPM, newPM, moProj.ID);
                            MessageBox.Show("Proj Summary info updated");
                        }
                        else MessageBox.Show("PM not changed");

                    }
                    
                }
                //************************ Security Check for Creating new project !!
                //else
                //{
                //     MessageBox.Show("No change Allowed");
                //    return;// **************** Added 5/26
                //}

            }
            //MessageBox.Show("Closing out ****************************************************"); 
            this.Close();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tdbgBudget_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            TotalBudget();
            mbItemChanged = true;
        }

        private void SaveBudgets(int projID)
        {
            CBProjectBudget pb;

            foreach (DataRow d in mdsBudget.Tables[0].Rows)
            {
                pb = new CBProjectBudget();

                pb.ID = Convert.ToInt32(d["ID"]);
                pb.ProjectID = projID;
                pb.DepartmentID = Convert.ToInt32(d["DepartmentID"]);
                pb.BudgetHrs = Convert.ToDecimal(d["BudgetHrs"]);

                pb.Save();
            }
        }

        private bool IsValid()
        {
            bool retVal;
            string msg;

            if (txtNumber.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter a project number.";
            }
            else if (txtDescription.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter a project description.";
            }
            else if (cboCustomer.Text.Length < 1)
            {
                retVal = false;
                msg = "Please select a customer.";
            }
            else if (cboLocation.Text.Length < 1)
            {
                retVal = false;
                msg = "Please select a location.";
            }
            else if (cboManager.Text.Length < 1)
            {
                retVal = false;
                msg = "Please select a Project Manager.";
            }
            else if (cboManagerLead.Text.Length < 1)
            {
                retVal = false;
                msg = "Please select a Lead Project Manager.";
            }
            else if (cboRateSched.Text.Length < 1)
            {
                retVal = false;
                msg = "Please select a rate schedule";
            }
            else
            {
                retVal = true;
                msg = "";
            }

            if (retVal == false)
            
                MessageBox.Show(msg, "Incompelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                         

            return retVal;
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;

            if (cboCustomer.SelectedItem != null)
            {
                int tmpID = ((RSLib.COListItem)cboCustomer.SelectedItem).ID;

                if (tmpID > 0)
                {
                    // load locations for selected customer
                    LoadLocationBox(tmpID);
                }
            }
        }

        private void cboManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
            mbPMChanged = true; //***************Added 7/28/2015
        }
        private void cboManagerLead_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }
        private void rtbNotes_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void chkIsBooked_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocation.Text == NEWCOMBOENTRY)
            {
                // allow user to create new location
                FLoc_AddEdit loc;
                int tmpID;

                tmpID = ((RSLib.COListItem)cboCustomer.SelectedItem).ID;
                loc = new FLoc_AddEdit(tmpID);

                cboLocation.SelectedItem = null;
                cboLocation.Text = "";

                loc.OnChangeLocation += new RSLib.ItemReturnAction(loc_OnChangeLocation);
                loc.ShowDialog();
                loc.OnChangeLocation -= new RSLib.ItemReturnAction(loc_OnChangeLocation);

                loc.Close();
            }
            else
            {
                if (cboLocation.Text.Length > 0)
                    mbItemChanged = true;
            }
        }

        void loc_OnChangeLocation(int itmID, string description)
        {
            CBLocation loc = new CBLocation();

            loc.Load(itmID);
            int tmpID = ((RSLib.COListItem)cboCustomer.SelectedItem).ID;
            LoadLocationBox(tmpID);
            cboLocation.Text = loc.FullName;
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;

            if (chkIsActive.Checked == true)
            {
                chkActiveProposal.Checked = false;
                chkActiveProposal.Enabled = false;
            }
            else
            {
                chkActiveProposal.Enabled = true;
            }
        }

        private void txtPOAmount_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void cboRelationship_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void cboRateSched_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;

            if (cboRateSched.Text == "Multiplier")
            {
                lblMultiplier.Visible = true;
                txtMultiplier.Visible = true;
                txtMultiplier.Text = moProj.Multiplier.ToString("#,##0.00");
                lblOverlay.Visible = true;
                txtOverlay.Visible = true;
                txtOverlay.Text = moProj.Overlay.ToString("#,##0.00");
            }
            else
            {
                lblMultiplier.Visible = false;
                txtMultiplier.Visible = false;
                txtMultiplier.Text = "0.00";
                lblOverlay.Visible = false;
                txtOverlay.Visible = false;
                txtOverlay.Text = "0.00";
            }
        }

        private void txtMultiplier_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void txtOverlay_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void chkActiveProposal_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;

            if (chkActiveProposal.Checked == true)
            {
                chkIsActive.Checked = false;
                chkIsBooked.Checked = false;
                chkIsActive.Enabled = false;
                chkIsBooked.Enabled = false;
            }
            else
            {
                chkIsActive.Enabled = true;
                chkIsBooked.Enabled = true;
            }
        }

        private void FProj_AddEdit_Load(object sender, EventArgs e)
        {

        }

        private void txtCustomerNumber_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void chkIsGovernment_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void chkIsMaster_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void cboMasterJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void cboReportStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Save_PMUpdate(int prevID, int newID, int projID)  //************Added*****7/28/2015
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            //LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummary_PM_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@PrevPMID", SqlDbType.Int);
            prm.Value = prevID;
            prm = cmd.Parameters.Add("@NewPMID", SqlDbType.Int);
            prm.Value = newID;
            prm = cmd.Parameters.Add("@projectID", SqlDbType.Int);
            prm.Value = projID;


            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            //return oVar.ID;
        }

        private void Save_Summary_NewProject(int EmployeeID, int ProjectID)  //************Added*****7/28/2015
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            //LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummary_SummaryInfo_NewProject_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;


            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = EmployeeID;
            
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = ProjectID;


            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            //return oVar.ID;
        }




    }
}
