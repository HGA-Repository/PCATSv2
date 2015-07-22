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
using Common.Extentions;
using System.Linq;
using System.Resources;
using System.Reflection;


using GrapeCity.ActiveReports;
//using DataDynamics.ActiveReports.Export.Pdf.PdfDocumentOptions
//using DataDynamics.ActiveReports;

namespace RSMPS
{
    public partial class FBudgetMain : Form
    {
        /*

         * Line types for budget lines
         * 1 = manual entered
         * 2 = entered from worksheet
         * 3 = entered from pcn

        */

        public string st_Description;

        private const int QUANTITYCOLUMN = 10;
        private const decimal DEFAULTLABORRATE = 100.00m;
        private const string DEFAULTDOLLARS = "#,##0.00";
        private const string DEFAULTINTEGER = "#,##0";

        private const string BUDGETTITLE = "PCATS Budget Add/Edit";

        private const string BUDCOL1 = "Utility1";
        private const string BUDCOL2 = "Task";
        private const string BUDCOL3 = "Cat";
        private const string BUDCOL4 = "Act";
        private const string BUDCOL5 = "Sort1";
        private const string BUDCOL6 = "Sort2";
        private const string BUDCOL7 = "Sort3";
        private const string BUDCOL8 = "EditType";
        private const string BUDCOL9 = "WBS";
        private const string BUDCOL10 = "Description";
        private const string BUDCOL11 = "Quantity";
        private const string BUDCOL12 = "HoursEach";
        private const string BUDCOL13 = "TotalHours";
        private const string BUDCOL14 = "LoadedRate";
        private const string BUDCOL15 = "TotalDollars";
        private const string BUDCOL16 = "LineID";


        private decimal DEFAULTRATE = 100.00m;

        private int miProjectID;
        private string msProject;
        private int miCurrUser = 0;
        private bool mbProcessing = false;
        private bool mbIsGovernment = false;
        private bool mbIsPipeline = false;
        private bool mbUseAllGroups = false;

        private CBBudget moCurrBudget;



        private Dictionary<string, bool> mbLoaded = new Dictionary<string,bool>();
        private dsBudgetPCN mdsPCNs;
        private dsPCNStatus mdsPCNStatus;

        private Dictionary<string, dsWorkSheet> mdsWS = new Dictionary<string,dsWorkSheet>();
        private Dictionary<string, int> miExpHght = new Dictionary<string,int>();
        private List<CBActivityCodeDisc> _Groups = null;
        private string _Default_Group = null;

        private string SelectedGroupTab
        {
          
            get {
                //try { return _Groups[tabControl1.SelectedIndex].Code; }
                //catch{ return _Default_Group; }
                var group = tabControl1.SelectedTab.Text;
                int group_int;
                if (Int32.TryParse(group, out group_int))
                    group = group_int.ToString();
                else
                    group = _Default_Group;
                return group;
            }


        }

        /// <summary>
        /// if set to return the form will reopen when it is closed
        /// </summary>
        public bool ReloadForm { get; private set; }

        public void SetNewProjectBudget(int projID)
        {
            CBProject p = new CBProject();
            CBBudget b = new CBBudget();

            p.Load(projID);

            miProjectID = projID;
            msProject = p.Number;

            b.LoadByProject(projID);
            mbIsGovernment = p.IsGovernment;
            mbIsPipeline = p.IsPipeline();
            mbUseAllGroups = p.UseAllGroups();

            if (b.ID > 0)
            {
                LoadPreviousBudget(projID);
            }
            else
            {
                mbProcessing = true;
                StartNewBudget();
                mbProcessing = false;
            }
           //    MessageBox.Show(" SetNewProjectBudget "); //***************************7
        }


        public FBudgetMain( int project_id )
        {
            InitializeComponent();
            
            this.ReloadForm = false;
            _Groups = CBActivityCodeDisc.GetAllForProject(project_id).ToList();
            if (_Groups.Count() == 0) _Groups.Add(CBActivityCodeDisc.GetAll().ToList().First());
            _Default_Group = _Groups.First().Code;
            InitializeDynamicComponent();
            Init();
        }


        private void Init()
        {

            int EXPENSEHT = 250;

            foreach (var group in _Groups)
            {
                mbLoaded[group.Code] = false;
                mdsWS[group.Code] = new dsWorkSheet();
                miExpHght[group.Code] = EXPENSEHT;
            }

            foreach (var group in _Groups) {
                pnlExpForGroup(group.Code).Height = 25;
                txtSumHrsForGroup(group.Code).Text = "";
                txtSumDlrsForGroup(group.Code).Text = "";
                txtSumExpForGroup(group.Code).Text = "";
                txtSumRateForGroup(group.Code).Text = "";
            }

            txtTotalHrs.Text = "";
            txtTotalDlrs.Text = "";
            txtTotalExp.Text = "";
            txtTotalRate.Text = "";
           // MessageBox.Show("Init()"); //*********************1
            LoadUOMExp();
        }


        private void LoadGroupWithAccounts(string group)
        {
            SqlDataReader dr;
            bool isWorkSheet;

            C1FlexGrid fg = this.fgForGroup(group);
            int group_int = Int32.Parse(group);

            string col1;
            string col2;
            string col3;
            string col4;
            string col5;
            string col6;
            string col7;
            string col8;
            string col9;
            string col10;
            string col11;
            string col12;
            string col13;
            string col14;
            string col15;
            string col16;

            col1 = fg.Cols[0].Name;
            col2 = fg.Cols[1].Name;
            col3 = fg.Cols[2].Name;
            col4 = fg.Cols[3].Name;
            col5 = fg.Cols[4].Name;
            col6 = fg.Cols[5].Name;
            col7 = fg.Cols[6].Name;
            col8 = fg.Cols[7].Name;
            col9 = fg.Cols[8].Name;
            col10 = fg.Cols[9].Name;
            col11 = fg.Cols[10].Name;
            col12 = fg.Cols[11].Name;
            col13 = fg.Cols[12].Name;
            col14 = fg.Cols[13].Name;
            col15 = fg.Cols[14].Name;
            col16 = fg.Cols[15].Name;

            fg.Cols[BUDCOL15].Format = DEFAULTDOLLARS;

            while (fg.Rows.Count > 1)
            {
                fg.Rows.Remove(1);
            }

            if (mbIsGovernment == true)
                dr = CBProjectBudget.GetAccountGroupByDiscipline(group_int, true);
            else
                dr = CBProjectBudget.GetAccountGroupByDiscipline(group_int);

            while (dr.Read())
            {
                Row r = fg.Rows.Add();

                isWorkSheet = IsLockedBudgetLine(dr["Activity"].ToString());

                r[BUDCOL2] = dr["Task"].ToString() + "     " + dr["TaskDesc"].ToString();
                r[BUDCOL3] = dr["Category"].ToString() + "     " + dr["CatDesc"].ToString();
                r[BUDCOL4] = dr["Activity"].ToString() + "     " + dr["ActDesc"].ToString();
                r[BUDCOL5] = dr["Task"].ToString();
                r[BUDCOL6] = dr["Category"].ToString();
                r[BUDCOL7] = dr["Activity"].ToString();
                if (isWorkSheet == true)
                    r[BUDCOL8] = 2;
                else
                    r[BUDCOL8] = 1;
                r[BUDCOL9] = "";
                r[BUDCOL10] = dr["ActDesc"].ToString();
                r[BUDCOL11] = "0";
                r[BUDCOL12] = "0";
                r[BUDCOL13] = "0";
                r[BUDCOL14] = DEFAULTRATE.ToString("#,##0.00");
                r[BUDCOL15] = "0";
                

                if (isWorkSheet == true)
                    r.Style = fg.Styles["RSWorksheetEdit"];
                else
                    r.Style = fg.Styles["RSAllowEdit"];
            }

            fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
            fg.Tree.Column = 0;
            fg.AllowMerging = AllowMergingEnum.Nodes;

            SubTotal(group);

            mbLoaded[group] = true;
           // MessageBox.Show("LoadGroupWithAccounts");
        }



        private void LoadGroupWithBudget(string group, string wbsCode)
        {
            SqlDataReader dr;
            var fg = fgForGroup(group);
            int group_int = Int32.Parse(group);

            while (fg.Rows.Count > 1)
            {
                fg.Rows.Remove(1);
            }

            CBBudgetLine.AddMissingLines(moCurrBudget.ID, group_int, wbsCode);
            CBBudgetExpenseLine.AddMissingLines(moCurrBudget.ID, group_int, wbsCode);

            if (wbsCode.Length > 0)
                dr = CBBudgetLine.GetListByBudgetWithWBS(moCurrBudget.ID, group_int, wbsCode);
            else
                dr = CBBudgetLine.GetListByBudget(moCurrBudget.ID, group_int, wbsCode);

            while (dr.Read())
            {
                Row r = fg.Rows.Add();

                r[BUDCOL2] = dr["Task"].ToString() + "     " + dr["TaskDesc"].ToString();
                r[BUDCOL3] = dr["Category"].ToString() + "     " + dr["CatDesc"].ToString();
                r[BUDCOL4] = dr["Activity"].ToString() + "     " + dr["ActDesc"].ToString();
                r[BUDCOL5] = dr["Task"].ToString();
                r[BUDCOL6] = dr["Category"].ToString();
                r[BUDCOL7] = dr["Activity"].ToString();
                if (IsLockedBudgetLine(dr["Activity"].ToString()) == true)
                {
                    r[BUDCOL8] = 2;
                }
                else
                {
                    //r[BUDCOL8] = 1;
                    r[BUDCOL8] = Convert.ToInt32(dr["EntryLevel"]);
                }
                //r[BUDCOL8] = Convert.ToInt32(dr["EntryLevel"]);
                r[BUDCOL9] = dr["WBS"].ToString();
                r[BUDCOL10] = dr["Description"].ToString();
                r[BUDCOL11] = Convert.ToInt32(dr["Quantity"]);
                r[BUDCOL12] = Convert.ToInt32(dr["HoursEach"]);
                r[BUDCOL13] = Convert.ToInt32(dr["TotalHours"]);
                r[BUDCOL14] = Convert.ToDecimal(dr["LoadedRate"]).ToString("#,##0.00");
                r[BUDCOL15] = Convert.ToDecimal(dr["TotalDollars"]).ToString("#,##0.00");
                r[BUDCOL16] = dr["ID"].ToString();

                SetEntryLevel(Convert.ToInt32(dr["EntryLevel"]), Int32.Parse(group), ref r);
            }
            fg.Cols[BUDCOL15].Format = DEFAULTDOLLARS;
            fg.Tree.Style = TreeStyleFlags.SimpleLeaf;
            fg.Tree.Column = 0;
            fg.AllowMerging = AllowMergingEnum.Nodes;

            SubTotal(group);
            mbLoaded[group] = true;
           // MessageBox.Show("LoadGroupWithBudget"); //********************* 3 & 4 With Subtotal
        }




        private void SubTotal(string group)
        {
            var fg = fgForGroup(group);


            fg.Subtotal(AggregateEnum.Sum, 0, BUDCOL2, BUDCOL11);   //*******************Added 7/16/2015
            fg.Subtotal(AggregateEnum.Sum, 1, BUDCOL3, BUDCOL11);
            fg.Subtotal(AggregateEnum.Sum, 2, BUDCOL4, BUDCOL11);



            fg.Subtotal(AggregateEnum.Sum, 0, BUDCOL2, BUDCOL13);
            fg.Subtotal(AggregateEnum.Sum, 1, BUDCOL3, BUDCOL13);
            fg.Subtotal(AggregateEnum.Sum, 2, BUDCOL4, BUDCOL13);

            fg.Subtotal(AggregateEnum.Average, 0, BUDCOL2, BUDCOL14, "");
            fg.Subtotal(AggregateEnum.Average, 1, BUDCOL3, BUDCOL14, "");
            fg.Subtotal(AggregateEnum.Average, 2, BUDCOL4, BUDCOL14, "");

            //var rounder = new SubtotalEventHandler(afterTotal_Round);
            //fg.AfterSubtotal += rounder;
            fg.Subtotal(AggregateEnum.Sum, 0, BUDCOL2, BUDCOL15);
            fg.Subtotal(AggregateEnum.Sum, 1, BUDCOL3, BUDCOL15);
            fg.Subtotal(AggregateEnum.Sum, 2, BUDCOL4, BUDCOL15);
            //fg.AfterSubtotal -= rounder;


            for (int i = 0; i < fg.Rows.Count; i++)
            {
                if (fg.Rows[i].IsNode == true)
                {
                    fg[i, BUDCOL14] = "   ";
                }
            }
          //  MessageBox.Show("SubTotal(string group)");
        }

        private static void afterTotal_Round(object sender, SubtotalEventArgs args)
        {
            if (args.AggregateValue is double )
            {
                var rounded = Math.Round((double)args.AggregateValue, 4);
                args.AggregateValue = rounded;
            }
          //  MessageBox.Show("afterTotal_Round");
        }

        private void LoadExpenseWithAccounts(string group)
        {
            SqlDataReader dr;
            var fgExp = fgExpForGroup(group);
            var group_int = Int32.Parse(group);

            while (fgExp.Rows.Count > 1)
            {
                fgExp.Rows.Remove(1);
            }

            dr = CBProjectBudget.GetExpenseGroupByDiscipline(group_int);

            while (dr.Read())
            {
                bool isLocked;
                Row r = fgExp.Rows.Add();

                isLocked = IsLockedExpense(dr["Code"].ToString());

                r[1] = dr["Code"].ToString();
                r[2] = Convert.ToDecimal(dr["DefaultMU"]).ToString("#,##0");
                r[3] = dr["Description"].ToString();
                r[4] = dr["UOMCode"].ToString();
                if (Convert.ToInt32(dr["DecimalPlaces"]) > 2)
                    r[5] = Convert.ToDecimal(dr["DefaultRate"]).ToString("#,##0.000");
                else
                    r[5] = Convert.ToDecimal(dr["DefaultRate"]).ToString("#,##0.00");
                //r[06] = "Num Items";          // num items
                //r[07] = "Markup dollars";     // markup dollars
                //r[08] = "TotalDollars";       // total dollars
                r[9] = 0;
                r[10] = Convert.ToInt32(dr["UOMID"]);
            }

            dr.Close();
           // MessageBox.Show("LoadExpenseWithAccounts(string group)");
        }



