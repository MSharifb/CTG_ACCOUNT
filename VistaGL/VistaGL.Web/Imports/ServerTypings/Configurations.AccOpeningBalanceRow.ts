namespace VistaGL.Configurations {
    export interface AccOpeningBalanceRow {
        Id?: number;
        OpeningBalance?: number;
        CoAid?: number;
        ZoneId?: number;
        FundControlId?: number;
        CoAidAccountCode?: string;
        CoAidAccountCodeCount?: number;
        CoAidAccountGroup?: string;
        CoAidAccountName?: string;
        CoAidAccountNameBangla?: string;
        CoAidCoaMapping?: string;
        CoAidIsBillRef?: number;
        CoAidIsBudgetHead?: number;
        CoAidIsControlhead?: number;
        CoAidIsCostCenterAllocate?: number;
        CoAidLevel?: number;
        CoAidMailingAddress?: string;
        CoAidMailingName?: string;
        CoAidOpeningBalance?: number;
        CoAidRemarks?: string;
        CoAidTaxId?: string;
        CoAidUgcCode?: string;
        CoAidFundControlId?: number;
        CoAidParentAccountId?: number;
        CoAidMultiCurrencyId?: number;
        CoAidEffectCashFlow?: number;
        ZoneZoneName?: string;
        ZoneZoneNameInBengali?: string;
        ZoneZoneCode?: string;
        ZoneSortOrder?: number;
        ZoneOrganogramCategoryTypeId?: number;
        ZoneZoneAddress?: string;
        ZoneZoneAddressInBengali?: string;
        ZonePrefix?: string;
        ZoneIsHeadOffice?: boolean;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlBookingDate?: string;
        FundControlAddress?: string;
        FundControlPhone?: string;
        FundControlMobile?: string;
        FundControlFax?: string;
        FundControlEmail?: string;
        FundControlWebUrl?: string;
        FundControlRemarks?: string;
        FundControlZoneInfoId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccOpeningBalanceRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccOpeningBalance';
        export const lookupKey = 'Configurations.AccOpeningBalance';

        export function getLookup(): Q.Lookup<AccOpeningBalanceRow> {
            return Q.getLookup<AccOpeningBalanceRow>('Configurations.AccOpeningBalance');
        }

        export declare const enum Fields {
            Id = "Id",
            OpeningBalance = "OpeningBalance",
            CoAid = "CoAid",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            CoAidAccountCode = "CoAidAccountCode",
            CoAidAccountCodeCount = "CoAidAccountCodeCount",
            CoAidAccountGroup = "CoAidAccountGroup",
            CoAidAccountName = "CoAidAccountName",
            CoAidAccountNameBangla = "CoAidAccountNameBangla",
            CoAidCoaMapping = "CoAidCoaMapping",
            CoAidIsBillRef = "CoAidIsBillRef",
            CoAidIsBudgetHead = "CoAidIsBudgetHead",
            CoAidIsControlhead = "CoAidIsControlhead",
            CoAidIsCostCenterAllocate = "CoAidIsCostCenterAllocate",
            CoAidLevel = "CoAidLevel",
            CoAidMailingAddress = "CoAidMailingAddress",
            CoAidMailingName = "CoAidMailingName",
            CoAidOpeningBalance = "CoAidOpeningBalance",
            CoAidRemarks = "CoAidRemarks",
            CoAidTaxId = "CoAidTaxId",
            CoAidUgcCode = "CoAidUgcCode",
            CoAidFundControlId = "CoAidFundControlId",
            CoAidParentAccountId = "CoAidParentAccountId",
            CoAidMultiCurrencyId = "CoAidMultiCurrencyId",
            CoAidEffectCashFlow = "CoAidEffectCashFlow",
            ZoneZoneName = "ZoneZoneName",
            ZoneZoneNameInBengali = "ZoneZoneNameInBengali",
            ZoneZoneCode = "ZoneZoneCode",
            ZoneSortOrder = "ZoneSortOrder",
            ZoneOrganogramCategoryTypeId = "ZoneOrganogramCategoryTypeId",
            ZoneZoneAddress = "ZoneZoneAddress",
            ZoneZoneAddressInBengali = "ZoneZoneAddressInBengali",
            ZonePrefix = "ZonePrefix",
            ZoneIsHeadOffice = "ZoneIsHeadOffice",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlBookingDate = "FundControlBookingDate",
            FundControlAddress = "FundControlAddress",
            FundControlPhone = "FundControlPhone",
            FundControlMobile = "FundControlMobile",
            FundControlFax = "FundControlFax",
            FundControlEmail = "FundControlEmail",
            FundControlWebUrl = "FundControlWebUrl",
            FundControlRemarks = "FundControlRemarks",
            FundControlZoneInfoId = "FundControlZoneInfoId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

