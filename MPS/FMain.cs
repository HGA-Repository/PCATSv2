using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
#if TEST
            this.BackgroundImage = global::RSMPS.Properties.Resources.testing;
#endif
        }

        private void InitApplication()
        {
            FLogin fl = new FLogin();

            this.Hide();
            fl.OnSuccessLogin += new LoginSuccessful(fl_OnSuccessLogin);
            fl.OnCancelLogin += new EventHandler(fl_OnCancelLogin);
            fl.ShowDialog();
            fl.OnSuccessLogin -= new LoginSuccessful(fl_OnSuccessLogin);
            fl.OnCancelLogin -= new EventHandler(fl_OnCancelLogin);
            fl.Close();
            
        }

        void fl_OnCancelLogin(object sender, EventArgs e)
        {
            tmrClose.Enabled = true;
        }

       // private void SetDebugMenu()
       // {
            //pCIManagerToolStripMenuItem.Visible = false;
            //pCILogToolStripMenuItem.Visible = false;
            //pCNLogToolStripMenuItem.Visible = false;

            //mnuToolsDocRelease.Visible = false;
      //  }

        void fl_OnSuccessLogin(int userID, string sessionID)
        {
            RSLib.COAppSetting aps = new RSLib.COAppSetting();

            this.Show();
            aps.InitAppSettings();

            if (aps.WindowMax == true)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Height = aps.WindowHt;
                this.Width = aps.WindowWid;
                if (Screen.PrimaryScreen.Bounds.Width >= this.Width)
                    this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

                if (Screen.PrimaryScreen.Bounds.Height >= this.Height)
                    this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            }

            tssStatus1.Text = "Ready";
            tssStatus2.Text = DateTime.Now.ToShortDateString();

            SetAccessForSecurityLevel();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           // if (MessageBox.Show("Are you sure you wish to exit PCATS?", "Exit PCATS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           // {
                RSLib.COAppSetting aps = new RSLib.COAppSetting();

                aps.InitAppSettings();

                if (this.WindowState == FormWindowState.Maximized)
                {
                    aps.WindowMax = true;
                }
                else
                {
                    aps.WindowMax = false;
                    aps.WindowHt = this.Height;
                    aps.WindowWid = this.Width;
                }

                aps.SaveAppSettings();

                RSLib.COSecurity.Delete();
            //}
            //else;
            //{
             //   e.Cancel = true;
             //   this.Activate();
            //}
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            {
               this.Close();
            }
        }

        #region Testing List
        private void mnuTestListtest_Click(object sender, EventArgs e)
        {
            FEmp_TitleList fl = new FEmp_TitleList();

            fl.IsSelectOnly = true;
            fl.ShowDialog();
        }

        private void mnuTestListCust_Click(object sender, EventArgs e)
        {
            FCust_List cl = new FCust_List();

            cl.ShowDialog();
        }

        private void mnuTestListDept_Click(object sender, EventArgs e)
        {
            FDept_List dl = new FDept_List();

            dl.ShowDialog();
        }

        private void mnuTestListEmp_Click(object sender, EventArgs e)
        {
            FEmp_List el = new FEmp_List();

            el.ShowDialog();
        }
        #endregion

        private void mnuTestListProj_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.ShowDialog();
        }

        private void mnuTestSchedule_Click(object sender, EventArgs e)
        {
            FScd_AddEdit s = new FScd_AddEdit();

            tsMain.Visible = false;
            s.MdiParent = this;
            s.OnScheduleClose += new EventHandler(s_OnScheduleClose);
            s.Show();
            s.WindowState = FormWindowState.Maximized;
        }

        void s_OnScheduleClose(object sender, EventArgs e)
        {
            tsMain.Visible = true;
        }

        private void mnuTestInitCalendar_Click(object sender, EventArgs e)
        {
            CBUtility u = new CBUtility();

            u.InitWeeks(1);
        }

        private void mnuToolEmpTitle_Click(object sender, EventArgs e)
        {
            FEmp_TitleList fl = new FEmp_TitleList();

            fl.ShowDialog();
        }

        private void mnuToolDept_Click(object sender, EventArgs e)
        {
            FDept_List dl = new FDept_List();

            dl.ShowDialog();
        }

        private void mnuNavSchedule_Click(object sender, EventArgs e)
        {
            FScd_AddEdit s;

            if (CheckIfScheduleOpen() == false)
            {
                s = new FScd_AddEdit();
                tsMain.Visible = false;
                s.MdiParent = this;
                s.OnScheduleClose += new EventHandler(s_OnScheduleClose);
                s.Show();
                s.WindowState = FormWindowState.Maximized;
            }
        }

        private void mnuNavProjects_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.ShowDialog();
        }

        private void mnuNavEmp_Click(object sender, EventArgs e)
        {
            FEmp_List el = new FEmp_List();

            el.ShowDialog();
        }

        private void tsbSchedule_Click(object sender, EventArgs e)
        {
            FScd_AddEdit s;

            if (CheckIfScheduleOpen() == false)
            {
                s = new FScd_AddEdit();
                tsMain.Visible = false;
                s.MdiParent = this;
                s.OnScheduleClose += new EventHandler(s_OnScheduleClose);
                s.Show();
                s.WindowState = FormWindowState.Maximized;
            }
        }

        private void tsbProject_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.ShowDialog();
        }

        private void tsbCustomer_Click(object sender, EventArgs e)
        {
            FCust_List cl = new FCust_List();

            cl.ShowDialog();
        }

        private void tsbEmployee_Click(object sender, EventArgs e)
        {
            FEmp_List el = new FEmp_List();

            el.ShowDialog();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            {
               this.Close();
            }
        }

        private void mnuNavCust_Click(object sender, EventArgs e)
        {
            FCust_List cl = new FCust_List();

            cl.ShowDialog();
        }

        private bool CheckIfScheduleOpen()
        {
            bool retVal;

            retVal = false;

            foreach (System.Windows.Forms.Form f in this.MdiChildren)
            {
                if (f.Name == "FScd_AddEdit")
                    retVal = true;
            }

            return retVal;
        }

        private void mnuReportsSchedule_Click(object sender, EventArgs e)
        {
            FPnt_GridPrint gp = new FPnt_GridPrint();

            gp.ShowDialog();

            gp.Close();
        }

        private void mnuToolsTest_Click(object sender, EventArgs e)
        {
            ////FSec_UserAddEdit f = new FSec_UserAddEdit();
            //FSec_UserList fl = new FSec_UserList();

            ////f.LoadByID(2);
            ////f.ShowDialog();

            //fl.ShowDialog();

            CPTest t = new CPTest();

            t.TestPM();
        }

        private void mnuToolsOptionsUsers_Click(object sender, EventArgs e)
        {
            FSec_UserList fl = new FSec_UserList();

            fl.ShowDialog();
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
                       
                    tmrClose.Enabled = false;
                    this.Close();       
               
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            InitApplication();
        }

        private void SetAccessForSecurityLevel()
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();
            decimal maxLvl;

            sec.InitAppSettings();
            u.Load(sec.UserID);

            maxLvl = CBUserLevel.GetMaxLevelForUser(u.ID);

            tssUsername.Text = u.Username;

          
            // turn everything back on in case of logout
            mnuToolsEmpTitle.Enabled = true;
            mnuToolsDept.Enabled = true;
            mnuToolsOptions.Enabled = true;

            mnuNavigate.Enabled = true;
            mnuNavigate.Visible = true;

            tsbProject.Enabled = true;
            tsbCustomer.Enabled = true;
            tsbEmployee.Enabled = true;

            manageReleaseTransmittalToolStripMenuItem.Enabled = true;
            manageIssueReleaseFormToolStripMenuItem.Visible = true;
            employeeTitlesToolStripMenuItem.Visible = true;
            departmentsToolStripMenuItem.Visible = true;

            if (u.IsAdministrator == true || u.IsEngineerAdmin == true)
            {
                forecastRemainingToolStripMenuItem.Visible = true;
                manageReleaseTransmittalToolStripMenuItem.Enabled = true; 
                mnuNavigate.Enabled = true;
                systemUsersToolStripMenuItem.Enabled = false;
                systemUsersToolStripMenuItem.Visible = false;

                if (u.IsAdministrator == true)
                {
                    systemUsersToolStripMenuItem.Enabled = true;
                    systemUsersToolStripMenuItem.Visible = true;
                }
            }
            else
            {
                if (u.IsManager == true)
                {
                    forecastRemainingToolStripMenuItem.Visible = false;
                    manageReleaseTransmittalToolStripMenuItem.Visible = false;
                    mnuNavigate.Enabled = true;

                    employeeTitlesToolStripMenuItem.Visible = false;
                    departmentsToolStripMenuItem.Visible = false;
                    systemUsersToolStripMenuItem.Visible = false;

                    //resourceVarianceToolStripMenuItem.Visible = true;
                    //resourceVarianceSummaryToolStripMenuItem.Visible = true;
                }
                else
                {
                    forecastRemainingToolStripMenuItem.Visible = false;
                    manageReleaseTransmittalToolStripMenuItem.Visible = false;
                    mnuNavigate.Visible = false;
                    systemUsersToolStripMenuItem.Visible = false;
                    tsbProject.Visible = false;
                    tsbCustomer.Visible = false;
                    tsbEmployee.Visible = false;

                    costSummaryToolStripMenuItem.Visible = false;
                    costSummaryToolStripMenuItem1.Visible = false;
                    projectForecastingToolStripMenuItem.Visible = false;
                    weeklyPMReportsToolStripMenuItem.Visible = false;
                    pCNLogToolStripMenuItem.Visible = false;
                    resourceVarianceToolStripMenuItem.Visible = true;
                    resourceVarianceSummaryToolStripMenuItem.Visible = true;
                    projectForecastingReportRollupToolStripMenuItem.Visible = false;
                    forecastRemainingToolStripMenuItem.Visible = false;
                    pipelineForecastRemainingToolStripMenuItem.Visible = false;
                    programManagementForecastRemainingToolStripMenuItem.Visible = false;
                }
            }
        }

        private void mnuFileLogoff_Click(object sender, EventArgs e)
        {
            CloseAllOpenWindows();
            this.Hide();
            
            // redo the login
            FLogin fl = new FLogin();

            fl.OnSuccessLogin += new LoginSuccessful(fl_OnSuccessLogin);
            //fl.OnCancelLogin += new EventHandler(fl_OnCancelLogin);
            fl.ShowDialog();
            fl.OnSuccessLogin -= new LoginSuccessful(fl_OnSuccessLogin);
            //fl.OnCancelLogin -= new EventHandler(fl_OnCancelLogin);
            fl.Close();
        }

        private void CloseAllOpenWindows()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void mnuFileChangePassword_Click(object sender, EventArgs e)
        {
            FSec_UserAddEdit uae = new FSec_UserAddEdit();
            RSLib.COSecurity sec = new RSLib.COSecurity();

            sec.InitAppSettings();
            uae.LoadByID(sec.UserID);
            uae.ShowDialog();
            uae.Close();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            FAbout f = new FAbout();

            f.ShowDialog();
            f.Close();
        }

        private void drawingLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDrawingLogList dll = new FDrawingLogList();

            dll.ShowDialog();
            dll.Close();
        }

        private void mnuDrawingLogs_Click(object sender, EventArgs e)
        {
            FPnt_JobStat js = new FPnt_JobStat();

            js.ShowDialog();
        }

        private void importBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBudgetImport bi = new FBudgetImport();

            bi.ShowDialog();
        }

        private void mnuIssueDocRelease_Click(object sender, EventArgs e)
        {
            FTran_IssueNew tran = new FTran_IssueNew();

            tran.ShowDialog();
        }

        private void mnuToolsTransmittalList_Click(object sender, EventArgs e)
        {
            FTran_IssueList il = new FTran_IssueList();

            il.ShowDialog();
        }

        private void mnuToolsNewTransmittal_Click(object sender, EventArgs e)
        {
            FTran_TranAddEdit t = new FTran_TranAddEdit();

            t.ShowDialog();
        }

        private void mnuToolsTestIssue_Click(object sender, EventArgs e)
        {
            DataSet ds;

            ds = CBTransmittalRelease.GetIssueReleaseForReport(4);

            CPTransmittal.ShowTestIssuance(ds);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CPDrawingLog dl = new CPDrawingLog();

            //dl.PrintTest();
        }

        private void projectSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSMPS.FManager_List fml = new FManager_List();

            fml.ShowDialog();
        }

        private void costReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSMPS.FCRMain crm = new FCRMain();

            crm.ShowDialog();
        }

        private void mnuCustomerDrawingLogs_Click(object sender, EventArgs e)
        {
            FPnt_JobStat_Customer js = new FPnt_JobStat_Customer();

            js.ShowDialog();
        }

        private void testBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List(true, true);

            pl.OnItemSelected += new RSLib.ListItemAction(BudgetProjectSelected);
            pl.IsSelectOnly = true;
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(BudgetProjectSelected);
        }

        void BudgetProjectSelected(int itmID)
        {
            FBudgetMain b;
            do{
                b = new FBudgetMain(itmID);
                b.SetNewProjectBudget(itmID);
                b.ShowDialog();
            } while( b.ReloadForm );
        }

        private void costSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.OnItemSelected += new RSLib.ListItemAction(CostSummaryProject);
            pl.IsSelectOnly = true;
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(CostSummaryProject);
        }

        void CostSummaryProject(int itmID)
        {
            FCostSummary cs = new FCostSummary();

            cs.SetProjectID(itmID);
            cs.ShowDialog();
        }

        private void systemUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSec_UserList fl = new FSec_UserList();

            fl.ShowDialog();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDept_List dl = new FDept_List();

            dl.ShowDialog();
        }

        private void employeeTitlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEmp_TitleList fl = new FEmp_TitleList();

            fl.ShowDialog();
        }

        private void updateMPPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FScd_AddEdit s;

            if (CheckIfScheduleOpen() == false)
            {
                s = new FScd_AddEdit();
                tsMain.Visible = false;
                s.MdiParent = this;
                s.OnScheduleClose += new EventHandler(s_OnScheduleClose);
                s.Show();
                s.WindowState = FormWindowState.Maximized;
            }
        }

        private void manpowerPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPnt_GridPrint gp = new FPnt_GridPrint();

            gp.ShowDialog();

            gp.Close();
        }

        private void drawingLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FPnt_JobStat js = new FPnt_JobStat();

            js.ShowDialog();
        }

        private void costSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.OnItemSelected += new RSLib.ListItemAction(CostSummaryProject);
            pl.IsSelectOnly = true;
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(CostSummaryProject);
        }

        private void projectForecastingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSMPS.FCRMain crm = new FCRMain();

            crm.ShowDialog();
        }

        private void weeklyPMReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSMPS.FManager_List fml = new FManager_List();

            fml.ShowDialog();
        }

        private void updateJobStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDrawingLogList dll = new FDrawingLogList();

            dll.ShowDialog();
            dll.Close();
        }

        private void importBudgetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FBudgetImport bi = new FBudgetImport();

            bi.ShowDialog();
        }

        private void drawingLogForCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPnt_JobStat_Customer js = new FPnt_JobStat_Customer();

            js.ShowDialog();
        }

        private void jobStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPnt_JobStat js = new FPnt_JobStat();

            js.SetPrintMode(true);
            js.ShowDialog();
        }

        private void pCIManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List(true, true);

            pl.IsSelectOnly = true;
            pl.ShowInTaskbar = false;
            pl.OnItemSelected += new RSLib.ListItemAction(pl_OnItemSelected);
            pl.ShowDialog();
        }

        void pl_OnItemSelected(int itmID)
        {
            FPCIList pcil = new FPCIList();
            COAppState aps = new COAppState();

            aps.InitAppSettings();

            pcil.OnPCISelected += new RevSol.ItemMultiSelectHandler(pcil_OnPCISelected);
            pcil.SetDefaultDepartment(aps.Sch_LastDeptID);
            pcil.SetProjectID(itmID);
            pcil.ShowDialog();
        }

        void pcil_OnPCISelected(int itm1ID, int itm2ID, int itm3ID)
        {
            // itm1ID is department
            // itm2ID is project
            // itm3ID is pci

            FPCIMain pci = new FPCIMain(itm1ID, itm2ID);

            if (itm3ID != 0)
                pci.SetPCI(itm3ID);

            pci.ShowDialog();
        }

        private void pCILogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.OnItemSelected += new RSLib.ListItemAction(PCIProjectSelected);
            pl.IsSelectOnly = true;
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(PCIProjectSelected);
        }

        void PCIProjectSelected(int itmID)
        {
            FPCILog log = new FPCILog(itmID);

            log.ShowDialog();
        }

        private void pCNLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.OnItemSelected += new RSLib.ListItemAction(PCNProjectSelected);
            pl.IsSelectOnly = true;
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(PCNProjectSelected);
        }

        void PCNProjectSelected(int itmID)
        {
            FPCNLog log = new FPCNLog(itmID);

            log.ShowDialog();
        }

        private void resourceVarianceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;

            //CPSummary sum = new CPSummary();

            //sum.PrintVariance();

            //this.Cursor = Cursors.Default;

            FPnt_Variance v = new FPnt_Variance();

            v.ShowDialog();
        }

        private void resourceVarianceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPSummary sum = new CPSummary();
            this.Cursor = Cursors.WaitCursor;
            sum.PrintVariance(2,0);
            this.Cursor = Cursors.Default;
        }

        private void issueANewReleaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProj_List plIssue = new FProj_List();

            plIssue.OnItemSelected += new RSLib.ListItemAction(plIssue_OnItemSelected);
            plIssue.IsSelectOnly = true;
            plIssue.ShowDialog();
            plIssue.OnItemSelected -= new RSLib.ListItemAction(plIssue_OnItemSelected);

            //CPTransmittal.PrintTransmittalRelease(3);
        }

        void plIssue_OnItemSelected(int itmID)
        {
            FRelease_AddEdit rel = new FRelease_AddEdit();

            rel.SetProjectID(itmID);
            //rel.SetReleaseID(3);
            rel.ShowDialog();
        }

        private void issueANewTransmittalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProj_List plTran = new FProj_List();

            plTran.OnItemSelected += new RSLib.ListItemAction(plTran_OnItemSelected);
            plTran.IsSelectOnly = true;
            plTran.ShowDialog();
            plTran.OnItemSelected -= new RSLib.ListItemAction(plTran_OnItemSelected);

            //CPTransmittal.PrintTransmittal(1);
        }

        void plTran_OnItemSelected(int itmID)
        {
            FTransmittal_AddEdit tran = new FTransmittal_AddEdit();

            tran.SetProjectID(itmID);
            //tran.SetTransmittalID(1);
            tran.ShowDialog();
        }

        private void manageReleaseTransmittalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTransmittal_Manage tranMan = new FTransmittal_Manage();

            tranMan.ShowDialog();
        }

        private void manageIssueReleaseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRelease_Manage relMan = new FRelease_Manage();

            relMan.ShowDialog();
        }

        private void projectForecastingReportRollupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSMPS.FCRMain crm = new FCRMain();

            crm.LoadMasters();
            crm.ShowDialog();
        }

        private void copyBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCopyBudget copy = new FCopyBudget();

            copy.ShowDialog();
        }

        private void forecastRemainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPSummary sum = new CPSummary();

            this.Cursor = Cursors.WaitCursor;

            sum.PrintForecastRemainingNew(1);

            this.Cursor = Cursors.Default;
        }

        private void exportBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBudgetToVision btv = new FBudgetToVision();

            btv.ShowDialog();
        }

        private void pipelineForecastRemainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPSummary sum = new CPSummary();

            this.Cursor = Cursors.WaitCursor;

            sum.PrintForecastRemaining(true);

            this.Cursor = Cursors.Default;
        }

        private void programManagementForecastRemainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPSummary sum = new CPSummary();

            this.Cursor = Cursors.WaitCursor;

            //sum.PrintForecastRemaining(true);
            sum.PrintForecastRemainingNew(3);

            this.Cursor = Cursors.Default;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuReports_Click(object sender, EventArgs e)
        {

        }

        private void viewMPPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FScd_AddEdit_View_MPP s;

            if (CheckIfScheduleOpen() == false)
            {
                s = new FScd_AddEdit_View_MPP();
                tsMain.Visible = false;
                s.MdiParent = this;
                s.OnScheduleClose += new EventHandler(s_OnScheduleClose);
                s.Show();
                s.WindowState = FormWindowState.Maximized;
            }
        }

        private void viewMPPlan2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FScd_AddEdit_View_MPP2 s;

            if (CheckIfScheduleOpen() == false)
            {
                s = new FScd_AddEdit_View_MPP2();
                tsMain.Visible = false;
                s.MdiParent = this;
                s.OnScheduleClose += new EventHandler(s_OnScheduleClose);
                s.Show();
                s.WindowState = FormWindowState.Maximized;
            }
        }

        //SSS 20131209 - Removing from Menu
        //private void mnuReportByDepartment_Click(object sender, EventArgs e)
        //{

        //}
    }
}