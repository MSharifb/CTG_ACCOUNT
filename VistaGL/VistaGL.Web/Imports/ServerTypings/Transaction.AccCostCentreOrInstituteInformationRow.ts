namespace VistaGL.Transaction {
    export interface AccCostCentreOrInstituteInformationRow {
        Id?: number;
        AccountCodeClient?: string;
        Code?: string;
        CodeCount?: number;
        UserCode?: string;
        IsInstitute?: boolean;
        NameForBankAdviceLetter?: string;
        Name?: string;
        PaAmmount?: number;
        Remarks?: string;
        ParentId?: number;
        CostCenterTypeId?: number;
        EmpId?: number;
        IsActive?: boolean;
        TotalVoucherDtlAlo?: number;
        ZoneInfoId?: number;
        EntityId?: number;
        IsBudgetHead?: number;
        BudgetGroupId?: number;
        BudgetCode?: string;
        LookupText?: string;
        FromCostCenter?: number;
        ToCostCenter?: number;
        IsFixedAssetHead?: boolean;
        IsFixedAssetDevWork?: boolean;
        IsFixedAssetNonDevWork?: boolean;
        DepreciationRate?: number;
        FixedAssetDevWorkTypeSelector?: number;
        ParentCode?: string;
        ParentIsInstitute?: boolean;
        ParentName?: string;
        ParentPaAmmount?: number;
        ParentRemarks?: string;
        ParentParentId?: number;
        ParentEntityId?: number;
        ParentCostCenterTypeId?: number;
        EntityCode?: string;
        EntityFundControlName?: string;
        EntityRemarks?: string;
        CostCenterType?: string;
        CostCenterTypeSortOrder?: number;
        ZoneName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccCostCentreOrInstituteInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'LookupText';
        export const localTextPrefix = 'Transaction.AccCostCentreOrInstituteInformation';
        export const lookupKey = 'Transaction.AccCostCentreOrInstituteInformation';

        export function getLookup(): Q.Lookup<AccCostCentreOrInstituteInformationRow> {
            return Q.getLookup<AccCostCentreOrInstituteInformationRow>('Transaction.AccCostCentreOrInstituteInformation');
        }

        export declare const enum Fields {
            Id = "Id",
            AccountCodeClient = "AccountCodeClient",
            Code = "Code",
            CodeCount = "CodeCount",
            UserCode = "UserCode",
            IsInstitute = "IsInstitute",
            NameForBankAdviceLetter = "NameForBankAdviceLetter",
            Name = "Name",
            PaAmmount = "PaAmmount",
            Remarks = "Remarks",
            ParentId = "ParentId",
            CostCenterTypeId = "CostCenterTypeId",
            EmpId = "EmpId",
            IsActive = "IsActive",
            TotalVoucherDtlAlo = "TotalVoucherDtlAlo",
            ZoneInfoId = "ZoneInfoId",
            EntityId = "EntityId",
            IsBudgetHead = "IsBudgetHead",
            BudgetGroupId = "BudgetGroupId",
            BudgetCode = "BudgetCode",
            LookupText = "LookupText",
            FromCostCenter = "FromCostCenter",
            ToCostCenter = "ToCostCenter",
            IsFixedAssetHead = "IsFixedAssetHead",
            IsFixedAssetDevWork = "IsFixedAssetDevWork",
            IsFixedAssetNonDevWork = "IsFixedAssetNonDevWork",
            DepreciationRate = "DepreciationRate",
            FixedAssetDevWorkTypeSelector = "FixedAssetDevWorkTypeSelector",
            ParentCode = "ParentCode",
            ParentIsInstitute = "ParentIsInstitute",
            ParentName = "ParentName",
            ParentPaAmmount = "ParentPaAmmount",
            ParentRemarks = "ParentRemarks",
            ParentParentId = "ParentParentId",
            ParentEntityId = "ParentEntityId",
            ParentCostCenterTypeId = "ParentCostCenterTypeId",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
            EntityRemarks = "EntityRemarks",
            CostCenterType = "CostCenterType",
            CostCenterTypeSortOrder = "CostCenterTypeSortOrder",
            ZoneName = "ZoneName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

