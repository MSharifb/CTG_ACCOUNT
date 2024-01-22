namespace VistaGL.Transaction {
    export namespace AccBudgetForDepartmentDetailService {
        export const baseUrl = 'Transaction/AccBudgetForDepartmentDetail';

        export declare function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccBudgetForDepartmentDetail/Create",
            Update = "Transaction/AccBudgetForDepartmentDetail/Update",
            Delete = "Transaction/AccBudgetForDepartmentDetail/Delete",
            Retrieve = "Transaction/AccBudgetForDepartmentDetail/Retrieve",
            List = "Transaction/AccBudgetForDepartmentDetail/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccBudgetForDepartmentDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

