namespace VistaGL.Transaction {
    export interface AccViewBudgetDetailsRow {
        Id?: number;
        AccountName?: string;
        Quantity?: number;
        Amount?: number;
        ActualDuring?: number;
        Actual1stSixMonths?: number;
        BudgetApproved?: number;
        RevisedEstimate?: number;
        ZoneInfoId?: number;
        BudgetYearId?: number;
        BudgetStatus?: number;
        YearName?: string;
        ZoneName?: string;
        ZoneCode?: string;
    }

    export namespace AccViewBudgetDetailsRow {
        export const idProperty = 'AccountName';
        export const nameProperty = 'AccountName';
        export const localTextPrefix = 'Transaction.AccViewBudgetDetails';

        export declare const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            Quantity = "Quantity",
            Amount = "Amount",
            ActualDuring = "ActualDuring",
            Actual1stSixMonths = "Actual1stSixMonths",
            BudgetApproved = "BudgetApproved",
            RevisedEstimate = "RevisedEstimate",
            ZoneInfoId = "ZoneInfoId",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus",
            YearName = "YearName",
            ZoneName = "ZoneName",
            ZoneCode = "ZoneCode"
        }
    }
}

