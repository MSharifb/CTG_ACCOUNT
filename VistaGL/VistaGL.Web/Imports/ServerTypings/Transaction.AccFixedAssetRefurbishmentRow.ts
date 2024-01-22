namespace VistaGL.Transaction {
    export interface AccFixedAssetRefurbishmentRow {
        Id?: number;
        CoaId?: number;
        FinancialYearId?: number;
        CostOpening?: number;
        CostAddition?: number;
        CostAdjustment?: number;
        CostClosing?: number;
        DepOpening?: number;
        DepCharge?: number;
        DepAdjustment?: number;
        DepClosing?: number;
        BookValue?: number;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        CoaIsBalanceSheet?: boolean;
        CoaBalanceSheetNotes?: number;
        CoaIsIncomeExpenditure?: boolean;
        CoaIncomeExpenditureNotes?: number;
        CoaBudgetCode?: string;
        CoaIsHideChildrenFromThisLevel?: boolean;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }

    export namespace AccFixedAssetRefurbishmentRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Transaction.AccFixedAssetRefurbishment';
        export const lookupKey = 'Transaction.AccFixedAssetRefurbishment';

        export function getLookup(): Q.Lookup<AccFixedAssetRefurbishmentRow> {
            return Q.getLookup<AccFixedAssetRefurbishmentRow>('Transaction.AccFixedAssetRefurbishment');
        }

        export declare const enum Fields {
            Id = "Id",
            CoaId = "CoaId",
            FinancialYearId = "FinancialYearId",
            CostOpening = "CostOpening",
            CostAddition = "CostAddition",
            CostAdjustment = "CostAdjustment",
            CostClosing = "CostClosing",
            DepOpening = "DepOpening",
            DepCharge = "DepCharge",
            DepAdjustment = "DepAdjustment",
            DepClosing = "DepClosing",
            BookValue = "BookValue",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            CoaIsBalanceSheet = "CoaIsBalanceSheet",
            CoaBalanceSheetNotes = "CoaBalanceSheetNotes",
            CoaIsIncomeExpenditure = "CoaIsIncomeExpenditure",
            CoaIncomeExpenditureNotes = "CoaIncomeExpenditureNotes",
            CoaBudgetCode = "CoaBudgetCode",
            CoaIsHideChildrenFromThisLevel = "CoaIsHideChildrenFromThisLevel",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId"
        }
    }
}

