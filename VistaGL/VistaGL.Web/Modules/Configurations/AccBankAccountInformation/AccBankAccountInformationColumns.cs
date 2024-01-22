
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccBankAccountInformation")]
    [BasedOnRow(typeof(Entities.AccBankAccountInformationRow))]
    public class AccBankAccountInformationColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String AccountNumber { get; set; }
        public String AccountName { get; set; }
        public String BankBankName { get; set; }
        public Int32 BankBranchBranchName { get; set; }       
        public String CoaAccountName { get; set; }      
                      
   
    }
}