namespace VistaGL.Transaction {
    export interface AccFixedAssetDepreciationRow {
        Id?: number;
        FinancialYearId?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
        ProcessType?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccFixedAssetDepreciationRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Transaction.AccFixedAssetDepreciation';
        export const lookupKey = 'Transaction.AccFixedAssetDepreciation';

        export function getLookup(): Q.Lookup<AccFixedAssetDepreciationRow> {
            return Q.getLookup<AccFixedAssetDepreciationRow>('Transaction.AccFixedAssetDepreciation');
        }

        export declare const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
            ProcessType = "ProcessType",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

