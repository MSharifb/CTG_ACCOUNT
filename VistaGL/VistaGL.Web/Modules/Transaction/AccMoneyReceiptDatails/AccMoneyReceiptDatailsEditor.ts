
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccMoneyReceiptDatailsEditor extends GridEditorBase<AccMoneyReceiptDatailsRow> {
        protected getColumnsKey() { return 'Transaction.AccMoneyReceiptDatails'; }
        protected getDialogType() { return AccMoneyReceiptDatailsEditorDialog; }
                protected getLocalTextPrefix() { return AccMoneyReceiptDatailsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
        validateEntity(row, id) {
            row.CoaAccountName = Configurations.AccChartofAccountsRow.getLookup().itemById[row.CoaId].AccountName;
            row.CostCenterName = AccCostCentreOrInstituteInformationRow.getLookup().itemById[row.CostCenterId].Name;
            return true;
        }
    }
}