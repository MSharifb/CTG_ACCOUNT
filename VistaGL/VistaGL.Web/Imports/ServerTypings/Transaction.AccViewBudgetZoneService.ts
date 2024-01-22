namespace VistaGL.Transaction {
    export namespace AccViewBudgetZoneService {
        export const baseUrl = 'Transaction/AccViewBudgetZone';

        export declare function Create(request: Serenity.SaveRequest<AccViewBudgetZoneRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccViewBudgetZoneRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccViewBudgetZoneRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccViewBudgetZoneRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccViewBudgetZone/Create",
            Update = "Transaction/AccViewBudgetZone/Update",
            Delete = "Transaction/AccViewBudgetZone/Delete",
            Retrieve = "Transaction/AccViewBudgetZone/Retrieve",
            List = "Transaction/AccViewBudgetZone/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccViewBudgetZoneService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

