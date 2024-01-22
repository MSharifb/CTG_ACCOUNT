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
using VistaGL.Views.Shared;

namespace VistaGL.ReportViewers
{
    public partial class myReceiptPaymentReportViewer : System.Web.UI.Page
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public myReceiptPaymentReportViewer()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetDate();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //
        }

        private void GetDate()
        {
            if (Session["dt"] != null)
            {
                var model = Session["model"] as ReportSearchViewModel;
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.EnableHyperlinks = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(Session["rpath"].ToString());
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.LocalReport.DataSources.Clear();

                if (model != null)
                {
                    #region report Title
                    ReportParameter p1 = new ReportParameter("pZoneName", model.pZoneName);
                    ReportParameter p2 = new ReportParameter("pEntityName", model.pEntityName);

                    string pFromDate = string.Empty;
                    string pFromYear = string.Empty;
                    CultureInfo ci = new CultureInfo("en-US");
                    if (model.FromDate != null)
                        pFromDate = model.FromDate.Value.ToString("dd-MMM-yyyy", ci);
                    pFromYear = model.FromDate.Value.Year.ToString();

                    string pToDate = string.Empty;
                    string pToYear = string.Empty;
                    if (model.ToDate != null)
                        pToDate = model.ToDate.Value.ToString("dd-MMM-yyyy", ci);
                    pToYear = model.ToDate.Value.Year.ToString();

                    ReportParameter p3 = new ReportParameter("pFromDate", pFromDate);
                    ReportParameter p4 = new ReportParameter("pFromYear", pFromYear);
                    ReportParameter p5 = new ReportParameter("pToDate", pToDate);
                    ReportParameter p6 = new ReportParameter("pToYear", pToYear);
                    ReportParameter p7 = new ReportParameter("pIsShowYear", model.IsAddYear.ToString());
                    ReportParameter p8 = new ReportParameter("pLevel", model.Level.ToString());
                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8 });

                    #endregion
                }

                var dt = Session["dt"];

                var param = new DynamicParameters();
                param.Add("@ZoneId", ((UserDefinition)Authorization.UserDefinition).ZoneID);
                con.Open();
                var data = con.Query<ZoneInfoViewModel>("SP_PRM_GetReportHeaderByZoneID", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();

                ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
                ReportDataSource rdc1 = new ReportDataSource("ZoneInfo", data);

                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.DataSources.Add(rdc1);

                this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
                ReportViewer1.DataBind();

                if (model.IsOpenReportInNewTab)
                {
                    //ExportToPDF
                    String fileName = "ACCReport_" + Guid.NewGuid() + ".pdf";
                    ExportToPDFUtil.ExportToPDF(ReportViewer1, fileName);
                }
            }
        }

        void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ZoneId", ((UserDefinition)Authorization.UserDefinition).ZoneID);
            con.Open();
            var dsName = "ZoneInfo";
            var data = con.Query<ZoneInfoViewModel>("SP_PRM_GetReportHeaderByZoneID", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            e.DataSources.Add(new ReportDataSource(dsName, data));
        }
    }
}