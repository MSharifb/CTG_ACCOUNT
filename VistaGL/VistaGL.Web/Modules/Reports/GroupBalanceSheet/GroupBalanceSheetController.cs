using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/GroupBalanceSheet"), Route("{action=index}")]
    public class GroupBalanceSheetController : Controller
    {
        public SqlConnection con;
        public GroupBalanceSheetController()
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
            return View("~/Modules/Reports/GroupBalanceSheet/GroupBalanceSheetIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            //            @param_asOnDate VARCHAR(50),
            //@param_level INT,
            //@param_fundControlId VARCHAR(50),
            //@param_periodStartDate VARCHAR(50)


            DynamicParameters param = new DynamicParameters();
            param.Add("@param_asOnDate", model.FromDate);
            param.Add("@param_level", model.Level);
            param.Add("@param_fundcontrolId", model.FundcontrolId);

            param.Add("@param_periodStartDate", model.FromDate);
            param.Add("@param_ZoneId", model.ZoneInfoList);


            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<GroupBalanceSheetRptModel>("proc_acc_calculateBalanceGroup", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/GroupBalanceSheet.rdlc";
            Session["dt"] = list;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/GroupBalanceSheet/GroupBalanceSheetIndex.cshtml", model);
        }
    }
}