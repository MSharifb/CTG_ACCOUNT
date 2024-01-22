using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Modules.Reports.LedgerSubLedgerInfo;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/GroupLedger"), Route("{action=index}")]
    public class GroupLedgerController : Controller
    {
        public SqlConnection con;
        public GroupLedgerController()
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
            model.TransactionType = "C";

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/GroupLedger/GroupLedgerIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/GroupLedger/GroupLedgerIndex.cshtml", model);
            }

            var isConsolidated = false;
            var isTabular = false;

            if (model.TransactionType == "C")
            {
                isConsolidated = true;
            }
            else if (model.TransactionType == "T")
            {
                isTabular = true;
            }


            var param = new DynamicParameters();
            param.Add("@param_coaId", model.COAId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_withOpening", model.IsWithOpening);

            Session["dt"] = null;
            Session["rpath"] = null;
            con.Open();
            if (isConsolidated)
            {
                model.IsOpenReportInNewTab = false;
                var list = con.Query<ConsolidatedScheduleRptModel>("Rpt_SP_ACC_GroupLedgerConsolidated", param, commandTimeout: 0, commandType: CommandType.StoredProcedure).ToList();
                Session["dt"] = list;
                if (model.IsGroupbyCOA)
                {
                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerScheduleConsolidated_groupbyCOA.rdlc";
                }
                else
                {
                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerScheduleConsolidated.rdlc";
                }
            }
            else if(isTabular)
            {
                model.IsOpenReportInNewTab = true;
                var list = con.Query<GroupLedgerRptModel>("proc_acc_GroupLedger", param, commandType: CommandType.StoredProcedure).ToList();
                Session["dt"] = list;
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptGroupLedger.rdlc";
            }
            con.Close();

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/GroupLedger/GroupLedgerIndex.cshtml", model);
        }
    }
}