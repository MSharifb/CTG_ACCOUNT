namespace VistaGL.Configurations {
    export interface AccReportTypeGroupSetupForm {
        ReportTypeId: Serenity.LookupEditor;
        ParentId: Serenity.LookupEditor;
        GroupName: Serenity.StringEditor;
        SortingOrder: Serenity.IntegerEditor;
        ShowAutoSum: Serenity.BooleanEditor;
        NoteNo: Serenity.DecimalEditor;
        AddBlankSpaceBefore: Serenity.BooleanEditor;
        AddBlankSpaceAfter: Serenity.BooleanEditor;
        ShowBottomBorder: Serenity.BooleanEditor;
        ShowUpperBorder: Serenity.BooleanEditor;
        ShowLeftBorder: Serenity.BooleanEditor;
        ShowRightBorder: Serenity.BooleanEditor;
        Symbol: Serenity.StringEditor;
        FontWeight: Serenity.StringEditor;
        FundControlId: Serenity.IntegerEditor;
    }

    export class AccReportTypeGroupSetupForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccReportTypeGroupSetup';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccReportTypeGroupSetupForm.init)  {
                AccReportTypeGroupSetupForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.IntegerEditor;
                var w3 = s.BooleanEditor;
                var w4 = s.DecimalEditor;

                Q.initFormType(AccReportTypeGroupSetupForm, [
                    'ReportTypeId', w0,
                    'ParentId', w0,
                    'GroupName', w1,
                    'SortingOrder', w2,
                    'ShowAutoSum', w3,
                    'NoteNo', w4,
                    'AddBlankSpaceBefore', w3,
                    'AddBlankSpaceAfter', w3,
                    'ShowBottomBorder', w3,
                    'ShowUpperBorder', w3,
                    'ShowLeftBorder', w3,
                    'ShowRightBorder', w3,
                    'Symbol', w1,
                    'FontWeight', w1,
                    'FundControlId', w2
                ]);
            }
        }
    }
}

