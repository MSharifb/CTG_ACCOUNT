namespace VistaGL.Transaction {
    export interface AccTransactionTypeAssignRow {
        Id?: number;
        TrType?: string;
        ParentId?: number;
        CoaId?: number;
        MasterID?: number;
        ParentRemarks?: string;
        ParentSortOrder?: number;
        ParentTransactionType?: string;
        ParentFundControlId?: number;
        ParentVoucherTypeId?: number;
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
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccTransactionTypeAssignRow {
        export const idProperty = 'Id';
        export const nameProperty = 'CoaAccountName';
        export const localTextPrefix = 'Transaction.AccTransactionTypeAssign';
        export const lookupKey = 'Transaction.AccTransactionTypeAssign';

        export function getLookup(): Q.Lookup<AccTransactionTypeAssignRow> {
            return Q.getLookup<AccTransactionTypeAssignRow>('Transaction.AccTransactionTypeAssign');
        }

        export declare const enum Fields {
            Id = "Id",
            TrType = "TrType",
            ParentId = "ParentId",
            CoaId = "CoaId",
            MasterID = "MasterID",
            ParentRemarks = "ParentRemarks",
            ParentSortOrder = "ParentSortOrder",
            ParentTransactionType = "ParentTransactionType",
            ParentFundControlId = "ParentFundControlId",
            ParentVoucherTypeId = "ParentVoucherTypeId",
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
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

