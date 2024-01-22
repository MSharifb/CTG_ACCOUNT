
namespace VistaGL.Transaction {

    import fld = AccViewBudgetRow.Fields;
    @Serenity.Decorators.registerClass()
    export class AccViewBudgetGrid extends Serenity.EntityGrid<AccViewBudgetRow, any> {
        protected getColumnsKey() { return 'Transaction.AccViewBudget'; }
        protected getDialogType() { return AccViewBudgetDialog; }
        protected getLocalTextPrefix() { return AccViewBudgetRow.localTextPrefix; }
        protected getService() { return AccViewBudgetService.baseUrl; }
        protected getIdProperty() { return "__id"; }
        constructor(container: JQuery) {
            super(container);
        }

        private nextId = 1;


        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<AccViewBudgetRow>) {
            response = super.onViewProcessData(response);

            // there is no __id property in SalesByCategoryRow but
            // this is javascript and we can set any property of an object
            for (var x of response.Entities) {
                (x as any).__id = this.nextId++;
            }
            return response;
        }

        protected getButtons() {
            var b = super.getButtons();
            b.shift();
            return b;
        }
        protected getColumns(): Slick.Column[] {
            var columns = super.getColumns();

            Q.first(columns, x => x.field == fld.AccountName).format =
                ctx => `<a href="javascript:;" class="customer-link">${Q.htmlEncode(ctx.value)}</a>`;

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number): void {

            // let base grid handle clicks for its edit links
            super.onClick(e, row, cell);

            // if base grid already handled, we shouldn"t handle it again
            if (e.isDefaultPrevented()) {
                return;
            }

            // get reference to current item
            var item = this.itemAt(row);

            // get reference to clicked element
            var target = $(e.target);

            if (target.hasClass("customer-link")) {
                e.preventDefault();


                var dlg = new AccViewBudgetDialog();
                dlg.COAID = item.Id;
                dlg.COAName=item.AccountName;
                dlg.dialogOpen();


            }
        }
        //protected createSlickGrid() {
        //    var grid = super.createSlickGrid();

        //    // need to register this plugin for grouping or you'll have errors
        //    grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());

        //    this.view.setSummaryOptions({
        //        aggregators: [
        //            new Slick.Aggregators.Sum('Amount')
        //        ]
        //    });

        //    this.view.setGrouping(
        //        [{     formatter: x => x.value + ' (' + x.count + ' item(s))',
        //            getter: 'AccountName'
        //        }]);

        //    return grid;
        //}
    }
}
