namespace VistaGL.Transaction {
    export namespace BudgetCreationApprovalService {
        export const baseUrl = 'Transaction/BudgetCreationApproval';

        export declare function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/BudgetCreationApproval/Create",
            Update = "Transaction/BudgetCreationApproval/Update",
            Delete = "Transaction/BudgetCreationApproval/Delete",
            Retrieve = "Transaction/BudgetCreationApproval/Retrieve",
            List = "Transaction/BudgetCreationApproval/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>BudgetCreationApprovalService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

