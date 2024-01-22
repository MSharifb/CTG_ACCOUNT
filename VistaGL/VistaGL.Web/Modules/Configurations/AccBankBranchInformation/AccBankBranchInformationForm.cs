
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccBankBranchInformation")]
    [BasedOnRow(typeof(Entities.AccBankBranchInformationRow))]
    public class AccBankBranchInformationForm
    {

        public String BranchName { get; set; }
        [TextAreaEditor(Rows = 5)]
        public String Address { get; set; }        
        public String Contacts { get; set; }
        public String Email { get; set; }
        public String Code { get; set; }
        //  public Int32 BankId { get; set; }
    }
}