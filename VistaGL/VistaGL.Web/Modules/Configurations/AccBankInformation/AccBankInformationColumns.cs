
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccBankInformation")]
    [BasedOnRow(typeof(Entities.AccBankInformationRow))]
    public class AccBankInformationColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String BankName { get; set; }
        public String Code { get; set; }
    }
}