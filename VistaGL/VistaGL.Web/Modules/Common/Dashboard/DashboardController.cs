
using Serenity.Data;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using VistaGL.Modules.Reports;
using VistaGL.Transaction.Entities;


namespace VistaGL.Common.Pages
{
    [RoutePrefix("Dashboard"), Route("{action=index}")]
    public class DashboardController : Controller
    {
        [Authorize, HttpGet, Route("~/")]
        public ActionResult Index()
        {
            var user = (UserDefinition)Serenity.Authorization.UserDefinition;
            var model = new DashboardPageModel();

            model.FromDate = DateTime.Now;
            model.ToDate = DateTime.Now;

            if (user != null)
            {
                PrepareModel(model, user.ZoneID, user.FundControlInformationId);
            }

            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }

        [Authorize, HttpPost, Route("~/")]
        public ActionResult Index(DashboardPageModel model)
        {
            if (model.CurrentZone > 0)
            {
                var user = (UserDefinition)Serenity.Authorization.UserDefinition;
                PrepareModel(model, model.CurrentZone, user.FundControlInformationId);
            }

            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }

        //
        private void PrepareModel(DashboardPageModel model, int zoneId, int fundcontrolId)
        {
            #region IMPORT VOUCHER FROM BILLING SYSTEM - TEST
            if (System.IO.File.Exists(@"c:\\JSON from IBCS.txt"))
            {
                //try
                //{
                //    var importVoucherApiUrlPrefix = "http://localhost:81/VistaGL.Web/Services/Transaction/AccImportVoucherService/";

                //    var text = System.IO.File.ReadAllText(@"c:\\JSON from IBCS.txt");
                //    var dataString = text;

                //    var createVoucherUrl = importVoucherApiUrlPrefix + "CreateVoucher?voucherAsJson=" + dataString;

                //    using (var client = new System.Net.WebClient())
                //    {
                //        client.Headers.Add(System.Net.HttpRequestHeader.ContentType, "application/json");

                //        var response = client.UploadString(new Uri(createVoucherUrl), "POST", dataString);
                //    }
                //}
                //catch (System.Net.WebException ex)
                //{
                //    var sr = new System.IO.StreamReader(ex.Response.GetResponseStream(), true);
                //    Response.Write(sr.ReadToEnd());
                //}
            }
            #endregion

            #region Dashboard
            if (zoneId > 0 && fundcontrolId > 0)
            {
                model.CurrentZone = zoneId;

                using (var connection = SqlConnections.NewFor<AccVoucherInformationRow>())
                {
                    //var voucherList = connection.List<AccVoucherInformationRow>(
                    //    AccVoucherInformationRow.Fields.FundControlInformationId == fundcontrolId
                    //                && AccVoucherInformationRow.Fields.ZoneId == model.CurrentZone
                    //    );

                    var tblVoucherAlias = AccVoucherInformationRow.Fields.As("tblVoucherAlias");
                    var vQurey = new SqlQuery()
                        .Select(tblVoucherAlias.FundControlInformationId)
                        .Select(tblVoucherAlias.ZoneId)
                        .Select(tblVoucherAlias.ChequeRegisterId)
                        .Select(tblVoucherAlias.VoucherDate)
                        .Select(tblVoucherAlias.PostToLedger)
                        .Select(tblVoucherAlias.VoucherTypeId)
                        .Select(tblVoucherAlias.LinkedWithAutoJV)
                        .Select(tblVoucherAlias.approveStatus)
                        .From(tblVoucherAlias)
                        .Where(tblVoucherAlias.FundControlInformationId == fundcontrolId &
                               tblVoucherAlias.ZoneId == model.CurrentZone);

                    var voucherList = connection.Query<AccVoucherInformationRow>(vQurey).ToList();

                    model.IssuedCheque = voucherList
                        .Count(x => x.ChequeRegisterId != null
                                    && (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && x.PostToLedger == 1
                                    && x.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher));

                    model.PreparedVoucher = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && x.LinkedWithAutoJV == false
                                    && Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Draft));

                    model.SubmittedVoucher = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && x.LinkedWithAutoJV == false
                                    && (Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Submit)
                                        || Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Recommend)
                                        || Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Regret)));

                    model.ApprovedVoucher = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Approved));

                    model.PostedVoucher = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && x.PostToLedger == 1);

                    model.TotalVoucher = model.PreparedVoucher + model.SubmittedVoucher + model.ApprovedVoucher;

                    #region Bank Transactions

                    var paramStatofBank = new DynamicParameters();
                    paramStatofBank.Add("@paramZoneList", model.myCommaSeparatedZoneIds.ToString());
                    paramStatofBank.Add("@param_fundcontrolId", fundcontrolId);
                    paramStatofBank.Add("@param_FromDate", model.FromDate);
                    paramStatofBank.Add("@param_ToDate", model.FromDate);

                    model.dashboardBankTransactions = connection.Query<DashboardBankTransactionModel>("proc_acc_DashboardBankTransactions",
                        paramStatofBank,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: 0).ToList();

                    #endregion

                    #region STAT OF RECEIPT VOUCHERS FROM BILLING SYSTEM

                    //var paramStatofBillingSystem = new DynamicParameters();
                    //paramStatofBillingSystem.Add("@paramZoneList", model.myCommaSeparatedZoneIds.ToString());
                    //paramStatofBillingSystem.Add("@param_fundcontrolId", fundcontrolId);
                    //paramStatofBillingSystem.Add("@reportDate", model.FromDate);

                    //model.dashboardCollectionFromBillingSystem = connection.Query<DashboardCollectionFromBillingSystemModel>("proc_acc_StatOfBillingSystem",
                    //    paramStatofBillingSystem,
                    //    commandType: CommandType.StoredProcedure,
                    //    commandTimeout: 0).ToList();

                    #endregion

                    #region VOUCHER SUMMARY

                    model.ApprovedChequeVoucher = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Approved)
                                    && x.ChequeRegisterId != null
                                    && x.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher));

                    model.ApprovedOtherVoucher = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Approved)
                                    && (x.VoucherTypeId != Convert.ToInt32(VoucherType.Payment_Voucher)
                                    || x.ChequeRegisterId == null));

                    model.ApprovedOtherPV = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Approved)
                                    && (x.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher)
                                        && x.ChequeRegisterId == null));

                    model.ApprovedOtherRV = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Approved)
                                    && x.VoucherTypeId == Convert.ToInt32(VoucherType.Receipt_Voucher));

                    model.ApprovedOtherJV = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && Convert.ToInt32(x.approveStatus) == Convert.ToInt32(ApprovalStatus.Approved)
                                    && x.VoucherTypeId == Convert.ToInt32(VoucherType.Journal_Voucher));

                    model.NumberofChequeVoucher = voucherList
                        .Count(x => (x.VoucherDate >= model.FromDate && x.VoucherDate <= model.ToDate)
                                    && x.ChequeRegisterId != null
                                    && x.VoucherTypeId == Convert.ToInt32(VoucherType.Payment_Voucher));

                    model.NumberofChequePrepared = (from v in voucherList
                                                    where (v.VoucherDate >= model.FromDate && v.VoucherDate <= model.ToDate)
                                                        && v.IsChequePrepared == true
                                                    select v.Id).Count();

                    #endregion

                    #region Today's Receipt & Payment
                    //var user = (UserDefinition)Serenity.Authorization.UserDefinition;

                    //DynamicParameters param = new DynamicParameters();
                    //param.Add("@paramZoneList", model.CurrentZone.ToString());
                    //param.Add("@param_fundcontrolId", fundcontrolId);
                    //param.Add("@param_level", 1);
                    //param.Add("@param_fromDate", DateTime.Now.Date);
                    //param.Add("@param_toDate", DateTime.Now.Date.AddDays(1));

                    //var todaysReceiptPayment = connection.Query<ReceiptPaymentRptModel>("proc_acc_paymentReceive", param,
                    //    commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList();

                    //model.TodayOpeningBalance = todaysReceiptPayment.Where(w => w.tempSerial == 1).ToList().Sum(s => s.sumAmount);
                    //model.TodayReceiptAmount = todaysReceiptPayment.Where(w => w.tempSerial == 2).ToList().Sum(s => s.sumAmount);
                    //model.TodayPaymentAmount = todaysReceiptPayment.Where(w => w.tempSerial == 3).ToList().Sum(s => s.sumAmount);
                    //model.TodayClosingBalance = todaysReceiptPayment.Where(w => w.tempSerial == 4).ToList().Sum(s => s.sumAmount);

                    #endregion

                }
            }
            #endregion
        }

    }
}