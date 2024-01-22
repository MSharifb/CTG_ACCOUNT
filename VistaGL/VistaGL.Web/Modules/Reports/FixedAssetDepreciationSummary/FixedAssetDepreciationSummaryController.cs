using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.FixedAssetDepreciationSummary
{
    [RoutePrefix("Reports/FixedAssetDepreciationSummary"), Route("{action=index}")]
    public class FixedAssetDepreciationSummaryController : Controller
    {
        public SqlConnection con;
        public FixedAssetDepreciationSummaryController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: FixedAssetDepreciationSummary
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/FixedAssetDepreciationSummary/FixedAssetDepreciationSummaryIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;

            DynamicParameters param = new DynamicParameters();
            param.Add("@param_FinancialYearId", model.financialPeriodId);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<FixedAssetDepreciationSummaryModel>("ACC_RptFixedAssetDepreciationSummary", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            TempData["model"] = model;
            Session["model"] = model;
            Session["rpath"] = "~/Modules/Reports/Rdlc/FixedAssetDepreciationSummary.rdlc";
            Session["dt"] = list;
            return View("~/Modules/Reports/FixedAssetDepreciationSummary/FixedAssetDepreciationSummaryIndex.cshtml", model);
        }
    }
}