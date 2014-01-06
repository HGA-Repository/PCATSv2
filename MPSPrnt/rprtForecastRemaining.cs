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
    public partial class rprtForecastRemaining : DataDynamics.ActiveReports.ActiveReport
    {

        public rprtForecastRemaining()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            PageSettings.Orientation = PageOrientation.Landscape;
            float m = (float)(0.25);
            PageSettings.Margins = new Margins(m, m, m, m);
        }

        public void SetAsPipeline()
        {
            label12.Text = "Pipeline Forecast Remaining Report";
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
            if (textBox19.Value != DBNull.Value) totalVal += Convert.ToInt32(textBox19.Value);
            if (textBox21.Value != DBNull.Value) totalVal += Convert.ToInt32(textBox21.Value);
            if (textBox23.Value != DBNull.Value) totalVal += Convert.ToInt32(textBox23.Value);
            if (textBox25.Value != DBNull.Value) totalVal += Convert.ToInt32(textBox25.Value);
            if (textBox27.Value != DBNull.Value) totalVal += Convert.ToInt32(textBox27.Value);
            if (textBox29.Value != DBNull.Value) totalVal += Convert.ToInt32(textBox29.Value);
            if (textBox30.Value != DBNull.Value) totalVal += Convert.ToInt32(textBox30.Value);

            textBox10.Value = totalVal.ToString("#,##0");
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

            totalValAll = Convert.ToInt32(textBox12.Value)
                + Convert.ToInt32(textBox13.Value)
                + Convert.ToInt32(textBox14.Value)
                + Convert.ToInt32(textBox15.Value)
                + Convert.ToInt32(textBox16.Value)
                + Convert.ToInt32(textBox17.Value)
                + Convert.ToInt32(textBox20.Value)
                + Convert.ToInt32(textBox22.Value)
                + Convert.ToInt32(textBox24.Value)
                + Convert.ToInt32(textBox26.Value)
                + Convert.ToInt32(textBox28.Value)
                + Convert.ToInt32(textBox31.Value)
                + Convert.ToInt32(textBox32.Value);

            textBox18.Value = totalValAll.ToString("#,##0");
        }
    }
}
