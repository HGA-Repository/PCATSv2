using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C1.Win.C1FlexGrid;
using System.Data.SqlClient;
using System.Threading;


namespace RSMPS
{
    public partial class FScd_AddEdit : Form
    {
        private enum SchdSortType
        {
            enProjectSort,
            enEmployeeSort
        }

        private const int WEEKCOLSTART = 9; // was 8
        private const int WEEKCOLOFFSET = 6; // was 5
        private const int ROWTOTALCOLUMNS = 2;
        private const int TOTALCOLS = 0;
        private const string PLANCOLTITLE = "P";
        private const string FORECOLTITLE = "F";
        private const string ACTLCOLTITLE = "A";

        private const string CELLSTYLEUNDER = "CellStyleUnder";
        private const string CELLSTYLEOVER = "CellStyleOver";
        private const string CELLSTYLEMAX = "CellStyleMax";
        private const string CELLSTYLEREG = "CellStyleReg";

        private const int PROJECTCOLUMN = 1;
        private const int PROJECTDESCCOLUMN = 2;
        private const int EMPLOYEECOLUMN = 3;
        private const int PROJECTIDCOLUMN = 4;
        private const int VISIONEMPLOYEEID = 5; //new
        private const int EMPLOYEEIDCOLUMN = 6; // was 5
        private const int EMPLOYEEPTOTCOL = 7; // was 6
        private const int EMPLOYEEFTOTCOL = 8;// was 7

        private String HOURDISPLAYFORMAT = "#,##0";

        private Color WARNINGCOLORBELOW = Color.White;
        private Color WARNINGCOLORHIGH = Color.Yellow;
        private Color WARNINGCOLORMAX = Color.Red;
        private Color WARNINGCOLORREG = Color.Lime;

        private delegate void CHANGEVALFORHOURS(COScheduleHour.GridHoursLevel hrsLvl);

        private DataSet mdsWeeks;
        private int miCurrDept;
        private int miCurrSort;
        private SchdSortType meCurrSort;
        private int miStartWeekID;
        //private int miEndWeekID;

        private bool mbShowPlanned;
        private bool mbShowForecast;
        private bool mbShowActual;

        FScd_ProjSummary moProjSumm;
        private bool mbSummaryOpen;

        private int miCurrUserID;
        private bool mbIsModerator;
        //private int miCurrColumn;

        public event EventHandler OnScheduleClose;


        public FScd_AddEdit()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            miCurrDept = 0;
            miCurrSort = 1;
            meCurrSort = SchdSortType.enProjectSort;
            miStartWeekID = 0;
            //miEndWeekID = 0;
            //miCurrColumn = -1;
            mbSummaryOpen = false;

            // create new styles
            CellStyle s = fgSchedule.Styles.Add("TotalValStyle");
            s.BackColor = Color.LightGray;
            s.ForeColor = Color.Black;
            s = fgSchedule.Styles.Add(CELLSTYLEUNDER);
            s.BackColor = WARNINGCOLORBELOW;
            s = fgSchedule.Styles.Add(CELLSTYLEOVER);
            s.BackColor = WARNINGCOLORHIGH;
            s = fgSchedule.Styles.Add(CELLSTYLEMAX);
            s.BackColor = WARNINGCOLORMAX;
            s = fgSchedule.Styles.Add(CELLSTYLEREG);
            s.BackColor = WARNINGCOLORREG;


            tbcGroupBy.SelectTab(1);

            LoadHourDisplayCombo();

            tmrInit.Enabled = true;
        }

        private void LoadHourDisplayCombo()
        {
            RSLib.COListItem li;

            tsbHoursDisp.Items.Clear();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "0";
            li.Meta = "#,##0";
            tsbHoursDisp.Items.Add(li);
            
            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "0.0";
            li.Meta = "#,##0.0";
            tsbHoursDisp.Items.Add(li);

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "0.00";
            li.Meta = "#,##0.00";
            tsbHoursDisp.Items.Add(li);

            tsbHoursDisp.Text = "0";
        }

        private void bttDept_Click(object sender, EventArgs e)
        {
            FDept_List dl = new FDept_List();

            dl.OnItemSelected += new RSLib.ListItemAction(dl_OnItemSelected);
            dl.IsSelectOnly = true;
            dl.ShowDialog();

            dl.Close();
        }

        void dl_OnItemSelected(int itmID)
        {
            CBDepartment d = new CBDepartment();

            d.Load(itmID);
            txtDepartment.Text = d.Description;
            miCurrDept = itmID;

            LoadTheGrid();

            SetAccessForSecurityLevel(miCurrDept);
        }

        private void SetGridByDateRange(DateTime sDate, DateTime eDate)
        {
            int numWeeks;
            int numWeekCols;

            fgSchedule.Redraw = false;

            mdsWeeks = CBWeekList.GetList(sDate, eDate);

            // initialize
            fgSchedule.Styles.Normal.WordWrap = true;
            //numWeeks = RSLib.COUtility.NumberWeeksInRange(sDate, eDate);
            numWeeks = mdsWeeks.Tables[0].Rows.Count;
            numWeekCols = numWeeks * 3;

            fgSchedule.Cols.Count = WEEKCOLSTART + numWeekCols + TOTALCOLS;
            fgSchedule.Rows.Fixed = 2;
            fgSchedule.AllowMerging = AllowMergingEnum.FixedOnly;

            // create row headers
            fgSchedule.Rows[0].AllowMerging = true;

            fgSchedule.Tree.Column = 0;
            fgSchedule.Tree.Style = TreeStyleFlags.Simple;

            fgSchedule.Cols[PROJECTCOLUMN].Width = 80;
            fgSchedule.Cols.Frozen = PROJECTCOLUMN;
            fgSchedule.Cols[PROJECTDESCCOLUMN].Width = 150;
            fgSchedule.Cols.Frozen = PROJECTDESCCOLUMN;
            fgSchedule.Cols[EMPLOYEECOLUMN].Width = 150;
            fgSchedule.Cols.Frozen = EMPLOYEECOLUMN;
            fgSchedule.Cols[6].Width = 40;
            fgSchedule.Cols.Frozen = 6;
            fgSchedule.Cols[7].Width = 40;
            fgSchedule.Cols.Frozen = 7;

            CreateWeekHeaders();

            fgSchedule.Cols[0].AllowMerging = true;
            fgSchedule.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            fgSchedule.AutoSizeCols(WEEKCOLSTART, fgSchedule.Cols.Count - 1, 15);

            LoadGridByRange(miCurrDept, sDate, eDate);

            SetMinimumTimeWidths();

            fgSchedule.Redraw = true;
        }

