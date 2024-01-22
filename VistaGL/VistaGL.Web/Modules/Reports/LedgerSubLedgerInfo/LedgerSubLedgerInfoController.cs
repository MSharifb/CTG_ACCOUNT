using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace VistaGL.Modules.Reports.LedgerSubLedgerInfo
{
    [RoutePrefix("Reports/LedgerSubLedgerInfo"), Route("{action=index}")]
    public class LedgerSubLedgerInfoController : Controller
    {
        public SqlConnection con;
        public LedgerSubLedgerInfoController()
        {
            string constr = ConfigurationManager.ConnectionStrings["ACCDB"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: LedgerSubLedgerInfo
        public ActionResult Index(ReportSearchViewModel model)
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            model.ZoneInfoList = user.ZoneID.ToString();
            model.FundcontrolId = user.FundControlInformationId;
            model.financialPeriodId = user.FinancialYearId;
            model.IsWithNarration = true;
            model.IsOpenReportInNewTab = false;

            Session["dt"] = null;
            Session["rpath"] = null;
            return View("~/Modules/Reports/LedgerSubLedgerInfo/LedgerSubLedgerInfoIndex.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ReportSearchViewModel model, int? zoneId)
        {
            if (model.FromDate > model.ToDate)
            {
                model.IsError = true;
                model.Message = @"From date cannot be greater than to date. Try again.";
                return View("~/Modules/Reports/LedgerSubLedgerInfo/LedgerSubLedgerInfoIndex.cshtml", model);
            }

            var isShowLedger = false;
            var isShowConsolidatedSchedule = false;
            var isShowSchedule = false;
            var isAdjustmentSchedure = false;
            var isUnadjustmentSchedure = false;

            if (model.TransactionType == "L") { isShowLedger = true; }
            else if (model.TransactionType == "S") { isShowSchedule = true; }
            else if (model.TransactionType == "CS") { isShowConsolidatedSchedule = true; }
            else if (model.TransactionType == "SAS") { isAdjustmentSchedure = true; }
            else if (model.TransactionType == "SUAS") { isUnadjustmentSchedure = true; }

            var param = new DynamicParameters();
            param.Add("@paramZoneList", model.ZoneInfoList);
            param.Add("@param_fundcontrolId", model.FundcontrolId);
            param.Add("@param_fromDate", model.FromDate);
            param.Add("@param_toDate", model.ToDate);

            Session["dt"] = null;
            Session["rpath"] = null;

            con.Open();
            if (model.ShowInReceiptPaymentFormat)
            {
                #region Show in receipt-payment format.
                param.Add("@param_level", 0);
                param.Add("@param_financialYearId", null);
                param.Add("@param_summaryWithCOATree", false);
                param.Add("@param_withOpening", false);

                Session["rpath"] = "~/Modules/Reports/Rdlc/ReceiptPaymentDetailsWithSubledger.rdlc";
                var aList = con.Query<ReceiptPaymentDetailsRptModel>("proc_acc_DetailsPaymentReceive", param, commandTimeout: 0,
                        commandType: CommandType.StoredProcedure).ToList();

                aList = aList.Where(a => a.ledger_coaid == model.COAId).ToList();
                Session["dt"] = aList;
                #endregion
            }
            else
            {
                #region Ledger/Sub-ledger Report
                param.Add("@param_withOpening", model.IsWithOpening);

                #region Commented
                // BY SUB-LEDGER ONLY
                //if (model.COAId <= 0)
                //{
                //    param.Add("@param_costCenterId", model.CostCenterId);
                //    //LedgerSubLedgerInfoRptModel
                //    //Rpt_SP_ACC_SubLedger
                //    var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_LedgerInfoByCostCenter",
                //        param,
                //        commandTimeout: 0,
                //        commandType: CommandType.StoredProcedure).ToList();

                //    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCostCenter.rdlc"; //RptSubLedgerInfo
                //    Session["dt"] = list;
                //}
                // BY ACCOUNT HEAD
                //else if (model.COAId > 0 && model.CostCenterId <= 0)
                //{
                // SHOW LEDGER BY CHART OF ACCOUNT
                //if (isShowLedger)
                //{
                //    var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_LedgerInfoByCoa",
                //        param,
                //        commandTimeout: 0,
                //        commandType: CommandType.StoredProcedure).ToList();

                //    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCoa.rdlc";
                //    Session["dt"] = list;
                //}
                // SHOW SCHEDULE
                //else if (isShowSchedule)
                //{
                //    var list = con.Query<LedgerSubLedgerInfoRptModel>("Rpt_SP_ACC_Schedule",
                //        param,
                //        commandTimeout: 0,
                //        commandType: CommandType.StoredProcedure).ToList();

                //    if (model.ShowSubledgersWithoutParent)
                //        Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoWithAccountHead_WithoutParentGroup.rdlc";
                //    else
                //        Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoWithAccountHead.rdlc";

                //    Session["dt"] = list;
                //}
                //else if (isShowConsolidatedSchedule)
                //{
                //    var list = con.Query<LedgerSubLedgerInfoRptModel>("Rpt_SP_ACC_Schedule",
                //        param,
                //        commandTimeout: 0,
                //        commandType: CommandType.StoredProcedure).ToList();

                //    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerScheduleConsolidated.rdlc";

                //    Session["dt"] = list;
                //}
                //}
                // BY BOTH ACCOUNT HEAD AND SUB-LEDGER
                //else if (model.COAId > 0 && model.CostCenterId > 0)
                //{
                //    param.Add("@param_costCenterId", model.CostCenterId);
                //    var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_LedgerInfoByCoaAndCostCenter",
                //        param,
                //        commandTimeout: 0,
                //        commandType: CommandType.StoredProcedure).ToList();

                //    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCoaAndCostCenter.rdlc";
                //    Session["dt"] = list;
                //}
                #endregion

                if (isShowLedger)
                {
                    if (model.COAId > 0 && model.CostCenterId <= 0) // by account head
                    {
                        param.Add("@param_coaId", model.COAId);
                        var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_LedgerInfoByCoa",
                                                                        param,
                                                                        commandTimeout: 0,
                                                                        commandType: CommandType.StoredProcedure).ToList();

                        Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCoa.rdlc";
                        Session["dt"] = list;
                    }
                    else if (model.COAId > 0 && model.CostCenterId > 0) // by account head and cost center
                    {
                        param.Add("@param_coaId", model.COAId);
                        param.Add("@param_costCenterId", model.CostCenterId);
                        var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_LedgerInfoByCoaAndCostCenter",
                            param,
                            commandTimeout: 0,
                            commandType: CommandType.StoredProcedure).ToList();

                        Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCoaAndCostCenter.rdlc";
                        Session["dt"] = list;
                    }
                    else if (model.COAId <= 0 && model.CostCenterId > 0) // by cost center
                    {
                        param.Add("@param_costCenterId", model.CostCenterId);
                        //LedgerSubLedgerInfoRptModel
                        //Rpt_SP_ACC_SubLedger
                        var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_LedgerInfoByCostCenter",
                            param,
                            commandTimeout: 0,
                            commandType: CommandType.StoredProcedure).ToList();

                        Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCostCenter.rdlc"; //RptSubLedgerInfo
                        Session["dt"] = list;
                    }
                }
                else if (isShowSchedule)
                {
                    param.Add("@param_coaId", model.COAId);
                    var list = con.Query<LedgerSubLedgerInfoRptModel>("Rpt_SP_ACC_Schedule",
                        param,
                        commandTimeout: 0,
                        commandType: CommandType.StoredProcedure).ToList();

                    if (model.ShowSubledgersWithoutParent)
                        Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoWithAccountHead_WithoutParentGroup.rdlc";
                    else
                        Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoWithAccountHead.rdlc";

                    Session["dt"] = list;
                }
                else if (isShowConsolidatedSchedule)
                {
                    param.Add("@param_coaId", model.COAId);
                    var list = con.Query<LedgerSubLedgerInfoRptModel>("Rpt_SP_ACC_Schedule",
                        param,
                        commandTimeout: 0,
                        commandType: CommandType.StoredProcedure).ToList();

                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerScheduleConsolidated.rdlc";

                    Session["dt"] = list;
                }
                else if(isAdjustmentSchedure)
                {
                    param.Add("@param_coaId", model.COAId);
                    param.Add("@param_costCenterId", model.CostCenterId);
                    param.Add("@param_IsAdjusted", true);
                    var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_AdjustmentVoucherInfo",
                        param,
                        commandTimeout: 0,
                        commandType: CommandType.StoredProcedure).ToList();

                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCoaAndCostCenter.rdlc";
                    Session["dt"] = list;
                }
                else if (isUnadjustmentSchedure)
                {
                    param.Add("@param_coaId", model.COAId);
                    param.Add("@param_costCenterId", model.CostCenterId);
                    param.Add("@param_IsAdjusted", false);
                    var list = con.Query<LedgerByCoaRptModel>("Rpt_SP_ACC_AdjustmentVoucherInfo",
                        param,
                        commandTimeout: 0,
                        commandType: CommandType.StoredProcedure).ToList();

                    Session["rpath"] = "~/Modules/Reports/Rdlc/RptLedgerInfoByCoaAndCostCenter.rdlc";
                    Session["dt"] = list;
                }

                #endregion
            }
            con.Close();

            //TempData["model"] = model;
            Session["model"] = model;
            return View("~/Modules/Reports/LedgerSubLedgerInfo/LedgerSubLedgerInfoIndex.cshtml", model);
        }
    }
}