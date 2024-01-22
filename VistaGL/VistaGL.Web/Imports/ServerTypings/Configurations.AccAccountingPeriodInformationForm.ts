namespace VistaGL.Configurations {
    export interface AccAccountingPeriodInformationForm {
        YearName: Serenity.StringEditor;
        PeriodStartDate: Serenity.DateEditor;
        PeriodEndDate: Serenity.DateEditor;
        IsActive: Serenity.BooleanEditor;
        IsClosed: Serenity.BooleanEditor;
    }

    export class AccAccountingPeriodInformationForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccAccountingPeriodInformation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccAccountingPeriodInformationForm.init)  {
                AccAccountingPeriodInformationForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.BooleanEditor;

                Q.initFormType(AccAccountingPeriodInformationForm, [
                    'YearName', w0,
                    'PeriodStartDate', w1,
                    'PeriodEndDate', w1,
                    'IsActive', w2,
                    'IsClosed', w2
                ]);
            }
        }
    }
}

