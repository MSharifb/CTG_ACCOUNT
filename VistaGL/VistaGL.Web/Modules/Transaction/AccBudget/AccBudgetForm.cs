
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccBudget")]
    [BasedOnRow(typeof(Entities.AccBudgetRow), CheckNames = true)]
    public class AccBudgetForm
    {
        [HalfWidth]
        public Int32 FinancialYearId { get; set; }
        [Hidden]
        public Int32 ZoneInfoId { get; set; }
        [Hidden]
        public Int32 EntityId { get; set; }
        public Boolean IsApproved { get; set; }
        [AccBudgetDetailsEditor]
        public List<Entities.AccBudgetDetailsRow> BudgetDetails { get; set; }
        [MultipleFileUploadEditor]
        public String Attachment { get; set; }
    }
}