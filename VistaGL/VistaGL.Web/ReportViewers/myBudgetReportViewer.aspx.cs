using Dapper;
using Microsoft.Reporting.WebForms;
using Serenity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VistaGL.Modules.Reports;
using VistaGL.Views.Shared;

namespace VistaGL.ReportViewers
{
    public partial class myBudgetReportViewer : System.Web.UI.Page
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public myBudgetReportViewer()
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

                ReportParameter p10 = new ReportParameter("pZoneName", model.pZoneName);
                ReportParameter p11 = new ReportParameter("pEntityName", model.pEntityName);
                ReportParameter p12 = new ReportParameter("pDepartments", model.pDeptName);
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p10, p11, p12 });

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

                this.ReportViewer1.LocalReport.SubreportProcessing +=
                    new SubreportProcessingEventHandler(localReport_SubreportProcessing);
                ReportViewer1.DataBind();


                //ExportToPDF
                String fileName = "ACCReport_" + Guid.NewGuid() + ".pdf";
                ExportToPDFUtil.ExportToPDF(ReportViewer1, fileName);
            }
        }

        void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            var param = new DynamicParameters();
            param.Add("@ZoneId", ((UserDefinition)Authorization.UserDefinition).ZoneID);
            con.Open();
            var dsName = "ZoneInfo";
            var data = con.Query<ZoneInfoViewModel>("SP_PRM_GetReportHeaderByZoneID", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            e.DataSources.Add(new ReportDataSource(dsName, data));
        }
    }
}