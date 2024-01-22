namespace VistaGL.Configurations {
    export interface AccFinancialReportsDetailsRow {
        Id?: number;
        ReportType?: string;
        ZoneInfoId?: number;
        EntityId?: number;
        CoaId?: number;
        SubledgerId?: number;
        Opening?: number;
        ZoneInfoZoneName?: string;
        ZoneInfoZoneNameInBengali?: string;
        ZoneInfoZoneCode?: string;
        ZoneInfoSortOrder?: number;
        ZoneInfoOrganogramCategoryTypeId?: number;
        ZoneInfoZoneAddress?: string;
        ZoneInfoZoneAddressInBengali?: string;
        ZoneInfoPrefix?: string;
        ZoneInfoIsHeadOffice?: boolean;
        ZoneInfoZoneCodeForBillingSystem?: string;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        CoaIsBalanceSheet?: boolean;
        CoaBalanceSheetNotes?: number;
        CoaIsIncomeExpenditure?: boolean;
        CoaIncomeExpenditureNotes?: number;
        CoaBudgetCode?: string;
        CoaIsHideChildrenFromThisLevel?: boolean;
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

    export namespace AccFinancialReportsDetailsRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccFinancialReportsDetails';
        export const lookupKey = 'Configurations.AccFinancialReportsDetails';

        export function getLookup(): Q.Lookup<AccFinancialReportsDetailsRow> {
            return Q.getLookup<AccFinancialReportsDetailsRow>('Configurations.AccFinancialReportsDetails');
        }

        export declare const enum Fields {
            Id = "Id",
            ReportType = "ReportType",
            ZoneInfoId = "ZoneInfoId",
            EntityId = "EntityId",
            CoaId = "CoaId",
            SubledgerId = "SubledgerId",
            Opening = "Opening",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            ZoneInfoZoneNameInBengali = "ZoneInfoZoneNameInBengali",
            ZoneInfoZoneCode = "ZoneInfoZoneCode",
            ZoneInfoSortOrder = "ZoneInfoSortOrder",
            ZoneInfoOrganogramCategoryTypeId = "ZoneInfoOrganogramCategoryTypeId",
            ZoneInfoZoneAddress = "ZoneInfoZoneAddress",
            ZoneInfoZoneAddressInBengali = "ZoneInfoZoneAddressInBengali",
            ZoneInfoPrefix = "ZoneInfoPrefix",
            ZoneInfoIsHeadOffice = "ZoneInfoIsHeadOffice",
            ZoneInfoZoneCodeForBillingSystem = "ZoneInfoZoneCodeForBillingSystem",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            CoaIsBalanceSheet = "CoaIsBalanceSheet",
            CoaBalanceSheetNotes = "CoaBalanceSheetNotes",
            CoaIsIncomeExpenditure = "CoaIsIncomeExpenditure",
            CoaIncomeExpenditureNotes = "CoaIncomeExpenditureNotes",
            CoaBudgetCode = "CoaBudgetCode",
            CoaIsHideChildrenFromThisLevel = "CoaIsHideChildrenFromThisLevel",
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

