namespace VistaGL.Transaction {
    export namespace AccViewBudgetDetailsService {
        export const baseUrl = 'Transaction/AccViewBudgetDetails';

        export declare function Create(request: Serenity.SaveRequest<AccViewBudgetDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccViewBudgetDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccViewBudgetDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccViewBudgetDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccViewBudgetDetails/Create",
            Update = "Transaction/AccViewBudgetDetails/Update",
            Delete = "Transaction/AccViewBudgetDetails/Delete",
            Retrieve = "Transaction/AccViewBudgetDetails/Retrieve",
            List = "Transaction/AccViewBudgetDetails/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccViewBudgetDetailsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

