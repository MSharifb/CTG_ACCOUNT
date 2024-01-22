namespace VistaGL.Configurations {
    export interface AccVoucherTypeRow {
        Id?: number;
        Name?: string;
        SortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccVoucherTypeRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Configurations.AccVoucherType';
        export const lookupKey = 'Configurations.AccVoucherType';

        export function getLookup(): Q.Lookup<AccVoucherTypeRow> {
            return Q.getLookup<AccVoucherTypeRow>('Configurations.AccVoucherType');
        }

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
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

