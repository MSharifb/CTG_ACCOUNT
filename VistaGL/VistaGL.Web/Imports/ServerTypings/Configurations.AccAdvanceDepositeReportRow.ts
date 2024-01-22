namespace VistaGL.Configurations {
    export interface AccAdvanceDepositeReportRow {
        Id?: number;
        FinancialId?: number;
        SubledgerId?: number;
        OpeningBalance?: number;
        During?: number;
        FinancialIsActive?: boolean;
        FinancialIsClosed?: boolean;
        FinancialPeriodEndDate?: string;
        FinancialPeriodStartDate?: string;
        FinancialYearName?: string;
        FinancialFundControlInformationId?: number;
        SubledgerCode?: string;
        SubledgerCodeCount?: number;
        SubledgerUserCode?: string;
        SubledgerIsInstitute?: boolean;
        SubledgerName?: string;
        SubledgerNameForBankAdviceLetter?: string;
        SubledgerPaAmmount?: number;
        SubledgerRemarks?: string;
        SubledgerParentId?: number;
        SubledgerCostCenterTypeId?: number;
        SubledgerEmpId?: number;
        SubledgerIsActive?: boolean;
        SubledgerEntityId?: number;
        SubledgerZoneInfoId?: number;
        SubledgerIsBudgetHead?: boolean;
        SubledgerBudgetGroupId?: number;
        SubledgerIsFixedAssetHead?: boolean;
        SubledgerIsFixedAssetDevWork?: boolean;
        SubledgerIsFixedAssetNonDevWork?: boolean;
        SubledgerDepreciationRate?: number;
        SubledgerBudgetCode?: string;
    }

    export namespace AccAdvanceDepositeReportRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccAdvanceDepositeReport';
        export const lookupKey = 'Configurations.AccAdvanceDepositeReport';

        export function getLookup(): Q.Lookup<AccAdvanceDepositeReportRow> {
            return Q.getLookup<AccAdvanceDepositeReportRow>('Configurations.AccAdvanceDepositeReport');
        }

        export declare const enum Fields {
            Id = "Id",
            FinancialId = "FinancialId",
            SubledgerId = "SubledgerId",
            OpeningBalance = "OpeningBalance",
            During = "During",
            FinancialIsActive = "FinancialIsActive",
            FinancialIsClosed = "FinancialIsClosed",
            FinancialPeriodEndDate = "FinancialPeriodEndDate",
            FinancialPeriodStartDate = "FinancialPeriodStartDate",
            FinancialYearName = "FinancialYearName",
            FinancialFundControlInformationId = "FinancialFundControlInformationId",
            SubledgerCode = "SubledgerCode",
            SubledgerCodeCount = "SubledgerCodeCount",
            SubledgerUserCode = "SubledgerUserCode",
            SubledgerIsInstitute = "SubledgerIsInstitute",
            SubledgerName = "SubledgerName",
            SubledgerNameForBankAdviceLetter = "SubledgerNameForBankAdviceLetter",
            SubledgerPaAmmount = "SubledgerPaAmmount",
            SubledgerRemarks = "SubledgerRemarks",
            SubledgerParentId = "SubledgerParentId",
            SubledgerCostCenterTypeId = "SubledgerCostCenterTypeId",
            SubledgerEmpId = "SubledgerEmpId",
            SubledgerIsActive = "SubledgerIsActive",
            SubledgerEntityId = "SubledgerEntityId",
            SubledgerZoneInfoId = "SubledgerZoneInfoId",
            SubledgerIsBudgetHead = "SubledgerIsBudgetHead",
            SubledgerBudgetGroupId = "SubledgerBudgetGroupId",
            SubledgerIsFixedAssetHead = "SubledgerIsFixedAssetHead",
            SubledgerIsFixedAssetDevWork = "SubledgerIsFixedAssetDevWork",
            SubledgerIsFixedAssetNonDevWork = "SubledgerIsFixedAssetNonDevWork",
            SubledgerDepreciationRate = "SubledgerDepreciationRate",
            SubledgerBudgetCode = "SubledgerBudgetCode"
        }
    }
}

