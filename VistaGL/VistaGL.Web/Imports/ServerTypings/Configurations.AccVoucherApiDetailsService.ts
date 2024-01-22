namespace VistaGL.Configurations {
    export namespace AccVoucherApiDetailsService {
        export const baseUrl = 'Configurations/AccVoucherApiDetails';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherApiDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherApiDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherApiDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherApiDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccVoucherApiDetails/Create",
            Update = "Configurations/AccVoucherApiDetails/Update",
            Delete = "Configurations/AccVoucherApiDetails/Delete",
            Retrieve = "Configurations/AccVoucherApiDetails/Retrieve",
            List = "Configurations/AccVoucherApiDetails/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccVoucherApiDetailsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

