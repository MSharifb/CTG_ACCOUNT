namespace VistaGL.Transaction {
    export interface AccBudgetCircularRow {
        Id?: number;
        FinancialYearId?: number;
        FundControlId?: number;
        IsActive?: boolean;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBudgetCircularRow {
        export const idProperty = 'Id';
        export const nameProperty = 'FinancialYearYearName';
        export const localTextPrefix = 'Transaction.AccBudgetCircular';
        export const lookupKey = 'Transaction.AccBudgetCircular';

        export function getLookup(): Q.Lookup<AccBudgetCircularRow> {
            return Q.getLookup<AccBudgetCircularRow>('Transaction.AccBudgetCircular');
        }

        export declare const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            FundControlId = "FundControlId",
            IsActive = "IsActive",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

