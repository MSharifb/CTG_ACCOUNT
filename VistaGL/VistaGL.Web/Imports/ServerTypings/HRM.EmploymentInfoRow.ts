namespace VistaGL.HRM {
    export interface EmploymentInfoRow {
        Id?: number;
        EmpId?: string;
        EmployeeInitial?: string;
        TitleId?: number;
        FirstName?: string;
        MiddleName?: string;
        LastName?: string;
        FullName?: string;
        DesignationId?: number;
        DisciplineId?: number;
        DivisionId?: number;
        EmploymentStatusId?: number;
        PrlDate?: string;
        RegionId?: number;
        TitleName?: string;
        LookupText?: string;
        DesignationName?: string;
        DisciplineName?: string;
        DivisionName?: string;
        EmploymentStatusName?: string;
    }

    export namespace EmploymentInfoRow {
        export const idProperty = 'Id';
        export const nameProperty = 'LookupText';
        export const localTextPrefix = 'HRM.EmploymentInfo';
        export const lookupKey = 'HRM.EmploymentInfo';

        export function getLookup(): Q.Lookup<EmploymentInfoRow> {
            return Q.getLookup<EmploymentInfoRow>('HRM.EmploymentInfo');
        }

        export declare const enum Fields {
            Id = "Id",
            EmpId = "EmpId",
            EmployeeInitial = "EmployeeInitial",
            TitleId = "TitleId",
            FirstName = "FirstName",
            MiddleName = "MiddleName",
            LastName = "LastName",
            FullName = "FullName",
            DesignationId = "DesignationId",
            DisciplineId = "DisciplineId",
            DivisionId = "DivisionId",
            EmploymentStatusId = "EmploymentStatusId",
            PrlDate = "PrlDate",
            RegionId = "RegionId",
            TitleName = "TitleName",
            LookupText = "LookupText",
            DesignationName = "DesignationName",
            DisciplineName = "DisciplineName",
            DivisionName = "DivisionName",
            EmploymentStatusName = "EmploymentStatusName"
        }
    }
}

