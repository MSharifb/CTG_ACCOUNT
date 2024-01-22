namespace VistaGL.Configurations {
    export interface AccCostCenterTypeRow {
        Id?: number;
        CostCenterType?: string;
        SortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccCostCenterTypeRow {
        export const idProperty = 'Id';
        export const nameProperty = 'CostCenterType';
        export const localTextPrefix = 'Configurations.AccCostCenterType';
        export const lookupKey = 'Configurations.AccCostCenterType';

        export function getLookup(): Q.Lookup<AccCostCenterTypeRow> {
            return Q.getLookup<AccCostCenterTypeRow>('Configurations.AccCostCenterType');
        }

        export declare const enum Fields {
            Id = "Id",
            CostCenterType = "CostCenterType",
            SortOrder = "SortOrder",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