        private void LoadExpenseWithBudget(string group)
        {
            SqlDataReader dr;
            var fgExp = fgExpForGroup(group);

            while (fgExp.Rows.Count > 1)
            {
                fgExp.Rows.Remove(1);
            }

            dr = CBBudgetExpenseLine.GetListByBudget(moCurrBudget.ID, Int32.Parse(group) );
            bool has_rows = false;

            while (dr.Read())
            {
                has_rows = true;

                Row r = fgExp.Rows.Add();

                r[1] = dr["Code"].ToString();
                r[2] = Convert.ToDecimal(dr["Markup"]).ToString(DEFAULTINTEGER);
                r[3] = dr["Description"].ToString();
                r[4] = dr["UOMCode"].ToString();
                if (Convert.ToInt32(dr["DecimalPlaces"]) > 2)
                    r[5] = Convert.ToDecimal(dr["DollarsEach"]).ToString("#,##0.000");
                else
                    r[5] = Convert.ToDecimal(dr["DollarsEach"]).ToString(DEFAULTDOLLARS);
                r[06] = Convert.ToInt32(dr["Quantity"]).ToString();
                r[07] = Convert.ToDecimal(dr["MarkupDollars"]).ToString(DEFAULTDOLLARS);
                r[08] = Convert.ToDecimal(dr["TotalDollars"]).ToString(DEFAULTDOLLARS);
                r[9] = Convert.ToInt32(dr["ID"]).ToString();
                r[10] = Convert.ToInt32(dr["UOMID"]).ToString();
            }

            dr.Close();

            if (!has_rows) {
                LoadExpenseWithAccounts(group);
                SaveExpenseLines(group);
            }

           // MessageBox.Show("LoadExpenseWithBudget");

        }


        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        { AddNewRow(SelectedGroupTab); }

        private void AddNewRow(string group)
        {
            var fg = fgForGroup(group);
            int currentRow = fg.Row;
            int newRow;

            if (currentRow < 0) return;

            Row r = fg.Rows.Insert(currentRow + 1);
            r.Style = fg.Styles["RSAllowEdit"];

            newRow = r.Index;

            r[BUDCOL2] = fg[currentRow, 1];
            r[BUDCOL3] = fg[currentRow, 2];
            r[BUDCOL4] = fg[currentRow, 3];
            r[BUDCOL5] = fg[currentRow, 4];
            r[BUDCOL6] = fg[currentRow, 5];
            r[BUDCOL7] = fg[currentRow, 6];
            r[BUDCOL8] = fg[currentRow, 7];
            r[BUDCOL9] = fg[currentRow, 8];
            r[BUDCOL10] = fg[currentRow, 9];
            r[BUDCOL11] = "0";
            r[BUDCOL12] = "0";
            r[BUDCOL13] = "0";
            r[BUDCOL14] = "100.00";
            r[BUDCOL15] = "0";

            SaveChangeToDB(group, newRow);
           // MessageBox.Show("AddNewRow");
        }



        private void tlbbExit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBudget(SelectedGroupTab);
        }

        private void LoadBudget(string group)
        {

            if ( mbLoaded[group] == true)
                return;

            LoadGroupWithAccounts(group);    
            SaveBudgetLines(group);
            LoadExpenseWithAccounts(group);
            SaveExpenseLines(group);

            mbLoaded[group] = true;

           // MessageBox.Show("LoadBudget");
        }



        private void FBudgetMain_Load(object sender, EventArgs e)
        {
            //mdsPCNs = new dsBudgetPCN();
            LoadPCNStatus();

            SetBudgetUserLevel();
            
            richTextBox1.Text = moCurrBudget.Clarification11000.ToString();
            richTextBox2.Text = moCurrBudget.Clarification12000.ToString();
            richTextBox3.Text = moCurrBudget.Clarification13000.ToString();
            richTextBox4.Text = moCurrBudget.Clarification14000.ToString();
            richTextBox5.Text = moCurrBudget.Clarification15000.ToString();
            richTextBox6.Text = moCurrBudget.Clarification16000.ToString();
            richTextBox7.Text = moCurrBudget.Clarification18000.ToString();
            richTextBox8.Text = moCurrBudget.Clarification50000.ToString();
         //   MessageBox.Show("FBudgetMain_Load"); //**************************10

        }

