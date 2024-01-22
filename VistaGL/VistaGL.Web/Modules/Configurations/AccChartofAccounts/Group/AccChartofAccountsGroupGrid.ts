
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccChartofAccountsGroupGrid extends EntityGridBase<AccChartofAccountsRow, any> {
        protected getColumnsKey() { return 'Configurations.AccChartofAccounts'; }
        protected getDialogType() { return AccChartofAccountsDialog; }
        protected getIdProperty() { return AccChartofAccountsRow.idProperty; }
        protected getLocalTextPrefix() { return AccChartofAccountsRow.localTextPrefix; }
        protected getService() { return AccChartofAccountsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Chart of Accounts Group");
            new Serenity.TreeGridMixin<AccChartofAccountsRow>({
                grid: this,
                getParentId: x => x.ParentAccountId,
                toggleField: AccChartofAccountsRow.Fields.AccountName,
                initialCollapse: () => false
            });
        }

        protected subDialogDataChange() {
            super.subDialogDataChange();

            Q.reloadLookup(AccChartofAccountsRow.lookupKey);
        }

        protected usePager() {
            return false;
        }

        protected getColumns() {
            var columns = super.getColumns();

            columns.splice(Q.indexOf(columns, x => x.name == "Account Head") + 1, 0, {
                field: 'Add Child',
                name: '',
                format: ctx => '<a class="inline-action add-child-unit" title="add child"></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });
            //columns.splice(Q.indexOf(columns, x => x.name == AccChartofAccountsRow.Fields.AccountName) + 1, 0, {
            //    field: 'Add Child Unit',
            //    name: '',
            //    format: ctx => '<a class="inline-action add-child-unit" title="add child unit"></a>',
            //    width: 24,
            //    minWidth: 24,
            //    maxWidth: 24
            //});

            return columns;
        }
          protected addButtonClick() {
            //this.editItem(<AccChartofAccountsRow>{
            //    IsControlhead: true
            //});
               var dlg = new AccChartofAccountsDialog();
                        this.initDialog(dlg);
                        dlg.isGroup=true;
                        dlg.loadEntityAndOpenDialog({

                         });
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
                    if (item.IsControlhead == 1 && item.AccountGroup != "Root") {
                        var _items = this.getItems().filter(p => p.ParentAccountId == item.Id);

                        var max_ = Math.max.apply(Math, _items.map(function (o) { return o.AccountCodeCount; }));

                        if (max_.toString() == "NaN" || max_.toString() == "-Infinity")
                            max_ = 1;
                        else
                            max_++;

                        var dlg = new AccChartofAccountsDialog();
                        this.initDialog(dlg);
                        dlg.isGroup=true;
                        dlg.loadEntityAndOpenDialog({
                            ParentAccountId: item.Id,
                            FundControlId: item.FundControlId,
                            AccountGroup: item.AccountGroup,
                            AccountCode: item.AccountCode,
                            AccountCodeCount: max_, Level: item.Level + 1
                            //,                            AccountCodeClient: item.AccountCode + "." + max_
                        });
                    } else {
                        Q.alert("it's not Controlhead");
                    }
                }
            }
        }

        protected onViewSubmit() {
            // only continue if base class returns true (didn't cancel request)
            if (!super.onViewSubmit()) {
                return false;
            }

            // view object is the data source for grid (SlickRemoteView)
            // this is an EntityGrid so its Params object is a ListRequest
            var request = this.view.params as Serenity.ListRequest;

            // list request has a Criteria parameter
            // we AND criteria here to existing one because
            // otherwise we might clear filter set by
            // an edit filter dialog if any.

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['IsControlhead'], '=', 1]);

            // TypeScript doesn't support operator overloading
            // so we had to use array syntax above to build criteria.

            // Make sure you write
            // [['Field'], '>', 10] (which means field A is greater than 10)
            // not
            // ['A', '>', 10] (which means string 'A' is greater than 10

            return true;
        }


        //protected getButtons() {
        //    var b = super.getButtons();
        //    b.shift();

        //    return b;
        //}
    }
}