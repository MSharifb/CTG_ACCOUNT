using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.BudgetRequirementInfo
{
    [RoutePrefix("Reports/BudgetRequirementInfo"), Route("{action=index}")]
    public class BudgetRequirementInfoController : Controller
    {
        public SqlConnection con;
        public BudgetRequirementInfoController()
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
            return View("~/Modules/Reports/BudgetRequirementInfo/BudgetRequirementInfoIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_curBudgetYearId", model.financialPeriodId);
            param.Add("@param_fundControlId", model.FundcontrolId);
            param.Add("@param_deptId", model.DepartmentId);
            param.Add("@param_coaId", model.COAId);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            List<BudgetRequirementInfoRptModel> aList = null;
            if (model.ReportType == "S")
            {
                aList = con.Query<BudgetRequirementInfoRptModel>("Rpt_SP_ACC_BudgetSubmissionDetailProcess", param, commandType: CommandType.StoredProcedure).ToList();
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptBudgetRequirementInfo.rdlc";
            }
            else
            {
                aList = con.Query<BudgetRequirementInfoRptModel>("Rpt_SP_ACC_BudgetSubmissionDetailProcess", param, commandType: CommandType.StoredProcedure).ToList();
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptBudgetRequirementDetailsInfo.rdlc";
            }

            con.Close();


            Session["dt"] = aList;
            TempData["model"] = model;
            return View("~/Modules/Reports/BudgetRequirementInfo/BudgetRequirementInfoIndex.cshtml", model);
        }

    }
}