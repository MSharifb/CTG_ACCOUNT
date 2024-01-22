namespace VistaGL.Transaction {
    export interface AccFixedAssetsManualInputForm {
        CostCenterId: Serenity.LookupEditor;
        FinancialYearId: Serenity.LookupEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        AdditionAmount: Serenity.DecimalEditor;
        AdjustmentAmount: Serenity.DecimalEditor;
        DepCharge: Serenity.DecimalEditor;
        DepAdjustment: Serenity.DecimalEditor;
        FundControlId: Serenity.IntegerEditor;
    }

    export class AccFixedAssetsManualInputForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccFixedAssetsManualInput';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccFixedAssetsManualInputForm.init)  {
                AccFixedAssetsManualInputForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(AccFixedAssetsManualInputForm, [
                    'CostCenterId', w0,
                    'FinancialYearId', w0,
                    'ZoneInfoId', w1,
                    'AdditionAmount', w2,
                    'AdjustmentAmount', w2,
                    'DepCharge', w2,
                    'DepAdjustment', w2,
                    'FundControlId', w1
                ]);
            }
        }
    }
}

