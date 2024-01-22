using Dapper;
using Microsoft.Reporting.WebForms;
using Serenity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using VistaGL.Modules.Reports;

namespace VistaGL.Views.Shared
{
    public partial class ReportsViewer : ViewUserControl
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public ReportsViewer()
        {
            //string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            //con = new SqlConnection(constr);
        }
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    GetDate();
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //
        }

        //private void GetDate()
        //{
        //    if (Session["dt"] != null)
        //    {
        //        var model = TempData["model"] as ReportSearchViewModel;
        //        ReportViewer1.Reset();
        //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(Session["rpath"].ToString());
        //        ReportViewer1.LocalReport.Refresh();
        //        ReportViewer1.LocalReport.DataSources.Clear();

        //        #region report Title

        //        ReportParameter p10 = new ReportParameter("pZoneName", model.pZoneName);
        //        ReportParameter p11 = new ReportParameter("pEntityName", model.pEntityName);

        //        string pReportPeriod = "";
        //        CultureInfo ci = new CultureInfo("en-US");
        //        if (model.FromDate != null)
        //            pReportPeriod = model.FromDate.Value.ToString("dd-MMM-yyyy", ci);

        //        if (model.FromDate != null && model.ToDate != null)
        //            pReportPeriod = model.FromDate.Value.ToString("dd-MMM-yyyy", ci) + " to " +
        //                            model.ToDate.Value.ToString("dd-MMM-yyyy", ci);

        //        ReportParameter p12 = new ReportParameter("pReportPeriod", pReportPeriod);

        //        ReportParameter p13 = new ReportParameter("pAccountHead", model.pAccountHead);
        //        ReportParameter p14 = new ReportParameter("pAccountCode", model.pAccountCode);
        //        ReportParameter p15 = new ReportParameter("pBankAccountNo", model.pBankAccountNo);
        //        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p10, p11, p12, p13, p14, p15 });

        //        #endregion

        //        var dt = Session["dt"];

        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@ZoneId", ((UserDefinition)Authorization.UserDefinition).ZoneID);
        //        con.Open();
        //        var data = con.Query<ZoneInfoViewModel>("SP_PRM_GetReportHeaderByZoneID", param, commandType: CommandType.StoredProcedure).ToList();
        //        con.Close();

        //        ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
        //        ReportDataSource rdc1 = new ReportDataSource("ZoneInfo", data);

        //        ReportViewer1.LocalReport.DataSources.Add(rdc);
        //        ReportViewer1.LocalReport.DataSources.Add(rdc1);

        //        //this.ReportViewer1.LocalReport.SubreportProcessing +=
        //        //    new SubreportProcessingEventHandler(localReport_SubreportProcessing);
        //        ReportViewer1.DataBind();


        //        //ExportToPDF
        //        String fileName = "ACCReport_" + Guid.NewGuid() + ".pdf";
        //        ExportToPDFUtil.ExportToPDF(ReportViewer1, fileName);
        //    }
        //}

    }

}