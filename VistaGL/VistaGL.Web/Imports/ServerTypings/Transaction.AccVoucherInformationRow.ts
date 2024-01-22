namespace VistaGL.Transaction {
    export interface AccVoucherInformationRow {
        Id?: number;
        Amount?: number;
        AmountInWords?: string;
        ClearDate?: string;
        IsClearDate?: number;
        Description?: string;
        FileNo?: string;
        HeadDescription?: string;
        IsApproved?: number;
        IsAuto?: number;
        IsBankReconcile?: number;
        IsCash?: number;
        IsSubmitted?: number;
        MenuName?: string;
        Mid?: number;
        NoteType?: string;
        PageNo?: string;
        PaymentAmount?: number;
        PaymentamountInWords?: string;
        PostToLedger?: number;
        PostToLedgerBoolean?: boolean;
        PostedBy?: string;
        PostedByName?: string;
        PostingDate?: string;
        PostingNumber?: string;
        PreparedBy?: string;
        SubModule?: string;
        TransactionMode?: string;
        TransactionType?: string;
        TransferType?: string;
        VoucherDate?: string;
        VoucherNo?: string;
        VoucherNumber?: string;
        VoucherTag?: number;
        VoucherType?: string;
        Type?: string;
        CostCenterTypeId?: number;
        ParentId?: number;
        CostCentreId?: number;
        VoucherTypeId?: number;
        FileName?: string;
        TransactionTypeEntityId?: number;
        PostingFinancialYearId?: number;
        FundControlInformationId?: number;
        VoucherDetails?: AccVoucherDetailsRow[];
        ZoneId?: number;
        approveStatus?: ApprovalStatus;
        EmpId?: number;
        ProjectID?: number;
        TemplateId?: number;
        postingSendTo?: number;
        AccountBankCash?: string;
        AccountBankCashAmount?: number;
        PowerofAttorney?: string;
        LinkedWithAutoJV?: boolean;
        LinkedVoucherIdForAutoJV?: number;
        LinkedJournalVoucherNo?: string;
        LinkedDebitVoucherNo?: string;
        LinkedWithDebitVoucher?: boolean;
        JVAmount?: number;
        JVAmountInWords?: string;
        NOAId?: number;
        NoaNumber?: string;
        IsBankWisePaymentVoucher?: boolean;
        IsBankWiseReceiptVoucher?: boolean;
        BankAccountInformationId?: number;
        PaytoOrReciveFrom?: string;
        PaytoForBankAdvice?: string;
        ChequeRegisterId?: number;
        IsChequePrepared?: boolean;
        ChequePreparedBy?: string;
        ChequePrepareDate?: string;
        CostCentreCode?: string;
        CostCentreIsInstitute?: number;
        CostCentreName?: string;
        CostCentrePaAmmount?: number;
        CostCentreParentId?: number;
        CostCentreEntityId?: number;
        ChequeRegisterAmount?: number;
        ChequeRegisterAmountInWords?: string;
        ChequeRegisterChequeDate?: string;
        ChequeRegisterChequeIssueDate?: string;
        ChequeRegisterChequeNo?: string;
        ChequeRegisterChequeType?: string;
        ChequeRegisterIsCancelled?: number;
        ChequeRegisterIsPayment?: number;
        ChequeRegisterIsUsed?: number;
        ChequeRegisterPayTo?: string;
        ChequeRegisterPayeeBankName?: string;
        ChequeRegisterRemarks?: string;
        ChequeRegisterVoucherNo?: string;
        ChequeRegisterBankAccountInformationId?: number;
        ChequeRegisterVoucherInformationId?: number;
        ChequeRegisterEntityId?: number;
        ChequeRegisterChequeBookId?: number;
        TransactionTypeEntityTransactionType?: string;
        TransactionTypeEntityFundControlId?: number;
        TransactionTypeEntityVoucherTypeId?: number;
        BankAccountInformationAccountName?: string;
        BankAccountInformationAccountNumber?: string;
        BankAccountInformationCode?: string;
        BankAccountInformationCoaId?: number;
        BankAccountInformationBankId?: number;
        BankAccountInformationBankBranchId?: number;
        BankAccountInformationEntityId?: number;
        PostingFinancialYearIsActive?: number;
        PostingFinancialYearIsClosed?: number;
        PostingFinancialYearPeriodEndDate?: string;
        PostingFinancialYearPeriodStartDate?: string;
        PostingFinancialYearYearName?: string;
        PostingFinancialYearFundControlInformationId?: number;
        FundControlInformationCode?: string;
        FundControlInformationFundControlName?: string;
        FundControlInformationRemarks?: string;
        ZoneZoneName?: string;
        ZoneZoneCode?: string;
        VoucherTypeName?: string;
        ApprovalAction?: string;
        ApprovalComments?: string;
        ApplicationInformationHistory?: ApvApplicationInformationRow[];
        ApproverId?: number;
        TemplateStatus?: number;
        TemplateCOAId?: number;
        TemplateChequeRegisterId?: number;
        RemainAmount?: number;
        TemplateCOAId2?: number;
        AutoJVVoucherNo?: string;
        AutoJVVoucherNumber?: string;
        TransactionTypeEntityIdForAutoJV?: number;
        AutoPV_AccountHead?: number;
        AutoPV_CostCentreId?: number;
        MinAmount?: number;
        MaxAmount?: number;
        PostingSing?: number[];
        PreparedSing?: number[];
        CheckedSing?: number[];
        ApprovedSing?: number[];
        PostedEmployee?: string;
        PreparedEmployee?: string;
        CheckedEmployee?: string;
        ApprovedEmployee?: string;
        RegretSendTo?: number;
        AccountHeadBankCash?: number;
        ChequeBookId?: number;
        ChequeNumhdn?: number;
        ChequeNo?: string;
        IsChequeFinished?: boolean;
        ChequeType?: string;
        ChequeDate?: string;
        ChequeRemarks?: string;
        BankAmount?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccVoucherInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AmountInWords';
        export const localTextPrefix = 'Transaction.AccVoucherInformation';
        export const lookupKey = 'Transaction.AccVoucherInformation';

        export function getLookup(): Q.Lookup<AccVoucherInformationRow> {
            return Q.getLookup<AccVoucherInformationRow>('Transaction.AccVoucherInformation');
        }

        export declare const enum Fields {
            Id = "Id",
            Amount = "Amount",
            AmountInWords = "AmountInWords",
            ClearDate = "ClearDate",
            IsClearDate = "IsClearDate",
            Description = "Description",
            FileNo = "FileNo",
            HeadDescription = "HeadDescription",
            IsApproved = "IsApproved",
            IsAuto = "IsAuto",
            IsBankReconcile = "IsBankReconcile",
            IsCash = "IsCash",
            IsSubmitted = "IsSubmitted",
            MenuName = "MenuName",
            Mid = "Mid",
            NoteType = "NoteType",
            PageNo = "PageNo",
            PaymentAmount = "PaymentAmount",
            PaymentamountInWords = "PaymentamountInWords",
            PostToLedger = "PostToLedger",
            PostToLedgerBoolean = "PostToLedgerBoolean",
            PostedBy = "PostedBy",
            PostedByName = "PostedByName",
            PostingDate = "PostingDate",
            PostingNumber = "PostingNumber",
            PreparedBy = "PreparedBy",
            SubModule = "SubModule",
            TransactionMode = "TransactionMode",
            TransactionType = "TransactionType",
            TransferType = "TransferType",
            VoucherDate = "VoucherDate",
            VoucherNo = "VoucherNo",
            VoucherNumber = "VoucherNumber",
            VoucherTag = "VoucherTag",
            VoucherType = "VoucherType",
            Type = "Type",
            CostCenterTypeId = "CostCenterTypeId",
            ParentId = "ParentId",
            CostCentreId = "CostCentreId",
            VoucherTypeId = "VoucherTypeId",
            FileName = "FileName",
            TransactionTypeEntityId = "TransactionTypeEntityId",
            PostingFinancialYearId = "PostingFinancialYearId",
            FundControlInformationId = "FundControlInformationId",
            VoucherDetails = "VoucherDetails",
            ZoneId = "ZoneId",
            approveStatus = "approveStatus",
            EmpId = "EmpId",
            ProjectID = "ProjectID",
            TemplateId = "TemplateId",
            postingSendTo = "postingSendTo",
            AccountBankCash = "AccountBankCash",
            AccountBankCashAmount = "AccountBankCashAmount",
            PowerofAttorney = "PowerofAttorney",
            LinkedWithAutoJV = "LinkedWithAutoJV",
            LinkedVoucherIdForAutoJV = "LinkedVoucherIdForAutoJV",
            LinkedJournalVoucherNo = "LinkedJournalVoucherNo",
            LinkedDebitVoucherNo = "LinkedDebitVoucherNo",
            LinkedWithDebitVoucher = "LinkedWithDebitVoucher",
            JVAmount = "JVAmount",
            JVAmountInWords = "JVAmountInWords",
            NOAId = "NOAId",
            NoaNumber = "NoaNumber",
            IsBankWisePaymentVoucher = "IsBankWisePaymentVoucher",
            IsBankWiseReceiptVoucher = "IsBankWiseReceiptVoucher",
            BankAccountInformationId = "BankAccountInformationId",
            PaytoOrReciveFrom = "PaytoOrReciveFrom",
            PaytoForBankAdvice = "PaytoForBankAdvice",
            ChequeRegisterId = "ChequeRegisterId",
            IsChequePrepared = "IsChequePrepared",
            ChequePreparedBy = "ChequePreparedBy",
            ChequePrepareDate = "ChequePrepareDate",
            CostCentreCode = "CostCentreCode",
            CostCentreIsInstitute = "CostCentreIsInstitute",
            CostCentreName = "CostCentreName",
            CostCentrePaAmmount = "CostCentrePaAmmount",
            CostCentreParentId = "CostCentreParentId",
            CostCentreEntityId = "CostCentreEntityId",
            ChequeRegisterAmount = "ChequeRegisterAmount",
            ChequeRegisterAmountInWords = "ChequeRegisterAmountInWords",
            ChequeRegisterChequeDate = "ChequeRegisterChequeDate",
            ChequeRegisterChequeIssueDate = "ChequeRegisterChequeIssueDate",
            ChequeRegisterChequeNo = "ChequeRegisterChequeNo",
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
            TransactionTypeEntityTransactionType = "TransactionTypeEntityTransactionType",
            TransactionTypeEntityFundControlId = "TransactionTypeEntityFundControlId",
            TransactionTypeEntityVoucherTypeId = "TransactionTypeEntityVoucherTypeId",
            BankAccountInformationAccountName = "BankAccountInformationAccountName",
            BankAccountInformationAccountNumber = "BankAccountInformationAccountNumber",
            BankAccountInformationCode = "BankAccountInformationCode",
            BankAccountInformationCoaId = "BankAccountInformationCoaId",
            BankAccountInformationBankId = "BankAccountInformationBankId",
            BankAccountInformationBankBranchId = "BankAccountInformationBankBranchId",
            BankAccountInformationEntityId = "BankAccountInformationEntityId",
            PostingFinancialYearIsActive = "PostingFinancialYearIsActive",
            PostingFinancialYearIsClosed = "PostingFinancialYearIsClosed",
            PostingFinancialYearPeriodEndDate = "PostingFinancialYearPeriodEndDate",
            PostingFinancialYearPeriodStartDate = "PostingFinancialYearPeriodStartDate",
            PostingFinancialYearYearName = "PostingFinancialYearYearName",
            PostingFinancialYearFundControlInformationId = "PostingFinancialYearFundControlInformationId",
            FundControlInformationCode = "FundControlInformationCode",
            FundControlInformationFundControlName = "FundControlInformationFundControlName",
            FundControlInformationRemarks = "FundControlInformationRemarks",
            ZoneZoneName = "ZoneZoneName",
            ZoneZoneCode = "ZoneZoneCode",
            VoucherTypeName = "VoucherTypeName",
            ApprovalAction = "ApprovalAction",
            ApprovalComments = "ApprovalComments",
            ApplicationInformationHistory = "ApplicationInformationHistory",
            ApproverId = "ApproverId",
            TemplateStatus = "TemplateStatus",
            TemplateCOAId = "TemplateCOAId",
            TemplateChequeRegisterId = "TemplateChequeRegisterId",
            RemainAmount = "RemainAmount",
            TemplateCOAId2 = "TemplateCOAId2",
            AutoJVVoucherNo = "AutoJVVoucherNo",
            AutoJVVoucherNumber = "AutoJVVoucherNumber",
            TransactionTypeEntityIdForAutoJV = "TransactionTypeEntityIdForAutoJV",
            AutoPV_AccountHead = "AutoPV_AccountHead",
            AutoPV_CostCentreId = "AutoPV_CostCentreId",
            MinAmount = "MinAmount",
            MaxAmount = "MaxAmount",
            PostingSing = "PostingSing",
            PreparedSing = "PreparedSing",
            CheckedSing = "CheckedSing",
            ApprovedSing = "ApprovedSing",
            PostedEmployee = "PostedEmployee",
            PreparedEmployee = "PreparedEmployee",
            CheckedEmployee = "CheckedEmployee",
            ApprovedEmployee = "ApprovedEmployee",
            RegretSendTo = "RegretSendTo",
            AccountHeadBankCash = "AccountHeadBankCash",
            ChequeBookId = "ChequeBookId",
            ChequeNumhdn = "ChequeNumhdn",
            ChequeNo = "ChequeNo",
            IsChequeFinished = "IsChequeFinished",
            ChequeType = "ChequeType",
            ChequeDate = "ChequeDate",
            ChequeRemarks = "ChequeRemarks",
            BankAmount = "BankAmount",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

