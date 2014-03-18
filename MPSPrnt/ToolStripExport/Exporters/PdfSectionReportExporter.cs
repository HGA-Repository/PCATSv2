using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Export;


namespace RSMPS
{
	public class PdfSectionReportExporter : SectionReportExporter
	{
		private const string TypeName = "GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport";
		private const string AssemblyName = "GrapeCity.ActiveReports.Export.Pdf.v7";

		public PdfSectionReportExporter() : base(TypeName, AssemblyName)
		{
		}

		public override void Export(SectionDocument document, string filename, NameValueCollection settings)
		{
			throw new NotImplementedException();
		}

		public override string DefaultExtension
		{
			get { return "pdf"; }
		}

		public override string FileDialogFilter
		{
			get { return "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"; }
		}
	}
}
