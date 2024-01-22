using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Modules.Reports.AuditNotes;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/IncomeExpenditure"), Route("{action=index}")]
    public class IncomeExpenditureController : Controller
    {
        public SqlConnection con;
        public IncomeExpenditureController()
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
            return View("~/Modules/Reports/IncomeExpenditure/IncomeExpenditureIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/IncomeExpenditure/IncomeExpenditureIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@FundControlId", model.FundcontrolId);
            param.Add("@StartDate", model.FromDate);
            param.Add("@EndDate", model.ToDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<IncomeExpenditureRptModel>("Rpt_SP_ACC_IncomeExpenditure", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();


            Session["rpath"] = "~/Modules/Reports/Rdlc/IncomeExpenditure.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/IncomeExpenditure/IncomeExpenditureIndex.cshtml", model);
        }


        public ActionResult GetNote17(int fundControlId, string fromDate , string toDate)
        {
            ReportSearchViewModel model = new ReportSearchViewModel();
            DynamicParameters param = new DynamicParameters();
            param.Add("@FundControlId", fundControlId);
            param.Add("@StartDate", fromDate);
            param.Add("@EndDate", toDate);

            model.FromDate = Convert.ToDateTime(fromDate);
            model.ToDate = Convert.ToDateTime(toDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note17", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note17.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
    }
}