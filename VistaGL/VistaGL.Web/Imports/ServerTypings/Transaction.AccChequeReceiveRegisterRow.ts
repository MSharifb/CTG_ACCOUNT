namespace VistaGL.Transaction {
    export interface AccChequeReceiveRegisterRow {
        Id?: number;
        AccountName?: string;
        AccountNo?: string;
        Amount?: number;
        AmountInWords?: string;
        BankName?: string;
        BranchName?: string;
        ChequeDate?: string;
        ChequeNo?: string;
        ChequeReceiveDate?: string;
        ChequeType?: string;
        IsCancelled?: boolean;
        IsUsed?: boolean;
        ReceiveType?: string;
        RecieveFrom?: string;
        EntityId?: number;
        Remarks?: string;
        ZoneInfoId?: number;
        EntityCode?: string;
        EntityFundControlName?: string;
        EntityRemarks?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccChequeReceiveRegisterRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AccountName';
        export const localTextPrefix = 'Transaction.AccChequeReceiveRegister';
        export const lookupKey = 'Transaction.AccChequeReceiveRegister';

        export function getLookup(): Q.Lookup<AccChequeReceiveRegisterRow> {
            return Q.getLookup<AccChequeReceiveRegisterRow>('Transaction.AccChequeReceiveRegister');
        }

        export declare const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            AccountNo = "AccountNo",
            Amount = "Amount",
            AmountInWords = "AmountInWords",
            BankName = "BankName",
            BranchName = "BranchName",
            ChequeDate = "ChequeDate",
            ChequeNo = "ChequeNo",
            ChequeReceiveDate = "ChequeReceiveDate",
            ChequeType = "ChequeType",
            IsCancelled = "IsCancelled",
            IsUsed = "IsUsed",
            ReceiveType = "ReceiveType",
            RecieveFrom = "RecieveFrom",
            EntityId = "EntityId",
            Remarks = "Remarks",
            ZoneInfoId = "ZoneInfoId",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
            EntityRemarks = "EntityRemarks",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

