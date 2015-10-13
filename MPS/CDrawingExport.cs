using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


using System.Windows.Forms;
using System.Diagnostics;
//using Bytescout.Spreadsheet;
using System.IO;


using C1.C1Excel;

namespace RSMPS
{
    public class CDrawingExport
    {
        public C1XLBook book ;
        public XLSheet sheet ;
        public CBDrawingLog moDrwLog;
        public FileStream fs;
            int ID;
            public string F_Name;
        
        CDbDrawingLog dl = new CDbDrawingLog();
  // public void ExportDrawingForPrimavera()
       public void ExportDrawingForPrimavera(int deptID, int projID)
        {
            string s = "C:\\Test\\" + F_Name + ".xlsx";
           // string s = "C:\\Test\\Book3.xls";
         

                      FileStream fs = new FileStream(@s, FileMode.Open, FileAccess.Read);
           // FileStream fs = new FileStream(@"C:\\Test\\Book3.xlsx", FileMode.Open, FileAccess.Read);
                    
                        book = new C1XLBook();
                         book.Load(fs, FileFormat.OpenXml);
                             sheet = book.Sheets[0];
                          //   int indx = 2;
                          //int did =    LoadScreenToObject(indx);
                          //   moDrwLog.Save_Test();
                    //             return did;

                             MessageBox.Show(F_Name + "..............................................");        
                             for (int indx = 1; indx < 5; indx++)
                             {                             
                               int id=  LoadScreenToObject(indx, deptID, projID);
                                    int id_exist = dl.ID_Test(id);
                    
                                    if (id_exist == 0)
                                    {
                                        MessageBox.Show(id.ToString() + "-----" + id_exist.ToString() + "   Insert");
                                        moDrwLog.Save_Insert();
                                       
                                    }
                                    else
                                    {
                                        MessageBox.Show(id.ToString() + "-----" + id_exist.ToString() + "Update");
                                        moDrwLog.ID = id;
                                        moDrwLog.Save_Update();
                                    }
                             }

        }




         


