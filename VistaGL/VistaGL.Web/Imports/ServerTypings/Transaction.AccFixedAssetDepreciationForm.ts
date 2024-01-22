namespace VistaGL.Transaction {
    export interface AccFixedAssetDepreciationForm {
        FinancialYearId: Serenity.LookupEditor;
        ProcessType: Serenity.StringEditor;
    }

    export class AccFixedAssetDepreciationForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccFixedAssetDepreciation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccFixedAssetDepreciationForm.init)  {
                AccFixedAssetDepreciationForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;

                Q.initFormType(AccFixedAssetDepreciationForm, [
                    'FinancialYearId', w0,
                    'ProcessType', w1
                ]);
            }
        }
    }
}

