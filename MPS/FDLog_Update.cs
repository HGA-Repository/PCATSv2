using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C1.Win.C1FlexGrid;
using System.Data.SqlClient;

namespace RSMPS
{
    public partial class FDLog_Update : Form
    {
        private DataSet mdsUpdates;
        private int miCurrDept;
        private int miCurrProj;
        private string msCurrProj;
        private bool mbUseGroup;
        private int miCurrLead;
        private int miCurrUserID;
        //private bool mbIsModerator;

        //private int miTotCol = 0;

        public int ProjectID
        {
            get { return miCurrProj; }
            set
            {
                miCurrProj = value;
                CBProject p = new CBProject();
                p.Load(miCurrProj);
                msCurrProj = p.Number;

                sbProjects.Text = "for " + p.Number + "  " + p.Description;

                LoadDrawingList();
                LoadWBSCodesForFilter();
            }
        }

        public bool SetToUseGroups
        {
            set
            {
                if (value == true)
                {
                    mbUseGroup = true;
                    lblProjectLead.Visible = true;
                    txtProjectLead.Visible = true;
                    bttProjLead.Visible = true;

                    sbProjects.Text = "for Project Lead";

                    ttlbbSwitch.Enabled = false;
                }
                else
                {
                    mbUseGroup = false;
                    tdbgQuikUpdate.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Normal;
                    tdbgQuikUpdate.GroupedColumns.Clear();
                    lblProjectLead.Visible = false;
                    txtProjectLead.Visible = false;
                    bttProjLead.Visible = false;

                    ttlbbSwitch.Enabled = true;
                }
            }
        }

        public FDLog_Update()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            COAppState aps = new COAppState();
            CBDepartment d = new CBDepartment();

            aps.InitAppSettings();

            miCurrDept = aps.Sch_LastDeptID;
            miCurrLead = aps.Sch_EmplyID;
            d.Load(miCurrDept);
            txtDepartment.Text = d.Name;

            timer1.Enabled = true;

            CellStyle s = fgQuikUpdate.Styles.Add("ActualValues");
            s.ForeColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (mbUseGroup == true)
            {
                CBEmployee emp = new CBEmployee();
                emp.Load(miCurrLead);
                txtProjectLead.Text = emp.Name;

                LoadListForGrouping();
            }
        }

        private void TotalHours()
        {
            decimal budHrs;
            decimal erndHrs;
            decimal remHrs;
            decimal percComp;
            int drwCnt;

            budHrs = 0;
            erndHrs = 0;
            remHrs = 0;
            drwCnt = 0;

            foreach (DataRow dr in mdsUpdates.Tables[0].Rows)
            {
                budHrs += Convert.ToDecimal(dr["BudgetHrs"]);
                erndHrs += Convert.ToDecimal(dr["EarnedHrs"]);
                remHrs += Convert.ToDecimal(dr["RemainingHrs"]);

                if (Convert.ToBoolean(dr["IsTask"]) == false)
                {
                    drwCnt++;
                }
            }

            tdbgQuikUpdate.Columns[7].FooterText = budHrs.ToString("#,##0");
            tdbgQuikUpdate.Columns[9].FooterText = erndHrs.ToString("#,##0");
            tdbgQuikUpdate.Columns[10].FooterText = remHrs.ToString("#,##0");

            //string proj = tdbgQuikUpdate.Columns["Project"].Value.ToString();

            if (budHrs != 0)
            {
                percComp = (erndHrs / budHrs) * 100.0m;
            }
            else
            {
                percComp = 0;
            }

            tdbgQuikUpdate.Columns[8].FooterText = percComp.ToString("#,##0.00") + "%";
            sbDrawings.Text = drwCnt.ToString() + " Drawing(s)";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
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
            miCurrLead = 0;
            txtProjectLead.Text = "";

            LoadDrawingList();

            if (mbUseGroup == false)
                LoadGridWithDrawings();

            SetAccessForSecurityLevel(miCurrDept);
        }


        private void SetAccessForSecurityLevel(int deptID)
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();
            decimal passLvl;

