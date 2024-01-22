namespace VistaGL.Transaction {
    export interface AccBudgetApprovalHistoryRow {
        Id?: number;
        BudgetForDepartmentId?: number;
        FromAppoverId?: number;
        ApprovalStatusId?: ApprovalStatus;
        ToApproverId?: number;
        BudgetBudgetCircularId?: number;
        BudgetZoneId?: number;
        BudgetDepartmentId?: number;
        BudgetApprovalStatusId?: number;
        BudgetForwardToEmployeeId?: number;
        FromEmpFullName?: string;
        ToEmpFullName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBudgetApprovalHistoryRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Transaction.AccBudgetApprovalHistory';

        export declare const enum Fields {
            Id = "Id",
            BudgetForDepartmentId = "BudgetForDepartmentId",
            FromAppoverId = "FromAppoverId",
            ApprovalStatusId = "ApprovalStatusId",
            ToApproverId = "ToApproverId",
            BudgetBudgetCircularId = "BudgetBudgetCircularId",
            BudgetZoneId = "BudgetZoneId",
            BudgetDepartmentId = "BudgetDepartmentId",
            BudgetApprovalStatusId = "BudgetApprovalStatusId",
            BudgetForwardToEmployeeId = "BudgetForwardToEmployeeId",
            FromEmpFullName = "FromEmpFullName",
            ToEmpFullName = "ToEmpFullName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

