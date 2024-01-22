using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.BudgetRequirementInfo
{
    [RoutePrefix("Reports/BudgetApprovalInfo"), Route("{action=index}")]
    public class BudgetApprovalInfoController : Controller
    {
        public SqlConnection con;
        public BudgetApprovalInfoController()
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
            return View("~/Modules/Reports/BudgetApprovalInfo/BudgetApprovalInfoIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {

            var param = new DynamicParameters();
            param.Add("@param_BudgetYearId", model.financialPeriodId);
            param.Add("@param_fundControlId", model.FundcontrolId);
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@param_DeptList", model.SelectedDeptList);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<BudgetApprovalInfoRptModel>("Rpt_SP_ACC_BudgetApprovalProcess", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptBudgetApproval.rdlc";
            Session["dt"] = list;

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/BudgetApprovalInfo/BudgetApprovalInfoIndex.cshtml", model);
        }
        public ActionResult BudgetHistory(int financialPeriodId, int zoneInfoId, int departmentId)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            var param = new DynamicParameters();
            var model = new ReportSearchViewModel();
            model.financialPeriodId = financialPeriodId;
            model.FundcontrolId = user.FundControlInformationId;
            model.ZoneInfoList = zoneInfoId.ToString();
            model.SelectedDeptList = departmentId.ToString();

            param.Add("@param_BudgetYearId", model.financialPeriodId);
            param.Add("@param_fundControlId", model.FundcontrolId);
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@param_DeptList", model.SelectedDeptList);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<BudgetApprovalInfoRptModel>("Rpt_SP_ACC_BudgetApprovalProcess", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptBudgetApproval.rdlc";
            Session["dt"] = list;

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/BudgetApprovalInfo/BudgetApprovalInfoIndex.cshtml", model);
        }
    }
}