namespace VistaGL.Configurations {
    export namespace AccVoucherApiConfigDetailsService {
        export const baseUrl = 'Configurations/AccVoucherApiConfigDetails';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherApiConfigDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherApiConfigDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherApiConfigDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherApiConfigDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccVoucherApiConfigDetails/Create",
            Update = "Configurations/AccVoucherApiConfigDetails/Update",
            Delete = "Configurations/AccVoucherApiConfigDetails/Delete",
            Retrieve = "Configurations/AccVoucherApiConfigDetails/Retrieve",
            List = "Configurations/AccVoucherApiConfigDetails/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccVoucherApiConfigDetailsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

