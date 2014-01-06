using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtForecastRemaining.
    /// </summary>
    public partial class rprtForecastRemaining : DataDynamics.ActiveReports.ActiveReport3
    {

        public rprtForecastRemaining()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            int totalVal = 0;

            totalVal += Convert.ToInt32(textBox4.Value);
            totalVal += Convert.ToInt32(textBox5.Value);
            totalVal += Convert.ToInt32(textBox6.Value);
            totalVal += Convert.ToInt32(textBox7.Value);
            totalVal += Convert.ToInt32(textBox8.Value);
            totalVal += Convert.ToInt32(textBox9.Value);

            textBox10.Value = totalVal;
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            DateTime tmpDate = DateTime.Now;
            DateTime dataDate;
            int weekDay;

            weekDay = (-1) * (int)tmpDate.DayOfWeek;
            dataDate = tmpDate.AddDays(weekDay);

            lblDataDate.Text = "Data date: " + dataDate.ToShortDateString();
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            int totalValAll = 0;

            totalValAll = Convert.ToInt32(textBox12.Value) + Convert.ToInt32(textBox13.Value) + Convert.ToInt32(textBox14.Value) + Convert.ToInt32(textBox15.Value) + Convert.ToInt32(textBox16.Value) + Convert.ToInt32(textBox17.Value);
            textBox18.Value = totalValAll;
        }
    }
}
