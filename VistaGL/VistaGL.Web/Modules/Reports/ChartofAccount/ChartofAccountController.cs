
using Serenity.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Configurations.Entities;
using VistaGL.Configurations.Repositories;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/ChartofAccount"), Route("{action=index}")]
    public class ChartofAccountController : Controller
    {
        public SqlConnection con;
        public ChartofAccountController()
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
            return View("~/Modules/Reports/ChartofAccount/ChartofAccountIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            using (var connection = SqlConnections.NewFor<AccChartofAccountsRow>())
            {
                if (model.COAId > 0)
                {
                    var query = @"

WITH cte_count (Id, ParentAccountId, Level, accountName, accountCode, UserCode, parentaccountaccountname, isControlhead, coaMapping, SortOrder)
AS	(
		SELECT coa.Id, coa.ParentAccountId, coa.Level, coa.accountName, coa.accountCode, coa.UserCode
				, parent.accountName parentaccountaccountname, coa.isControlhead, coa.coaMapping, coa.SortOrder
			FROM acc_ChartofAccounts coa INNER JOIN
				acc_ChartofAccounts parent ON coa.parentAccountId = parent.id
			WHERE coa.Id = " + model.COAId + @"
		UNION ALL
		SELECT coa.Id, coa.ParentAccountId, coa.Level, coa.accountName, coa.accountCode, coa.UserCode
				, parent.accountName parentaccountaccountname, coa.isControlhead, coa.coaMapping, coa.SortOrder
			FROM cte_count a INNER JOIN acc_ChartofAccounts coa ON a.ParentAccountId = coa.Id  INNER JOIN
				acc_ChartofAccounts parent ON coa.parentAccountId = parent.id
	),
cte_count1 (Id, ParentAccountId, Level, accountName, accountCode, UserCode, parentaccountaccountname, isControlhead, coaMapping, SortOrder)
AS	(
		SELECT coa.Id, coa.ParentAccountId, coa.Level, coa.accountName, coa.accountCode, coa.UserCode
				, parent.accountName parentaccountaccountname, coa.isControlhead, coa.coaMapping, coa.SortOrder
			FROM acc_ChartofAccounts coa  INNER JOIN
				acc_ChartofAccounts parent ON coa.parentAccountId = parent.id WHERE coa.Id = " + model.COAId + @"
		UNION ALL
		SELECT coa.Id, coa.ParentAccountId, coa.Level, coa.accountName, coa.accountCode, coa.UserCode
				, parent.accountName parentaccountaccountname, coa.isControlhead, coa.coaMapping, coa.SortOrder
			FROM cte_count1 a INNER JOIN acc_ChartofAccounts coa ON a.Id = coa.parentAccountId  INNER JOIN
				acc_ChartofAccounts parent ON coa.parentAccountId = parent.id
	)

SELECT Distinct Id, ParentAccountId, Level, accountName, accountCode, UserCode, parentaccountaccountname, isControlhead, coaMapping, SortOrder FROM cte_count
UNION ALL
SELECT Distinct Id, ParentAccountId, Level, accountName, accountCode, UserCode, parentaccountaccountname, isControlhead, coaMapping, SortOrder FROM cte_count1


                    ";

                    var d = connection.Query<AccChartofAccountsRow>(query);

                    Session["dt"] = d;
                }
                else
                {
                    var d = new AccChartofAccountsRepository().List(connection, new Serenity.Services.ListRequest { }).Entities.ToList();
                    Session["dt"] = d;
                }

            }

            Session["rpath"] = "~/Modules/Reports/Rdlc/ChartofAccount.rdlc";

            if(model.IsTreeView)
                Session["rpath"] = "~/Modules/Reports/Rdlc/ChartofAccountTreeView.rdlc";

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/ChartofAccount/ChartofAccountIndex.cshtml", model);
        }
    }
}