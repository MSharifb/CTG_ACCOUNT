namespace VistaGL.Transaction {
    export interface AccChequeBookRow {
        Id?: number;
        CheckBookName?: string;
        EndingNo?: number;
        HasFinished?: boolean;
        StartingNo?: string;
        EntityId?: number;
        BankAccountInformationId?: number;
        PageNo?: number;
        Prefix?: string;
        ZoneInfoId?: number;
        CBDate?: string;
        EntityCode?: string;
        EntityFundControlName?: string;
        EntityRemarks?: string;
        BankAccountInformationAccountDescription?: string;
        BankAccountInformationAccountName?: string;
        BankAccountInformationAccountNumber?: string;
        BankAccountInformationCode?: string;
        BankAccountInformationCoaId?: number;
        BankAccountInformationBankId?: number;
        BankAccountInformationBankBranchId?: number;
        BankAccountInformationEntityId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccChequeBookRow {
        export const idProperty = 'Id';
        export const nameProperty = 'CheckBookName';
        export const localTextPrefix = 'Transaction.AccChequeBook';
        export const lookupKey = 'Transaction.AccChequeBook';

        export function getLookup(): Q.Lookup<AccChequeBookRow> {
            return Q.getLookup<AccChequeBookRow>('Transaction.AccChequeBook');
        }

        export declare const enum Fields {
            Id = "Id",
            CheckBookName = "CheckBookName",
            EndingNo = "EndingNo",
            HasFinished = "HasFinished",
            StartingNo = "StartingNo",
            EntityId = "EntityId",
            BankAccountInformationId = "BankAccountInformationId",
            PageNo = "PageNo",
            Prefix = "Prefix",
            ZoneInfoId = "ZoneInfoId",
            CBDate = "CBDate",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
            EntityRemarks = "EntityRemarks",
            BankAccountInformationAccountDescription = "BankAccountInformationAccountDescription",
            BankAccountInformationAccountName = "BankAccountInformationAccountName",
            BankAccountInformationAccountNumber = "BankAccountInformationAccountNumber",
            BankAccountInformationCode = "BankAccountInformationCode",
            BankAccountInformationCoaId = "BankAccountInformationCoaId",
            BankAccountInformationBankId = "BankAccountInformationBankId",
            BankAccountInformationBankBranchId = "BankAccountInformationBankBranchId",
            BankAccountInformationEntityId = "BankAccountInformationEntityId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

