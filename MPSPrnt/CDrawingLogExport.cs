using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using C1.C1Excel;

namespace RSMPS
{
    public class CDrawingLogExport
    {
       
            public void ExportBudgetForPrimavera_GetDrawingLogMainByDeptListProjList(string saveLoc, string dXml, string pXml, int sortCode, int drwgSpec)
        {
            SqlDataReader dr;
            C1XLBook book = new C1XLBook();
            XLSheet sheet = book.Sheets[0];
            int indx;
            decimal tmpRate;

            // must be output with the following columns
            // code,blank,description,quantity,uom,hours,rate,cost

          //  dr = CBBudgetLine.GetExportListByBudget(budgetID);
            dr = CBDrawingLog.GetExportListForDrawingLog(dXml, pXml, sortCode, drwgSpec);

            indx = 0;
            tmpRate = 0;

            while (dr.Read())
            {
                sheet[indx, 3].Value = dr["DrawingID"].ToString();                                                      //  code
                sheet[indx, 4].Value = "";                                                                  //  blank
               sheet[indx, 5].Value = dr["Department"];                                               //  description
                sheet[indx, 6].Value = dr["Project"].ToString();                                           //  quantity
                sheet[indx, 7].Value = dr["ProjectNumber"];                                                           //  uom
                sheet[indx, 8].Value = dr["Title1"].ToString();                                         //  hours
                sheet[indx, 9].Value = dr["RevisionNumber"].ToString();
                sheet[indx, 10].Value = dr["IssueDate"].ToString();                                    //  rate
                sheet[indx, 11].Value = dr["IssuedFor"].ToString();        //  cost
                sheet[indx, 12].Value = dr["TransNo"].ToString(); 


                indx++;
            }

            dr.Close();

            book.Save(saveLoc);
        }
            public void ExportBudgetForPrimavera_GetDrawingLogMainByDeptList(string saveLoc, string xml,  int sortCode, int drwgSpec)
            {
                SqlDataReader dr;
                C1XLBook book = new C1XLBook();
                XLSheet sheet = book.Sheets[0];
                int indx;
                decimal tmpRate;

                // must be output with the following columns
                // code,blank,description,quantity,uom,hours,rate,cost

                
                dr = CBDrawingLog.GetExportListForDrawingLog_Dept(xml, sortCode, drwgSpec);

                indx = 0;
                tmpRate = 0;

                while (dr.Read())
                {
                    sheet[indx, 3].Value = dr["DrawingID"].ToString();                                                      //  code
                    sheet[indx, 4].Value = "";                                                                  //  blank
                    sheet[indx, 5].Value = dr["Department"];                                               //  description
                    sheet[indx, 6].Value = dr["Project"].ToString();                                           //  quantity
                    sheet[indx, 7].Value = dr["ProjectNumber"];                                                           //  uom
                    sheet[indx, 8].Value = dr["Title1"].ToString();                                         //  hours
                    sheet[indx, 9].Value = dr["RevisionNumber"].ToString();
                    sheet[indx, 10].Value = dr["IssueDate"].ToString();                                    //  rate
                    sheet[indx, 11].Value = dr["IssuedFor"].ToString();        //  cost
                    sheet[indx, 12].Value = dr["TransNo"].ToString();


                    indx++;
                }

                dr.Close();

                book.Save(saveLoc);
            }
            public void ExportBudgetForPrimavera_GetDrawingLogMainByProjList(string saveLoc, string xml,  int sortCode, int drwgSpec)
            {
                SqlDataReader dr;
                C1XLBook book = new C1XLBook();
                XLSheet sheet = book.Sheets[0];
                int indx;
                decimal tmpRate;

                // must be output with the following columns
                // code,blank,description,quantity,uom,hours,rate,cost

                //  dr = CBBudgetLine.GetExportListByBudget(budgetID);
                dr = CBDrawingLog.GetExportListForDrawingLog_Proj(xml, sortCode, drwgSpec);

                indx = 0;
                tmpRate = 0;

                while (dr.Read())
                {
                    sheet[indx, 3].Value = dr["DrawingID"].ToString();                                                      //  code
                    sheet[indx, 4].Value = "";                                                                  //  blank
                    sheet[indx, 5].Value = dr["Department"];                                               //  description
                    sheet[indx, 6].Value = dr["Project"].ToString();                                           //  quantity
                    sheet[indx, 7].Value = dr["ProjectNumber"];                                                           //  uom
                    sheet[indx, 8].Value = dr["Title1"].ToString();                                         //  hours
                    sheet[indx, 9].Value = dr["RevisionNumber"].ToString();
                    sheet[indx, 10].Value = dr["IssueDate"].ToString();                                    //  rate
                    sheet[indx, 11].Value = dr["IssuedFor"].ToString();        //  cost
                    sheet[indx, 12].Value = dr["TransNo"].ToString();


                    indx++;
                }

                dr.Close();

                book.Save(saveLoc);
            }
            public void ExportBudgetForPrimavera_GetDrawingLogMainByLeadList(string saveLoc, string deptXml, string leadXml, int sortCode, int drwgSpec)
            {
                SqlDataReader dr;
                C1XLBook book = new C1XLBook();
                XLSheet sheet = book.Sheets[0];
                int indx;
                decimal tmpRate;

                // must be output with the following columns
                // code,blank,description,quantity,uom,hours,rate,cost

                //  dr = CBBudgetLine.GetExportListByBudget(budgetID);
                dr = CBDrawingLog.GetExportListForDrawingLog_Lead(deptXml, leadXml, sortCode, drwgSpec);

                indx = 0;
                tmpRate = 0;

                while (dr.Read())
                {
                    sheet[indx, 3].Value = dr["DrawingID"].ToString();                                                      //  code
                    sheet[indx, 4].Value = "";                                                                  //  blank
                    sheet[indx, 5].Value = dr["Department"];                                               //  description
                    sheet[indx, 6].Value = dr["Project"].ToString();                                           //  quantity
                    sheet[indx, 7].Value = dr["ProjectNumber"];                                                           //  uom
                    sheet[indx, 8].Value = dr["Title1"].ToString();                                         //  hours
                    sheet[indx, 9].Value = dr["RevisionNumber"].ToString();
                    sheet[indx, 10].Value = dr["IssueDate"].ToString();                                    //  rate
                    sheet[indx, 11].Value = dr["IssuedFor"].ToString();        //  cost
                    sheet[indx, 12].Value = dr["TransNo"].ToString();


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
