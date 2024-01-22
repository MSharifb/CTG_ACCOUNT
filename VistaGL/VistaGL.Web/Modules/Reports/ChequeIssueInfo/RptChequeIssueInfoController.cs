using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ChequeIssueInfo
{
    [RoutePrefix("Reports/ChequeIssueInfo"), Route("{action=index}")]
    public class RptChequeIssueInfoController : Controller
    {
        public SqlConnection con;
        public RptChequeIssueInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: ChequeIssueInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ChequeIssueInfo/ChequeIssueInfoIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? BankAccountId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/ChequeIssueInfo/ChequeIssueInfoIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@paramBankAccountId", model.BankAccountId);
            param.Add("@paramEntityId", model.FundcontrolId);
            param.Add("@paramFromDate", model.FromDate);
            param.Add("@paramToDate", model.ToDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<ChequIssueInfoRptModel>("Rpt_SP_ACC_ChequeIssueProcess", param, commandTimeout: 0,
                commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptChequeIssueInfo.rdlc";
            Session["dt"] = list;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/ChequeIssueInfo/ChequeIssueInfoIndex.cshtml", model);


        }
    }
}