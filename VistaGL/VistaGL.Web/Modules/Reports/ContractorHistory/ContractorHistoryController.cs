using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ContractorHistory
{
    [Authorize]
    [RoutePrefix("Reports/ContractorHistory"), Route("{action=index}")]
    public class ContractorHistoryController : Controller
    {
        public SqlConnection con;
        public ContractorHistoryController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: ContractorHistory
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ContractorHistory/ContractorHistoryIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/ContractorHistory/ContractorHistoryIndex.cshtml", model);
            }

            var param = new DynamicParameters();
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_SubledgerId", model.CostCenterId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            Session["DataSet"] = null;

            con.Open();
            var list = con.Query<ContractorHistoryRptModel>("ACC_RptContractorHistory", param, commandTimeout:0, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptContractorHistory.rdlc";
            Session["dt"] = list;
            Session["DataSet"] = "DataSet1";

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/ContractorHistory/ContractorHistoryIndex.cshtml", model);
        }

    }
}