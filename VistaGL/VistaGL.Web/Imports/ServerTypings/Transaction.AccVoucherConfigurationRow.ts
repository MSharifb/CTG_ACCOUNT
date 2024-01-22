namespace VistaGL.Transaction {
    export interface AccVoucherConfigurationRow {
        Id?: number;
        AutoNumbering?: boolean;
        CommonDescription?: boolean;
        EachAccounting?: boolean;
        IsActive?: boolean;
        IsUserFinancialAtTheEnd?: boolean;
        MaxMonthSerialNumber?: string;
        MaxSerialNumber?: number;
        NewNumber?: boolean;
        NumberLength?: number;
        PostingNumber?: number;
        Prefix?: string;
        PreparedByInfo?: boolean;
        Separators?: string;
        StartingNumber?: number;
        Suffix?: string;
        TransactionTypeId?: number;
        VoucherTypeId?: number;
        FundControlInformationId?: number;
        AccountingPeriodId?: number;
        Date?: string;
        ZoneInfoId?: number;
        IsAutoPost?: boolean;
        IsUserFinancialAtStart?: boolean;
        IsMonth?: boolean;
        IsDate?: boolean;
        NewNumberforEveryBankAccount?: boolean;
        AddZoneShortCode?: boolean;
        AddBankACShortCode?: boolean;
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
        TransactionTypeVoucherTypeId?: number;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        FundControlInformationCode?: string;
        FundControlInformationFundControlName?: string;
        FundControlInformationRemarks?: string;
        AccountingPeriodIsActive?: number;
        AccountingPeriodIsClosed?: number;
        AccountingPeriodPeriodEndDate?: string;
        AccountingPeriodPeriodStartDate?: string;
        AccountingPeriodYearName?: string;
        AccountingPeriodFundControlInformationId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccVoucherConfigurationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'AccountingPeriodYearName';
        export const localTextPrefix = 'Transaction.AccVoucherConfiguration';
        export const lookupKey = 'Transaction.AccVoucherConfiguration';

        export function getLookup(): Q.Lookup<AccVoucherConfigurationRow> {
            return Q.getLookup<AccVoucherConfigurationRow>('Transaction.AccVoucherConfiguration');
        }

        export declare const enum Fields {
            Id = "Id",
            AutoNumbering = "AutoNumbering",
            CommonDescription = "CommonDescription",
            EachAccounting = "EachAccounting",
            IsActive = "IsActive",
            IsUserFinancialAtTheEnd = "IsUserFinancialAtTheEnd",
            MaxMonthSerialNumber = "MaxMonthSerialNumber",
            MaxSerialNumber = "MaxSerialNumber",
            NewNumber = "NewNumber",
            NumberLength = "NumberLength",
            PostingNumber = "PostingNumber",
            Prefix = "Prefix",
            PreparedByInfo = "PreparedByInfo",
            Separators = "Separators",
            StartingNumber = "StartingNumber",
            Suffix = "Suffix",
            TransactionTypeId = "TransactionTypeId",
            VoucherTypeId = "VoucherTypeId",
            FundControlInformationId = "FundControlInformationId",
            AccountingPeriodId = "AccountingPeriodId",
            Date = "Date",
            ZoneInfoId = "ZoneInfoId",
            IsAutoPost = "IsAutoPost",
            IsUserFinancialAtStart = "IsUserFinancialAtStart",
            IsMonth = "IsMonth",
            IsDate = "IsDate",
            NewNumberforEveryBankAccount = "NewNumberforEveryBankAccount",
            AddZoneShortCode = "AddZoneShortCode",
            AddBankACShortCode = "AddBankACShortCode",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId",
            TransactionTypeVoucherTypeId = "TransactionTypeVoucherTypeId",
            VoucherTypeName = "VoucherTypeName",
            VoucherTypeSortOrder = "VoucherTypeSortOrder",
            FundControlInformationCode = "FundControlInformationCode",
            FundControlInformationFundControlName = "FundControlInformationFundControlName",
            FundControlInformationRemarks = "FundControlInformationRemarks",
            AccountingPeriodIsActive = "AccountingPeriodIsActive",
            AccountingPeriodIsClosed = "AccountingPeriodIsClosed",
            AccountingPeriodPeriodEndDate = "AccountingPeriodPeriodEndDate",
            AccountingPeriodPeriodStartDate = "AccountingPeriodPeriodStartDate",
            AccountingPeriodYearName = "AccountingPeriodYearName",
            AccountingPeriodFundControlInformationId = "AccountingPeriodFundControlInformationId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

