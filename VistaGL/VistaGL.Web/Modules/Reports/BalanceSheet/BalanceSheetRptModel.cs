using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports
{
    public class BalanceSheetRptModel
    {

        public String accountName { get; set; }
        public String accountGroup { get; set; }
        public Decimal Balance { get; set; }
        public String temporary_head { get; set; }
        public Decimal incomeExpenseBalance { get; set; }
        public String incomeExpenseGroup { get; set; }
        public Decimal Balance2 { get; set; }
        public string ParentGroup { get; set; }
        public string AccountName { get; set; }
        public string Group1 { get; set; }
        public decimal PreBalance { get; set; }
        public string OrderGroup { get; set; }
        public decimal Notes { get; set; }
    }


    public class BalanceSheetRptModel_M1
    {

        public String ReportType { get; set; }
        public Int32 Id { get; set; }
        public Int32 ParentId { get; set; }
        public String ParentName { get; set; }
        public String GroupName { get; set; }
        public Int32 SortingOrder { get; set; }
        public Decimal Total { get; set; }
        public Decimal PreviousYearTotal { get; set; }
        public String Symbol { get; set; }

        public Decimal BalanceBrought { get; set; }
        public Decimal BalanceBroughtPrevious { get; set; }
        public Decimal PriorYearAdjustment { get; set; }
        public Decimal PriorYearAdjustmentPrevious { get; set; }
        public Decimal RentalIncome { get; set; }
        public Decimal RentalIncomePrevious { get; set; }
        public decimal Notes { get; set; }

        public Boolean IsAutoSum { get; set; }
        public decimal CashAndBankBegining { get; set; }
        public decimal CashAndBankEnd { get; set; }
        public decimal CashAndBankBeginingPre { get; set; }
        public decimal CashAndBankEndPre { get; set; }

    }
}