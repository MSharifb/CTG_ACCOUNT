using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerInfo
{

    [RoutePrefix("Reports/LedgerInfo"), Route("{action=index}")]
    public class LedgerInfoController : Controller
    {
        public SqlConnection con;
        public LedgerInfoController()
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
            return View("~/Modules/Reports/LedgerInfo/LedgerInfoIndex.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = "From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/LedgerInfo/LedgerInfoIndex.cshtml", model);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_coaId", model.COAId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);

            param.Add("@param_voucherTypeId", model.VoucherTypeId);
            param.Add("@param_transactionType", model.TransactionType);
            param.Add("@param_checkNumber", model.IsWithChequeNo);

            param.Add("@param_operator", model.Operator);
            param.Add("@param_amount", model.Amount);
            param.Add("@param_narration", model.IsWithNarration);
            param.Add("@param_withOtherTransactionHeads", model.WithDetails);
            param.Add("@param_costCenterId", model.CostCenterId);
            param.Add("@param_IsWithOpening", model.IsWithOpening);

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();
            var list = con.Query<LedgerInfoRptModel>("Rpt_SP_ACC_LedgerProcess", param, commandType: CommandType.StoredProcedure).ToList();
            con.Close();

            Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfo.rdlc";
            Session["dt"] = list;


            model.OperatorLIst = ddlOPeratorList();
            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/LedgerInfo/LedgerInfoIndex.cshtml", model);
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