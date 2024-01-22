using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.AllVoucherInfo
{
    public class AllVoucherInfoRptModel
    {
        public String VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public String AmountInWords { get; set; }
        public DateTime chequeDate { get; set; }
        public String chequeNo { get; set; }
        public String PowerofAttorney { get; set; }
        public String Description { get; set; }
        public String paytoOrReciveFrom { get; set; }
        public String accountName { get; set; }
        public String coaMapping { get; set; }
        public String UserCode { get; set; }
        public long VoucherDetailId { get; set; }
        public decimal EffectiveValue { get; set; }
        public decimal debitAmount { get; set; }
        public decimal creditAmount { get; set; }
        public String vdtlDescription { get; set; }
        public String name { get; set; }
        public String DetailAllocationuserCode { get; set; }
        public decimal DetailAllocationcreditAmount { get; set; }
        public decimal DetailAllocationdebitAmount { get; set; }

        public string PreparedByName { get; set; }
        public string CheckedByEmployeeName { get; set; }
        public string ApprovedByEmployeeName { get; set; }
        public string PostedByEmployeeName { get; set; }

        public byte[] PreparedBySignature { get; set; }
        public byte[] CheckedByPhotoSignature { get; set; }
        public byte[] ApprovedByPhotoSignature { get; set; }
        public byte[] PostedByPhotoSignature { get; set; }

        public String LinkedAutoJVoucherNo { get; set; }
        public String LinkedAutoDebitVoucherNo { get; set; }

        public string accountNumber { get; set; }
        public string bankName { get; set; }
    }


    public class VoucherInconsistancyRptModel
    {
        public Boolean IsVoucherAmountInconsistancy { get; set; }
        public Boolean IsVoucherInconsistancy { get; set; }
        public Boolean IsChequeRegisterInconsistancy { get; set; }
        public string FundControl { get; set; }
        public Int64 Id { get; set; }
        public string voucherNo { get; set; }
        public DateTime voucherDate { get; set; }
        public string ZoneName { get; set; }
        public Decimal vAmount { get; set; }
        public Decimal creditAmount { get; set; }
        public Decimal debitAmount { get; set; }
        public Decimal voucherAmount { get; set; }
        public Decimal chequeRegisterAmount { get; set; }
        public string voucherLastUpdatedBy { get; set; }
        public string chequeLastUpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class SubledgersWithUnallocatedParentRptModel
    {
        public String SubledgerName { get; set; }
        public String userCode { get; set; }
        public string voucherNo { get; set; }
        public DateTime voucherDate { get; set; }
        public string ZoneName { get; set; }
        public int SortOrder { get; set; }
    }

}