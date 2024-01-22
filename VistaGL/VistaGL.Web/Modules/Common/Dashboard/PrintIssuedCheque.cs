using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serenity.Reporting;

namespace VistaGL.Modules.Common.Dashboard
{
    [Report("Dashboard.PrintIssuedCheque")]
    [ReportDesign(MVC.Views.Common.Dashboard.PrintIssuedCheque)]
    public class PrintIssuedCheque : IReport, ICustomizeHtmlToPdf
    {
        public int ZoneId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public object GetData()
        {
            var model = new DashboardPrintModel();

            model.Title = "Issued Cheque";

            return model;
        }

        public void Customize(IHtmlToPdfOptions options)
        {

        }
    }

}