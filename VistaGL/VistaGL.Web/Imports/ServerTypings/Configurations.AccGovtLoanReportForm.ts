namespace VistaGL.Configurations {
    export interface AccGovtLoanReportForm {
        CoaId: Serenity.LookupEditor;
        LoanOpening: Serenity.DecimalEditor;
        LoanRefundOpening: Serenity.DecimalEditor;
        IsInterestFree: Serenity.BooleanEditor;
    }

    export class AccGovtLoanReportForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccGovtLoanReport';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccGovtLoanReportForm.init)  {
                AccGovtLoanReportForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.BooleanEditor;

                Q.initFormType(AccGovtLoanReportForm, [
                    'CoaId', w0,
                    'LoanOpening', w1,
                    'LoanRefundOpening', w1,
                    'IsInterestFree', w2
                ]);
            }
        }
    }
}

