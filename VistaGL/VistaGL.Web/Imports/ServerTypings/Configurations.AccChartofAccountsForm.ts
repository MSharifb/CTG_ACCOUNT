namespace VistaGL.Configurations {
    export interface AccChartofAccountsForm {
        FundControlId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        UserCode: Serenity.StringEditor;
        ParentAccountId: Serenity.LookupEditor;
        AccountCode: Serenity.StringEditor;
        Level: Serenity.IntegerEditor;
        AccountCodeCount: Serenity.IntegerEditor;
        AccountGroup: Serenity.StringEditor;
        AccOpeningBalance: Serenity.DecimalEditor;
        AccOpeningBalanceId: Serenity.IntegerEditor;
        MultiCurrencyId: Serenity.LookupEditor;
        EffectCashFlow: Serenity.EnumEditor;
        CoaMapping: COAMappingEditor;
        TaxId: Serenity.StringEditor;
        IsCostCenterAllocate: Serenity.BooleanEditor;
        IsBillRef: Serenity.BooleanEditor;
        IsControlhead: Serenity.BooleanEditor;
        NoaAccTypeId: AccHeadTypeMappingEditor;
        Remarks: Serenity.StringEditor;
        NoaAccTypeId2: Serenity.IntegerEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        BudgetCode: Serenity.StringEditor;
        BudgetGroupId: Serenity.LookupEditor;
        SortOrder: Serenity.IntegerEditor;
        ShowSumInReceiptPaymentReport: Serenity.BooleanEditor;
        IsHideChildrenFromThisLevel: Serenity.BooleanEditor;
        IsBalanceSheet: Serenity.BooleanEditor;
        BalanceSheetNotes: Serenity.IntegerEditor;
        IsIncomeExpenditure: Serenity.BooleanEditor;
        IncomeExpenditureNotes: Serenity.IntegerEditor;
    }

    export class AccChartofAccountsForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccChartofAccounts';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccChartofAccountsForm.init)  {
                AccChartofAccountsForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.IntegerEditor;
                var w3 = s.DecimalEditor;
                var w4 = s.EnumEditor;
                var w5 = COAMappingEditor;
                var w6 = s.BooleanEditor;
                var w7 = AccHeadTypeMappingEditor;

                Q.initFormType(AccChartofAccountsForm, [
                    'FundControlId', w0,
                    'AccountName', w1,
                    'UserCode', w1,
                    'ParentAccountId', w0,
                    'AccountCode', w1,
                    'Level', w2,
                    'AccountCodeCount', w2,
                    'AccountGroup', w1,
                    'AccOpeningBalance', w3,
                    'AccOpeningBalanceId', w2,
                    'MultiCurrencyId', w0,
                    'EffectCashFlow', w4,
                    'CoaMapping', w5,
                    'TaxId', w1,
                    'IsCostCenterAllocate', w6,
                    'IsBillRef', w6,
                    'IsControlhead', w6,
                    'NoaAccTypeId', w7,
                    'Remarks', w1,
                    'NoaAccTypeId2', w2,
                    'IsBudgetHead', w6,
                    'BudgetCode', w1,
                    'BudgetGroupId', w0,
                    'SortOrder', w2,
                    'ShowSumInReceiptPaymentReport', w6,
                    'IsHideChildrenFromThisLevel', w6,
                    'IsBalanceSheet', w6,
                    'BalanceSheetNotes', w2,
                    'IsIncomeExpenditure', w6,
                    'IncomeExpenditureNotes', w2
                ]);
            }
        }
    }
}

