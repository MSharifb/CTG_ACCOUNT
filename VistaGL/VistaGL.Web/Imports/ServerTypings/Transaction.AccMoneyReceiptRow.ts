namespace VistaGL.Transaction {
    export interface AccMoneyReceiptRow {
        Id?: number;
        MonryReceiptDate?: string;
        Amount?: number;
        AmountInWord?: string;
        Narration?: string;
        ChequeReceiveRegisterId?: number;
        SerialNo?: string;
        ReceiveFrom?: string;
        AccHeadBankId?: number;
        AccHeadBankName?: string;
        IsCancelled?: boolean;
        IsUsed?: boolean;
        VoucherId?: number;
        VoucherNo?: string;
        EntityId?: number;
        ZoneInfoId?: number;
        MoneyReceiptNo?: string;
        Dollar?: number;
        IsConfirmed?: boolean;
        CreditVoucherDate?: string;
        CreditVoucherNarration?: string;
        AccMoneyReceiptDatailsList?: AccMoneyReceiptDatailsRow[];
        ChequeReceiveRegisterAccountName?: string;
        ChequeReceiveRegisterAccountNo?: string;
        ChequeReceiveRegisterAmount?: number;
        ChequeReceiveRegisterAmountInWords?: string;
        ChequeReceiveRegisterBankName?: string;
        ChequeReceiveRegisterBranchName?: string;
        ChequeDate?: string;
        ChequeNo?: string;
        ChequeReceiveRegisterChequeReceiveDate?: string;
        ChequeType?: string;
        ChequeReceiveRegisterIsCancelled?: boolean;
        ChequeReceiveRegisterIsUsed?: boolean;
        ChequeReceiveRegisterReceiveType?: string;
        ChequeReceiveRegisterRemarks?: string;
        ChequeReceiveRegisterRecieveFrom?: string;
        ChequeReceiveRegisterEntityId?: number;
        ChequeReceiveRegisterZoneInfoId?: number;
        VouchervoucherNo?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccMoneyReceiptRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AmountInWord';
        export const localTextPrefix = 'Transaction.AccMoneyReceipt';
        export const lookupKey = 'Transaction.AccMoneyReceipt';

        export function getLookup(): Q.Lookup<AccMoneyReceiptRow> {
            return Q.getLookup<AccMoneyReceiptRow>('Transaction.AccMoneyReceipt');
        }

        export declare const enum Fields {
            Id = "Id",
            MonryReceiptDate = "MonryReceiptDate",
            Amount = "Amount",
            AmountInWord = "AmountInWord",
            Narration = "Narration",
            ChequeReceiveRegisterId = "ChequeReceiveRegisterId",
            SerialNo = "SerialNo",
            ReceiveFrom = "ReceiveFrom",
            AccHeadBankId = "AccHeadBankId",
            AccHeadBankName = "AccHeadBankName",
            IsCancelled = "IsCancelled",
            IsUsed = "IsUsed",
            VoucherId = "VoucherId",
            VoucherNo = "VoucherNo",
            EntityId = "EntityId",
            ZoneInfoId = "ZoneInfoId",
            MoneyReceiptNo = "MoneyReceiptNo",
            Dollar = "Dollar",
            IsConfirmed = "IsConfirmed",
            CreditVoucherDate = "CreditVoucherDate",
            CreditVoucherNarration = "CreditVoucherNarration",
            AccMoneyReceiptDatailsList = "AccMoneyReceiptDatailsList",
            ChequeReceiveRegisterAccountName = "ChequeReceiveRegisterAccountName",
            ChequeReceiveRegisterAccountNo = "ChequeReceiveRegisterAccountNo",
            ChequeReceiveRegisterAmount = "ChequeReceiveRegisterAmount",
            ChequeReceiveRegisterAmountInWords = "ChequeReceiveRegisterAmountInWords",
            ChequeReceiveRegisterBankName = "ChequeReceiveRegisterBankName",
            ChequeReceiveRegisterBranchName = "ChequeReceiveRegisterBranchName",
            ChequeDate = "ChequeDate",
            ChequeNo = "ChequeNo",
            ChequeReceiveRegisterChequeReceiveDate = "ChequeReceiveRegisterChequeReceiveDate",
            ChequeType = "ChequeType",
            ChequeReceiveRegisterIsCancelled = "ChequeReceiveRegisterIsCancelled",
            ChequeReceiveRegisterIsUsed = "ChequeReceiveRegisterIsUsed",
            ChequeReceiveRegisterReceiveType = "ChequeReceiveRegisterReceiveType",
            ChequeReceiveRegisterRemarks = "ChequeReceiveRegisterRemarks",
            ChequeReceiveRegisterRecieveFrom = "ChequeReceiveRegisterRecieveFrom",
            ChequeReceiveRegisterEntityId = "ChequeReceiveRegisterEntityId",
            ChequeReceiveRegisterZoneInfoId = "ChequeReceiveRegisterZoneInfoId",
            VouchervoucherNo = "VouchervoucherNo",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

