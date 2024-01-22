using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/JournalInfo"), Route("{action=index}")]
    public class JournalInfoController : Controller
    {
        public SqlConnection con;
        public JournalInfoController()
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

            model.OperatorLIst = ddlOPeratorList();
            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/JournalInfo/JournalInfoIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/JournalInfo/JournalInfoIndex.cshtml", model);
            }

            var param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);
            param.Add("@param_voucherTypeId", model.VoucherTypeId);
            param.Add("@param_WithLinkedJV", model.IsWithLinkedJournal);

            var zoneName = model.Zone;
            var entityName = model.FundcontrolId;
            var strReportperioc = model.FromDate + " to " + model.ToDate;
            var accountHead = model.COAId;

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();
            var list = con.Query<JournalInfoRptModel>(
                    "Rpt_SP_ACC_JournalProcess",
                    param,
                    commandTimeout: 0,
                    commandType: CommandType.StoredProcedure)
                .ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptJournalInfo.rdlc";

            if(model.WithDetails)
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptJournalInfoWithSubledger.rdlc";

            if(model.IsWithNarration)
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptJournalInfoWithNarration.rdlc";

            if (model.WithDetails && model.IsWithNarration)
                Session["rpath"] = "~/Modules/Reports/Rdlc/RptJournalInfoWithSubledgerAndNarration.rdlc";

            Session["dt"] = list;

            model.OperatorLIst = ddlOPeratorList();
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/JournalInfo/JournalInfoIndex.cshtml", model);
        }

        #region Private Methods
        private static IList<SelectListItem> ddlOPeratorList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "All", Value = "All", });
            list.Add(new SelectListItem() { Text = "=", Value = "=", });
            list.Add(new SelectListItem() { Text = ">", Value = ">", });
            list.Add(new SelectListItem() { Text = ">=", Value = ">=", });
            list.Add(new SelectListItem() { Text = "<", Value = "<", });
            list.Add(new SelectListItem() { Text = "<=", Value = "<=", });
            return list;
        }

        #endregion
    }
}