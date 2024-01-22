
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    @Serenity.Decorators.maximizable()
    export class AccTransactionTypeAssignMasterDialog extends Serenity.EntityDialog<AccTransactionTypeAssignMasterRow, any> {
        protected getFormKey() { return AccTransactionTypeAssignMasterForm.formKey; }
        protected getIdProperty() { return AccTransactionTypeAssignMasterRow.idProperty; }
        protected getLocalTextPrefix() { return AccTransactionTypeAssignMasterRow.localTextPrefix; }
        protected getNameProperty() { return AccTransactionTypeAssignMasterRow.nameProperty; }
        protected getService() { return AccTransactionTypeAssignMasterService.baseUrl; }

        protected form = new AccTransactionTypeAssignMasterForm(this.idPrefix);
        constructor(container: JQuery) {
            super(container);
            $('.ui-dialog-titlebar-maximize').click();
            this.form.TransactionTypeId.change(e => {
                this.form.CoADebit.TransactionTypeID = Q.toId(this.form.TransactionTypeId.value);
            });


        //   this.byId('jsTreeCreditDiv').appendTo(this.byId('Credit'));
            var fieldDetailList = $('.Credit')[0];
            fieldDetailList.children[1].remove();
          //fieldDetailList.innerHTML = '';
         
            //var _details1 = $('#searchCreditInput')[0];

           // fieldDetailList.appendChild(_details1);
           // var br = document.createElement("p");
           //// element.appendChild(br);
           // fieldDetailList.appendChild(br);
           //// fieldDetailList.appendChild(ht
            var _details = $('#jsTreeCreditDiv')[0];

            fieldDetailList.appendChild(_details);
        }
    }
}