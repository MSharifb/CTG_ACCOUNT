namespace VistaGL.Transaction {
    export interface AccMoneyReceiptDatailsForm {
        MoneyReceiptId: Serenity.StringEditor;
        CoaId: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        Description: Serenity.StringEditor;
    }

    export class AccMoneyReceiptDatailsForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccMoneyReceiptDatails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccMoneyReceiptDatailsForm.init)  {
                AccMoneyReceiptDatailsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(AccMoneyReceiptDatailsForm, [
                    'MoneyReceiptId', w0,
                    'CoaId', w1,
                    'CostCenterId', w1,
                    'Amount', w2,
                    'Description', w0
                ]);
            }
        }
    }
}

