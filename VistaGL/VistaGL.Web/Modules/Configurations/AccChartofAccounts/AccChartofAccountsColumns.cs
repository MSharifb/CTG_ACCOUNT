
namespace VistaGL.Configurations.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Configurations.AccChartofAccounts")]
    [BasedOnRow(typeof(Entities.AccChartofAccountsRow))]
    public class AccChartofAccountsColumns
    {

        [Width(100, Min = 100)]
        public String UserCode { get; set; }

        [Width(60, Min = 60), SortOrder(1), AlignCenter]
        public String AccountGroup { get; set; }

        [EditLink, Width(400, Min = 400)]
        public String AccountName { get; set; }

        [COAMappingEditor, FilterOnly, QuickFilter]
        public String CoaMapping { get; set; }

        [FilterOnly, QuickFilter]
        public Boolean IsBudgetHead { get; set; }

        [QuickFilter(), FilterOnly()]
        public Int32 ParentAccountId { get; set; }

        [Width(250, Min = 250)]
        public String ParentAccountAccountName { get; set; }

        public Int32 SortOrder { get; set; }

        [Width(50, Min = 50)]
        public Boolean IsCostCenterAllocate { get; set; }

        [Width(150, Min = 150)]
        public String Remarks { get; set; }
    }
}