using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.BankBookInformation
{
    [RoutePrefix("Reports/BankBookInformation"), Route("{action=index}")]
    public class BankBookInformationController : Controller
    {
        public SqlConnection con;
        public BankBookInformationController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: BankBookInformation
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsWithOpening = true;
            model.IsWithNarration = true;
            model.IsOpenReportInNewTab = true;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/BankBookInformation/BankBookInformationIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/BankBookInformation/BankBookInformationIndex.cshtml", model);
            }

            var param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_coaId", model.COAId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);
            param.Add("@param_voucherTypeId", model.VoucherTypeId);
            param.Add("@param_transactionType", model.TransactionType);
            param.Add("@param_payTo", model.strPayTo);

            param.Add("@param_IsWithOpening", model.IsWithOpening);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<BankBookInformationRptModel>("Rpt_SP_ACC_BankBookInfoProcess", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptBankBookInformation.rdlc";
            Session["dt"] = list;

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/BankBookInformation/BankBookInformationIndex.cshtml", model);
        }

    }
}