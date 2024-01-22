
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccCurrencyConversionRate")]
    [BasedOnRow(typeof(Entities.AccCurrencyConversionRateRow))]
    public class AccCurrencyConversionRateColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink, AlignRight]
        public Decimal FirstAmout { get; set; }

        [AlignCenter]
        public String FirstCurrencyCurrency { get; set; }

        [AlignRight]
        public Decimal SecondAmout { get; set; }

        [AlignCenter]
        public String SecondCurrencyCurrency { get; set; }
       
       
    }
}