       private int LoadScreenToObject(int indx, int deptID, int projID)
          //   private int LoadScreenToObject(int indx)
        {
               
            moDrwLog = new CBDrawingLog();
           ID = Convert.ToInt32(sheet[indx, 0].Value);
                       //moDrwLog.DepartmentID = Convert.ToInt32(sheet[indx, 1].Value);
            moDrwLog.DepartmentID = deptID;
                       //moDrwLog.ProjectID = Convert.ToInt32(sheet[indx, 2].Value);
            moDrwLog.ProjectID = projID;
                        //moDrwLog.ProjectLeadID = Convert.ToInt32(sheet[indx, 3].Value);
            moDrwLog.ProjectLeadID = Convert.ToInt32(sheet[indx, 3].Value); ;
            moDrwLog.HGANumber = sheet[indx, 5].Text;
                        //moDrwLog.ClientNumber = sheet[indx, 6].Text;
            moDrwLog.ClientNumber = sheet[indx, 6].Text;
                        // moDrwLog.CADNumber = sheet[indx, 7].Text;
            moDrwLog.CADNumber = sheet[indx, 7].Text;
                        // moDrwLog.ActCodeID = GetActivityCode();
                    //moDrwLog.ActCodeID = Convert.ToInt32(sheet[indx, 8].Value);
            moDrwLog.ActCodeID = Convert.ToInt32(sheet[indx, 8].Value);

            //moDrwLog.IsTask = chkIsTask.Checked;
                        // moDrwLog.IsTaskDrwgSpec = Convert.ToInt32(sheet[indx, 9].Value);
            moDrwLog.IsTaskDrwgSpec = 1;

          //  moDrwLog.DrawingSizeID = GetDrawingSizeCode();
           // moDrwLog.DrawingSizeID = Convert.ToInt32(sheet[indx, 10].Value);
            moDrwLog.DrawingSizeID = 2;
            moDrwLog.WBS = sheet[indx, 4].Text;
            try
            {
                moDrwLog.BudgetHrs = Convert.ToDecimal(sheet[indx, 11].Text);
            }
            catch
            {
                moDrwLog.BudgetHrs = 0;
            }
            try
            {
                moDrwLog.PercentComplete = Convert.ToDecimal(sheet[indx, 12].Text);
            }
            catch
            {
                moDrwLog.PercentComplete = 0;
            }
            try
            {
                moDrwLog.RemainingHrs = Convert.ToDecimal(sheet[indx, 13].Text);
            }
            catch
            {
                moDrwLog.RemainingHrs = 0;
            }
            try
            {
                moDrwLog.EarnedHrs = Convert.ToDecimal(sheet[indx, 14].Text);
            }
            catch
            {
                moDrwLog.EarnedHrs = 0;
            }

            moDrwLog.Title1 = sheet[indx, 15].Text;
            moDrwLog.Title2 = sheet[indx, 18].Text;
            moDrwLog.Title3 = sheet[indx, 21].Text;
            moDrwLog.Title4 = sheet[indx, 24].Text;
            moDrwLog.Title5 = sheet[indx, 27].Text;
            moDrwLog.Title6 = sheet[indx, 30].Text;

            moDrwLog.Title6IsTitle = true;
            moDrwLog.Title5IsTitle = true;
            moDrwLog.Title4IsTitle = true;
            moDrwLog.Title3IsTitle = true;
            moDrwLog.Title2IsTitle = true;
            moDrwLog.Title1IsTitle = true;

            moDrwLog.Title6IsDesc = true;
            moDrwLog.Title5IsDesc = true;
            moDrwLog.Title4IsDesc = true;
            moDrwLog.Title3IsDesc = true;
            moDrwLog.Title2IsDesc = true;
            moDrwLog.Title1IsDesc = true;

            moDrwLog.Revision = sheet[indx, 33].Text;
            moDrwLog.ReleasedDrawingID = 1;
            //if (dtpDateRevised.Checked == false)
                moDrwLog.DateRevised = RSLib.COUtility.DEFAULTDATE;
            //else
                //moDrwLog.DateRevised = dtpDateRevised.Value;

           // if (dtpDateDue.Checked == false)
                moDrwLog.DateDue = RSLib.COUtility.DEFAULTDATE;
            //else
               // moDrwLog.DateDue = dtpDateDue.Value;

            //if (dtpDateLate.Checked == false)
                moDrwLog.DateLate = RSLib.COUtility.DEFAULTDATE;
           // else
              //  moDrwLog.DateLate = dtpDateLate.Value;
                return ID;
        
        }
        
        //*****************************************Not Needed


