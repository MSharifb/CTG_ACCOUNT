namespace VistaGL.Configurations {
    export interface AccBankBranchInformationRow {
        Id?: number;
        BranchName?: string;
        Address?: string;
        Contacts?: string;
        Email?: string;
        Code?: string;
        BankId?: number;
        BankBankName?: string;
        BankCode?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBankBranchInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'BranchName';
        export const localTextPrefix = 'Configurations.AccBankBranchInformation';
        export const lookupKey = 'Configurations.AccBankBranchInformation';

        export function getLookup(): Q.Lookup<AccBankBranchInformationRow> {
            return Q.getLookup<AccBankBranchInformationRow>('Configurations.AccBankBranchInformation');
        }

        export declare const enum Fields {
            Id = "Id",
            BranchName = "BranchName",
            Address = "Address",
            Contacts = "Contacts",
            Email = "Email",
            Code = "Code",
            BankId = "BankId",
            BankBankName = "BankBankName",
            BankCode = "BankCode",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

