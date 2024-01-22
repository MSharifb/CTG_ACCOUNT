using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace VistaGL.Transaction.PublicEndpoints
{
    using Configurations.Entities;
    using System.Globalization;
    //using MyRow = Entities.AccVoucherInformationRow;
    using MyRepository = Repositories.AccVoucherInformationRepository;

    [RoutePrefix("Services/Transaction/AccImportVoucherService"), Route("{action}")]
    //[ConnectionKey(typeof(MyRow))]
    //[ServiceAuthorize(typeof(MyRow))]
    public class AccImportVoucherServiceController : Controller
    {

        /// <summary>
        /// It will return either validation message or Success word or Fail word
        /// </summary>
        /// <param name="voucherAsJson">Serialized json of ServiceParamVoucherInfo object</param>
        /// <returns></returns>
        public JsonResult CreateVoucher(string voucherAsJson)
        {
            try
            {
                var request = new BillingAPIVoucherInfo();
                var outputString = String.Empty;
                var query = String.Empty;
                int zoneId = 0;


                try
                {
                    request = JsonConvert.DeserializeObject<BillingAPIVoucherInfo>(voucherAsJson, Converter.Settings);
                }
                catch (Exception ex)
                {
                    outputString = "Cannot deserialize service parameter:voucher info!" + Environment.NewLine
                        + ex.Message + Environment.NewLine
                        + ex.InnerException?.Message;
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(request.zoneId?.FirstOrDefault()))
                {
                    outputString = "Invalid ZONE!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                using (var connection = SqlConnections.NewByKey("ACCDB"))
                {
                    query = String.Format("SELECT Id FROM PRM_ZoneInfo WHERE ZoneCodeForBillingSystem = '{0}'", request.zoneId.FirstOrDefault());
                    zoneId = connection.Query<int>(query).FirstOrDefault();
                    if (zoneId == 0)
                    {
                        outputString = "Invalid ZONE!";
                        return Json(outputString, JsonRequestBehavior.AllowGet);
                    }
                }

                using (var connection = SqlConnections.NewByKey("ACCDB"))
                {
                    try
                    {
                        var voucherDate = DateTime.ParseExact(request.voucherDate.FirstOrDefault(),
                                                            "dd-MMM-yyyy",
                                                            System.Globalization.CultureInfo.InvariantCulture);
                        String sqlJSONDataHistory =
                            String.Format(@"
                            INSERT INTO acc_ibcs_jsondata_history(VoucherNo, VoucherDate, ZoneId, JSONData, IsSuccess)
                            VALUES('{0}','{1}',{2},'{3}',{4})",
                                request.voucherNo.FirstOrDefault(),
                                Convert.ToDateTime(voucherDate).ToString("yyyy-MM-dd"),
                                zoneId,
                                voucherAsJson,
                                0
                                );
                        connection.Execute(sqlJSONDataHistory);
                    }
                    catch (Exception) { }
                }

                if (request.ApproveStatus == null)
                {
                    outputString = "Invalid voucher approve status (Draft/Approve)!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                if (request.voucherTypeId?.FirstOrDefault() < 1 || request.voucherTypeId?.FirstOrDefault() > 2)
                {
                    outputString = "Invalid VOUCHER TYPE!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(request.voucherNo?.FirstOrDefault()))
                {
                    outputString = "Invalid VOUCHER NO.!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }



                if (!request.voucherDetails.Any())
                {
                    outputString = "Invalid VOUCHER DETAILS!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                //-- Determining Fund Control Id --//
                int? fundControlIDbyCOA = 0;
                String fundControlName = String.Empty;
                var coaId = request.voucherDetails.FirstOrDefault().BILL_TYPE_ID;
                using (var connection = SqlConnections.NewByKey("ACCDB"))
                {
                    fundControlIDbyCOA = connection.Query<int>(@"SELECT fundControlId FROM acc_ChartofAccounts WHERE Id = " + coaId).FirstOrDefault();
                    if ((fundControlIDbyCOA ?? 0) == 0)
                    {
                        outputString = "Invalid FUND CONTROL!";
                        return Json(outputString, JsonRequestBehavior.AllowGet);
                    }

                    fundControlName = connection.Query<String>(@"SELECT fundControlName FROM acc_FundControlInformation WHERE Id = " + fundControlIDbyCOA).FirstOrDefault();
                }


                if (request.voucherTypeId.FirstOrDefault() == Convert.ToInt32(ServiceVoucherType.CreditVoucher))
                {
                    if (String.IsNullOrEmpty(request.bankCoaId?.FirstOrDefault()))
                    {
                        outputString = "Invalid BANK ACCOUNT NUMBER!";
                        return Json(outputString, JsonRequestBehavior.AllowGet);
                    }

                    using (var connection = SqlConnections.NewByKey("ACCDB"))
                    {
                        query = String.Format(@"SELECT COAId FROM acc_BankAccountInformation
                                                WHERE
                                                    accountNumber = '{0}'
                                                    AND entityId = {1}
                                                    AND ZoneInfoId = {2}", request.bankCoaId.FirstOrDefault(), fundControlIDbyCOA, zoneId);

                        var bankCOAId = connection.Query<int>(query).FirstOrDefault();
                        if (bankCOAId == 0)
                        {
                            outputString = "Invalid BANK ACCOUNT NUMBER for the given zone and fund control: " + fundControlName + "!";
                            return Json(outputString, JsonRequestBehavior.AllowGet);
                        }
                    }
                }


                using (var connection = SqlConnections.NewByKey("ACCDB"))
                {
                    if (request.voucherTypeId.FirstOrDefault() == Convert.ToInt32(ServiceVoucherType.CreditVoucher))
                    {
                        query = String.Format(@"SELECT Id FROM acc_BankAccountInformation
                                                WHERE
                                                    accountNumber = '{0}'
                                                    AND entityId = {1}
                                                    AND ZoneInfoId = {2}", request.bankCoaId.FirstOrDefault(), fundControlIDbyCOA, zoneId);

                        var bankAccountId = connection.Query<int>(query).FirstOrDefault();

                        query = String.Format(@"SELECT count(*) FROM acc_voucher_information
                                            WHERE
                                                voucherNo = '{0}'
                                                AND fundControlInformationId = {1}
                                                AND ZoneID = {2}
                                                AND BankAccountInformationId = {3}", request.voucherNo.FirstOrDefault(), fundControlIDbyCOA, zoneId, bankAccountId);

                        outputString = "This voucher number is already exists in this given zone and fund control: " + fundControlName + " and bank account: " + request.bankCoaId.FirstOrDefault() + "!";
                    }
                    else
                    {
                        query = String.Format(@"SELECT count(*)
                                            FROM
                                                acc_voucher_information
                                            WHERE
                                                voucherNo = '{0}'
                                                AND fundControlInformationId = {1}
                                                AND ZoneID = {2}", request.voucherNo.FirstOrDefault(), fundControlIDbyCOA, zoneId);

                        outputString = "This voucher number is already exists in this given zone and fund control: " + fundControlName + "!";
                    }

                    var totalVoucherCount = connection.Query<int>(query).FirstOrDefault();
                    if (totalVoucherCount > 0)
                    {
                        return Json(outputString, JsonRequestBehavior.AllowGet);
                    }
                }


                if (String.IsNullOrEmpty(request.voucherDate?.FirstOrDefault()))
                {
                    outputString = "Invalid VOUCHER DATE!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                if (request.voucherAmount?.FirstOrDefault() == 0)
                {
                    outputString = "Invalid VOUCHER AMOUNT!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(request.receiveFrom?.FirstOrDefault()))
                {
                    outputString = "Invalid 'RECEIVE FROM'!";
                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }

                using (var connection = SqlConnections.NewByKey("ACCDB"))
                {
                    query = String.Format("SELECT Id FROM acc_Cost_Centre_or_Institute_Information WHERE userCode = '{0}'", request.receiveFrom.FirstOrDefault());
                    var subLedgerId = connection.Query<int>(query).FirstOrDefault();
                    if (subLedgerId == 0)
                    {
                        outputString = "Invalid SUB-LEDGER!";
                        return Json(outputString, JsonRequestBehavior.AllowGet);
                    }

                    Boolean isChartofAccIdsValid = true;
                    int billTypeId = 0;
                    var coa = AccChartofAccountsRow.Fields.As("coa");

                    foreach (var v in request.voucherDetails)
                    {
                        //query = String.Format(@"SELECT Id FROM acc_ChartofAccounts
                        //                        WHERE
                        //                            Id = {0}
                        //                            AND fundControlId = {1}", v.BILL_TYPE_ID, fundControlIDbyCOA);

                        var sqlQueryFluent = new SqlQuery()
                            .From(coa)
                            .Select(coa.Id)
                            .Where(coa.Id == v.BILL_TYPE_ID)
                            .Where(coa.FundControlId == Convert.ToInt32(fundControlIDbyCOA));

                        var chartofAcc = connection.Query(sqlQueryFluent)?.FirstOrDefault();

                        if (chartofAcc == null || chartofAcc.Id == 0)
                        {
                            isChartofAccIdsValid = false;
                            billTypeId = v.BILL_TYPE_ID;
                            break;
                        }
                    }

                    if (!isChartofAccIdsValid)
                    {
                        outputString = "Invalid BILL TYPE/ACCOUNT HEAD ID: " + billTypeId + " in given fund control: " + fundControlName + "!";
                        return Json(outputString, JsonRequestBehavior.AllowGet);
                    }


                    // FINNALY CALL CREATE VOUCHER METHOD
                    var result = new MyRepository().CreateVoucher(connection, request);
                    if (result)
                        outputString = "Success";
                    else
                        outputString = "Fail";


                    try
                    {
                        var voucherDate = DateTime.ParseExact(request.voucherDate.FirstOrDefault(),
                                                            "dd-MMM-yyyy",
                                                            System.Globalization.CultureInfo.InvariantCulture);
                        String sqlJSONDataHistory =
                            String.Format(@"INSERT INTO acc_ibcs_jsondata_history(VoucherNo, VoucherDate, ZoneId, FundControlId, JSONData, IsSuccess)
                            VALUES('{0}','{1}',{2},{3},'{4}',{5})",
                                request.voucherNo.FirstOrDefault(),
                                Convert.ToDateTime(voucherDate).ToString("yyyy-MM-dd"),
                                zoneId,
                                fundControlIDbyCOA,
                                voucherAsJson,
                                outputString == "Success" ? 1 : 0
                                );
                        connection.Execute(sqlJSONDataHistory);
                    }
                    catch (Exception) { }

                    return Json(outputString, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message + Environment.NewLine
                    + ex.InnerException?.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public class BillingAPIVoucherDetail
    {
        public int BILL_TYPE_ID { get; set; }
        public Decimal DR_AMOUNT { get; set; }
        public Decimal CR_AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
    }

    public class BillingAPIVoucherInfo
    {
        public BillingAPIVoucherInfo()
        {
            voucherDetails = new List<BillingAPIVoucherDetail>();
            ApproveStatus = ApprovalStatus.Approved;
        }

        public List<string> postingDate { get; set; }
        public List<string> narration { get; set; }
        public List<int> voucherTypeId { get; set; }
        public List<string> clearDate { get; set; }
        public List<BillingAPIVoucherDetail> voucherDetails { get; set; }
        public List<string> receiveFrom { get; set; }
        public List<string> bankCoaId { get; set; }
        public List<Decimal> voucherAmount { get; set; }
        public List<string> voucherNo { get; set; }
        public List<string> voucherDate { get; set; }
        public List<string> zoneId { get; set; }
        public List<string> crNo { get; set; }
        public List<string> chequeNo { get; set; }
        public List<string> entityType { get; set; }

        /// <summary>
        /// 1: Draft
        /// 6: Approve
        /// </summary>
        public ApprovalStatus? ApproveStatus { get; set; }
    }

    public enum ServiceVoucherType
    {
        CreditVoucher = 1,
        JournalVoucher = 2
    }

}
