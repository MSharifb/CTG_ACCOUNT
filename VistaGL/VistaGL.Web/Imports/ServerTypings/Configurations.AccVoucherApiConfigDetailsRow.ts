namespace VistaGL.Configurations {
    export interface AccVoucherApiConfigDetailsRow {
        Id?: number;
        ConfigId?: number;
        AccountHeadId?: number;
        DrCr?: string;
        Description?: string;
        SubLedgerId?: number;
        ConfigConfigName?: string;
        ConfigModuleId?: string;
        ConfigFormName?: string;
        ConfigVouchrTypeId?: number;
        ConfigTransactionId?: number;
        ConfigTransactionMode?: string;
        ConfigNarration?: string;
        ConfigFundControlId?: number;
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

    export namespace AccVoucherApiConfigDetailsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'DrCr';
        export const localTextPrefix = 'Configurations.AccVoucherApiConfigDetails';
        export const lookupKey = 'Configurations.AccVoucherApiConfigDetails';

        export function getLookup(): Q.Lookup<AccVoucherApiConfigDetailsRow> {
            return Q.getLookup<AccVoucherApiConfigDetailsRow>('Configurations.AccVoucherApiConfigDetails');
        }

        export declare const enum Fields {
            Id = "Id",
            ConfigId = "ConfigId",
            AccountHeadId = "AccountHeadId",
            DrCr = "DrCr",
            Description = "Description",
            SubLedgerId = "SubLedgerId",
            ConfigConfigName = "ConfigConfigName",
            ConfigModuleId = "ConfigModuleId",
            ConfigFormName = "ConfigFormName",
            ConfigVouchrTypeId = "ConfigVouchrTypeId",
            ConfigTransactionId = "ConfigTransactionId",
            ConfigTransactionMode = "ConfigTransactionMode",
            ConfigNarration = "ConfigNarration",
            ConfigFundControlId = "ConfigFundControlId",
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