        private void SetBudgetUserLevel()
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);
            miCurrUser = u.ID;

            if (u.IsAdministrator == true)
            {
                tlbbNewRev.Enabled = true;
                tlbbMakeDefault.Enabled = true;
                tlbbMakeActive.Visible = true;
                makeActiveToolStripMenuItem.Visible = true;
                tlbbWorksheet.Enabled = true;
                tlbbSummary.Enabled = true;
                tlbbPreviewDetails.Enabled = true;
                tlbbJobStat.Enabled = true;
                tlbbBudgetEntry.Enabled = true;
                tlbbPrintAll.Enabled = true;
                tlbbBudgetEntry.Enabled = true;
                tlbbBudgetExport.Enabled = true;
            }
            else if (u.IsEngineerAdmin == true)
            {
                tlbbNewRev.Enabled = true;
                tlbbMakeDefault.Enabled = true;
                tlbbMakeActive.Visible = true;
                makeActiveToolStripMenuItem.Visible = true;
                tlbbWorksheet.Enabled = true;
                tlbbSummary.Enabled = true;
                tlbbPreviewDetails.Enabled = true;
                tlbbJobStat.Enabled = true;
                tlbbBudgetEntry.Enabled = true;
                tlbbPrintAll.Enabled = true;
                tlbbBudgetEntry.Enabled = true;
                tlbbBudgetExport.Enabled = true;
            }
            else if (u.IsManager == true)
            {
                tlbbNewRev.Enabled = true;
                tlbbWorksheet.Enabled = true;
                tlbbSummary.Enabled = true;
                tlbbPreviewDetails.Enabled = true;
                tlbbJobStat.Enabled = true;
                tlbbBudgetEntry.Enabled = true;
                tlbbPrintAll.Enabled = true;
                tlbbBudgetEntry.Enabled = true;
                tlbbBudgetExport.Enabled = true;
                tlbbMakeDefault.Enabled = false;
                tlbbMakeDefault.Visible = false;
                tlbbMakeActive.Visible = false;
                tlbbMakeActive.Visible = false;
                makeActiveToolStripMenuItem.Visible = false;
                
            }
            else
            {
                tlbbNewRev.Enabled = true;
                tlbbWorksheet.Enabled = true;
                tlbbMakeDefault.Enabled = false;
                tlbbMakeDefault.Visible = false;
                tlbbMakeActive.Visible = false;
                makeActiveToolStripMenuItem.Visible = false;
                tlbbSummary.Enabled = false;
                tlbbSummary.Visible = false;
                tlbbPreviewDetails.Enabled = false;
                tlbbPreviewDetails.Visible = false;
                tlbbJobStat.Enabled = true;
                tlbbBudgetEntry.Enabled = false;
                tlbbBudgetEntry.Visible = false;
                tlbbPrintAll.Enabled = false;
                tlbbPrintAll.Visible = false;
                tlbbBudgetExport.Enabled = false;
                tlbbBudgetExport.Visible = false;

                // hide dollars for non-admin
                foreach (var group in _Groups)
                {
                    txtSumDlrsForGroup(group.Code).Visible = false;
                    txtSumRateForGroup(group.Code).Visible = false;
                    txtSumExpForGroup(group.Code).Visible = false;
                }

                txtTotalDlrs.Visible = false;
                txtTotalRate.Visible = false;
                txtTotalExp.Visible = false;

                foreach (var group in _Groups)
                {
                    // hide dollar columns in grid
                    fgForGroup(group.Code).Cols[13].Visible = false;
                    fgForGroup(group.Code).Cols[14].Visible = false;
                }

                tdbgBudgetPCN.Splits[0].DisplayColumns[4].Visible = false;
            }

           // MessageBox.Show(" SetBudgetUserLevel"); //***************************8
        }

        private void tlbbWorksheet_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            OpenWorksheet(SelectedGroupTab);
        }

        private void OpenWorksheet(string group)
        {
            var has_no_worksheet_codes = new[] { "1000", "10000", "20000" };
            var group_obj = _Groups.FirstOrDefault(x => x.Code == group);
            FWS worksheet = new FWS(group_obj, !has_no_worksheet_codes.Contains(group) );

           // worksheet.cboWBS_Text = cboWBS.Text; // *****************************Added 7/1/15
           // worksheet.miProjectID = miProjectID;
           
         //   MessageBox.Show(worksheet.miProjectID.ToString());
            //MessageBox.Show(cboWBS.Text);

            var handler = new WorksheetChangedHandler((ds) => { f1_OnWorkSheetChanged(group, ds); });
            worksheet.OnWorkSheetChanged += handler;
            worksheet.SetDataValues(mdsWS[group], moCurrBudget.ID);

            //MessageBox.Show(mdsWS[group].ToString());
         //   MessageBox.Show(moCurrBudget.ID.ToString());
          
            
            worksheet.ShowDialog();
            worksheet.OnWorkSheetChanged -= handler;
            

        }

        private decimal WorksheetRate(int code, List<CBBudgetLine> removed)
        {
            var found = removed.FirstOrDefault(x => x.Activity == code);
            return found != null ? found.LoadedRate : DEFAULTRATE;

        }


        void f1_OnWorkSheetChanged(string group, DataSet dsWS)
        {
            int valID, budID;
            string guidVal;
            string wbs;
            string description;
            int qtyEach;

            var mdsWS = (dsWorkSheet)dsWS;
            this.mdsWS[group] = mdsWS;
            var group_int = Int32.Parse(group);
            var fg = fgForGroup(group);
            var fgExp = fgExpForGroup(group);

            var removed = ClearWorksheetLines(group);

            // go through dataset and add to grid
            foreach (DataRow dr in mdsWS.Tables["Worksheet"].Rows)
            {
                valID = 0;
                budID = 0;
                guidVal = "";
                wbs = "";
                description = "";
                qtyEach = 0;

                valID = Convert.ToInt32(dr[0]);
                budID = Convert.ToInt32(dr[1]);
                guidVal = dr[2].ToString();
                description = dr[3].ToString();
                wbs = dr[18].ToString();
                qtyEach = Convert.ToInt32(dr[4]);

                var codes = new[] { 211, 212, 213, 214, 215, 221, 222, 223, 224, 225, 226, 227, 229 };
                int index = 5; //location of 211 column in FWS
                foreach (int sub_code in codes)
                {
                    int value = CheckforNullConvert(dr[index]);
                    if (value > 0)
                    {
                        int code = group_int + sub_code;
                        var locDesc = GetProcurementDescription(code, description);
                        var rate = WorksheetRate(code, removed);
                        InsertLineFromWorkSheet(valID, group_int, code, wbs, locDesc, qtyEach, value, rate);
                    }
                    index++;
                }

            }

            ClearExpenseLines(group);

            int travelFare, autoRental, tolls, fuel, mileage, meals, lodging, perdiem, miscExp, survey1, survey2, survey3, survey4, survsup, engserv, surveying, geotinv, environ, specsub, atv, oruv, boat, digcam, cphone, fldcomp, trimbler8, trimblegeo, etotstat, lasrange, pipeloc;
            string rowCode;

            travelFare = 0;
            autoRental = 0;
            tolls = 0;
            fuel = 0;
            mileage = 0;
            meals = 0;
            lodging = 0;
            perdiem = 0;
            miscExp = 0;
            survey1 = 0;
            survey2 = 0;
            survey3 = 0;
            survey4 = 0;
            survsup = 0;
            engserv = 0;
            surveying = 0;
            geotinv = 0;
            environ = 0;
            specsub = 0;
            atv = 0;
            oruv = 0;
            boat = 0;
            digcam = 0;
            cphone = 0;
            fldcomp = 0;
            trimbler8 = 0;
            trimblegeo = 0;
            etotstat = 0;
            lasrange = 0;
            pipeloc = 0;

            foreach (DataRow dr in mdsWS.Tables["Expenses"].Rows)
            {
                var quantity = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["TripQty"]));
                travelFare += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E110"])) * quantity;
                autoRental += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E120"])) * quantity;
                tolls += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E130"])) * quantity;
                fuel += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E140"])) * quantity;
                mileage += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E150"])) * quantity;
                meals += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E160"])) * quantity;
                lodging += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E170"])) * quantity;
                perdiem += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E180"])) * quantity;
                miscExp += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E190"])) * quantity;
                survey1 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E281"])) * quantity;
                survey2 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E282"])) * quantity;
                survey3 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E283"])) * quantity;
                survey4 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E284"])) * quantity;
                survsup += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E290"])) * quantity;
                engserv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E310"])) * quantity;
                surveying += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E320"])) * quantity;
                geotinv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E330"])) * quantity;
                environ += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E340"])) * quantity;
                specsub += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E350"])) * quantity;
                atv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E541"])) * quantity;
                oruv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E542"])) * quantity;
                boat += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E543"])) * quantity;
                digcam += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E561"])) * quantity;
                cphone += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E562"])) * quantity;
                fldcomp += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E580"])) * quantity;
                trimbler8 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E591"])) * quantity;
                trimblegeo += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E592"])) * quantity;
                etotstat += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E593"])) * quantity;
                lasrange += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E594"])) * quantity;
                pipeloc += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E595"])) * quantity;
            }

            foreach (C1.Win.C1FlexGrid.Row r in fgExp.Rows)
            {
                rowCode = r[1].ToString();
                switch (rowCode)
                {
                    case "E110":
                        r[6] = travelFare;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E120":
                        r[6] = autoRental;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E130":
                        r[6] = tolls;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E140":
                        r[6] = fuel;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E150":
                        r[6] = mileage;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E160":
                        r[6] = meals;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E170":
                        r[6] = lodging;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E180":
                        r[6] = perdiem;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E190":
                        r[6] = miscExp;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E281":
                        r[6] = survey1;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E282":
                        r[6] = survey2;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E283":
                        r[6] = survey3;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E284":
                        r[6] = survey4;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E290":
                        r[6] = survsup;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E310":
                        r[6] = engserv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E320":
                        r[6] = surveying;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E330":
                        r[6] = geotinv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E340":
                        r[6] = environ;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E350":
                        r[6] = specsub;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E541":
                        r[6] = atv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E542":
                        r[6] = oruv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E543":
                        r[6] = boat;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E561":
                        r[6] = digcam;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E562":
                        r[6] = cphone;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E580":
                        r[6] = fldcomp;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E591":
                        r[6] = trimbler8;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E592":
                        r[6] = trimblegeo;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E593":
                        r[6] = etotstat;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E594":
                        r[6] = lasrange;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E595":
                        r[6] = pipeloc;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    default:
                        break;
                }
            }

            tlbbSaveRev.Enabled = true;

            SubTotal(group);
            TotalBudget(group, true);
        }


        private int CheckforNullConvert(object o)
        {
            int retVal;

            if (o == DBNull.Value)
                retVal = 0;
            else
                retVal = Convert.ToInt32(o);

            return retVal;
        }

        private List<CBBudgetLine> ClearWorksheetLines(string group)
        {
            List<CBBudgetLine> deleted = new List<CBBudgetLine>();
            int test;
            bool keepLooking = true;
            var fg = fgForGroup(group);

            while (keepLooking)
            {
                keepLooking = false;

                for (int i = 0; i < fg.Rows.Count; i++)
                {
                    if (RevSol.RSMath.IsInteger(fg[i, BUDCOL8]) == true)
                        test = Convert.ToInt32(fg[i, BUDCOL8]);
                    else
                        test = 0;

                    if (test == 2 && RevSol.RSMath.IsIntegerEx(fg[i, BUDCOL11]) > 0)
                    {
                        deleted.Add( CBBudgetLineFromFg( fg.Rows[i], group.ToInt().Value ));
                        CBBudgetLine.Delete(Convert.ToInt32(fg[i, BUDCOL16]));
                        fg.Rows.Remove(i);
                        keepLooking = true;
                    }
                }
            }
            return deleted;
        }



        private void ClearExpenseLines(string group)
        {
            string rowCode;

            var fgExp = fgExpForGroup(group);

            foreach (C1.Win.C1FlexGrid.Row r in fgExp.Rows)
            {
                rowCode = r[1].ToString();
                switch (rowCode)
                {
                    case "E110":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E120":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E130":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E140":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E150":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E160":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E170":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E180":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E190":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E281":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E282":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E283":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E284":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E290":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E310":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E320":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E330":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E340":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E350":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E541":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E542":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E543":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E561":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E562":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E580":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E591":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E592":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E593":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E594":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E595":
                        r[6] = 0;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    default:
                        break;
                }
            }
        }


        private void InsertLineFromWorkSheet(int wsID, int acctGroup, int acctCode, string wbs, string description, int qty, int hrs, decimal rate)
        {
            string group = acctGroup + "";
            var fg = fgForGroup(group);
            int rowIndx = 0;
            bool foundFirst = false;
            string taskVal, catVal, actVal;
            int task, cat, act;
            int rowGrp;
            
            taskVal = "";
            catVal = "";
            actVal = "";
            task = 0;
            cat = 0;
            act = 0;

            foreach (Row r in fg.Rows)
            {
                if (r.Index > 0)
                {
                    if (r[BUDCOL7] == null)
                    {
                        rowGrp = 0;
                    }
                    else
                    {
                        rowGrp = Convert.ToInt32(r[BUDCOL7]);
                    }

                    if (rowGrp == acctCode)
                    {
                        foundFirst = true;
                        rowIndx = r.Index;

                        taskVal = r[BUDCOL2].ToString();
                        catVal = r[BUDCOL3].ToString();
                        actVal = r[BUDCOL4].ToString();
                        task = Convert.ToInt32(r[BUDCOL5]);
                        cat = Convert.ToInt32(r[BUDCOL6]);
                        act = Convert.ToInt32(r[BUDCOL7]);
                    }
                    else if (rowGrp != acctCode && foundFirst == true)
                    {
                        rowIndx = r.Index;
                        break;
                    }
                }
            }

            if (foundFirst == true && rowIndx != 0)
            {
                //  insert a new row into the grid
                Row newRow = fg.Rows.Insert(rowIndx);
                newRow.Style = fg.Styles["RSWorksheetEdit"];

                CBBudgetLine bl = new CBBudgetLine();

                bl.ID = 0;
                bl.BudgetID = moCurrBudget.ID;
                bl.DeptGroup = acctGroup;
                bl.EntryLevel = 2;
                bl.Task = task;
                bl.Category = cat;
                bl.Activity = act;
                bl.WBS = wbs;
                bl.Description = description;
                bl.Quantity = qty;
                bl.HoursEach = hrs;
                bl.TotalHours = qty * hrs;
                bl.LoadedRate = rate;
                bl.TotalDollars = qty * hrs * rate;
                bl.BareRate = 0;
                bl.BareDollars = 0;

                bl.Save();

                newRow[1] = taskVal;
                newRow[2] = catVal;
                newRow[3] = actVal;
                newRow[4] = task;
                newRow[5] = cat;
                newRow[6] = act;
                newRow[7] = 2;
                newRow[8] = wbs;
                newRow[9] = description;
                newRow[10] = qty;
                newRow[11] = hrs;
                newRow[12] = qty * hrs;
                newRow[13] = rate.ToString(DEFAULTDOLLARS);
                newRow[14] = qty * hrs * rate;
                newRow[15] = bl.ID;
            }

           // MessageBox.Show("InsertLineFromWorkSheet");
        }

        private void InsertLineFromPCN(int wsID, int acctGroup, int acctCode, string wbs, string description, int qty, int hrs, decimal rate)
        {
            string group = acctGroup + "";
            var fg = fgForGroup(group);
            int rowIndx = 0;
            bool foundFirst = false;
            string taskVal, catVal, actVal;
            int task, cat, act;
            int rowGrp;

            taskVal = "";
            catVal = "";
            actVal = "";
            task = 0;
            cat = 0;
            act = 0;

            foreach (Row r in fg.Rows)
            {
                if (r.Index > 0)
                {
                    if (r[BUDCOL7] == null)
                    {
                        rowGrp = 0;
                    }
                    else
                    {
                        rowGrp = Convert.ToInt32(r[BUDCOL7]);
                    }

                    if (rowGrp == acctCode)
                    {
                        foundFirst = true;
                        rowIndx = r.Index;

                        taskVal = r[BUDCOL2].ToString();
                        catVal = r[BUDCOL3].ToString();
                        actVal = r[BUDCOL4].ToString();
                        task = Convert.ToInt32(r[BUDCOL5]);
                        cat = Convert.ToInt32(r[BUDCOL6]);
                        act = Convert.ToInt32(r[BUDCOL7]);
                    }
                    else if (rowGrp != acctCode && foundFirst == true)
                    {
                        rowIndx = r.Index;
                        break;
                    }
                }
            }

            if (foundFirst == true && rowIndx != 0)
            {
                //  insert a new row into the grid
                Row newRow = fg.Rows.Insert(rowIndx);
                newRow.Style = fg.Styles["RSWorksheetEdit"];

                CBBudgetLine bl = new CBBudgetLine();

                bl.ID = 0;
                bl.BudgetID = moCurrBudget.ID;
                bl.DeptGroup = acctGroup;
                bl.EntryLevel = 3;
                bl.Task = task;
                bl.Category = cat;
                bl.Activity = act;
                bl.WBS = wbs;
                bl.Description = description;
                bl.Quantity = qty;
                bl.HoursEach = hrs;
                bl.TotalHours = qty * hrs;
                bl.LoadedRate = rate;
                bl.TotalDollars = qty * hrs * rate;
                bl.BareRate = 0;
                bl.BareDollars = 0;

                bl.Save();

                newRow[1] = taskVal;
                newRow[2] = catVal;
                newRow[3] = actVal;
                newRow[4] = task;
                newRow[5] = cat;
                newRow[6] = act;
                newRow[7] = 3;
                newRow[8] = wbs;
                newRow[9] = description;
                newRow[10] = qty;
                newRow[11] = hrs;
                newRow[12] = qty * hrs;
                newRow[13] = rate.ToString(DEFAULTDOLLARS);
                newRow[14] = qty * hrs * rate;
                newRow[15] = bl.ID;

            }
           // MessageBox.Show("InsertLineFromPCN");
        }

        private void tlbbNewRev_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            int cnt;
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

            DialogResult ret = MessageBox.Show("Make a new revision from " + li.Description + " ?", "New Revision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ret == DialogResult.Yes)
            {
                RevSol.RSListItem l2 = new RevSol.RSListItem();
                CBBudget bud = new CBBudget();
                CBBudget budNew = new CBBudget();

                bud.Load(li.ID);
                budNew.ProjectID = bud.ProjectID;
                budNew.Revision = CBBudget.GetNextRevision(bud.ProjectID);
                budNew.PCNID = bud.PCNID;
                budNew.Description = bud.Description;
                budNew.Contingency = bud.Contingency;
                budNew.Clarification11000 = bud.Clarification11000;
                budNew.Clarification12000 = bud.Clarification12000;
                budNew.Clarification13000 = bud.Clarification13000;
                budNew.Clarification14000 = bud.Clarification14000;
                budNew.Clarification15000 = bud.Clarification15000;
                budNew.Clarification16000 = bud.Clarification16000;
                budNew.Clarification17000 = bud.Clarification17000;
                budNew.Clarification18000 = bud.Clarification18000;
                budNew.Clarification50000 = bud.Clarification50000;
                budNew.PreparedBy = bud.PreparedBy;
                budNew.IsActive = false;
                budNew.Save();

                cnt = lstBudgets.Items.Count + 1;

                l2.ID = budNew.ID;
                l2.Description = budNew.GetNumber();
                l2.Meta = budNew.IsActive.ToString();

                int indx = lstBudgets.Items.Add(l2);

                CopyBudget(li.ID, l2.ID);

                //tlbbNewRev.Enabled = false;
                tlbbSaveRev.Enabled = true;

                lstBudgets.SelectedIndex = indx;
            }
        }

        private int MakeNewRevision()
        {
            int newBud;
            int cnt;
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

            RevSol.RSListItem l2 = new RevSol.RSListItem();
            CBBudget bud = new CBBudget();
            CBBudget budNew = new CBBudget();

            bud.Load(li.ID);
            budNew.ProjectID = bud.ProjectID;
            budNew.Revision = CBBudget.GetNextRevision(bud.ProjectID);
            budNew.PCNID = bud.PCNID;
            budNew.IsActive = false;
            budNew.Save();
            newBud = budNew.ID;

            cnt = lstBudgets.Items.Count + 1;

            l2.ID = budNew.ID;
            l2.Description = budNew.GetNumber();
            l2.Meta = budNew.IsActive.ToString();

            int indx = lstBudgets.Items.Add(l2);

            CopyBudget(li.ID, l2.ID);

            //tlbbNewRev.Enabled = false;
            tlbbSaveRev.Enabled = true;

            lstBudgets.SelectedIndex = indx;

            return newBud;
           // MessageBox.Show("MakeNewRevision");

        }

        private int MakeNewRevision(int pcnID)
        {
            int newBud;
            int cnt;
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

            RevSol.RSListItem l2 = new RevSol.RSListItem();
            CBBudget bud = new CBBudget();
            CBBudget budNew = new CBBudget();

            bud.Load(li.ID);
            budNew.ProjectID = bud.ProjectID;
            budNew.PCNID = pcnID;
            budNew.Revision = CBBudget.GetNextRevision(bud.ProjectID);
            budNew.IsActive = false;
            budNew.Contingency = bud.Contingency;
            budNew.Clarification11000 = bud.Clarification11000;
            budNew.Clarification12000 = bud.Clarification12000;
            budNew.Clarification13000 = bud.Clarification13000;
            budNew.Clarification14000 = bud.Clarification14000;
            budNew.Clarification15000 = bud.Clarification15000;
            budNew.Clarification16000 = bud.Clarification16000;
            budNew.Clarification17000 = bud.Clarification17000;
            budNew.Clarification18000 = bud.Clarification18000;
            budNew.Clarification50000 = bud.Clarification50000;
            budNew.Description = bud.Description;
            budNew.Save();
            newBud = budNew.ID;

            cnt = lstBudgets.Items.Count + 1;

            l2.ID = budNew.ID;
            l2.Description = budNew.GetNumber();
            l2.Meta = budNew.IsActive.ToString();

            int indx = lstBudgets.Items.Add(l2);

            CopyBudget(li.ID, l2.ID);

            //tlbbNewRev.Enabled = false;
            tlbbSaveRev.Enabled = true;

            lstBudgets.SelectedIndex = indx;

           // MessageBox.Show("MakeNewRevision");
            return newBud;
            

        }

        private void StartNewBudget()
        {
            RevSol.RSListItem li;

            moCurrBudget = new CBBudget();
            moCurrBudget.Clear();
            moCurrBudget.ProjectID = miProjectID;
            moCurrBudget.Revision = 0;
            moCurrBudget.PCNID = 0;
            moCurrBudget.IsDefault = false;
            moCurrBudget.IsActive = false;
            moCurrBudget.Save();

            lstBudgets.Items.Clear();

            li = new RevSol.RSListItem();
            li.ID = moCurrBudget.ID;

            li.Description = moCurrBudget.GetNumber();
            li.Meta = moCurrBudget.IsActive.ToString();

            lstBudgets.Items.Add(li);
            lstBudgets.SelectedIndex = 0;

            //DisablePanelsForGovernmentJob();

            foreach (var group in _Groups) { LoadBudget(group.Code); }

            LoadPCNStatus();
            LoadBudgetPCNs();

            mdsPCNs = new dsBudgetPCN();
            tdbgBudgetPCN.SetDataBinding(mdsPCNs,"PCNs",true);

            tlbbMakeActive.Enabled = false;
            tlbbSaveRev.Enabled = true;
            makeActiveToolStripMenuItem.Enabled = false;
           // MessageBox.Show("StartNewBudget"); //************************5
        }



        private void LoadPreviousBudget(int projID)
        {
            RevSol.RSListItem li;
            SqlDataReader dr;
            int activeIndx = 0;
            CBBudget b = new CBBudget();

            //DisablePanelsForGovernmentJob();

            dr = CBBudget.GetListByProject(projID);

            lstBudgets.Items.Clear();

            while (dr.Read())
            {
                li = new RevSol.RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                b.Load(li.ID);

                if (b.IsActive == true)
                {
                    li.Description = b.GetNumber() + " (A)";
                    li.Meta = b.IsActive.ToString();
                    li.Meta1 = b.Description;
                    activeIndx = lstBudgets.Items.Count;
                    
                }
                else
                {
                    li.Description = b.GetNumber();
                    li.Meta = b.IsActive.ToString();
                    li.Meta1 = b.Description;
                }

                lstBudgets.Items.Add(li);
            }

            lstBudgets.SelectedIndex = activeIndx;

            LoadPCNStatus();
            LoadBudgetPCNs();
          //  MessageBox.Show("LoadPreviousBudget"); //***********************************6

        }

        private void lstBudgets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mbProcessing == true)
                return;

            DoBudgetSelectChange();
        }
        
        private void tbpClarification_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoBudgetSelectChange();

        }

        private void DoBudgetSelectChange()
        {
            if (lstBudgets.SelectedItems.Count > 0)
            {
                tlbbNewRev.Enabled = true;
                tlbbMakeActive.Enabled = true;
                makeActiveToolStripMenuItem.Enabled = true;
            }
            else
            {
                tlbbNewRev.Enabled = false;
                tlbbMakeActive.Enabled = false;
                makeActiveToolStripMenuItem.Enabled = false;
            }

            foreach (var group in _Groups) { mdsWS[group.Code] = new dsWorkSheet(); }



            // set current budget to selected
            if (lstBudgets.SelectedItem == null)
                return;

            int curr = ((RevSol.RSListItem)lstBudgets.SelectedItem).ID;
            moCurrBudget = new CBBudget();
            moCurrBudget.Load(curr);

            if (curr > 0)
            {
                LoadBudgetLines();
                LoadBudgetWorksheets();
                LoadExpenseLines();
                LoadExpenseWorksheets();
                //LoadBudgetPCNs();

                foreach (var group in _Groups) { TotalBudget(group.Code, false); }

                TotalAllBudget();

                tlbbNewRev.Enabled = true;
                tlbbSaveRev.Enabled = false;

                if (moCurrBudget.IsActive == true)
                {
                    tlbbMakeActive.Enabled = false;
                }
                else
                {
                    tlbbMakeActive.Enabled = true;
                }

                if (moCurrBudget.IsLocked == true)
                {
                    LockTheCurrentBudget();
                }
                else
                {
                    UnLockTheCurrentBudget();
                }
            }
            else
            {
                tlbbNewRev.Enabled = false;
                tlbbSaveRev.Enabled = true;
            }

            LoadWBSCodesForFilter();

            this.Text = BUDGETTITLE + "  Budget: " + moCurrBudget.GetNumber();
        }

        private void LoadBudgetLines()
        {
            foreach (var group in _Groups)
            { LoadGroupWithBudget(group.Code,""); }
        }

        private void LoadBudgetWorksheets()
        {
            foreach (var group in _Groups) { LoadWorksheet(group.Code); }
        }

        private void LoadExpenseLines()
        {
            foreach (var group in _Groups) { LoadExpenseWithBudget(group.Code); }
        }

        private void LoadExpenseWorksheets()
        {
            foreach (var group in _Groups) { LoadExpenseWorksheet(group.Code); }
        }

        private void LoadBudgetPCNs()
        {
            SqlDataReader dr;

            mdsPCNs = new dsBudgetPCN();
            tdbgBudgetPCN.SetDataBinding(mdsPCNs, "PCNs", true);

            dr = CBBudgetPCN.GetListByProject(moCurrBudget.ProjectID);

            while (dr.Read())
            {
                DataRow d = mdsPCNs.Tables["PCNs"].NewRow();

                d["ID"] = dr["ID"];
                d["BudgetID"] = dr["BudgetID"];
                d["PCINumber"] = dr["PCINumber"];
                d["PCNNumber"] = dr["PCNNumber"];
                d["Description"] = dr["PCNTitle"];
                d["PCNStatusID"] = dr["PCNStatusID"];
                d["PCNStatus"] = dr["PCNStatus"];
                d["TotalHrs"] = dr["TotalHours"];
                d["TotalDlrs"] = dr["TotalDollars"];

                mdsPCNs.Tables["PCNs"].Rows.Add(d);
            }
           // MessageBox.Show("LoadBudgetPCNs()");
            dr.Close();
        }

        private void LoadPCNStatus()
        {
            SqlDataReader dr;
            DataRow d;

            mdsPCNStatus = new dsPCNStatus();
            dr = CBPCNStatus.GetList();

            while (dr.Read())
            {
                d = mdsPCNStatus.Tables["Statuss"].NewRow();

                d["ID"] = dr["ID"];
                d["Status"] = dr["Status"];
                d["Description"] = dr["Description"];

                mdsPCNStatus.Tables["Statuss"].Rows.Add(d);
                
            }

            tdbdPCNStatus.SetDataBinding(mdsPCNStatus, "Statuss", true);
          
        }

        private void tlbbMakeActive_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            string msg;
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

            msg = "This will make " + li.Description + " the active project\nThis will also enter the information into the JobStat\nDo you wish to continue?";

            if (MessageBox.Show(msg, "Make Project Active", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CBBudget.MakeBudgetActive(li.ID);

                SetActiveInList();

                tlbbMakeActive.Enabled = false;
                makeActiveToolStripMenuItem.Enabled = false;

                MakeProjectActiveInJobStat(li.ID);
            }
        }

        private void SetActiveInList()
        {
            //  change current budget to active
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;
            CBBudget bud;
            int indx = 0;
            int oldActive = -1;
            string oldDesc = "";
            int newActive = 0;
            string newDesc = "";

            foreach (object o in lstBudgets.Items)
            {
                RevSol.RSListItem l = (RevSol.RSListItem)o;
                bud = new CBBudget();

                bud.Load(l.ID);

                if (bud.IsActive == true)
                {
                    newActive = indx;
                    newDesc = bud.GetNumber() + " (A)";
                }

                if (Convert.ToBoolean(l.Meta) == true)
                {
                    oldActive = indx;
                    oldDesc = bud.GetNumber();
                }

                indx++;
            }

            RevSol.RSListItem l2;

            if (oldActive >= 0)
            {
                l2 = (RevSol.RSListItem)lstBudgets.Items[oldActive];
                l2.Description = oldDesc;
                l2.Meta = "false";
                lstBudgets.Items[oldActive] = l2;
            }

            l2 = (RevSol.RSListItem)lstBudgets.Items[newActive];
            l2.Description = newDesc;
            l2.Meta = "true";
            lstBudgets.Items[newActive] = l2;
        }

        private void SetLockStatusInList()
        {
            //  change current budget to active
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;
            CBBudget bud;
            int indx = 0;
            string newDesc = "";

            bud = new CBBudget();

            bud.Load(li.ID);

            if (bud.IsActive == true)
            {
                newDesc = bud.GetNumber() + " (A)";
            }
            else
            {
                newDesc = bud.GetNumber();
            }

            indx = lstBudgets.SelectedIndex;
            RevSol.RSListItem l2 = (RevSol.RSListItem)lstBudgets.Items[indx];
            l2.Description = newDesc;
            lstBudgets.Items[indx] = l2;
        }



        //private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        //{RemoveCurrentLine(SelectedGroupTab); }


        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e) ///****************Experimenting 7/14/2015
        {
           
                //do something
                        
                int currRw = fgForGroup(SelectedGroupTab).Row;
                int currID;
                var fg = fgForGroup(SelectedGroupTab);
                if (currRw < 0) return;

                //don't delete the last node
               // if (CountChildren(fg, fg.Rows[currRw].Node) == 1) return;

                currID = Convert.ToInt32(fg.Rows[currRw][BUDCOL16]);

                //MessageBox.Show(currID.ToString());

                CBBudgetLine bl= new CBBudgetLine();
                bl.Load(currID);
                      int el = bl.EntryLevel;
            // MessageBox.Show(el.ToString());
           
            if (el == 2)

            {   
                  MessageBox.Show("This record is associated with Work Sheet, Please remove it from WorkSheet");
                    return;
            }
            else
                RemoveCurrentLine(SelectedGroupTab);           
            
            }

        private static int IndexOf_Hyphen(string str, char c, int n)
        {
            int s = -1;

            for (int i = 0; i < n; i++)
            {
                s = str.IndexOf(c, s + 1);

                if (s == -1) break;
            }

            return s;
        }



        public int CountChildren(C1FlexGrid fg, Node node) 
        {
            var index = node.Row.Index;
            List<Row> rows = new List<Row>();
            foreach( Row row in fg.Rows ){
                if (row.Node != null && row.Node.Row.Index == index)
                rows.Add(row); 
            }
            return rows.Where(x => x != node.Row).Count();
        }

        private void RemoveCurrentLine(string group)
        {
            int currRw = fgForGroup(group).Row;
            int currID;
            var fg = fgForGroup(group);
            if (currRw < 0) return;

            //don't delete the last node
            if ( CountChildren(fg, fg.Rows[currRw].Node ) == 1) return;

            currID = Convert.ToInt32(fg.Rows[currRw][BUDCOL16]);

            fg.Rows.Remove(currRw);

            CBBudgetLine.Delete(currID);

            TotalBudget(group,true);
        }

        private void UpdateIDOfCurrentBudgetList(int newID)
        {
            //  change current budget to active
            int indx = lstBudgets.SelectedIndex;

            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

            li.ID = newID;
            lstBudgets.Items[indx] = li;
        }

        private CBBudgetLine CBBudgetLineFromFg(C1.Win.C1FlexGrid.Row r, int group_int)
        {
            var bl = new CBBudgetLine();
            bl.ID = Convert.ToInt32(r[BUDCOL16]);
            bl.BudgetID = moCurrBudget.ID;
            bl.DeptGroup = group_int;
            bl.EntryLevel = GetEntryLevel(r);
            bl.Task = r[BUDCOL5].As<string>().ToInt() ?? 0;
            bl.Category = r[BUDCOL6].As<string>().ToInt() ?? 0;
            bl.Activity = r[BUDCOL7].As<string>().ToInt() ?? 0;
            bl.WBS = r[BUDCOL9].ToString();
            bl.Description = r[BUDCOL10].ToString();
            bl.Quantity = r[BUDCOL11].As<string>().ToInt() ?? 0;
            bl.HoursEach = r[BUDCOL12].As<string>().ToInt() ?? 0;
            bl.TotalHours = r[BUDCOL13].As<string>().ToInt() ?? 0;
            bl.LoadedRate = r[BUDCOL14].As<string>().ToDecimal() ?? 0; // was ToInt()
            bl.TotalDollars = r[BUDCOL15].As<string>().ToDecimal() ?? 0;
            
            
                    


            bl.BareRate = 0;
            bl.BareDollars = 0;

           // MessageBox.Show("CBBudgetLineFromFg");
            return bl;
        }

        private void SaveBudgetLines(string group)
        {
            CBBudgetLine bl;
            var fg = fgForGroup(group);
            int group_int = Int32.Parse(group);

            foreach (C1.Win.C1FlexGrid.Row r in fg.Rows)
            {
                if (r[BUDCOL8] != null && RevSol.RSMath.IsInteger(r[BUDCOL8]) == true)
                {
                    bl = CBBudgetLineFromFg(r, group_int);
                    bl.Save();
                    r[BUDCOL16] = bl.ID;
                }
            }

           // MessageBox.Show("SaveBudgetLines");
        }

        private void SaveExpenseLines(string group)
        {
            CBBudgetExpenseLine el;
            var fgExp = fgExpForGroup(group);
            var group_int = Int32.Parse(group);

            foreach (C1.Win.C1FlexGrid.Row r in fgExp.Rows)
            {
                if (r[3].ToString() != "Description")
                {
                    el = new CBBudgetExpenseLine();

                    el.ID = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(r[9]));
                    el.BudgetID = moCurrBudget.ID;
                    el.DeptGroup = group_int;
                    el.EntryLevel = 1;
                    el.Code = r[1].ToString();
                    el.MarkUp = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(r[2]));
                    el.Description = r[3].ToString();
                    el.UOMID = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(r[10]));
                    el.DollarsEach = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(r[5]));
                    el.Quantity = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(r[6]));
                    el.MarkupDollars = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(r[7]));
                    el.TotalDollars = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(r[8]));

                    el.Save();

                    r[9] = el.ID;
                }
            }

           // MessageBox.Show("SaveExpenseLines");
        }

        private void SaveExpenseLines(string group, int row)
        {
            CBBudgetExpenseLine el;
            var fgExp = fgExpForGroup(group);
            var group_int = Int32.Parse(group);

            el = new CBBudgetExpenseLine();

            el.ID = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(fgExp[row, 9]));
            el.BudgetID = moCurrBudget.ID;
            el.DeptGroup = group_int;
            el.EntryLevel = 1;
            el.Code = fgExp[row, 1].ToString(); ;
            el.MarkUp = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(fgExp[row, 2]));
            el.Description = fgExp[row, 3].ToString(); ;
            el.UOMID = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(fgExp[row, 10]));
            el.DollarsEach = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(fgExp[row, 5]));
            el.Quantity = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(fgExp[row, 6]));
            el.MarkupDollars = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(fgExp[row, 7]));
            el.TotalDollars = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(fgExp[row, 8]));

            el.Save();

            fgExp[row, 9] = el.ID;

           // MessageBox.Show("SaveExpenseLines(string group, int row)");
        }


        private int GetEntryLevel(C1.Win.C1FlexGrid.Row rw)
        {
            int entryLevel;

            switch (rw.Style.Name)
            {
                case "RSWorksheetEdit":
                    entryLevel = 2;
                    break;
                default:
                    entryLevel = 1;
                    break;
            }

            return entryLevel;
        }

        private void SetEntryLevel(int entryLevel, int groupNum, ref C1.Win.C1FlexGrid.Row rw)
        {
            var fg = fgForGroup(groupNum + "");
            switch (entryLevel)
            {
                case 2:
                    rw.Style = fg.Styles["RSWorksheetEdit"];
                    break;
                case 3:
                    rw.Style = fg.Styles["RSWorksheetEdit"];
                    break;
                default:
                    rw.Style = fg.Styles["RSAllowEdit"];
                    break;
            }
        }

        public void ClearBudgetLineIDForRevision(string group)
        {
            var fg = fgForGroup(group);
            foreach (C1.Win.C1FlexGrid.Row r in fg.Rows)
            {
                r[BUDCOL16] = "0";
            }
        }

        private void SaveChangeToDB(string group, int rw)
        {
            CBBudgetLine bl = new CBBudgetLine();
            var fg = fgForGroup(group);

            bl.ID = Convert.ToInt32(fg[rw, BUDCOL16]);
            bl.BudgetID = moCurrBudget.ID;
            bl.DeptGroup = Int32.Parse(group);
            bl.EntryLevel = GetEntryLevel(fg.Rows[rw]);
            bl.Task = Convert.ToInt32(fg[rw, BUDCOL5]);
            bl.Category = Convert.ToInt32(fg[rw, BUDCOL6]);
            bl.Activity = Convert.ToInt32(fg[rw, BUDCOL7]);
            bl.WBS = fg[rw, BUDCOL9].ToString();
            bl.Description = fg[rw, BUDCOL10].ToString();
            bl.Quantity = Convert.ToInt32(fg[rw, BUDCOL11]);
            bl.HoursEach = Convert.ToInt32(fg[rw, BUDCOL12]);
            bl.TotalHours = Convert.ToInt32(fg[rw, BUDCOL13]);
            bl.LoadedRate = Convert.ToDecimal(fg[rw, BUDCOL14]);
            bl.TotalDollars = Convert.ToDecimal(fg[rw, BUDCOL15]);
            bl.BareRate = 0;
            bl.BareDollars = 0;

            bl.Save();

            fg[rw, BUDCOL16] = bl.ID;
           // MessageBox.Show("SaveChangeToDB");

        }



        private void fg_AfterEdit(string group, object sender, RowColEventArgs e)
        {
            var fg = this.fgForGroup(group);
            if (fg[e.Row, BUDCOL8] == null || RevSol.RSMath.IsInteger(fg[e.Row, BUDCOL8]) == false)
                return;     // must be in heading and need to skip processing

            if (e.Col >= QUANTITYCOLUMN)
            {
                int qty = Convert.ToInt32(fg[e.Row, QUANTITYCOLUMN]);                    // Quantity
                decimal hrsEach = Convert.ToDecimal(fg[e.Row, QUANTITYCOLUMN + 1]);      // Hours/Each
                decimal loadRate = Convert.ToDecimal(fg[e.Row, QUANTITYCOLUMN + 3]);    //  Loaded Rate
                fg[e.Row, QUANTITYCOLUMN + 2] = (decimal)qty * hrsEach;                  // total hours
                fg[e.Row, QUANTITYCOLUMN + 4] = (decimal)qty * hrsEach * loadRate;      // total dollars
            }

            string wbs = fg[e.Row, BUDCOL9].ToString();
            CheckToAddNewWBSCode(wbs);

            SaveChangeToDB(group, e.Row);
            SubTotal(group);

            //tlbbNewRev.Enabled = false;
            tlbbSaveRev.Enabled = true;
            TotalBudget(group,true);
        }


        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            tmrLoad.Enabled = false;

            mbProcessing = true;
            StartNewBudget();
            mbProcessing = false;

            DoBudgetSelectChange();
        }

        private void LoadWorksheet(string group)
        {
            SqlDataReader dr;

            mdsWS[group] = new dsWorkSheet();

            dr = CBBudgetWorksheet.GetListByBudgetGroup(moCurrBudget.ID, Int32.Parse(group) );

            while (dr.Read())
            {
                DataRow d = mdsWS[group].Tables["Worksheet"].NewRow();

                d["ID"] = dr["ID"];
                d["BudgetID"] = dr["BudgetID"];
                d["WorkGuid"] = dr["WorkGuid"];
                d["ItemDescription"] = dr["ItemDescription"];
                d["WBS"] = dr["WBS"];
                d["QtyEach"] = dr["Quantity"];
                d["Spec211"] = dr["Spec211"];
                d["Spec212"] = dr["Spec212"];
                d["Spec213"] = dr["Spec213"];
                d["Spec214"] = dr["Spec214"];
                d["Spec215"] = dr["Spec215"];
                d["Proc221"] = dr["Proc221"];
                d["Proc222"] = dr["Proc222"];
                d["Proc223"] = dr["Proc223"];
                d["Proc224"] = dr["Proc224"];
                d["Proc225"] = dr["Proc225"];
                d["Proc226"] = dr["Proc226"];
                d["Proc227"] = dr["Proc227"];
                d["Proc229"] = dr["Proc229"];

                mdsWS[group].Tables["Worksheet"].Rows.Add(d);
            }
        }

        private void LoadExpenseWorksheet(string group)
        {
            SqlDataReader dr;

            dr = CBBudgetExpenseSheet.GetListByBudgetGroup(moCurrBudget.ID, Int32.Parse(group) );

            while (dr.Read())
            {
                DataRow d = mdsWS[group].Tables["Expenses"].NewRow();

                d["ID"] = dr["ID"];
                d["BudgetID"] = dr["BudgetID"];
                d["WorkGuid"] = dr["WorkGuid"];
                d["Description"] = dr["Description"];
                d["TripQty"] = dr["Quantity"];
                d["RoundTripMiles"] = dr["RoundTrips"];
                d["NumberOfPeople"] = dr["People"];
                d["NumDays"] = dr["NumDays"];
                d["NumNights"] = dr["NumNights"];
                d["HrsPerDay"] = dr["HoursPerDay"];
                d["E110"] = dr["E110"];
                d["E120"] = dr["E120"];
                d["E130"] = dr["E130"];
                d["E140"] = dr["E140"];
                d["E150"] = dr["E150"];
                d["E160"] = dr["E160"];
                d["E170"] = dr["E170"];
                d["E180"] = dr["E180"];
                d["E190"] = dr["E190"];
                d["E281"] = dr["E281"];
                d["E282"] = dr["E282"];
                d["E283"] = dr["E283"];
                d["E284"] = dr["E284"];
                d["E290"] = dr["E290"];
                d["E310"] = dr["E310"];
                d["E320"] = dr["E320"];
                d["E330"] = dr["E330"];
                d["E340"] = dr["E340"];
                d["E350"] = dr["E350"];
                d["E541"] = dr["E541"];
                d["E542"] = dr["E542"];
                d["E543"] = dr["E543"];
                d["E561"] = dr["E561"];
                d["E562"] = dr["E562"];
                d["E580"] = dr["E580"];
                d["E591"] = dr["E591"];
                d["E592"] = dr["E592"];
                d["E593"] = dr["E593"];
                d["E594"] = dr["E594"];
                d["E595"] = dr["E595"];

                mdsWS[group].Tables["Expenses"].Rows.Add(d);
            }
        }

        private void CopyBudget(int orgID, int newID)
        {
            CBBudgetLine.CopyBudgetLines(orgID, newID);
            CBBudgetWorksheet.CopyBudgetWorksheet(orgID, newID);
            CBBudgetExpenseLine.CopyExpenseLines(orgID, newID);
            CBBudgetExpenseSheet.CopyBudgetExpenseWorksheet(orgID, newID);
        }

        private void bttHide_Click( string group, object sender, EventArgs e)
        {
            miExpHght[group] = pnlExpForGroup(group).Height;
            pnlExpForGroup(group).Height = 25;
        }

        private void bttShow_Click(string group, object sender, EventArgs e)
        {
            // SSS 20131204 pnlExpForGroup(group).Height = miExpHght[group];
            //when clicking hide twice the default height was lost.  Set the value to always be the default.
            pnlExpForGroup(group).Height = 250;
            
        }


        private void fgExp_AfterEdit(string group, object sender, RowColEventArgs e)
        {
            var fgExp = fgExpForGroup(group);

            int markup = Convert.ToInt32(fgExp[e.Row, 2]);
            decimal dllrPerItm = Convert.ToDecimal(fgExp[e.Row, 5]);
            int numItms = Convert.ToInt32(fgExp[e.Row, 6]);
            decimal muDllrs, totDllrs;

            if (e.Col == 7)
            {
                muDllrs = Convert.ToDecimal(fgExp[e.Row, 7]);
                totDllrs = muDllrs + (dllrPerItm * Convert.ToDecimal(numItms));

                fgExp[e.Row, 8] = totDllrs.ToString("#,##0.00");
            }
            else
            {
                muDllrs = (Convert.ToDecimal(markup) / 100.0m) * (dllrPerItm * Convert.ToDecimal(numItms));
                totDllrs = muDllrs + (dllrPerItm * Convert.ToDecimal(numItms));

                fgExp[e.Row, 7] = muDllrs.ToString("#,##0.00");
                fgExp[e.Row, 8] = totDllrs.ToString("#,##0.00");
            }

            SaveExpenseChangeToDB(group, e.Row);
            TotalBudget(group, true);
        }


        private void SaveExpenseChangeToDB(string group, int rw)
        {
            CBBudgetExpenseLine el = new CBBudgetExpenseLine();
            var fgExp = fgExpForGroup(group);

            el.ID = Convert.ToInt32(fgExp[rw, 9]);
            el.BudgetID = moCurrBudget.ID;
            el.DeptGroup = Int32.Parse(group);
            el.EntryLevel = 0;
            el.Code = fgExp[rw, 1].ToString();
            el.Description = fgExp[rw, 3].ToString();
            el.MarkUp = Convert.ToDecimal(fgExp[rw, 2]);
            //el.UOMID = Convert.ToInt32(fgExp[rw, 10]);
            el.UOMID = UOMIDFromUomText(fgExp[rw, 4].ToString());
            el.DollarsEach = Convert.ToDecimal(fgExp[rw, 5]);
            el.Quantity = Convert.ToInt32(fgExp[rw, 6]);
            el.MarkupDollars = Convert.ToDecimal(fgExp[rw, 7]);
            el.TotalDollars = Convert.ToDecimal(fgExp[rw, 8]);

            el.Save();

            fgExp[rw, 9] = el.ID;
            fgExp[rw, 10] = el.UOMID;
        }

        private int UOMIDFromUomText(string uom)
        {
            int uomID = 0;

            lstExpUOMs.Text = uom;
            uomID = ((RevSol.RSListItem)lstExpUOMs.SelectedItem).ID;

            return uomID;
        }


        private void tdbgBudgetPCN_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            //DataRow d4 = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];

            if (e.ColIndex == 5 && Convert.ToBoolean(tdbgBudgetPCN.Tag) == true)
            {
                CBBudgetPCN pcn = new CBBudgetPCN();
                DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];

                int pcnID = Convert.ToInt32(d["ID"]);
                pcn.Load(pcnID);

                DataRow d2 = mdsPCNStatus.Tables["Statuss"].Rows[tdbdPCNStatus.Bookmark]; // ********************was Statuss ******corrected and again made Statuss**********
                pcn.PCNStatusID = Convert.ToInt32(d2["ID"]);
                pcn.Save();

                CBBudgetPCN.SetCurrentStatus(pcnID, pcn.PCNStatusID);
                string msg;
                RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

                msg = "This will make " + li.Description + " the active project\nThis will also enter the information into the JobStat\nDo you wish to continue?";

                if (MessageBox.Show(msg, "Make Project Active", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CBBudget.MakeBudgetActive(li.ID);

                    SetActiveInList();

                    tlbbMakeActive.Enabled = false;
                    makeActiveToolStripMenuItem.Enabled = false;

                    MakeProjectActiveInJobStat(li.ID);
                }

                //**************************************added on 5/6
                        string st = Convert.ToString(d["PCNStatus"]);
                        if (st == "Approved" || st == "Disapprove" || st == "Pending" || st == "Prepare Control Estimate") { bttEditPCN.Enabled = false; }
                //**************************************


            }
            /************************************This is edited on 5/6****@2:56
            if (e.ColIndex == 2)
            {
                CBBudgetPCN pcn = new CBBudgetPCN();
                DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];

                int pcnID = Convert.ToInt32(d["ID"]);
                pcn.Load(pcnID);

                pcn.PCNTitle = d["Description"].ToString();
                pcn.Save();
            }*/

            if (e.ColIndex == 2)
            {
                DataRow d3 = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
                string st_status = Convert.ToString(d3["PCNStatus"]);
                              
                if (st_status == "Initiated")
                {
                    CBBudgetPCN pcn = new CBBudgetPCN();
                    DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];

                    int pcnID = Convert.ToInt32(d["ID"]);
                    pcn.Load(pcnID);

                    pcn.PCNTitle = d["Description"].ToString();
                    pcn.Save();
                }
                else
                {                   
                    int r_i = tdbgBudgetPCN.Row;
                    tdbgBudgetPCN[r_i, 2] = st_Description;
                 }
                //MessageBox.Show("You cannot edit Description with Approved/Pendind/Disapprove PCN");
            }





        }

        private void tdbgBudgetPCN_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            //MessageBox.Show("Please Hit enter to Change PCN Status");
            tdbgBudgetPCN.Tag = true;

            if (e.Column.Name == "Status")
            {
                if (e.OldValue.ToString() == "Approved")
                {
                    if (UnApprovePCN() == false)
                    {
                        e.Cancel = true;

                        tdbgBudgetPCN.Tag = false;    // tell other functions to not update

                        pa_OnChangeCancelled(e.OldValue.ToString(), 0);
                    }
                }
                else
                {
                    FBudgetPCNApproval pa = new FBudgetPCNApproval();
                    //SSS02192014
                    if (tdbgBudgetPCN.Columns["Status"].Value.ToString() == "Approved" | tdbgBudgetPCN.Columns["Status"].Value.ToString() == "Pending")
                    {
                        pa.IsChangeOnly = false;


                    }
                    else
                        pa.IsChangeOnly = true;

                    pa.PreviousEntry = e.OldValue.ToString();
                    pa.OnChangeApproved += new RevSol.PassDataStringWithIndex(pa_OnChangeApproved);
                    pa.OnChangeCancelled += new RevSol.PassDataStringWithIndex(pa_OnChangeCancelled);
                    pa.ShowDialog();
                    pa.OnChangeApproved -= new RevSol.PassDataStringWithIndex(pa_OnChangeApproved);
                    pa.OnChangeCancelled -= new RevSol.PassDataStringWithIndex(pa_OnChangeCancelled);
                }
            }

            //bttEditPCN.Enabled = false; // Added 5/6 **************@10:52

        }

        private bool UnApprovePCN()
        {
            // check to make sure it is not associated with any budgets
            DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            int pcnID = Convert.ToInt32(d["ID"]);
            bool unAppVal = false;

            if (CBBudgetPCN.GetBudgetsWithPCN(pcnID) > 0)
            {
                MessageBox.Show("This PCN is associated with a budget and cannot have its status changed until the budget is deleted", "PCN Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);

                unAppVal = false;
            }
            else
            {
                if (MessageBox.Show("Are your sure that you wish to change the status of this PCN?", "PCN Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FBudgetPCNApproval pa = new FBudgetPCNApproval();
                    pa.IsUserCheckOnly = true;
                    pa.ShowDialog();

                    unAppVal = pa.IsApproved;

                    pa.Close();
                }
                else
                {
                    unAppVal = false;
                }
            }

            return unAppVal;
        }

        void pa_OnChangeCancelled(string val, int index)
        {
            tdbgBudgetPCN.Tag = false;

            tdbgBudgetPCN.Columns["Status"].Value = val;
            tdbgBudgetPCN.UpdateData();
        }

        void pa_OnChangeApproved(string val, int index)
        {
            if (val == "NO")
            {
                tdbgBudgetPCN.Tag = true;

                DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
                //tdbgBudgetPCN.UpdateData();

                int pcnID = Convert.ToInt32(d["ID"]);

                AddPCNToCurrentBudget(pcnID);
            }
        }

        private void bttAddPCN_Click(object sender, EventArgs e)
        {
            FBudgetPCNAddition pcn = new FBudgetPCNAddition();

            pcn.OnPCNChanged += new RevSol.ItemValueChangedHandler(PCNAdded);
            pcn.StartNewPCN(moCurrBudget.ProjectID);
            pcn.ShowDialog();
            pcn.OnPCNChanged -= new RevSol.ItemValueChangedHandler(PCNAdded);
        }




        void PCNAdded(int itmID, string name)
        {
            CBBudgetPCN pcn = new CBBudgetPCN();

            pcn.Load(itmID);

            DataRow dr = mdsPCNs.Tables["PCNs"].NewRow();

            dr["ID"] = pcn.ID;
            dr["BudgetID"] = pcn.BudgetID;
            dr["PCNNumber"] = pcn.PCNNumber;
            dr["Description"] = pcn.PCNTitle;
            dr["PCNStatusID"] = pcn.PCNStatusID;
            dr["PCNStatus"] = "Initiated";
            dr["TotalHrs"] = CBBudgetPCN.TotalHours(itmID);
            dr["TotalDlrs"] = CBBudgetPCN.TotalDollars(itmID);

            mdsPCNs.Tables["PCNs"].Rows.Add(dr);

            //bttEditPCN.Enabled = true;    //**************************************commented on 5/6
        }

        private void bttEditPCN_Click(object sender, EventArgs e)
        {
         
            FBudgetPCNAddition pcn = new FBudgetPCNAddition();

            DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            int currID = Convert.ToInt32(d["ID"]);
        //    string stat = tdbgBudgetPCN.Columns["Status"].Value.ToString();
            //Console.WriteLine("The Status is: " + stat);
           // if (stat == "Approved" || stat == "Pending" || stat == "Disapprove" || stat == "Prepare Control Estimate" || stat != "Initiated") { bttEditPCN.Enabled = false; }
            //else {             
                pcn.OnPCNChanged += new RevSol.ItemValueChangedHandler(PCNChanged);
                pcn.EditPreviousPCN(currID);
                pcn.ShowDialog();
                pcn.OnPCNChanged -= new RevSol.ItemValueChangedHandler(PCNChanged);
          //      }

        }

        void PCNChanged(int itmID, string name)
        {
            CBBudgetPCN pcn = new CBBudgetPCN();

            pcn.Load(itmID);

            DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            
            d["Description"] = pcn.PCNTitle;
            d["TotalHrs"] = CBBudgetPCN.TotalHours(itmID);
            d["TotalDlrs"] = CBBudgetPCN.TotalDollars(itmID);
            if (pcn.PCNNumber != null)
            { d["PCNNumber"] = pcn.PCNNumber; }
        
            
         }
        private void bttCopyPCN_Click_1(object sender, EventArgs e)
        {
           
            FBudgetPCNAddition pcn = new FBudgetPCNAddition();

            DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            int currID = Convert.ToInt32(d["ID"]);


            pcn.OnPCNChanged += new RevSol.ItemValueChangedHandler(PCNAdded);
            pcn.CopyPCN(moCurrBudget.ProjectID, currID);
            currID = 0; 
            pcn.SaveCopyPCN();
            pcn.ShowDialog();
            pcn.OnPCNChanged -= new RevSol.ItemValueChangedHandler(PCNAdded);

          

        }

        private void AddPCNToCurrentBudget(int pcnID)
        {
            CBBudgetPCN pcn = new CBBudgetPCN();
            int code;
            string wbs;
            string desc;
            int hrs;
            decimal rate;
            int newBud;

            newBud = MakeNewRevision(pcnID);

            pcn.LoadWithData(pcnID);

            foreach (DataRow d in pcn.PCNData.Tables["PCNHours"].Rows)
            {
                code = Convert.ToInt32(d["Code"]);
                wbs = d["WBS"].ToString();
                desc = d["Description"].ToString();
                hrs = Convert.ToInt32(d["SubtotalHrs"]);
                rate = Convert.ToDecimal(d["Rate"]);

                AddPCNByCode(pcn.PCNNumber, code, wbs, desc, hrs, rate);
            }

            AddPCNExpenses(pcn.ID, pcn.PCNNumber, pcn.PCNData);
        }

        private void AddPCNByCode(string pcnNum, int code, string wbs, string desc, int hrs, decimal rate)
        {
            string newDesc;

            newDesc = "PCN" + pcnNum + " " + wbs + " " + desc;

            //code is int so extra bits are trashed
            int group = (code / 1000) * 1000;
            InsertLineFromPCN(0, group, code, wbs, newDesc, 1, hrs, rate);
        }

        private void AddPCNExpenses(int pcnID, string pcnNum, dsPCN pcns)
        {
            var group = _Default_Group;

            int travelFare, autoRental, tolls, fuel, mileage, meals, lodging, perdiem, miscExp, survey1, survey2, survey3, survey4, survsup, engserv, surveying, geotinv, environ, specsub, atv, oruv, boat, digcam, cphone, fldcomp, trimbler8, trimblegeo, etotstat, lasrange, pipeloc; 
            string rowCode;

            travelFare = 0;
            autoRental = 0;
            tolls = 0;
            fuel = 0;
            mileage = 0;
            meals = 0;
            lodging = 0;
            perdiem = 0;
            miscExp = 0;
            survey1 = 0;
            survey2 = 0;
            survey3 = 0;
            survey4 = 0;
            survsup = 0;
            engserv = 0;
            surveying = 0;
            geotinv = 0;
            environ = 0;
            specsub = 0;
            atv = 0;
            oruv = 0;
            boat = 0;
            digcam = 0;
            cphone = 0;
            fldcomp = 0;
            trimbler8 = 0;
            trimblegeo = 0;
            etotstat = 0;
            lasrange = 0;
            pipeloc = 0;

            // find entries to make new worksheet line
            foreach (DataRow d in pcns.Tables["PCNExpenses"].Rows)
            {

                rowCode = d["Code"].ToString();

                switch (rowCode)
                {
                    case "E110":
                        travelFare += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E120":
                        autoRental += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E130":
                        tolls += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E140":
                        fuel += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E150":
                        mileage += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E160":
                        meals += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E170":
                        lodging += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E180":
                        perdiem += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E190":
                        miscExp += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E281":
                        survey1 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E282":
                        survey2 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E283":
                        survey3 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E284":
                        survey4 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E290":
                        survsup  += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E310":
                        engserv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E320":
                        surveying += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E330":
                        geotinv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E340":
                        environ += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E350":
                        specsub += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E541":
                        atv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E542":
                        oruv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E543":
                        boat += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E561":
                        digcam += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E562":
                        cphone += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E580":
                        fldcomp += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E591":
                        trimbler8 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E592":
                        trimblegeo += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E593":
                        etotstat += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E594":
                        lasrange += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    case "E595":
                        pipeloc += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(d["NumItems"]));
                        break;
                    default:
                        AddPCNExpensesNonWorksheet(pcnID, rowCode, Convert.ToInt32(d["NumItems"]), Convert.ToDecimal(d["DlrsPerItem"]), Convert.ToDecimal(d["MUPerc"]));
                        break;
                }
            }

            // create worksheet entries for pcn expenses
            CBBudgetExpenseSheet es = new CBBudgetExpenseSheet();

            es.ID = 0;
            es.BudgetID = moCurrBudget.ID;
            es.WorkGuid = Guid.NewGuid().ToString();
            es.DeptGroup = Int32.Parse(group);
            es.Description = pcnNum;
            es.Quantity = 1;
            es.RoundTrips = 0;
            es.People = 1;
            es.NumDays = 1;
            es.NumNights = 1;
            es.HoursPerDay = 8;
            es.TravelHours = 0;
            es.E110 = travelFare;
            es.E120 = autoRental;
            es.E130 = tolls;
            es.E140 = fuel;
            es.E150 = mileage;
            es.E160 = meals;
            es.E170 = lodging;
            es.E180 = perdiem;
            es.E190 = miscExp;
            es.E281 = survey1;
            es.E282 = survey2;
            es.E283 = survey3;
            es.E284 = survey4;
            es.E290 = survsup;
            es.E310 = engserv;
            es.E320 = surveying;
            es.E330 = geotinv;
            es.E340 = environ;
            es.E350 = specsub;
            es.E541 = atv;
            es.E542 = oruv;
            es.E543 = boat;
            es.E561 = digcam;
            es.E562 = cphone;
            es.E580 = fldcomp;
            es.E591 = trimbler8;
            es.E592 = trimblegeo;
            es.E593 = etotstat;
            es.E594 = lasrange;
            es.E595 = pipeloc;

            es.Save();

            DataRow eRow = mdsWS[group].Tables["Expenses"].NewRow();
            eRow["ID"] = es.ID;
            eRow["BudgetID"] = moCurrBudget.ID;
            eRow["Description"] = pcnNum;
            eRow["TripQty"] = 1;
            eRow["RoundTripMiles"] = 0;
            eRow["NumberOfPeople"] = 1;
            eRow["NumDays"] = 1;
            eRow["NumNights"] = 1;
            eRow["HrsPerDay"] = 8;
            eRow["E110"] = travelFare;
            eRow["E120"] = autoRental;
            eRow["E130"] = tolls;
            eRow["E140"] = fuel;
            eRow["E150"] = mileage;
            eRow["E160"] = meals;
            eRow["E170"] = lodging;
            eRow["E180"] = perdiem;
            eRow["E190"] = miscExp;
            eRow["E281"] = survey1;
            eRow["E282"] = survey2;
            eRow["E283"] = survey3;
            eRow["E284"] = survey4;
            eRow["E290"] = survsup;
            eRow["E310"] = engserv;
            eRow["E320"] = surveying;
            eRow["E330"] = geotinv;
            eRow["E340"] = environ;
            eRow["E350"] = specsub;
            eRow["E541"] = atv;
            eRow["E542"] = oruv;
            eRow["E543"] = boat;
            eRow["E561"] = digcam;
            eRow["E562"] = cphone;
            eRow["E580"] = fldcomp;
            eRow["E591"] = trimbler8;
            eRow["E592"] = trimblegeo;
            eRow["E593"] = etotstat;
            eRow["E594"] = lasrange;
            eRow["E595"] = pipeloc;

            mdsWS[group].Tables["Expenses"].Rows.Add(eRow);

            AddPCNWorksheetExpenses();
        }

        private void AddPCNWorksheetExpenses()
        {
            var group = _Default_Group;

            ClearExpenseLines(group);

            int travelFare, autoRental, tolls, fuel, mileage, meals, lodging, perdiem, miscExp, survey1, survey2, survey3, survey4, survsup, engserv, surveying, geotinv, environ, specsub, atv, oruv, boat, digcam, cphone, fldcomp, trimbler8, trimblegeo, etotstat, lasrange, pipeloc;
            string rowCode;

            travelFare = 0;
            autoRental = 0;
            tolls = 0;
            fuel = 0;
            mileage = 0;
            meals = 0;
            lodging = 0;
            perdiem = 0;
            miscExp = 0;
            survey1 = 0;
            survey2 = 0;
            survey3 = 0;
            survey4 = 0;
            survsup = 0;
            engserv = 0;
            surveying = 0;
            geotinv = 0;
            environ = 0;
            specsub = 0;
            atv = 0;
            oruv = 0;
            boat = 0;
            digcam = 0;
            cphone = 0;
            fldcomp = 0;
            trimbler8 = 0;
            trimblegeo = 0;
            etotstat = 0;
            lasrange = 0;
            pipeloc = 0;

            foreach (DataRow dr in mdsWS[group].Tables["Expenses"].Rows)
            {
                travelFare += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E110"]));
                autoRental += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E120"]));
                tolls += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E130"]));
                fuel += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E140"]));
                mileage += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E150"]));
                meals += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E160"]));
                lodging += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E170"]));
                perdiem += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E180"]));
                miscExp += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E190"]));
                survey1 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E281"]));
                survey2 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E282"]));
                survey3 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E283"]));
                survey4 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E284"]));
                survsup += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E290"]));
                engserv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E310"]));
                surveying += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E320"]));
                geotinv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E330"]));
                environ += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E340"]));
                specsub += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E350"]));
                atv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E541"]));
                oruv += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E542"]));
                boat += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E543"]));
                digcam += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E561"]));
                cphone += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E562"]));
                fldcomp += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E580"]));
                trimbler8 += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E591"]));
                trimblegeo += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E592"]));
                etotstat += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E593"]));
                lasrange += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E594"]));
                pipeloc += Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E595"]));
            }

            var fgExp = fgExpForGroup(group);
            foreach (C1.Win.C1FlexGrid.Row r in fgExp.Rows)
            {
                rowCode = r[1].ToString();
                switch (rowCode)
                {
                    case "E110":
                        r[6] = travelFare;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E120":
                        r[6] = autoRental;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E130":
                        r[6] = tolls;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E140":
                        r[6] = fuel;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E150":
                        r[6] = mileage;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E160":
                        r[6] = meals;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E170":
                        r[6] = lodging;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E180":
                        r[6] = perdiem;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E190":
                        r[6] = miscExp;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E281":
                        r[6] = survey1;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E282":
                        r[6] = survey2;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E283":
                        r[6] = survey3;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E284":
                        r[6] = survey4;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E290":
                        r[6] = survsup;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E310":
                        r[6] = engserv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E320":
                        r[6] = surveying;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E330":
                        r[6] = geotinv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E340":
                        r[6] = environ;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E350":
                        r[6] = specsub;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E541":
                        r[6] = atv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E542":
                        r[6] = oruv;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E543":
                        r[6] = boat;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E561":
                        r[6] = digcam;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E562":
                        r[6] = cphone;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E580":
                        r[6] = fldcomp;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E591":
                        r[6] = trimbler8;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E592":
                        r[6] = trimblegeo;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E593":
                        r[6] = etotstat;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E594":
                        r[6] = lasrange;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    case "E595":
                        r[6] = pipeloc;
                        fgExp_AfterEdit(group, this, new RowColEventArgs(r.Index, 6));
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddPCNExpensesNonWorksheet(int pcnID, string rowCode, int quantity, decimal dlrsPer, decimal mu)
        {
            CBBudgetPCN pcn = new CBBudgetPCN();
            pcn.Load(pcnID);
            AddPCNExpensesNonWorkSheet(_Default_Group, pcn.PCNNumber, rowCode, rowCode, quantity, dlrsPer, mu, 0);
        }


        private void AddPCNExpensesNonWorkSheet(string group, string pcnNumber, string rowCode, string description, int quantity, decimal dlrsPer, decimal mu, int uomID)
        {
            string gridCode;
            int currIndx = -1;
            C1FlexGrid fgExp = fgExpForGroup(group);

            foreach (C1.Win.C1FlexGrid.Row r in fgExp.Rows)
            {
                gridCode = r[1].ToString();

                if (gridCode == rowCode)
                {
                    currIndx = r.Index;

                    break;
                }
            }

            if (currIndx >= 0)
            {
                Row rw = fgExp.Rows.Insert(currIndx + 1);

                rw[1] = rowCode;
                rw[2] = mu.ToString(DEFAULTINTEGER);
                rw[3] = "PCN";
                rw[4] = "Each";  // UOM code
                rw[5] = dlrsPer.ToString(DEFAULTDOLLARS);
                rw[06] = quantity.ToString();
                rw[07] = ((quantity * dlrsPer) * (mu / 100m)).ToString(DEFAULTDOLLARS);
                rw[08] = ((quantity * dlrsPer) + ((quantity * dlrsPer) * (mu / 100m))).ToString(DEFAULTDOLLARS);
                rw[9] = 0;
                rw[10] = 0; // uom id

                CBBudgetExpenseLine el;

                el = new CBBudgetExpenseLine();

                el.ID = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(rw[9]));
                el.BudgetID = moCurrBudget.ID;
                el.DeptGroup = Int32.Parse(group);
                el.EntryLevel = 1;
                el.Code = rowCode;
                el.MarkUp = mu;
                el.Description = rw[3].ToString();
                el.UOMID = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(rw[10]));
                el.DollarsEach = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(rw[5]));
                el.Quantity = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(rw[6]));
                el.MarkupDollars = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(rw[7]));
                el.TotalDollars = Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(rw[8]));

                el.Save();

                rw[9] = el.ID;
            }
        }



        private void tdbgBudgetPCN_Click(object sender, EventArgs e) //******************Commented 9:51
        //private string tdbgBudgetPCN_Click(object sender, EventArgs e)
        {
            if (tdbgBudgetPCN.Bookmark >= 0)
            {
               // bttEditPCN.Enabled = true; //***********************Commented****MZ
            }          
            
            
            
            
            //string stat = tdbgBudgetPCN.Columns["Status"].Value.ToString();

            //Console.WriteLine("The Status is: " + stat);


            DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];//***********************Added 9:48
            st_Description = Convert.ToString(d["Description"]);

           // Set_Description(st_Description);
            //string st = Convert.ToString(d["PCNStatus"]);
           // MessageBox.Show(st_Description); 
            //return(st_Description);

            //********************5/4 *******************Uncommented below
            //if (stat == "Initiated")
            //{
            //    bttEditPCN.Enabled = true;
            //    tdbgBudgetPCN.Columns["Status"].DropDown.AllowDrop = false;
            //}
            //else
            //{
            //    bttEditPCN.Enabled = false;
            //}
                
            
  }
        //public void Set_Description(string s)

        //{ 
        //    st_Description = s;
            
        //}



