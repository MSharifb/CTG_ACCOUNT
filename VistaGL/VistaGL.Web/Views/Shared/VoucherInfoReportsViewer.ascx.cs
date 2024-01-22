using Dapper;
using Microsoft.Reporting.WebForms;
using Serenity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaGL.Modules.Reports;

namespace VistaGL.Views.Shared
{
    public partial class VoucherInfoReportsViewer : ViewUserControl
    {
        //#region Fields
        //public SqlConnection con;
        //#endregion

        //#region Ctor
        //public VoucherInfoReportsViewer()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
        //    con = new SqlConnection(constr);
        //}
        //#endregion
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        GetDate();
        //    }
        //}

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

        //        ReportParameter p10 = new ReportParameter("ChequeNo", model.Operator);
        //        ReportParameter p11 = new ReportParameter("ChequeDate", model.FromDate != null ? model.FromDate.Value.ToString("dd-MM-yyyy") : string.Empty);
        //        ReportParameter p12 = new ReportParameter("BankAccountNo", model.pBankAccountNo);
        //        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p10, p11, p12 });


        //        var dt = Session["dt"];
        //        ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
        //        ReportViewer1.LocalReport.DataSources.Add(rdc);

        //        var dt1 = Session["dt1"];
        //        ReportDataSource rdc1 = new ReportDataSource("DataSet2", dt1);
        //        ReportViewer1.LocalReport.DataSources.Add(rdc1);

        //        this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
        //        //ReportViewer1.DataBind();

        //        ////ExportToPDF
        //        //String fileName = "VoucherReport_" + Guid.NewGuid() + ".pdf";
        //        //ExportToPDFUtil.ExportToPDF(ReportViewer1, fileName);
        //    }
        //}

        //void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@ZoneId", ((UserDefinition)Authorization.UserDefinition).ZoneID);
        //    con.Open();
        //    var dsName = "ZoneInfo";
        //    var data = con.Query<ZoneInfoViewModel>("SP_PRM_GetReportHeaderByZoneID", param, commandType: CommandType.StoredProcedure).ToList();
        //    con.Close();
        //    e.DataSources.Add(new ReportDataSource(dsName, data));
        //}
    }
}