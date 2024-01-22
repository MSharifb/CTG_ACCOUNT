namespace VistaGL.Configurations {
    export interface AccFinancialReportsDetailsForm {
        ReportType: FinancialReportEditor;
        ZoneInfoId: Serenity.LookupEditor;
        EntityId: Serenity.IntegerEditor;
        CoaId: Serenity.LookupEditor;
        SubledgerId: Serenity.LookupEditor;
        Opening: Serenity.DecimalEditor;
    }

    export class AccFinancialReportsDetailsForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccFinancialReportsDetails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccFinancialReportsDetailsForm.init)  {
                AccFinancialReportsDetailsForm.init = true;

                var s = Serenity;
                var w0 = FinancialReportEditor;
                var w1 = s.LookupEditor;
                var w2 = s.IntegerEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(AccFinancialReportsDetailsForm, [
                    'ReportType', w0,
                    'ZoneInfoId', w1,
                    'EntityId', w2,
                    'CoaId', w1,
                    'SubledgerId', w1,
                    'Opening', w3
                ]);
            }
        }
    }
}

