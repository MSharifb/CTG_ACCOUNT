
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccFundControlInformation")]
    [BasedOnRow(typeof(Entities.AccFundControlInformationRow))]
    public class AccFundControlInformationColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink]
        public String FundControlName { get; set; }
        public String Code { get; set; }
        public String CurrencyCurrency { get; set; }
        public String CurrencySymbol { get; set; }

    }
}