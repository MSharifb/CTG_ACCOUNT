namespace VistaGL.Transaction {
    export interface AccBudgetForDepartmentRow {
        Id?: number;
        BudgetCircularId?: number;
        ZoneId?: number;
        EntityId?: number;
        DepartmentId?: number;
        ForwardToEmployeeId?: number;
        ApprovalStatusId?: ApprovalStatus;
        BudgetCircularFinancialYearId?: number;
        BudgetCircularFundControlId?: number;
        BudgetCircularIsActive?: boolean;
        DepartmentName?: string;
        FinancialYearName?: string;
        ZoneName?: string;
        AccBudgetForDepartmentDetailList?: AccBudgetForDepartmentDetailRow[];
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBudgetForDepartmentRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Transaction.AccBudgetForDepartment';
        export const lookupKey = 'Transaction.AccBudgetForDepartment';

        export function getLookup(): Q.Lookup<AccBudgetForDepartmentRow> {
            return Q.getLookup<AccBudgetForDepartmentRow>('Transaction.AccBudgetForDepartment');
        }

        export declare const enum Fields {
            Id = "Id",
            BudgetCircularId = "BudgetCircularId",
            ZoneId = "ZoneId",
            EntityId = "EntityId",
            DepartmentId = "DepartmentId",
            ForwardToEmployeeId = "ForwardToEmployeeId",
            ApprovalStatusId = "ApprovalStatusId",
            BudgetCircularFinancialYearId = "BudgetCircularFinancialYearId",
            BudgetCircularFundControlId = "BudgetCircularFundControlId",
            BudgetCircularIsActive = "BudgetCircularIsActive",
            DepartmentName = "DepartmentName",
            FinancialYearName = "FinancialYearName",
            ZoneName = "ZoneName",
            AccBudgetForDepartmentDetailList = "AccBudgetForDepartmentDetailList",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

