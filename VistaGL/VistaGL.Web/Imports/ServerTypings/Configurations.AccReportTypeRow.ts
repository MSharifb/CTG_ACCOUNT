namespace VistaGL.Configurations {
    export interface AccReportTypeRow {
        Id?: number;
        ReportType?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccReportTypeRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ReportType';
        export const localTextPrefix = 'Configurations.AccReportType';
        export const lookupKey = 'Configurations.AccReportType';

        export function getLookup(): Q.Lookup<AccReportTypeRow> {
            return Q.getLookup<AccReportTypeRow>('Configurations.AccReportType');
        }

        export declare const enum Fields {
            Id = "Id",
            ReportType = "ReportType",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

