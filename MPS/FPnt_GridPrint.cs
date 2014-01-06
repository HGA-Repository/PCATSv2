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
    public partial class FPnt_GridPrint : Form
    {
        private const int WEEKCOLSTART = 6;
        private const int TOTALCOLS = 0;
        private const string PLANCOLTITLE = "P";
        private const string FORECOLTITLE = "F";
        private const string ACTLCOLTITLE = "A";

        private const string CELLSTYLEUNDER = "CellStyleUnder";
        private const string CELLSTYLEOVER = "CellStyleOver";
        private const string CELLSTYLEMAX = "CellStyleMax";

        private const int PROJECTIDCOLUMN = 4;
        private const int EMPLOYEEIDCOLUMN = 5;

        private String HOURDISPLAYFORMAT = "#,##0";

        private Color WARNINGCOLORBELOW = Color.LightGreen;
        private Color WARNINGCOLORHIGH = Color.Yellow;
        private Color WARNINGCOLORMAX = Color.LightSalmon;

        private delegate void CHANGEVALFORHOURS(COScheduleHour.GridHoursLevel hrsLvl);

        private DataSet mdsWeeks;
        //private int miCurrDept;
        private int miCurrSort = 2;
        private int miStartWeekID;

        private bool mbListWork;

        public FPnt_GridPrint()
        {
            InitializeComponent();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDepartments()
        {
            RSLib.COListItem li;
            SqlDataReader dr;

            dr = CBDepartment.GetList();

            lstDepartments.Items.Clear();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "All";
            lstDepartments.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                lstDepartments.Items.Add(li);
            }

            lstDepartments.SetItemChecked(0, true);

            dr.Close();
        }

        private void LoadProjects()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            //SSS 20131105 dr = CBProject.GetList();
            dr = CBProject.GetListProj();

            lstProjects.Items.Clear();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "All";
            lstProjects.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Number"].ToString();

                lstProjects.Items.Add(li);
            }

            lstProjects.SetItemChecked(0, true);

            dr.Close();
        }

        private void LoadTheGrid()
        {
            DateTime s;
            DateTime ed;

            this.Cursor = Cursors.WaitCursor;

            s = dtpStart.Value;
            ed = dtpEnd.Value;

            if (ed < s)
            {
                dtpEnd.Value = s.AddMonths(1);
                ed = s.AddMonths(1);
            }

            SetGridByDateRange(s, ed, false, false);

            this.Cursor = Cursors.Default;
        }

        private void LoadTheGridForBoth()
        {
            DateTime s;
            DateTime ed;

            this.Cursor = Cursors.WaitCursor;

            s = dtpStart.Value;
            ed = dtpEnd.Value;

            if (ed < s)
            {
                dtpEnd.Value = s.AddMonths(1);
                ed = s.AddMonths(1);
            }

            SetGridByDateRange(s, ed, true, true);

            this.Cursor = Cursors.Default;
        }

        private void LoadTheGridForProj()
        {
            DateTime s;
            DateTime ed;

            this.Cursor = Cursors.WaitCursor;

            s = dtpStart.Value;
            ed = dtpEnd.Value;

            if (ed < s)
            {
                dtpEnd.Value = s.AddMonths(1);
                ed = s.AddMonths(1);
            }

            SetGridByDateRange(s, ed, false, true);

            this.Cursor = Cursors.Default;
        }

        private void LoadTheGridForDept()
        {
            DateTime s;
            DateTime ed;

            this.Cursor = Cursors.WaitCursor;

            s = dtpStart.Value;
            ed = dtpEnd.Value;

            if (ed < s)
            {
                dtpEnd.Value = s.AddMonths(1);
                ed = s.AddMonths(1);
            }

            SetGridByDateRange(s, ed, true, false);

            this.Cursor = Cursors.Default;
        }

        private void SetGridByDateRange(DateTime sDate, DateTime eDate, bool selDept, bool selProj)
        {
            int numWeeks;
            int numWeekCols;

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

            fgSchedule.Cols[1].Width = 100;
            fgSchedule.Cols[2].Width = 100;
            fgSchedule.Cols[3].Width = 100;

            CreateWeekHeaders();

            fgSchedule.Cols[0].AllowMerging = true;
            fgSchedule.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            fgSchedule.AutoSizeCols(6, fgSchedule.Cols.Count - 1, 15);

            LoadGridByRange(0, sDate, eDate, selDept, selProj);
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

                tmpCol = ((indx + 1) * 3) + 3;
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
                tmpCol = ((i + 1) * 3) + 3;
                fgSchedule[1, tmpCol] = PLANCOLTITLE;
                fgSchedule[1, tmpCol + 1] = FORECOLTITLE;
                fgSchedule[1, tmpCol + 2] = ACTLCOLTITLE;
            }
        }

        private void CreateSubtotals()
        {
            int tmpTot;

            fgSchedule.Subtotal(AggregateEnum.Clear);
            fgSchedule.Sort(SortFlags.Ascending, 1);

            tmpTot = (mdsWeeks.Tables[0].Rows.Count * 3);

            for (int i = 0; i < tmpTot; i++)
            {
                fgSchedule.Subtotal(AggregateEnum.Sum, 0, 1, i + 5);
                fgSchedule.Subtotal(AggregateEnum.Sum, 1, 2, i + 5);
            }

            //flex.Sort(SortFlags.Ascending, flex.Cols.Fixed, flex.Cols.Count - 1);
        }


        private void LoadGridByRange(int deptID, DateTime sDate, DateTime eDate, bool selDept, bool selProj)
        {
            SqlDataReader dr;
            Row rw;
            int wkID;
            string lineCode;
            string tmpCode;
            string oDeptXML;
            string oProjXML;

            oDeptXML = "";
            oProjXML = "";

            CreateDepartmentXMLList(ref oDeptXML);
            CreateProjectXMLList(ref oProjXML);

            if (rdoDEP.Checked == true)
            {
                if (miCurrSort != 2)
                {
                    fgSchedule.Cols[1].Move(3);
                    miCurrSort = 2;
                }

                if (selDept == true && selProj == true)
                {
                    dr = CBReportData.GetListByRangeDeptEmpProj(sDate, eDate, true, true, oDeptXML, oProjXML);
                }
                else if (selDept == true && selProj == false)
                {
                    dr = CBReportData.GetListByRangeDeptEmpProj(sDate, eDate, true, false, oDeptXML, "");
                }
                else if (selDept == false && selProj == true)
                {
                    dr = CBReportData.GetListByRangeDeptEmpProj(sDate, eDate, false, true, "", oProjXML);
                }
                else
                {
                    dr = CBReportData.GetListByRangeDeptEmpProj(sDate, eDate);
                }
            }
            else
            {
                if (miCurrSort == 2)
                {
                    fgSchedule.Cols[3].Move(1);
                    miCurrSort = 1;
                }

                if (selDept == true && selProj == true)
                {
                    dr = CBReportData.GetListByRangeProjDeptEmp(sDate, eDate, true, true, oDeptXML, oProjXML);
                }
                else if (selDept == true && selProj == false)
                {
                    dr = CBReportData.GetListByRangeProjDeptEmp(sDate, eDate, true, false, oDeptXML, "");
                }
                else if (selDept == false && selProj == true)
                {
                    dr = CBReportData.GetListByRangeProjDeptEmp(sDate, eDate, false, true, "", oProjXML);
                }
                else
                {
                    dr = CBReportData.GetListByRangeProjDeptEmp(sDate, eDate);
                }

            }

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

                    if (rdoDEP.Checked == true)
                    {
                        rw[1] = dr["Department"].ToString();
                        rw[2] = dr["EmployeeName"].ToString();
                        rw[3] = dr["ProjectNumber"].ToString();
                        rw[4] = dr["ProjectID"].ToString();
                        rw[5] = dr["EmployeeID"].ToString();
                    }
                    else
                    {
                        rw[1] = dr["ProjectNumber"].ToString();
                        rw[2] = dr["Department"].ToString();
                        rw[3] = dr["EmployeeName"].ToString();
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

            CreateSubtotals();
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
                        rng.Style = fgSchedule.Styles["Normal"];
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

        private void CreateDepartmentXMLList(ref string dXml)
        {
            DataSet ds;
            DataTable dt;
            DataRow dr;

            ds = new DataSet();
            dt = new DataTable("Dept");
            dt.Columns.Add("DeptID", Type.GetType("System.Int32"));

            foreach (Object o in lstDepartments.CheckedItems)
            {
                dr = dt.NewRow();
                dr["DeptID"] = ((RSLib.COListItem)o).ID;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            if (lstDepartments.CheckedItems.Count > 0)
                dXml = ds.GetXml();
            else
                dXml = "";
        }

        private void CreateProjectXMLList(ref string pXml)
        {
            DataSet ds;
            DataTable dt;
            DataRow dr;

            ds = new DataSet();
            dt = new DataTable("Proj");
            dt.Columns.Add("ProjID", Type.GetType("System.Int32"));

            foreach (Object o in lstProjects.CheckedItems)
            {
                dr = dt.NewRow();
                dr["ProjID"] = ((RSLib.COListItem)o).ID;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            if (lstProjects.CheckedItems.Count > 0)
                pXml = ds.GetXml();
            else
                pXml = "";
        }

        private void rdoDEP_CheckedChanged(object sender, EventArgs e)
        {
            //LoadTheGrid();
        }

        private void dtpStart_CloseUp(object sender, EventArgs e)
        {
            //LoadTheGrid();
        }

        private void dtpEnd_CloseUp(object sender, EventArgs e)
        {
            //LoadTheGrid();
        }

        private void bttPreview_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument pd;
            string currSort;

            if (lstDepartments.CheckedIndices.Contains(0) == false && lstProjects.CheckedIndices.Contains(0) == true)
                LoadTheGridForDept();
            else if (lstDepartments.CheckedIndices.Contains(0) == true && lstProjects.CheckedIndices.Contains(0) == false)
                LoadTheGridForProj();
            else if (lstDepartments.CheckedIndices.Contains(0) == false && lstProjects.CheckedIndices.Contains(0) == false)
                LoadTheGridForBoth();
            else
                LoadTheGrid();

            if (miCurrSort == 2)
                currSort = "Department, Employee, Project";
            else
                currSort = "Project, Department, Employee";

            pd = fgSchedule.PrintParameters.PrintDocument;
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.Margins.Left = 75;
            pd.DefaultPageSettings.Margins.Right = 75;
            pd.DefaultPageSettings.Margins.Top = 75;
            pd.DefaultPageSettings.Margins.Bottom = 75;

            if (chkPrintDialog.Checked == true)
            {
                fgSchedule.PrintGrid("Manpower Plan",
                    PrintGridFlags.ShowPreviewDialog | PrintGridFlags.FitToPageWidth | PrintGridFlags.ShowPageSetupDialog,
                    "Manpower Scheduling: " + currSort + "\t\t" + DateTime.Now.ToShortDateString(), "\t\tPage {0} of {1}");
            }
            else
            {
                fgSchedule.PrintGrid("Manpower Plan",
                    PrintGridFlags.ShowPreviewDialog | PrintGridFlags.FitToPageWidth,
                    "Manpower Scheduling: " + currSort + "\t\t" + DateTime.Now.ToShortDateString(), "\t\tPage {0} of {1}");
            }
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument pd;
            string currSort;

            if (lstDepartments.CheckedIndices.Contains(0) == false && lstProjects.CheckedIndices.Contains(0) == true)
                LoadTheGridForDept();
            else if (lstDepartments.CheckedIndices.Contains(0) == true && lstProjects.CheckedIndices.Contains(0) == false)
                LoadTheGridForProj();
            else if (lstDepartments.CheckedIndices.Contains(0) == false && lstProjects.CheckedIndices.Contains(0) == false)
                LoadTheGridForBoth();
            else
                LoadTheGrid();

            if (miCurrSort == 2)
                currSort = "Department, Employee, Project";
            else
                currSort = "Project, Department, Employee";

            pd = fgSchedule.PrintParameters.PrintDocument;
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.Margins.Left = 75;
            pd.DefaultPageSettings.Margins.Right = 75;
            pd.DefaultPageSettings.Margins.Top = 75;
            pd.DefaultPageSettings.Margins.Bottom = 75;

            if (chkPrintDialog.Checked == true)
            {
                fgSchedule.PrintGrid("Manpower Plan",
                    PrintGridFlags.FitToPageWidth | PrintGridFlags.ShowPageSetupDialog,
                    "Manpower Scheduling: " + currSort + "\t\t" + DateTime.Now.ToShortDateString(), "\t\tPage {0} of {1}");
            }
            else
            {
                fgSchedule.PrintGrid("Manpower Plan",
                    PrintGridFlags.FitToPageWidth,
                    "Manpower Scheduling: " + currSort + "\t\t" + DateTime.Now.ToShortDateString(), "\t\tPage {0} of {1}");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadDepartments();
            LoadProjects();
            //LoadTheGrid();
        }

        private void FPnt_GridPrint_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now.AddMonths(1);

            mbListWork = false;
            timer1.Enabled = true;
        }

        private void lstDepartments_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                mbListWork = true;
                lstDepartments.SetItemCheckState(0, CheckState.Unchecked);
                mbListWork = false;
            }
            else if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                if (mbListWork == true)
                    return;

                mbListWork = true;

                for (int i = 1; i < lstDepartments.Items.Count; i++)
                    lstDepartments.SetItemCheckState(i, CheckState.Unchecked);

                lstDepartments.SetItemChecked(0, true);

                mbListWork = false;
            }
            else if (e.Index == 0 && lstDepartments.CheckedItems.Count <= 1 && mbListWork == false)
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void lstProjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                mbListWork = true;
                lstProjects.SetItemCheckState(0, CheckState.Unchecked);
                mbListWork = false;
            }
            else if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                if (mbListWork == true)
                    return;

                mbListWork = true;

                for (int i = 1; i < lstProjects.Items.Count; i++)
                    lstProjects.SetItemCheckState(i, CheckState.Unchecked);

                lstProjects.SetItemChecked(0, true);

                mbListWork = false;
            }
            else if (e.Index == 0 && lstProjects.CheckedItems.Count <= 1 && mbListWork == false)
            {
                e.NewValue = CheckState.Checked;
            }
        }
    }
}