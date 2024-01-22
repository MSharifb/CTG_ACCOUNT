using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ConsolidatedProposedBudget
{
    [RoutePrefix("Reports/ConsolidatedProposedBudget"), Route("{action=index}")]
    public class ConsolidatedProposedBudgetController : Controller
    {
        public SqlConnection con;
        public ConsolidatedProposedBudgetController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: ConsolidatedProposedBudget
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ConsolidatedProposedBudget/ConsolidatedProposedBudgetIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@param_ProposedYearId", model.financialPeriodId);
            param.Add("@param_fundControlId", model.FundcontrolId);
            param.Add("@param_ZoneList", model.ZoneInfoList);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<ConsolidatedProposedBudgetRptModel>("Rpt_SP_ACC_ConsolidatedProposedBudget", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptConsolidatedProposedBudget.rdlc";
            Session["dt"] = list;

            TempData["model"] = model;
            return View("~/Modules/Reports/ConsolidatedProposedBudget/ConsolidatedProposedBudgetIndex.cshtml", model);
        }
    }
}