namespace VistaGL.Transaction {
    export interface AccMoneyReceiptDatailsRow {
        Id?: number;
        MoneyReceiptId?: number;
        CoaId?: number;
        CostCenterId?: number;
        Amount?: number;
        MoneyReceiptSerialNo?: string;
        MoneyReceiptMonryReceiptDate?: string;
        MoneyReceiptAmount?: number;
        MoneyReceiptAmountInWord?: string;
        MoneyReceiptNarration?: string;
        MoneyReceiptChequeReceiveRegisterId?: number;
        MoneyReceiptAccHeadBankId?: number;
        MoneyReceiptIsCancelled?: boolean;
        MoneyReceiptIsUsed?: boolean;
        MoneyReceiptVoucherId?: number;
        MoneyReceiptEntityId?: number;
        MoneyReceiptZoneInfoId?: number;
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
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterNameForBankAdviceLetter?: string;
        CostCenterPaAmmount?: number;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterEmpId?: number;
        CostCenterIsActive?: boolean;
        CostCenterEntityId?: number;
        CostCenterZoneInfoId?: number;
        CostCenterIsBudgetHead?: boolean;
        CostCenterBudgetGroupId?: number;
        CostCenterIsFixedAssetHead?: boolean;
        CostCenterIsFixedAssetDevWork?: boolean;
        CostCenterIsFixedAssetNonDevWork?: boolean;
        CostCenterDepreciationRate?: number;
        CostCenterBudgetCode?: string;
        Description?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccMoneyReceiptDatailsRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Transaction.AccMoneyReceiptDatails';
        export const lookupKey = 'Transaction.AccMoneyReceiptDatails';

        export function getLookup(): Q.Lookup<AccMoneyReceiptDatailsRow> {
            return Q.getLookup<AccMoneyReceiptDatailsRow>('Transaction.AccMoneyReceiptDatails');
        }

        export declare const enum Fields {
            Id = "Id",
            MoneyReceiptId = "MoneyReceiptId",
            CoaId = "CoaId",
            CostCenterId = "CostCenterId",
            Amount = "Amount",
            MoneyReceiptSerialNo = "MoneyReceiptSerialNo",
            MoneyReceiptMonryReceiptDate = "MoneyReceiptMonryReceiptDate",
            MoneyReceiptAmount = "MoneyReceiptAmount",
            MoneyReceiptAmountInWord = "MoneyReceiptAmountInWord",
            MoneyReceiptNarration = "MoneyReceiptNarration",
            MoneyReceiptChequeReceiveRegisterId = "MoneyReceiptChequeReceiveRegisterId",
            MoneyReceiptAccHeadBankId = "MoneyReceiptAccHeadBankId",
            MoneyReceiptIsCancelled = "MoneyReceiptIsCancelled",
            MoneyReceiptIsUsed = "MoneyReceiptIsUsed",
            MoneyReceiptVoucherId = "MoneyReceiptVoucherId",
            MoneyReceiptEntityId = "MoneyReceiptEntityId",
            MoneyReceiptZoneInfoId = "MoneyReceiptZoneInfoId",
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
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterNameForBankAdviceLetter = "CostCenterNameForBankAdviceLetter",
            CostCenterPaAmmount = "CostCenterPaAmmount",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterEmpId = "CostCenterEmpId",
            CostCenterIsActive = "CostCenterIsActive",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterZoneInfoId = "CostCenterZoneInfoId",
            CostCenterIsBudgetHead = "CostCenterIsBudgetHead",
            CostCenterBudgetGroupId = "CostCenterBudgetGroupId",
            CostCenterIsFixedAssetHead = "CostCenterIsFixedAssetHead",
            CostCenterIsFixedAssetDevWork = "CostCenterIsFixedAssetDevWork",
            CostCenterIsFixedAssetNonDevWork = "CostCenterIsFixedAssetNonDevWork",
            CostCenterDepreciationRate = "CostCenterDepreciationRate",
            CostCenterBudgetCode = "CostCenterBudgetCode",
            Description = "Description",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

