
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccViewBudgetDetails")]
    [BasedOnRow(typeof(Entities.AccViewBudgetDetailsRow))]
    public class AccViewBudgetDetailsColumns
    {
        //public Int32 Id { get; set; }
        //[EditLink]
      //  public String AccountName { get; set; }
        //  public Decimal Quantity { get; set; }
        public String ZoneName { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Amount1 { get; set; }
        //public Int32 BudgetRevisionNo { get; set; }
        //public Int32 BudgetDepartmentInfoId { get; set; }
        //public Int32 ZoneInfoId { get; set; }
        //public Int32 EntityId { get; set; }
        //public Int32 BudgetYearId { get; set; }
        //public Int32 BudgetStatus { get; set; }

        //  public String BudgetDept { get; set; }
        //   public String YearName { get; set; }
        //   public String FundControlName { get; set; }
    }
}