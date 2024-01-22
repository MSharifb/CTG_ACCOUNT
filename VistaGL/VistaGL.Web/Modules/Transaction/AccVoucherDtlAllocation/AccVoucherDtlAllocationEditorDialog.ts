namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherDtlAllocationEditorDialog extends GridEditorDialog<AccVoucherDtlAllocationRow> {
        protected getFormKey() { return AccVoucherDtlAllocationForm.formKey; }
        protected getLocalTextPrefix() { return AccVoucherDtlAllocationRow.localTextPrefix; }
        protected form = new AccVoucherDtlAllocationForm(this.idPrefix);
        public isDrCr: string;

        onDialogOpen(): void {
            super.onDialogOpen();
            //let subLedgerList = AccCostCentreOrInstituteInformationRow.getLookup().items;
            ////console.log(subLedgerList);
            //for (var item of subLedgerList) {
            //    this.form.CostCenterId.addItem({ id: item.Id.toString(), text: item.Name, source: null, disabled: false });
            //}
        }

        protected getSaveEntity() {
            var entity = super.getSaveEntity();
            console.log(this.isDrCr);
            //   entity.ChartofAccountsAccountName = this.form.ChartofAccountsId.itemById[this.form.ChartofAccountsId.value].text;
            entity.CostCenterName = this.form.CostCenterId.get_text();
            if (this.isDrCr == "Cr")
                entity.CreditAmount = entity.Amount;
            else
                entity.DebitAmount = entity.Amount;

            return entity;
        }
    }
}