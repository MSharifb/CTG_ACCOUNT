
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBudgetCreation")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentDetailRow), CheckNames = true)]
    public class AccBudgetCreationColumns
    {
        [ReadOnly(true), QuickFilter]
        public String BudgetHeadName { get; set; }
        public Decimal ProposedBudgetAmount { get; set; }
        public Decimal RevisedEstimateAmount { get; set; }
        [ReadOnly(true)]
        public Decimal ActualFirstSixMonths { get; set; }
        [ReadOnly(true)]
        public Decimal BudgetApproved { get; set; }
        [ReadOnly(true)]
        public Decimal ActualDuring { get; set; }
        [QuickFilter(), FilterOnly]
        public Int32 CircularFinancialYearId { get; set; }
        [QuickFilter(), FilterOnly]
        public Int32? BudgetForDepartmentDepartmentId { get; set; }
        [QuickFilter(), FilterOnly]
        public Int32? BudgetForDepartmentZoneId { get; set; }
    }
}