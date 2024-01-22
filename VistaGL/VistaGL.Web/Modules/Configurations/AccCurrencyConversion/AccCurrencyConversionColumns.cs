
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccCurrencyConversion")]
    [BasedOnRow(typeof(Entities.AccCurrencyConversionRow))]
    public class AccCurrencyConversionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String Currency { get; set; }

        [AlignCenter]
        public String Symbol { get; set; }
        public String Remarks { get; set; }
       
    }
}