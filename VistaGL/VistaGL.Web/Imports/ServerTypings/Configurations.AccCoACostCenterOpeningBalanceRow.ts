namespace VistaGL.Configurations {
    export interface AccCoACostCenterOpeningBalanceRow {
        Id?: number;
        CoAid?: number;
        CostCenterId?: number;
        OBDebit?: number;
        OBCredit?: number;
        ZoneId?: number;
        FundControlId?: number;
        CoAidAccountCode?: string;
        CoAidAccountCodeCount?: number;
        CoAidAccountGroup?: string;
        CoAidAccountName?: string;
        CoAidOpeningBalance?: number;
        CoAidRemarks?: string;
        CoAidFundControlId?: number;
        CoAidParentAccountId?: number;
        CoAidUserCode?: string;
        CoAidNoaAccTypeId?: number;
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterEntityId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterIsActive?: boolean;
        ZoneZoneName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccCoACostCenterOpeningBalanceRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccCoACostCenterOpeningBalance';
        export const lookupKey = 'Configurations.AccCoACostCenterOpeningBalance';

        export function getLookup(): Q.Lookup<AccCoACostCenterOpeningBalanceRow> {
            return Q.getLookup<AccCoACostCenterOpeningBalanceRow>('Configurations.AccCoACostCenterOpeningBalance');
        }

        export declare const enum Fields {
            Id = "Id",
            CoAid = "CoAid",
            CostCenterId = "CostCenterId",
            OBDebit = "OBDebit",
            OBCredit = "OBCredit",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            CoAidAccountCode = "CoAidAccountCode",
            CoAidAccountCodeCount = "CoAidAccountCodeCount",
            CoAidAccountGroup = "CoAidAccountGroup",
            CoAidAccountName = "CoAidAccountName",
            CoAidOpeningBalance = "CoAidOpeningBalance",
            CoAidRemarks = "CoAidRemarks",
            CoAidFundControlId = "CoAidFundControlId",
            CoAidParentAccountId = "CoAidParentAccountId",
            CoAidUserCode = "CoAidUserCode",
            CoAidNoaAccTypeId = "CoAidNoaAccTypeId",
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterIsActive = "CostCenterIsActive",
            ZoneZoneName = "ZoneZoneName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

