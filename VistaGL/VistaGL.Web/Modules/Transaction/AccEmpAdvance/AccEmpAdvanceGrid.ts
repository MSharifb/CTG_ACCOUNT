
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccEmpAdvanceGrid extends EntityGridBase<AccEmpAdvanceRow, any> {
        protected getColumnsKey() { return 'Transaction.AccEmpAdvance'; }
        protected getDialogType() { return AccEmpAdvanceDialog; }
        protected getIdProperty() { return AccEmpAdvanceRow.idProperty; }
        protected getLocalTextPrefix() { return AccEmpAdvanceRow.localTextPrefix; }
        protected getService() { return AccEmpAdvanceService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected subDialogDataChange() {
            super.subDialogDataChange();
            this.refresh();
            // Q.reloadLookup("Transaction.AccCostCentreOrInstituteInformation_Lookup");
        }
    }
}