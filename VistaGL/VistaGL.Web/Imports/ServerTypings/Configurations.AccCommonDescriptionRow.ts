namespace VistaGL.Configurations {
    export interface AccCommonDescriptionRow {
        Id?: number;
        Description?: string;
        TransactionTypeId?: number;
        VoucherTypeId?: number;
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
        TransactionTypeVoucherTypeId?: number;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccCommonDescriptionRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Description';
        export const localTextPrefix = 'Configurations.AccCommonDescription';
        export const lookupKey = 'Configurations.AccCommonDescription';

        export function getLookup(): Q.Lookup<AccCommonDescriptionRow> {
            return Q.getLookup<AccCommonDescriptionRow>('Configurations.AccCommonDescription');
        }

        export declare const enum Fields {
            Id = "Id",
            Description = "Description",
            TransactionTypeId = "TransactionTypeId",
            VoucherTypeId = "VoucherTypeId",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId",
            TransactionTypeVoucherTypeId = "TransactionTypeVoucherTypeId",
            VoucherTypeName = "VoucherTypeName",
            VoucherTypeSortOrder = "VoucherTypeSortOrder",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

