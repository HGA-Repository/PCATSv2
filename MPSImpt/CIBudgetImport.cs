using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.Data;

using RSMPS;

using Microsoft.Office.Interop;


namespace MPSImpt
{
    public delegate void ProgressHandler(int curr, int max, string status);
    public delegate void ImportErrorHandler(string errVal);

    public class CIBudgetImport
    {
        public event ProgressHandler OnProgress;
        public event ImportErrorHandler OnError;

        private const int ALPHASTART = 65;
        private const int ALPHAEND = 90;

        public bool ImportExcelBudget(int projID, string fileLoc)
        {
            bool success;

            CBBudgetImp.ClearBudgetImp();

            success = UploadExcelData(projID, fileLoc);

            if (success == true)
                success = ProcessExcelData();

            if (success == true)
                CBBudgetImp.ApplyBudgetImport();

            return success;
        }

        private bool UploadExcelData(int projID, string fileLoc)
        {
            bool success;
            int indx;

            Microsoft.Office.Interop.Excel.Application eApp;
            //Excel.Application eApp;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Range range;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            int COLUMN_E = 1;
            int COLUMN_F = 2;
            int COLUMN_G = 3;
            int COLUMN_H = 4;
            int COLUMN_I = 5;

            string codes;
            string desc;
            string qty;
            string uom;
            string hours;

            success = false;
            indx = 0;

            eApp = new Microsoft.Office.Interop.Excel.ApplicationClass();

            eApp.Visible = false;
            eApp.DisplayAlerts = false;
            eApp.ScreenUpdating = false;

#if DEBUG
            workbook = eApp.Workbooks.Open(fileLoc, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
#else
            workbook = eApp.Workbooks.Open(fileLoc, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
#endif

            try
            {
                //worksheet = (Excel.Worksheet)workbook.Sheets[5];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Job Stat Data"];
                range = worksheet.get_Range("E15", "I1500");

                object[,] values = (object[,])range.Value2;
                for (int i = 1; i <= values.GetLength(0); i++)
                {

                    if (values[i, 1] != null)
                    {
                        codes = values[i, COLUMN_E].ToString();
                        if (codes == "Z")
                            break;
                        else if (codes.Substring(0, 1) == "E")
                            continue;

                        desc = values[i, COLUMN_F].ToString();
                        qty = values[i, COLUMN_G].ToString();
                        uom = values[i, COLUMN_H].ToString();
                        hours = values[i, COLUMN_I].ToString();

                        CBBudgetImp.SaveNewBudget(projID, codes, desc, qty, uom, hours);

                        indx++;
                        if (OnProgress != null)
                            OnProgress(indx, 1000, "Processing Excel file");
                    }
                    else
                    {
                        break;
                    }
                }

                success = true;
            }
            catch (Exception exc)
            {
                if (OnError != null)
                    OnError("(Excel upload) -" + indx.ToString() + "- " + exc.Message);

                success = false;
            }
            finally
            {
                range = null;
                worksheet = null;
                //if (workbook != null)
                workbook.Close(false, Missing.Value, Missing.Value);
                workbook = null;
                //if (eApp != null)
                eApp.Quit();
                eApp = null;
            }

            if (OnProgress != null)
                OnProgress(0, 100, "Excel file processed");

            return success;
        }

        private bool ProcessExcelData()
        {
            DataSet dsBudImp;
            int indx, maxBud;
            bool success;

            // tmp variables
            int projectID, departmentID;
            int acctCodeID;
            string code;
            decimal quantity;
            string description;
            string uom;
            decimal hours;
            int codeCnt;
            string drwgCode;
            string lastCode;
            int currAlpha;
            int currIndx;

            CBBudgetImp.UpdateActivityCodes();
            dsBudImp = CBBudgetImp.GetBudgetImportData();

            indx = 0;
            maxBud = dsBudImp.Tables[0].Rows.Count;
            currAlpha = ALPHASTART;
            lastCode = "";

            try
            {
                foreach (DataRow dr in dsBudImp.Tables[0].Rows)
                {
                    projectID = Convert.ToInt32(dr["ProjectID"]);
                    departmentID = Convert.ToInt32(dr["DepartmentID"]);
                    acctCodeID = Convert.ToInt32(dr["CodeID"]);
                    code = dr["Code"].ToString();
                    quantity = Convert.ToDecimal(dr["Qty"]);
                    description = dr["Description"].ToString();
                    uom = dr["UOM"].ToString();
                    hours = Convert.ToDecimal(dr["Hours"]);
                    codeCnt = Convert.ToInt32(dr["CodeCnt"]);

                    if (lastCode != code)
                        currAlpha = ALPHASTART;

                    if (quantity > 1)
                    {
                        for (int i = 1; i <= quantity; i++)
                        {
                            if (codeCnt > 1)
                            {
                                drwgCode = code + Convert.ToChar(currAlpha) + "-" + i.ToString();
                            }
                            else
                            {
                                drwgCode = code + "-" + i.ToString();
                            }

                            SaveToLog(projectID, departmentID, acctCodeID, drwgCode, 1, description, uom, hours);
                        }
                    }
                    else
                    {
                        if (codeCnt > 1)
                        {
                            drwgCode = code + Convert.ToChar(currAlpha) + "-1";
                        }
                        else
                        {
                            drwgCode = code + "-1";
                        }

                        SaveToLog(projectID, departmentID, acctCodeID, drwgCode, 1, description, uom, hours);
                    }

                    indx++;

                    if (OnProgress != null)
                        OnProgress(indx, maxBud, "Processing budget data");

                    currAlpha++;
                    lastCode = code;
                }

                success = true;
            }
            catch (Exception exc)
            {
                if (OnError != null)
                    OnError("(Data process) " + exc.Message);

                success = false;
            }

            return success;
        }

        private void SaveToLog(int projectID, int departmentID, int acctCodeID, string drwgCode, decimal quantity, string description, string uom, decimal hours)
        {
            CBDrawingLog dl = new CBDrawingLog();

            dl.Clear();

            dl.DepartmentID = departmentID;
            dl.ProjectID = projectID;
            dl.HGANumber = drwgCode;
            dl.ActCodeID = acctCodeID;
            if (uom == "TASK")
                dl.IsTask = true;
            else
                dl.IsTask = false;
            dl.BudgetHrs = quantity * hours;
            dl.EarnedHrs = 0;
            dl.RemainingHrs = quantity * hours;
            dl.PercentComplete = 0;
            dl.Title1 = description;
            dl.Title1IsDesc = true;
            dl.Title1IsTitle = true;

            dl.SaveNewImport();
        }
    }
}
