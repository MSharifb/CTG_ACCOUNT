using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Modules.Reports.AuditNotes;
using VistaGL.Modules.Reports.FixedAssetDepreciationSummary;

namespace VistaGL.Modules.Reports
{

    [RoutePrefix("Reports/BalanceSheet"), Route("{action=index}")]
    public class BalanceSheetController : Controller
    {
        public SqlConnection con;
        public BalanceSheetController()
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
            return View("~/Modules/Reports/BalanceSheet/BalanceSheetIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/BalanceSheet/BalanceSheetIndex.cshtml", model);
            }

            var user = (UserDefinition)Serenity.Authorization.UserDefinition;

            var param = new DynamicParameters();
            param.Add("@param_ReportTypeId", model.ReportTypeId);
            param.Add("@param_ZoneList", model.ZoneInfoList);
            param.Add("@param_fundControlId", model.FundcontrolId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);

            Session["dt"] = null;
            Session["rpath"] = null;

            if (model.ReportTypeId == 1)
            {
                con.Open();
                var list = con.Query<BalanceSheetRptModel_M1>("Rpt_SP_ACC_BalanceSheet_M1", param, commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();



                con.Close();
                Session["dt"] = list;
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptBalanceSheet_M1.rdlc";
            }
            else if (model.ReportTypeId == 2)
            {
                con.Open();
                var list = con.Query<BalanceSheetRptModel_M1>("Rpt_SP_ACC_IncomeExpenditure_M1", param, commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
                con.Close();
                Session["dt"] = list;
                Session["rpath"] = "~/Modules/Reports/Rdlc/IncomeExpenditure.rdlc";
            }
            else if (model.ReportTypeId == 3)
            {
                con.Open();
                var list = con.Query<BalanceSheetRptModel_M1>("Rpt_SP_ACC_CashFlow_M1", param, commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
                con.Close();
                Session["dt"] = list;
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptCashFlow.rdlc";
            }

            Session["model"] = model;
            return View("~/Modules/Reports/BalanceSheet/BalanceSheetIndex.cshtml", model);
        }
        public ActionResult GetNote16(int fundControlId, string fromDate, string toDate)
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

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note16.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }

        public ActionResult GetNote07(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<FixedAssetDepreciationSummaryModel>("Rpt_SP_ACC_Note07", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/FixedAssetDepreciationSummary.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/FixedAssetDepreciationSummary/FixedAssetDepreciationSummaryIndex.cshtml", model);
        }

        public ActionResult GetNote08(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note08", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note8.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }

        public ActionResult GetNote12(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note12", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note12.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote13(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note13", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note13.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote09(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note09", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note9.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }

        public ActionResult GetNote10(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note10", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note10.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote11(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note11", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note11.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }

        public ActionResult GetNote06(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note06", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note06.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote04(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note04", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note4.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote05(int fundControlId, string fromDate, string toDate)
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
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note05", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note5.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote14_01(int fundControlId, string fromDate, string toDate)
        {
            ReportSearchViewModel model = new ReportSearchViewModel();
            DynamicParameters param = new DynamicParameters();

            param.Add("@param_ZoneList", "1,2,3,4,5,6,7,8,9,10");
            param.Add("@param_fundControlId", fundControlId);
            param.Add("@param_fromDate", fromDate);
            param.Add("@param_toDate", toDate);

            model.FromDate = Convert.ToDateTime(fromDate);
            model.ToDate = Convert.ToDateTime(toDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note14_01", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note14_01.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote14(int fundControlId, string fromDate, string toDate)
        {
            ReportSearchViewModel model = new ReportSearchViewModel();
            DynamicParameters param = new DynamicParameters();
            param.Add("@param_ZoneList", "1,2,3,4,5,6,7,8,9,10");
            param.Add("@param_fundControlId", fundControlId);
            param.Add("@param_fromDate", fromDate);
            param.Add("@param_toDate", toDate);

            model.FromDate = Convert.ToDateTime(fromDate);
            model.ToDate = Convert.ToDateTime(toDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note14", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note14.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
        public ActionResult GetNote15(int fundControlId, string fromDate, string toDate)
        {
            ReportSearchViewModel model = new ReportSearchViewModel();
            DynamicParameters param = new DynamicParameters();
            param.Add("@param_ZoneList", "1,2,3,4,5,6,7,8,9,10");
            param.Add("@param_fundControlId", fundControlId);
            param.Add("@param_fromDate", fromDate);
            param.Add("@param_toDate", toDate);

            model.FromDate = Convert.ToDateTime(fromDate);
            model.ToDate = Convert.ToDateTime(toDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<AuditNotesViewModel>("Rpt_SP_ACC_Note15", param, commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/Note15.rdlc";
            Session["dt"] = list;
            Session["model"] = model;
            return View("~/Modules/Reports/AuditNotes/AuditNotesIndex.cshtml", model);
        }
    }
}