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
using MFiles.Mfws.Structs;

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


            if (proj.BusinessUnit() == 1) rprt.MainReportTitle = "Staffing Estimate Loaded Details";
            if (proj.BusinessUnit() == 2) rprt.MainReportTitle = "Engineering Estimate Loaded Details";
            if (proj.BusinessUnit() == 3) rprt.MainReportTitle = "Pipeline Services Estimate Loaded Details";
            if (proj.BusinessUnit() == 4) rprt.MainReportTitle = "Program Management Estimate Loaded Details";
            if (proj.BusinessUnit() == 5) rprt.MainReportTitle = "EPC Estimate Loaded Details";

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void SavePDF_BudgetDetails(int budID, string wbs)    //**************************Added 6/22/15
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

                                    //try
                                    //{
                                    //    // Export the Report to Response stream in PDF format and file name Customers

                                    //    pv.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "ABC");
                                    //    // There are other format options available such as Word, Excel, CVS, and HTML in the ExportFormatType Enum given by crystal reports
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine(ex.Message);
                                    //    ex = null;
                                    //}

            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport PDFEx = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();
            //*********************************
                    //rptDataDynamics rpt = new rptDataDynamics();
                    //DataDynamics.ActiveReports.Export.Pdf.PdfExport p = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
            PDFEx.Options.Application = "Mortimer's Reporting Software";
            PDFEx.Options.Author = "Mortimer";
            PDFEx.Options.CenterWindow = true;
                    //PDFEx.Options.DisplayMode = GrapeCity.ActiveReports.Export.Pdf.DisplayMode.Thumbs;

            PDFEx.Options.DisplayTitle = true;
            PDFEx.Options.FitWindow = true;
                    //PDFEx.HideMenubar = true;
            PDFEx.Options.HideToolbar = true;
            PDFEx.Options.HideWindowUI = true;
            PDFEx.Options.Keywords = "annual, report, 2003";
            PDFEx.Options.Subject = "Sales report for 2003";
            PDFEx.Options.Title = "Annual Report";
            rprt.Run();
                    //this.arv.Document = rprt.Document;
           // PDFEx.Export(rprt.Document, Application.StartupPath + "\\p.pdf");
            
          // PDFEx.Export(rprt.Document,  "C:\\Users\\mzaman\\Documents\\GitHub\\PCATSv2\\PCATSv2\\MPS\\bin\\Debug\\4.pdf");
           SaveFileDialog sv1 = new SaveFileDialog();
           sv1.Filter = "PDF Files | *.pdf";
           sv1.DefaultExt = "pdf";


                                    if (sv1.ShowDialog() == DialogResult.OK)
                                    {
                                    //    ee.ExportBudgetForPrimavera(saveFileDialog1.FileName, moPCN.ID);
                                        PDFEx.Export(rprt.Document, sv1.FileName);


                                    }



            //pv.Export(PDFEx, new System.IO.FileInfo(Application.StartupPath + "\\outputPDF.pdf"));
            //rprt.Export(PDFEx, new System.IO.FileInfo("\\outputPDF.pdf"));
            //GrapeCity.ActiveReports.Export.Pdf.PdfExport p = new GrapeCity.ActiveReports.Export.Pdf.PdfExport();

                                    MFilesAPI.PropertyValues oPropVals = new MFilesAPI.PropertyValues();
                                    MFilesAPI.PropertyValue oPropVal = new MFilesAPI.PropertyValue();

                                   MFilesAPI.SourceObjectFiles ofiles = new MFilesAPI.SourceObjectFiles();
                                    MFilesAPI.SourceObjectFile ofile = new MFilesAPI.SourceObjectFile();

                                    ofile.SourceFilePath = sv1.FileName;

                                   // ofile.Extension = Path.GetExtension(sv1.FileName).Substring(1); // don't forget to sub the <dot>
                                    //ofile.Title = Path.GetFileNameWithoutExtension(FilePath);
                                    ofiles.Add(-1, ofile);
                                   


        }



        public void SaveMFile_BudgetDetails(int budID, string wbs)    //**************************Added 6/22/15
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
            //*********************************
          
                                //PDFEx.Options.Application = "Mortimer's Reporting Software";
                                //PDFEx.Options.Author = "Mortimer";
                                //PDFEx.Options.CenterWindow = true;
                                ////PDFEx.Options.DisplayMode = GrapeCity.ActiveReports.Export.Pdf.DisplayMode.Thumbs;

                                //PDFEx.Options.DisplayTitle = true;
                                //PDFEx.Options.FitWindow = true;
                                ////PDFEx.HideMenubar = true;
                                //PDFEx.Options.HideToolbar = true;
                                //PDFEx.Options.HideWindowUI = true;
                                //PDFEx.Options.Keywords = "annual, report, 2003";
                                //PDFEx.Options.Subject = "Sales report for 2003";
                                //PDFEx.Options.Title = "Annual Report";
            
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
