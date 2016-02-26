using RSMPS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GrapeCity.ActiveReports;
using DataDynamics.ActiveReports;

namespace RSMPS
{
    public partial class FPreviewAR : Form
    {
        private SectionReport rprt;

        public  string projNumber;
        public string Title;
        public string pcnNumber;
        public  string reportType;
        public int budID;

        public string wbs;
                    
        public FPreviewAR()
        {
            InitializeComponent();
                                     
        }

        public void ViewReport(SectionReport ar)
        {
           
            reportType = ar.GetType().ToString();       
            rprt = ar;
            viewer1.Document = rprt.Document;
            rprt.Run();
        }
        public void ViewReportBatch(GrapeCity.ActiveReports.SectionReport ar) 
        {

            reportType = "All PCN";
            rprt = ar;
            viewer1.Document = rprt.Document;
        }
        public void ViewReportNoRun(SectionReport ar)
        {
            reportType = ar.GetType().ToString(); 
            rprt = ar;
            viewer1.Document = rprt.Document;
        }

        public void ViewReportWithExcel(SectionReport ar)
        {
            reportType = ar.GetType().ToString(); 
            rprt = ar;
            viewer1.Document = rprt.Document;
            rprt.Run();
        }

        public void ViewDrawingLogWithExcel(SectionReport ar)
        {
            reportType = ar.GetType().ToString(); 
            rprt = ar;
            viewer1.Document = rprt.Document;
            rprt.Run();
        }
       
        private void SendForcastReportToExcel()
        {

        }
        private void SendForcastReportToExcelOld()
        {

        }

        private void SendDrawingLogToExcel()
        {

        }

        private string DateToOutput(DateTime dOut)
        {
            string retVal = "";

            if (dOut < new DateTime(2000, 1, 1))
                retVal = "";
            else
                retVal = dOut.ToShortDateString();

            return retVal;
        }
        const long pdfExportToolID = 42;
        private void FPreviewAR_Load(object sender, EventArgs e)
        {

        }

        private void c1Button1_Click(object sender, EventArgs e)       
        {
            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport PDFEx = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();

            Report_Name = CreateFileNAme();
            SaveFileDialog sv1 = new SaveFileDialog();
            sv1.InitialDirectory = "v:\\HGA\\";
          
            sv1.FileName = Report_Name;
            sv1.Filter = "PDF Files | *.pdf";
            sv1.DefaultExt = "pdf";         

            if (sv1.ShowDialog() == DialogResult.OK)
            {
                viewer1.Export(PDFEx, new System.IO.FileInfo(sv1.FileName));
            }
        }

        public string Report_Name;
        public string deptXml; public string projXml; public string xml; public string leadXml; 
        public bool isPreview; public int sortCode; public int drwgSpec;
        public string name_of_Method;
       
        private void bttExportExcel_Click(object sender, EventArgs e)
        {
            CDrawingLogExport DrEx = new CDrawingLogExport();

            SaveFileDialog sv2 = new SaveFileDialog();
            Report_Name = CreateFileNAme();
            sv2.FileName = Report_Name;
            sv2.Filter = "XLS Files | *.xls";
            sv2.DefaultExt = "xls";
          
            if (sv2.ShowDialog() == DialogResult.OK)
            {
              if(name_of_Method =="GetDrawingLogMainByDeptListProjList" )
                   DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByDeptListProjList(sv2.FileName, deptXml, projXml, sortCode, drwgSpec);

                if(name_of_Method =="GetDrawingLogMainByDeptList")
                    DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByDeptList(sv2.FileName, xml, sortCode, drwgSpec);
       
                if(name_of_Method =="GetDrawingLogMainByProjList")
                    DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByProjList(sv2.FileName, xml, sortCode, drwgSpec);
       
                if(name_of_Method =="GetDrawingLogMainByLeadList")
                    DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByLeadList(sv2.FileName, deptXml, leadXml, sortCode, drwgSpec); 
            }
        }


        public string CreateFileNAme() 
        {
            DateTime dt = DateTime.Now;
            string fileName;
            if (reportType == "RSMPS.rprtBudgetDetail")
                fileName = Title + "-" + projNumber + " " + dt.ToString("yyyMMdd hhmmss");

            else
                if (reportType == "RSMPS.rprtPCNMain")
                    fileName = "Project Change Notice-" + projNumber + Title + "-" + "-PCN No-" + pcnNumber + "-" + dt.ToString("yyyMMdd hhmmss");
                else if (reportType == "RSMPS.rprtBudgetSummary1")
                        fileName = Title + "-" + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                else if (reportType == "GrapeCity.ActiveReports.SectionReport")
                            fileName = "Proposal Budget Detail(All)- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                else if (reportType == "RSMPS.rprtBudgetJobStat2")
                                fileName = "Job Stat Data- " + " " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                else
                                if (reportType == "RSMPS.rprtBudgetAccounting")
                                    fileName = "Budget Entry- " + " " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                else
                                    if (reportType == "RSMPS.rprtPCIInformation")
                                        fileName = "Project Change Identification- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                    else
                                        if (reportType == "RSMPS.rprtJobStat1")
                                            fileName = "Job Stat- " + " " + dt.ToString("yyyMMdd hhmmss"); //******No project No, because there may be many
                                        else
                                            if (reportType == "RSMPS.rprtPCNLog")
                                                fileName = "PCN Log- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                            else
                                                if (reportType == "RSMPS.rprtPCILog")
                                                    fileName = "PCI Log- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                                else
                                                    if (reportType == "RSMPS.rprtCostSummary")
                                                        fileName = "Cost Summary- " + projNumber + "- " + dt.ToString("yyyMMdd hhmmss");
                                                    else
                                                        if (reportType == "RSMPS.rprtPMReport1")
                                                            fileName = "PM Report- " + " " + dt.ToString("yyyMMdd hhmmss");
                                                        else
                                                            if (reportType == "RSMPS.rprtJobVariance1")                                                           
                                                                fileName = Title + "-" + " " + dt.ToString("yyyMMdd hhmmss");
                                                            else
                                                                if (reportType == "RSMPS.rprtDrawingLogTranAlt2")
                                                                   fileName = Title + " " + dt.ToString("yyyMMdd hhmmss"); //******No project No, because there may be many

                                                                else
                                                                    if (reportType == "RSMPS.rprtForecastRemaining")
                                                                        fileName = Title + "--" + dt.ToString("yyyMMdd hhmmss");
                                                                    else
                                                                        if (reportType == "RSMPS.rprtTravelExpenseDetail")
                                                                            fileName = "Travel Expense(WorkSheet)- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                                                        else
                                                                            if (reportType == "RSMPS.rprtTransmittal1")
                                                                                fileName = "Transmittal- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                                                            else
                                                                                if (reportType == "RSMPS.rprtTransmittalRelease1")
                                                                                    fileName = "Issue Release- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");

                                                                                else fileName = "Report-" + dt.ToString("yyyMMdd hhmmss");
            return fileName;

        }       

    }
}


	
	