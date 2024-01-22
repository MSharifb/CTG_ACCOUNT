
namespace VistaGL.Transaction {
    import fld = AccViewBudgetDetailsRow.Fields;
    @Serenity.Decorators.registerClass()
    export class AccViewBudgetDetailsGrid extends Serenity.EntityGrid<AccViewBudgetDetailsRow, any> {
        protected getColumnsKey() { return 'Transaction.AccViewBudgetDetails'; }
        protected getDialogType() { return AccViewBudgetDetailsDialog; }
        protected getLocalTextPrefix() { return AccViewBudgetDetailsRow.localTextPrefix; }
        protected getService() { return AccViewBudgetDetailsService.baseUrl; }
        protected getIdProperty() { return "__id"; }
        private pendingChanges: Q.Dictionary<any> = {};
        constructor(container: JQuery) {
            super(container);
            //  $('.s-Transaction-AccViewBudgetDialog .grid-title').remove();
            $('.s-Transaction-AccViewBudgetDialog .grid-toolbar').remove();
            this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));
        }

        private nextId = 1;






        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<AccViewBudgetDetailsRow>) {
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

        private _CoAID: number;

        get CoAID() {
            return this._CoAID;
        }

        set CoAID(value: number) {
            if (this._CoAID !== value) {
                this._CoAID = value;
                this.setEquality('id', value);
                this.refresh();
            }
        }

        protected usePager() {
            return false;
        }
        private getEffectiveValue(item, field): any {
            var pending = this.pendingChanges[item.ProductID];
            if (pending && pending[field] !== undefined) {
                return pending[field];
            }

            return item[field];
        }

        protected getColumns() {
            var columns = super.getColumns();
            var num = ctx => this.numericInputFormatter(ctx);
            //  var str = ctx => this.stringInputFormatter(ctx);

            Q.first(columns, x => x.field === 'Amount1').format = num;

            //Q.first(columns, x => x.field === fld.UnitPrice).format = num;
            //Q.first(columns, x => x.field === fld.UnitsInStock).format = num;
            //Q.first(columns, x => x.field === fld.UnitsOnOrder).format = num;
            //Q.first(columns, x => x.field === fld.ReorderLevel).format = num;

            return columns;
        }
        private numericInputFormatter(ctx) {
            var klass = 'edit numeric';
            var item = ctx.item as AccViewBudgetDetailsRow;
            var pending = this.pendingChanges[item.Id];

            if (pending && pending[ctx.column.field] !== undefined) {
                klass += ' dirty';
            }

            var value = this.getEffectiveValue(item, ctx.column.field) as number;

            return "<input type='text' class='" + klass +
                "' data-field='" + ctx.column.field +
                "' value='" + Q.formatNumber(value, '0.##') + "'/>";
        }
        private inputsChange(e: JQueryEventObject) {
            var cell = this.slickGrid.getCellFromEvent(e);
            var item = this.itemAt(cell.row);
            var input = $(e.target);
            var field = input.data('field');
            var text = Q.coalesce(Q.trimToNull(input.val()), '0');
            var pending = this.pendingChanges[item.Id];

            var effective = this.getEffectiveValue(item, field);
            var oldText: string;
            if (input.hasClass("numeric"))
                oldText = Q.formatNumber(effective, '0.##');
            else
                oldText = effective as string;

            var value;
            if (field === 'UnitPrice') {
                value = Q.parseDecimal(text);
                if (value == null || isNaN(value)) {
                    Q.notifyError(Q.text('Validation.Decimal'), '', null);
                    input.val(oldText);
                    input.focus();
                    return;
                }
            }
            else if (input.hasClass("numeric")) {
                var i = Q.parseInteger(text);
                if (isNaN(i) || i > 32767 || i < 0) {
                    Q.notifyError(Q.text('Validation.Integer'), '', null);
                    input.val(oldText);
                    input.focus();
                    return;
                }
                value = i;
            }
            else
                value = text;

            if (!pending) {
                this.pendingChanges[item.Id] = pending = {};
            }

            pending[field] = value;
            item[field] = value;
            this.view.refresh();

            if (input.hasClass("numeric"))
                value = Q.formatNumber(value, '0.##');

            input.val(value).addClass('dirty');

            this.setSaveButtonState();
        }

        private setSaveButtonState() {
            this.toolbar.findButton('apply-changes-button').toggleClass('disabled',
                Object.keys(this.pendingChanges).length === 0);
        }


    }
}