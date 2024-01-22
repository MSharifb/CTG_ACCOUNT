namespace VistaGL.Configurations {
    export interface PrmEmploymentInfoRow {
        Id?: number;
        EmpId?: string;
        EmployeeInitial?: string;
        TitleId?: number;
        FirstName?: string;
        MiddleName?: string;
        LastName?: string;
        FullName?: string;
        FullNameBangla?: string;
        DateofJoining?: string;
        ProvisionMonth?: number;
        DateofConfirmation?: string;
        DateofPosition?: string;
        DesignationId?: number;
        StatusDesignationId?: number;
        DisciplineId?: number;
        DivisionId?: number;
        StaffCategoryId?: number;
        SectionId?: number;
        BankId?: number;
        BankBranchId?: number;
        BankAccountNo?: string;
        EmploymentStatusId?: number;
        DateofInactive?: string;
        Gender?: string;
        ZoneInfoId?: number;
        LookupText?: string;
        DesignationName?: string;
        ZoneInfoZoneName?: string;
        StatusDesignationName?: string;
        DivisionName?: string;
        StaffCategoryName?: string;
    }

    export namespace PrmEmploymentInfoRow {
        export const idProperty = 'Id';
        export const nameProperty = 'LookupText';
        export const localTextPrefix = 'Configurations.PrmEmploymentInfo';
        export const lookupKey = 'Configurations.PrmEmploymentInfo';

        export function getLookup(): Q.Lookup<PrmEmploymentInfoRow> {
            return Q.getLookup<PrmEmploymentInfoRow>('Configurations.PrmEmploymentInfo');
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
            FullNameBangla = "FullNameBangla",
            DateofJoining = "DateofJoining",
            ProvisionMonth = "ProvisionMonth",
            DateofConfirmation = "DateofConfirmation",
            DateofPosition = "DateofPosition",
            DesignationId = "DesignationId",
            StatusDesignationId = "StatusDesignationId",
            DisciplineId = "DisciplineId",
            DivisionId = "DivisionId",
            StaffCategoryId = "StaffCategoryId",
            SectionId = "SectionId",
            BankId = "BankId",
            BankBranchId = "BankBranchId",
            BankAccountNo = "BankAccountNo",
            EmploymentStatusId = "EmploymentStatusId",
            DateofInactive = "DateofInactive",
            Gender = "Gender",
            ZoneInfoId = "ZoneInfoId",
            LookupText = "LookupText",
            DesignationName = "DesignationName",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            StatusDesignationName = "StatusDesignationName",
            DivisionName = "DivisionName",
            StaffCategoryName = "StaffCategoryName"
        }
    }
}

