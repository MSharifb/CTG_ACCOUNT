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
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaGL.Modules.Reports;

namespace VistaGL.Views.Shared
{
    public partial class AsOnReportsViewer : ViewUserControl
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public AsOnReportsViewer()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDate();
            }
        }

        private void GetDate()
        {
            //if (Session["dt"] != null)
            //{
            //    var model = TempData["model"] as ReportSearchViewModel;
            //    ReportViewer1.Reset();
            //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //    ReportViewer1.LocalReport.ReportPath = Server.MapPath(Session["rpath"].ToString());
            //    ReportViewer1.LocalReport.Refresh();
            //    ReportViewer1.LocalReport.DataSources.Clear();

            //    #region report Title
            //    ReportParameter p1 = new ReportParameter("pZoneName", model.pZoneName);
            //    ReportParameter p2 = new ReportParameter("pEntityName", model.pEntityName);

            //    string pFromDate = string.Empty;
            //    string pFromYear = string.Empty;
            //    CultureInfo ci = new CultureInfo("en-US");
            //    if (model.FromDate != null)
            //        pFromDate = model.FromDate.Value.ToString("dd-MMM-yyyy", ci);
            //        pFromYear = model.FromDate.Value.Year.ToString();

            //    string pToDate = string.Empty;
            //    string pToYear = string.Empty;
            //    if (model.ToDate != null)
            //        pToDate = model.ToDate.Value.ToString("dd-MMM-yyyy", ci);
            //        pToYear = model.ToDate.Value.Year.ToString();

            //    ReportParameter p3 = new ReportParameter("pFromDate", pFromDate);
            //    ReportParameter p4 = new ReportParameter("pFromYear", pFromYear);
            //    ReportParameter p5 = new ReportParameter("pToDate", pToDate);
            //    ReportParameter p6 = new ReportParameter("pToYear", pToYear);
            //    ReportParameter p7 = new ReportParameter("pIsShowYear", model.IsAddYear.ToString());
            //    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6,p7});

            //    #endregion

            //    var dt = Session["dt"];
            //    ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            //    ReportViewer1.LocalReport.DataSources.Add(rdc);
            //    this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
            //    ReportViewer1.DataBind();

            //    //ExportToPDF
            //    String fileName = "ACCReport_" + Guid.NewGuid() + ".pdf";
            //    ExportToPDFUtil.ExportToPDF(ReportViewer1, fileName);
            //}
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