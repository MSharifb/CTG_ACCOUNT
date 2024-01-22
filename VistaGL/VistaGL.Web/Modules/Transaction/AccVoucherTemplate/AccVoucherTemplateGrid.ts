
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherTemplateGrid extends EntityGridBase<AccVoucherTemplateRow, any> {
        protected getColumnsKey() { return 'Transaction.AccVoucherTemplate'; }
        protected getDialogType() { return AccVoucherTemplateDialog; }
        protected getIdProperty() { return AccVoucherTemplateRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherTemplateRow.localTextPrefix; }
        protected getService() { return AccVoucherTemplateService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }


        protected getColumns() {
            var columns = super.getColumns();
            columns.splice(Q.indexOf(columns, x => x.name == "Account Head (Credit)") + 1, 0, {
                field: 'Process',
                name: 'Process',
                format: ctx => '<a class="inline-action Process-row" title="Process">' + 
                    '<i class="fa fa-repeat text-green"></i></a>',
                width: 100,
                minWidth: 100,
                maxWidth: 100,
                cssClass: 'text-center' 
            });

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number) {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            // if user clicks "i" element, e.g. icon
            if (target.parent().hasClass('inline-action'))
                target = target.parent();

            if (target.hasClass('inline-action')) {
                e.preventDefault();

                if (target.hasClass('Process-row')) {                   

                    let dlg = new AccVoucherTemplateVoucherIssueDialog();
                    this.initDialog(dlg);
                    dlg.loadByIdAndOpenDialog(item.Id);

              


                    //dlg.loadEntityAndOpenDialog(<AccVoucherTemplateRow>{
                    //    VoucherTypeId: item.VoucherTypeId, 
                    //});

                }               
            }
        }
    }
}