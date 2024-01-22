namespace VistaGL.Configurations {
    export namespace AccOpeningBalanceService {
        export const baseUrl = 'Configurations/AccOpeningBalance';

        export declare function Create(request: Serenity.SaveRequest<AccOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccOpeningBalance/Create",
            Update = "Configurations/AccOpeningBalance/Update",
            Delete = "Configurations/AccOpeningBalance/Delete",
            Retrieve = "Configurations/AccOpeningBalance/Retrieve",
            List = "Configurations/AccOpeningBalance/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccOpeningBalanceService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

