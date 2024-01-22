namespace VistaGL.Configurations {
    export interface AccVoucherApiDetailsRow {
        Id?: number;
        VoucherApiId?: number;
        AccountHeadId?: number;
        DrCr?: string;
        Description?: string;
        Amount?: number;
        VoucherApiConfigId?: number;
        VoucherApiVouchrTypeId?: number;
        VoucherApiTransactionId?: number;
        VoucherApiNarration?: string;
        VoucherApiTransactionMode?: string;
        VoucherApiEmpId?: number;
        AccountHeadAccountCode?: string;
        AccountHeadAccountCodeCount?: number;
        AccountHeadAccountGroup?: string;
        AccountHeadAccountName?: string;
        AccountHeadAccountNameBangla?: string;
        AccountHeadCoaMapping?: string;
        AccountHeadIsBillRef?: number;
        AccountHeadIsBudgetHead?: number;
        AccountHeadIsControlhead?: number;
        AccountHeadIsCostCenterAllocate?: number;
        AccountHeadLevel?: number;
        AccountHeadMailingAddress?: string;
        AccountHeadMailingName?: string;
        AccountHeadOpeningBalance?: number;
        AccountHeadRemarks?: string;
        AccountHeadTaxId?: string;
        AccountHeadUgcCode?: string;
        AccountHeadFundControlId?: number;
        AccountHeadParentAccountId?: number;
        AccountHeadMultiCurrencyId?: number;
        AccountHeadEffectCashFlow?: number;
        AccountHeadUserCode?: string;
    }

    export namespace AccVoucherApiDetailsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'DrCr';
        export const localTextPrefix = 'Configurations.AccVoucherApiDetails';
        export const lookupKey = 'Configurations.AccVoucherApiDetails';

        export function getLookup(): Q.Lookup<AccVoucherApiDetailsRow> {
            return Q.getLookup<AccVoucherApiDetailsRow>('Configurations.AccVoucherApiDetails');
        }

        export declare const enum Fields {
            Id = "Id",
            VoucherApiId = "VoucherApiId",
            AccountHeadId = "AccountHeadId",
            DrCr = "DrCr",
            Description = "Description",
            Amount = "Amount",
            VoucherApiConfigId = "VoucherApiConfigId",
            VoucherApiVouchrTypeId = "VoucherApiVouchrTypeId",
            VoucherApiTransactionId = "VoucherApiTransactionId",
            VoucherApiNarration = "VoucherApiNarration",
            VoucherApiTransactionMode = "VoucherApiTransactionMode",
            VoucherApiEmpId = "VoucherApiEmpId",
            AccountHeadAccountCode = "AccountHeadAccountCode",
            AccountHeadAccountCodeCount = "AccountHeadAccountCodeCount",
            AccountHeadAccountGroup = "AccountHeadAccountGroup",
            AccountHeadAccountName = "AccountHeadAccountName",
            AccountHeadAccountNameBangla = "AccountHeadAccountNameBangla",
            AccountHeadCoaMapping = "AccountHeadCoaMapping",
            AccountHeadIsBillRef = "AccountHeadIsBillRef",
            AccountHeadIsBudgetHead = "AccountHeadIsBudgetHead",
            AccountHeadIsControlhead = "AccountHeadIsControlhead",
            AccountHeadIsCostCenterAllocate = "AccountHeadIsCostCenterAllocate",
            AccountHeadLevel = "AccountHeadLevel",
            AccountHeadMailingAddress = "AccountHeadMailingAddress",
            AccountHeadMailingName = "AccountHeadMailingName",
            AccountHeadOpeningBalance = "AccountHeadOpeningBalance",
            AccountHeadRemarks = "AccountHeadRemarks",
            AccountHeadTaxId = "AccountHeadTaxId",
            AccountHeadUgcCode = "AccountHeadUgcCode",
            AccountHeadFundControlId = "AccountHeadFundControlId",
            AccountHeadParentAccountId = "AccountHeadParentAccountId",
            AccountHeadMultiCurrencyId = "AccountHeadMultiCurrencyId",
            AccountHeadEffectCashFlow = "AccountHeadEffectCashFlow",
            AccountHeadUserCode = "AccountHeadUserCode"
        }
    }
}

