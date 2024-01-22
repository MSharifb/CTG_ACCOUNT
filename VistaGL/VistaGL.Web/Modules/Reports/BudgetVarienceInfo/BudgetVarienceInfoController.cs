using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.BudgetRequirementInfo
{
    [RoutePrefix("Reports/BudgetVarienceInfo"), Route("{action=index}")]
    public class BudgetVarienceInfoController : Controller
    {
        public SqlConnection con;
        public BudgetVarienceInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: BudgetRequirementInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/BudgetVarienceInfo/BudgetVarienceInfoIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_curBudgetYearId", model.financialPeriodId);
            param.Add("@param_fundControlId", model.FundcontrolId);
            param.Add("@param_coaId", model.COAId);


            // var pFinajcialYear= con.Query<BudgetRequirementInfoRptModel>("ACC_getPreFinancialYearbyCurId", param, commandType: CommandType.StoredProcedure).ToList();

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<BudgetRequirementInfoRptModel>("Rpt_SP_ACC_BudgetApprovalProcess", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptBudgetVariance.rdlc";
            Session["dt"] = list;

            TempData["model"] = model;
            return View("~/Modules/Reports/BudgetVarienceInfo/BudgetVarienceInfoIndex.cshtml", model);
        }

    }
}