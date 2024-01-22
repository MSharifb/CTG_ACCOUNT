namespace VistaGL.Transaction {
    export interface AccVoucherDetailsForm {
        ChartofAccountsId: Serenity.LookupEditor;
        DebitAmount: Serenity.DecimalEditor;
        CreditAmount: Serenity.DecimalEditor;
        CalculationAmount: Serenity.DecimalEditor;
        CalculationRate: Serenity.DecimalEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        EffectiveValue: Serenity.DecimalEditor;
        CCreditAmount: Serenity.DecimalEditor;
        CDebitAmount: Serenity.DecimalEditor;
        Description: Serenity.TextAreaEditor;
        AdjustedChequeRegisterId: Serenity.LookupEditor;
        VoucherDtlAllocation: AccVoucherDtlAllocationEditor;
        VoucherDtlBillRef: AccVoucherDtlBillRefEditor;
        ConversionRate: Serenity.DecimalEditor;
        ConversionAmount: Serenity.DecimalEditor;
    }

    export class AccVoucherDetailsForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherDetails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherDetailsForm.init)  {
                AccVoucherDetailsForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.TextAreaEditor;
                var w3 = AccVoucherDtlAllocationEditor;
                var w4 = AccVoucherDtlBillRefEditor;

                Q.initFormType(AccVoucherDetailsForm, [
                    'ChartofAccountsId', w0,
                    'DebitAmount', w1,
                    'CreditAmount', w1,
                    'CalculationAmount', w1,
                    'CalculationRate', w1,
                    'ChequeRegisterId', w0,
                    'EffectiveValue', w1,
                    'CCreditAmount', w1,
                    'CDebitAmount', w1,
                    'Description', w2,
                    'AdjustedChequeRegisterId', w0,
                    'VoucherDtlAllocation', w3,
                    'VoucherDtlBillRef', w4,
                    'ConversionRate', w1,
                    'ConversionAmount', w1
                ]);
            }
        }
    }
}

