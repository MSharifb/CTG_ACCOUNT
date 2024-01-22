namespace VistaGL.Transaction {
    export interface AccNoaForm {
        NoaNumber: Serenity.StringEditor;
        NoaDate: Serenity.DateEditor;
        CostCenterId: Serenity.LookupEditor;
        ContactValue: Serenity.DecimalEditor;
        NameofContract: Serenity.StringEditor;
        ContractDate: Serenity.DateEditor;
        BudgetProvision: Serenity.DecimalEditor;
        TenderNo: Serenity.StringEditor;
        AdministrativeApproved: Serenity.StringEditor;
        AdministrativeDate: Serenity.DateEditor;
        TechnicalApproved: Serenity.StringEditor;
        TechnicalDate: Serenity.DateEditor;
        FinancialApproved: Serenity.StringEditor;
        FinancialDate: Serenity.DateEditor;
        NameofContractor: Serenity.StringEditor;
        ContractorAddress: Serenity.StringEditor;
        SecurityMoney: Serenity.DecimalEditor;
        MBNo: Serenity.StringEditor;
        WorkStartOn: Serenity.DateEditor;
        CompilationDate: Serenity.DateEditor;
        ZoneInfoId: Serenity.IntegerEditor;
    }

    export class AccNoaForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccNoa';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccNoaForm.init)  {
                AccNoaForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.LookupEditor;
                var w3 = s.DecimalEditor;
                var w4 = s.IntegerEditor;

                Q.initFormType(AccNoaForm, [
                    'NoaNumber', w0,
                    'NoaDate', w1,
                    'CostCenterId', w2,
                    'ContactValue', w3,
                    'NameofContract', w0,
                    'ContractDate', w1,
                    'BudgetProvision', w3,
                    'TenderNo', w0,
                    'AdministrativeApproved', w0,
                    'AdministrativeDate', w1,
                    'TechnicalApproved', w0,
                    'TechnicalDate', w1,
                    'FinancialApproved', w0,
                    'FinancialDate', w1,
                    'NameofContractor', w0,
                    'ContractorAddress', w0,
                    'SecurityMoney', w3,
                    'MBNo', w0,
                    'WorkStartOn', w1,
                    'CompilationDate', w1,
                    'ZoneInfoId', w4
                ]);
            }
        }
    }
}

