
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccViewBudgetZone")]
    [BasedOnRow(typeof(Entities.AccViewBudgetZoneRow))]
    public class AccViewBudgetZoneForm
    {
        public Int32 Id { get; set; }
        public String AccountName { get; set; }
        public Int32 BudgetYearId { get; set; }
        public Int32 BudgetStatus { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Int32 ZoneInfoId { get; set; }
    }
}