namespace VistaGL.Transaction {
    export interface AccChequeRegisterRow {
        Id?: number;
        ChequeDate?: string;
        ChequeIssueDate?: string;
        BankAdviceDate?: string;
        ChequeNo?: string;
        ChequeType?: string;
        Amount?: number;
        PayTo?: string;
        ChequeNumhdn?: number;
        ChequeNoTemp?: string;
        AmountInWords?: string;
        IsCancelled?: boolean;
        IsPayment?: boolean;
        IsUsed?: boolean;
        isAdjusted?: boolean;
        PayeeBankName?: string;
        Remarks?: string;
        VoucherNo?: string;
        BankAccountInformationId?: number;
        VoucherInformationId?: number;
        EntityId?: number;
        ChequeBookId?: number;
        IsBankAdvice?: boolean;
        IsFinished?: boolean;
        ZoneInfoId?: number;
        BankAccountInformationAccountNumber?: string;
        BankAccountInformationCoaId?: number;
        VoucherInformationVoucherDate?: string;
        VoucherInformationVoucherNo?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccChequeRegisterRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ChequeNo';
        export const localTextPrefix = 'Transaction.AccChequeRegister';
        export const lookupKey = 'Transaction.AccChequeRegister';

        export function getLookup(): Q.Lookup<AccChequeRegisterRow> {
            return Q.getLookup<AccChequeRegisterRow>('Transaction.AccChequeRegister');
        }

        export declare const enum Fields {
            Id = "Id",
            ChequeDate = "ChequeDate",
            ChequeIssueDate = "ChequeIssueDate",
            BankAdviceDate = "BankAdviceDate",
            ChequeNo = "ChequeNo",
            ChequeType = "ChequeType",
            Amount = "Amount",
            PayTo = "PayTo",
            ChequeNumhdn = "ChequeNumhdn",
            ChequeNoTemp = "ChequeNoTemp",
            AmountInWords = "AmountInWords",
            IsCancelled = "IsCancelled",
            IsPayment = "IsPayment",
            IsUsed = "IsUsed",
            isAdjusted = "isAdjusted",
            PayeeBankName = "PayeeBankName",
            Remarks = "Remarks",
            VoucherNo = "VoucherNo",
            BankAccountInformationId = "BankAccountInformationId",
            VoucherInformationId = "VoucherInformationId",
            EntityId = "EntityId",
            ChequeBookId = "ChequeBookId",
            IsBankAdvice = "IsBankAdvice",
            IsFinished = "IsFinished",
            ZoneInfoId = "ZoneInfoId",
            BankAccountInformationAccountNumber = "BankAccountInformationAccountNumber",
            BankAccountInformationCoaId = "BankAccountInformationCoaId",
            VoucherInformationVoucherDate = "VoucherInformationVoucherDate",
            VoucherInformationVoucherNo = "VoucherInformationVoucherNo",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

