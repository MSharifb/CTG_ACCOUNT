using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/ConsolidatedBudget"), Route("{action=index}")]
    public class ConsolidatedBudgetController : Controller
    {
        public SqlConnection con;
        public ConsolidatedBudgetController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: LedgerInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ConsolidatedBudget/ConsolidatedBudgetIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@param_BudgetYearId", model.financialPeriodId);
            param.Add("@param_fundControlId", model.FundcontrolId);
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@param_DeptList", model.SelectedDeptList);

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();
            var list = con.Query<ConsolidatedBudgetRptModel>("proc_acc_ConsolidatedBudget", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptConsolidatedBudget.rdlc";
            Session["dt"] = list;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/ConsolidatedBudget/ConsolidatedBudgetIndex.cshtml", model);
        }

        public ActionResult GetBudget(int financialPeriodId, int zoneInfoId, int departmentId)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            var model = new ReportSearchViewModel();
            model.financialPeriodId = financialPeriodId;
            model.FundcontrolId = user.FundControlInformationId;
            model.ZoneInfoList = zoneInfoId.ToString();
            model.SelectedDeptList = departmentId.ToString();

            DynamicParameters param = new DynamicParameters();
            param.Add("@param_BudgetYearId", financialPeriodId);
            param.Add("@param_fundControlId", user.FundControlInformationId);
            param.Add("@param_ZoneList", zoneInfoId.ToString());
            param.Add("@param_DeptList", departmentId.ToString());

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<ConsolidatedBudgetRptModel>("proc_acc_ConsolidatedBudget", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptConsolidatedBudget.rdlc";
            Session["dt"] = list;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/ConsolidatedBudget/ConsolidatedBudgetIndex.cshtml", model);
        }
    }
}