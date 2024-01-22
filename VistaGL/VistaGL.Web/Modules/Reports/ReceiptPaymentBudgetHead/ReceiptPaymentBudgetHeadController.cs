using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ReceiptPaymentBudgetHead
{
    [RoutePrefix("Reports/ReceiptPaymentBudgetHead"), Route("{action=index}")]
    public class ReceiptPaymentBudgetHeadController : Controller
    {
        public SqlConnection con;
        public ReceiptPaymentBudgetHeadController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }
        // GET: ReceiptPaymentBudgetHead
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsOpenReportInNewTab = false;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ReceiptPaymentBudgetHead/ReceiptPaymentBudgetHeadIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.Message = "From data cannot be greater than to date! Please check.";
                model.IsError = true;
                return View("~/Modules/Reports/ReceiptPaymentBudgetHead/ReceiptPaymentBudgetHeadIndex.cshtml", model);
            }

            var param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_fromDate", Convert.ToDateTime(model.FromDate?.ToString("dd-MMM-yyyy")));
            param.Add("@param_toDate", Convert.ToDateTime(model.ToDate?.ToString("dd-MMM-yyyy")));

            Session["dt"] = null;
            Session["dtopening"] = null;
            Session["dtclosing"] = null;

            Session["rpath"] = null;

            con.Open();

            var aList = new List<ReceiptPaymentDetailsRptModel>();
            var aListOpening = new List<ReceiptPaymentDetailsRptModel>();
            var aListClosing = new List<ReceiptPaymentDetailsRptModel>();

            param.Add("@param_withOpening", model.IsWithOpening);
            param.Add("@param_HideChildren", model.HideChildren);
            param.Add("@param_summaryWithCOATree", false);
            if (model.IsTreeView)
                Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPaymentBudgetHead_Consolidate.rdlc";
            else
                Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPaymentBudgetHead.rdlc";


            //----------
            aListOpening = con.Query<ReceiptPaymentDetailsRptModel>(
                                        "proc_acc_ReceiptPayment_BudgetHead_Opening",
                                        param,
                                        commandType: CommandType.StoredProcedure,
                                        commandTimeout: 0
                                    ).ToList();
            //----------
            if(model.IsTreeView)
            aList = con.Query<ReceiptPaymentDetailsRptModel>(
                                    "proc_acc_ReceiptPayment_BudgetHead_Consolidate_test",
                                    param,
                                    commandType: CommandType.StoredProcedure,
                                    commandTimeout: 0
                                ).ToList(); 
            else
             aList = con.Query<ReceiptPaymentDetailsRptModel>(
                                    "proc_acc_ReceiptPayment_BudgetHead",
                                    param,
                                    commandType: CommandType.StoredProcedure,
                                    commandTimeout: 0
                                ).ToList();
            //----------
            aListClosing = con.Query<ReceiptPaymentDetailsRptModel>(
                                    "proc_acc_ReceiptPayment_BudgetHead_Closing",
                                    param,
                                    commandType: CommandType.StoredProcedure,
                                    commandTimeout: 0
                                ).ToList();

           


            Session["dt"] = aList;
            Session["dtopening"] = aListOpening;
            Session["dtclosing"] = aListClosing;

            con.Close();
            Session["model"] = model;
            return View("~/Modules/Reports/ReceiptPaymentBudgetHead/ReceiptPaymentBudgetHeadIndex.cshtml", model);
        }
    }
}