/*
        //****************************************************************these were added for testing
        private void button5_Click_1(object sender, EventArgs e)
        {
            DataRow d_New = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            string st = Convert.ToString(d_New["PCNStatus"]);
            MessageBox.Show(st);

        }

        

        private void tdbgBudgetPCN_SelChange(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
           // MessageBox.Show("********************************");
        }

        private void tdbgBudgetPCN_Change(object sender, EventArgs e)
        {
            //MessageBox.Show("Please Hit Enter to Change PCN");
            
                    }
         * 
         * */


        private void tdbgBudgetPCN_Change(object sender, EventArgs e)
        {
            //MessageBox.Show("Please Hit Enter to Change PCN");


            DataRow d_MC = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            string st = Convert.ToString(d_MC["PCNStatus"]);
            if (st == "Approved")
            {
                bttEditPCN.Enabled = false;
               }

        }




        private void tdbgBudgetPCN_MouseClick(object sender, MouseEventArgs e)
        {
            DataRow d_MC = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            string st = Convert.ToString(d_MC["PCNStatus"]);
            //MessageBox.Show(st);


            //if (st == "Approved")
            //{
            //    bttEditPCN.Enabled = false;
            //tdbgBudgetPCN.EditRows = olumns["Description"].Text. = false;
            //    //MessageBox.Show("Can not Edit   " + st + " PCN"); //******************Commented on 5/6
            
            //}
            
            
             
                
                
                if (st == "Initiated")
            {
                bttEditPCN.Enabled = true;
                //tdbgBudgetPCN.Columns["Status"].DropDown.AllowDrop = false;
            }
            
            else
            {
                bttEditPCN.Enabled = false;
                //MessageBox.Show("Can not Edit   " + st +" PCN");
               
            }

        }

        private void tlbbSummary_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPBudget bud = new CPBudget();
            this.Cursor = Cursors.WaitCursor;
            bud.PreviewBudgetSummary(moCurrBudget.ID, cboWBS.Text);
            this.Cursor = Cursors.Default;
        }


        private void tlbbSummaryWORate_Click(object sender, C1.Win.C1Command.ClickEventArgs e) //*****************************Added 7/22/2015
        {
            CPBudget bud = new CPBudget();
            this.Cursor = Cursors.WaitCursor;
            bool rate = false;
            bud.PreviewBudgetSummary(moCurrBudget.ID, cboWBS.Text,rate);
            this.Cursor = Cursors.Default;

        }

        private void tlbbPreviewDetails_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPBudget bud = new CPBudget();
            this.Cursor = Cursors.WaitCursor;

           // MessageBox.Show(moCurrBudget.ID.ToString());
           // MessageBox.Show(moCurrBudget.ProjectID.ToString());
            //MessageBox.Show(moCurrBudget.Description);

            //worksheet.cboWBS_Text = cboWBS.Text; // *****************************Added 7/1/15
            //MessageBox.Show("#################################");
            //MessageBox.Show(cboWBS.Text);
            

            bud.PreviewBudgetDetails(moCurrBudget.ID, cboWBS.Text); 
            
            //MessageBox.Show(moCurrBudget.ID.ToString());

            this.Cursor = Cursors.Default;
        }

        private void TotalBudget(string group, bool retotalAll)
        {
            decimal hrsTot;
            decimal dlrsTot;
            decimal rateTot;
            decimal expTot;

            hrsTot = 0;
            dlrsTot = 0;
            rateTot = 0;
            expTot = 0;

            var fg = fgForGroup(group);
            var fgExp = fgExpForGroup(group);

            foreach (C1.Win.C1FlexGrid.Row r in fg.Rows)
            {
                if (r[BUDCOL8] != null && RevSol.RSMath.IsInteger(r[BUDCOL8]) == true)
                {
                    hrsTot += Convert.ToInt32(r[BUDCOL13]);
                    dlrsTot += Convert.ToDecimal(r[BUDCOL15]);
                }
            }

            foreach (C1.Win.C1FlexGrid.Row r in fgExp.Rows)
            {
                if (r[3].ToString() != "Description")
                {
                    expTot += Convert.ToDecimal(RevSol.RSMath.IsDecimalEx(r[8]));
                }
            }

            txtSumHrsForGroup(group).Text = hrsTot.ToString(DEFAULTINTEGER);
            txtSumDlrsForGroup(group).Text = dlrsTot.ToString(DEFAULTDOLLARS);
            txtSumExpForGroup(group).Text = expTot.ToString(DEFAULTDOLLARS);

            if (hrsTot != 0)
            {
                rateTot = dlrsTot / hrsTot;
            }

            txtSumRateForGroup(group).Text = rateTot.ToString(DEFAULTDOLLARS);

            if (retotalAll == true)
            {
                TotalAllBudget();
            }
        }

        private void TotalAllBudget()
        {
            decimal hrsTot;
            decimal dlrsTot;
            decimal rateTot;
            decimal expTot;

            hrsTot = 0;
            dlrsTot = 0;
            rateTot = 0;
            expTot = 0;

            foreach (var group in _Groups)
            {
                hrsTot += RevSol.RSMath.IsDecimalEx(txtSumHrsForGroup(group.Code).Text);
                dlrsTot += RevSol.RSMath.IsDecimalEx(txtSumDlrsForGroup(group.Code).Text);
                expTot += RevSol.RSMath.IsDecimalEx(txtSumExpForGroup(group.Code).Text);
            }

            txtTotalHrs.Text = hrsTot.ToString(DEFAULTINTEGER);
            txtTotalDlrs.Text = dlrsTot.ToString(DEFAULTDOLLARS);
            txtTotalExp.Text = expTot.ToString(DEFAULTDOLLARS);

            if (hrsTot != 0)
            {
                rateTot = dlrsTot / hrsTot;
            }

            txtTotalRate.Text = rateTot.ToString(DEFAULTDOLLARS);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            C1.Win.C1FlexGrid.C1FlexGrid fg;
            C1.Win.C1FlexGrid.Row rw;

            fg = (C1.Win.C1FlexGrid.C1FlexGrid)contextMenuStrip1.SourceControl;
            string tmp = fg.Name;
            if (fg.Row == -1) return;
            rw = fg.Rows[fg.Row];

            if (RevSol.RSMath.IsInteger(rw[7]) == false || rw[7] == null)
                            {
                cmnuAddRow.Enabled = false;
                deleteRowToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (IsLockedBudgetLine(rw[6].ToString()) == true)
                {
                    cmnuAddRow.Enabled = false;
                    deleteRowToolStripMenuItem.Enabled = false;
                }
                else
                    if (moCurrBudget.IsActive == true)
                    {
                        cmnuAddRow.Enabled = false;
                        deleteRowToolStripMenuItem.Enabled = false;
                    }
                else
                {
                    cmnuAddRow.Enabled = true;
                    deleteRowToolStripMenuItem.Enabled = true;
                }
            }
        }


        private void fg_BeforeEdit(string group, object sender, RowColEventArgs e)
        {
            var fg = fgForGroup(group);
            Row r = fg.Rows[e.Row];

            if (r[BUDCOL7] == null)
                return;

            if (RevSol.RSMath.IsIntegerEx(r[BUDCOL8]) == 2 && fg.Col != 13)
            {
                e.Cancel = true;
            }
            else
            {
                if (IsLockedBudgetLine(r[BUDCOL7].ToString()) == true && fg.Col != 13)
                    e.Cancel = true;
            }
        }


        private void makeActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

            msg = "This will make " + li.Description + " the active project\nThis will also enter the information into the JobStat\nDo you wish to continue?";

            if (MessageBox.Show(msg, "Make Project Active", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CBBudget.MakeBudgetActive(li.ID);

                SetActiveInList();

                tlbbMakeActive.Enabled = false;
                makeActiveToolStripMenuItem.Enabled = false;

                MakeProjectActiveInJobStat(li.ID);
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBudgetInfo bi = new FBudgetInfo();

            bi.OnBudgetPropertiesChanged += new RevSol.PassMultiDataStrings(bi_OnBudgetPropertiesChanged);
            bi.SetBudget(moCurrBudget.ID);
            bi.ShowDialog();
            bi.OnBudgetPropertiesChanged -= new RevSol.PassMultiDataStrings(bi_OnBudgetPropertiesChanged);
        }

        void bi_OnBudgetPropertiesChanged(string[] vals, int count)
        {
            if (count == 2)
            {
                string description;
                decimal contingency;

                description = vals[0];
                contingency = Convert.ToDecimal(vals[1]);

                ((RevSol.RSListItem)lstBudgets.SelectedItem).Meta1 = description;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to remove " + moCurrBudget.GetNumber(), "Remove Budget", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CBBudget.Delete(moCurrBudget.ID);

                LoadPreviousBudget(moCurrBudget.ProjectID);
            }
        }

        private void makeDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;

            msg = "Are you sure you wish to make " + moCurrBudget.GetNumber() + " the default budget";
            msg += "\nThis will remove the remaining budgets from the current view";

            if (MessageBox.Show(msg, "Make Default", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CBBudget.MakeBudgetDefault(moCurrBudget.ID);

                LoadPreviousBudget(moCurrBudget.ProjectID);
            }
        }

        private void lstBudgets_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePositionInClientCoord = new Point(e.X, e.Y);
            int indexUnderTheMouse = lstBudgets.IndexFromPoint(mousePositionInClientCoord);

            if (indexUnderTheMouse > -1)
            {
                string number = ((RevSol.RSListItem)lstBudgets.Items[indexUnderTheMouse]).Description;
                string desc = ((RevSol.RSListItem)lstBudgets.Items[indexUnderTheMouse]).Meta1;
                string toolString = number + " - " + desc;

                this.toolTip1.SetToolTip(this.lstBudgets, toolString);
            }
        }

        private void tlbbJobStat_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPBudget bud = new CPBudget();

            this.Cursor = Cursors.WaitCursor;

            bud.PreviewJobStat(moCurrBudget.ID, cboWBS.Text);

            this.Cursor = Cursors.Default;
        }

        private void tlbbMakeDefault_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            string msg;

            msg = "Are you sure you wish to make " + moCurrBudget.GetNumber() + " the default budget";
            msg += "\nThis will remove the remaining budgets from the current view";

            if (MessageBox.Show(msg, "Make Default", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CBBudget.MakeBudgetDefault(moCurrBudget.ID);

                LoadPreviousBudget(moCurrBudget.ProjectID);
            }
        }

        private bool IsLockedExpense(string val)
        {
            bool retVal;

            switch (val)
            {
                case "E110":
                    retVal = true;
                    break;
                case "E120":
                    retVal = true;
                    break;
                case "E130":
                    retVal = true;
                    break;
                case "E140":
                    retVal = true;
                    break;
                case "E150":
                    retVal = true;
                    break;
                case "E160":
                    retVal = true;
                    break;
                case "E170":
                    retVal = true;
                    break;
                case "E180":
                    retVal = true;
                    break;
                case "E190":
                    retVal = true;
                    break;
                case "E281":
                    retVal = true;
                    break;
                case "E282":
                    retVal = true;
                    break;
                case "E283":
                    retVal = true;
                    break;
                case "E284":
                    retVal = true;
                    break;
                case "E290":
                    retVal = true;
                    break;
                case "E310":
                    retVal = true;
                    break;
                case "E320":
                    retVal = true;
                    break;
                case "E330":
                    retVal = true;
                    break;
                case "E340":
                    retVal = true;
                    break;
                case "E350":
                    retVal = true;
                    break;
                case "E541":
                    retVal = true;
                    break;
                case "E542":
                    retVal = true;
                    break;
                case "E543":
                    retVal = true;
                    break;
                case "E561":
                    retVal = true;
                    break;
                case "E562":
                    retVal = true;
                    break;
                case "E580":
                    retVal = true;
                    break;
                case "E591":
                    retVal = true;
                    break;
                case "E592":
                    retVal = true;
                    break;
                case "E593":
                    retVal = true;
                    break;
                case "E594":
                    retVal = true;
                    break;
                case "E595":
                    retVal = true;
                    break;



                default:
                    retVal = false;
                    break;
            }

            return retVal;
        }

        private void fgExp_BeforeEdit(string group, object sender, RowColEventArgs e)
        {
            var fgExp = fgExpForGroup(group);
            if (IsLockedExpense(fgExp[e.Row, 1].ToString()) == true && e.Col == 6)
            { e.Cancel = true; }
        }


        private void fgExp_OwnerDrawCell(string group, object sender, OwnerDrawCellEventArgs e)
        {
            var fgExp = fgExpForGroup(group);
            if (IsLockedExpense(fgExp[e.Row, 1].ToString()) == true && e.Col == 6)
            { e.Style = fgExp.Styles["CustomStyle1"]; }
        }


        private bool IsLockedBudgetLine(string val)
        {
            bool retVal;
            string codeVal;
            if (val == "" || val == null) return false;

            codeVal = val.Substring(1);

            switch (codeVal)
            {
                case "211":
                    retVal = true;
                    break;
                case "212":
                    retVal = true;
                    break;
                case "213":
                    retVal = true;
                    break;
                case "214":
                    retVal = true;
                    break;
                case "215":
                    retVal = true;
                    break;
                case "221":
                    retVal = true;
                    break;
                case "222":
                    retVal = true;
                    break;
                case "223":
                    retVal = true;
                    break;
                case "224":
                    retVal = true;
                    break;
                case "225":
                    retVal = true;
                    break;
                case "226":
                    retVal = true;
                    break;
                case "227":
                    retVal = true;
                    break;
                case "229":
                    retVal = true;
                    break;
                default:
                    retVal = false;
                    break;
            }

            return retVal;
        }

        private void tlbbBudgetEntry_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPBudget bud = new CPBudget();

            this.Cursor = Cursors.WaitCursor;

            bud.PreviewBudgetFormEntry(moCurrBudget.ID, cboWBS.Text);

            this.Cursor = Cursors.Default;
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockToolStripMenuItem.Text == "Lock")
            {
                CBBudget.MakeBudgetLockedUnlocked(moCurrBudget.ID, true);
                moCurrBudget.IsLocked = true;
                LockTheCurrentBudget();
                SetLockStatusInList();
            }
            else
            {
                CBBudget.MakeBudgetLockedUnlocked(moCurrBudget.ID, false);
                moCurrBudget.IsLocked = false;
                UnLockTheCurrentBudget();
                SetLockStatusInList();
            }
        }

        private void cmnuBudget_Opening(object sender, CancelEventArgs e)
        {
            if (moCurrBudget.IsActive == true)
            {
                lockToolStripMenuItem.Enabled = false;
            }
            else
            {
                lockToolStripMenuItem.Enabled = true;

                if (moCurrBudget.IsLocked == true)
                {
                    lockToolStripMenuItem.Text = "Unlock";
                }
                else
                {
                    lockToolStripMenuItem.Text = "Lock";
                }
            }
        }

        private void LockTheCurrentBudget()
        {
            foreach (var group in _Groups)
            {
                fgForGroup(group.Code).AllowEditing = false;
                fgExpForGroup(group.Code).AllowEditing = false;
            }
        }

        private void UnLockTheCurrentBudget()
        {
            foreach (var group in _Groups)
            {
                fgForGroup(group.Code).AllowEditing = true;
                fgExpForGroup(group.Code).AllowEditing = true;
            }
        }

        private void MakeProjectActiveInJobStat(int budgetID)
        {
            this.Cursor = Cursors.WaitCursor;

            CBBudget.CreateBudgetInJobStat(budgetID);

            this.Cursor = Cursors.Default;
        }

        private void button5_Click (object sender, EventArgs e)
        {

            moCurrBudget.Clarification11000 = richTextBox1.Text;
            moCurrBudget.Clarification12000 = richTextBox2.Text;
            moCurrBudget.Clarification13000 = richTextBox3.Text;
            moCurrBudget.Clarification14000 = richTextBox4.Text;
            moCurrBudget.Clarification15000 = richTextBox5.Text;
            moCurrBudget.Clarification16000 = richTextBox6.Text;
            moCurrBudget.Clarification18000 = richTextBox7.Text;
            moCurrBudget.Clarification50000 = richTextBox8.Text;
            moCurrBudget.Save();
        }

        private string GetProcurementDescription(int code, string descrip)
        {
            string codeDesc;
            string newDesc;

            codeDesc = CBBudgetLine.GetDescriptionByCode(code);

            if (codeDesc.Length > 0)
            {
                //newDesc = code.ToString() + " " + codeDesc + " - " + descrip;
                newDesc = codeDesc + " - " + descrip;
            }
            else
            {
                newDesc = descrip;
            }

            return newDesc;
        }

        private void tlbbBudgetExport_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CBudgetExport be = new CBudgetExport();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                be.ExportBudgetForPrimavera(saveFileDialog1.FileName, moCurrBudget.ID);
            }
        }

        private void LoadUOMExp()
        {
            SqlDataReader dr;
            RevSol.RSListItem li;
            string comboLst;

            dr = CBUnitOfMeasure.GetList();

            lstExpUOMs.Items.Clear();
            comboLst = "";

            while (dr.Read())
            {
                li = new RevSol.RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Code"].ToString();
                comboLst += li.Description + "|";

                lstExpUOMs.Items.Add(li);
            }

            dr.Close();

            if (comboLst.Length > 0)
            {
                comboLst = comboLst.Substring(0, comboLst.Length - 1);
            }

            foreach (var group in _Groups)
            { fgExpForGroup(group.Code).Cols[4].ComboList = comboLst; }

            // MessageBox.Show("LoadUOMExp...."); //*********************2 

        }

        private void newBlankBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt;
            RevSol.RSListItem li = (RevSol.RSListItem)lstBudgets.SelectedItem;

            DialogResult ret = MessageBox.Show("Make a new blank revision?", "New Revision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ret == DialogResult.Yes)
            {
                RevSol.RSListItem l2 = new RevSol.RSListItem();
                CBBudget bud = new CBBudget();
                CBBudget budNew = new CBBudget();

                bud.Load(li.ID);
                budNew.ProjectID = bud.ProjectID;
                budNew.Revision = CBBudget.GetNextRevision(bud.ProjectID);
                budNew.PCNID = bud.PCNID;
                budNew.IsActive = false;
                budNew.Save();

                cnt = lstBudgets.Items.Count + 1;

                l2.ID = budNew.ID;
                l2.Description = budNew.GetNumber();
                l2.Meta = budNew.IsActive.ToString();

                int indx = lstBudgets.Items.Add(l2);

                //CopyBudget(li.ID, l2.ID);
                CopyAsNewBlankBudget(budNew.ID);

                //tlbbNewRev.Enabled = false;
                tlbbSaveRev.Enabled = true;

                lstBudgets.SelectedIndex = indx;
            }
        }

        private void CopyAsNewBlankBudget(int newBudID)
        {
            moCurrBudget = new CBBudget();
            moCurrBudget.Clear();
            moCurrBudget.Load(newBudID);

            foreach (var group in _Groups)
            {
                mbLoaded[group.Code] = false;
                LoadBudget(group.Code);
            }



            mdsPCNs = new dsBudgetPCN();
            tdbgBudgetPCN.SetDataBinding(mdsPCNs, "PCNs", true);

            tlbbMakeActive.Enabled = false;
            tlbbSaveRev.Enabled = true;
            makeActiveToolStripMenuItem.Enabled = false;
        }

        private void tlbbPrintAll_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPBudget prnt = new CPBudget();

            this.Cursor = Cursors.WaitCursor;
            //string projNumber = moCurrBudget.pr
            //prnt.PreviewAllBudget(moCurrBudget.ID, cboWBS.Text);
            prnt.PreviewAllBudget_New(moCurrBudget.ID, msProject, cboWBS.Text);

            this.Cursor = Cursors.Default;
            c1ToolBar1.Cursor = Cursors.Default;
        }

        private void tdbgBudgetPCN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tdbgBudgetPCN.UpdateData();
            }
        }



        private void cboWBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wbs = cboWBS.Text;

            this.Cursor = Cursors.WaitCursor;

            LoadBudgetLinesForWBS(wbs);

            this.Cursor = Cursors.Default;

            if (wbs.Length > 0)
                tlbbWorksheet.Enabled = false;
            else
                tlbbWorksheet.Enabled = true;

            this.Text = BUDGETTITLE + "  Budget: " + moCurrBudget.GetNumber() + "  WBS: " + wbs;
        }

        private void LoadBudgetWithWBSCode(string code)
        {
            foreach (var group in _Groups) { mdsWS[group.Code] = new dsWorkSheet(); }

            int curr = ((RevSol.RSListItem)lstBudgets.SelectedItem).ID;

            if (curr > 0)
            {
                LoadBudgetLinesForWBS(code);
                LoadBudgetWorksheetsForWBS(code);
                LoadExpenseLinesForWBS(code);
                LoadExpenseWorksheetsForWBS(code);

                foreach (var group in _Groups) { TotalBudget( group.Code, false); }
                TotalAllBudget();
            }
            else
            {
                tlbbNewRev.Enabled = false;
                tlbbSaveRev.Enabled = true;
            }

        }

        private void LoadBudgetLinesForWBS(string wbsCode)
        {
            foreach (var group in _Groups) { LoadGroupWithBudget(group.Code, wbsCode); }
            foreach (var group in _Groups) { TotalBudget(group.Code, true); }
        }

        private void LoadBudgetWorksheetsForWBS(string wbsCode)
        { foreach (var group in _Groups) { LoadWorksheet(group.Code); } }


        private void LoadExpenseLinesForWBS(string wbsCode)
        { foreach (var group in _Groups) { LoadExpenseWithBudget(group.Code); } }


        private void LoadExpenseWorksheetsForWBS(string wbsCode)
        { foreach (var group in _Groups) { LoadExpenseWithBudget(group.Code); } }


        private void LoadWBSCodesForFilter()
        {
            SqlDataReader dr;

            dr = CBBudgetLine.GetWBSListByBudget(moCurrBudget.ID);

            cboWBS.Items.Clear();

            cboWBS.Items.Add("");

            while (dr.Read())
            {
                if (dr["WBS"].ToString().Length > 0)
                {
                    cboWBS.Items.Add(dr["WBS"].ToString());
                }
            }

            dr.Close();
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


        private void fg_MouseDown(string group, object sender, MouseEventArgs e)
        {
            var fg = fgForGroup(group);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                fg.Select(fg.MouseRow, 0, fg.MouseRow, fg.Cols.Count - 1);
            }
        }

        private void tlbbSelectCodes_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            var code_selector = new CodeGroupSelector(this.miProjectID);
            code_selector.ShowDialog();
            this.ReloadForm = true;
            this.Close();
        }

        private void bttSaveClarification_Click(object sender, EventArgs e) //***************************Added 5/21
        {
            moCurrBudget.Clarification11000 = richTextBox1.Text;
            moCurrBudget.Clarification12000 = richTextBox2.Text;
            moCurrBudget.Clarification13000 = richTextBox3.Text;
            moCurrBudget.Clarification14000 = richTextBox4.Text;
            moCurrBudget.Clarification15000 = richTextBox5.Text;
            moCurrBudget.Clarification16000 = richTextBox6.Text;
            moCurrBudget.Clarification18000 = richTextBox7.Text;
            moCurrBudget.Clarification50000 = richTextBox8.Text;
            moCurrBudget.Save();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FBudgetPCNAddition pcn = new FBudgetPCNAddition();
            
            pcn.ViewForm();
            
            DataRow d = mdsPCNs.Tables["PCNs"].Rows[tdbgBudgetPCN.Bookmark];
            int currID = Convert.ToInt32(d["ID"]);
            //    string stat = tdbgBudgetPCN.Columns["Status"].Value.ToString();
            //Console.WriteLine("The Status is: " + stat);
            // if (stat == "Approved" || stat == "Pending" || stat == "Disapprove" || stat == "Prepare Control Estimate" || stat != "Initiated") { bttEditPCN.Enabled = false; }
            //else {             
            pcn.OnPCNChanged += new RevSol.ItemValueChangedHandler(PCNChanged);
            pcn.EditPreviousPCN(currID);
            pcn.ShowDialog();
            pcn.OnPCNChanged -= new RevSol.ItemValueChangedHandler(PCNChanged);
        }

       

     
       

        
        

       



     
    }
}
