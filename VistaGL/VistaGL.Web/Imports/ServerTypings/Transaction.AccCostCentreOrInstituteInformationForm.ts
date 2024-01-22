namespace VistaGL.Transaction {
    export interface AccCostCentreOrInstituteInformationForm {
        IsInstitute: Serenity.BooleanEditor;
        CostCenterTypeId: Serenity.LookupEditor;
        EmpId: Serenity.LookupEditor;
        UserCode: Serenity.StringEditor;
        AccountCodeClient: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        CodeCount: Serenity.IntegerEditor;
        Name: Serenity.StringEditor;
        NameForBankAdviceLetter: Serenity.StringEditor;
        ParentId: Serenity.LookupEditor;
        Remarks: Serenity.TextAreaEditor;
        IsActive: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        BudgetCode: Serenity.StringEditor;
        BudgetGroupId: Serenity.LookupEditor;
        FromCostCenter: Serenity.LookupEditor;
        ToCostCenter: Serenity.LookupEditor;
        ZoneName: Serenity.StringEditor;
        IsFixedAssetHead: Serenity.BooleanEditor;
        FixedAssetDevWorkTypeSelector: Serenity.RadioButtonEditor;
        DepreciationRate: Serenity.DecimalEditor;
    }

    export class AccCostCentreOrInstituteInformationForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccCostCentreOrInstituteInformation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCostCentreOrInstituteInformationForm.init)  {
                AccCostCentreOrInstituteInformationForm.init = true;

                var s = Serenity;
                var w0 = s.BooleanEditor;
                var w1 = s.LookupEditor;
                var w2 = s.StringEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.TextAreaEditor;
                var w5 = s.RadioButtonEditor;
                var w6 = s.DecimalEditor;

                Q.initFormType(AccCostCentreOrInstituteInformationForm, [
                    'IsInstitute', w0,
                    'CostCenterTypeId', w1,
                    'EmpId', w1,
                    'UserCode', w2,
                    'AccountCodeClient', w2,
                    'Code', w2,
                    'CodeCount', w3,
                    'Name', w2,
                    'NameForBankAdviceLetter', w2,
                    'ParentId', w1,
                    'Remarks', w4,
                    'IsActive', w0,
                    'IsBudgetHead', w0,
                    'BudgetCode', w2,
                    'BudgetGroupId', w1,
                    'FromCostCenter', w1,
                    'ToCostCenter', w1,
                    'ZoneName', w2,
                    'IsFixedAssetHead', w0,
                    'FixedAssetDevWorkTypeSelector', w5,
                    'DepreciationRate', w6
                ]);
            }
        }
    }
}

