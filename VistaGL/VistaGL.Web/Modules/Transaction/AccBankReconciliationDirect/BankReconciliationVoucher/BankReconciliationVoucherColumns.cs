
namespace VistaGL.Transaction.Columns
{

    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;
    using Configurations.Entities;

    [ColumnsScript("Transaction.BankReconciliationVoucher")]
    [BasedOnRow(typeof(Entities.AccVoucherDetailsRow))]
    public class BankReconciliationVoucherColumns
    {
        [Visible(false)]
        public Int64 VoucherInformationId { get; set; }

        [Width(200)]
        public String VoucherInformationVoucherNo { get; set; }

        [QuickFilter]
        [Width(100), SortOrder(1, descending: true), AlignRight]
        public DateTime VoucherInformationVoucherDate { get; set; }

        [Width(360)]
        public String PaytoOrReciveFrom { get; set; }

        [Width(100, Min = 100), AlignRight, DisplayName("Cheque No."), QuickFilter]
        public String VoucherInformationChequeRegisterNo { get; set; }

        [Width(100, Min = 100), DisplayName("Amount"), AlignRight, QuickFilter]
        public decimal EffectiveValue { get; set; }

        [Width(100, Min = 100), QuickFilter]
        public DateTime ClearDate { get; set; }

        [QuickFilter, FilterOnly]
        [LookupEditor(typeof(Entities.VoucherLookUp))]
        public Int32 VoucherInformationVoucherTypeId { get; set; }

        [Hidden]
        public String Description { get; set; }

        [Hidden]
        public DateTime ChequeRegisterChequeDate { get; set; }

        [QuickFilter, FilterOnly, DisplayName("Bank")]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(AccChartofAccountsRow.CoaMapping), FilterValue = "BANK")]
        public Int32 ChartofAccountsId { get; set; }

        [QuickFilter, FilterOnly]
        [ReconciliationEditor]
        public Int32 IsClearDate { get; set; }
    }
}