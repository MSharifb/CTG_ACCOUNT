namespace VistaGL.Configurations {
    export interface AccTransactionTypeRow {
        Id?: number;
        Remarks?: string;
        SortOrder?: number;
        TransactionType?: string;
        FundControlId?: number;
        VoucherTypeId?: number;
        TransactionMode?: string;
        IsbyDefault?: boolean;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlRemarks?: string;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccTransactionTypeRow {
        export const idProperty = 'Id';
        export const nameProperty = 'TransactionType';
        export const localTextPrefix = 'Configurations.AccTransactionType';
        export const lookupKey = 'Configurations.AccTransactionType';

        export function getLookup(): Q.Lookup<AccTransactionTypeRow> {
            return Q.getLookup<AccTransactionTypeRow>('Configurations.AccTransactionType');
        }

        export declare const enum Fields {
            Id = "Id",
            Remarks = "Remarks",
            SortOrder = "SortOrder",
            TransactionType = "TransactionType",
            FundControlId = "FundControlId",
            VoucherTypeId = "VoucherTypeId",
            TransactionMode = "TransactionMode",
            IsbyDefault = "IsbyDefault",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlRemarks = "FundControlRemarks",
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

