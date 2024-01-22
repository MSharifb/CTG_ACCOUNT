namespace VistaGL.Transaction {
    export interface AccVoucherDetailsRow {
        Id?: number;
        CreditAmount?: number;
        DebitAmount?: number;
        Description?: string;
        IsPayorReceiveHead?: number;
        PaymentVoucherHead?: boolean;
        Mid?: number;
        ChartofAccountsId?: number;
        VoucherInformationId?: number;
        VoucherDtlAllocation?: AccVoucherDtlAllocationRow[];
        VoucherDtlBillRef?: AccVoucherDtlBillRefRow[];
        ConversionRate?: number;
        ConversionAmount?: number;
        EffectiveValue?: number;
        CCreditAmount?: number;
        CDebitAmount?: number;
        BankAccountInformationId?: number;
        ChequeRegisterId?: number;
        ClearDate?: string;
        IsClearDate?: number;
        CalculationAmount?: number;
        CalculationRate?: number;
        IsAccountHeadBankCash?: boolean;
        LinkedJVDetailId?: number;
        AdjustedChequeRegisterId?: number;
        ChartofAccountsUserCode?: string;
        ChartofAccountsAccountName?: string;
        ChartofAccountsCoaMapping?: string;
        ChartofAccountsFundControlId?: number;
        VoucherInformationAmount?: number;
        VoucherInformationAmountInWords?: string;
        VoucherInformationClearDate?: string;
        VoucherInformationDescription?: string;
        VoucherInformationHeadDescription?: string;
        VoucherInformationIsApproved?: number;
        VoucherInformationIsAuto?: number;
        VoucherInformationIsBankReconcile?: number;
        VoucherInformationIsSubmitted?: number;
        VoucherInformationPaymentAmount?: number;
        VoucherInformationPaytoOrReciveFrom?: string;
        VoucherInformationPostToLedger?: number;
        VoucherInformationPostedBy?: string;
        VoucherInformationPostingDate?: string;
        VoucherInformationPostingNumber?: string;
        VoucherInformationPreparedBy?: string;
        VoucherInformationTransactionMode?: string;
        VoucherInformationTransactionType?: string;
        VoucherInformationVoucherDate?: string;
        VoucherInformationVoucherNo?: string;
        VoucherInformationVoucherNumber?: string;
        VoucherInformationVoucherType?: string;
        VoucherInformationVoucherTypeId?: number;
        VoucherInformationCostCentreId?: number;
        VoucherInformationChequeRegisterId?: number;
        VoucherInformationChequeRegisterNo?: string;
        VoucherInformationTransactionTypeEntityId?: number;
        VoucherInformationBankAccountInformationId?: number;
        VoucherInformationFundControlInformationId?: number;
        VoucherInformationZoneID?: number;
        VoucherTypeName?: string;
        PaytoOrReciveFrom?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccVoucherDetailsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Description';
        export const localTextPrefix = 'Transaction.AccVoucherDetails';
        export const lookupKey = 'Transaction.AccVoucherDetails';

        export function getLookup(): Q.Lookup<AccVoucherDetailsRow> {
            return Q.getLookup<AccVoucherDetailsRow>('Transaction.AccVoucherDetails');
        }

        export declare const enum Fields {
            Id = "Id",
            CreditAmount = "CreditAmount",
            DebitAmount = "DebitAmount",
            Description = "Description",
            IsPayorReceiveHead = "IsPayorReceiveHead",
            PaymentVoucherHead = "PaymentVoucherHead",
            Mid = "Mid",
            ChartofAccountsId = "ChartofAccountsId",
            VoucherInformationId = "VoucherInformationId",
            VoucherDtlAllocation = "VoucherDtlAllocation",
            VoucherDtlBillRef = "VoucherDtlBillRef",
            ConversionRate = "ConversionRate",
            ConversionAmount = "ConversionAmount",
            EffectiveValue = "EffectiveValue",
            CCreditAmount = "CCreditAmount",
            CDebitAmount = "CDebitAmount",
            BankAccountInformationId = "BankAccountInformationId",
            ChequeRegisterId = "ChequeRegisterId",
            ClearDate = "ClearDate",
            IsClearDate = "IsClearDate",
            CalculationAmount = "CalculationAmount",
            CalculationRate = "CalculationRate",
            IsAccountHeadBankCash = "IsAccountHeadBankCash",
            LinkedJVDetailId = "LinkedJVDetailId",
            AdjustedChequeRegisterId = "AdjustedChequeRegisterId",
            ChartofAccountsUserCode = "ChartofAccountsUserCode",
            ChartofAccountsAccountName = "ChartofAccountsAccountName",
            ChartofAccountsCoaMapping = "ChartofAccountsCoaMapping",
            ChartofAccountsFundControlId = "ChartofAccountsFundControlId",
            VoucherInformationAmount = "VoucherInformationAmount",
            VoucherInformationAmountInWords = "VoucherInformationAmountInWords",
            VoucherInformationClearDate = "VoucherInformationClearDate",
            VoucherInformationDescription = "VoucherInformationDescription",
            VoucherInformationHeadDescription = "VoucherInformationHeadDescription",
            VoucherInformationIsApproved = "VoucherInformationIsApproved",
            VoucherInformationIsAuto = "VoucherInformationIsAuto",
            VoucherInformationIsBankReconcile = "VoucherInformationIsBankReconcile",
            VoucherInformationIsSubmitted = "VoucherInformationIsSubmitted",
            VoucherInformationPaymentAmount = "VoucherInformationPaymentAmount",
            VoucherInformationPaytoOrReciveFrom = "VoucherInformationPaytoOrReciveFrom",
            VoucherInformationPostToLedger = "VoucherInformationPostToLedger",
            VoucherInformationPostedBy = "VoucherInformationPostedBy",
            VoucherInformationPostingDate = "VoucherInformationPostingDate",
            VoucherInformationPostingNumber = "VoucherInformationPostingNumber",
            VoucherInformationPreparedBy = "VoucherInformationPreparedBy",
            VoucherInformationTransactionMode = "VoucherInformationTransactionMode",
            VoucherInformationTransactionType = "VoucherInformationTransactionType",
            VoucherInformationVoucherDate = "VoucherInformationVoucherDate",
            VoucherInformationVoucherNo = "VoucherInformationVoucherNo",
            VoucherInformationVoucherNumber = "VoucherInformationVoucherNumber",
            VoucherInformationVoucherType = "VoucherInformationVoucherType",
            VoucherInformationVoucherTypeId = "VoucherInformationVoucherTypeId",
            VoucherInformationCostCentreId = "VoucherInformationCostCentreId",
            VoucherInformationChequeRegisterId = "VoucherInformationChequeRegisterId",
            VoucherInformationChequeRegisterNo = "VoucherInformationChequeRegisterNo",
            VoucherInformationTransactionTypeEntityId = "VoucherInformationTransactionTypeEntityId",
            VoucherInformationBankAccountInformationId = "VoucherInformationBankAccountInformationId",
            VoucherInformationFundControlInformationId = "VoucherInformationFundControlInformationId",
            VoucherInformationZoneID = "VoucherInformationZoneID",
            VoucherTypeName = "VoucherTypeName",
            PaytoOrReciveFrom = "PaytoOrReciveFrom",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

