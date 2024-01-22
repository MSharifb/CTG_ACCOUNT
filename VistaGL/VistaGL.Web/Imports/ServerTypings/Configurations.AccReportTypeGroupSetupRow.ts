namespace VistaGL.Configurations {
    export interface AccReportTypeGroupSetupRow {
        Id?: number;
        ParentId?: number;
        ReportTypeId?: number;
        GroupName?: string;
        SortingOrder?: number;
        ShowAutoSum?: boolean;
        NoteNo?: number;
        AddBlankSpaceBefore?: boolean;
        AddBlankSpaceAfter?: boolean;
        ShowBottomBorder?: boolean;
        ShowUpperBorder?: boolean;
        ShowLeftBorder?: boolean;
        ShowRightBorder?: boolean;
        FundControlId?: number;
        ReportType?: string;
        ParentGroupName?: string;
        Symbol?: string;
        FontWeight?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccReportTypeGroupSetupRow {
        export const idProperty = 'Id';
        export const nameProperty = 'GroupName';
        export const localTextPrefix = 'Configurations.AccReportTypeGroupSetup';
        export const lookupKey = 'Configurations.AccReportTypeGroupSetup';

        export function getLookup(): Q.Lookup<AccReportTypeGroupSetupRow> {
            return Q.getLookup<AccReportTypeGroupSetupRow>('Configurations.AccReportTypeGroupSetup');
        }

        export declare const enum Fields {
            Id = "Id",
            ParentId = "ParentId",
            ReportTypeId = "ReportTypeId",
            GroupName = "GroupName",
            SortingOrder = "SortingOrder",
            ShowAutoSum = "ShowAutoSum",
            NoteNo = "NoteNo",
            AddBlankSpaceBefore = "AddBlankSpaceBefore",
            AddBlankSpaceAfter = "AddBlankSpaceAfter",
            ShowBottomBorder = "ShowBottomBorder",
            ShowUpperBorder = "ShowUpperBorder",
            ShowLeftBorder = "ShowLeftBorder",
            ShowRightBorder = "ShowRightBorder",
            FundControlId = "FundControlId",
            ReportType = "ReportType",
            ParentGroupName = "ParentGroupName",
            Symbol = "Symbol",
            FontWeight = "FontWeight",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

