using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.ReceiptPayment
{

    [RoutePrefix("Reports/ReceiptPayment"), Route("{action=index}")]
    public class ReceiptPaymentController : Controller
    {
        public SqlConnection con;
        public ReceiptPaymentController()
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
            model.IsOpenReportInNewTab = false;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/ReceiptPayment/ReceiptPaymentIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.Message = "From data cannot be greater than to date! Please check.";
                model.IsError = true;
                return View("~/Modules/Reports/ReceiptPayment/ReceiptPaymentIndex.cshtml", model);
            }

            var param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);


            if (model.IsAddYear)
            {
                param.Add("@param_fromDate2", model.FromDate2);
                param.Add("@param_toDate2", model.ToDate2);
            }

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();

            if (model.WithDetails) // with budget variance
            {
                var aList = new List<ReceiptPaymentDetailsRptModel>();

                param.Add("@param_withOpening", model.IsWithOpening);
                param.Add("@param_HideChildren", model.HideChildren);


                if (model.ReportType == "S") // INDIVIDUAL
                {
                    param.Add("@param_summaryWithCOATree", false);

                    Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPaymentDetails.rdlc";

                    if (model.ReceiptsPaymentsReportType == "WSD") // With subledger details
                    {
                        Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPaymentDetailsWithSubledger.rdlc";
                    }
                    else if (model.ReceiptsPaymentsReportType == "WSP") // With subledger parent
                    {
                        Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPaymentDetailsWithSubledgerParent.rdlc";
                    }
                    else if (model.ReceiptsPaymentsReportType == "WSCOA") // With CoA tree
                    {
                        param.Add("@param_summaryWithCOATree", true);
                        Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPaymentDetailsWithCOATree.rdlc";
                    }
                    //----------

                    aList = con
                            .Query<ReceiptPaymentDetailsRptModel>(
                                            "proc_acc_DetailsPaymentReceive",
                                            param,
                                            commandType: CommandType.StoredProcedure,
                                            commandTimeout: 0
                                        ).ToList();
                }
                else // CONSOLIDATED
                {
                    if (model.ReceiptsPaymentsReportType == "WSD") // With subledger details
                    {
                        Session["rpath"] = "~/Modules/Reports/Rdlc/ConsolidateReceiptPaymentDetailsWithSubledger.rdlc";
                    }
                    else if (model.ReceiptsPaymentsReportType == "WSP") // With subledger parent
                    {
                        Session["rpath"] = "~/Modules/Reports/Rdlc/ConsolidateReceiptPaymentDetailsWithSubledgerParent.rdlc";
                    }
                    //else if (model.ReceiptsPaymentsReportType == "WSCOA") // With CoA tree
                    //{
                    //    param.Add("@param_summaryWithCOATree", true);
                    //    Session["rpath"] = "~/Modules/Reports/Rdlc/ConsolidateReceiptPaymentDetailsWithCOATree.rdlc";
                    //}
                    else
                    {
                        Session["rpath"] = "~/Modules/Reports/Rdlc/ConsolidateReceiptPaymentDetails.rdlc";
                    }
                    //----------

                    aList = con
                            .Query<ReceiptPaymentDetailsRptModel>(
                                        "proc_acc_ConsolidatePaymentReceive",
                                        param,
                                        commandType: CommandType.StoredProcedure,
                                        commandTimeout: 0
                                    ).ToList();
                }

                Session["dt"] = aList;
            }
            //else
            //{
            //    var aList = con.Query<ReceiptPaymentRptModel>("proc_acc_paymentReceive", param,
            //        commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();
            //    Session["dt"] = aList;
            //    Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPayment.rdlc";

            //    if (model.ReportType == "C")
            //    {
            //        aList = con.Query<ReceiptPaymentRptModel>("proc_acc_consolidatedPaymentReceive", param,
            //            commandType: CommandType.StoredProcedure).ToList();
            //        Session["dt"] = aList;
            //        Session["rpath"] = "~/Modules/Reports/Rdlc/ConsolidateReceiptPayment.rdlc";
            //    }
            //}

            con.Close();

            //TempData["model"] = model;
            Session["model"] = model;

            return View("~/Modules/Reports/ReceiptPayment/ReceiptPaymentIndex.cshtml", model);
        }
    }
}