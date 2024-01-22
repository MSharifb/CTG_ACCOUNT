
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.resizable()
    @Serenity.Decorators.maximizable()
    export class VoucherPreviewDialog extends Serenity.TemplatedDialog<any> {

        public _url: string;

        constructor() {
            //
            super();

            $('.s-Transaction-VoucherPreviewDialog .ui-dialog-titlebar-maximize').click();
            this.byId('Loading').show();
            this.byId('Loading').fadeOut(3000);
        }

        static initializePage() {
            //
        }

        protected onDialogOpen() {
            //
            super.onDialogOpen();

            this.byId('Preview').html(`<iframe src='${this._url}' width='100%' style='border:none; height: 99%;'></iframe>`);
        }

        protected arrange() {
            //
            super.arrange();
        }

        protected getTemplate() {
            //
            return `<div id='~_Loading' style='display: none; font-size: 18px; font-weight: bold; padding-left: 10px;'>Loading.. Please wait...</div><div id='~_Preview' style='height: 100%;'></div>`;
        }

        protected getDialogOptions() {
            //
            var opt = super.getDialogOptions();
            opt.title = 'Preview';
            opt.buttons = [{
                text: "Close",
                click: () => this.dialogClose()
            }
            ];
            return opt;
        }
    }
}