namespace VistaGL.Transaction {
    export interface AccViewBudgetZoneRow {
        Id?: number;
        AccountName?: string;
        BudgetYearId?: number;
        BudgetStatus?: number;
        Quantity?: number;
        Amount?: number;
        ZoneInfoId?: number;
    }

    export namespace AccViewBudgetZoneRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AccountName';
        export const localTextPrefix = 'Transaction.AccViewBudgetZone';
        export const lookupKey = 'Transaction.AccViewBudgetZoneRow';

        export function getLookup(): Q.Lookup<AccViewBudgetZoneRow> {
            return Q.getLookup<AccViewBudgetZoneRow>('Transaction.AccViewBudgetZoneRow');
        }

        export declare const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus",
            Quantity = "Quantity",
            Amount = "Amount",
            ZoneInfoId = "ZoneInfoId"
        }
    }
}

