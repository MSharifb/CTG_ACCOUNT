namespace VistaGL.Configurations {
    export namespace AccVoucherApiConfigService {
        export const baseUrl = 'Configurations/AccVoucherApiConfig';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherApiConfigRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherApiConfigRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherApiConfigRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherApiConfigRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccVoucherApiConfig/Create",
            Update = "Configurations/AccVoucherApiConfig/Update",
            Delete = "Configurations/AccVoucherApiConfig/Delete",
            Retrieve = "Configurations/AccVoucherApiConfig/Retrieve",
            List = "Configurations/AccVoucherApiConfig/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccVoucherApiConfigService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

