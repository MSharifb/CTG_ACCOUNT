namespace VistaGL.Configurations {
    export interface AccCostCentreDepreciationOpeningBalanceForm {
        CostCenterId: Serenity.LookupEditor;
        OpeningBalanceCost: Serenity.DecimalEditor;
        OpeningBalanceDepreciation: Serenity.DecimalEditor;
    }

    export class AccCostCentreDepreciationOpeningBalanceForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccCostCentreDepreciationOpeningBalance';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCostCentreDepreciationOpeningBalanceForm.init)  {
                AccCostCentreDepreciationOpeningBalanceForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccCostCentreDepreciationOpeningBalanceForm, [
                    'CostCenterId', w0,
                    'OpeningBalanceCost', w1,
                    'OpeningBalanceDepreciation', w1
                ]);
            }
        }
    }
}

