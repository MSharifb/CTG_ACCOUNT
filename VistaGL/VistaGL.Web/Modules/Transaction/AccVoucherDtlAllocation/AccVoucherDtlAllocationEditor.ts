
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccVoucherDtlAllocationEditor extends GridEditorBase<AccVoucherDtlAllocationRow> {
        protected getColumnsKey() { return 'Transaction.AccVoucherDtlAllocation'; }
        protected getDialogType() { return AccVoucherDtlAllocationEditorDialog; }
        protected getLocalTextPrefix() { return AccVoucherDtlAllocationRow.localTextPrefix; }
        public isDrCr: string;
        constructor(container: JQuery) {
            super(container);
        }

        protected initEntityDialog(itemType: string, dialog: Serenity.Widget<any>) {
            super.initEntityDialog(itemType, dialog);

            // passing category ID from grid editor to detail dialog
            var _dialog = (dialog as AccVoucherDtlAllocationEditorDialog);
            _dialog.isDrCr = this.isDrCr;

        }

        validateEntity(row: AccVoucherDtlAllocationRow, id) {
            row.CostCenterId = Q.toId(row.CostCenterId);

            var sameCostCenter = Q.tryFirst(this.view.getItems(), x => x.CostCenterId === row.CostCenterId);
            if (sameCostCenter && this.id(sameCostCenter) !== id) {
                Q.alert('This Sub Ledger is already exist!');
                return false;
            }

            return true;
        }
    }
}