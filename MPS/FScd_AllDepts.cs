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
    public partial class FScd_AllDepts : Form
    {
        private const int WEEKCOLSTART = 6;
        private const string PLANCOLTITLE = "P";
        private const string FORECOLTITLE = "F";
        private const string ACTLCOLTITLE = "A";

        private const string CELLSTYLEUNDER = "CellStyleUnder";
        private const string CELLSTYLEOVER = "CellStyleOver";
        private const string CELLSTYLEMAX = "CellStyleMax";

        private const int PROJECTCOLUMN = 1;
        private const int DEPARTMENTCOLUMN = 2;
        private const int EMPLOYEECOLUMN = 3;
        private const int PLANTOTCOLUMN = 4;
        private const int FORTOTCOLUMN = 5;

        //private string HOURDISPLAYFORMAT = "#,##0";

        private Color WARNINGCOLORBELOW = Color.LightGreen;
        private Color WARNINGCOLORHIGH = Color.Yellow;
        private Color WARNINGCOLORMAX = Color.LightSalmon;

        public FScd_AllDepts()
        {
            InitializeComponent();

            ClearForm();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            lblProjNumber.Text = "";
            lblDescription.Text = "";
            lblCustLoc.Text = "";
            lblDateRange.Text = "";

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
        }
    }
}