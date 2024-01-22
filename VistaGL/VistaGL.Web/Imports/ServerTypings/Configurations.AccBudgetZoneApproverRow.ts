namespace VistaGL.Configurations {
    export interface AccBudgetZoneApproverRow {
        Id?: number;
        EmployeeId?: number;
        ZoneId?: number;
        EntityId?: number;
        EmployeeEmpId?: string;
        EmployeeEmployeeInitial?: string;
        EmployeeTitleId?: number;
        EmployeeFirstName?: string;
        EmployeeMiddleName?: string;
        EmployeeLastName?: string;
        EmployeeFullName?: string;
        EmployeeFullNameBangla?: string;
        EmployeeDateofJoining?: string;
        EmployeeProvisionMonth?: number;
        EmployeeDateofConfirmation?: string;
        EmployeeDateofPosition?: string;
        EmployeeDesignationId?: number;
        EmployeeStatusDesignationId?: number;
        EmployeeDisciplineId?: number;
        EmployeeDivisionId?: number;
        EmployeeSectionId?: number;
        EmployeeSubSectionId?: number;
        EmployeeJobLocationId?: number;
        EmployeeResourceLevelId?: number;
        EmployeeStaffCategoryId?: number;
        ZoneZoneName?: string;
        EntityCode?: string;
        EntityFundControlName?: string;
    }

    export namespace AccBudgetZoneApproverRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccBudgetZoneApprover';
        export const lookupKey = 'Configurations.AccBudgetZoneApprover';

        export function getLookup(): Q.Lookup<AccBudgetZoneApproverRow> {
            return Q.getLookup<AccBudgetZoneApproverRow>('Configurations.AccBudgetZoneApprover');
        }

        export declare const enum Fields {
            Id = "Id",
            EmployeeId = "EmployeeId",
            ZoneId = "ZoneId",
            EntityId = "EntityId",
            EmployeeEmpId = "EmployeeEmpId",
            EmployeeEmployeeInitial = "EmployeeEmployeeInitial",
            EmployeeTitleId = "EmployeeTitleId",
            EmployeeFirstName = "EmployeeFirstName",
            EmployeeMiddleName = "EmployeeMiddleName",
            EmployeeLastName = "EmployeeLastName",
            EmployeeFullName = "EmployeeFullName",
            EmployeeFullNameBangla = "EmployeeFullNameBangla",
            EmployeeDateofJoining = "EmployeeDateofJoining",
            EmployeeProvisionMonth = "EmployeeProvisionMonth",
            EmployeeDateofConfirmation = "EmployeeDateofConfirmation",
            EmployeeDateofPosition = "EmployeeDateofPosition",
            EmployeeDesignationId = "EmployeeDesignationId",
            EmployeeStatusDesignationId = "EmployeeStatusDesignationId",
            EmployeeDisciplineId = "EmployeeDisciplineId",
            EmployeeDivisionId = "EmployeeDivisionId",
            EmployeeSectionId = "EmployeeSectionId",
            EmployeeSubSectionId = "EmployeeSubSectionId",
            EmployeeJobLocationId = "EmployeeJobLocationId",
            EmployeeResourceLevelId = "EmployeeResourceLevelId",
            EmployeeStaffCategoryId = "EmployeeStaffCategoryId",
            ZoneZoneName = "ZoneZoneName",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName"
        }
    }
}

