namespace VistaGL.Transaction {
    export interface AccViewBudgetDetailsDeptRow {
        Id?: number;
        AccountName?: string;
        Quantity?: number;
        Amount?: number;
        ZoneInfoId?: number;
        BudgetYearId?: number;
        BudgetStatus?: number;
        BudgetDepartmentInfoId?: number;
        BudgetDept?: string;
        YearName?: string;
        ActualDuring?: number;
        Actual1stSixMonths?: number;
        BudgetApproved?: number;
        RevisedEstimate?: number;
    }

    export namespace AccViewBudgetDetailsDeptRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AccountName';
        export const localTextPrefix = 'Transaction.AccViewBudgetDetailsDept';
        export const lookupKey = 'Transaction.AccViewBudgetDetailsDeptRow';

        export function getLookup(): Q.Lookup<AccViewBudgetDetailsDeptRow> {
            return Q.getLookup<AccViewBudgetDetailsDeptRow>('Transaction.AccViewBudgetDetailsDeptRow');
        }

        export declare const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            Quantity = "Quantity",
            Amount = "Amount",
            ZoneInfoId = "ZoneInfoId",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus",
            BudgetDepartmentInfoId = "BudgetDepartmentInfoId",
            BudgetDept = "BudgetDept",
            YearName = "YearName",
            ActualDuring = "ActualDuring",
            Actual1stSixMonths = "Actual1stSixMonths",
            BudgetApproved = "BudgetApproved",
            RevisedEstimate = "RevisedEstimate"
        }
    }
}

