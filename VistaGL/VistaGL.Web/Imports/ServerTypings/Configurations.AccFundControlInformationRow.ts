namespace VistaGL.Configurations {
    export interface AccFundControlInformationRow {
        Id?: number;
        Code?: string;
        FundControlName?: string;
        BookingDate?: string;
        Address?: string;
        Phone?: string;
        Mobile?: string;
        Fax?: string;
        Email?: string;
        WebUrl?: string;
        Remarks?: string;
        ZoneInfoId?: number;
        CurrencyId?: number;
        ZoneInfoZoneName?: string;
        ZoneInfoZoneNameInBengali?: string;
        ZoneInfoZoneCode?: string;
        ZoneInfoSortOrder?: number;
        ZoneInfoOrganogramCategoryTypeId?: number;
        ZoneInfoZoneAddress?: string;
        ZoneInfoZoneAddressInBengali?: string;
        ZoneInfoPrefix?: string;
        ZoneInfoIsHeadOffice?: boolean;
        CurrencySymbol?: string;
        CurrencyCurrency?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccFundControlInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'FundControlName';
        export const localTextPrefix = 'Configurations.AccFundControlInformation';
        export const lookupKey = 'Configurations.AccFundControlInformation';

        export function getLookup(): Q.Lookup<AccFundControlInformationRow> {
            return Q.getLookup<AccFundControlInformationRow>('Configurations.AccFundControlInformation');
        }

        export declare const enum Fields {
            Id = "Id",
            Code = "Code",
            FundControlName = "FundControlName",
            BookingDate = "BookingDate",
            Address = "Address",
            Phone = "Phone",
            Mobile = "Mobile",
            Fax = "Fax",
            Email = "Email",
            WebUrl = "WebUrl",
            Remarks = "Remarks",
            ZoneInfoId = "ZoneInfoId",
            CurrencyId = "CurrencyId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            ZoneInfoZoneNameInBengali = "ZoneInfoZoneNameInBengali",
            ZoneInfoZoneCode = "ZoneInfoZoneCode",
            ZoneInfoSortOrder = "ZoneInfoSortOrder",
            ZoneInfoOrganogramCategoryTypeId = "ZoneInfoOrganogramCategoryTypeId",
            ZoneInfoZoneAddress = "ZoneInfoZoneAddress",
            ZoneInfoZoneAddressInBengali = "ZoneInfoZoneAddressInBengali",
            ZoneInfoPrefix = "ZoneInfoPrefix",
            ZoneInfoIsHeadOffice = "ZoneInfoIsHeadOffice",
            CurrencySymbol = "CurrencySymbol",
            CurrencyCurrency = "CurrencyCurrency",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

