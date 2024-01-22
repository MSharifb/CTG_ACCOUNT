namespace VistaGL.Configurations {
    export interface AccPriorYearAdjustmentRow {
        Id?: number;
        FinancialYearId?: number;
        IncomeTax?: number;
        Adjustment?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }

    export namespace AccPriorYearAdjustmentRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccPriorYearAdjustment';
        export const lookupKey = 'Configurations.AccPriorYearAdjustment';

        export function getLookup(): Q.Lookup<AccPriorYearAdjustmentRow> {
            return Q.getLookup<AccPriorYearAdjustmentRow>('Configurations.AccPriorYearAdjustment');
        }

        export declare const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            IncomeTax = "IncomeTax",
            Adjustment = "Adjustment",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId"
        }
    }
}

