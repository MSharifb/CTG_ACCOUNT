namespace VistaGL.Configurations {
    export interface AccReportTypeCoaMappingRow {
        Id?: number;
        GroupId?: number;
        CoaId?: number;
        GroupParentId?: number;
        ReportTypeId?: number;
        GroupGroupName?: string;
        GroupSortingOrder?: number;
        GroupShowAutoSum?: boolean;
        GroupNoteNo?: number;
        GroupAddBlankSpaceBefore?: boolean;
        GroupAddBlankSpaceAfter?: boolean;
        GroupShowBottomBorder?: boolean;
        GroupShowUpperBorder?: boolean;
        GroupShowLeftBorder?: boolean;
        GroupShowRightBorder?: boolean;
        GroupFundControlId?: number;
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
        OpeningBalance?: number;
    }

    export namespace AccReportTypeCoaMappingRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccReportTypeCoaMapping';
        export const lookupKey = 'Configurations.AccReportTypeCoaMapping';

        export function getLookup(): Q.Lookup<AccReportTypeCoaMappingRow> {
            return Q.getLookup<AccReportTypeCoaMappingRow>('Configurations.AccReportTypeCoaMapping');
        }

        export declare const enum Fields {
            Id = "Id",
            GroupId = "GroupId",
            CoaId = "CoaId",
            GroupParentId = "GroupParentId",
            ReportTypeId = "ReportTypeId",
            GroupGroupName = "GroupGroupName",
            GroupSortingOrder = "GroupSortingOrder",
            GroupShowAutoSum = "GroupShowAutoSum",
            GroupNoteNo = "GroupNoteNo",
            GroupAddBlankSpaceBefore = "GroupAddBlankSpaceBefore",
            GroupAddBlankSpaceAfter = "GroupAddBlankSpaceAfter",
            GroupShowBottomBorder = "GroupShowBottomBorder",
            GroupShowUpperBorder = "GroupShowUpperBorder",
            GroupShowLeftBorder = "GroupShowLeftBorder",
            GroupShowRightBorder = "GroupShowRightBorder",
            GroupFundControlId = "GroupFundControlId",
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
            OpeningBalance = "OpeningBalance"
        }
    }
}

