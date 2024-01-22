
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccChequeRegister")]
    [BasedOnRow(typeof(Entities.AccChequeRegisterRow))]
    public class AccChequeRegisterColumns
    {
        [DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink, Width(100)]
        public String ChequeNo { get; set; }

        [AlignRight, QuickFilter]
        public DateTime ChequeDate { get; set; }

        [AlignCenter, Width(100)]
        public String ChequeType { get; set; }

        [AlignRight, QuickFilter]
        public DateTime ChequeIssueDate { get; set; }

        public String PayTo { get; set; }

        [Width(150)]
        public String BankAccountInformationAccountNumber { get; set; }

        [AlignRight]
        public Double Amount { get; set; }

        [AlignCenter, QuickFilter]
        public Boolean IsCancelled { get; set; }

        //public DateTime ChequeDate { get; set; }
        //public String AmountInWords { get; set; }

        //public Boolean IsPayment { get; set; }


        //public String PayeeBankName { get; set; }
        //public String Remarks { get; set; }
        //public String VoucherNo { get; set; }

        //public Int32 VoucherInformationId { get; set; }
        //public Int32 EntityId { get; set; }
        //public Int32 ChequeBookId { get; set; }

        [AlignCenter, QuickFilter]
        public Boolean IsUsed { get; set; }

        [AlignCenter, QuickFilter]
        public Boolean IsBankAdvice { get; set; }
    }
}