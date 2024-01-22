namespace VistaGL.Transaction {
    export namespace AccBudgetCircularService {
        export const baseUrl = 'Transaction/AccBudgetCircular';

        export declare function Create(request: Serenity.SaveRequest<AccBudgetCircularRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBudgetCircularRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetCircularRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetCircularRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccBudgetCircular/Create",
            Update = "Transaction/AccBudgetCircular/Update",
            Delete = "Transaction/AccBudgetCircular/Delete",
            Retrieve = "Transaction/AccBudgetCircular/Retrieve",
            List = "Transaction/AccBudgetCircular/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccBudgetCircularService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

