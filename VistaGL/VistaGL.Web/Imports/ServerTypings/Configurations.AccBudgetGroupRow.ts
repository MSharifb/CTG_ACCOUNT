namespace VistaGL.Configurations {
    export interface AccBudgetGroupRow {
        Id?: number;
        ParentId?: number;
        GroupName?: string;
        SortingOrder?: number;
        IsActive?: boolean;
        ParentGroupName?: string;
        BudgetCode?: string;
        IsHideChildrenFromThisLevel?: boolean;
        Type?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBudgetGroupRow {
        export const idProperty = 'Id';
        export const nameProperty = 'GroupName';
        export const localTextPrefix = 'Configurations.AccBudgetGroup';
        export const lookupKey = 'Configurations.AccBudgetGroup';

        export function getLookup(): Q.Lookup<AccBudgetGroupRow> {
            return Q.getLookup<AccBudgetGroupRow>('Configurations.AccBudgetGroup');
        }

        export declare const enum Fields {
            Id = "Id",
            ParentId = "ParentId",
            GroupName = "GroupName",
            SortingOrder = "SortingOrder",
            IsActive = "IsActive",
            ParentGroupName = "ParentGroupName",
            BudgetCode = "BudgetCode",
            IsHideChildrenFromThisLevel = "IsHideChildrenFromThisLevel",
            Type = "Type",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

