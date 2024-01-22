namespace VistaGL.Configurations {
    export interface AccArDoubtfulDebtsRow {
        Id?: number;
        FinancialYearId?: number;
        DoubtfulDebtsAmount?: number;
        Receivable?: number;
        Adjusted?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }

    export namespace AccArDoubtfulDebtsRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccArDoubtfulDebts';
        export const lookupKey = 'Configurations.AccArDoubtfulDebts';

        export function getLookup(): Q.Lookup<AccArDoubtfulDebtsRow> {
            return Q.getLookup<AccArDoubtfulDebtsRow>('Configurations.AccArDoubtfulDebts');
        }

        export declare const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            DoubtfulDebtsAmount = "DoubtfulDebtsAmount",
            Receivable = "Receivable",
            Adjusted = "Adjusted",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId"
        }
    }
}

