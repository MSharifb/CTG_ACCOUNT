namespace VistaGL.Transaction {
    export interface AccBankReconciliationDirectRow {
        Id?: number;
        Amount?: number;
        ChequeDate?: string;
        ChequeNo?: string;
        ClearDate?: string;
        Description?: string;
        IsBankReconcile?: boolean;
        IsCash?: boolean;
        PaytoOrReciveFrom?: string;
        TransactionMode?: string;
        TransactionType?: string;
        VoucherDate?: string;
        VoucherNumber?: string;
        FundControlInformationId?: number;
        BankAccountInformationId?: number;
        ZoneInfoId?: number;
        VoucherDetailId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBankReconciliationDirectRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ChequeNo';
        export const localTextPrefix = 'Transaction.AccBankReconciliationDirect';
        export const lookupKey = 'Transaction.AccBankReconciliationDirect';

        export function getLookup(): Q.Lookup<AccBankReconciliationDirectRow> {
            return Q.getLookup<AccBankReconciliationDirectRow>('Transaction.AccBankReconciliationDirect');
        }

        export declare const enum Fields {
            Id = "Id",
            Amount = "Amount",
            ChequeDate = "ChequeDate",
            ChequeNo = "ChequeNo",
            ClearDate = "ClearDate",
            Description = "Description",
            IsBankReconcile = "IsBankReconcile",
            IsCash = "IsCash",
            PaytoOrReciveFrom = "PaytoOrReciveFrom",
            TransactionMode = "TransactionMode",
            TransactionType = "TransactionType",
            VoucherDate = "VoucherDate",
            VoucherNumber = "VoucherNumber",
            FundControlInformationId = "FundControlInformationId",
            BankAccountInformationId = "BankAccountInformationId",
            ZoneInfoId = "ZoneInfoId",
            VoucherDetailId = "VoucherDetailId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

