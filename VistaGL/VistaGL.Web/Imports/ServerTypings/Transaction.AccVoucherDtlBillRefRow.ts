namespace VistaGL.Transaction {
    export interface AccVoucherDtlBillRefRow {
        Id?: number;
        Amount?: number;
        BillDate?: string;
        BillRefNo?: string;
        BillType?: string;
        Description?: string;
        IsPaymentComplete?: number;
        VoucherDetailId?: number;
        VoucherDetailCreditAmount?: number;
        VoucherDetailDebitAmount?: number;
        VoucherDetailDescription?: string;
        VoucherDetailIsPayorReceiveHead?: number;
        VoucherDetailChartofAccountsId?: number;
        VoucherDetailVoucherInformationId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccVoucherDtlBillRefRow {
        export const idProperty = 'Id';
        export const nameProperty = 'BillRefNo';
        export const localTextPrefix = 'Transaction.AccVoucherDtlBillRef';
        export const lookupKey = 'Transaction.AccVoucherDtlBillRefRow';

        export function getLookup(): Q.Lookup<AccVoucherDtlBillRefRow> {
            return Q.getLookup<AccVoucherDtlBillRefRow>('Transaction.AccVoucherDtlBillRefRow');
        }

        export declare const enum Fields {
            Id = "Id",
            Amount = "Amount",
            BillDate = "BillDate",
            BillRefNo = "BillRefNo",
            BillType = "BillType",
            Description = "Description",
            IsPaymentComplete = "IsPaymentComplete",
            VoucherDetailId = "VoucherDetailId",
            VoucherDetailCreditAmount = "VoucherDetailCreditAmount",
            VoucherDetailDebitAmount = "VoucherDetailDebitAmount",
            VoucherDetailDescription = "VoucherDetailDescription",
            VoucherDetailIsPayorReceiveHead = "VoucherDetailIsPayorReceiveHead",
            VoucherDetailChartofAccountsId = "VoucherDetailChartofAccountsId",
            VoucherDetailVoucherInformationId = "VoucherDetailVoucherInformationId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

