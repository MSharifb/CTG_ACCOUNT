namespace VistaGL.Configurations {
    export namespace AccFundControlZoneWiseApproverService {
        export const baseUrl = 'Configurations/AccFundControlZoneWiseApprover';

        export declare function Create(request: Serenity.SaveRequest<AccFundControlZoneWiseApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccFundControlZoneWiseApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFundControlZoneWiseApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFundControlZoneWiseApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccFundControlZoneWiseApprover/Create",
            Update = "Configurations/AccFundControlZoneWiseApprover/Update",
            Delete = "Configurations/AccFundControlZoneWiseApprover/Delete",
            Retrieve = "Configurations/AccFundControlZoneWiseApprover/Retrieve",
            List = "Configurations/AccFundControlZoneWiseApprover/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccFundControlZoneWiseApproverService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

