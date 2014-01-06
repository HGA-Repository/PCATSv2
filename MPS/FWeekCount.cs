using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RSLib;

namespace RSMPS
{
    public partial class FWeekCount : Form
    {
        public event RSLib.ItemReturnAction OnWeekCount;

        public FWeekCount()
        {
            InitializeComponent();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (OnWeekCount != null)
                OnWeekCount(Convert.ToInt32(numWeeks.Value),"");

            this.Close();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FWeekCount_Load(object sender, EventArgs e)
        {
            numWeeks.Select(0, 1);
        }
    }
}