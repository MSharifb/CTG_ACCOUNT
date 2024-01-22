namespace VistaGL.Transaction {
    export interface AccFixedAssetRefurbishmentForm {
        CoaId: Serenity.LookupEditor;
        FinancialYearId: Serenity.LookupEditor;
        CostOpening: Serenity.DecimalEditor;
        CostAddition: Serenity.DecimalEditor;
        CostAdjustment: Serenity.DecimalEditor;
        CostClosing: Serenity.DecimalEditor;
        DepOpening: Serenity.DecimalEditor;
        DepCharge: Serenity.DecimalEditor;
        DepAdjustment: Serenity.DecimalEditor;
        DepClosing: Serenity.DecimalEditor;
        BookValue: Serenity.DecimalEditor;
    }

    export class AccFixedAssetRefurbishmentForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccFixedAssetRefurbishment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccFixedAssetRefurbishmentForm.init)  {
                AccFixedAssetRefurbishmentForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccFixedAssetRefurbishmentForm, [
                    'CoaId', w0,
                    'FinancialYearId', w0,
                    'CostOpening', w1,
                    'CostAddition', w1,
                    'CostAdjustment', w1,
                    'CostClosing', w1,
                    'DepOpening', w1,
                    'DepCharge', w1,
                    'DepAdjustment', w1,
                    'DepClosing', w1,
                    'BookValue', w1
                ]);
            }
        }
    }
}