        private void CreateWeekHeaders()
        {
            CellRange rng;
            DateTime currWk;
            string wkDisp;
            int tmpCol;
            int indx;

            // create headers for week range
            indx = 0;
            foreach (DataRow dr in mdsWeeks.Tables[0].Rows)
            {
                if (indx == 0)
                    miStartWeekID = Convert.ToInt32(dr["ID"]);

                tmpCol = ((indx + 1) * 3) + WEEKCOLOFFSET;
                currWk = Convert.ToDateTime(dr["StartOfWeek"]);
                rng = fgSchedule.GetCellRange(0, tmpCol, 0, tmpCol + 2);
                wkDisp = dr["DisplayVal"].ToString();
                rng.Data = wkDisp;
                rng.UserData = dr["ID"].ToString();
                
                fgSchedule.Cols[tmpCol].Name = dr["ID"].ToString() + "-" + PLANCOLTITLE;
                fgSchedule.Cols[tmpCol].UserData = dr["ID"].ToString();
                fgSchedule.Cols[tmpCol + 1].Name = dr["ID"].ToString() + "-" + FORECOLTITLE;
                fgSchedule.Cols[tmpCol + 1].UserData = dr["ID"].ToString();
                fgSchedule.Cols[tmpCol + 2].Name = dr["ID"].ToString() + "-" + ACTLCOLTITLE;
                fgSchedule.Cols[tmpCol + 2].UserData = dr["ID"].ToString();
                indx++;
            }

            for (int i = 0; i < mdsWeeks.Tables[0].Rows.Count; i++)
            {
                tmpCol = ((i + 1) * 3) + WEEKCOLOFFSET;
                fgSchedule[1, tmpCol] = PLANCOLTITLE;
                fgSchedule[1, tmpCol + 1] = FORECOLTITLE;
                fgSchedule[1, tmpCol + 2] = ACTLCOLTITLE;
            }

            #region OldCalendarLoad
            //sDate = RSLib.COUtility.StartWeekRange(strtDate);

            //// create headers for week range
            //for (int i = 0; i < numWeeks; i++)
            //{
            //    tmpCol = (i+1) * 3;
            //    currWk = sDate.AddDays(i*7);
            //    rng = fgSchedule.GetCellRange(0, tmpCol, 0, tmpCol + 2);
            //    rng.Data = "Week " + currWk.Month.ToString() + "/" + currWk.Day.ToString();
            //}

            //// create headers for time entry
            //for (int i = 0; i < numWeeks; i++)
            //{
            //    tmpCol = (i + 1) * 3;
            //    fgSchedule[1, tmpCol] = PLANCOLTITLE;
            //    fgSchedule[1, tmpCol + 1] = FORECOLTITLE;
            //    fgSchedule[1, tmpCol + 2] = ACTLCOLTITLE;

            //    //fgSchedule.Cols[tmpCol].Style = fgSchedule.Styles["Normal"];
            //    //fgSchedule.Cols[tmpCol + 1].Style = fgSchedule.Styles["Normal"];
            //    //fgSchedule.Cols[tmpCol + 2].Style = fgSchedule.Styles["Normal"];
            //}

            // create headers for totals
            //int tmpTot;
            //tmpTot = (numWeeks * 3) + 3;
            //rng = fgSchedule.GetCellRange(0, tmpTot, 0,tmpTot + 2);
            //rng.Data = "Project Totals";
            //fgSchedule[1, tmpTot] = PLANCOLTITLE;
            //fgSchedule[1, tmpTot + 1] = FORECOLTITLE;
            //fgSchedule[1, tmpTot + 2] = ACTLCOLTITLE;

            //fgSchedule.Cols[tmpTot].Style = fgSchedule.Styles["TotalValStyle"];
            //fgSchedule.Cols[tmpTot + 1].Style = fgSchedule.Styles["TotalValStyle"];
            //fgSchedule.Cols[tmpTot + 2].Style = fgSchedule.Styles["TotalValStyle"];
            #endregion
        }

        private void CreateSubtotals()
        {
            int tmpTot;

            //fgSchedule.Subtotal(AggregateEnum.Clear);
            //fgSchedule.Sort(SortFlags.Ascending, 1);

            tmpTot = (mdsWeeks.Tables[0].Rows.Count * 3) + ROWTOTALCOLUMNS;

            for (int i = 0; i < tmpTot; i++)
            {
                fgSchedule.Subtotal(AggregateEnum.Sum, 0, 1, i + WEEKCOLSTART-2);
            }
        }

        private void dtpEnd_CloseUp(object sender, EventArgs e)
        {
            LoadTheGrid();
        }

        private void fgSchedule_AfterEdit(object sender, RowColEventArgs e)
        {
            SaveTimeChange(e.Row,e.Col);
            CreateSubtotals();
            SumRowHours(e.Row);
        }

