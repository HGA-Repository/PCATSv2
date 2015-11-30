using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


using System.Windows.Forms;
using System.Diagnostics;
//using Bytescout.Spreadsheet;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel; //********************Added 10/9/2015
using Microsoft.Office.Core;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
using System.Collections;

namespace RSMPS
{
    public class CDrawingExport
    {

       public  Excel.Application excelApp2;
       public Excel._Worksheet workSheet;

        public CBDrawingLog moDrwLog;
          
        CDbDrawingLog dl = new CDbDrawingLog();


        public object misValue = System.Reflection.Missing.Value;
   public     CDrawingExport()
        {


        }

 object Missing = System.Reflection.Missing.Value;

        public Excel.Workbook workBook2;


        public string CreateFolder_InDocument()
        {
            string folderName = @Environment.SpecialFolder.MyDocuments.ToString();

            string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                     
            string pathString = System.IO.Path.Combine(myDoc, "PCATJobStat");
       
            try
            {
                System.IO.Directory.CreateDirectory(pathString);
              //  MessageBox.Show("folder created"); 

            }
            catch (IOException ioex)
            {
                MessageBox.Show("folder not created");
                MessageBox.Show(ioex.Message); }            

         //   MessageBox.Show(Environment.SpecialFolder.MyDocuments.ToString() + "           "+folderName + " " +myDoc);
            return myDoc;
        }


