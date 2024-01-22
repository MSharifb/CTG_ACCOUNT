namespace VistaGL.Transaction {
    export interface AccPartyPaymentRow {
        Id?: number;
        PartyId?: number;
        TransactionMode?: string;
        CoAId?: number;
        ChequeRegisterId?: number;
        Amount?: number;
        Status?: number;
        ZoneId?: number;
        RemainAmount?: number;
        Narration?: string;
        CoAId2?: number;
        PartyCode?: string;
        PartyCodeCount?: number;
        PartyUserCode?: string;
        PartyIsInstitute?: boolean;
        PartyName?: string;
        PartyPaAmmount?: number;
        PartyRemarks?: string;
        PartyParentId?: number;
        PartyEntityId?: number;
        PartyCostCenterTypeId?: number;
        CoAAccountCode?: string;
        CoAAccountCodeCount?: number;
        CoAAccountGroup?: string;
        CoAAccountName?: string;
        CoAAccountNameBangla?: string;
        CoACoaMapping?: string;
        CoAIsBillRef?: number;
        CoAIsBudgetHead?: number;
        CoAIsControlhead?: number;
        CoAIsCostCenterAllocate?: number;
        CoALevel?: number;
        CoAMailingAddress?: string;
        CoAMailingName?: string;
        CoAOpeningBalance?: number;
        CoARemarks?: string;
        CoATaxId?: string;
        CoAUgcCode?: string;
        CoAFundControlId?: number;
        CoAParentAccountId?: number;
        CoAMultiCurrencyId?: number;
        CoAEffectCashFlow?: number;
        CoAUserCode?: string;
        ChequeRegisterAmount?: number;
        ChequeRegisterAmountInWords?: string;
        ChequeRegisterChequeDate?: string;
        ChequeRegisterChequeIssueDate?: string;
        ChequeRegisterChequeNo?: string;
        ChequeRegisterChequeNumhdn?: number;
        ChequeRegisterChequeType?: string;
        ChequeRegisterIsCancelled?: boolean;
        ChequeRegisterIsPayment?: boolean;
        ChequeRegisterIsUsed?: boolean;
        ChequeRegisterPayTo?: string;
        ChequeRegisterPayeeBankName?: string;
        ChequeRegisterRemarks?: string;
        ChequeRegisterVoucherNo?: string;
        ChequeRegisterBankAccountInformationId?: number;
        ChequeRegisterVoucherInformationId?: number;
        ChequeRegisterEntityId?: number;
        ChequeRegisterChequeBookId?: number;
        ChequeRegisterIsBankAdvice?: boolean;
        ChequeRegisterZoneInfoId?: number;
        CoA2AccountCode?: string;
        CoA2AccountName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccPartyPaymentRow {
        export const idProperty = 'Id';
        export const nameProperty = 'TransactionMode';
        export const localTextPrefix = 'Transaction.AccPartyPayment';
        export const lookupKey = 'Transaction.AccPartyPayment';

        export function getLookup(): Q.Lookup<AccPartyPaymentRow> {
            return Q.getLookup<AccPartyPaymentRow>('Transaction.AccPartyPayment');
        }

        export declare const enum Fields {
            Id = "Id",
            PartyId = "PartyId",
            TransactionMode = "TransactionMode",
            CoAId = "CoAId",
            ChequeRegisterId = "ChequeRegisterId",
            Amount = "Amount",
            Status = "Status",
            ZoneId = "ZoneId",
            RemainAmount = "RemainAmount",
            Narration = "Narration",
            CoAId2 = "CoAId2",
            PartyCode = "PartyCode",
            PartyCodeCount = "PartyCodeCount",
            PartyUserCode = "PartyUserCode",
            PartyIsInstitute = "PartyIsInstitute",
            PartyName = "PartyName",
            PartyPaAmmount = "PartyPaAmmount",
            PartyRemarks = "PartyRemarks",
            PartyParentId = "PartyParentId",
            PartyEntityId = "PartyEntityId",
            PartyCostCenterTypeId = "PartyCostCenterTypeId",
            CoAAccountCode = "CoAAccountCode",
            CoAAccountCodeCount = "CoAAccountCodeCount",
            CoAAccountGroup = "CoAAccountGroup",
            CoAAccountName = "CoAAccountName",
            CoAAccountNameBangla = "CoAAccountNameBangla",
            CoACoaMapping = "CoACoaMapping",
            CoAIsBillRef = "CoAIsBillRef",
            CoAIsBudgetHead = "CoAIsBudgetHead",
            CoAIsControlhead = "CoAIsControlhead",
            CoAIsCostCenterAllocate = "CoAIsCostCenterAllocate",
            CoALevel = "CoALevel",
            CoAMailingAddress = "CoAMailingAddress",
            CoAMailingName = "CoAMailingName",
            CoAOpeningBalance = "CoAOpeningBalance",
            CoARemarks = "CoARemarks",
            CoATaxId = "CoATaxId",
            CoAUgcCode = "CoAUgcCode",
            CoAFundControlId = "CoAFundControlId",
            CoAParentAccountId = "CoAParentAccountId",
            CoAMultiCurrencyId = "CoAMultiCurrencyId",
            CoAEffectCashFlow = "CoAEffectCashFlow",
            CoAUserCode = "CoAUserCode",
            ChequeRegisterAmount = "ChequeRegisterAmount",
            ChequeRegisterAmountInWords = "ChequeRegisterAmountInWords",
            ChequeRegisterChequeDate = "ChequeRegisterChequeDate",
            ChequeRegisterChequeIssueDate = "ChequeRegisterChequeIssueDate",
            ChequeRegisterChequeNo = "ChequeRegisterChequeNo",
            ChequeRegisterChequeNumhdn = "ChequeRegisterChequeNumhdn",
            ChequeRegisterChequeType = "ChequeRegisterChequeType",
            ChequeRegisterIsCancelled = "ChequeRegisterIsCancelled",
            ChequeRegisterIsPayment = "ChequeRegisterIsPayment",
            ChequeRegisterIsUsed = "ChequeRegisterIsUsed",
            ChequeRegisterPayTo = "ChequeRegisterPayTo",
            ChequeRegisterPayeeBankName = "ChequeRegisterPayeeBankName",
            ChequeRegisterRemarks = "ChequeRegisterRemarks",
            ChequeRegisterVoucherNo = "ChequeRegisterVoucherNo",
            ChequeRegisterBankAccountInformationId = "ChequeRegisterBankAccountInformationId",
            ChequeRegisterVoucherInformationId = "ChequeRegisterVoucherInformationId",
            ChequeRegisterEntityId = "ChequeRegisterEntityId",
            ChequeRegisterChequeBookId = "ChequeRegisterChequeBookId",
            ChequeRegisterIsBankAdvice = "ChequeRegisterIsBankAdvice",
            ChequeRegisterZoneInfoId = "ChequeRegisterZoneInfoId",
            CoA2AccountCode = "CoA2AccountCode",
            CoA2AccountName = "CoA2AccountName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

