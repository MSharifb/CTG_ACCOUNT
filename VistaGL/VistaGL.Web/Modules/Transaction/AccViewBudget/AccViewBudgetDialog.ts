
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.resizable()
    @Serenity.Decorators.maximizable()
    export class AccViewBudgetDialog extends Serenity.EntityDialog<AccViewBudgetRow, any> {
        protected getFormKey() { return AccViewBudgetForm.formKey; }
        protected getLocalTextPrefix() { return AccViewBudgetRow.localTextPrefix; }
        protected getNameProperty() { return AccViewBudgetRow.nameProperty; }
        protected getService() { return AccViewBudgetService.baseUrl; }
        public COAID: number;
         public COAName: string;
        protected form = new AccViewBudgetForm(this.idPrefix);
        private ViewBudgetDetailsGrid: AccViewBudgetDetailsGrid;
        protected onDialogOpen() {
            super.onDialogOpen();
            this.ViewBudgetDetailsGrid = new AccViewBudgetDetailsGrid(this.byId('DetailsGrid'));
            this.ViewBudgetDetailsGrid.element.flexHeightOnly(1);
            // Q.initFullHeightGridPage(this.byId('DetailsGrid'));
            this.ViewBudgetDetailsGrid.CoAID = this.COAID;

            $('.s-Transaction-AccViewBudgetDialog .grid-title').text(this.COAName);

           // this.byId('AccountID').val(this.COAID.toString());
        }

        //protected getTemplate() {
        //    // you could also put this in a ChartInDialog.Template.html file. it's here for simplicity.
        //    return "<div id='~_Budget'></div>";
        //}

        //protected getDialogOptions() {
        //    var opt = super.getDialogOptions();
        //    opt.title = 'Budget Details';
        //    return opt;
        //}
        protected getToolbarButtons() {
            var buttons = [];
            buttons.push({
                title: "Save", cssClass: "approve-button",

                onClick: (x) => {

                    let message = "Are you sure you want to " + $('.approve-button .button-inner').text() + "?";

                    Q.confirm(message, () => {
                        //this.form.BudgetStatus.value = this.entity.ApprovalAction;
                        //this.save(p => { Q.notifySuccess("success"); this.dialogClose(); });
                    }
                    );



                }
            });
            return buttons;
        }
     
    }
}