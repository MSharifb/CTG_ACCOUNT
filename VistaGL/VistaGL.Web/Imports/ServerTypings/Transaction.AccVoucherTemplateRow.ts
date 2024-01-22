namespace VistaGL.Transaction {
    export interface AccVoucherTemplateRow {
        Id?: number;
        VoucherTypeId?: number;
        TransactionTypeId?: number;
        TransactionMode?: string;
        TemplateName?: string;
        CoaDebitHeadId?: number;
        IsDebitHeadCheque?: boolean;
        CoaCreditHeadId?: number;
        IsCreditHeadCheque?: boolean;
        IsBillReference?: boolean;
        IsCostCenter?: boolean;
        IsSd?: boolean;
        CoaSdId?: number;
        SdType?: string;
        SdRate?: number;
        IsVat?: boolean;
        CoaVatId?: number;
        VatType?: string;
        VatRate?: number;
        IsTax?: boolean;
        CoaTaxId?: number;
        TaxType?: string;
        TaxRate?: number;
        Remarks?: string;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
        TransactionTypeVoucherTypeId?: number;
        CoaDebitHeadAccountCode?: string;
        CoaDebitHeadAccountCodeCount?: number;
        CoaDebitHeadAccountGroup?: string;
        CoaDebitHeadAccountName?: string;
        CoaDebitHeadAccountNameBangla?: string;
        CoaDebitHeadCoaMapping?: string;
        CoaDebitHeadIsBillRef?: number;
        CoaDebitHeadIsBudgetHead?: number;
        CoaDebitHeadIsControlhead?: number;
        CoaDebitHeadIsCostCenterAllocate?: number;
        CoaDebitHeadLevel?: number;
        CoaDebitHeadMailingAddress?: string;
        CoaDebitHeadMailingName?: string;
        CoaDebitHeadOpeningBalance?: number;
        CoaDebitHeadRemarks?: string;
        CoaDebitHeadTaxId?: string;
        CoaDebitHeadUgcCode?: string;
        CoaDebitHeadFundControlId?: number;
        CoaDebitHeadParentAccountId?: number;
        CoaCreditHeadAccountCode?: string;
        CoaCreditHeadAccountCodeCount?: number;
        CoaCreditHeadAccountGroup?: string;
        CoaCreditHeadAccountName?: string;
        CoaCreditHeadAccountNameBangla?: string;
        CoaCreditHeadCoaMapping?: string;
        CoaCreditHeadIsBillRef?: number;
        CoaCreditHeadIsBudgetHead?: number;
        CoaCreditHeadIsControlhead?: number;
        CoaCreditHeadIsCostCenterAllocate?: number;
        CoaCreditHeadLevel?: number;
        CoaCreditHeadMailingAddress?: string;
        CoaCreditHeadMailingName?: string;
        CoaCreditHeadOpeningBalance?: number;
        CoaCreditHeadRemarks?: string;
        CoaCreditHeadTaxId?: string;
        CoaCreditHeadUgcCode?: string;
        CoaCreditHeadFundControlId?: number;
        CoaCreditHeadParentAccountId?: number;
        CoaSdAccountCode?: string;
        CoaSdAccountCodeCount?: number;
        CoaSdAccountGroup?: string;
        CoaSdAccountName?: string;
        CoaSdAccountNameBangla?: string;
        CoaSdCoaMapping?: string;
        CoaSdIsBillRef?: number;
        CoaSdIsBudgetHead?: number;
        CoaSdIsControlhead?: number;
        CoaSdIsCostCenterAllocate?: number;
        CoaSdLevel?: number;
        CoaSdMailingAddress?: string;
        CoaSdMailingName?: string;
        CoaSdOpeningBalance?: number;
        CoaSdRemarks?: string;
        CoaSdTaxId?: string;
        CoaSdUgcCode?: string;
        CoaSdFundControlId?: number;
        CoaSdParentAccountId?: number;
        CoaVatAccountCode?: string;
        CoaVatAccountCodeCount?: number;
        CoaVatAccountGroup?: string;
        CoaVatAccountName?: string;
        CoaVatAccountNameBangla?: string;
        CoaVatCoaMapping?: string;
        CoaVatIsBillRef?: number;
        CoaVatIsBudgetHead?: number;
        CoaVatIsControlhead?: number;
        CoaVatIsCostCenterAllocate?: number;
        CoaVatLevel?: number;
        CoaVatMailingAddress?: string;
        CoaVatMailingName?: string;
        CoaVatOpeningBalance?: number;
        CoaVatRemarks?: string;
        CoaVatTaxId?: string;
        CoaVatUgcCode?: string;
        CoaVatFundControlId?: number;
        CoaVatParentAccountId?: number;
        CoaTaxAccountCode?: string;
        CoaTaxAccountCodeCount?: number;
        CoaTaxAccountGroup?: string;
        CoaTaxAccountName?: string;
        CoaTaxAccountNameBangla?: string;
        CoaTaxCoaMapping?: string;
        CoaTaxIsBillRef?: number;
        CoaTaxIsBudgetHead?: number;
        CoaTaxIsControlhead?: number;
        CoaTaxIsCostCenterAllocate?: number;
        CoaTaxLevel?: number;
        CoaTaxMailingAddress?: string;
        CoaTaxMailingName?: string;
        CoaTaxOpeningBalance?: number;
        CoaTaxRemarks?: string;
        CoaTaxTaxId?: string;
        CoaTaxUgcCode?: string;
        CoaTaxFundControlId?: number;
        CoaTaxParentAccountId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccVoucherTemplateRow {
        export const idProperty = 'Id';
        export const nameProperty = 'TemplateName';
        export const localTextPrefix = 'Transaction.AccVoucherTemplate';
        export const lookupKey = 'Transaction.AccVoucherTemplateRow';

        export function getLookup(): Q.Lookup<AccVoucherTemplateRow> {
            return Q.getLookup<AccVoucherTemplateRow>('Transaction.AccVoucherTemplateRow');
        }

        export declare const enum Fields {
            Id = "Id",
            VoucherTypeId = "VoucherTypeId",
            TransactionTypeId = "TransactionTypeId",
            TransactionMode = "TransactionMode",
            TemplateName = "TemplateName",
            CoaDebitHeadId = "CoaDebitHeadId",
            IsDebitHeadCheque = "IsDebitHeadCheque",
            CoaCreditHeadId = "CoaCreditHeadId",
            IsCreditHeadCheque = "IsCreditHeadCheque",
            IsBillReference = "IsBillReference",
            IsCostCenter = "IsCostCenter",
            IsSd = "IsSd",
            CoaSdId = "CoaSdId",
            SdType = "SdType",
            SdRate = "SdRate",
            IsVat = "IsVat",
            CoaVatId = "CoaVatId",
            VatType = "VatType",
            VatRate = "VatRate",
            IsTax = "IsTax",
            CoaTaxId = "CoaTaxId",
            TaxType = "TaxType",
            TaxRate = "TaxRate",
            Remarks = "Remarks",
            VoucherTypeName = "VoucherTypeName",
            VoucherTypeSortOrder = "VoucherTypeSortOrder",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId",
            TransactionTypeVoucherTypeId = "TransactionTypeVoucherTypeId",
            CoaDebitHeadAccountCode = "CoaDebitHeadAccountCode",
            CoaDebitHeadAccountCodeCount = "CoaDebitHeadAccountCodeCount",
            CoaDebitHeadAccountGroup = "CoaDebitHeadAccountGroup",
            CoaDebitHeadAccountName = "CoaDebitHeadAccountName",
            CoaDebitHeadAccountNameBangla = "CoaDebitHeadAccountNameBangla",
            CoaDebitHeadCoaMapping = "CoaDebitHeadCoaMapping",
            CoaDebitHeadIsBillRef = "CoaDebitHeadIsBillRef",
            CoaDebitHeadIsBudgetHead = "CoaDebitHeadIsBudgetHead",
            CoaDebitHeadIsControlhead = "CoaDebitHeadIsControlhead",
            CoaDebitHeadIsCostCenterAllocate = "CoaDebitHeadIsCostCenterAllocate",
            CoaDebitHeadLevel = "CoaDebitHeadLevel",
            CoaDebitHeadMailingAddress = "CoaDebitHeadMailingAddress",
            CoaDebitHeadMailingName = "CoaDebitHeadMailingName",
            CoaDebitHeadOpeningBalance = "CoaDebitHeadOpeningBalance",
            CoaDebitHeadRemarks = "CoaDebitHeadRemarks",
            CoaDebitHeadTaxId = "CoaDebitHeadTaxId",
            CoaDebitHeadUgcCode = "CoaDebitHeadUgcCode",
            CoaDebitHeadFundControlId = "CoaDebitHeadFundControlId",
            CoaDebitHeadParentAccountId = "CoaDebitHeadParentAccountId",
            CoaCreditHeadAccountCode = "CoaCreditHeadAccountCode",
            CoaCreditHeadAccountCodeCount = "CoaCreditHeadAccountCodeCount",
            CoaCreditHeadAccountGroup = "CoaCreditHeadAccountGroup",
            CoaCreditHeadAccountName = "CoaCreditHeadAccountName",
            CoaCreditHeadAccountNameBangla = "CoaCreditHeadAccountNameBangla",
            CoaCreditHeadCoaMapping = "CoaCreditHeadCoaMapping",
            CoaCreditHeadIsBillRef = "CoaCreditHeadIsBillRef",
            CoaCreditHeadIsBudgetHead = "CoaCreditHeadIsBudgetHead",
            CoaCreditHeadIsControlhead = "CoaCreditHeadIsControlhead",
            CoaCreditHeadIsCostCenterAllocate = "CoaCreditHeadIsCostCenterAllocate",
            CoaCreditHeadLevel = "CoaCreditHeadLevel",
            CoaCreditHeadMailingAddress = "CoaCreditHeadMailingAddress",
            CoaCreditHeadMailingName = "CoaCreditHeadMailingName",
            CoaCreditHeadOpeningBalance = "CoaCreditHeadOpeningBalance",
            CoaCreditHeadRemarks = "CoaCreditHeadRemarks",
            CoaCreditHeadTaxId = "CoaCreditHeadTaxId",
            CoaCreditHeadUgcCode = "CoaCreditHeadUgcCode",
            CoaCreditHeadFundControlId = "CoaCreditHeadFundControlId",
            CoaCreditHeadParentAccountId = "CoaCreditHeadParentAccountId",
            CoaSdAccountCode = "CoaSdAccountCode",
            CoaSdAccountCodeCount = "CoaSdAccountCodeCount",
            CoaSdAccountGroup = "CoaSdAccountGroup",
            CoaSdAccountName = "CoaSdAccountName",
            CoaSdAccountNameBangla = "CoaSdAccountNameBangla",
            CoaSdCoaMapping = "CoaSdCoaMapping",
            CoaSdIsBillRef = "CoaSdIsBillRef",
            CoaSdIsBudgetHead = "CoaSdIsBudgetHead",
            CoaSdIsControlhead = "CoaSdIsControlhead",
            CoaSdIsCostCenterAllocate = "CoaSdIsCostCenterAllocate",
            CoaSdLevel = "CoaSdLevel",
            CoaSdMailingAddress = "CoaSdMailingAddress",
            CoaSdMailingName = "CoaSdMailingName",
            CoaSdOpeningBalance = "CoaSdOpeningBalance",
            CoaSdRemarks = "CoaSdRemarks",
            CoaSdTaxId = "CoaSdTaxId",
            CoaSdUgcCode = "CoaSdUgcCode",
            CoaSdFundControlId = "CoaSdFundControlId",
            CoaSdParentAccountId = "CoaSdParentAccountId",
            CoaVatAccountCode = "CoaVatAccountCode",
            CoaVatAccountCodeCount = "CoaVatAccountCodeCount",
            CoaVatAccountGroup = "CoaVatAccountGroup",
            CoaVatAccountName = "CoaVatAccountName",
            CoaVatAccountNameBangla = "CoaVatAccountNameBangla",
            CoaVatCoaMapping = "CoaVatCoaMapping",
            CoaVatIsBillRef = "CoaVatIsBillRef",
            CoaVatIsBudgetHead = "CoaVatIsBudgetHead",
            CoaVatIsControlhead = "CoaVatIsControlhead",
            CoaVatIsCostCenterAllocate = "CoaVatIsCostCenterAllocate",
            CoaVatLevel = "CoaVatLevel",
            CoaVatMailingAddress = "CoaVatMailingAddress",
            CoaVatMailingName = "CoaVatMailingName",
            CoaVatOpeningBalance = "CoaVatOpeningBalance",
            CoaVatRemarks = "CoaVatRemarks",
            CoaVatTaxId = "CoaVatTaxId",
            CoaVatUgcCode = "CoaVatUgcCode",
            CoaVatFundControlId = "CoaVatFundControlId",
            CoaVatParentAccountId = "CoaVatParentAccountId",
            CoaTaxAccountCode = "CoaTaxAccountCode",
            CoaTaxAccountCodeCount = "CoaTaxAccountCodeCount",
            CoaTaxAccountGroup = "CoaTaxAccountGroup",
            CoaTaxAccountName = "CoaTaxAccountName",
            CoaTaxAccountNameBangla = "CoaTaxAccountNameBangla",
            CoaTaxCoaMapping = "CoaTaxCoaMapping",
            CoaTaxIsBillRef = "CoaTaxIsBillRef",
            CoaTaxIsBudgetHead = "CoaTaxIsBudgetHead",
            CoaTaxIsControlhead = "CoaTaxIsControlhead",
            CoaTaxIsCostCenterAllocate = "CoaTaxIsCostCenterAllocate",
            CoaTaxLevel = "CoaTaxLevel",
            CoaTaxMailingAddress = "CoaTaxMailingAddress",
            CoaTaxMailingName = "CoaTaxMailingName",
            CoaTaxOpeningBalance = "CoaTaxOpeningBalance",
            CoaTaxRemarks = "CoaTaxRemarks",
            CoaTaxTaxId = "CoaTaxTaxId",
            CoaTaxUgcCode = "CoaTaxUgcCode",
            CoaTaxFundControlId = "CoaTaxFundControlId",
            CoaTaxParentAccountId = "CoaTaxParentAccountId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

