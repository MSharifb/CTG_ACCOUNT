namespace VistaGL.Transaction {
    export interface AccBudgetForDepartmentDetailRow {
        BGSortOrder?: number;
        BudgetCode?: string;
        _collapsed?: string;
        _indent?: string;
        Id?: number;
        BudgetForDepartmentId?: number;
        BudgetGroupId?: number;
        ParentId?: number;
        BudgetHeadId?: number;
        IsCoa?: boolean;
        IsBudgetHead?: boolean;
        IsCostCenter?: boolean;
        BudgetForDepartmentBudgetCircularId?: number;
        BudgetForDepartmentZoneId?: number;
        BudgetForDepartmentDepartmentId?: number;
        BudgetForDepartmentForwardToEmployeeId?: number;
        BudgetForDepartmentApprovalStatusId?: number;
        ProposedBudgetFinancialYearId?: number;
        BudgetGroupParentId?: number;
        BudgetGroupGroupName?: string;
        BudgetGroupSortingOrder?: number;
        BudgetGroupIsActive?: boolean;
        BudgetHeadName?: string;
        ProposedBudgetAmount?: number;
        RevisedEstimateAmount?: number;
        ActualFirstSixMonths?: number;
        BudgetApproved?: number;
        ActualDuring?: number;
        CircularFundControlId?: number;
        CircularFinancialYearId?: number;
        CircularIsActive?: boolean;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBudgetForDepartmentDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'BudgetHeadName';
        export const localTextPrefix = 'Transaction.AccBudgetForDepartmentDetail';
        export const lookupKey = 'Transaction.AccBudgetForDepartmentDetail';

        export function getLookup(): Q.Lookup<AccBudgetForDepartmentDetailRow> {
            return Q.getLookup<AccBudgetForDepartmentDetailRow>('Transaction.AccBudgetForDepartmentDetail');
        }

        export declare const enum Fields {
            BGSortOrder = "BGSortOrder",
            BudgetCode = "BudgetCode",
            _collapsed = "_collapsed",
            _indent = "_indent",
            Id = "Id",
            BudgetForDepartmentId = "BudgetForDepartmentId",
            BudgetGroupId = "BudgetGroupId",
            ParentId = "ParentId",
            BudgetHeadId = "BudgetHeadId",
            IsCoa = "IsCoa",
            IsBudgetHead = "IsBudgetHead",
            IsCostCenter = "IsCostCenter",
            BudgetForDepartmentBudgetCircularId = "BudgetForDepartmentBudgetCircularId",
            BudgetForDepartmentZoneId = "BudgetForDepartmentZoneId",
            BudgetForDepartmentDepartmentId = "BudgetForDepartmentDepartmentId",
            BudgetForDepartmentForwardToEmployeeId = "BudgetForDepartmentForwardToEmployeeId",
            BudgetForDepartmentApprovalStatusId = "BudgetForDepartmentApprovalStatusId",
            ProposedBudgetFinancialYearId = "ProposedBudgetFinancialYearId",
            BudgetGroupParentId = "BudgetGroupParentId",
            BudgetGroupGroupName = "BudgetGroupGroupName",
            BudgetGroupSortingOrder = "BudgetGroupSortingOrder",
            BudgetGroupIsActive = "BudgetGroupIsActive",
            BudgetHeadName = "BudgetHeadName",
            ProposedBudgetAmount = "ProposedBudgetAmount",
            RevisedEstimateAmount = "RevisedEstimateAmount",
            ActualFirstSixMonths = "ActualFirstSixMonths",
            BudgetApproved = "BudgetApproved",
            ActualDuring = "ActualDuring",
            CircularFundControlId = "CircularFundControlId",
            CircularFinancialYearId = "CircularFinancialYearId",
            CircularIsActive = "CircularIsActive",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

