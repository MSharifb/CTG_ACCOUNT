namespace VistaGL.Transaction {
    export interface AccVoucherConfigurationForm {
        VoucherTypeId: Serenity.LookupEditor;
        AutoNumbering: Serenity.BooleanEditor;
        TransactionTypeId: Serenity.LookupEditor;
        PreparedByInfo: Serenity.BooleanEditor;
        AccountingPeriodId: Serenity.LookupEditor;
        IsUserFinancialAtTheEnd: Serenity.BooleanEditor;
        StartingNumber: Serenity.IntegerEditor;
        NewNumber: Serenity.BooleanEditor;
        NumberLength: Serenity.IntegerEditor;
        CommonDescription: Serenity.BooleanEditor;
        Prefix: Serenity.StringEditor;
        EachAccounting: Serenity.BooleanEditor;
        Suffix: Serenity.StringEditor;
        IsAutoPost: Serenity.BooleanEditor;
        Separators: Serenity.StringEditor;
        IsUserFinancialAtStart: Serenity.BooleanEditor;
        IsMonth: Serenity.BooleanEditor;
        IsDate: Serenity.BooleanEditor;
        Date: Serenity.DateEditor;
        NewNumberforEveryBankAccount: Serenity.BooleanEditor;
        IsActive: Serenity.BooleanEditor;
        AddZoneShortCode: Serenity.BooleanEditor;
        AddBankACShortCode: Serenity.BooleanEditor;
    }

    export class AccVoucherConfigurationForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherConfiguration';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherConfigurationForm.init)  {
                AccVoucherConfigurationForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.BooleanEditor;
                var w2 = s.IntegerEditor;
                var w3 = s.StringEditor;
                var w4 = s.DateEditor;

                Q.initFormType(AccVoucherConfigurationForm, [
                    'VoucherTypeId', w0,
                    'AutoNumbering', w1,
                    'TransactionTypeId', w0,
                    'PreparedByInfo', w1,
                    'AccountingPeriodId', w0,
                    'IsUserFinancialAtTheEnd', w1,
                    'StartingNumber', w2,
                    'NewNumber', w1,
                    'NumberLength', w2,
                    'CommonDescription', w1,
                    'Prefix', w3,
                    'EachAccounting', w1,
                    'Suffix', w3,
                    'IsAutoPost', w1,
                    'Separators', w3,
                    'IsUserFinancialAtStart', w1,
                    'IsMonth', w1,
                    'IsDate', w1,
                    'Date', w4,
                    'NewNumberforEveryBankAccount', w1,
                    'IsActive', w1,
                    'AddZoneShortCode', w1,
                    'AddBankACShortCode', w1
                ]);
            }
        }
    }
}

