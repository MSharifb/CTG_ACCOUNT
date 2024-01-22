namespace VistaGL.Transaction {
    export interface AccBudgetDetailsRow {
        Id?: number;
        BudgetId?: number;
        BudgetGroupId?: number;
        BudgetHeadId?: number;
        ParentId?: number;
        IsCoa?: boolean;
        IsBudgetHead?: boolean;
        IsCostCenter?: boolean;
        BudgetAmount?: number;
        BudgetCode?: string;
        BgSortOrder?: number;
        BudgetHeadName?: string;
        ZoneInfoId?: number;
        FinancialYearId?: number;
        EntityId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBudgetDetailsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'BudgetHeadName';
        export const localTextPrefix = 'Transaction.AccBudgetDetails';
        export const lookupKey = 'Transaction.AccBudgetDetails';

        export function getLookup(): Q.Lookup<AccBudgetDetailsRow> {
            return Q.getLookup<AccBudgetDetailsRow>('Transaction.AccBudgetDetails');
        }

        export declare const enum Fields {
            Id = "Id",
            BudgetId = "BudgetId",
            BudgetGroupId = "BudgetGroupId",
            BudgetHeadId = "BudgetHeadId",
            ParentId = "ParentId",
            IsCoa = "IsCoa",
            IsBudgetHead = "IsBudgetHead",
            IsCostCenter = "IsCostCenter",
            BudgetAmount = "BudgetAmount",
            BudgetCode = "BudgetCode",
            BgSortOrder = "BgSortOrder",
            BudgetHeadName = "BudgetHeadName",
            ZoneInfoId = "ZoneInfoId",
            FinancialYearId = "FinancialYearId",
            EntityId = "EntityId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