   public void ExportDrawing_ToExcel_Test2(int projID, int deptID, string FN)
   {
       string initDr = CreateFolder_InDocument();
     initDr = initDr + "\\PCATJobStat";

  //  MessageBox.Show(FN);
       SaveFileDialog saveFileDialog1 = new SaveFileDialog();

       saveFileDialog1.InitialDirectory = initDr;



         saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
        saveFileDialog1.DefaultExt = "xls";
       
      // saveFileDialog1.FilterIndex = 1;
      // saveFileDialog1.RestoreDirectory = true;
        saveFileDialog1.FileName = FN;



       string x="";
       if (saveFileDialog1.ShowDialog() == DialogResult.OK)
       {
            x = saveFileDialog1.FileName;
           //   MessageBox.Show(x);
       }
       else return;
       fName = x;

   
      excelApp2 = new Excel.Application();


       // Make the object visible.
            
       excelApp2.DefaultSaveFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;
       excelApp2.DisplayAlerts = false;
     
       workBook2 = excelApp2.Workbooks.Add(misValue);

       workBook2.CheckCompatibility = false;
       workSheet = excelApp2.ActiveSheet;

      

       SqlDataReader dr;


       int indx = 1;
       dr = dl.GetListbyDeptProj(deptID, projID);
       workSheet.Cells[indx, 1] = "ID";
       workSheet.Cells[indx, 2] = "DepartmentID";
       workSheet.Cells[indx, 3] = "ProjectID";
       workSheet.Cells[indx, 4] = "ProjectLeadID";
       workSheet.Cells[indx, 5] = "WBS";
       workSheet.Cells[indx, 6] = "HGANumber";
       workSheet.Cells[indx, 7] = "ClientNumber";
       workSheet.Cells[indx, 8] = "CADNumber";
       workSheet.Cells[indx, 9] = "ActCodeID";
       workSheet.Cells[indx, 10] = "IsTask";
       workSheet.Cells[indx, 11] = "DrawingSizeID";

       workSheet.Cells[indx, 12] = "BudgetHrs";
       workSheet.Cells[indx, 13] = "PercentComplete";
       workSheet.Cells[indx, 14] = "RemainingHrs";
       workSheet.Cells[indx, 15] = "EarnedHrs";
       workSheet.Cells[indx, 16] = "Title1";
       workSheet.Cells[indx, 17] = "Title1IsTitle";
       workSheet.Cells[indx, 18] = "Title1IsDesc";
       workSheet.Cells[indx, 19] = "Title2";
       workSheet.Cells[indx, 20] = "Title2IsTitle";
       workSheet.Cells[indx, 21] = "Title2IsDesc";


       workSheet.Cells[indx, 22] = "Title3";
       workSheet.Cells[indx, 23] = "Title3IsTitle";
       workSheet.Cells[indx, 24] = "Title3IsDesc";
       workSheet.Cells[indx, 25] = "Title4";
       workSheet.Cells[indx, 26] = "Title4IsTitle";
       workSheet.Cells[indx, 27] = "Title4IsDesc";
       workSheet.Cells[indx, 28] = "Title5";
       workSheet.Cells[indx, 29] = "Title5IsTitle";
       workSheet.Cells[indx, 30] = "Title5IsDesc";
       workSheet.Cells[indx, 31] = "Title6";


       workSheet.Cells[indx, 32] = "Title6IsTitle";
       workSheet.Cells[indx, 33] = "Title6IsDesc";
       workSheet.Cells[indx, 34] = "Revision";
       workSheet.Cells[indx, 35] = "ReleasedDrawingID";
       workSheet.Cells[indx, 36] = "DateRevised";
       workSheet.Cells[indx, 37] = "DateDue";
       workSheet.Cells[indx, 38] = "DateLate";
       indx++;




       while (dr.Read())
       {
           //  MessageBox.Show("XLReadingDirection.........");
           workSheet.Cells[indx, 1] = dr["ID"];
           workSheet.Cells[indx, 2] = dr["DepartmentID"];
           workSheet.Cells[indx, 3] = dr["ProjectID"];
           workSheet.Cells[indx, 4] = dr["ProjectLeadID"];
           workSheet.Cells[indx, 5] = dr["WBS"];
           workSheet.Cells[indx, 6] = dr["HGANumber"].ToString();
           workSheet.Cells[indx, 7] = dr["ClientNumber"];
           workSheet.Cells[indx, 8] = dr["CADNumber"];
           //  sheet[indx, 8].Value = dr["ActCodeID"];

           workSheet.Cells[indx, 9] = dr["Code"];

        //   workSheet.Cells[indx, 9] = dr["ActCodeID"]; //*****************************************************11/23
           workSheet.Cells[indx, 10] = dr["IsTask"];
           workSheet.Cells[indx, 11] = dr["DrawingSizeID"];


           workSheet.Cells[indx, 12].Value = dr["BudgetHrs"];
           workSheet.Cells[indx, 13].Value = dr["PercentComplete"];
           workSheet.Cells[indx, 14].Value = dr["RemainingHrs"];
           workSheet.Cells[indx, 15].Value = dr["EarnedHrs"];
           workSheet.Cells[indx, 16].Value = dr["Title1"].ToString();
           workSheet.Cells[indx, 17].Value = dr["Title1IsTitle"];
           workSheet.Cells[indx, 18].Value = dr["Title1IsDesc"];
           workSheet.Cells[indx, 19].Value = dr["Title2"].ToString();
           workSheet.Cells[indx, 20].Value = dr["Title2IsTitle"];
           workSheet.Cells[indx, 21].Value = dr["Title2IsDesc"];


           workSheet.Cells[indx, 22].Value = dr["Title3"].ToString();
           workSheet.Cells[indx, 23].Value = dr["Title3IsTitle"];
           workSheet.Cells[indx, 24].Value = dr["Title3IsDesc"];
           workSheet.Cells[indx, 25].Value = dr["Title4"].ToString();
           workSheet.Cells[indx, 26].Value = dr["Title4IsTitle"];
           workSheet.Cells[indx, 27].Value = dr["Title4IsDesc"];
           workSheet.Cells[indx, 28].Value = dr["Title5"].ToString();
           workSheet.Cells[indx, 29].Value = dr["Title5IsTitle"];
           workSheet.Cells[indx, 30].Value = dr["Title5IsDesc"];
           workSheet.Cells[indx, 31].Value = dr["Title6"].ToString();


           workSheet.Cells[indx, 32].Value = dr["Title6IsTitle"];
           workSheet.Cells[indx, 33].Value = dr["Title6IsDesc"];
           workSheet.Cells[indx, 34].Value = dr["Revision"];
           workSheet.Cells[indx, 35].Value = dr["ReleasedDrawingID"];
           workSheet.Cells[indx, 36].Value = dr["DateRevised"].ToString();  //  quantity
           workSheet.Cells[indx, 37].Value = dr["DateDue"];
           workSheet.Cells[indx, 38].Value = dr["DateLate"];
           // sheet[indx, 38].Value = dr["Deleted"];                                                           
           // sheet[indx, 39].Value = dr["DateLastModified"];
           // sheet[indx, 40].Value = dr["DateCreated"];


           indx++;


       }

       dr.Close();         

       workBook2.SaveAs(x, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

       excelApp2.Visible = true;
       
       int no = FormatExcelFile();

       MessageBox.Show("Please Don't close the file while Editing");




       DialogResult ret = MessageBox.Show("Do you Want to Save the Data to Database? ", "Import JobStat", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
       if (ret == DialogResult.Cancel)
       {
           //  workBook2.Close(true, misValue, misValue);
           excelApp2.Quit();
           return;
       }
    
       else 
       {
           excelApp2.Quit();
           ExportDrawing_ToDataBase_Test2(deptID, projID, no, FN, initDr);

       }
   }

                                                       
            public string fName = "";
            public int FormatExcelFile()
            {
                int noOfRows = workSheet.UsedRange.Rows.Count;
                int iTotalRows = noOfRows + 10;

                string a = "";
                a = "Q" + iTotalRows;
                //  Excel.Range RangeQ = workSheet.get_Range("Q2", "Q20");
                Excel.Range RangeQ = workSheet.get_Range("Q2", a);
                RangeQ.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeQ.Validation.InCellDropdown = true;
                RangeQ.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 217, 217, 0));
                a = "R" + iTotalRows;
                // Excel.Range RangeR = workSheet.get_Range("R2", "R20");
                Excel.Range RangeR = workSheet.get_Range("R2", a);
                RangeR.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeR.Validation.InCellDropdown = true;
                RangeR.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));
                a = "T" + iTotalRows;
                Excel.Range RangeT = workSheet.get_Range("T2", a);
                RangeT.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeT.Validation.InCellDropdown = true;
                RangeT.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));
                a = "U" + iTotalRows;
                Excel.Range RangeU = workSheet.get_Range("U2", a);
                RangeU.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeU.Validation.InCellDropdown = true;
                RangeU.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 0, 255, 0));
                a = "W" + iTotalRows;
                Excel.Range RangeW = workSheet.get_Range("W2", a);
                RangeW.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeW.Validation.InCellDropdown = true;
                RangeW.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 0, 0, 255));
                a = "X" + iTotalRows;
             
                Excel.Range RangeX = workSheet.get_Range("X2", a);
                RangeX.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeX.Validation.InCellDropdown = true;
                RangeX.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));

                a = "Z" + iTotalRows;
                Excel.Range RangeZ = workSheet.get_Range("Z2", a);
                RangeZ.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeZ.Validation.InCellDropdown = true;

                a = "AA" + iTotalRows;
                Excel.Range RangeAA = workSheet.get_Range("AA2", a);
                RangeAA.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAA.Validation.InCellDropdown = true;
                a = "AC" + iTotalRows;
                Excel.Range RangeAC = workSheet.get_Range("AC2", a);
                RangeAC.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAC.Validation.InCellDropdown = true;
                a = "AD" + iTotalRows;
                Excel.Range RangeAD = workSheet.get_Range("AD2", a);
                RangeAD.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAD.Validation.InCellDropdown = true;
                a = "AF" + iTotalRows;
                Excel.Range RangeAF = workSheet.get_Range("AF2", a);
                RangeAF.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAF.Validation.InCellDropdown = true;
                a = "AZ" + iTotalRows;
                Excel.Range RangeAG = workSheet.get_Range("AG2", a);
                RangeAG.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAG.Validation.InCellDropdown = true;



          

                string listOfAccount2 = ActivityList() + "00000";

               

                a = "I" + iTotalRows;


                Excel.Range RangeI = workSheet.get_Range("I2", a);
                RangeI.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, listOfAccount2, Type.Missing);  //**********************11/20
                RangeI.Validation.InCellDropdown = true;
              

                Excel.Range RangeTop = workSheet.get_Range("A1", "AL1");
                RangeTop.Font.Bold = true;
                RangeTop.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));
                            

                a = "O" + iTotalRows;

   

                workSheet.get_Range("O2", a).Formula = "=L2-N2";


                a = "M" + iTotalRows;

                workSheet.get_Range("M2", a).Formula = "=IF(L2=0,0,(1-N2/L2)*100)";
                

                workSheet.Columns.AutoFit();
                workSheet.Columns[3].Style.Locked = true;

                //Excel.Range fit = workSheet.get_Range("A1", "AL100");
                //fit.Columns.AutoFit();

                        //Excel.Range rngRO = workSheet.Range["B1"];
                        //rngRO.Locked = true;


                // workSheet.get_Range("A1", Type.Missing).EntireColumn.AllowEdit = false;
                //rngRO.EntireColumn.Locked = true;


