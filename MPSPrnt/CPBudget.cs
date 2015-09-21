using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using System.Windows.Forms;
using System.Data;
using System.Drawing;


using System.Threading;
using Common.Extentions;
using System.Linq;
using System.Resources;
using System.Reflection;


//using DataDynamics.ActiveReports.Interop;
//using DataDynamics.ActiveReports;
using GrapeCity.ActiveReports;
 //using DataDynamics.ActiveReports.Export.Pdf.PdfDocumentOptions
using DataDynamics.ActiveReports;

using System.Net;
using System.Runtime.Serialization.Json;
//using MFiles.Mfws.Structs;

namespace RSMPS
{
    public class CPBudget
    {
        public void PreviewBudgetSummary(int budID, string wbs)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtBudgetSummary1 rprt = new rprtBudgetSummary1();
            DataSet ds;


            int totalHours;
            decimal totalHourDollars;
            decimal totalExpenses;
            decimal contingency;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            totalHours = CBBudget.GetTotalBudgetHours(budID, wbs);
            totalHourDollars = CBBudget.GetTotalBudgetHourDollars(budID, wbs);
            totalExpenses = CBBudget.GetTotalBudgetExpenses(budID);
            contingency = CBBudget.GetContingencyForBudget(budID);

            ds = CBBudget.GetBudgetSummaryForReport(budID, wbs);
            if (proj.BusinessUnit() == 1) rprt.MainReportTitle = "Staffing Estimate Loaded Summary";
            if (proj.BusinessUnit() == 2)  rprt.MainReportTitle = "Engineering Estimate Loaded Summary";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Loaded Summary";
            if (proj.BusinessUnit() == 4) rprt.MainReportTitle = "Program Management Estimate Loaded Summary";
           if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Loaded Summary";
                
                   
            

