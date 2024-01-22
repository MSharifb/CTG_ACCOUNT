
using Serenity.Data;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Configurations.Entities;

namespace VistaGL.Modules.Reports.BudgetGroup
{

    [RoutePrefix("Reports/BudgetGroup"), Route("{action=index}")]
    public class BudgetGroupController : Controller
    {

        public BudgetGroupController()
        {

        }

        // GET: BudgetGroup
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/BudgetGroup/BudgetGroupIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            using (var connection = SqlConnections.NewFor<AccBudgetGroupRow>())
            {
                var user = (UserDefinition)Serenity.Authorization.UserDefinition;
                DynamicParameters param = new DynamicParameters();
                param.Add("@param_fundcontrolId", user.FundControlInformationId);

                var list = connection.Query<BudgetGroupRptModel>("Rpt_SP_ACC_BudgetGroup", param, commandType: CommandType.StoredProcedure).ToList();

                Session["dt"] = list;
            }

            Session["rpath"] = "~/Modules/Reports/Rdlc/BudgetGroup.rdlc";

            Session["model"] = model;
            return View("~/Modules/Reports/BudgetGroup/BudgetGroupIndex.cshtml", model);
        }
    }
}