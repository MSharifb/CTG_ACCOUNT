
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccBankBranchInformation")]
    [BasedOnRow(typeof(Entities.AccBankBranchInformationRow))]
    public class AccBankBranchInformationColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink]
        public String BranchName { get; set; }
        public String Address { get; set; } 
        public String Contacts { get; set; }
        public String Email { get; set; }
        public String Code { get; set; }
        //public Int32 BankId { get; set; }
    }
}