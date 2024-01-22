using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VistaGL
{
    public class CommonEnum
    {
    }

    [EnumKey("BudgetTypeenum"), ScriptInclude]
    public enum BudgetTypeenum
    {

        [Description("Proposed")]
        Proposed = 1,
        [Description("Revised")]
        Revised = 2
    }

    [EnumKey("COAMapping"), ScriptInclude]
    public enum COAMapping
    {
        [Description("Bank")]
        Bank,
        [Description("Cash")]
        Cash,
        [Description("Other")]
        Other
    }

    [EnumKey("RTransferType"), ScriptInclude]
    public enum RTransferType
    {
        [Description("Bank to Bank")]
        BanktoBank,
        [Description("Bank to Cash")]
        BanktoCash,
        [Description("Cash to Bank")]
        CashtoBank

    }

    [EnumKey("ApprovalStatus"), ScriptInclude]
    public enum ApprovalStatus
    {
        [Description("Draft")]
        Draft = 1,
        [Description("Cancel")]
        Cancel = 2,
        [Description("Submit")]
        Submit = 3,
        [Description("Regret")]
        Regret = 4,
        [Description("Recommend")]
        Recommend = 5,
        [Description("Approved")]
        Approved = 6
    }

    [EnumKey("SignatureType"), ScriptInclude]
    public enum SignatureType
    {
        [Description("Prepared By")]
        PreparedBy = 1,
        [Description("Checked By")]
        CheckedBy = 2,
        [Description("Approved By")]
        ApprovedBy = 3,
        [Description("Posted By")]
        PostedBy = 4
    }

    //[EnumKey("ChequeTypeMapping"), ScriptInclude]
    //public enum ChequeTypeMapping
    //{
    //    [Description("Account Payee")]
    //    AccountPayee,
    //    [Description("Cash Cheque")]
    //    CashCheque
    //}

    //[EnumKey("RecChequeTypeMapping"), ScriptInclude]
    //public enum RecChequeTypeMapping
    //{
    //    [Description("Cheque")]
    //    Cheque,
    //    [Description("DD")]
    //    DD,
    //    [Description("PO")]
    //    PO
    //}


    [EnumKey("EffectinCashFlow"), ScriptInclude]
    public enum EffectinCashFlow
    {
        [Description("Investing")]
        Investing,
        [Description("Operating")]
        Operating,
        [Description("Financing")]
        Financing
    }

    [EnumKey("VoucherType"), ScriptInclude]
    public enum VoucherType
    {
        [Description("Payment Voucher")]
        Payment_Voucher = 1,
        [Description("Receipt Voucher")]
        Receipt_Voucher = 2,
        [Description("Journal Voucher")]
        Journal_Voucher = 3,
        [Description("Transfer Voucher")]
        Transfer_Voucher = 4
    }

    //[EnumKey("BillType"), ScriptInclude]
    //public enum eBillType
    //{
    //    [Description("New")]
    //    New,
    //    [Description("Advance")]
    //    Advance,
    //    [Description("Against")]
    //    Against
    //}

    [EnumKey("ApprovalStepType"), ScriptInclude]
    public enum ApprovalStepType
    {
        [Description("Approval")]
        Approval = 1,
        [Description("Recommendation")]
        Recommendation = 2,
        [Description("Both")]
        Both = 3
    }

    [EnumKey("AccType"), ScriptInclude]
    public enum AccHeadTypeMappingEnum
    {
        [Description("S.D.")]
        SD = 1,
        [Description("I.TAX")]
        IncomeTax = 2,
        [Description("VAT")]
        VAT = 3,
        [Description("ADVANCE")]
        Advance = 4,
        [Description("WIP")]
        WIP = 5
    }


    public enum MoneyReceiptReportSource
    {
        FromReceiptVoucher = 1,
        FromMoneyReceiptPage = 2
    }


    public enum FixedAssetDevWorkType
    {
        [Description("Fixed Asset for Dev, Work")]
        IsFixedAssetDevWork = 1,
        [Description("Fixed Asset for Non-Dev, Work")]
        IsFixedAssetNonDevWork = 2
    }

}