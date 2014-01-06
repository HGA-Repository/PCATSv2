using System;
using System.Collections.Generic;
using System.Text;


using System.Data;

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

            if (proj.IsPipeline() == true)
                rprt.MainReportTitle = "Pipeline Services Estimate Loaded Summary";
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

            if (proj.IsPipeline() == true)
                rprt.MainReportTitle = "Pipeline Services Estimate Details";

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            pv.ViewReport(rprt);
            pv.ShowDialog();
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
            DataDynamics.ActiveReports.ActiveReport rprtMain = new DataDynamics.ActiveReports.ActiveReport();

            DataDynamics.ActiveReports.Document.PagesCollection pagesBudSum;
            DataDynamics.ActiveReports.Document.PagesCollection pagesBudDtl;
            DataDynamics.ActiveReports.Document.PagesCollection pagesJobStat;
            DataDynamics.ActiveReports.Document.PagesCollection pagesBudEntry;

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

        private DataDynamics.ActiveReports.Document.PagesCollection CreatePagesBudgetSummary(int budID, string wbs)
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

            if (proj.IsPipeline() == true)
                rprt.MainReportTitle = "Pipeline Services Estimate Loaded Summary";
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

        private DataDynamics.ActiveReports.Document.PagesCollection CreatePagesBudgetDetails(int budID, string wbs)
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

            if (proj.IsPipeline() == true)
                rprt.MainReportTitle = "Pipeline Services Estimate Details";

            rprt.SetTitles(cust.Name + " / " + loc.City + "," + state.Abbrev, proj.Description, proj.Number, bud.GetNumber(), wbs);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            rprt.Run(false);

            return rprt.Document.Pages;
        }

        private DataDynamics.ActiveReports.Document.PagesCollection CreatePagesJobStat(int budID, string wbs)
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

        private DataDynamics.ActiveReports.Document.PagesCollection CreatePagesBudgetFormEntry(int budID, string wbs)
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

            CBProject p = new CBProject();
            p.Load(proj);

            if (p.UseAllGroups() == true)
                caseVal = 0;

            return caseVal;
        }
    }
}
