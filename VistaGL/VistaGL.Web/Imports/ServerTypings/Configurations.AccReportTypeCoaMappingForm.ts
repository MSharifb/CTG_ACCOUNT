namespace VistaGL.Configurations {
    export interface AccReportTypeCoaMappingForm {
        ReportTypeId: Serenity.LookupEditor;
        GroupId: Serenity.LookupEditor;
        CoaId: Serenity.LookupEditor;
        OpeningBalance: Serenity.DecimalEditor;
    }

    export class AccReportTypeCoaMappingForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccReportTypeCoaMapping';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccReportTypeCoaMappingForm.init)  {
                AccReportTypeCoaMappingForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccReportTypeCoaMappingForm, [
                    'ReportTypeId', w0,
                    'GroupId', w0,
                    'CoaId', w0,
                    'OpeningBalance', w1
                ]);
            }
        }
    }
}

