using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;


namespace VistaGL.Modules.Reports.BankReconciliation
{
    [Authorize]
    [RoutePrefix("Reports/BankReconciliation"), Route("{action=index}")]
    public class BankReconciliationController : Controller
    {
        public SqlConnection con;
        public BankReconciliationController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: BankReconciliation
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            //model.ToDate = DateTime.Now;
            model.OperatorLIst = ddlOPeratorList();
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/BankReconciliation/BankReconciliationIndex.cshtml", model);
        }

        private static IList<SelectListItem> ddlOPeratorList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "All", Value = "All", });
            list.Add(new SelectListItem() { Text = "=", Value = "=", });
            list.Add(new SelectListItem() { Text = ">", Value = ">", });
            list.Add(new SelectListItem() { Text = ">=", Value = ">=", });
            list.Add(new SelectListItem() { Text = "<", Value = "<", });
            list.Add(new SelectListItem() { Text = "<=", Value = "<=", });
            return list;
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/BankReconciliation/BankReconciliationIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@FundcontrolId", model.FundcontrolId);
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@COAId", model.COAId);
            param.Add("@FromDate", model.FromDate);
            param.Add("@ToDate", model.ToDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            Session["DataSet"] = null;

            if (model.BankReconcileType == "NR")
            {
                con.Open();
                var list = con.Query<BankReconciliationRptModel>("ACC_rptbank_reconciliation", param, commandTimeout:0,
                    commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                Session["rpath"] = "~/Modules/Reports/Rdlc/rptBankReconciliation.rdlc";
                Session["dt"] = list;
            }
            else if (model.BankReconcileType == "R")
            {
                con.Open();
                var list = con.Query<BankReconciliationOption2RptModel>("ACC_RPTBank_ReconciliationOption2", param, commandTimeout: 0,
                    commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                Session["rpath"] = "~/Modules/Reports/Rdlc/rptBankReconciliationOption2.rdlc";
                Session["dt"] = list;
            }

            Session["DataSet"] = "DSBank_reconciliation";
            //TempData["model"] = model;
            Session["model"] = model;
            model.OperatorLIst = ddlOPeratorList();

            return View("~/Modules/Reports/BankReconciliation/BankReconciliationIndex.cshtml", model);
        }


    }
}