using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/GratuityStatement"), Route("{action=index}")]
    public class GratuityStatementController : Controller
    {
        public SqlConnection con;
        public GratuityStatementController()
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
            return View("~/Modules/Reports/GratuityStatement/GratuityStatementIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@param_asOnDate", model.FromDate);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            var list = con.Query<GratuityStatementRptModel>("sp_PRM_GratuityStatement", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/GratuityStatement.rdlc";
            Session["dt"] = list;
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/GratuityStatement/GratuityStatementIndex.cshtml", model);
        }
    }
}