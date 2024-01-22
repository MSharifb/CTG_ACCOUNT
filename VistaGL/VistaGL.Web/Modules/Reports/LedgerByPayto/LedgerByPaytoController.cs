using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Modules.Reports.LedgerSubLedgerInfo;

namespace VistaGL.Modules.Reports.LedgerByPayto
{
    [RoutePrefix("Reports/LedgerByPayto"), Route("{action=index}")]
    public class LedgerByPaytoController : Controller
    {
        public SqlConnection con;
        public LedgerByPaytoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: LedgetByPayto
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsWithNarration = false;
            model.IsWithPayto = false;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/LedgerByPayto/LedgerByPaytoReportIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/LedgerByPayto/LedgerByPaytoReportIndex.cshtml", model);
            }

            var param = new DynamicParameters();

            param.Add("@param_paytoList", model.strPayTo);
            param.Add("@param_zoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);
            param.Add("@param_COAId", model.COAId);
            param.Add("@param_CostCenterId", model.CostCenterId);

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();
            var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_LedgerByPayto",
                                    param,
                                    commandTimeout: 0,
                                    commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByPayto.rdlc"; //RptSubLedgerInfo
            Session["dt"] = list;

            Session["model"] = model;
            return View("~/Modules/Reports/LedgerByPayto/LedgerByPaytoReportIndex.cshtml", model);

        }

    }
}