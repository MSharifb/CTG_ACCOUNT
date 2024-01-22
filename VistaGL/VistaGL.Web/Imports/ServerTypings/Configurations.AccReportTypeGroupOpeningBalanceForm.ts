namespace VistaGL.Configurations {
    export interface AccReportTypeGroupOpeningBalanceForm {
        ReportTypeId: Serenity.LookupEditor;
        GroupId: Serenity.LookupEditor;
        ZoneId: Serenity.LookupEditor;
        FundControlId: Serenity.IntegerEditor;
        OpeningBalance: Serenity.DecimalEditor;
    }

    export class AccReportTypeGroupOpeningBalanceForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccReportTypeGroupOpeningBalance';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccReportTypeGroupOpeningBalanceForm.init)  {
                AccReportTypeGroupOpeningBalanceForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(AccReportTypeGroupOpeningBalanceForm, [
                    'ReportTypeId', w0,
                    'GroupId', w0,
                    'ZoneId', w0,
                    'FundControlId', w1,
                    'OpeningBalance', w2
                ]);
            }
        }
    }
}

