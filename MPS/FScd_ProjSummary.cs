using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FScd_ProjSummary : Form
    {
        private const string DISPFORMAT = "#,##0.00";
        public FScd_ProjSummary()
        {
            InitializeComponent();
        }


        public event EventHandler OnSummaryClose;
        private int miProjID;

        public int ProjectID
        {
            get { return miProjID; }
        }


        public void SetProject(int deptID, int projID, int weekID, decimal totPlan, decimal totFor, decimal totAct)
        {
            CBProject p = new CBProject();
            CBWeekList w = new CBWeekList();
            CBCustomer c = new CBCustomer();
            CBProjectBudget pb = new CBProjectBudget();
            CBDepartment d = new CBDepartment();
            
            p.Load(projID);
            miProjID = projID;

            w.Load(weekID);
            c.Load(p.CustomerID);

            pb.Load(deptID, projID);
            d.Load(deptID);
            
            txtNumber.Text = p.Number;
            txtWeek.Text = w.StartOfWeek.ToShortDateString();
            txtStartDate.Text = p.DateStart.ToShortDateString();
            txtEndDate.Text = p.DateEnd.ToShortDateString();
            txtDescription.Text = p.Description;
            txtCustomer.Text = c.Name;
            if (d.Name.Length > 5)
                lblBudget.Text = d.Name.Substring(0,5) + " Bugt.:";
            else
                lblBudget.Text = d.Name + " Bugt.:";
            txtTotBudget.Text = pb.BudgetHrs.ToString(DISPFORMAT);
            txtTotPlanned.Text = totPlan.ToString(DISPFORMAT);
            txtTotForecast.Text = totFor.ToString(DISPFORMAT);
            txtTotActual.Text = totAct.ToString(DISPFORMAT);
            txtRemaining.Text = ((decimal)(totFor + totAct)).ToString(DISPFORMAT);
        }

        public void UpdatePlanned(decimal val)
        {
            decimal tmp;

            tmp = Convert.ToDecimal(txtTotPlanned.Text);
            tmp += val;

            txtTotPlanned.Text = tmp.ToString(DISPFORMAT);
        }

        public void UpdateForecast(decimal val)
        {
            decimal tmp;

            tmp = Convert.ToDecimal(txtTotForecast.Text);
            tmp += val;

            txtTotForecast.Text = tmp.ToString(DISPFORMAT);
        }

        public void UpdateActual(decimal val)
        {
            decimal tmp;

            tmp = Convert.ToDecimal(txtTotActual.Text);
            tmp += val;

            txtTotActual.Text = tmp.ToString(DISPFORMAT);
        }

        private void chkGhost_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGhost.Checked == true)
                this.Opacity = .50;
            else
                this.Opacity = 1.00;
        }

        private void FScd_ProjSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnSummaryClose != null)
                OnSummaryClose(this, null);
        }

        private void txtEndDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtTotPlanned_TextChanged(object sender, EventArgs e)
        {

        }
    }
}