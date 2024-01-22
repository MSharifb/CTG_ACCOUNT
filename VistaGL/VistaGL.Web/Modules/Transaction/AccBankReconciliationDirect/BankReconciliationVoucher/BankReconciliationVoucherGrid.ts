
namespace VistaGL.Transaction {
    import fld = AccVoucherDetailsRow.Fields;

    @Serenity.Decorators.registerClass()
    export class BankReconciliationVoucherGrid extends EntityGridBase<AccVoucherDetailsRow, any> {
        protected getColumnsKey() { return 'Transaction.BankReconciliationVoucher'; }

        protected getIdProperty() { return AccVoucherDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherDetailsRow.localTextPrefix; }
        protected getService() { return BankReconciliationVoucherService.baseUrl; }

        private pendingChanges: Q.Dictionary<any> = {};

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Bank Reconciliation");
            this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));
        }
        createSlickGrid(): Slick.Grid {
            //
            var grid = super.createSlickGrid();
            grid.setSelectionModel(new Slick.RowSelectionModel());
            return grid;
        }

        protected markupReady(): void {
            super.markupReady();
            let $dd = this.slickContainer.find('.date-editor') as any;
            $dd.datepicker({
                showOn: "button",
                buttonImageOnly: true,
                buttonImage: Q.resolveUrl("~/Content/serenity/images/calendar-blue.png"),
                dateFormat: 'dd-mm-yy'
                //beforeShow: function () {
                //    calendarOpen = true
                //},
                //onClose: function () {
                //    calendarOpen = false
                //}
            });
        }

        protected getButtons() {
            var buttons = super.getButtons();
            buttons.shift();
            buttons.push({
                title: 'Save Changes',
                cssClass: 'apply-changes-button disabled',
                onClick: e => this.saveClick(),
                separator: true
            });

            return buttons;
        }

        protected onViewProcessData(response) {
            //
            this.pendingChanges = {};
            this.setSaveButtonState();

            return super.onViewProcessData(response);
        }

        protected getSlickOptions(){
            let opt = super.getSlickOptions();

            opt.enableTextSelectionOnCells = true;
            opt.selectedCellCssClass = "slick-row-selected";
            opt.enableCellNavigation = true;

            return opt;
        }

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();


            Q.first(filters, x => x.field == fld.IsClearDate).init = w => {
                (w as ReconciliationEditor).value = "0";
            };

            // --
            let filterByChequeNo = Q.tryFirst(filters, x => x.field == fld.VoucherInformationChequeRegisterNo);
            if (filterByChequeNo != null) {
                filterByChequeNo.title = "Cheque No..";
                filterByChequeNo.type = Serenity.StringEditor;
                filterByChequeNo.handler = h => {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria,
                            [[fld.VoucherInformationChequeRegisterNo], 'like', '%' + h.value + '%']);
                    }
                };
            }

            return filters;
        }

        getQuickSearchFields(): Serenity.QuickSearchField[] {

            let txt = (s) => Q.text("Db." + AccVoucherDetailsRow.localTextPrefix + "." + s).toLowerCase();

            return [
                { name: "", title: "all" },
                { name: fld.VoucherInformationVoucherNo, title: txt(fld.VoucherInformationVoucherNo) },
                { name: fld.PaytoOrReciveFrom, title: txt(fld.PaytoOrReciveFrom) },
                { name: fld.VoucherInformationChequeRegisterNo, title: txt(fld.VoucherInformationChequeRegisterNo) },
            ];

        }

        protected getColumns() {
            var columns = super.getColumns();

            var str = ctx => this.dateInputFormatter(ctx);


            Q.first(columns, x => x.field === fld.ClearDate).format = str;
            Q.first(columns, x => x.field === fld.ClearDate).width = 120;

            columns.unshift(
                {
                    field: 'Print Voucher',
                    name: '',
                    format: ctx => '<a class="inline-action Print-link" title="Print Voucher">' +
                        '<i class="fa fa-print text-blue"></i></a>',
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                }
            );

            Q.first(columns, x => x.field == "inline-actions").visible = false;

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number): void {

            super.onClick(e, row, cell);

            if (e.isDefaultPrevented()) {
                return;
            }

            var item = this.itemAt(row);

            var target = $(e.target);

            if (target.parent().hasClass('Print-link'))
                target = target.parent();

            var voucher = Q.tryFirst(Transaction.AccVoucherInformationRow.getLookup().items,
                x => x.Id == item.VoucherInformationId);

            if (target.hasClass("Print-link")) {
                e.preventDefault();
                if (voucher.LinkedWithAutoJV == true && voucher.LinkedWithAutoJV != null) {
                    var _url = "~/Reports/VoucherPreview/IndexCombineVoucher?id=" + item.VoucherInformationId + "&isCombineVoucher=" + true;
                } else {
                    var _url = "~/Reports/VoucherPreview?id=" + item.VoucherInformationId;
                }
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });
            }

        }

        private inputsChange(e: JQueryEventObject) {
            var cell = this.slickGrid.getCellFromEvent(e);
            var item = this.itemAt(cell.row);
            var input = $(e.target);
            var field = input.data('field');
            var text = Q.coalesce(Q.trimToNull(input.val()), '');
            var pending = this.pendingChanges[item.Id];

            var effective = this.getEffectiveValue(item, field);
            var oldText: string;
            if (input.hasClass("date-editor"))
                oldText = Q.formatDate(effective, 'dd-MM-yyyy');
            else
                oldText = effective as string;

            var value;
            if (field === 'ClearDate') {

                value = Q.formatDate(text, 'yyyy-MM-ddTHH:mm')

                // value = Q.parseDate(value);
                //console.log(value);
                //if (value == null || isNaN(value)) {
                //    Q.notifyError(Q.text('Validation.DateInvalid'), '', null);
                //    input.val(oldText);
                //    input.focus();
                //    return;
                //}
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

            if (input.hasClass("date-editor"))
                value = Q.formatDate(value, 'dd-MM-yyyy');

            input.val(value).addClass('dirty');

            this.setSaveButtonState();
        }

        private setSaveButtonState() {
            this.toolbar.findButton('apply-changes-button').toggleClass('disabled',
                Object.keys(this.pendingChanges).length === 0);
        }

        private saveClick() {
            if (Object.keys(this.pendingChanges).length === 0) {
                return;
            }

            // this calls save service for all modified rows, one by one
            // you could write a batch update service
            var keys = Object.keys(this.pendingChanges);
            var current = -1;
            var self = this;

            (function saveNext() {
                if (++current >= keys.length) {
                    self.refresh();
                    return;
                }

                var key = keys[current];
                var entity = Q.deepClone(self.pendingChanges[key]);
                entity.Id = key;
                entity.IsClearDate = 1;

                Q.serviceRequest('Transaction/AccVoucherDetails/Update', {
                    EntityId: key,
                    Entity: entity
                }, (response) => {
                    delete self.pendingChanges[key];
                    saveNext();
                });
            })();
        }

        private dateInputFormatter(ctx) {
            var klass = 'edit date-editor ';
            var item = ctx.item as AccVoucherDetailsRow;
            var pending = this.pendingChanges[item.Id];
            var column = ctx.column as Slick.Column;

            if (pending && pending[column.field] !== undefined) {
                klass += ' dirty';
            }

            var value = this.getEffectiveValue(item, column.field) as string;

            return "<input type='text' class='" + klass +
                "' data-field='" + column.field +
                "' value='" + Q.formatDate(value, 'dd-MM-yyyy') +
                "' maxlength='" + column.sourceItem.maxLength + "'/>";
        }

        private getEffectiveValue(item, field): any {
            var pending = this.pendingChanges[item.Id];
            if (pending && pending[field] !== undefined) {
                return pending[field];
            }

            return item[field];
        }


    }

}