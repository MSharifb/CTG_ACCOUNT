using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.BudgetZoneWise
{
    [RoutePrefix("Reports/BudgetZoneWise"), Route("{action=index}")]
    public class BudgetZoneWiseController : Controller
    {
        public SqlConnection con;
        public BudgetZoneWiseController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: BudgetZoneWise
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/BudgetZoneWise/BudgetZoneWiseIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/BudgetZoneWise/BudgetZoneWiseIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_FinancialYearId", model.financialPeriodId);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            if (model.IsGroupbyCOA)
            {
                var list = con.Query<BudgetZoneWiseRptModel>("Rpt_SP_ACC_ZonewiseBudgetwithoutChild", param, commandType: CommandType.StoredProcedure).ToList();
                Session["dt"] = list;
            }
            else
            {
                var list = con.Query<BudgetZoneWiseRptModel>("Rpt_SP_ACC_ZonewiseBudget", param, commandType: CommandType.StoredProcedure).ToList();
                Session["dt"] = list;
            }
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/BudgetZoneWise.rdlc";

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/BudgetZoneWise/BudgetZoneWiseIndex.cshtml", model);
        }
    }
}