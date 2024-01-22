
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccCurrencyConversionRate")]
    [BasedOnRow(typeof(Entities.AccCurrencyConversionRateRow))]
    public class AccCurrencyConversionRateForm
    {
        public Decimal FirstAmout { get; set; }
        public Int32 FirstCurrency { get; set; }
        public Decimal SecondAmout { get; set; }
        public Int32 SecondCurrency { get; set; }
       
       
    }
}