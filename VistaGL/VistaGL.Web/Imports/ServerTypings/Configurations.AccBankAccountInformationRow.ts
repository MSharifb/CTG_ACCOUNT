namespace VistaGL.Configurations {
    export interface AccBankAccountInformationRow {
        Id?: number;
        OpeningBalance?: number;
        OpeningDate?: string;
        AccountDescription?: string;
        AccountName?: string;
        AccountNumber?: string;
        Code?: string;
        CoaId?: number;
        BankId?: number;
        BankBranchId?: number;
        EntityId?: number;
        ZoneInfoId?: number;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaAccountGroup?: string;
        CoaAccountName?: string;
        CoaAccountNameBangla?: string;
        CoaCoaMapping?: string;
        CoaIsBillRef?: number;
        CoaIsBudgetHead?: number;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaLevel?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaOpeningBalance?: number;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaFundControlId?: number;
        CoaParentAccountId?: number;
        BankBankName?: string;
        BankCode?: string;
        BankBranchAddress?: string;
        BankBranchBranchName?: string;
        BankBranchCode?: string;
        BankBranchContacts?: string;
        BankBranchEmail?: string;
        BankBranchBankId?: number;
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

    export namespace AccBankAccountInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AccountNumber';
        export const localTextPrefix = 'Configurations.AccBankAccountInformation';
        export const lookupKey = 'Configurations.AccBankAccountInformation';

        export function getLookup(): Q.Lookup<AccBankAccountInformationRow> {
            return Q.getLookup<AccBankAccountInformationRow>('Configurations.AccBankAccountInformation');
        }

        export declare const enum Fields {
            Id = "Id",
            OpeningBalance = "OpeningBalance",
            OpeningDate = "OpeningDate",
            AccountDescription = "AccountDescription",
            AccountName = "AccountName",
            AccountNumber = "AccountNumber",
            Code = "Code",
            CoaId = "CoaId",
            BankId = "BankId",
            BankBranchId = "BankBranchId",
            EntityId = "EntityId",
            ZoneInfoId = "ZoneInfoId",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountName = "CoaAccountName",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsBillRef = "CoaIsBillRef",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaLevel = "CoaLevel",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaFundControlId = "CoaFundControlId",
            CoaParentAccountId = "CoaParentAccountId",
            BankBankName = "BankBankName",
            BankCode = "BankCode",
            BankBranchAddress = "BankBranchAddress",
            BankBranchBranchName = "BankBranchBranchName",
            BankBranchCode = "BankBranchCode",
            BankBranchContacts = "BankBranchContacts",
            BankBranchEmail = "BankBranchEmail",
            BankBranchBankId = "BankBranchBankId",
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

