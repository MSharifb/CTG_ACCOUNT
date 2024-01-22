namespace VistaGL.Configurations {
    export interface AccReportTypeForm {
        ReportType: Serenity.StringEditor;
    }

    export class AccReportTypeForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccReportType';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccReportTypeForm.init)  {
                AccReportTypeForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(AccReportTypeForm, [
                    'ReportType', w0
                ]);
            }
        }
    }
}

