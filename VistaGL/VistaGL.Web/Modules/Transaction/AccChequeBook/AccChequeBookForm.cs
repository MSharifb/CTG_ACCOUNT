
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccChequeBook")]
    [BasedOnRow(typeof(Entities.AccChequeBookRow))]
    public class AccChequeBookForm
    {

        //public Int32 EntityId { get; set; }
        [CssClass("width6")]
        public Int32 BankAccountInformationId { get; set; }

        [OneWay, Required, ReadOnly(true), DisplayName("Account Name"), CssClass("width6")]
        public String AccountName { get; set; }

        [OneWay,Required, ReadOnly(true),DisplayName("Bank Name"), CssClass("width6")]
        public String BankName { get; set; }

        [OneWay, Required, ReadOnly(true), DisplayName("Branch Name"), CssClass("width6")]
        public String BranchName { get; set; }


        [CssClass("width6")]
        public String CheckBookName { get; set; }

        [CssClass("width6")]
        public DateTime CBDate { get; set; }


        [CssClass("width6")]
        public String StartingNo { get; set; }

        [CssClass("width6")]
        public String Prefix { get; set; }

        [CssClass("width6")]
        public Int32 PageNo { get; set; }

        [ReadOnly(true), CssClass("width6")]
        public Int32 EndingNo { get; set; }

        [CssClass("width6")]
        public Boolean HasFinished { get; set; }

    }
}