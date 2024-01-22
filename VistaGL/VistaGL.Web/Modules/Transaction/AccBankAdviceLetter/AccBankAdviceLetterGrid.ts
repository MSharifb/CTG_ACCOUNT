
namespace VistaGL.Transaction {
    import fld = AccChequeRegisterRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccBankAdviceLetterGrid extends EntityGridBase<AccChequeRegisterRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBankAdviceLetter'; }

        protected getIdProperty() { return AccChequeRegisterRow.idProperty; }
        protected getLocalTextPrefix() { return AccChequeRegisterRow.localTextPrefix; }
        protected getService() { return AccBankAdviceLetterService.baseUrl; }

        private pendingChanges: Q.Dictionary<any> = {};

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Bank Advice Letter");
            this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));
        }
        protected createToolbarExtensions() {
            super.createToolbarExtensions();
        }
        protected markupReady(): void {
           super.markupReady();
            setTimeout(() => {
                $('.date-editor').unbind("datepicker").datepicker({
                    buttonImage: Q.resolveUrl("~/Content/serenity/images/calendar-blue.png"),
                    dateFormat: 'dd-mm-yy'
                });
            }, 100);
        }

        protected getItemCssClass(item, index: number): string {
                $('.date-editor').unbind("datepicker").datepicker({
                    buttonImage: Q.resolveUrl("~/Content/serenity/images/calendar-blue.png"),
                    dateFormat: 'dd-mm-yy'
                });
            return "";
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

            buttons.push({
                title: 'Print',
                cssClass: 'print-preview-button',
                onClick: () => {
                    if (!this.onViewSubmit()) {
                        return;
                    }

                    var selected = this.rowSelection.getSelectedKeys();
                    if (selected.length == 0) {
                        var rv = Q.warning("No row is selected!");
                    }
                    else {
                        var selectedOutput = [];
                        var items;
                        for (var i = 0; i < selected.length; i++) {
                            let id = selected[i];
                            items = AccChequeRegisterRow.getLookup().items.filter(x => x.Id == +id)[0];
                            if (items.BankAdviceDate == undefined || items.BankAdviceDate == "") {
                                Q.warning("No bank advice date found!");
                                return;
                            }

                            selectedOutput.push(+selected[i]);
                        }
                        var _url = "~/Reports/BankAdviceLetterTemplateInfo/GenerateReport?id=" + selectedOutput + "&COAId=" + items.BankAccountInformationCoaId;
                        Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                    }

                } // *** End onClick() ***

            }); // *** End Button.push ***

            return buttons;
        }

        protected onViewProcessData(response) {
            this.pendingChanges = {};
            this.setSaveButtonState();
            return super.onViewProcessData(response);
        }

        //protected getSlickOptions() {
        //    let opt = super.getSlickOptions();
        //    opt.frozenColumn = 5;

        //    return opt;
        //}

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();

            Q.first(filters, x => x.field == fld.IsBankAdvice).init = w => {
                (w as TrueFalseEditor).value = 'false';
            };

            return filters;
        }

        protected getColumns() {
            var columns = super.getColumns();

            let rowSelectionCol = Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection);
            rowSelectionCol.width = rowSelectionCol.minWidth = rowSelectionCol.maxWidth = 25
            columns.unshift(rowSelectionCol);

            var str = ctx => this.dateInputFormatter(ctx);

            Q.first(columns, x => x.field === fld.BankAdviceDate).format = str;
            Q.first(columns, x => x.field === fld.BankAdviceDate).width = 220;

            Q.first(columns, x => x.field == "inline-actions").visible = false;

            //Q.first(columns, x => x.field == "_select__").width = 50;
            //columns.unshift();

            return columns;
        }

        private inputsChange(e: JQueryEventObject) {
            var cell = this.slickGrid.getCellFromEvent(e);
            var item = this.itemAt(cell.row);
            var input = $(e.target);
            var field = input.data('field');
            var text = Q.coalesce(Q.trimToNull(input.val()), null);
            var pending = this.pendingChanges[item.Id];

            var effective = this.getEffectiveValue(item, field);
            var oldText: string;
            if (input.hasClass("date-editor"))
                oldText = Q.formatDate(effective, 'dd-MM-yyyy');
            else
                oldText = effective as string;

            var value;
            if (field === 'BankAdviceDate') {

                value = Q.formatDate(text, 'yyyy-MM-ddTHH:mm')
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
            //console.log(value);
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
                Q.serviceRequest('Transaction/AccBankAdviceLetter/Update', {
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
            var item = ctx.item as AccChequeRegisterRow;
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