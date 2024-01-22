
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccViewBudgetDetailsDept")]
    [BasedOnRow(typeof(Entities.AccViewBudgetDetailsDeptRow))]
    public class AccViewBudgetDetailsDeptForm
    {
        public Int32 Id { get; set; }
        public String AccountName { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Int32 ZoneInfoId { get; set; }
        public Int32 BudgetYearId { get; set; }
        public Int32 BudgetStatus { get; set; }
        public Int32 BudgetDepartmentInfoId { get; set; }
        public String BudgetDept { get; set; }
        public String YearName { get; set; }
        public Decimal ActualDuring { get; set; }
        public Decimal Actual1stSixMonths { get; set; }
        public Decimal BudgetApproved { get; set; }
        public Decimal RevisedEstimate { get; set; }
        public Decimal BudgetApproved1Step { get; set; }
    }
}