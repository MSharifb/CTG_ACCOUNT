
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccPriorYearAdjustment")]
    [BasedOnRow(typeof(Entities.AccPriorYearAdjustmentRow), CheckNames = true)]
    public class AccPriorYearAdjustmentForm
    {
        public Int32 FinancialYearId { get; set; }
        public Decimal IncomeTax { get; set; }
        public Decimal Adjustment { get; set; }
    }
}