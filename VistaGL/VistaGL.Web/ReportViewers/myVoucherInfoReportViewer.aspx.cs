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
    public partial class myVoucherInfoReportViewer : System.Web.UI.Page
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public myVoucherInfoReportViewer()
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
                var model = Session["model"] as ReportSearchViewModel;
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(Session["rpath"].ToString());
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportParameter p10 = new ReportParameter("ChequeNo", model.Operator);
                ReportParameter p11 = new ReportParameter("ChequeDate", model.FromDate != null ? model.FromDate.Value.ToString("dd-MM-yyyy") : string.Empty);
                ReportParameter p12 = new ReportParameter("BankAccountNo", model.pBankAccountNo);
                ReportParameter p13 = new ReportParameter("BankName", model.pBankName);
                ReportParameter p14 = new ReportParameter("pEntityName", model.pEntityName);
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p10, p11, p12, p13, p14 });


                var dt = Session["dt"];
                ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Add(rdc);

                var dt1 = Session["dt1"];
                ReportDataSource rdc1 = new ReportDataSource("DataSet2", dt1);
                ReportViewer1.LocalReport.DataSources.Add(rdc1);

                this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
                //ReportViewer1.DataBind();

                //ExportToPDF
                String fileName = "VoucherReport_" + Guid.NewGuid() + ".pdf";
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