        public void ExportDrawingForPrimavera(string saveLoc, int projID, int deptID)
        {
            SqlDataReader dr;
            C1XLBook book = new C1XLBook();
            XLSheet sheet = book.Sheets[0];

            //book = new C1XLBook("C:\\Test\\JobStat.Xls");
            sheet = book.Sheets[0];

            int indx;
            decimal tmpRate;

            // must be output with the following columns
            // 

            //dr = dl.GetDrawingLogForExport(deptID, projID);
            dr = dl.GetListbyDeptProj(deptID, projID);

            indx = 1;

            //Alt. Doc #	Drwg/Spec #	WBS	Type	Title/Description	Acct	Budget	% Comp.	Ernd Hrs	Rmn Hrs

            sheet[0, 0].Value = "ID"; 
            sheet[0, 1].Value = "Alt. Doc #"; 
            sheet[0, 2].Value = "Drwg/Spec #"; 
            sheet[0, 3].Value = "WBS";
            sheet[0, 4].Value = "Type";
            sheet[0, 5].Value = "Title/Description";  //  quantity
            sheet[0, 6].Value = "Acct";
            sheet[0, 7].Value = "Budget";
            sheet[0, 8].Value = "% Comp.";                                                           //  uom
            sheet[0, 9].Value = "Ernd Hrs";
            sheet[0, 9].Value = "Rmn Hrs";
            sheet[0, 10].Value = "DrawingSizeID";

            sheet[0, 11].Value = "BudgetHrs";
            sheet[0, 12].Value = "PercentComplete";
            sheet[0, 13].Value = "RemainingHrs";
            sheet[0, 14].Value = "EarnedHrs";
            sheet[0, 15].Value = "Title1";
            sheet[0, 16].Value = "Title1IsTitle";
            sheet[0, 17].Value = "Title1IsDesc";
            sheet[0, 18].Value = "Title2";
            sheet[0, 19].Value = "Title2IsTitle";
            sheet[0, 20].Value = "Title2IsDesc";


            sheet[0, 21].Value = "Title3";
            sheet[0, 22].Value = "Title3IsTitle";
            sheet[0, 23].Value = "Title3IsDesc";
            sheet[0, 24].Value = "Title4";
            sheet[0, 25].Value = "Title4IsTitle";
            sheet[0, 26].Value = "Title4IsDesc";
            sheet[0, 27].Value = "Title5";
            sheet[0, 28].Value = "Title5IsTitle";
            sheet[0, 29].Value = "Title5IsDesc";
            sheet[0, 30].Value = "Title6";


            sheet[0, 31].Value = "Title6IsTitle";
            sheet[0, 32].Value = "Title6IsDesc";
            sheet[0, 33].Value = "Revision";
            sheet[0, 34].Value = "ReleasedDrawingID";
            sheet[0, 35].Value = "DateRevised";  
            sheet[0, 36].Value = "DateDue";
            sheet[0, 37].Value = "DateLate";
            tmpRate = 0;

            while (dr.Read())
            {
                
                sheet[indx, 0].Value = dr["ID"];    
                sheet[indx, 1].Value = dr["DepartmentID"];
                sheet[indx, 2].Value = dr["ProjectID"];
                sheet[indx, 3].Value = dr["ProjectLeadID"];
                sheet[indx, 4].Value = dr["WBS"];
                sheet[indx, 5].Value = dr["HGANumber"].ToString();  
                sheet[indx, 6].Value = dr["ClientNumber"];
                sheet[indx, 7].Value = dr["CADNumber"];
                sheet[indx, 8].Value = dr["ActCodeID"];                                                           
                sheet[indx, 9].Value = dr["IsTask"];
                sheet[indx, 10].Value = dr["DrawingSizeID"];

                sheet[indx, 11].Value = dr["BudgetHrs"];
                sheet[indx, 12].Value = dr["PercentComplete"];
                sheet[indx, 13].Value = dr["RemainingHrs"];
                sheet[indx, 14].Value = dr["EarnedHrs"];
                sheet[indx, 15].Value = dr["Title1"].ToString();  
                sheet[indx, 16].Value = dr["Title1IsTitle"];
                sheet[indx, 17].Value = dr["Title1IsDesc"];
                sheet[indx, 18].Value = dr["Title2"];                                                          
                sheet[indx, 19].Value = dr["Title2IsTitle"];
                sheet[indx, 20].Value = dr["Title2IsDesc"];

                
                sheet[indx, 21].Value = dr["Title3"];
                sheet[indx, 22].Value = dr["Title3IsTitle"];
                sheet[indx, 23].Value = dr["Title3IsDesc"];
                sheet[indx, 24].Value = dr["Title4"];
                sheet[indx, 25].Value = dr["Title4IsTitle"].ToString();  
                sheet[indx, 26].Value = dr["Title4IsDesc"];
                sheet[indx, 27].Value = dr["Title5"];
                sheet[indx, 28].Value = dr["Title5IsTitle"];                                                           
                sheet[indx, 29].Value = dr["Title5IsDesc"];
                sheet[indx, 30].Value = dr["Title6"];

                
                sheet[indx, 31].Value = dr["Title6IsTitle"];
                sheet[indx, 32].Value = dr["Title6IsDesc"];
                sheet[indx, 33].Value = dr["Revision"];
                sheet[indx, 34].Value = dr["ReleasedDrawingID"];
                sheet[indx, 35].Value = dr["DateRevised"].ToString();  //  quantity
                sheet[indx, 36].Value = dr["DateDue"];
                sheet[indx, 37].Value = dr["DateLate"];
               // sheet[indx, 38].Value = dr["Deleted"];                                                           
               // sheet[indx, 39].Value = dr["DateLastModified"];
               // sheet[indx, 40].Value = dr["DateCreated"];
                
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
