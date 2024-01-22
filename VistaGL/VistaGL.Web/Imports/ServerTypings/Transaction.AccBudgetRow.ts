namespace VistaGL.Transaction {
    export interface AccBudgetRow {
        Id?: number;
        FinancialYearId?: number;
        ZoneInfoId?: number;
        EntityId?: number;
        IsApproved?: boolean;
        Attachment?: string;
        FinancialYearYearName?: string;
        ZoneInfoZoneName?: string;
        BudgetDetails?: AccBudgetDetailsRow[];
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBudgetRow {
        export const idProperty = 'Id';
        export const nameProperty = 'FinancialYearYearName';
        export const localTextPrefix = 'Transaction.AccBudget';
        export const lookupKey = 'Transaction.AccBudget';

        export function getLookup(): Q.Lookup<AccBudgetRow> {
            return Q.getLookup<AccBudgetRow>('Transaction.AccBudget');
        }

        export declare const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            ZoneInfoId = "ZoneInfoId",
            EntityId = "EntityId",
            IsApproved = "IsApproved",
            Attachment = "Attachment",
            FinancialYearYearName = "FinancialYearYearName",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            BudgetDetails = "BudgetDetails",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

