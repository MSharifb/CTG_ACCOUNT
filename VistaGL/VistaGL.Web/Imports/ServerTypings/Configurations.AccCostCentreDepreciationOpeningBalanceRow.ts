namespace VistaGL.Configurations {
    export interface AccCostCentreDepreciationOpeningBalanceRow {
        Id?: number;
        CostCenterId?: number;
        OpeningBalanceDepreciation?: number;
        OpeningBalanceCost?: number;
        ZoneInfoId?: number;
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
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccCostCentreDepreciationOpeningBalanceRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccCostCentreDepreciationOpeningBalance';
        export const lookupKey = 'Configurations.AccCostCentreDepreciationOpeningBalance';

        export function getLookup(): Q.Lookup<AccCostCentreDepreciationOpeningBalanceRow> {
            return Q.getLookup<AccCostCentreDepreciationOpeningBalanceRow>('Configurations.AccCostCentreDepreciationOpeningBalance');
        }

        export declare const enum Fields {
            Id = "Id",
            CostCenterId = "CostCenterId",
            OpeningBalanceDepreciation = "OpeningBalanceDepreciation",
            OpeningBalanceCost = "OpeningBalanceCost",
            ZoneInfoId = "ZoneInfoId",
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
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

