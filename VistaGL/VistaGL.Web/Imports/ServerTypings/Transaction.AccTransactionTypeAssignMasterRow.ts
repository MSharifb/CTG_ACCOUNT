namespace VistaGL.Transaction {
    export interface AccTransactionTypeAssignMasterRow {
        Id?: number;
        VoucherTypeId?: number;
        TransactionTypeId?: number;
        Remarks?: string;
        CoADebit?: AccTransactionTypeAssignRow[];
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
    }

    export namespace AccTransactionTypeAssignMasterRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Remarks';
        export const localTextPrefix = 'Transaction.AccTransactionTypeAssignMaster';
        export const lookupKey = 'Transaction.AccTransactionTypeAssignMaster';

        export function getLookup(): Q.Lookup<AccTransactionTypeAssignMasterRow> {
            return Q.getLookup<AccTransactionTypeAssignMasterRow>('Transaction.AccTransactionTypeAssignMaster');
        }

        export declare const enum Fields {
            Id = "Id",
            VoucherTypeId = "VoucherTypeId",
            TransactionTypeId = "TransactionTypeId",
            Remarks = "Remarks",
            CoADebit = "CoADebit",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId"
        }
    }
}

