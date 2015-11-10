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
//***********************************************************************************************************


using System.ComponentModel;

using System.Drawing;

using System.Collections;

//***********************************************************************************************************




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


                     public void ExportDrawing_ToDataBase(int deptID, int projID)
                     
       {
          // string s = "C:\\Test\\" + F_Name + ".xlsx";
         //  string s = "C:\\Test\\" +"HGA" + ".xlsx";
           string s = F_Name;
          
           FileStream fs = new FileStream(@s, FileMode.Open, FileAccess.Read);
           
           book = new C1XLBook();
           book.Load(fs, FileFormat.OpenXml); 
           sheet = book.Sheets[0];

           int NoOfRows = sheet.Rows.Count;
           NoOfRows--;
           int lastRow = 0;

           for (int i = 0; i < NoOfRows; i++)
           {
               if (sheet[i, 12].Text == "#DIV/0!")
               {
                   lastRow = i;
                   MessageBox.Show(sheet[i, 12].Text + "found @" + lastRow);
                   break;
               }


           }

        //   if (lastRow == 0)
          //     NoOfRows = lastRow;

  //         MessageBox.Show(sheet.Rows.Count.ToString() + "............" + F_Name + "NoOfRows..." + NoOfRows + "..lastRow..found @" + lastRow);
        
  //       for (int indx = 1; indx < NoOfRows; indx++)

           int indx;
           for (indx = 1; indx < lastRow; indx++)
    
           {
                                   //int id = LoadScreenToObject(indx, deptID, projID);
                                 //  int id_exist = dl.ID_Test(id);

                                   //if (id_exist == 0)
                                   //{
                                   //    MessageBox.Show(id.ToString() + "-----" + id_exist.ToString() + "   Insert");
                                   //    moDrwLog.Save_Insert();

                                   //}
                                   //else
                                   //{
                                   //    MessageBox.Show(id.ToString() + "-----" + id_exist.ToString() + "Update");
                                   //    moDrwLog.ID = id;
                                   //    moDrwLog.Save_Update();
                                   //}

          LoadScreenToObject(indx, deptID, projID);

           int ii =    FindIDExists(moDrwLog.ID);
     //      MessageBox.Show("Title1......" + moDrwLog.Title1IsTitle.ToString() + "..Title2......" + moDrwLog.Title2IsTitle.ToString() + "Title3......" + moDrwLog.Title3IsTitle.ToString());


           if (ii == 0)
           {
               MessageBox.Show("Return of ID Test for..." + moDrwLog.ID + "....." + ii + "..So   Insert");
               moDrwLog.Save_Insert();

           }
           else
           {
               MessageBox.Show("Return of ID Test for..." + moDrwLog.ID + "....." + ii + "..So   Update");
             
               moDrwLog.Save_Update();
           }
               

           }

       }

                     private int FindIDExists(int indx)
                     
                     {
                         int id_Exists;
                         CDbDrawingLog moCDbDrawingLogTestID = new CDbDrawingLog();
                         id_Exists = moCDbDrawingLogTestID.ID_Test(indx);
                         return id_Exists;
                     }


         


       private int LoadScreenToObject(int indx, int deptID, int projID)
          
        {
               
            moDrwLog = new CBDrawingLog();
       //    ID = Convert.ToInt32(sheet[indx, 0].Value);
            moDrwLog.ID = Convert.ToInt32(sheet[indx, 0].Value);

                       moDrwLog.DepartmentID = Convert.ToInt32(sheet[indx, 1].Value);
            moDrwLog.DepartmentID = deptID;
                       //moDrwLog.ProjectID = Convert.ToInt32(sheet[indx, 2].Value);
            moDrwLog.ProjectID = projID;
                        //moDrwLog.ProjectLeadID = Convert.ToInt32(sheet[indx, 3].Value);
            moDrwLog.ProjectLeadID = Convert.ToInt32(sheet[indx, 3].Value); ;
           moDrwLog.WBS = sheet[indx, 4].Text; 
           moDrwLog.HGANumber = sheet[indx, 5].Text;
            moDrwLog.ClientNumber = sheet[indx, 6].Text;
                        // moDrwLog.CADNumber = sheet[indx, 7].Text;
            moDrwLog.CADNumber = sheet[indx, 7].Text;
                        // moDrwLog.ActCodeID = GetActivityCode();
                    
         //   moDrwLog.ActCodeID = Convert.ToInt32(sheet[indx, 8].Value);

            moDrwLog.ActCodeID = Array.IndexOf(listOfAccount, Convert.ToInt32(sheet[indx, 8].Value)); /// **************************     to fetch index of AccountCode

       //     MessageBox.Show(moDrwLog.ActCodeID.ToString());


            //moDrwLog.IsTask = chkIsTask.Checked;
             moDrwLog.IsTaskDrwgSpec = Convert.ToInt32(sheet[indx, 9].Value);
           
                                 //  moDrwLog.DrawingSizeID = GetDrawingSizeCode();
            moDrwLog.DrawingSizeID = Convert.ToInt32(sheet[indx, 10].Value);
            
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

            bool IsTitle1, IsTitle2,IsTitle3,IsTitle4,IsTitle5,IsTitle6;
            bool IsDesc1, IsDesc2, IsDesc3, IsDesc4, IsDesc5, IsDesc6;


            if (sheet[indx, 16].Value.ToString() == "True")
                IsTitle1 = true;
            else IsTitle1 = false;
            if (sheet[indx, 19].Value.ToString() == "True")
                IsTitle2 = true;
            else IsTitle2 = false;
            if (sheet[indx, 22].Value.ToString() == "True")
                IsTitle3 = true;
            else IsTitle3 = false;
            if (sheet[indx, 25].Value.ToString() == "True")
                IsTitle4 = true;
            else IsTitle4 = false;
            if (sheet[indx, 28].Value.ToString() == "True")
                IsTitle5 = true;
            else IsTitle5 = false;
            if (sheet[indx, 31].Value.ToString() == "True")
                IsTitle6 = true;
            else IsTitle6 = false;


            if (sheet[indx, 17].Value.ToString() == "True")
                IsDesc1 = true;
            else IsDesc1 = false;
            if (sheet[indx, 20].Value.ToString() == "True")
                IsDesc2 = true;
            else IsDesc2 = false;
            if (sheet[indx, 23].Value.ToString() == "True")
                IsDesc3 = true;
            else IsDesc3 = false;
            if (sheet[indx, 26].Value.ToString() == "True")
                IsDesc4 = true;
            else IsDesc4 = false;
            if (sheet[indx, 29].Value.ToString() == "True")
                IsDesc5 = true;
            else IsDesc5 = false;
            if (sheet[indx, 32].Value.ToString() == "True")
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


     //       MessageBox.Show("From sheet....." + sheet[indx, 17].Value + ".from variable."+IsTitle1+ "............ToDB......." + moDrwLog.Title1IsTitle);

                //moDrwLog.Title1IsTitle = Convert.ToBoolean(sheet[indx, 16].Text);
                //moDrwLog.Title2IsTitle = Convert.ToBoolean(sheet[indx, 19].Text);
                //moDrwLog.Title3IsTitle = Convert.ToBoolean(sheet[indx, 22].Text);
                //moDrwLog.Title4IsTitle = Convert.ToBoolean(sheet[indx, 25].Text);
                //moDrwLog.Title5IsTitle = Convert.ToBoolean(sheet[indx, 28].Text);
                //moDrwLog.Title6IsTitle = Convert.ToBoolean(sheet[indx, 31].Text);



                //moDrwLog.Title1IsDesc = Convert.ToBoolean(sheet[indx, 17].Text);
                //moDrwLog.Title2IsDesc = Convert.ToBoolean(sheet[indx, 20].Text);
                //moDrwLog.Title3IsDesc = Convert.ToBoolean(sheet[indx, 23].Text);
                //moDrwLog.Title4IsDesc = Convert.ToBoolean(sheet[indx, 26].Text);
                //moDrwLog.Title5IsDesc = Convert.ToBoolean(sheet[indx, 29].Text);
                //moDrwLog.Title6IsDesc = Convert.ToBoolean(sheet[indx, 32].Text);









            moDrwLog.Revision = sheet[indx, 33].Text;
            moDrwLog.ReleasedDrawingID = Convert.ToInt32(sheet[indx, 34].Value); 

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


        
            public void ExportDrawing_ToExcel(string saveLoc, int projID, int deptID)
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

                    //  dr = dl.GetDrawingLogForExport(deptID, projID);
            dr = dl.GetListbyDeptProj(deptID, projID);

            indx = 1;

            sheet[0, 0].Value = "ID";
            sheet[0, 1].Value = "DepartmentID";
            sheet[0, 2].Value = "ProjectID";
            sheet[0, 3].Value = "ProjectLeadID";
            sheet[0, 4].Value = "WBS";
            sheet[0, 5].Value = "HGANumber";  //  quantity
            sheet[0, 6].Value = "ClientNumber";
            sheet[0, 7].Value = "CADNumber";
            sheet[0, 8].Value = "ActCodeID";                                                           //  uom
            sheet[0, 9].Value = "IsTask";
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
              //  sheet[indx, 8].Value = dr["ActCodeID"];
                sheet[indx, 8].Value = dr["Code"];                                            
                sheet[indx, 9].Value = dr["IsTask"];
                sheet[indx, 10].Value = dr["DrawingSizeID"];

                sheet[indx, 11].Value = dr["BudgetHrs"];
                sheet[indx, 12].Value = dr["PercentComplete"];
                sheet[indx, 13].Value = dr["RemainingHrs"];
                sheet[indx, 14].Value = dr["EarnedHrs"];
                sheet[indx, 15].Value = dr["Title1"].ToString();  
                sheet[indx, 16].Value = dr["Title1IsTitle"];
                sheet[indx, 17].Value = dr["Title1IsDesc"];
                sheet[indx, 18].Value = dr["Title2"].ToString();                                                          
                sheet[indx, 19].Value = dr["Title2IsTitle"];
                sheet[indx, 20].Value = dr["Title2IsDesc"];


                sheet[indx, 21].Value = dr["Title3"].ToString();
                sheet[indx, 22].Value = dr["Title3IsTitle"];
                sheet[indx, 23].Value = dr["Title3IsDesc"];
                sheet[indx, 24].Value = dr["Title4"].ToString();
                sheet[indx, 25].Value = dr["Title4IsTitle"];  
                sheet[indx, 26].Value = dr["Title4IsDesc"];
                sheet[indx, 27].Value = dr["Title5"].ToString();
                sheet[indx, 28].Value = dr["Title5IsTitle"];                                                           
                sheet[indx, 29].Value = dr["Title5IsDesc"];
                sheet[indx, 30].Value = dr["Title6"].ToString();

                
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

      public   int [] listOfAccount = {99999, 11000	,11100	,11110	,11210	,11220	,11230	,11310	,11320	,11330	,11410	,11820	,11910	,12000	,12100	,12110	,12200	,12210	,12211	,12212	,12213	,12214	,12215	,12220	,12221	,12222	,12223	,12224	,12225	,12226	,12227	,12229	,12300	,12310	,12311	,12312	,12313	,12320	,12330	,12331	,12332	,12333	,12334	,12340	,12350	,12360	,12370	,12380	,12390	,12391	,12392	,

    12393	,12394	,12395	,12400	,12410	,12411	,12412	,12413	,12414	,12415	,12416	,12490	,12491	,12501	,12502	,12503	,12504	,12506	,12507	,12508	,12509	,12510	,13000	,13100	,13110	,13200	,13210	,13211	,13212	,13213	,13214	,13215	,13220	,13221	,13222	,13223	,13224	,13225	,13226	,13227	,13229	,13300	,13310	,13311	,13312	,13320	,13330	,13331	,13332	,13333	,

    13334	,13335	,13340	,13360	,13370	,13380	,13390	,13391	,13392	,13393	,13394	,13395	,13400	,13410	,13411	,13412	,13413	,13414	,13415	,13416	,13417	,13418	,13420	,13421	,13422	,13423	,13424	,13425	,13426	,13427	,13490	,13491	,13492	,13493	,13494	,13495	,13496	,13600	,13601	,13602	,13603	,13604	,13605	,13606	,13607	,13608	,13609	,13610	,14000	,14100	,

    14110	,14200	,14210	,14212	,14213	,14214	,14215	,14220	,14221	,14222	,14223	,14224	,14225	,14226	,14227	,14229	,14300	,14310	,14311	,14312	,14320	,14330	,14331	,14360	,14370	,14380	,14390	,14391	,14392	,14393	,14394	,14395	,14400	,14410	,14411	,14412	,14413	,14420	,14421	,14422	,14423	,14430	,14431	,14432	,14433	,14434	,14435	,14440	,14441	,14442	,

    14450	,14451	,14490	,14491	,14492	,14493	,14494	,15000	,15100	,15110	,15200	,15210	,15211	,15212	,15213	,15214	,15215	,15220	,15221	,15222	,15223	,15224	,15225	,15226	,15227	,15229	,15300	,15310	,15311	,15312	,15313	,15320	,15330	,15331	,15332	,15370	,15380	,15390	,15391	,15392	,15393	,15394	,15395	,15400	,15410	,15411	,15412	,15413	,15414	,15422	,

    15423	,15424	,15425	,15426	,15427	,15428	,15430	,15431	,15432	,15433	,15434	,15441	,15442	,15443	,15444	,15450	,15451	,15452	,15453	,15454	,15490	,15491	,15492	,15493	,15494	,16415	,16416	,16420	,16421	,16431	,16432	,16451	,16460	,16461	,16462	,16463	,16464	,16465	,16466	,16467	,16468	,17100	,17110	,17200	,17210	,17211	,17212	,17213	,17214	,17215	,

    17220	,17221	,17222	,17223	,17224	,17225	,17226	,17227	,17229	,17300	,17310	,17311	,17312	,17313	,17320	,17330	,17331	,17332	,17333	,17334	,17340	,17360	,17370	,17380	,17390	,17391	,17393	,17394	,17395	,17400	,17410	,17411	,17412	,17413	,17414	,17415	,17416	,17417	,17418	,17420	,17421	,17422	,17490	,17491	,17500	,17501	,17502	,17503	,17504	,17505	,

    17506	,17507	,17508	,17509	,17510	,18100	,18110	,18200	,18210	,18211	,18212	,18213	,18214	,18220	,18221	,18222	,18223	,18224	,18225	,18226	,18227	,18300	,18310	,18311	,18312	,18313	,18320	,18330	,18331	,18340	,18350	,18360	,18361	,18362	,18363	,18364	,18365	,18400	,18410	,18411	,18412	,18413	,18414	,18415	,18420	,18421	,18422	,18423	,18425	,18430	,

    18431	,18433	,18434	,18435	,18436	,18440	,18441	,18442	,18443	,18444	,18445	,18446	,18450	,18451	,18452	,18453	,18454	,18999	,19130	,19210	,19220	,19310	,19320	,19330	,19350	,19400	,19410	,19420	,19430	,19440	,19500	,19510	,19520	,19530	,19630	,20260	,21110	,21310	,22411	,50110	,50111	,50112	,50113	,50212	,50213	,50220	,50225	,50312	,50313	,50314	,
           
    50330	,50343	,50440	,50443	,50445	,50446	,50554	,50556	,50557	,50658	,50660	,50661	,50662	,50663	,50665	,50667	,11120	,11130	,11200	,11300	,11340	,11400	,11420	,11430	,11440	,11450	,11800	,11810	,11900	,11999	,12120	,12335	,12900	,12999	,13120	,13313	,13699	,13900	,13999	,14120	,14313	,14900	,14999	,15120	,15340	,15350	,15420	,15440	,15900	,15999	,

    16000	,16100	,16110	,16120	,16200	,16210	,16211	,16212	,16213	,16214	,16215	,16220	,16221	,16222	,16223	,16224	,16225	,16226	,16227	,16229	,16300	,16310	,16311	,16312	,16313	,16320	,16330	,16331	,16370	,16380	,16390	,16391	,16392	,16393	,16394	,16395	,16400	,16410	,16411	,16413	,16414	,16430	,16433	,16434	,16440	,16441	,16442	,16443	,16444	,16450	,

    16452	,16453	,16490	,16491	,16492	,16493	,16494	,16900	,16999	,17000	,17120	,17335	,17900	,17999	,18000	,18120	,18215	,18424	,18432	,18900	,19000	,19100	,19110	,19120	,19200	,19230	,19300	,19340	,19600	,19610	,19620	,19640	,19800	,19810	,19900	,19999	,20000	,20100	,20110	,20120	,20130	,20200	,20210	,20220	,20230	,20240	,20250	,20800	,20820	,20900	,

    20999	,21000	,21100	,21120	,21130	,21200	,21210	,21220	,21230	,21240	,21250	,21260	,21270	,21280	,21300	,21320	,21330	,21340	,21350	,21360	,21370	,21380	,21390	,21800	,21810	,21900	,21999	,22000	,22100	,22110	,22300	,22310	,22400	,22410	,22412	,22413	,22420	,22421	,22422	,22423	,22430	,22440	,22450	,22460	,22900	,22999	,50000	,50100	,50115	,50116	, 
             
    50200	,50214	,50215	,50216	,50300	,50315	,50316	,50370	,50400	,50412	,50413	,50414	,50415	,50416	,50441	,50442	,50444	,50465	,50470	,50500	,50512	,50513	,50514	,50515	,50516	,50541	,50542	,50545	,50550	,50551	,50552	,50553	,50555	,50558	,50565	,50570	,50600	,50612	,50613	,50614	,50615	,50616	,50641	,50642	,50653	,50657	,50664	,50666	,50670	,50700	,50712	,50713	,50714	,50716	,50765	,50770	,50771};
   
    
    }
}
