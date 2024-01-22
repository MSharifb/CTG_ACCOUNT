using Dapper;
using Microsoft.Reporting.WebForms;
using Serenity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using VistaGL.Modules.Reports;
using VistaGL.Views.Shared;

namespace VistaGL.ReportViewers
{
    public partial class myLedgerSubLedgerReportsViewer : System.Web.UI.Page
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public myLedgerSubLedgerReportsViewer()
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
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(Session["rpath"].ToString());
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.LocalReport.DataSources.Clear();

                #region report Title
                ReportParameter p1 = new ReportParameter("pZoneName", model.pZoneName);
                ReportParameter p2 = new ReportParameter("pEntityName", model.pEntityName);

                string pReportPeriod = "";
                CultureInfo ci = new CultureInfo("en-US");
                if (model.FromDate != null)
                {
                    pReportPeriod = model.FromDate.Value.ToString("dd-MMM-yy", ci);
                }

                if (model.FromDate != null && model.ToDate != null)
                {
                    pReportPeriod = model.FromDate.Value.ToString("dd-MMM-yyyy", ci) + " to " + model.ToDate.Value.ToString("dd-MMM-yyyy", ci);
                }

                if (model.CostCenterId <= 0)
                {
                    model.pCostCenter = "All Possible Details";
                }
                if(!String.IsNullOrEmpty( model.strPayTo))
                {
                    model.pCostCenter = model.strPayTo;
                }

                ReportParameter p3 = new ReportParameter("pReportPeriod", pReportPeriod);
                ReportParameter p4 = new ReportParameter("pAccountHead", model.pAccountHead);
                ReportParameter p5 = new ReportParameter("pSubLedger", model.pCostCenter);
                ReportParameter p6 = new ReportParameter("pAccFromDate", model.FromDate.Value.AddDays(-1).ToString("dd-MMM-yyyy", ci));
                ReportParameter p7 = new ReportParameter("pToDate", model.ToDate.Value.ToString("dd-MMM-yyyy", ci));
                ReportParameter p8 = new ReportParameter("pIsWithNarration", model.IsWithNarration ? "yes" : "no");
                ReportParameter p9 = new ReportParameter("pIsWithPayto", model.IsWithPayto ? "yes" : "no");
                ReportParameter p10 = new ReportParameter("pIsWithSubLedger", model.IsWithCostCenter ? "yes" : "no");
                ReportParameter p11 = new ReportParameter("pIsWithOpening", model.IsWithOpening ? "With opening balance." : "Without opening balance.");

                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });

                #endregion

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