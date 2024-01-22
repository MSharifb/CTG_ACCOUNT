
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccCostCentreOrInstituteInformationGrid extends EntityGridBase<AccCostCentreOrInstituteInformationRow, any> {
        protected getColumnsKey() { return 'Transaction.AccCostCentreOrInstituteInformation'; }
        protected getDialogType() { return AccCostCentreOrInstituteInformationDialog; }
        protected getIdProperty() { return AccCostCentreOrInstituteInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccCostCentreOrInstituteInformationRow.localTextPrefix; }
        protected getService() { return AccCostCentreOrInstituteInformationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);

            new Serenity.TreeGridMixin<AccCostCentreOrInstituteInformationRow>({
                grid: this,
                getParentId: x => x.ParentId,
                toggleField: AccCostCentreOrInstituteInformationRow.Fields.Name,
                initialCollapse: () => false
            });
        }

        protected subDialogDataChange() {
            super.subDialogDataChange();
            Q.reloadLookup("Transaction.AccCostCentreOrInstituteInformation_Lookup");
        }

        protected usePager() {
            return true;
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 500;
            return opt;
        }

        protected getColumns() {
            var columns = super.getColumns();
            columns.splice(Q.indexOf(columns, x => x.name == "Is Parent?") + 1, 0, {
                field: 'Add Child',
                name: '',
                format: ctx => '<a class="inline-action add-child-unit" title="add child"></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number) {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            if (target.parent().hasClass('inline-action'))
                target = target.parent();

            if (target.hasClass('inline-action')) {
                e.preventDefault();

                if (target.hasClass('add-child-unit')) {
                    if (item.IsInstitute == true) {
                        var _items = this.getItems().filter(p => p.ParentId == item.Id);
                        //console.log(_items);

                        var max_ = Math.max.apply(Math, _items.map(function (o) { return o.UserCode; }));
                        //console.log(max_);
                        if (max_.toString() == "NaN" || max_.toString() == "-Infinity")
                            max_ = 1;
                        else
                            max_++;

                        var dlg = new AccCostCentreOrInstituteInformationDialog();
                        this.initDialog(dlg);
                        dlg.loadEntityAndOpenDialog({
                            CostCenterTypeId: item.CostCenterTypeId,
                            ParentId: item.Id,
                            Code: item.Code,
                            CodeCount: max_,
                            AccountCodeClient: item.Code + "." + max_,
                            UserCode: max_.toString().padStart(_items[0].UserCode.length, "0")
                        });

                    } else {
                        Q.alert("Selected sub-ledger is not Parent! Mark it as parent first to add child!");
                    }
                }
            }
        }

    }
}