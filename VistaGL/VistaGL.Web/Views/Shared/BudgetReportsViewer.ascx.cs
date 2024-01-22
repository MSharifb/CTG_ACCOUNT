using Dapper;
using Microsoft.Reporting.WebForms;
using Serenity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VistaGL.Modules.Reports;

namespace VistaGL.Views.Shared
{
    public partial class BudgetReportsViewer : ViewUserControl
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public BudgetReportsViewer()
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
            if (Session["dt"] != null)
            {
                var model = TempData["model"] as ReportSearchViewModel;
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(Session["rpath"].ToString());
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.LocalReport.DataSources.Clear();

                #region report Title
                ReportParameter p10 = new ReportParameter("pZoneName", model.pZoneName);
                ReportParameter p11 = new ReportParameter("pEntityName", model.pEntityName);
                ReportParameter p12 = new ReportParameter("pAccountHead", model.pAccountHead);
                ReportParameter p13 = new ReportParameter("pCurFinancialYear", model.pFinancialYear);
                ReportParameter p14 = new ReportParameter("pPreFinancialYear", model.pAccountCode);

                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p10, p11, p12, p13 });

                #endregion

                var dt = Session["dt"];
                ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
                ReportViewer1.DataBind();

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