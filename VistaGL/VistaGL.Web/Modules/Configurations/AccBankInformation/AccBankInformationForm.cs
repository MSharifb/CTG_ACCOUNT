
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccBankInformation")]
    [BasedOnRow(typeof(Entities.AccBankInformationRow))]
    public class AccBankInformationForm
    {
        [Category("Bank Inforamtion")]
        public String BankName { get; set; }
        public String Code { get; set; }

        [Category("Bank Branch Information")]      
        [AccBankBranchInformationEditor]
        public List<Entities.AccBankBranchInformationRow> BankBranchInformations { get; set; }
    }
}