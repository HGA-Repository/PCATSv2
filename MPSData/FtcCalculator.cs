using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RSMPS
{

    /// <summary>
    /// calculates the Forecast to Complete Values for the forecast and rollup Report
    /// </summary>
    public class FtcCalculator
    {


        /// <summary>
        /// expects the output from spRPRT_CostReport_NewAcct2_Vision
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static void UpdateCalculatedField(DataSet set) 
        {
            UpdateCalculatedField(set.Tables[1]);
        }

        private static void UpdateCalculatedField(DataTable table)
        {
            table.Columns.Add("ftc", typeof(decimal));
            foreach (DataRow row in table.Rows)
                UpdateCalculatedField(row);
        }

        private static void UpdateCalculatedField(DataRow row)
        {
            UpdateFtcValue(row);
            UpdateForcastValue(row);
        }



        private static void UpdateForcastValue(DataRow row)
        {
            decimal forcast = (decimal)row["ForecastAmnt"];
            decimal costs = (decimal)row["costs"];
            decimal budget = (decimal)row["budget"];

            if (forcast < -1000)
            {
                if (forcast < -250000)
                {
                    forcast = costs;
                }
                else if (costs > budget)
                {
                    forcast = costs;
                }
                else if (costs < 0)
                {
                    forcast = budget - costs;
                }
                else
                {
                    forcast = budget;
                }
            }
            else if (costs >= forcast)
            {
                forcast = (costs > budget) ? costs : budget;
            }

            row["ForecastAmnt"] = forcast;
        }


        private static void UpdateFtcValue(DataRow row)
        {
            decimal forcast = (decimal)row["ForecastAmnt"];
            decimal costs = (decimal)row["costs"];
            decimal budget = (decimal)row["budget"];
            decimal ftc = 0;

            if (forcast < -1000)
            {
                if (forcast < -250000)
                {
                    ftc = 0;
                }
                else if (costs > budget)
                {
                    ftc = 0;
                }
                else if (costs < 0)
                {
                    ftc = 0;
                }
                else
                {
                    ftc = budget - costs;
                }
            }
            else
            {
                if (costs >= forcast)
                {
                    ftc = (costs > budget) ? 0 : budget - costs;
                }
                else
                {
                    ftc = forcast - costs;
                }
            }

            if (costs < 0) ftc = 0;

            row["ftc"] = ftc;
        }


    }
}
