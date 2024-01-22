
namespace VistaGL.Configurations {

    import fld = AccChartofAccountsRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccChartofAccountsGrid extends EntityGridBase<AccChartofAccountsRow, any> {
        protected getColumnsKey() { return 'Configurations.AccChartofAccounts'; }
        protected getDialogType() { return AccChartofAccountsDialog; }
        protected getIdProperty() { return AccChartofAccountsRow.idProperty; }
        protected getLocalTextPrefix() { return AccChartofAccountsRow.localTextPrefix; }
        protected getService() { return AccChartofAccountsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);

            this.setTitle("Chart of Accounts (Ledger)");

            var tree = new Serenity.TreeGridMixin<AccChartofAccountsRow>({
                grid: this,
                getParentId: x => x.ParentAccountId,
                toggleField: AccChartofAccountsRow.Fields.AccountName,
                initialCollapse: () => false
            });
        }

        createSlickGrid(): Slick.Grid {

            var grid = super.createSlickGrid();
            grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider);

            return grid;

        }

        protected subDialogDataChange() {
            super.subDialogDataChange();

            Q.reloadLookup(AccChartofAccountsRow.lookupKey);
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

            columns.splice(Q.indexOf(columns, x => x.name == "Account Head") + 1, 0, {
                field: 'Add Posting Head',
                name: '',
                format: ctx => '<a class="inline-action add-child-unit" title="add posting head"></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            Q.first(columns, x => x.field == fld.AccountName).cssClass += " col-account-head";

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
                    if (item.IsControlhead == 1 && item.AccountGroup != "Root") {
                        var _items = this.getItems().filter(p => p.ParentAccountId == item.Id);
                        var max_ = Math.max.apply(Math, _items.map(function (o) { return o.AccountCodeCount; }));

                        if (max_.toString() == "NaN" || max_.toString() == "-Infinity")
                            max_ = 1;
                        else
                            max_++;

                        var dlg = new AccChartofAccountsDialog();
                        this.initDialog(dlg);

                        dlg.loadEntityAndOpenDialog({
                            ParentAccountId: item.Id,
                            FundControlId: item.FundControlId,
                            AccountGroup: item.AccountGroup,
                            AccountCode: item.AccountCode,
                            AccountCodeCount: max_,
                            Level: item.Level + 1
                            //, AccountCodeClient: item.AccountCode + "." + max_
                        });
                    } else {
                        Q.warning("it's not Control head");
                    }
                }
            }
        }

        protected getButtons() {
            var b = super.getButtons();

            b.push({
                title: 'Group By Account Group',
                cssClass: 'expand-all-button',
                onClick: () => this.view.setGrouping([
                    {
                        getter: 'AccountGroup'
                    }])
            });

            b.push({
                title: 'No Grouping',
                cssClass: 'collapse-all-button',
                onClick: () => this.view.setGrouping([])
            });

            return b;
        }

        getQuickSearchFields(): Serenity.QuickSearchField[] {

            let txt = (s) => Q.text("Db." + AccChartofAccountsRow.localTextPrefix + "." + s).toLowerCase();

            return [
                { name: "", title: "all" },
                { name: fld.UserCode, title: txt(fld.UserCode) },
                { name: fld.AccountGroup, title: txt(fld.AccountGroup) },
                { name: fld.AccountName, title: txt(fld.AccountName) },
                { name: fld.ParentAccountAccountName, title: txt(fld.ParentAccountAccountName) }
            ];

        }

        getItemCssClass(item: Configurations.AccChartofAccountsRow, index: number): string {
            let klass: string = "";

            if (item.IsControlhead) {
                klass += " control-head";
            }

            return Q.trimToNull(klass);
        }
    }
}