        private void SumRowHours(int currRow)
        {
            decimal totP = 0;
            decimal totF = 0;

            foreach (Column c in fgSchedule.Cols)
            {
                if (Convert.ToString(c[1]) == PLANCOLTITLE)
                    totP += Convert.ToDecimal(fgSchedule[currRow, c.Index]);
                else if (Convert.ToString(c[1]) == FORECOLTITLE)
                    totF += Convert.ToDecimal(fgSchedule[currRow, c.Index]);
            }

            fgSchedule[currRow, EMPLOYEEPTOTCOL] = totP.ToString(HOURDISPLAYFORMAT);
            fgSchedule[currRow, EMPLOYEEFTOTCOL] = totF.ToString(HOURDISPLAYFORMAT);
        }

        private void chkActual_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActual.Checked == false)
                ChangeTimeColumnStatus(ACTLCOLTITLE, false);
            else
                ChangeTimeColumnStatus(ACTLCOLTITLE, true);
        }

        private void chkForcast_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForcast.Checked == false)
            {
                fgSchedule.Cols[EMPLOYEEFTOTCOL].Visible = false;
                ChangeTimeColumnStatus(FORECOLTITLE, false);
            }
            else
            {
                fgSchedule.Cols[EMPLOYEEFTOTCOL].Visible = true;
                ChangeTimeColumnStatus(FORECOLTITLE, true);
            }
        }

        private void chkPlan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlan.Checked == false)
            {
                fgSchedule.Cols[EMPLOYEEPTOTCOL].Visible = false;
                ChangeTimeColumnStatus(PLANCOLTITLE, false);
            }
            else
            {
                fgSchedule.Cols[EMPLOYEEPTOTCOL].Visible = true;

                ChangeTimeColumnStatus(PLANCOLTITLE, true);
            }
        }

        private void ChangeTimeColumnStatus(string colPrefix, bool visible)
        {
            foreach (Column c in fgSchedule.Cols)
            {
                if (Convert.ToString(c[1]) == colPrefix)
                    c.Visible = visible;
            }

            SetMinimumTimeWidths();
        }

        private void SetMinimumTimeWidths()
        {
            int colCnt;

            colCnt = 0;
            if (chkPlan.Checked == true)
                colCnt++;

            if (chkForcast.Checked == true)
                colCnt++;

            if (chkActual.Checked == true)
                colCnt++;

            switch (colCnt)
            {
                case 1:
                    fgSchedule.AutoSizeCols(WEEKCOLSTART, fgSchedule.Cols.Count - 1, 60);
                    break;
                case 2:
                    fgSchedule.AutoSizeCols(WEEKCOLSTART, fgSchedule.Cols.Count - 1, 20);
                    break;
                default:
                    fgSchedule.AutoSizeCols(WEEKCOLSTART, fgSchedule.Cols.Count - 1, 15);
                    break;
            }
        }

        private void mnuSch_AddProject_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.IsSelectOnly = true;
            pl.OnItemSelected += new RSLib.ListItemAction(pl_OnItemSelected);
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(pl_OnItemSelected);

            pl.Close();
        }

        void pl_OnItemSelected(int itmID)
        {
            FScd_AddProjEmp ape;

            ape = new FScd_AddProjEmp(miCurrDept,itmID);
            ape.OnProjectAdd += new ProjectEmployeeSelect(ape_OnProjectAdd);
            ape.ShowDialog();
            ape.OnProjectAdd -= new ProjectEmployeeSelect(ape_OnProjectAdd);

            ape.Close();
        }

        void ape_OnProjectAdd(int projID, int empID)
        {
            CBProject p = new CBProject();
            CBEmployee e = new CBEmployee();
            CBProjectEmployee pe = new CBProjectEmployee();
            Row r;

            bool addEmp = IsClearToAdd(projID, empID);

            if (addEmp == false)        // employee already exist for this project so do not add
                return;

            p.Load(projID);
            e.Load(empID);
            pe.ProjectID = projID;
            pe.EmployeeID = empID;
            pe.DepartmentID = miCurrDept;
            pe.Save();

            r = fgSchedule.Rows.Add();
            if (miCurrSort == 1)
            {
                r[1] = p.Number;
                r[2] = p.Description;
                r[3] = e.Name;
                r[PROJECTIDCOLUMN] = p.ID.ToString();
                r[EMPLOYEEIDCOLUMN] = e.ID.ToString();
            }
            else
            {
                r[1] = e.Name;
                r[2] = p.Number;
                r[3] = p.Description;
                r[PROJECTIDCOLUMN] = p.ID.ToString();
                r[EMPLOYEEIDCOLUMN] = e.ID.ToString();
            }

            CreateSubtotals();
        }

        private void tmrInit_Tick(object sender, EventArgs e)
        {
            LoadInitialSchedule();
        }

        private void LoadInitialSchedule()
        {
            COAppState aps = new COAppState();
            CBDepartment d;

            tmrInit.Enabled = false;

            aps.InitAppSettings();

            if (aps.Sch_LastDeptID > 0)
            {
                d = new CBDepartment();
                d.Load(aps.Sch_LastDeptID);
                txtDepartment.Text = d.Description;
                miCurrDept = aps.Sch_LastDeptID;
            }

            dtpStart.Value = aps.Sch_LastStartDate;
            dtpEnd.Value = aps.Sch_LastEndDate;
            HOURDISPLAYFORMAT = aps.Sch_HrDisplay;

            SetGridByDateRange(aps.Sch_LastStartDate, aps.Sch_LastEndDate);

            SetAccessForSecurityLevel(miCurrDept);

            //chkPlan.Checked = false;
            chkForcast.Checked = false;
            chkActual.Checked = false;

            mbShowPlanned = true;
            mbShowForecast = false;
            mbShowActual = false;
        }

        private void tbcGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int oldSort;

            //if (tbcGroupBy.SelectedIndex == 0)        // code in here for the all employee tab
            //    tbcGroupBy.SelectedIndex = 1;

            oldSort = miCurrSort;
            miCurrSort = tbcGroupBy.SelectedIndex;

            if (miCurrSort != oldSort)
            {
                SwapSortColumns(oldSort);
                fgSchedule.Subtotal(AggregateEnum.Clear);
                fgSchedule.Sort(SortFlags.Ascending, 1);
                CreateSubtotals();
            }
        }

        private void SwapSortColumns(int oldSort)
        {
            if (meCurrSort == SchdSortType.enProjectSort)
            {
                fgSchedule.Cols[EMPLOYEECOLUMN].Move(1);
                meCurrSort = SchdSortType.enEmployeeSort;
            }
            else
            {
                fgSchedule.Cols[1].Move(3);
                meCurrSort = SchdSortType.enProjectSort;
            }

            //fgSchedule.Cols[1].Move(2);
        }

        private void mnuSch_ProjSummary_Click(object sender, EventArgs e)
        {
            OpenSummaryWindow();
        }

        void ps_OnSummaryClose(object sender, EventArgs e)
        {
            mbSummaryOpen = false;

            mnuSch_ProjSummary.Enabled = true;
            tsbShowSummary.Enabled = true;
        }

        private void fgSchedule_Click(object sender, EventArgs e)
        {

        }

        private void fgSchedule_SelChange(object sender, EventArgs e)
        {
            if (fgSchedule.Row >= 0)
            {
                int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

                if (projID > 0 && mbIsModerator == true)
                    tsbAddEmployye.Enabled = true;
                else
                    tsbAddEmployye.Enabled = false;
            }
            else
            {
                tsbAddEmployye.Enabled = false;
            }
        }

        private void fgSchedule_RowColChange(object sender, EventArgs e)
        {
            if (mbSummaryOpen == true)
            {
                int row = fgSchedule.Row;

                if (row < 0)
                    return;     // not in a valid area so exit

                int projID = Convert.ToInt32(fgSchedule[row, PROJECTIDCOLUMN]);
                CellRange rng = fgSchedule.GetCellRange(0,fgSchedule.Col);
                int weekID = Convert.ToInt32(rng.UserData);
                
                decimal tmpP, tmpF, tmpA;
                CBScheduleHour sh = new CBScheduleHour();
                tmpP = tmpF = tmpA = 0;
                sh.GetProjectTotalByDate(miCurrDept, projID, weekID, ref tmpP, ref tmpF, ref tmpA);
                moProjSumm.SetProject(miCurrDept, projID, weekID, tmpP, tmpF, tmpA);
            }
        }

        private void SaveTimeChange(int rowIndx, int colIndx)
        {
            int projID, empID, weekID;
            decimal val;
            Column c;
            string colTitle;
            CBScheduleHour.HourTypeEnum hType;

            projID = Convert.ToInt32(fgSchedule[rowIndx, PROJECTIDCOLUMN]);
            empID = Convert.ToInt32(fgSchedule[rowIndx, EMPLOYEEIDCOLUMN]);
            c = fgSchedule.Cols[colIndx];
            weekID = Convert.ToInt32(c.UserData);
            colTitle = fgSchedule[1, colIndx].ToString();           // second row in grid should contain values for hour type
            val = Convert.ToInt32(fgSchedule[rowIndx, colIndx]);

            //SaveTimeChange(projID, empID, weekID, HourTypeEnum.enPlanning, );
            CBScheduleHour sh = new CBScheduleHour();

            sh.DepartmentID = miCurrDept;
            sh.ProjectID = projID;
            sh.EmployeeID = empID;
            sh.WeekID = weekID;

            switch (colTitle)
            {
                case FORECOLTITLE:
                    sh.FHrs = val;
                    hType = CBScheduleHour.HourTypeEnum.enForecast;
                    break;
                case ACTLCOLTITLE:
                    sh.AHrs = val;
                    hType = CBScheduleHour.HourTypeEnum.enActual;
                    break;
                default:
                    sh.PHrs = val;
                    hType = CBScheduleHour.HourTypeEnum.enPlanning;
                    break;
            }

            sh.Save(hType);

            // start thread to check on time warning
            CheckEmployeeForHoursWarning(empID, weekID, hType);

            if (mbSummaryOpen == true)
            {
                decimal tmpP, tmpF, tmpA;
                tmpP = tmpF = tmpA = 0;
                sh.GetProjectTotalByDate(miCurrDept, projID, weekID, ref tmpP, ref tmpF, ref tmpA);
                moProjSumm.SetProject(miCurrDept, projID, weekID, tmpP, tmpF, tmpA);
            }
        }

        private void FScd_AddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save current settings on exit
            COAppState aps = new COAppState();

            aps.InitAppSettings();
            aps.Sch_LastDeptID = miCurrDept;
            aps.Sch_LastStartDate = dtpStart.Value;
            aps.Sch_LastEndDate = dtpEnd.Value;
            aps.Sch_ViewPlan = chkPlan.Checked;
            aps.Sch_ViewFore = chkForcast.Checked;
            aps.Sch_ViewActl = chkActual.Checked;
            aps.Sch_SortType = miCurrSort;
            aps.Sch_HrDisplay = HOURDISPLAYFORMAT;
            aps.SaveAppSettings();

            if (mbSummaryOpen == true)
                // close the summary
                moProjSumm.Close();

            if (OnScheduleClose != null)
                OnScheduleClose(this, null);
        }

        private void LoadGridByRange(int deptID, DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            Row rw;
            int wkID;
            string lineCode;
            string tmpCode;

            //dr = CBScheduleHour.GetListByRange(deptID, sDate, eDate);
            dr = CBProjectEmployee.GetListActiveWithHours(deptID, sDate, eDate);

            this.Cursor = Cursors.WaitCursor;

            ClearCurrentGrid();
            lineCode = "";
            rw = fgSchedule.Rows[0];

            while (dr.Read())
            {
                tmpCode = dr["ProjectID"].ToString() + "-" + dr["EmployeeID"].ToString();

                if (lineCode != tmpCode)
                {
                    lineCode = tmpCode;
                    rw = fgSchedule.Rows.Add();

                    if (miCurrSort == 1)
                    {
                        rw[1] = dr["ProjectNumber"].ToString();
                        rw[2] = dr["ProjectDescription"].ToString();
                        rw[3] = dr["EmployeeName"].ToString();
                        rw[4] = dr["ProjectID"].ToString();
                        rw[5] = dr["VisionEmployeeID"].ToString();
                        rw[6] = dr["EmployeeID"].ToString();
                    }
                    else
                    {
                        rw[1] = dr["EmployeeName"].ToString();
                        rw[2] = dr["ProjectNumber"].ToString();
                        rw[3] = dr["ProjectDescription"].ToString();
                        rw[4] = dr["ProjectID"].ToString();
                        rw[5] = dr["EmployeeID"].ToString();
                    }
                }

                wkID = Convert.ToInt32(dr["WeekID"]);
                if (wkID > 0)
                {
                    SetScheduleValue(rw.Index, wkID, Convert.ToDecimal(dr["PHrs"]), Convert.ToInt32(dr["PWarn"]), Convert.ToDecimal(dr["FHrs"]), Convert.ToInt32(dr["FWarn"]), Convert.ToDecimal(dr["AHrs"]));
                }
            }

            dr.Close();

            SumAllRowHours();

            fgSchedule.Subtotal(AggregateEnum.Clear);
            fgSchedule.Sort(SortFlags.Ascending, 1);
            CreateSubtotals();

            this.Cursor = Cursors.Default;
        }

        private void SumAllRowHours()
        {
            foreach (Row r in fgSchedule.Rows)
            {
                if (r.Index > 1)
                    SumRowHours(r.Index);
            }
        }

        private void SetScheduleValue(int rwIndx, int weekID, decimal pHrs, int pWarn, decimal fHrs, int fWarn, decimal aHrs)
        {
            string colCode;
            CellRange rng;
            Column col;

            if (pHrs > 0)
            {
                colCode = weekID.ToString() + "-" + PLANCOLTITLE;
                fgSchedule[rwIndx, colCode] = pHrs.ToString(HOURDISPLAYFORMAT);
                col = fgSchedule.Cols[colCode];
                rng = fgSchedule.GetCellRange(rwIndx, col.Index);
                switch (pWarn)
                {
                    case -1:
                        rng.Style = fgSchedule.Styles[CELLSTYLEUNDER];
                        break;
                    case 1:
                        rng.Style = fgSchedule.Styles[CELLSTYLEOVER];
                        break;
                    case 2:
                        rng.Style = fgSchedule.Styles[CELLSTYLEMAX];
                        break;
                    default:
                        //rng.Style = fgSchedule.Styles["Normal"];
                        rng.Style = fgSchedule.Styles[CELLSTYLEREG];
                        break;
                }
            }

            if (fHrs > 0)
            {
                colCode = weekID.ToString() + "-" + FORECOLTITLE;
                fgSchedule[rwIndx, colCode] = fHrs.ToString(HOURDISPLAYFORMAT);
                col = fgSchedule.Cols[colCode];
                rng = fgSchedule.GetCellRange(rwIndx, col.Index);
                switch (fWarn)
                {
                    case -1:
                        rng.Style = fgSchedule.Styles[CELLSTYLEUNDER];
                        break;
                    case 1:
                        rng.Style = fgSchedule.Styles[CELLSTYLEOVER];
                        break;
                    case 2:
                        rng.Style = fgSchedule.Styles[CELLSTYLEMAX];
                        break;
                    default:
                        rng.Style = fgSchedule.Styles["Normal"];
                        break;
                }
            }

            if (aHrs > 0)
            {
                colCode = weekID.ToString() + "-" + ACTLCOLTITLE;
                fgSchedule[rwIndx, colCode] = aHrs.ToString(HOURDISPLAYFORMAT);
                col = fgSchedule.Cols[colCode];
                col.AllowEditing = false;
            }
        }

        private void ClearCurrentGrid()
        {
            int rwCnt;

            rwCnt = fgSchedule.Rows.Count;

            while (rwCnt > 2)
            {
                fgSchedule.Rows.Remove(rwCnt - 1);
                rwCnt--;
            }
        }

        #region Crazy nonsense to update warning colors
        private void CheckEmployeeForHoursWarning(int empID, int weekID, CBScheduleHour.HourTypeEnum hte)
        {
            CBHoursWarning hw = new CBHoursWarning();

            hw.SetWarningVals(empID, weekID, hte);
            hw.OnHoursWarning = new HoursWarningThread(this.SetWarningLevelForEmployee);

            Thread t = new Thread(new ThreadStart(hw.CheckCurrentHours));
            t.IsBackground = true;
            t.Start();
        }

        private void SetWarningLevelForEmployee(COScheduleHour.GridHoursLevel hrsLvl)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new CHANGEVALFORHOURS(this.SetLevelsInGrid), new Object[] { hrsLvl });
            }
            else
            {
                this.SetLevelsInGrid(hrsLvl);
            }
        }

        private void SetLevelsInGrid(COScheduleHour.GridHoursLevel hrsLvl)
        {
            int empRow;
            string colTitle;
            CellRange rng;
            Column col;

            if (hrsLvl.HrsType == COScheduleHour.ScheduleHourType.enForecast)
            {
                colTitle = hrsLvl.WeekID.ToString() + "-" + FORECOLTITLE;
            }
            else
            {
                colTitle = hrsLvl.WeekID.ToString() + "-" + PLANCOLTITLE;
            }

            col = fgSchedule.Cols[colTitle];
            empRow = fgSchedule.FindRow(hrsLvl.EmployeeID.ToString(), 0, EMPLOYEEIDCOLUMN, false, true, false);
            while (empRow > 0)
            {
                rng = fgSchedule.GetCellRange(empRow, col.Index);
                if (rng.Data != null)
                {
                    switch (hrsLvl.WarnLvl)
                    {
                        case -1:
                            rng.Style = fgSchedule.Styles[CELLSTYLEUNDER];
                            break;
                        case 1:
                            rng.Style = fgSchedule.Styles[CELLSTYLEOVER];
                            break;
                        case 2:
                            rng.Style = fgSchedule.Styles[CELLSTYLEMAX];
                            break;
                        default:
                            rng.Style = fgSchedule.Styles[CELLSTYLEREG];
                            break;
                    }
                }
                else
                {
                    rng.Style = fgSchedule.Styles["Normal"];
                }

                empRow = fgSchedule.FindRow(hrsLvl.EmployeeID.ToString(), empRow + 1, EMPLOYEEIDCOLUMN, false, true, false);
            }
        }
        #endregion

        private void dtpStart_CloseUp(object sender, EventArgs e)
        {
            LoadTheGrid();
        }

        private void LoadTheGrid()
        {
            DateTime s;
            DateTime ed;

            mbShowPlanned = chkPlan.Checked;
            mbShowForecast = chkForcast.Checked;
            mbShowActual = chkActual.Checked;

            chkPlan.Checked = true;
            chkForcast.Checked = true;
            chkActual.Checked = true;

            s = dtpStart.Value;
            ed = dtpEnd.Value;

            if (ed < s)
            {
                dtpEnd.Value = s.AddMonths(1);
                ed = s.AddMonths(1);
            }

            SetGridByDateRange(s, ed);

            chkPlan.Checked = mbShowPlanned;
            chkForcast.Checked = mbShowForecast;
            chkActual.Checked = mbShowActual;
        }

        private void tsbHoursDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            HOURDISPLAYFORMAT = ((RSLib.COListItem)tsbHoursDisp.SelectedItem).Meta;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAddProject_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.IsSelectOnly = true;
            pl.OnItemSelected += new RSLib.ListItemAction(pl_OnItemSelected);
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(pl_OnItemSelected);

            pl.Close();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            LoadTheGrid();
        }

        private void tsbShowSummary_Click(object sender, EventArgs e)
        {
            OpenSummaryWindow();
        }

        private void OpenSummaryWindow()
        {
            if (mbSummaryOpen == false)
            {
                moProjSumm = new FScd_ProjSummary();

                mbSummaryOpen = true;
                moProjSumm.OnSummaryClose += new EventHandler(ps_OnSummaryClose);
                moProjSumm.Show();

                mnuSch_ProjSummary.Enabled = false;
                tsbShowSummary.Enabled = false;
            }
        }

        private bool IsClearToAdd(int projID, int empID)
        {
            bool retVal;
            int prjCnt, empCnt;
            bool found;

            found = false;
            empCnt = -1;
            prjCnt = 0;
            while (prjCnt >= 0)
            {
                prjCnt = fgSchedule.FindRow(projID.ToString(), prjCnt + 1, PROJECTIDCOLUMN, false);

                if (prjCnt >= 0)
                    empCnt = Convert.ToInt32(fgSchedule[prjCnt,EMPLOYEEIDCOLUMN]);

                if (empCnt == empID)
                {
                    found = true;
                    break;
                }
            }

            if (found == true)
                retVal = false;
            else
                retVal = true;

            return retVal;
        }

        private void mnuSch_AddEmployee_Click(object sender, EventArgs e)
        {
           
            FEmp_List el = new FEmp_List();

            el.IsSelectOnly = true;
            el.DeptFilter = miCurrDept;
            el.OnItemSelected += new RSLib.ListItemAction(el_OnItemSelected);
            el.ShowDialog();
            el.OnItemSelected -= new RSLib.ListItemAction(el_OnItemSelected);

            el.Close();
        }

        void el_OnItemSelected(int itmID)
        {
            CBProject p = new CBProject();
            CBEmployee e = new CBEmployee();
            CBProjectEmployee pe = new CBProjectEmployee();
            Row r;

            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            bool addEmp = IsClearToAdd(projID, itmID);

            if (addEmp == false)        // employee already exist for this project so do not add
                return;

            p.Load(projID);
            e.Load(itmID);
            pe.ProjectID = projID;
            pe.EmployeeID = itmID;
            pe.DepartmentID = miCurrDept;
            pe.Save();

            //r = fgSchedule.Rows.Add();
            r = fgSchedule.Rows.Insert(fgSchedule.Row + 1);
            if (miCurrSort == 1)
            {
                r[1] = p.Number;
                r[2] = p.Description;
                r[3] = e.Name;
                r[PROJECTIDCOLUMN] = p.ID.ToString();
                r[EMPLOYEEIDCOLUMN] = e.ID.ToString();
            }
            else
            {
                r[1] = e.Name;
                r[2] = p.Number;
                r[3] = p.Description;
                r[PROJECTIDCOLUMN] = p.ID.ToString();
                r[EMPLOYEEIDCOLUMN] = e.ID.ToString();
            }

            CreateSubtotals();
        }

        private void mnuSch_RmvProject_Click(object sender, EventArgs e)
        {
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);
            string projName = fgSchedule[fgSchedule.Row, PROJECTCOLUMN].ToString();

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove project " + projName + "\n.  Schedule information will be lost.", "Remove Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBProject.DeleteFromSchedule(projID, miCurrDept);

                LoadTheGrid();
            }
        }

        private void mnuSch_RmvEmployee_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove employee " + empName + "\n from project " + projName + " Schedule information will be lost.", "Remove Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBProjectEmployee.Delete(projID, empID, miCurrDept);

                fgSchedule.Rows.Remove(fgSchedule.Row);

                CreateSubtotals();
            }
        }

        private void mnuSch_SwapEmployee_Click(object sender, EventArgs e)
        {
            FScd_EmpSwap es = new FScd_EmpSwap();

            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);

            es.SetCurrentEmployee(empID);
            es.OnSwapEmployee += new RSLib.ListItemAction(es_OnSwapEmployee);
            es.ShowDialog();
            es.OnSwapEmployee -= new RSLib.ListItemAction(es_OnSwapEmployee);

            es.Close();
        }

        void es_OnSwapEmployee(int itmID)
        {
            CBEmployee e = new CBEmployee();
            CBProjectEmployee pe = new CBProjectEmployee();

            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            bool addEmp = IsClearToAdd(projID, itmID);

            if (addEmp == false)        // employee already exist for this project so do not add
            {
                MessageBox.Show("This employee already exist in this project, swap will be cancelled");
                return;
            }

            e.Load(itmID);
            CBProjectEmployee.Swap(projID, empID, miCurrDept, itmID);

            if (miCurrSort == 1)
            {
                fgSchedule[fgSchedule.Row, EMPLOYEECOLUMN] = e.Name;
                fgSchedule[fgSchedule.Row,EMPLOYEEIDCOLUMN] = e.ID.ToString();
            }
            else
            {
                fgSchedule[fgSchedule.Row,1] = e.Name;
                fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN] = e.ID.ToString();
            }

            CreateSubtotals();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument pd;

            pd = fgSchedule.PrintParameters.PrintDocument;
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.Margins.Left = 75;
            pd.DefaultPageSettings.Margins.Right = 75;
            pd.DefaultPageSettings.Margins.Top = 75;
            pd.DefaultPageSettings.Margins.Bottom = 75;
            
            fgSchedule.PrintGrid("Test Print", 
                PrintGridFlags.ShowPreviewDialog | PrintGridFlags.FitToPageWidth | PrintGridFlags.ShowPageSetupDialog,
                "Manpower Scheduling: " + txtDepartment.Text + "\t\t" + DateTime.Now.ToShortDateString(), "\t\tPage {0} of {1}");
        }

        private void InitPopupMenu()
        {
            int currProj;
            int currEmp;
            int weekID;

            if (fgSchedule.Row < 0)
                return;

            Column c = fgSchedule.Cols[fgSchedule.Col];
            weekID = Convert.ToInt32(c.UserData);
            currProj = Convert.ToInt32(fgSchedule[fgSchedule.Row,PROJECTIDCOLUMN]);
            currEmp = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);

            if (miCurrSort == 1)
            {
                mnuSch_AddProject.Enabled = true;

                if (currProj > 0)
                {
                    mnuSch_RmvProject.Enabled = true;
                    mnuSch_AddEmployee.Enabled = true;
                }
                else
                {
                    mnuSch_RmvProject.Enabled = false;
                    mnuSch_AddEmployee.Enabled = false;
                }

                if (currEmp > 0)
                {
                    mnuSch_RmvEmployee.Enabled = true;
                    mnuSch_SwapEmployee.Enabled = true;
                }
                else
                {
                    mnuSch_RmvEmployee.Enabled = false;
                    mnuSch_SwapEmployee.Enabled = false;
                }
            }
            else
            {
                mnuSch_AddProject.Enabled = true;
                mnuSch_RmvProject.Enabled = false;
                mnuSch_AddEmployee.Enabled = false;

                if (currEmp > 0)
                {
                    mnuSch_RmvEmployee.Enabled = true;
                    mnuSch_SwapEmployee.Enabled = true;
                }
                else
                {
                    mnuSch_RmvEmployee.Enabled = false;
                    mnuSch_SwapEmployee.Enabled = false;
                }
            }

            //CBWeekList wl = new CBWeekList();
            //if (wl.IsCurrentPlus(weekID) == true)
            //{
            //    mnuMoveEmpOut.Enabled = true;
            //    mnuMoveAllEmpTime.Enabled = true;
            //}
            //else
            //{
            //    mnuMoveEmpOut.Enabled = false;
            //    mnuMoveAllEmpTime.Enabled = false;
            //}
        }

        private void cmnuSchedule_Opening(object sender, CancelEventArgs e)
        {
            InitPopupMenu();
        }

        private void tsbSaveAsExcel_Click(object sender, EventArgs e)
        {
            string newFile;

            DialogResult sf = saveFileDialog1.ShowDialog();

            if (sf != DialogResult.Cancel)
            {
                newFile = saveFileDialog1.FileName;

                try
                {
                    fgSchedule.SaveExcel(newFile, "Manpower", FileFlags.IncludeFixedCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save file: " + ex.Message, "Save File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbExpand_Click(object sender, EventArgs e)
        {
            fgSchedule.Tree.Show(1);
        }

        private void tsbCollapse_Click(object sender, EventArgs e)
        {
            fgSchedule.Tree.Show(0);
        }


        private void SetAccessForSecurityLevel(int deptID)
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();
            decimal passLvl;
            //int deptid;

            sec.InitAppSettings();
            u.Load(sec.UserID);
            passLvl = CBUserLevel.GetLevelForDepartment(u.ID, deptID);

            // enable everything in case of change
            tsbAddProject.Enabled = true;
            tsbAddEmployye.Enabled = true;
            cmnuSchedule.Enabled = true;
            fgSchedule.AllowEditing = true;


            miCurrUserID = u.ID;
            if (passLvl != 3 || u.IsAdministrator == true || u.IsManager == true)
            {
                // is a moderator for this department so enable some stuff
                mbIsModerator = true;
            }
            else
            {
                mbIsModerator = false;

                tsbAddProject.Enabled = false;
                tsbAddEmployye.Enabled = false;
                cmnuSchedule.Enabled = false;

                fgSchedule.AllowEditing = false;
            }
        }

        private void tsbAddEmployye_Click(object sender, EventArgs e)
        {
            FEmp_List el = new FEmp_List();

            el.IsSelectOnly = true;
            el.DeptFilter = miCurrDept;
            el.OnItemSelected += new RSLib.ListItemAction(el_OnItemSelected);
            el.ShowDialog();
            el.OnItemSelected -= new RSLib.ListItemAction(el_OnItemSelected);

            el.Close();
        }

        private void fgSchedule_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
        }

        private void bttTest_Click(object sender, EventArgs e)
        {
            //fgSchedule.Sort(SortFlags.Ascending, 1);
            fgSchedule.Tree.Sort(0, SortFlags.Ascending, 1 , 1);
        }

        private void mnuShowProjAllDepts_Click(object sender, EventArgs e)
        {
            FScd_AllDepts f = new FScd_AllDepts();

            f.ShowDialog();
            f.Close();
        }

        private void mnuMove1Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + empName + "\n time out 1 week on " + projName, "Move Employee Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveEmployeeTimeByWeek(miCurrDept, projID, empID, weekID, 1);

                LoadTheGrid();
            }
        }

        private void mnuMove2Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + empName + "\n time out 2 weeks on " + projName, "Move Employee Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveEmployeeTimeByWeek(miCurrDept, projID, empID, weekID, 2);

                LoadTheGrid();
            }
        }

        private void mnuMove3Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + empName + "\n time out 3 weeks on " + projName, "Move Employee Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveEmployeeTimeByWeek(miCurrDept, projID, empID, weekID, 3);

                LoadTheGrid();
            }
        }

        private void mnuMove4Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + empName + "\n time out 4 weeks on " + projName, "Move Employee Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveEmployeeTimeByWeek(miCurrDept, projID, empID, weekID, 4);

                LoadTheGrid();
            }
        }

        private void mnuMoveOtherWeek_Click(object sender, EventArgs e)
        {
            FWeekCount wc = new FWeekCount();

            wc.OnWeekCount += new RSLib.ItemReturnAction(wc_OnWeekCount);
            wc.ShowDialog();
            wc.OnWeekCount -= new RSLib.ItemReturnAction(wc_OnWeekCount);
        }

        void wc_OnWeekCount(int itmID, string description)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + empName + "\n time out " + itmID.ToString() + " weeks on " + projName, "Move Employee Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveEmployeeTimeByWeek(miCurrDept, projID, empID, weekID, itmID);

                LoadTheGrid();
            }
        }

        private void mnuMoveAll1Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + projName + "\n time out 1 week for everyone", "Move Project Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveAllTimeByWeek(miCurrDept, projID, empID, 1);

                LoadTheGrid();
            }
        }

        private void mnuMoveAll2Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + projName + "\n time out 2 weeks for everyone", "Move Project Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveAllTimeByWeek(miCurrDept, projID, empID, 2);

                LoadTheGrid();
            }
        }

        private void mnuMoveAll3Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + projName + "\n time out 3 weeks for everyone", "Move Project Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveAllTimeByWeek(miCurrDept, projID, empID, 3);

                LoadTheGrid();
            }
        }

        private void mnuMoveAll4Week_Click(object sender, EventArgs e)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + projName + "\n time out 4 weeks for everyone", "Move Project Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveAllTimeByWeek(miCurrDept, projID, empID, 4);

                LoadTheGrid();
            }
        }

        private void mnuMoveAllOtherWeek_Click(object sender, EventArgs e)
        {
            FWeekCount wc = new FWeekCount();

            wc.OnWeekCount += new RSLib.ItemReturnAction(wc_OnWeekCountAll);
            wc.ShowDialog();
            wc.OnWeekCount -= new RSLib.ItemReturnAction(wc_OnWeekCountAll);
        }

        void wc_OnWeekCountAll(int itmID, string description)
        {
            string empName;
            string projName;
            Column c = fgSchedule.Cols[fgSchedule.Col];
            int weekID = Convert.ToInt32(c.UserData);
            int empID = Convert.ToInt32(fgSchedule[fgSchedule.Row, EMPLOYEEIDCOLUMN]);
            int projID = Convert.ToInt32(fgSchedule[fgSchedule.Row, PROJECTIDCOLUMN]);

            if (miCurrSort == 1)
            {
                projName = fgSchedule[fgSchedule.Row, 1].ToString();
                empName = fgSchedule[fgSchedule.Row, 3].ToString();
            }
            else
            {
                projName = fgSchedule[fgSchedule.Row, 2].ToString();
                empName = fgSchedule[fgSchedule.Row, 1].ToString();
            }

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to move "
                + projName + "\n time out " + itmID.ToString() + " weeks for everyone", "Move Project Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                CBScheduleHour.MoveAllTimeByWeek(miCurrDept, projID, empID, itmID);

                LoadTheGrid();
            }

        }

        private void fgSchedule_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col < 1)
                return;

            string colTitle = fgSchedule[1, e.Col].ToString();

            if (colTitle == ACTLCOLTITLE)
            {
                e.Cancel = true;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}