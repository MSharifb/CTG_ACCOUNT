
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBankAdviceLetter")]
    [BasedOnRow(typeof(Entities.AccChequeRegisterRow))]
    public class AccBankAdviceLetterColumns
    {
        //[Visible(false)]
        //public Int64 Id { get; set; }

        public String PayTo { get; set; }

        [AlignRight, QuickFilter]
        public Decimal Amount { get; set; }
        [AlignCenter, QuickFilter]
        public String ChequeNo { get; set; }

        [AlignRight, QuickFilter]
        public DateTime ChequeIssueDate { get; set; }

        [QuickFilter]
        public DateTime BankAdviceDate { get; set; }

        [QuickFilter(), FilterOnly]
        [TrueFalseEditor]
        public Boolean IsBankAdvice { get; set; }

        [DisplayName("Account Head Bank"), FilterOnly, QuickFilter]
        [LookupEditor("Configurations.AccCoABank_Lookup")]
        public Int32? BankAccountInformationCoaId { get; set; }
    }
}