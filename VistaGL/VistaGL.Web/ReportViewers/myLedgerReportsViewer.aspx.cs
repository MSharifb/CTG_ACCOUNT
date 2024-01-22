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
    public partial class myLedgerReportsViewer : System.Web.UI.Page
    {
        #region Fields
        public SqlConnection con;
        #endregion

        #region Ctor
        public myLedgerReportsViewer()
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


                #region Search parameter
                // string searchParameters = "Balance as on : " + BalanceDate.ToString("dd MMM yyyy");
                ReportParameter p1 = new ReportParameter("IsDetails", model.WithDetails.ToString());
                ReportParameter p2 = new ReportParameter("IsWithCostCenter", model.IsWithCostCenter.ToString());
                ReportParameter p3 = new ReportParameter("IsWithBillRef", model.IsWithBillRef.ToString());
                ReportParameter p4 = new ReportParameter("IsWithChequeNo", model.IsWithChequeNo.ToString());
                ReportParameter p5 = new ReportParameter("IsWithNarration", model.IsWithNarration.ToString());
                // ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5 });

                #endregion

                #region report Title
                ReportParameter p10 = new ReportParameter("pZoneName", model.pZoneName);
                ReportParameter p11 = new ReportParameter("pEntityName", model.pEntityName);
                string pReportPeriod = "";
                CultureInfo ci = new CultureInfo("en-US");
                if (model.FromDate != null)
                    pReportPeriod = model.FromDate.Value.ToString("dd-MMM-yy", ci);

                if (model.FromDate != null && model.ToDate != null)
                    pReportPeriod = model.FromDate.Value.ToString("dd-MMM-yyyy", ci) + " to " + model.ToDate.Value.ToString("dd-MMM-yyyy", ci);

                ReportParameter p12 = new ReportParameter("pReportPeriod", pReportPeriod);
                ReportParameter p13 = new ReportParameter("pAccountHead", model.pAccountHead);
                ReportParameter p14 = new ReportParameter("pAccountCode", model.pAccountCode);
                ReportParameter p15 = new ReportParameter("pBankAccountNo", model.pBankAccountNo);
                ReportParameter p16 = new ReportParameter("pCostCenter", model.pCostCenter);
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p10, p11, p12, p13, p14, p15, p16 });

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