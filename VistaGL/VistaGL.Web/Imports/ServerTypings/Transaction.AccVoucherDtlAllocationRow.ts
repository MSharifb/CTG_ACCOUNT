namespace VistaGL.Transaction {
    export interface AccVoucherDtlAllocationRow {
        Id?: number;
        Amount?: number;
        CostCenterTypeId?: number;
        CostCenterParentId?: number;
        CostCenterId?: number;
        VoucherDetailId?: number;
        DebitAmount?: number;
        CreditAmount?: number;
        AdjustedChequeRegisterId?: number;
        CostCenterCode?: string;
        CostCenterUserCode?: string;
        CostCenterName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccVoucherDtlAllocationRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Transaction.AccVoucherDtlAllocation';
        export const lookupKey = 'Transaction.AccVoucherDtlAllocationRow';

        export function getLookup(): Q.Lookup<AccVoucherDtlAllocationRow> {
            return Q.getLookup<AccVoucherDtlAllocationRow>('Transaction.AccVoucherDtlAllocationRow');
        }

        export declare const enum Fields {
            Id = "Id",
            Amount = "Amount",
            CostCenterTypeId = "CostCenterTypeId",
            CostCenterParentId = "CostCenterParentId",
            CostCenterId = "CostCenterId",
            VoucherDetailId = "VoucherDetailId",
            DebitAmount = "DebitAmount",
            CreditAmount = "CreditAmount",
            AdjustedChequeRegisterId = "AdjustedChequeRegisterId",
            CostCenterCode = "CostCenterCode",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterName = "CostCenterName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

