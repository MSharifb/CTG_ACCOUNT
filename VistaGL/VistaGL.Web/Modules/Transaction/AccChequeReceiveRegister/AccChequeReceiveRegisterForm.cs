
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccChequeReceiveRegister")]
    [BasedOnRow(typeof(Entities.AccChequeReceiveRegisterRow))]
    public class AccChequeReceiveRegisterForm
    {

        [CssClass("width12")]
        public String RecieveFrom { get; set; }

        [CssClass("width6")]
        public DateTime ChequeReceiveDate { get; set; }


        [CssClass("width6"), DefaultValue("-")]
        public String AccountNo { get; set; }

        [CssClass("width6"), RecChequeTypeMappingEditor]
        public String ReceiveType { get; set; }

        [CssClass("width6"), DefaultValue("-")]
        public String AccountName { get; set; }

        [CssClass("width6")]
        public String ChequeNo { get; set; }

        [CssClass("width6"), DefaultValue("-")]
        public String BankName { get; set; }

        [CssClass("width6"), ChequeTypeMappingEditor]
        public String ChequeType { get; set; }

        [CssClass("width6"), DefaultValue("-")]
        public String BranchName { get; set; }

        [CssClass("width6")]
        public DateTime ChequeDate { get; set; }

        [CssClass("width6"),AlignRight]
        public Double Amount { get; set; }

        [CssClass("width12"), TextAreaEditor(Rows = 5)]
        public String Remarks { get; set; }

        [Hidden]
        public Boolean IsCancelled { get; set; }

        [Hidden]
        public Boolean IsUsed { get; set; }

        //[CssClass("width6")]
        //public String AmountInWords { get; set; }

        //[CssClass("width6")]
        //public Int32 EntityId { get; set; }




    }
}