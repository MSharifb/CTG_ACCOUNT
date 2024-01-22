using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serenity.Data;

namespace VistaGL.Modules.Common.Dashboard
{
    [ConnectionKey("ACCDB")]
    public class DashboardPrintModel
    {

        public String Title { get; set; }
        public List<DetailModel> Detail { get; set; }
        public List<SubmitDetailModel> SubmitDetail { get; set; }

        public DashboardPrintModel()
        {
            Detail = new List<DetailModel>();
            SubmitDetail = new List<SubmitDetailModel>();
        }


        public class DetailModel
        {
            public Int64 Id { get; set; }
            public String VoucherType { get; set; }
            public String TransactionType { get; set; }
            public String TransactionMode { get; set; }
            public String VoucherNo { get; set; }
            public DateTime? VoucherDate { get; set; }
            public double? Amount { get; set; }
            public String PaytoOrReciveFrom { get; set; }
            public String ChequeNo { get; set; }
            public String ChequeRemarks { get; set; }
            public Boolean? LinkedWithAutoJV { get; set; }
            public int? LinkedVoucherIdForAutoJV { get; set; }
            public String LinkedVoucherNo { get; set; }
            public int ApproveStatus { get; set; }
            public int? PostToLedger { get; set; }
            public String PostedBy { get; set; }
            public DateTime? PostingDate { get; set; }
        }

        public class SubmitDetailModel
        {
            public Int64 VoucherId { get; set; }
            public String VoucherNo { get; set; }
            public bool LinkedWithAutoJV { get; set; }
            public String LinkedVoucherNo { get; set; }
            public int ApproverId { get; set; }
            public int EmployeeId { get; set; }
            public String EmpID { get; set; }
            public String FullName { get; set; }
            public int ApprovalStatusId { get; set; }
            public String ForwardedBy { get; set; }
            public int TotalVoucher { get; set; }
        }
    }

}