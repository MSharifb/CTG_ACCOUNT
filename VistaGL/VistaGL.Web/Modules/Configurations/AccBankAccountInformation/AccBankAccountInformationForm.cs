
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccBankAccountInformation")]
    [BasedOnRow(typeof(Entities.AccBankAccountInformationRow))]
    public class AccBankAccountInformationForm
    {
        [Visible(false)]
        public Int32? Id { get; set; }

        [Category("Bank & Branch Inforamtion")]
        public Int32 BankId { get; set; }

        public Int32 BankBranchId { get; set; }

        [Category("Accounts Inforamtion")]
        public Int32 CoaId { get; set; }

        public String AccountName { get; set; }

        public String AccountNumber { get; set; }

        public String Code { get; set; }

        [TextAreaEditor(Rows = 5)]
        [DisplayName("Description")]
        public String AccountDescription { get; set; }

        //[DisplayName("Opening Balance")]
        //public decimal OpeningBalance { get; set; }

        //[DisplayName("Opening Date")]
        //public DateTime OpeningDate { get; set; }

        //public Int32 EntityId { get; set; }
    }
}