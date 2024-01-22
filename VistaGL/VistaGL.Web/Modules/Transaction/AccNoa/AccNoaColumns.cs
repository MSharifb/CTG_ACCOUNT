
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Transaction.AccNoa")]
    [BasedOnRow(typeof(Entities.AccNoaRow))]
    public class AccNoaColumns
    {
        [EditLink, Width(210, Min = 210)]
        public String NoaNumber { get; set; }

        [DisplayName("NOA Date"), QuickFilter, AlignRight, Width(100, Min = 100)]
        public DateTime NoaDate { get; set; }

        [QuickFilter, Width(250, Min = 250)]
        public String NameofContract { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 CostCenterId { get; set; }

        [DisplayName("Party Name"), Width(250, Min = 250)]
        public String CostCenterName { get; set; }

        [Width(150), QuickFilter]
        public Decimal ContactValue { get; set; }

        public Decimal BudgetProvision { get; set; }

        [Width(200, Min = 200)]
        public String NameofContractor { get; set; }

        [Width(100, Min = 100), AlignRight]
        public DateTime ContractDate { get; set; }

        [AlignRight]
        public DateTime? WorkStartOn { get; set; }

        [AlignRight]
        public DateTime? CompilationDate { get; set; }
    }
}