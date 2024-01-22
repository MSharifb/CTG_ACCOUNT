namespace VistaGL.Configurations {
    export interface AccChartofAccountsRow {
        Id?: number;
        AccountCode?: string;
        UserCode?: string;
        AccountCodeCount?: number;
        AccountGroup?: string;
        AccountName?: string;
        AccountNameBangla?: string;
        CoaMapping?: string;
        IsBillRef?: number;
        IsBudgetHead?: number;
        IsControlhead?: number;
        IsCostCenterAllocate?: number;
        Level?: number;
        MailingAddress?: string;
        MailingName?: string;
        Remarks?: string;
        TaxId?: string;
        UgcCode?: string;
        FundControlId?: number;
        ParentAccountId?: number;
        MultiCurrencyId?: number;
        MultiCurrencyCurrency?: string;
        EffectCashFlow?: number;
        NoaAccTypeId?: number;
        SortOrder?: number;
        ShowSumInReceiptPaymentReport?: boolean;
        IsHideChildrenFromThisLevel?: boolean;
        BudgetCode?: string;
        IsIncomeExpenditure?: boolean;
        BalanceSheetNotes?: number;
        IncomeExpenditureNotes?: number;
        BudgetGroupId?: number;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlRemarks?: string;
        ParentAccountAccountCode?: string;
        ParentAccountAccountCodeCount?: number;
        ParentAccountAccountGroup?: string;
        ParentAccountAccountName?: string;
        ParentAccountAccountNameBangla?: string;
        ParentAccountCoaMapping?: string;
        ParentAccountIsBudgetHead?: number;
        ParentAccountIsControlhead?: number;
        ParentAccountIsCostCenterAllocate?: number;
        ParentAccountLevel?: number;
        ParentAccountOpeningBalance?: number;
        ParentAccountRemarks?: string;
        ParentAccountFundControlId?: number;
        ParentAccountParentAccountId?: number;
        AccOpeningBalanceId?: number;
        OpeningBalance?: number;
        AccOpeningBalance?: number;
        iSCoAUsed?: number;
        NoaAccTypeId2?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccChartofAccountsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AccountName';
        export const localTextPrefix = 'Configurations.AccChartofAccounts';
        export const lookupKey = 'Configurations.AccChartofAccounts';

        export function getLookup(): Q.Lookup<AccChartofAccountsRow> {
            return Q.getLookup<AccChartofAccountsRow>('Configurations.AccChartofAccounts');
        }

        export declare const enum Fields {
            Id = "Id",
            AccountCode = "AccountCode",
            UserCode = "UserCode",
            AccountCodeCount = "AccountCodeCount",
            AccountGroup = "AccountGroup",
            AccountName = "AccountName",
            AccountNameBangla = "AccountNameBangla",
            CoaMapping = "CoaMapping",
            IsBillRef = "IsBillRef",
            IsBudgetHead = "IsBudgetHead",
            IsControlhead = "IsControlhead",
            IsCostCenterAllocate = "IsCostCenterAllocate",
            Level = "Level",
            MailingAddress = "MailingAddress",
            MailingName = "MailingName",
            Remarks = "Remarks",
            TaxId = "TaxId",
            UgcCode = "UgcCode",
            FundControlId = "FundControlId",
            ParentAccountId = "ParentAccountId",
            MultiCurrencyId = "MultiCurrencyId",
            MultiCurrencyCurrency = "MultiCurrencyCurrency",
            EffectCashFlow = "EffectCashFlow",
            NoaAccTypeId = "NoaAccTypeId",
            SortOrder = "SortOrder",
            ShowSumInReceiptPaymentReport = "ShowSumInReceiptPaymentReport",
            IsHideChildrenFromThisLevel = "IsHideChildrenFromThisLevel",
            BudgetCode = "BudgetCode",
            IsIncomeExpenditure = "IsIncomeExpenditure",
            BalanceSheetNotes = "BalanceSheetNotes",
            IncomeExpenditureNotes = "IncomeExpenditureNotes",
            BudgetGroupId = "BudgetGroupId",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlRemarks = "FundControlRemarks",
            ParentAccountAccountCode = "ParentAccountAccountCode",
            ParentAccountAccountCodeCount = "ParentAccountAccountCodeCount",
            ParentAccountAccountGroup = "ParentAccountAccountGroup",
            ParentAccountAccountName = "ParentAccountAccountName",
            ParentAccountAccountNameBangla = "ParentAccountAccountNameBangla",
            ParentAccountCoaMapping = "ParentAccountCoaMapping",
            ParentAccountIsBudgetHead = "ParentAccountIsBudgetHead",
            ParentAccountIsControlhead = "ParentAccountIsControlhead",
            ParentAccountIsCostCenterAllocate = "ParentAccountIsCostCenterAllocate",
            ParentAccountLevel = "ParentAccountLevel",
            ParentAccountOpeningBalance = "ParentAccountOpeningBalance",
            ParentAccountRemarks = "ParentAccountRemarks",
            ParentAccountFundControlId = "ParentAccountFundControlId",
            ParentAccountParentAccountId = "ParentAccountParentAccountId",
            AccOpeningBalanceId = "AccOpeningBalanceId",
            OpeningBalance = "OpeningBalance",
            AccOpeningBalance = "AccOpeningBalance",
            iSCoAUsed = "iSCoAUsed",
            NoaAccTypeId2 = "NoaAccTypeId2",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

