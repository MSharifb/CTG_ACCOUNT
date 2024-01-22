namespace VistaGL.Transaction {
    export interface AccViewBudgetZoneForm {
        Id: Serenity.IntegerEditor;
        AccountName: Serenity.StringEditor;
        BudgetYearId: Serenity.IntegerEditor;
        BudgetStatus: Serenity.IntegerEditor;
        Quantity: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        ZoneInfoId: Serenity.IntegerEditor;
    }

    export class AccViewBudgetZoneForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccViewBudgetZone';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccViewBudgetZoneForm.init)  {
                AccViewBudgetZoneForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(AccViewBudgetZoneForm, [
                    'Id', w0,
                    'AccountName', w1,
                    'BudgetYearId', w0,
                    'BudgetStatus', w0,
                    'Quantity', w2,
                    'Amount', w2,
                    'ZoneInfoId', w0
                ]);
            }
        }
    }
}

