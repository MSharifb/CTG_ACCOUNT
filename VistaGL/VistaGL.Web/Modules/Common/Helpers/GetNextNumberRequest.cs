
using System;

namespace VistaGL
{
    using Serenity.Services;

    public class GetApproverInfoByApplicantRequest : ServiceRequest
    {
        public int? ApprovalStepTypeId { get; set; }
    }

    public class GetNewVoucherNoRequest : ServiceRequest
    {
        public int TransactionTypeId { get; set; }
        public int FundControlInformationId { get; set; }
        public DateTime VoucherDate { get; set; }
        public int ZoneId { get; set; }
        public int FinancialYearId { get; set; }
        public int? BankAccId { get; set; }
    }

    public class GetNewVoucherNoResponse : ServiceResponse
    {
        public String VoucherNo { get; set; }
        public String VoucherNumber { get; set; }
    }

    public class CheckIsApproverResponse : ServiceResponse
    {
        public Boolean IsApprover { get; set; }
    }

    public class StringMessageResponse : ServiceResponse
    {
        public String OutoutMessage { get; set; }
    }

}