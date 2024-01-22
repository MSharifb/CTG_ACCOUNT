namespace VistaGL.Default {
    export interface AuditLogForm {
        UserId: Serenity.IntegerEditor;
        UserName: Serenity.StringEditor;
        UserFullName: Serenity.StringEditor;
        ZoneName: Serenity.StringEditor;
        Action: Serenity.LookupEditor;
        ChangedOn: Serenity.DateTimeEditor;
        Module: Serenity.StringEditor;
        Page: Serenity.StringEditor;
        RowId: Serenity.IntegerEditor;
        DBTableName: Serenity.LookupEditor;
        Changes: Serenity.TextAreaEditor;
    }

    export class AuditLogForm extends Serenity.PrefixedContext {
        static formKey = 'Default.AuditLog';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AuditLogForm.init)  {
                AuditLogForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.LookupEditor;
                var w3 = s.DateTimeEditor;
                var w4 = s.TextAreaEditor;

                Q.initFormType(AuditLogForm, [
                    'UserId', w0,
                    'UserName', w1,
                    'UserFullName', w1,
                    'ZoneName', w1,
                    'Action', w2,
                    'ChangedOn', w3,
                    'Module', w1,
                    'Page', w1,
                    'RowId', w0,
                    'DBTableName', w2,
                    'Changes', w4
                ]);
            }
        }
    }
}

