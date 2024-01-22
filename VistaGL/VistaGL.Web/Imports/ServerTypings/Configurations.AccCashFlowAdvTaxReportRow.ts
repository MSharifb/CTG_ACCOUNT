namespace VistaGL.Configurations {
    export interface AccCashFlowAdvTaxReportRow {
        Id?: number;
        FinancialYearId?: number;
        AdvTaxAmount?: number;
        Opening?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }

    export namespace AccCashFlowAdvTaxReportRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccCashFlowAdvTaxReport';
        export const lookupKey = 'Configurations.AccCashFlowAdvTaxReport';

        export function getLookup(): Q.Lookup<AccCashFlowAdvTaxReportRow> {
            return Q.getLookup<AccCashFlowAdvTaxReportRow>('Configurations.AccCashFlowAdvTaxReport');
        }

        export declare const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            AdvTaxAmount = "AdvTaxAmount",
            Opening = "Opening",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId"
        }
    }
}

