
namespace VistaGL.Transaction {

    import fld = AccIbcsJsondataHistoryRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccIbcsJsondataHistoryGrid extends EntityGridBaseNew<AccIbcsJsondataHistoryRow, any> {
        protected getColumnsKey() { return 'Transaction.AccIbcsJsondataHistory'; }
        protected getDialogType() { return AccIbcsJsondataHistoryDialog; }
        protected getIdProperty() { return AccIbcsJsondataHistoryRow.idProperty; }
        protected getLocalTextPrefix() { return AccIbcsJsondataHistoryRow.localTextPrefix; }
        protected getService() { return AccIbcsJsondataHistoryService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);

            return buttons;
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 20;
            return opt;
        }

        protected getColumns() {
            var columns = super.getColumns();

            Q.first(columns, x => x.field == fld.JsonData).cssClass += " inline-action download-json";

            Q.first(columns, x => x.field == fld.VoucherNo).cssClass += " inline-action download-json";

            //columns.splice(1, 0, {
            //    field: 'View XML',
            //    name: '',
            //    format: ctx => '<a class="inline-action download-json" title="View JSON">' +
            //        '<i class="fa fa-file-text-o text-blue"></i></a>',
            //    width: 24,
            //    minWidth: 24,
            //    maxWidth: 24
            //});

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

                if (target.hasClass('download-json')) {
                    let ServiceEndpoint = this.getService() + "/ExportFile";
                    Q.postToService(
                        {
                            service: ServiceEndpoint,
                            request: { EntityId: item.Id },
                            target: '_blank'
                        });
                }
            }
        }
    }
}