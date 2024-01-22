namespace VistaGL.Configurations {
    export interface AccVoucherApiConfigRow {
        Id?: number;
        ConfigName?: string;
        ModuleId?: string;
        FormName?: string;
        VouchrTypeId?: number;
        TransactionId?: number;
        TransactionMode?: string;
        Narration?: string;
        FundControlId?: number;
        ZoneInfoId?: number;
        VoucherApiConfigDetails?: AccVoucherApiConfigDetailsRow[];
        VouchrTypeName?: string;
        VouchrTypeSortOrder?: number;
        TransactionRemarks?: string;
        TransactionSortOrder?: number;
        TransactionTransactionType?: string;
        TransactionFundControlId?: number;
        TransactionVoucherTypeId?: number;
        TransactionTransactionMode?: string;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlBookingDate?: string;
        FundControlCurrencyId?: number;
        FundControlAddress?: string;
        FundControlPhone?: string;
        FundControlMobile?: string;
        FundControlFax?: string;
        FundControlEmail?: string;
        FundControlWebUrl?: string;
        FundControlRemarks?: string;
        FundControlZoneInfoId?: number;
    }

    export namespace AccVoucherApiConfigRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ConfigName';
        export const localTextPrefix = 'Configurations.AccVoucherApiConfig';
        export const lookupKey = 'Configurations.AccVoucherApiConfig';

        export function getLookup(): Q.Lookup<AccVoucherApiConfigRow> {
            return Q.getLookup<AccVoucherApiConfigRow>('Configurations.AccVoucherApiConfig');
        }

        export declare const enum Fields {
            Id = "Id",
            ConfigName = "ConfigName",
            ModuleId = "ModuleId",
            FormName = "FormName",
            VouchrTypeId = "VouchrTypeId",
            TransactionId = "TransactionId",
            TransactionMode = "TransactionMode",
            Narration = "Narration",
            FundControlId = "FundControlId",
            ZoneInfoId = "ZoneInfoId",
            VoucherApiConfigDetails = "VoucherApiConfigDetails",
            VouchrTypeName = "VouchrTypeName",
            VouchrTypeSortOrder = "VouchrTypeSortOrder",
            TransactionRemarks = "TransactionRemarks",
            TransactionSortOrder = "TransactionSortOrder",
            TransactionTransactionType = "TransactionTransactionType",
            TransactionFundControlId = "TransactionFundControlId",
            TransactionVoucherTypeId = "TransactionVoucherTypeId",
            TransactionTransactionMode = "TransactionTransactionMode",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlBookingDate = "FundControlBookingDate",
            FundControlCurrencyId = "FundControlCurrencyId",
            FundControlAddress = "FundControlAddress",
            FundControlPhone = "FundControlPhone",
            FundControlMobile = "FundControlMobile",
            FundControlFax = "FundControlFax",
            FundControlEmail = "FundControlEmail",
            FundControlWebUrl = "FundControlWebUrl",
            FundControlRemarks = "FundControlRemarks",
            FundControlZoneInfoId = "FundControlZoneInfoId"
        }
    }
}

