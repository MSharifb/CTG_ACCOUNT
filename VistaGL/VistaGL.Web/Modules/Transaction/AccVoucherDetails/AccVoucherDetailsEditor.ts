

namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccVoucherDetailsEditor extends GridEditorBase<AccVoucherDetailsRow> {
        protected getColumnsKey() { return 'Transaction.AccVoucherDetails'; }
        protected getDialogType() { return AccVoucherDetailsEditorDialog; }
        protected getLocalTextPrefix() { return AccVoucherDetailsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        onItemsChanged() {
            //
            let parentDialog = (this.parentDialog as any);
            if (parentDialog) {
                setTimeout(() => {
                    parentDialog.sumDebitCredit();
                });
            }
        }

        deleteEntity(id: number): boolean {
            //--
            let parentDialog = this.parentDialog as any;
            //
            if (parentDialog.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                var item = this.view.getItemById(id);

                if (item.Id != undefined) {
                    let linkedDetail = AccVoucherDetailsRow.getLookup().items.filter(i => i.LinkedJVDetailId == item.Id);

                    if (linkedDetail != undefined && linkedDetail.length > 0) {
                        Q.notifyWarning(
                            "This journal voucher entity has a relation with auto payment voucher entity! " +
                            "You cannot delete this entity! " +
                            "In this case, You have to delete whole voucher and re-enter again.");

                        return false;
                    }
                }
            }
            //
            this.view.deleteItem(id);
            this.onItemsChanged();
            return true;
        }

        editItem(entityOrId): void {
            //--
            let parentDialog = this.parentDialog as any;

            if (parentDialog.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                if (parentDialog.form.LinkedWithAutoJV.value == true) {
                    Q.notifyWarning(
                        "This voucher has an auto journal voucher! " +
                        "Please make sure that you have done necessary change in journal voucher also!");
                }
            }

            super.editItem(entityOrId);
        }

        public C_editItem(id: number) {
            //
            this.editItem(id);
        }

        public C_NewItem(_row: AccVoucherDetailsRow) {
            //
            this.createEntityDialog(this.getItemType(), dlg => {
                var dialog = dlg as AccVoucherDetailsEditorDialog;
                dialog.parentEditor = this;
                dialog.onSave = (opt, callback) => this.save(opt, callback);
                dialog.loadEntityAndOpenDialog(this.getNewEntity());
            });

        }

        validateEntity(row: AccVoucherDetailsRow, id) {
            //
            row.ChartofAccountsId = Q.toId(row.ChartofAccountsId);
            return true;
        }
    }
}