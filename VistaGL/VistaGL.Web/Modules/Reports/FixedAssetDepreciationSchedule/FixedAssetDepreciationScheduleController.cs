using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.FixedAssetDepreciationSchedule
{
    [RoutePrefix("Reports/FixedAssetDepreciationSchedule"), Route("{action=index}")]
    public class FixedAssetDepreciationScheduleController : Controller
    {
        public SqlConnection con;
        public FixedAssetDepreciationScheduleController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: FixedAssetDepreciationSchedule
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/FixedAssetDepreciationSchedule/FixedAssetDepreciationScheduleIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;

            DynamicParameters param = new DynamicParameters();
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@param_FinancialYearId", model.financialPeriodId);
            param.Add("@WorkType", "1");

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<FixedAssetDepreciationScheduleModel>("ACC_RptFixedAssetDepreciationSchedule", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            TempData["model"] = model;
            Session["model"] = model;
            Session["rpath"] = "~/Modules/Reports/Rdlc/FixedAssetDepreciationSchedule.rdlc";
            Session["dt"] = list;
            return View("~/Modules/Reports/FixedAssetDepreciationSchedule/FixedAssetDepreciationScheduleIndex.cshtml", model);
        }
    }
}