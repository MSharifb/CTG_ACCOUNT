namespace VistaGL.Configurations {
    export interface AccBankInformationRow {
        Id?: number;
        BankName?: string;
        Code?: string;
        BankBranchInformations?: AccBankBranchInformationRow[];
        ZoneInfoId?: number;
        ZoneInfoZoneName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBankInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'BankName';
        export const localTextPrefix = 'Configurations.AccBankInformation';
        export const lookupKey = 'Configurations.AccBankInformation';

        export function getLookup(): Q.Lookup<AccBankInformationRow> {
            return Q.getLookup<AccBankInformationRow>('Configurations.AccBankInformation');
        }

        export declare const enum Fields {
            Id = "Id",
            BankName = "BankName",
            Code = "Code",
            BankBranchInformations = "BankBranchInformations",
            ZoneInfoId = "ZoneInfoId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

