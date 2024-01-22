namespace VistaGL.Configurations {
    export interface AccReportTypeGroupOpeningBalanceRow {
        Id?: number;
        GroupId?: number;
        ZoneId?: number;
        FundControlId?: number;
        OpeningBalance?: number;
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
        ZoneZoneName?: string;
        ZoneZoneNameInBengali?: string;
        ZoneZoneCode?: string;
        ZoneSortOrder?: number;
        ZoneOrganogramCategoryTypeId?: number;
        ZoneZoneAddress?: string;
        ZoneZoneAddressInBengali?: string;
        ZonePrefix?: string;
        ZoneIsHeadOffice?: boolean;
        ZoneZoneCodeForBillingSystem?: string;
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
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccReportTypeGroupOpeningBalanceRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccReportTypeGroupOpeningBalance';
        export const lookupKey = 'Configurations.AccReportTypeGroupOpeningBalance';

        export function getLookup(): Q.Lookup<AccReportTypeGroupOpeningBalanceRow> {
            return Q.getLookup<AccReportTypeGroupOpeningBalanceRow>('Configurations.AccReportTypeGroupOpeningBalance');
        }

        export declare const enum Fields {
            Id = "Id",
            GroupId = "GroupId",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            OpeningBalance = "OpeningBalance",
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
            ZoneZoneName = "ZoneZoneName",
            ZoneZoneNameInBengali = "ZoneZoneNameInBengali",
            ZoneZoneCode = "ZoneZoneCode",
            ZoneSortOrder = "ZoneSortOrder",
            ZoneOrganogramCategoryTypeId = "ZoneOrganogramCategoryTypeId",
            ZoneZoneAddress = "ZoneZoneAddress",
            ZoneZoneAddressInBengali = "ZoneZoneAddressInBengali",
            ZonePrefix = "ZonePrefix",
            ZoneIsHeadOffice = "ZoneIsHeadOffice",
            ZoneZoneCodeForBillingSystem = "ZoneZoneCodeForBillingSystem",
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

