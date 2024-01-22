namespace VistaGL.Configurations {
    export namespace AccCoACostCenterOpeningBalanceService {
        export const baseUrl = 'Configurations/AccCoACostCenterOpeningBalance';

        export declare function Create(request: Serenity.SaveRequest<AccCoACostCenterOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccCoACostCenterOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCoACostCenterOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCoACostCenterOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccCoACostCenterOpeningBalance/Create",
            Update = "Configurations/AccCoACostCenterOpeningBalance/Update",
            Delete = "Configurations/AccCoACostCenterOpeningBalance/Delete",
            Retrieve = "Configurations/AccCoACostCenterOpeningBalance/Retrieve",
            List = "Configurations/AccCoACostCenterOpeningBalance/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccCoACostCenterOpeningBalanceService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

