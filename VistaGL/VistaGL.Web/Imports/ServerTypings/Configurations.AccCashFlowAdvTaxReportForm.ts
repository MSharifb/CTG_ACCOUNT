namespace VistaGL.Configurations {
    export interface AccCashFlowAdvTaxReportForm {
        FinancialYearId: Serenity.LookupEditor;
        AdvTaxAmount: Serenity.DecimalEditor;
        Opening: Serenity.DecimalEditor;
    }

    export class AccCashFlowAdvTaxReportForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccCashFlowAdvTaxReport';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCashFlowAdvTaxReportForm.init)  {
                AccCashFlowAdvTaxReportForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccCashFlowAdvTaxReportForm, [
                    'FinancialYearId', w0,
                    'AdvTaxAmount', w1,
                    'Opening', w1
                ]);
            }
        }
    }
}

