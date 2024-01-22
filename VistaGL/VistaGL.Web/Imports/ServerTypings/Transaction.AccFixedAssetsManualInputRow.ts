namespace VistaGL.Transaction {
    export interface AccFixedAssetsManualInputRow {
        Id?: number;
        CostCenterId?: number;
        FinancialYearId?: number;
        ZoneInfoId?: number;
        AdditionAmount?: number;
        AdjustmentAmount?: number;
        DepCharge?: number;
        DepAdjustment?: number;
        FundControlId?: number;
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterNameForBankAdviceLetter?: string;
        CostCenterPaAmmount?: number;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterEmpId?: number;
        CostCenterIsActive?: boolean;
        CostCenterEntityId?: number;
        CostCenterZoneInfoId?: number;
        CostCenterIsBudgetHead?: boolean;
        CostCenterBudgetGroupId?: number;
        CostCenterIsFixedAssetHead?: boolean;
        CostCenterIsFixedAssetDevWork?: boolean;
        CostCenterIsFixedAssetNonDevWork?: boolean;
        CostCenterDepreciationRate?: number;
        CostCenterBudgetCode?: string;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
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
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccFixedAssetsManualInputRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Transaction.AccFixedAssetsManualInput';
        export const lookupKey = 'Transaction.AccFixedAssetsManualInput';

        export function getLookup(): Q.Lookup<AccFixedAssetsManualInputRow> {
            return Q.getLookup<AccFixedAssetsManualInputRow>('Transaction.AccFixedAssetsManualInput');
        }

        export declare const enum Fields {
            Id = "Id",
            CostCenterId = "CostCenterId",
            FinancialYearId = "FinancialYearId",
            ZoneInfoId = "ZoneInfoId",
            AdditionAmount = "AdditionAmount",
            AdjustmentAmount = "AdjustmentAmount",
            DepCharge = "DepCharge",
            DepAdjustment = "DepAdjustment",
            FundControlId = "FundControlId",
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterNameForBankAdviceLetter = "CostCenterNameForBankAdviceLetter",
            CostCenterPaAmmount = "CostCenterPaAmmount",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterEmpId = "CostCenterEmpId",
            CostCenterIsActive = "CostCenterIsActive",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterZoneInfoId = "CostCenterZoneInfoId",
            CostCenterIsBudgetHead = "CostCenterIsBudgetHead",
            CostCenterBudgetGroupId = "CostCenterBudgetGroupId",
            CostCenterIsFixedAssetHead = "CostCenterIsFixedAssetHead",
            CostCenterIsFixedAssetDevWork = "CostCenterIsFixedAssetDevWork",
            CostCenterIsFixedAssetNonDevWork = "CostCenterIsFixedAssetNonDevWork",
            CostCenterDepreciationRate = "CostCenterDepreciationRate",
            CostCenterBudgetCode = "CostCenterBudgetCode",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
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
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