            rprt.SetTitles(proj.Number, proj.Description, bud.GetNumber(), cust.Name, loc.City + "," + state.Abbrev, wbs);
            rprt.TotalHours = totalHours;
            rprt.TotalHourDollars = totalHourDollars;
            rprt.TotalExpenses = totalExpenses;
            rprt.Contingency = contingency;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
           
            
            pv.projNumber = proj.Number; // **************************Added 6/29/2015 **************************
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PreviewBudgetSummary(int budID, string wbs,bool rate) //***********************Added 7/22/2015
        {
            FPreviewAR pv = new FPreviewAR();
            rprtBudgetSummary1 rprt = new rprtBudgetSummary1();
            DataSet ds;


            int totalHours;
            decimal totalHourDollars;
            decimal totalExpenses;
            decimal contingency;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            totalHours = CBBudget.GetTotalBudgetHours(budID, wbs);
            totalHourDollars = CBBudget.GetTotalBudgetHourDollars(budID, wbs);
            totalExpenses = CBBudget.GetTotalBudgetExpenses(budID);
            contingency = CBBudget.GetContingencyForBudget(budID);

            ds = CBBudget.GetBudgetSummaryForReport(budID, wbs);
            //ds = CBBudget.GetBudgetSummaryForReport(budID, wbs);
            if (proj.BusinessUnit() == 1) rprt.MainReportTitle = "Staffing Estimate Loaded Summary";
            if (proj.BusinessUnit() == 2) rprt.MainReportTitle = "Engineering Estimate Loaded Summary";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Loaded Summary";
            if (proj.BusinessUnit() == 4) rprt.MainReportTitle = "Program Management Estimate Loaded Summary";
            if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Loaded Summary";




            rprt.SetTitles(proj.Number, proj.Description, bud.GetNumber(), cust.Name, loc.City + "," + state.Abbrev, wbs);
            rprt.TotalHours = totalHours;
            rprt.TotalHourDollars = totalHourDollars;
            rprt.TotalExpenses = totalExpenses;
            rprt.Contingency = contingency;
            rprt.Rate = rate;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";


            pv.projNumber = proj.Number; // **************************Added 6/29/2015 **************************
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PreviewGetTravelExpenseReport(int budID, string wbs, bool rate) //***********************Added 7/22/2015 //*******************************I have to work on it
        {
            FPreviewAR pv = new FPreviewAR();
            //rprtBudgetSummary1 rprt = new rprtBudgetSummary1();

            rprtTravelExpenseDetail rprt = new rprtTravelExpenseDetail();
            DataSet ds;


            //int totalHours;
            //decimal totalHourDollars;
            //decimal totalExpenses;
            //decimal contingency;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            //totalHours = CBBudget.GetTotalBudgetHours(budID, wbs);
            //totalHourDollars = CBBudget.GetTotalBudgetHourDollars(budID, wbs);
            //totalExpenses = CBBudget.GetTotalBudgetExpenses(budID);
            //contingency = CBBudget.GetContingencyForBudget(budID);

            ds = CBBudget.GetTravelExpenseReport(budID);
           // ds = CBBudget.GetBudgetDetailsForReport(budID, wbs);

            if (proj.BusinessUnit() == 1) rprt.MainReportTitle = "Staffing Estimate Travel Expense Report";
            if (proj.BusinessUnit() == 2) rprt.MainReportTitle = "Engineering Estimate Travel Expense Report";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Travel Expense Report";
            if (proj.BusinessUnit() == 4) rprt.MainReportTitle = "Program Management Estimate Travel Expense Report";
            if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Travel Expense Report";

            rprt.SetTitles(proj.Number, proj.Description, bud.GetNumber(), cust.Name, loc.City + "," + state.Abbrev, wbs);
            //rprt.TotalHours = totalHours;
            //rprt.TotalHourDollars = totalHourDollars;
            //rprt.TotalExpenses = totalExpenses;
           // rprt.Contingency = contingency;
           // rprt.Rate = rate;
           
            rprt.DataSource = ds;
            rprt.DataMember = "Table";


            pv.projNumber = proj.Number; // **************************Added 6/29/2015 **************************
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }





        public void PreviewBudgetDetails(int budID, string wbs)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtBudgetDetail rprt = new rprtBudgetDetail();
            DataSet ds;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            ds = CBBudget.GetBudgetDetailsForReport(budID, wbs);


            if (proj.BusinessUnit() == 1)  rprt.MainReportTitle = "Staffing Estimate Loaded Details";
            if (proj.BusinessUnit() == 2) rprt.MainReportTitle = "Engineering Estimate Loaded Details";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Loaded Details";
            if (proj.BusinessUnit() == 4)  rprt.MainReportTitle = "Program Management Estimate Loaded Details";
            if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Loaded Details";


            pv.projNumber = proj.Number; //***************************Added 6/25/15
            
            // MessageBox.Show(pv.projNumber);

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        

       

        















       

        public void Show_BudgetDetails(int budID, string wbs)    //**************************Added 6/22/15
        {
            FPreviewAR pv = new FPreviewAR();
            rprtBudgetDetail rprt = new rprtBudgetDetail();
            DataSet ds;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            ds = CBBudget.GetBudgetDetailsForReport(budID, wbs);


            if (proj.BusinessUnit() == 1) rprt.MainReportTitle = "Staffing Estimate Loaded Details";
            if (proj.BusinessUnit() == 2) rprt.MainReportTitle = "Engineering Estimate Loaded Details";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Loaded Details";
            if (proj.BusinessUnit() == 4) rprt.MainReportTitle = "Program Management Estimate Loaded Details";
            if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Loaded Details";

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            //pv.ViewReport(rprt);
            //pv.ShowDialog();



            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport PDFEx = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();
            

            rprt.Run();

            SaveFileDialog sv1 = new SaveFileDialog();
            sv1.Filter = "PDF Files | *.pdf";
            sv1.DefaultExt = "pdf";

            //PDFEx.FileFormat = GrapeCity.ActiveReports.Export.Pdf.Section.FileFormat.Xlsx;


            if (sv1.ShowDialog() == DialogResult.OK)
            {
                //    ee.ExportBudgetForPrimavera(saveFileDialog1.FileName, moPCN.ID);
                PDFEx.Export(rprt.Document, sv1.FileName);


            }



        }
















        public void PreviewJobStat(int budID, string wbs)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtBudgetJobStat2 rprt = new rprtBudgetJobStat2();
            DataSet ds;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            ds = CBBudget.GetBudgetJobstatForReport(budID, wbs);

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            pv.projNumber = proj.Number; //**************************** added 6/27/2015 //****Commented on 6/29

            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PreviewBudgetFormEntry(int budID, string wbs)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtBudgetAccounting rprt = new rprtBudgetAccounting();
            DataSet ds;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            ds = CBBudget.GetBudgetAccountingEntryForReport(budID, wbs);

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            pv.projNumber = proj.Number; //*************************Added 6/29/15
      
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PreviewPCN(int pcnID)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtPCNMain rprt = new rprtPCNMain();
            DataSet ds;
            CBBudgetPCN pcn = new CBBudgetPCN();

            ds = CBBudgetPCN.GetBudgetPCNInfoForReport(pcnID);
            pcn.Load(pcnID);

            rprt.SetInformation(pcn);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            //rprt.Run();
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PreviewPCN_New(string projNumber, string pcnNumber, int pcnID) //******************************Added 6/25/15
        {
            FPreviewAR pv = new FPreviewAR();
            rprtPCNMain rprt = new rprtPCNMain();
            DataSet ds;
            CBBudgetPCN pcn = new CBBudgetPCN();

            ds = CBBudgetPCN.GetBudgetPCNInfoForReport(pcnID);
            pcn.Load(pcnID);

            rprt.SetInformation(pcn);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            //rprt.Run();
            pv.projNumber = projNumber;
            pv.pcnNumber = pcnNumber;

           // MessageBox.Show(pv.projNumber);


            pv.ViewReport(rprt);
            pv.ShowDialog();
        }



        


        public void PreviewPCI(int pciID)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtPCIInformation rprt = new rprtPCIInformation();
            CBPCIInfo info = new CBPCIInfo();

           
            info.Load(pciID);

            rprt.SetInformation(info);

            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PreviewPCI_New(string projNumber, int pciID) // *************************** Added 6/25/15
        {
            FPreviewAR pv = new FPreviewAR();
            rprtPCIInformation rprt = new rprtPCIInformation();
            CBPCIInfo info = new CBPCIInfo();

            //CBBudget bud = new CBBudget();
            //CBProject proj = new CBProject();
            //bud.Load(budID);
            //proj.Load(bud.ProjectID);


            info.Load(pciID);

            rprt.SetInformation(info);

            pv.projNumber = projNumber;

           // MessageBox.Show(pv.projNumber);

            pv.ViewReport(rprt);
            pv.ShowDialog();
        }










        public void PreviewAllBudget(int budID, string wbs)
        {
            FPreviewAR pv = new FPreviewAR();
            GrapeCity.ActiveReports.SectionReport rprtMain = new GrapeCity.ActiveReports.SectionReport();

            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesBudSum;
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesBudDtl;
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesJobStat;
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesBudEntry;

            pagesBudSum = CreatePagesBudgetSummary(budID, wbs);

            for (int i = 0; i < pagesBudSum.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesBudSum[i]);
            }

            pagesBudDtl = CreatePagesBudgetDetails(budID, wbs);

            for (int i = 0; i < pagesBudDtl.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesBudDtl[i]);
            }

