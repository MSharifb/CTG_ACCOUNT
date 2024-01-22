
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccBudgetCircular")]
    [BasedOnRow(typeof(Entities.AccBudgetCircularRow), CheckNames = true)]
    public class AccBudgetCircularForm
    {
        public Int32 FinancialYearId { get; set; }
        public Boolean IsActive { get; set; }
    }
}