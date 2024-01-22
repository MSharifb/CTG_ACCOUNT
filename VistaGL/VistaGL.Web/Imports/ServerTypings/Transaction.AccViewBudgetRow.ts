namespace VistaGL.Transaction {
    export interface AccViewBudgetRow {
        Id?: number;
        AccountName?: string;
        Quantity?: number;
        Amount?: number;
        BudgetYearId?: number;
        BudgetStatus?: number;
    }

    export namespace AccViewBudgetRow {
        export const idProperty = 'AccountName';
        export const nameProperty = 'AccountName';
        export const localTextPrefix = 'Transaction.AccViewBudget';

        export declare const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            Quantity = "Quantity",
            Amount = "Amount",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus"
        }
    }
}

