using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Modules.Reports.BankBookInfo;

namespace VistaGL.Modules.Reports.CashInfo
{
    [RoutePrefix("Reports/CashInfo"), Route("{action=index}")]
    public class CashInfoController : Controller
    {
        public SqlConnection con;
        public CashInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: CashInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/CashInfo/CashInfoIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/CashInfo/CashInfoIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@paramBankAccountId", model.COAId);
            param.Add("@paramEntityId", model.FundcontrolId);
            param.Add("@paramFromDate", model.FromDate);
            param.Add("@paramToDate", model.ToDate);
            //param.Add("@param_voucherTypeId", model.VoucherTypeId);
            //param.Add("@param_transactionType", model.TransactionType);

 //           @paramZoneList       VARCHAR(50),
	//@paramBankAccountId	 INT, --not used yet
 //   @paramEntityId       INT,
	//@paramFromDate       DATE,
 //   @paramToDate         DATE

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<BankBookInfoRptModel>("Rpt_SP_ACC_ChequeIssueProcess", param, commandTimeout: 0,
                commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptCashInfo.rdlc";
            Session["dt"] = list;

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/CashInfo/CashInfoIndex.cshtml", model);
        }


    }
}