            sec.InitAppSettings();
            u.Load(sec.UserID);
            passLvl = CBUserLevel.GetLevelForDepartment(u.ID, deptID);

            // enable everything in case of change
            tdbgQuikUpdate.EditActive = true;
            tdbgQuikUpdate.Enabled = true;
            
            miCurrUserID = u.ID;
            if (passLvl != 3 || u.IsAdministrator == true || u.IsManager == true)
            {
                // is a moderator for this department so enable some stuff
                //mbIsModerator = true;
            }
            else
            {
                //mbIsModerator = false;

                //tdbgQuikUpdate.EditActive = false;
                tdbgQuikUpdate.Enabled = false;
            }
        }
        private void LoadDrawingList()
        {
            mdsUpdates = CBDrawingLog.GetListbyDeptProjForUpdate(miCurrDept, miCurrProj, cboWBS.Text);

            tdbgQuikUpdate.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Normal;
            tdbgQuikUpdate.GroupedColumns.Clear();

            tdbgQuikUpdate.SetDataBinding(mdsUpdates, "Table", true);

            TotalHours();

            if (fgQuikUpdate.Visible)
                LoadGridWithDrawings();
        }

        private void LoadDrawingList(bool sortByCAD)
        {
            mdsUpdates = CBDrawingLog.GetListbyDeptProjForUpdate(miCurrDept, miCurrProj, cboWBS.Text, true);

            tdbgQuikUpdate.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Normal;
            tdbgQuikUpdate.GroupedColumns.Clear();

            tdbgQuikUpdate.SetDataBinding(mdsUpdates, "Table", true);

            TotalHours();

            if (fgQuikUpdate.Visible)
                LoadGridWithDrawings();
        }

        private void tdbgUpdate_AfterUpdate(object sender, EventArgs e)
        {
            DataRow dr = mdsUpdates.Tables[0].Rows[tdbgQuikUpdate.Bookmark];

            int tmpID;
            int tmpBM;
            decimal bHrs;
            decimal perc;
            decimal eHrs;
            decimal rHrs;

            tmpBM = tdbgQuikUpdate.Bookmark;

            // added to allow for the sort
            CurrencyManager cm;
            System.Data.DataView dv;
            System.Data.DataRowView drv;
            System.Data.DataRow dr2;
            int row;

            row = tdbgQuikUpdate.RowBookmark(tdbgQuikUpdate.Bookmark);
            cm = (CurrencyManager)this.BindingContext[tdbgQuikUpdate.DataSource, tdbgQuikUpdate.DataMember];
            dv = (DataView)cm.List;
            drv = (System.Data.DataRowView)cm.List[row];
            dr2 = drv.Row;

            tmpID = Convert.ToInt32(dr["ID"]);
            bHrs = Convert.ToDecimal(dr["BudgetHrs"]);
            rHrs = Convert.ToDecimal(dr["RemainingHrs"]);

            int tmpID2 = Convert.ToInt32(dr2["ID"]);
            decimal bHrs2 = Convert.ToDecimal(dr2["BudgetHrs"]);
            decimal rHrs2 = Convert.ToDecimal(dr2["RemainingHrs"]);

            perc = CBDrawingLog.GetPercentComplete(bHrs2, rHrs2);
            eHrs = CBDrawingLog.GetEarnedHrs(bHrs2, rHrs2);

            dr2["PercentComplete"] = perc;
            dr2["EarnedHrs"] = eHrs;

            CBDrawingLog.UpdateHours(tmpID2, bHrs2, perc, eHrs, rHrs2);

            //perc = CBDrawingLog.GetPercentComplete(bHrs, rHrs);
            //eHrs = CBDrawingLog.GetEarnedHrs(bHrs, rHrs);

            //dr["PercentComplete"] = perc;
            //dr["EarnedHrs"] = eHrs;

            //CBDrawingLog.UpdateHours(tmpID, bHrs, perc, eHrs, rHrs);

            TotalHours();
        }

        private void tdbgUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tdbgQuikUpdate.UpdateData();
        }

        private void tbbPrint_Click(object sender, EventArgs e)
        {
            CPDrawingLog dl = new CPDrawingLog();
            dl.PrintDrawingLog(miCurrDept, miCurrProj);
                       
        }

        private void tbbJobStatPrint_Click(object sender, EventArgs e)
        {
            CPDrawingLog dl = new CPDrawingLog();

            dl.PrintJobStat(miCurrDept, miCurrProj);
        }

        private void LoadListForGrouping()
        {
            mdsUpdates = CBDrawingLog.GetListByDeptLeadForUpdate(miCurrDept, miCurrLead);

            //tdbgQuikUpdate.GroupByAreaVisible = true;
            tdbgQuikUpdate.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy;
            tdbgQuikUpdate.GroupedColumns.Clear();

            tdbgQuikUpdate.SetDataBinding(mdsUpdates, "Table", true);

            tdbgQuikUpdate.GroupedColumns.Add(tdbgQuikUpdate.Columns["Project"]);
            tdbgQuikUpdate.Columns["Project"].GroupInfo.Interval = C1.Win.C1TrueDBGrid.GroupIntervalEnum.Custom;
            tdbgQuikUpdate.Columns["Project"].GroupInfo.ColumnVisible = true;

            TotalHours();
        }

        private void bttProjLead_Click(object sender, EventArgs e)
        {
            FEmp_List el = new FEmp_List();

            el.OnItemSelected += new RSLib.ListItemAction(NewProjectLead);
            el.IsSelectOnly = true;
            el.DeptFilter = miCurrDept;
            el.ShowDialog();
            el.OnItemSelected -= new RSLib.ListItemAction(NewProjectLead);
        }

        void NewProjectLead(int itmID)
        {
            CBEmployee e = new CBEmployee();

            e.Load(itmID);
            txtProjectLead.Text = e.Name;
            miCurrLead = itmID;

            // save new lead to file
            COAppState app = new COAppState();
            app.InitAppSettings();
            app.Sch_EmplyID = itmID;
            app.SaveAppSettings();

            LoadListForGrouping();
        }

        private void tdbgQuikUpdate_GroupInterval(object sender, C1.Win.C1TrueDBGrid.GroupIntervalEventArgs e)
        {
            if (mbUseGroup == true)
            {
                string s = ((string)tdbgQuikUpdate[e.Row,e.Col.DataColumn.DataField]);

                e.Value = s;
            }
        }

        private void bttTest_Click(object sender, EventArgs e)
        {
            tdbgQuikUpdate.GroupByAreaVisible = true;
            tdbgQuikUpdate.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy;
            tdbgQuikUpdate.GroupedColumns.Add(tdbgQuikUpdate.Columns["Project"]);
            tdbgQuikUpdate.Columns["Project"].GroupInfo.Interval = C1.Win.C1TrueDBGrid.GroupIntervalEnum.Custom;
            tdbgQuikUpdate.Columns["Project"].GroupInfo.ColumnVisible = true;
        }

        private void tdbgQuikUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tdbgQuikUpdate.UpdateData();
        }

        private void tdbgQuikUpdate_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            DataRow dr = mdsUpdates.Tables[0].Rows[tdbgQuikUpdate.Bookmark];

            int tmpID;
            int tmpBM;
            decimal bHrs;
            decimal perc;
            decimal eHrs;
            decimal rHrs;

            tmpBM = tdbgQuikUpdate.Bookmark;

            // added to allow for the sort
            CurrencyManager cm;
            System.Data.DataView dv;
            System.Data.DataRowView drv;
            System.Data.DataRow dr2;
            int row;

            row = tdbgQuikUpdate.RowBookmark(tdbgQuikUpdate.Bookmark);
            cm = (CurrencyManager)this.BindingContext[tdbgQuikUpdate.DataSource, tdbgQuikUpdate.DataMember];
            dv = (DataView)cm.List;
            drv = (System.Data.DataRowView)cm.List[row];
            dr2 = drv.Row;


            tmpID = Convert.ToInt32(dr["ID"]);
            bHrs = Convert.ToDecimal(dr["BudgetHrs"]);
            rHrs = Convert.ToDecimal(dr["RemainingHrs"]);


            int tmpID2 = Convert.ToInt32(dr2["ID"]);
            decimal bHrs2 = Convert.ToDecimal(dr2["BudgetHrs"]);
            decimal rHrs2 = Convert.ToDecimal(dr2["RemainingHrs"]);

            //perc = CBDrawingLog.GetPercentComplete(bHrs, rHrs);
            //eHrs = CBDrawingLog.GetEarnedHrs(bHrs, rHrs);

            //dr["PercentComplete"] = perc;
            //dr["EarnedHrs"] = eHrs;

            //CBDrawingLog.UpdateHours(tmpID, bHrs, perc, eHrs, rHrs);

            // changed to allow for the sort
            perc = CBDrawingLog.GetPercentComplete(bHrs2, rHrs2);
            eHrs = CBDrawingLog.GetEarnedHrs(bHrs2, rHrs2);

            dr2["PercentComplete"] = perc;
            dr2["EarnedHrs"] = eHrs;

            CBDrawingLog.UpdateHours(tmpID2, bHrs2, perc, eHrs, rHrs2);

            TotalHours();
        }

        private void LoadGridWithDrawings()
        {
            Row rw;
            fgQuikUpdate.Redraw = false;

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            DataView dv;

            ClearCurrentGrid();
            dv = new DataView(mdsUpdates.Tables[0]);
            dv.Sort = "AcctCode ASC";

            for (int i = 0; i < dv.Count; i++)
            {
                rw = fgQuikUpdate.Rows.Add();

                rw[1] = dv[i]["AcctCode"].ToString();
                rw[2] = dv[i]["ID"].ToString();
                rw[3] = dv[i]["Project"].ToString();
                rw[4] = dv[i]["HGANumber"].ToString();
                rw[5] = dv[i]["CADNumber"].ToString();
                rw[6] = dv[i]["WBS"].ToString();
                //rw[7] = dv[i]["IsTask"].ToString();
                rw[7] = CBDrawingLog.GetTaskDrwgSpecFromInt(Convert.ToInt32(dv[i]["IsTask"]));
                rw[8] = dv[i]["Title"].ToString();
                rw[9] = dv[i]["AcctCode"].ToString();
                rw[10] = dv[i]["BudgetHrs"].ToString();
                rw[11] = dv[i]["ActualHrs"].ToString();
                rw[12] = dv[i]["PercentComplete"].ToString();
                rw[13] = dv[i]["Earnedhrs"].ToString();
                rw[14] = dv[i]["RemainingHrs"].ToString();
            }

            this.Cursor = Cursors.Default;

            //fgQuikUpdate.Cols[10].Style = fgQuikUpdate.Styles["ActualValues"];
            fgQuikUpdate.Redraw = true;

            CreateSubtotals();
        }

        private void ClearCurrentGrid()
        {
            int rwCnt;

            rwCnt = fgQuikUpdate.Rows.Count;

            while (rwCnt > 1)
            {
                fgQuikUpdate.Rows.Remove(rwCnt - 1);
                rwCnt--;
            }
        }

        private void CreateSubtotals()
        {
            // show OutlineBar on column 0
            fgQuikUpdate.Tree.Column = 0;
            fgQuikUpdate.Tree.Style = TreeStyleFlags.Simple;

            // clear existing subtotals
            fgQuikUpdate.SubtotalPosition = SubtotalPositionEnum.BelowData;

            fgQuikUpdate.Subtotal(AggregateEnum.Clear);

            // grandtotal
            fgQuikUpdate.Subtotal(AggregateEnum.Sum, -1, -1, 10);
            fgQuikUpdate.Subtotal(AggregateEnum.Sum, -1, -1, 11);
            //fgQuikUpdate.Subtotal(AggregateEnum.Average, -1, -1, 12);
            fgQuikUpdate.Subtotal(AggregateEnum.Sum, -1, -1, 13);
            fgQuikUpdate.Subtotal(AggregateEnum.Sum, -1, -1, 14);

            fgQuikUpdate.Subtotal(AggregateEnum.Clear);

            // account subtotal
            fgQuikUpdate.Subtotal(AggregateEnum.Average, 0, 1, 9);
            fgQuikUpdate.Subtotal(AggregateEnum.Sum, 0, 1, 10);
            fgQuikUpdate.Subtotal(AggregateEnum.Average, 0, 1, 11);
            //fgQuikUpdate.Subtotal(AggregateEnum.Average, 0, 1, 12);
            fgQuikUpdate.Subtotal(AggregateEnum.Sum, 0, 1, 13);
            fgQuikUpdate.Subtotal(AggregateEnum.Sum, 0, 1, 14);

            CellStyle cs;
            cs = fgQuikUpdate.Styles[CellStyleEnum.Subtotal0];
            cs.BackColor = Color.Gray;
            cs.Font = new Font(Font, FontStyle.Bold);           
        }

        private void fgQuikUpdate_AfterEdit(object sender, RowColEventArgs e)
        {
            SaveTimeChange(e.Row, e.Col);
        }

        private void SaveTimeChange(int rowIndx, int colIndx)
        {
            int tmpID;
            decimal bHrs;
            decimal perc;
            decimal eHrs;
            decimal rHrs;

            tmpID = Convert.ToInt32(fgQuikUpdate[rowIndx,2]);
            bHrs = Convert.ToDecimal(fgQuikUpdate[rowIndx, 10]);
            rHrs = Convert.ToDecimal(fgQuikUpdate[rowIndx, 14]);

            perc = CBDrawingLog.GetPercentComplete(bHrs, rHrs);
            eHrs = CBDrawingLog.GetEarnedHrs(bHrs, rHrs);

            fgQuikUpdate[rowIndx, 12] = perc;
            fgQuikUpdate[rowIndx, 13] = eHrs;

            CBDrawingLog.UpdateHours(tmpID, bHrs, perc, eHrs, rHrs);

            CreateSubtotals();
        }

        private void ttlbbSwitch_Click(object sender, EventArgs e)
        {
            if (fgQuikUpdate.Visible == true)
            {
                fgQuikUpdate.Visible = false;
                tdbgQuikUpdate.Visible = true;
                LoadDrawingList();
            }
            else
            {
                tdbgQuikUpdate.Visible = false;
                fgQuikUpdate.Visible = true;
                LoadGridWithDrawings();
            }
        }

        private void tdbgQuikUpdate_HeadClick(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (e.ColIndex > 1 && e.ColIndex < 4)
            {
                if (e.ColIndex == 3)
                    LoadDrawingList(true);
                else
                    LoadDrawingList();
            }

            this.Cursor = Cursors.Default;
        }

        private void fgQuikUpdate_CellButtonClick(object sender, RowColEventArgs e)
        {

        }

        private void FDLog_Update_Load(object sender, EventArgs e)
        {

        }

        private void LoadWBSCodesForFilter()
        {
            SqlDataReader dr;

            dr = CBDrawingLog.GetWBSListByProject(miCurrProj);

            cboWBS.Items.Clear();

            cboWBS.Items.Add("");

            while (dr.Read())
            {
                if (dr["WBS"].ToString().Length > 0)
                {
                    cboWBS.Items.Add(dr["WBS"].ToString());
                }
            }
        }

        private void CheckToAddNewWBSCode(string wbs)
        {
            bool needToAdd = true;

            foreach (object o in cboWBS.Items)
            {
                if (wbs.Trim() == o.ToString())
                {
                    needToAdd = false;
                }
            }

            if (needToAdd == true)
            {
                cboWBS.Items.Add(wbs.Trim());
            }
        }

        private void cboWBS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
            string newFile;

            SaveFileDialog savefiledialog1 = new SaveFileDialog();
            savefiledialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            savefiledialog1.FilterIndex = 1;
            savefiledialog1.RestoreDirectory = true;


            if (savefiledialog1.ShowDialog() != DialogResult.Cancel)
            {
                newFile = savefiledialog1.FileName;
                    

                try
                {
                 
                    tdbgQuikUpdate.ExportToExcel(newFile);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save file: " + ex.Message, "Save File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
    }
}