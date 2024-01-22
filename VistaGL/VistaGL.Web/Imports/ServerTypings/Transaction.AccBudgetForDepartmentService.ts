namespace VistaGL.Transaction {
    export namespace AccBudgetForDepartmentService {
        export const baseUrl = 'Transaction/AccBudgetForDepartment';

        export declare function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function BudgetHeadList(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccBudgetForDepartment/Create",
            Update = "Transaction/AccBudgetForDepartment/Update",
            Delete = "Transaction/AccBudgetForDepartment/Delete",
            Retrieve = "Transaction/AccBudgetForDepartment/Retrieve",
            List = "Transaction/AccBudgetForDepartment/List",
            BudgetHeadList = "Transaction/AccBudgetForDepartment/BudgetHeadList"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'BudgetHeadList'
        ].forEach(x => {
            (<any>AccBudgetForDepartmentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

