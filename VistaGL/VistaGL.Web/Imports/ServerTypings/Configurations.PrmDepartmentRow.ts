namespace VistaGL.Configurations {
    export interface PrmDepartmentRow {
        Id?: number;
        Name?: string;
        SortOrder?: number;
        Remarks?: string;
        ZoneInfoId?: number;
        ZoneInfoZoneName?: string;
    }

    export namespace PrmDepartmentRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Configurations.PrmDepartment';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            SortOrder = "SortOrder",
            Remarks = "Remarks",
            ZoneInfoId = "ZoneInfoId",
            ZoneInfoZoneName = "ZoneInfoZoneName"
        }
    }
}

