
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccPriorYearAdjustment")]
    [BasedOnRow(typeof(Entities.AccPriorYearAdjustmentRow), CheckNames = true)]
    public class AccPriorYearAdjustmentColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public String FinancialYearYearName { get; set; }
        public Decimal IncomeTax { get; set; }
        public Decimal Adjustment { get; set; }
    }
}