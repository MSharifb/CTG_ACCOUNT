
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccChequeRegister")]
    [BasedOnRow(typeof(Entities.AccChequeRegisterRow))]
    public class AccChequeRegisterForm
    {
        [Category("Properties")]

        [CssClass("width6")]
        public DateTime ChequeIssueDate { get; set; }

        [CssClass("width6")]
        public String PayTo { get; set; }

        [CssClass("width6")]
        public Int32 BankAccountInformationId { get; set; }

        [CssClass("width6")]
        public Int32 ChequeBookId { get; set; }

        [OneWay, ReadOnly(true), CssClass("width6"),DisplayName("Account Name")]
        public String AccountName { get; set; }

        [CssClass("width6"), ChequeBookEditor]
        public String ChequeNo { get; set; }

        [OneWay, ReadOnly(true), CssClass("width6"), DisplayName("Bank Name")]
        public String BankName { get; set; }

        [CssClass("width6"), ChequeTypeMappingEditor]
        public String ChequeType { get; set; }

        [OneWay, ReadOnly(true), CssClass("width6"),DisplayName("Branch Name")]
        public String BranchName { get; set; }

        [CssClass("width6")]
        public DateTime ChequeDate { get; set; }

        [CssClass("width6")]
        public Double Amount { get; set; }

        //[CssClass("width6")]
        //public Int32 EntityId { get; set; }

        [CssClass("width12"), TextAreaEditor(Rows = 3)]
        public String Remarks { get; set; }



        [Category("Bank Advice Info")]

        [CssClass("width6"), ReadOnly(true)]
        public Boolean IsBankAdvice { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public DateTime? BankAdviceDate { get; set; }


        [Hidden]
        public Boolean IsFinished { get; set; }

        [Hidden]
        public Decimal ChequeNumhdn { get; set; }

        [Hidden]
        public string ChequeNoTemp { get; set; }


        [Category("Cancel Cheque")]

        [CssClass("width6")]
        public Boolean IsCancelled { get; set; }


        //[CssClass("width6")]
        //public String AmountInWords { get; set; }

        //[CssClass("width6")]
        //public Boolean IsPayment { get; set; }

        //[CssClass("width6")]
        //public Boolean IsUsed { get; set; }

        //[CssClass("width6")]
        //public String PayeeBankName { get; set; }

        //[CssClass("width6")]
        //public String VoucherNo { get; set; }

        //[CssClass("width6")]
        //public Int32 VoucherInformationId { get; set; }
        [Hidden]
        public Boolean isAdjusted { get; set; }
    }
}