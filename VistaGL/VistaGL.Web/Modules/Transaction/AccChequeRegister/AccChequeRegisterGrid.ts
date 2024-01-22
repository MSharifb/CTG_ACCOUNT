
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccChequeRegisterGrid extends EntityGridBaseNew<AccChequeRegisterRow, any> {
        protected getColumnsKey() { return 'Transaction.AccChequeRegister'; }
        protected getDialogType() { return AccChequeRegisterDialog; }
        protected getIdProperty() { return AccChequeRegisterRow.idProperty; }
        protected getLocalTextPrefix() { return AccChequeRegisterRow.localTextPrefix; }
        protected getService() { return AccChequeRegisterService.baseUrl; }

        private pendingChanges: Q.Dictionary<any> = {};

        constructor(container: JQuery) {
            super(container);
            //    this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));
        }
        protected subDialogDataChange() {
            super.subDialogDataChange();
            Q.reloadLookup(AccChequeRegisterRow.lookupKey);
        }

        //protected getButtons() {
        //    var buttons = super.getButtons();

        //    buttons.push({
        //        title: 'Save Changes',
        //        cssClass: 'apply-changes-button disabled',
        //        onClick: e => this.saveClick(),
        //        separator: true
        //    });

        //    return buttons;
        //}

        //protected onViewProcessData(response) {
        //    this.pendingChanges = {};
        //    this.setSaveButtonState();
        //    return super.onViewProcessData(response);
        //}

        //private numericInputFormatter(ctx) {
        //    var klass = 'edit numeric';
        //    var item = ctx.item as AccChequeRegisterRow;
        //    var pending = this.pendingChanges[item.IsCancelled];

        //    if (pending && pending[ctx.column.field] !== undefined) {
        //        klass += ' dirty';
        //    }

        //    var value = this.getEffectiveValue(item, ctx.column.field) as boolean;
        //    console.log(value);
        //    var checked = "";
        //    if (value) checked = "checked";
        //    return "<input type='checkbox' class='ChkClick " + klass +
        //        "' data-field='" + ctx.column.field + "' " + checked + "/>";
        //}

        //private getEffectiveValue(item, field): any {
        //    var pending = this.pendingChanges[item.ProductID];
        //    if (pending && pending[field] !== undefined) {
        //        return pending[field];
        //    }
        //    return item[field];
        //}

        //protected getColumns() {
        //    var columns = super.getColumns();
        //   var num = ctx => this.numericInputFormatter(ctx);
        //    //var fld = AccChequeRegisterRow.Fields;

        //    Q.first(columns, x => x.field === 'IsCancelled').format = num;
        //    return columns;
        //}

        //private inputsChange(e: JQueryEventObject) {
        //    var cell = this.slickGrid.getCellFromEvent(e);
        //    var item = this.itemAt(cell.row);
        //    var input = $(e.target);
        //    var field = input.data('field');
        //    var text = Q.coalesce(Q.trimToNull(input.val()), '0');
        //    var pending = this.pendingChanges[item.IsCancelled];

        //    var effective = this.getEffectiveValue(item, field);
        //    var oldText: string;
        //    if (input.hasClass("numeric"))
        //        oldText = Q.formatNumber(effective, '0');
        //    else
        //        oldText = effective as string;

        //    var value;
        //    if (field === 'IsCancelled') {
        //        value = Q.parseDecimal(text);
        //        if (value == null || isNaN(value)) {
        //            Q.notifyError(Q.text('Validation.Decimal'), '', null);
        //            input.val(oldText);
        //            input.focus();
        //            return;
        //        }
        //    }
        //    else if (input.hasClass("numeric")) {
        //        var i = Q.parseInteger(text);
        //        if (isNaN(i) || i > 32767 || i < 0) {
        //            Q.notifyError(Q.text('Validation.Integer'), '', null);
        //            input.val(oldText);
        //            input.focus();
        //            return;
        //        }
        //        value = i;
        //    }
        //    else
        //        value = text;

        //    if (!pending) {
        //        this.pendingChanges[item.IsCancelled] = pending = {};
        //    }

        //    pending[field] = value;
        //    item[field] = value;
        //    this.view.refresh();

        //    if (input.hasClass("numeric"))
        //        value = Q.formatNumber(value, '0');

        //    input.val(value).addClass('dirty');
        //    this.setSaveButtonState();
        //}

        //private setSaveButtonState() {
        //    this.toolbar.findButton('apply-changes-button').toggleClass('disabled',
        //        Object.keys(this.pendingChanges).length === 0);
        //}

        //private saveClick() {
        //    if (Object.keys(this.pendingChanges).length === 0) {
        //        return;
        //    }

        //    // this calls save service for all modified rows, one by one
        //    // you could write a batch update service
        //    var keys = Object.keys(this.pendingChanges);
        //    var current = -1;
        //    var self = this;

        //    (function saveNext() {
        //        if (++current >= keys.length) {
        //            self.refresh();
        //            return;
        //        }

        //        var key = keys[current];
        //        var entity = Q.deepClone(self.pendingChanges[key]);
        //        entity.ProductID = key;
        //        Q.serviceRequest('Transaction/AccChequeRegisterRepository/Update', {
        //            EntityId: key,
        //            Entity: entity
        //        }, (response) => {
        //            delete self.pendingChanges[key];
        //            saveNext();
        //        });
        //    })();
        //}

        //protected getColumns(): Slick.Column[] {
        //    var columns = super.getColumns();

        //    //  return "<input type='checkbox' class='' data-field='' value=''/>";

        //    var b = `<input type='checkbox' class='ChkClick'/>`;
        //    columns.push({
        //        name: "Action",
        //        field: 'Action',
        //        format: ctx => b,
        //        width: 80

        //    });

        //    //    var columns = super.getColumns();
        //    //var num = ctx => this.numericInputFormatter(ctx);
        //    // //var fld = AccChequeRegisterRow.Fields;

        //    // Q.first(columns, x => x.field === 'IsCancelled').format = num;

        //    return columns;
        //}

        //protected onClick(e: JQueryEventObject, row: number, cell: number): void {

        //    // let base grid handle clicks for its edit links
        //    super.onClick(e, row, cell);

        //    // if base grid already handled, we shouldn"t handle it again
        //    if (e.isDefaultPrevented()) {
        //        return;
        //    }

        //    // get reference to current item
        //    var item = this.itemAt(row);

        //    // get reference to clicked element
        //    var target = $(e.target);

        //    if (target.hasClass("ChkClick")) {
        //        //   e.preventDefault();

        //        let message = "confirm?";


        //        // $(target).prop("checked", "checked");
        //        Q.confirm(message, () => {
        //            // ConScreeningChecklistService.Delete({ EntityId: item.ConScreeningChecklistId }, p => { this.refresh() });
        //            //if (!$(target).is(':checked'))
        //            //var v = target as HTMLInputElement;

        //            //if (!$(target).is(':checked')) {
        //            //   // $(target).prop("checked", "");
        //            //    $(target).removeAttr('checked');
        //            //    alert('unchecked');
        //            //}
        //            //else {
        //            //    $(target).prop("checked", "checked");
        //            //    alert('checked');
        //            //}


        //        }
        //        );
        //    }



        //}

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 20;
            return opt;
        }

    }
}