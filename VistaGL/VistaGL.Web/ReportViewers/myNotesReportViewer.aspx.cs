using Dapper;
using Microsoft.Reporting.WebForms;
using Serenity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaGL.Modules.Reports;
using VistaGL.Views.Shared;

namespace VistaGL.ReportViewers
{
    public partial class myNotesReportViewer : System.Web.UI.Page
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public myNotesReportViewer()
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

                #region report Title

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

                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";

                ReportParameter p1 = new ReportParameter("pFromDate", pFromDate);
                ReportParameter p2 = new ReportParameter("pToDate", pToDate);
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

                #endregion

                var dt = Session["dt"];

                DynamicParameters param = new DynamicParameters();
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

                var url = HttpContext.Current.Request.Url.AbsoluteUri;

                //ExportToPDF
                String fileName = "ACCReport_" + Guid.NewGuid() + ".pdf";
                ExportToPDFUtil.ExportToPDF(ReportViewer1, fileName);
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