using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FBudgetInfo : Form
    {
        public event RevSol.PassMultiDataStrings OnBudgetPropertiesChanged;

        private int miBudgetID;

        public void SetBudget(int budgetID)
        {
            CBBudget bud = new CBBudget();

            bud.Load(budgetID);

            miBudgetID = budgetID;
            txtBudget.Text = bud.GetNumber();
            txtDescription.Text = bud.Description;
            txtPreparedBy.Text = bud.PreparedBy;
            txtContingency.Text = bud.Contingency.ToString("#,##0.00");

        }

        public FBudgetInfo()
        {
            InitializeComponent();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            CBBudget bud = new CBBudget();

            bud.Load(miBudgetID);
            bud.Description = txtDescription.Text;
            bud.PreparedBy = txtPreparedBy.Text;
            bud.Contingency = Convert.ToDecimal(txtContingency.Text);
            bud.Save();

            if (OnBudgetPropertiesChanged != null)
            {
                string[] vals = new string[2];

                vals[0] = txtDescription.Text;
                vals[1] = txtContingency.Text;

                OnBudgetPropertiesChanged(vals, 2);
            }

            this.Close();
        }

        private void FBudgetInfo_Load(object sender, EventArgs e)
        {

        }
    }
}