//******************************************************************************************************************************************************
                //Excel.Range rng = workSheet.Range["A1"];
                //// rng.EntireColumn.Hidden = true;
                ////    rng.EntireColumn.Hidden = true;
                //workSheet.Cells.Locked = false;
                //workSheet.Cells.FormulaHidden = false;
                //rng.Locked = true;
                //rng.FormulaHidden = false;
                //workSheet.Protect(Type.Missing, true, true, true);
               
                //**********************************

                this.excelApp2.Cells.Locked = false;
              //  this.excelApp2.get_Range("A1", "C3").Locked = true;                

                Excel.Range rngA = workSheet.Range["A1"];
                rngA.EntireColumn.Locked = true;
                
                Excel.Range rngB = workSheet.Range["B1"];
                rngB.EntireColumn.Locked = true;

                Excel.Range rngC = workSheet.Range["C1"];
                rngC.EntireColumn.Locked = true;

                Excel.Range rngD = workSheet.Range["D1"];
                rngD.EntireColumn.Locked = true;

                Excel.Range rngL = workSheet.Range["L1"];
                rngL.EntireColumn.Locked = true;

                Excel.Range rngM = workSheet.Range["M1"];
                rngM.EntireColumn.Locked = true;

                Excel.Range rngN = workSheet.Range["N1"];
                rngN.EntireColumn.Locked = true;
                


                workSheet.Protect(Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing);
                //*************************************                                           
                
                return noOfRows;
            }

            
                     public void ExportDrawing_ToDataBase_Test2(int deptID, int projID, int no, string FN, string location)
            {
               //  MessageBox.Show(fName);
                Excel.Application excelApp3 = new Excel.Application();

                string fName2 = location + "\\" + FN + ".xls";
          //     MessageBox.Show(fName2);

                Excel.Workbook excelWorkbook3 = excelApp3.Workbooks.Open(fName2, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

          //      workBook = excelApp.Workbooks.Add(misValue); 

                excelApp3.DefaultSaveFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;
                Excel._Worksheet workSheet3 = excelApp3.ActiveSheet;

                int lastRow = 0;

                for (int i = 1; i < (no + 5); i++)
                {
                    if (workSheet3.Cells[i, 12].Text == "")
                    {
                        lastRow = i;
                        //   MessageBox.Show("Emply" + "found @" + lastRow);
                        break;
                    }


                }

                for (int indx = 2; indx < lastRow; indx++)
                {

                    int ID = LoadScreenToObject_X(indx, deptID, projID, workSheet3);



                    if (ID == 0)
                    {
                        //   MessageBox.Show("Return of ID Test for..." + ID + "....."  + "..So   Insert");
                        moDrwLog.Save_Insert();

                    }
                    else
                    {
                        // MessageBox.Show("Return of ID Test for..." + ID + "....."  + "..So   Update");

                        moDrwLog.Save_Update();
                    }
                    
                }


                excelApp3.Quit();
            }


            private int FindIDExists_Test(int indx)
            {
                int id_Exists;
                id_Exists = dl.ID_Test(indx);
                return id_Exists;
            }   


            private int LoadScreenToObject_X(int indx, int deptID, int projID, Excel._Worksheet WS)
            {

                moDrwLog = new CBDrawingLog();
              
                if (WS.Cells[indx, 1].Text == "")
                    moDrwLog.ID = 0;
                else
                    moDrwLog.ID = Convert.ToInt32(WS.Cells[indx, 1].Value.ToString());

                moDrwLog.DepartmentID = Convert.ToInt32(WS.Cells[indx, 2].Value);
                moDrwLog.DepartmentID = deptID;
                moDrwLog.ProjectID = projID;
                moDrwLog.ProjectLeadID = Convert.ToInt32(WS.Cells[indx, 4].Value); ;
                moDrwLog.WBS = WS.Cells[indx, 5].Text;
                moDrwLog.HGANumber = WS.Cells[indx, 6].Text;
                moDrwLog.ClientNumber = WS.Cells[indx, 7].Text;
                moDrwLog.CADNumber = WS.Cells[indx, 8].Text;
            
              //  moDrwLog.ActCodeID = Array.IndexOf(AccountCodeID, Convert.ToInt32(WS.Cells[indx, 9].Value)); ///****************11/20

                moDrwLog.ActCodeID = CBActivityCode.GetID_ByActivityCode(Convert.ToInt32(WS.Cells[indx, 9].Value));/// **************************     to fetch index of AccountCode ***11/23

               //moDrwLog.ActCodeID = ((RSLib.COListItem)Convert.ToInt32(WS.Cells[indx, 9].Value).ID;          


           //     MessageBox.Show("From Sheet....."+WS.Cells[indx, 9].Value + ".....ID...." + moDrwLog.ActCodeID);              


                //moDrwLog.IsTask = chkIsTask.Checked;
                moDrwLog.IsTaskDrwgSpec = Convert.ToInt32(WS.Cells[indx, 10].Value);
                //  moDrwLog.DrawingSizeID = GetDrawingSizeCode();
                moDrwLog.DrawingSizeID = Convert.ToInt32(WS.Cells[indx, 11].Value);

                try
                {
                    moDrwLog.BudgetHrs = Convert.ToDecimal(WS.Cells[indx, 12].Text);
                }
                catch
                {
                    moDrwLog.BudgetHrs = 0;
                }
                try
                {
                    moDrwLog.PercentComplete = Convert.ToDecimal(WS.Cells[indx, 13].Text);
                }
                catch
                {
                    moDrwLog.PercentComplete = 0;
                }
                try
                {
                    moDrwLog.RemainingHrs = Convert.ToDecimal(WS.Cells[indx, 14].Text);
                }
                catch
                {
                    moDrwLog.RemainingHrs = 0;
                }
                try
                {
                    moDrwLog.EarnedHrs = Convert.ToDecimal(WS.Cells[indx, 15].Text);
                }
                catch
                {
                    moDrwLog.EarnedHrs = 0;
                }

                moDrwLog.Title1 = WS.Cells[indx, 16].Text;
                moDrwLog.Title2 = WS.Cells[indx, 18].Text;
                moDrwLog.Title3 = WS.Cells[indx, 22].Text;
                moDrwLog.Title4 = WS.Cells[indx, 25].Text;
                moDrwLog.Title5 = WS.Cells[indx, 28].Text;
                moDrwLog.Title6 = WS.Cells[indx, 31].Text;

                bool IsTitle1, IsTitle2, IsTitle3, IsTitle4, IsTitle5, IsTitle6;
                bool IsDesc1, IsDesc2, IsDesc3, IsDesc4, IsDesc5, IsDesc6;


                if (WS.Cells[indx, 17].Value.ToString() == "True")
                    IsTitle1 = true;
                else IsTitle1 = false;
                if (WS.Cells[indx, 20].Value.ToString() == "True")
                    IsTitle2 = true;
                else IsTitle2 = false;
                if (WS.Cells[indx, 23].Value.ToString() == "True")
                    IsTitle3 = true;
                else IsTitle3 = false;
                if (WS.Cells[indx, 26].Value.ToString() == "True")
                    IsTitle4 = true;
                else IsTitle4 = false;
                if (WS.Cells[indx, 29].Value.ToString() == "True")
                    IsTitle5 = true;
                else IsTitle5 = false;
                if (WS.Cells[indx, 32].Value.ToString() == "True")
                    IsTitle6 = true;
                else IsTitle6 = false;


                if (WS.Cells[indx, 18].Value.ToString() == "True")
                    IsDesc1 = true;
                else IsDesc1 = false;
                if (WS.Cells[indx, 21].Value.ToString() == "True")
                    IsDesc2 = true;
                else IsDesc2 = false;
                if (WS.Cells[indx, 24].Value.ToString() == "True")
                    IsDesc3 = true;
                else IsDesc3 = false;
                if (WS.Cells[indx, 27].Value.ToString() == "True")
                    IsDesc4 = true;
                else IsDesc4 = false;
                if (WS.Cells[indx, 30].Value.ToString() == "True")
                    IsDesc5 = true;
                else IsDesc5 = false;
                if (WS.Cells[indx, 33].Value.ToString() == "True")
                    IsDesc6 = true;
                else IsDesc6 = false;


                moDrwLog.Title1IsTitle = IsTitle1;
                moDrwLog.Title2IsTitle = IsTitle2;
                moDrwLog.Title3IsTitle = IsTitle3;
                moDrwLog.Title4IsTitle = IsTitle4;
                moDrwLog.Title5IsTitle = IsTitle5;
                moDrwLog.Title6IsTitle = IsTitle6;



                moDrwLog.Title1IsDesc = IsDesc1;
                moDrwLog.Title2IsDesc = IsDesc2;
                moDrwLog.Title3IsDesc = IsDesc3;
                moDrwLog.Title4IsDesc = IsDesc4;
                moDrwLog.Title5IsDesc = IsDesc5;
                moDrwLog.Title6IsDesc = IsDesc6;




                moDrwLog.Revision = WS.Cells[indx, 34].Text;
                moDrwLog.ReleasedDrawingID = Convert.ToInt32(WS.Cells[indx, 35].Value);

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
               
                return moDrwLog.ID;

            }
            private string ActivityList()
            {
                
                SqlDataReader dr;
                string AcctList = "";
                dr = CBDrawingLog.GetListAcctCodes();
                while (dr.Read())
                {
                   AcctList = AcctList + dr["Code"].ToString() + "," ;
                    
                }

                dr.Close();
         
                return AcctList;
            }


    
    }
}
