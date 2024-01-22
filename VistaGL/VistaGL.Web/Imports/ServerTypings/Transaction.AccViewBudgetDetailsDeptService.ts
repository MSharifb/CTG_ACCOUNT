namespace VistaGL.Transaction {
    export namespace AccViewBudgetDetailsDeptService {
        export const baseUrl = 'Transaction/AccViewBudgetDetailsDept';

        export declare function Create(request: Serenity.SaveRequest<AccViewBudgetDetailsDeptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccViewBudgetDetailsDeptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccViewBudgetDetailsDeptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccViewBudgetDetailsDeptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccViewBudgetDetailsDept/Create",
            Update = "Transaction/AccViewBudgetDetailsDept/Update",
            Delete = "Transaction/AccViewBudgetDetailsDept/Delete",
            Retrieve = "Transaction/AccViewBudgetDetailsDept/Retrieve",
            List = "Transaction/AccViewBudgetDetailsDept/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccViewBudgetDetailsDeptService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

