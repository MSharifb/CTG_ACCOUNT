namespace VistaGL.Configurations {
    export interface AccAdvanceDepositeReportForm {
        FinancialId: Serenity.LookupEditor;
        SubledgerId: Serenity.LookupEditor;
        OpeningBalance: Serenity.DecimalEditor;
        During: Serenity.DecimalEditor;
    }

    export class AccAdvanceDepositeReportForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccAdvanceDepositeReport';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccAdvanceDepositeReportForm.init)  {
                AccAdvanceDepositeReportForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccAdvanceDepositeReportForm, [
                    'FinancialId', w0,
                    'SubledgerId', w0,
                    'OpeningBalance', w1,
                    'During', w1
                ]);
            }
        }
    }
}

