namespace VistaGL.Configurations {
    export interface AccCoACostCenterOpeningBalanceForm {
        CoAid: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        OBDebit: Serenity.DecimalEditor;
        OBCredit: Serenity.DecimalEditor;
    }

    export class AccCoACostCenterOpeningBalanceForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccCoACostCenterOpeningBalance';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCoACostCenterOpeningBalanceForm.init)  {
                AccCoACostCenterOpeningBalanceForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccCoACostCenterOpeningBalanceForm, [
                    'CoAid', w0,
                    'CostCenterId', w0,
                    'OBDebit', w1,
                    'OBCredit', w1
                ]);
            }
        }
    }
}