            pagesJobStat = CreatePagesJobStat(budID, wbs);

            for (int i = 0; i < pagesJobStat.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesJobStat[i]);
            }

            pagesBudEntry = CreatePagesBudgetFormEntry(budID, wbs);

            for (int i = 0; i < pagesBudEntry.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesBudEntry[i]);
            }

            pv.ViewReportNoRun(rprtMain);
            pv.ShowDialog();
        }
        public void PreviewAllBudget_New(int budID, string projNumber,string wbs) //*********************************Added 6/29
        {
            FPreviewAR pv = new FPreviewAR();
            GrapeCity.ActiveReports.SectionReport rprtMain = new GrapeCity.ActiveReports.SectionReport();

            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesBudSum;
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesBudDtl;
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesJobStat;
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesBudEntry;

            pagesBudSum = CreatePagesBudgetSummary(budID, wbs);

            for (int i = 0; i < pagesBudSum.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesBudSum[i]);
            }

            pagesBudDtl = CreatePagesBudgetDetails(budID, wbs);

            for (int i = 0; i < pagesBudDtl.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesBudDtl[i]);
            }

            pagesJobStat = CreatePagesJobStat(budID, wbs);

            for (int i = 0; i < pagesJobStat.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesJobStat[i]);
            }

            pagesBudEntry = CreatePagesBudgetFormEntry(budID, wbs);

            for (int i = 0; i < pagesBudEntry.Count; i++)
            {
                rprtMain.Document.Pages.Add(pagesBudEntry[i]);
            }

            pv.projNumber = projNumber; //************************Added 6/29
            pv.ViewReportNoRun(rprtMain);
            pv.ShowDialog();
        }








        private GrapeCity.ActiveReports.Document.Section.PagesCollection CreatePagesBudgetSummary(int budID, string wbs)
        {
            rprtBudgetSummary1 rprt = new rprtBudgetSummary1();
            DataSet ds;

            int totalHours;
            decimal totalHourDollars;
            decimal totalExpenses;
            decimal contingency;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            totalHours = CBBudget.GetTotalBudgetHours(budID, wbs);
            totalHourDollars = CBBudget.GetTotalBudgetHourDollars(budID, wbs);
            totalExpenses = CBBudget.GetTotalBudgetExpenses(budID);
            contingency = CBBudget.GetContingencyForBudget(budID);
            ds = CBBudget.GetBudgetSummaryForReport(budID, wbs);


            if (proj.BusinessUnit() == 1) rprt.MainReportTitle = "Staffing Estimate Loaded Summary";
            if (proj.BusinessUnit() == 2) rprt.MainReportTitle = "Engineering Estimate Loaded Summary";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Loaded Summary";
            if (proj.BusinessUnit() == 4) rprt.MainReportTitle = "Program Management Estimate Loaded Summary";
            if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Loaded Summary";

            rprt.SetTitles(proj.Number, proj.Description, bud.GetNumber(), cust.Name, loc.City + "," + state.Abbrev, wbs);
            rprt.TotalHours = totalHours;
            rprt.TotalHourDollars = totalHourDollars;
            rprt.TotalExpenses = totalExpenses;
            rprt.Contingency = contingency;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            rprt.Run(false);

            return rprt.Document.Pages;
        }

        private GrapeCity.ActiveReports.Document.Section.PagesCollection CreatePagesBudgetDetails(int budID, string wbs)
        {
            rprtBudgetDetail rprt = new rprtBudgetDetail();
            DataSet ds;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            ds = CBBudget.GetBudgetDetailsForReport(budID, wbs);


            if (proj.BusinessUnit() == 1) rprt.MainReportTitle = "Staffing Estimate Loaded Details";
            if (proj.BusinessUnit() == 2) rprt.MainReportTitle = "Engineering Estimate Loaded Details";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Loaded Details";
            if (proj.BusinessUnit() == 4) rprt.MainReportTitle = "Program Management Estimate Loaded Details";
            if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Loaded Details";

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            rprt.Run(false);

            return rprt.Document.Pages;
        }

        private GrapeCity.ActiveReports.Document.Section.PagesCollection CreatePagesJobStat(int budID, string wbs)
        {
            rprtBudgetJobStat2 rprt = new rprtBudgetJobStat2();
            DataSet ds;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            ds = CBBudget.GetBudgetJobstatForReport(budID, wbs);

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            rprt.Run(false);

            return rprt.Document.Pages;
        }

        private GrapeCity.ActiveReports.Document.Section.PagesCollection CreatePagesBudgetFormEntry(int budID, string wbs)
        {
            rprtBudgetAccounting rprt = new rprtBudgetAccounting();
            DataSet ds;
            CBBudget bud = new CBBudget();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();
            CBState state = new CBState();

            bud.Load(budID);
            proj.Load(bud.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);
            state.Load(loc.StateID);

            ds = CBBudget.GetBudgetAccountingEntryForReport(budID, wbs);

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            rprt.Run(false);

            return rprt.Document.Pages;
        }

        public void PreviewPCILog(string client, string project, string hgaNum, string clientNum, string pm, DataSet pciLog)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtPCILog rprt = new rprtPCILog();

            rprt.SetHeaderInfo(client, project, hgaNum, clientNum, pm);
            rprt.DataSource = pciLog;
            rprt.DataMember = "Table";

            pv.projNumber = hgaNum; // ******************* Added 6/29/15**************
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }


        




        public void PreviewPCNLog(string client, string project, string hgaNum, string clientNum, string pm, DataSet pcnLog)
        {
            FPreviewAR pv = new FPreviewAR();
            rprtPCNLog rprt = new rprtPCNLog();

            rprt.SetHeaderInfo(client, project, hgaNum, clientNum, pm);
            rprt.DataSource = pcnLog;
            rprt.DataMember = "Table";

            pv.projNumber = hgaNum; //******************************Added 6/29/15
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

       




        public static int GetRprtCase(string proj)
        {
            int caseVal = 0;
            try
            {
                if (proj.Substring(0, 2) == "8.")
                {
                    caseVal = 1;
                }
                else if (proj.Substring(0, 3) == "P.8")
                {
                    caseVal = 1;
                }
                else
                {
                    caseVal = 0;
                }
            }
            catch { }//**************** try/catch added 6/1

            CBProject p = new CBProject();
            p.Load(proj);

            if (p.UseAllGroups() == true)
                caseVal = 0;

            return caseVal;
        }
    }
}
