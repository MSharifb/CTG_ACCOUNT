namespace VistaGL.Transaction {
    export interface AccPartyPaymentForm {
        PartyId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        CoAId: Serenity.LookupEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        CoAId2: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        RemainAmount: Serenity.DecimalEditor;
        Narration: Serenity.TextAreaEditor;
    }

    export class AccPartyPaymentForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccPartyPayment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccPartyPaymentForm.init)  {
                AccPartyPaymentForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = COAMappingEditor;
                var w2 = s.DecimalEditor;
                var w3 = s.TextAreaEditor;

                Q.initFormType(AccPartyPaymentForm, [
                    'PartyId', w0,
                    'TransactionMode', w1,
                    'CoAId', w0,
                    'ChequeRegisterId', w0,
                    'CoAId2', w0,
                    'Amount', w2,
                    'RemainAmount', w2,
                    'Narration', w3
                ]);
            }
        }
    }
}

