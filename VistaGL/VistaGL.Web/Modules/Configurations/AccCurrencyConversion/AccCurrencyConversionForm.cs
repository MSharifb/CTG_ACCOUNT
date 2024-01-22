
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccCurrencyConversion")]
    [BasedOnRow(typeof(Entities.AccCurrencyConversionRow))]
    public class AccCurrencyConversionForm
    {
        public String Currency { get; set; }
        public String Symbol { get; set; }

        [TextAreaEditor(Rows = 5)]
        public String Remarks { get; set; }
        
    }
}