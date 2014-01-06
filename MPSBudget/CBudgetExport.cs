using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using C1.C1Excel;

namespace RSMPS
{
    public class CBudgetExport
    {
        public void ExportBudgetForPrimavera(string saveLoc, int budgetID)
        {
            SqlDataReader dr;
            C1XLBook book = new C1XLBook();
            XLSheet sheet = book.Sheets[0];
            int indx;
            decimal tmpRate;

            // must be output with the following columns
            // code,blank,description,quantity,uom,hours,rate,cost

            dr = CBBudgetLine.GetExportListByBudget(budgetID);

            indx = 0;
            tmpRate = 0;

            while (dr.Read())
            {
                sheet[indx, 3].Value = dr["Activity"];                                                      //  code
                sheet[indx, 4].Value = "";                                                                  //  blank
                sheet[indx, 5].Value = dr["FullDescription"];                                               //  description
                sheet[indx, 6].Value = dr["Quantity"].ToString();                                           //  quantity
                sheet[indx, 7].Value = dr["UOM"];                                                           //  uom
                sheet[indx, 8].Value = dr["TotalHours"].ToString();                                         //  hours
                tmpRate = GetHourRate(Convert.ToInt32(dr["TotalHours"]), Convert.ToDecimal(dr["TotalDollars"]));
                sheet[indx, 9].Value = tmpRate.ToString("#,##0.00");                                        //  rate
                sheet[indx, 10].Value = Convert.ToDecimal(dr["TotalDollars"]).ToString("#,##0.00");         //  cost

                indx++;
            }

            dr.Close();

            book.Save(saveLoc);
        }

        private decimal GetHourRate(int hours, decimal totalCost)
        {
            decimal hourRate;

            if (hours != 0)
            {
                hourRate = totalCost / Convert.ToDecimal(hours);
            }
            else
            {
                hourRate = 0;
            }

            return hourRate;
        }
    }
}
