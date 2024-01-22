
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Transaction.AccCostCentreOrInstituteInformation")]
    [BasedOnRow(typeof(Entities.AccCostCentreOrInstituteInformationRow))]
    public class AccCostCentreOrInstituteInformationColumns
    {

        [Hidden]
        public String Code { get; set; }

        [Width(120, Min = 120)]
        public String UserCode { get; set; }

        [EditLink, Width(300, Min = 300)]
        public String Name { get; set; }

        [Width(50, Max = 50), QuickFilter, AlignCenter]
        public Boolean IsInstitute { get; set; }

        [Width(250, Min = 250), SortOrder(1)]
        public String ParentName { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 CostCenterTypeId { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 ParentId { get; set; }

        [Width(100, Max = 100), AlignRight]
        public Int64 TotalVoucherDtlAlo { get; set; }

        [Width(250, Min = 250)]
        public String ZoneName { get; set; }
    }
}