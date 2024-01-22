namespace VistaGL.Configurations {
    export interface AccReportTypeCostCenterMappingRow {
        Id?: number;
        GroupId?: number;
        CostCenterId?: number;
        GroupParentId?: number;
        GroupReportTypeId?: number;
        GroupGroupName?: string;
        GroupSortingOrder?: number;
        GroupShowAutoSum?: boolean;
        GroupNoteNo?: number;
        GroupAddBlankSpaceBefore?: boolean;
        GroupAddBlankSpaceAfter?: boolean;
        GroupShowBottomBorder?: boolean;
        GroupShowUpperBorder?: boolean;
        GroupShowLeftBorder?: boolean;
        GroupShowRightBorder?: boolean;
        GroupFundControlId?: number;
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
        OpeningBalance?: number;
        ReportTypeId?: number;
    }

    export namespace AccReportTypeCostCenterMappingRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccReportTypeCostCenterMapping';
        export const lookupKey = 'Configurations.AccReportTypeCostCenterMapping';

        export function getLookup(): Q.Lookup<AccReportTypeCostCenterMappingRow> {
            return Q.getLookup<AccReportTypeCostCenterMappingRow>('Configurations.AccReportTypeCostCenterMapping');
        }

        export declare const enum Fields {
            Id = "Id",
            GroupId = "GroupId",
            CostCenterId = "CostCenterId",
            GroupParentId = "GroupParentId",
            GroupReportTypeId = "GroupReportTypeId",
            GroupGroupName = "GroupGroupName",
            GroupSortingOrder = "GroupSortingOrder",
            GroupShowAutoSum = "GroupShowAutoSum",
            GroupNoteNo = "GroupNoteNo",
            GroupAddBlankSpaceBefore = "GroupAddBlankSpaceBefore",
            GroupAddBlankSpaceAfter = "GroupAddBlankSpaceAfter",
            GroupShowBottomBorder = "GroupShowBottomBorder",
            GroupShowUpperBorder = "GroupShowUpperBorder",
            GroupShowLeftBorder = "GroupShowLeftBorder",
            GroupShowRightBorder = "GroupShowRightBorder",
            GroupFundControlId = "GroupFundControlId",
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
            OpeningBalance = "OpeningBalance",
            ReportTypeId = "ReportTypeId"
        }
    }
}

