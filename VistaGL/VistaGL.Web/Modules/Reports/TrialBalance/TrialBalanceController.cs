using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/TrialBalance"), Route("{action=index}")]
    public class TrialBalanceController : Controller
    {
        public SqlConnection con;
        public TrialBalanceController()
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
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/TrialBalance/TrialBalanceIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/TrialBalance/TrialBalanceIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);
            param.Add("@param_level", model.Level);
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_isWithOpening", model.IsWithOpening);

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();

            List<TrialBalanceRptModel> aList = null;
            if (model.ReportType == "S")
            {
                aList = con.Query<TrialBalanceRptModel>("proc_acc_trialBalance", param,
                    commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
                Session["rpath"] = "~/Modules/Reports/Rdlc/TrialBalance.rdlc";
            }
            else if (model.ReportType == "D")
            {
                aList = con.Query<TrialBalanceRptModel>("proc_acc_trialBalance", param,
                    commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
                Session["rpath"] = "~/Modules/Reports/Rdlc/TrialBalanceDetails.rdlc";
            }
            else
            {
                aList = con.Query<TrialBalanceRptModel>("proc_acc_trialBalance", param,
                    commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
                Session["rpath"] = "~/Modules/Reports/Rdlc/ConsolidateTrialBalance.rdlc";
            }

            con.Close();

            Session["dt"] = aList;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/TrialBalance/TrialBalanceIndex.cshtml", model);
        }
    }
}