using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public delegate void WorksheetChangedHandler(DataSet dsWS);

    public partial class FWS : Form
    {
        public event WorksheetChangedHandler OnWorkSheetChanged;

        public void SetDataValues(dsWorkSheet ds, int budgetID)
        {
            mdsWSData = (dsWorkSheet)ds.Copy();
            miBudgetID = budgetID;

            CBBudget b = new CBBudget();
            b.Load(budgetID);

            if (b.IsLocked == true)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                bttOK.Visible = false;
            }
        }

        private dsWorkSheet mdsWSData;
        private int miBudgetID;

        public FWS()
        {
            InitializeComponent();
        }

        CBActivityCodeDisc _Group;
        public FWS(CBActivityCodeDisc group, bool show_specification = true)
        {
            _Group = group;
            InitializeComponent();
            this.Text = "FWS" + group.Code;
            groupBox1.Text = _Group.Code + " Specifications and Procurement";
            if (!show_specification)
            {
                groupBox1.Visible = false;
                this.Height = this.Height - groupBox1.Height;
            }
         //   this.WindowState = FormWindowState.Maximized;            
        }

        private void Init()
        {
            mdsWSData = new dsWorkSheet();
        }

        private void FWS_Load(object sender, EventArgs e)
        {
            tdbgWS.SetDataBinding(mdsWSData, "WorkSheet", true);
            tdbgExpense.SetDataBinding(mdsWSData, "Expenses", true);

            SetHeaderCaptionAndFormat();

            bttOK.Enabled = false;
        }


        private void SetHeaderCaptionAndFormat()
        {
            tdbgWS.Splits[0].ColumnCaptionHeight = 70;
            tdbgWS.Splits[1].ColumnCaptionHeight = 70;
            tdbgWS.Splits[2].ColumnCaptionHeight = 70;
            tdbgWS.Columns[4].Caption = "211\n\nEqp Spec / Data Sheets";
            tdbgWS.Columns[5].Caption = "212\n\nConstr Spec";
            tdbgWS.Columns[6].Caption = "213\n\nMatl Spec";
            tdbgWS.Columns[7].Caption = "214\n\nConstr Scope / Bid Pkgs";
            tdbgWS.Columns[8].Caption = "215\n\nFabr Spec / Bid Pkgs";
            tdbgWS.Columns[9].Caption = "221\n\nInquiries";
            tdbgWS.Columns[10].Caption = "222\n\nPre-bid Meetings";
            tdbgWS.Columns[11].Caption = "223\n\nBid Evaluations";
            tdbgWS.Columns[12].Caption = "224\n\nPre-award Meetings";
            tdbgWS.Columns[13].Caption = "225\n\nBills of Material";
            tdbgWS.Columns[14].Caption = "226\n\nPurchase Reqs";
            tdbgWS.Columns[15].Caption = "227\nVend Drwg Revws, Consult, Coordn, Mtgs";
            tdbgWS.Columns[16].Caption = "229\n\nShop Inspection";

            tdbgExpense.Splits[0].ColumnCaptionHeight = 50;
            tdbgExpense.Splits[1].ColumnCaptionHeight = 50;
            tdbgExpense.Columns[3].Caption = "Trip\nQty\nEach";
            tdbgExpense.Columns[4].Caption = "Round\nTrip\nMiles";
            tdbgExpense.Columns[5].Caption = "Number\nof\nPeople";
            tdbgExpense.Columns[6].Caption = "No\nDays";
            tdbgExpense.Columns[7].Caption = "No\nNights";
            tdbgExpense.Columns[8].Caption = "Hrs\nPer\nDay";
            tdbgExpense.Columns[9].Caption = "E110 Travel Fares";
            tdbgExpense.Columns[11].Caption = "E120 Auto Rentals";
            tdbgExpense.Columns[12].Caption = "E130 Tolls / Parking";
            tdbgExpense.Columns[13].Caption = "E140 Fuel";
            tdbgExpense.Columns[14].Caption = "E150 Mileage";
            tdbgExpense.Columns[15].Caption = "E160 Meals";
            tdbgExpense.Columns[16].Caption = "E170 Lodging";
            tdbgExpense.Columns[18].Caption = "E180 Per diem";
            tdbgExpense.Columns[19].Caption = "E190 Misc Exp";
            tdbgExpense.Columns[20].Caption = "E281 1-Man Crew";
            tdbgExpense.Columns[21].Caption = "E282 2-Man Crew";
            tdbgExpense.Columns[22].Caption = "E283 3-Man Crew";
            tdbgExpense.Columns[23].Caption = "E284 4-Man Crew";
            tdbgExpense.Columns[24].Caption = "E290 Survey Supplies";
            tdbgExpense.Columns[25].Caption = "E310 Eng. Services";
            tdbgExpense.Columns[26].Caption = "E320 Surveying";
            tdbgExpense.Columns[27].Caption = "E330 GeoTech Inv";
            tdbgExpense.Columns[28].Caption = "E340 Environmental";
            tdbgExpense.Columns[29].Caption = "E350 Spec Sub";
            tdbgExpense.Columns[30].Caption = "E541 ATV";
            tdbgExpense.Columns[31].Caption = "E542 ORUV";
            tdbgExpense.Columns[32].Caption = "E543 Boat";
            tdbgExpense.Columns[33].Caption = "E561 Digital Cam";
            tdbgExpense.Columns[34].Caption = "E562 Cell Phone";
            tdbgExpense.Columns[35].Caption = "E580 Field Comp";
            tdbgExpense.Columns[36].Caption = "E591 Trimble R8 GPS";
            tdbgExpense.Columns[37].Caption = "E592 Trimble GEO";
            tdbgExpense.Columns[38].Caption = "E593 Total Station";
            tdbgExpense.Columns[39].Caption = "E594 Laser Range";
            tdbgExpense.Columns[40].Caption = "E595 Pipe Locator";

        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            //   make sure that each row has a work guid
            foreach (DataRow dr in mdsWSData.Tables["Worksheet"].Rows)
            {
                if (dr["WorkGuid"].ToString().Length < 1)
                    dr["WorkGuid"] = Guid.NewGuid().ToString();
            }

            foreach (DataRow dr in mdsWSData.Tables["Expenses"].Rows)
            {
                if (dr["WorkGuid"].ToString().Length < 1)
                    dr["WorkGuid"] = Guid.NewGuid().ToString();
            }

            SaveWorksheetValues();      // update the database with values

            if (OnWorkSheetChanged != null)
                OnWorkSheetChanged(mdsWSData.Copy());
         //   MessageBox.Show("Worksheet updated");
            this.Close();
        }



        private void deleteLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tdbgWS.Row > 0)
            {
                DialogResult retVal = MessageBox.Show("Are you sure that you wish to delete " + tdbgWS.Columns[2].Text, "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (retVal == DialogResult.Yes)
                {
                    DataRow dr = mdsWSData.Worksheet.Rows[tdbgWS.Bookmark];
                    DataRow dd = mdsWSData.WorksheetDeleted.NewRow();
                    dd["ID"] = dr["ID"];

                    mdsWSData.WorksheetDeleted.Rows.Add(dd);
                    tdbgWS.Delete(tdbgWS.Row);

                    bttOK.Enabled = true;
                }
            }
        }

        private void SaveWorksheetValues()
        {
            CBBudgetWorksheet ws;
            CBBudgetExpenseSheet es;

            foreach (DataRow dr in mdsWSData.Tables["Worksheet"].Rows)
            {
                ws = new CBBudgetWorksheet();

                ws.ID = Convert.ToInt32(dr["ID"]);
                ws.BudgetID = miBudgetID;
                ws.WorkGuid = dr["WorkGuid"].ToString();
                ws.ItemDescription = dr["ItemDescription"].ToString();
                ws.WBS = dr["WBS"].ToString();
                ws.DeptGroup = Int32.Parse(_Group.Code);
                ws.Quantity = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["QtyEach"]));
                ws.Spec211 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Spec211"]));
                ws.Spec212 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Spec212"]));
                ws.Spec213 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Spec213"]));
                ws.Spec214 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Spec214"]));
                ws.Spec215 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Spec215"]));
                ws.Proc221 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc221"]));
                ws.Proc222 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc222"]));
                ws.Proc223 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc223"]));
                ws.Proc224 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc224"]));
                ws.Proc225 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc225"]));
                ws.Proc226 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc226"]));
                ws.Proc227 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc227"]));
                ws.Proc229 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["Proc229"]));

                ws.Save();

                dr["ID"] = ws.ID;
            }

            foreach (DataRow dr in mdsWSData.Tables["WorksheetDeleted"].Rows)
            {
                CBBudgetWorksheet.Delete(Convert.ToInt32(dr["ID"]));
            }

            foreach (DataRow dr in mdsWSData.Tables["Expenses"].Rows)
            {
                es = new CBBudgetExpenseSheet();

                es.ID = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["ID"]));
                es.BudgetID = miBudgetID;
                es.WorkGuid = dr["WorkGuid"].ToString();
                es.DeptGroup = Int32.Parse(_Group.Code);
                es.Description = dr["Description"].ToString();
                es.Quantity = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["TripQty"]));
                es.RoundTrips = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["RoundTripMiles"]));
                es.People = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["NumberOfPeople"]));
                es.NumDays = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["NumDays"]));
                es.NumNights = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["NumNights"]));
                es.HoursPerDay = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["HrsPerDay"]));

                //es.TravelHours = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["TotalHours"]));
                es.E110 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E110"]));
                es.E120 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E120"]));
                es.E130 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E130"]));
                es.E140 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E140"]));
                es.E150 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E150"]));
                es.E160 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E160"]));
                es.E170 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E170"]));
                es.E180 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E180"]));
                es.E190 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E190"]));
                es.E281 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E281"]));
                es.E282 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E282"]));
                es.E283 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E283"]));
                es.E284 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E284"]));
                es.E290 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E290"]));
                es.E310 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E310"]));
                es.E320 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E320"]));
                es.E330 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E330"]));
                es.E340 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E340"]));
                es.E350 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E350"]));
                es.E541 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E541"]));
                es.E542 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E542"]));
                es.E543 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E543"]));
                es.E561 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E561"]));
                es.E562 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E562"]));
                es.E580 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E580"]));
                es.E591 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E591"]));
                es.E592 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E592"]));
                es.E593 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E593"]));
                es.E594 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E594"]));
                es.E595 = Convert.ToInt32(RevSol.RSMath.IsIntegerEx(dr["E595"]));

                es.Save();

                dr["ID"] = es.ID;
            }

            foreach (DataRow dr in mdsWSData.Tables["ExpensesDeleted"].Rows)
            {
                CBBudgetExpenseSheet.Delete(Convert.ToInt32(dr["ID"]));
            }
        }

        private void deleteLineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tdbgExpense.Row > 0)
            {
                DialogResult retVal = MessageBox.Show("Are you sure that you wish to delete " + tdbgExpense.Columns[2].Text, "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (retVal == DialogResult.Yes)
                {
                    DataRow dr = mdsWSData.Expenses.Rows[tdbgExpense.Bookmark];
                    DataRow dd = mdsWSData.ExpensesDeleted.NewRow();
                    dd["ID"] = dr["ID"];

                    mdsWSData.ExpensesDeleted.Rows.Add(dd);

                    tdbgExpense.Delete(tdbgExpense.Row);
                }


                bttOK.Enabled = true;
            }
        }


        private void tdbgWS_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        { bttOK.Enabled = true; }


        private void tdbgExpense_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            //SSS 20131218 - Removing this code so that the grid does not auto edit or auto populate
            //decimal totalMiles, totalHours, hotel, carRental, meals, travelExp, airFare, perdiem;
            //decimal qty, miles, people, days, nights, hrsPerDay;

            //if (e.ColIndex < 9 && e.ColIndex != 2)
            //{
            //    Decimal.TryParse(tdbgExpense.Columns[3].Value.ToString(), out qty);
            //    Decimal.TryParse(tdbgExpense.Columns[4].Value.ToString(), out miles);
            //    Decimal.TryParse(tdbgExpense.Columns[5].Value.ToString(), out people);
            //    Decimal.TryParse(tdbgExpense.Columns[6].Value.ToString(), out days);
            //    Decimal.TryParse(tdbgExpense.Columns[7].Value.ToString(), out nights);
            //    Decimal.TryParse(tdbgExpense.Columns[8].Value.ToString(), out hrsPerDay);

            //    if (people == 0) people = 1;
            //    if (days == 0) days = 1;

            //    totalMiles = qty * miles;

            //    if (hrsPerDay == 0)
            //        totalHours = qty * people * days * 8.0m;
            //    else
            //        totalHours = qty * people * days * hrsPerDay;

            //    carRental = qty * days;
            //    hotel = qty * people * nights;
            //    meals = (days * 2 + nights * 1) * people * qty;
            //    travelExp = qty * people;
            //    airFare = qty * people;
            //    perdiem = qty * days;

            //    tdbgExpense.Columns[9].Value = airFare;
            //    tdbgExpense.Columns[11].Value = carRental;
            //    tdbgExpense.Columns[14].Value = totalMiles;
            //    tdbgExpense.Columns[15].Value = meals;
            //    tdbgExpense.Columns[16].Value = hotel;
            //    tdbgExpense.Columns[18].Value = perdiem;
            //}

            bttOK.Enabled = true;
        }

        private void tdbgExpense_Click(object sender, EventArgs e)
        {

        }

       

    }
}