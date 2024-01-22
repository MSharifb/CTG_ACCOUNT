namespace VistaGL.Configurations {
    export namespace AccCurrencyConversionService {
        export const baseUrl = 'Configurations/AccCurrencyConversion';

        export declare function Create(request: Serenity.SaveRequest<AccCurrencyConversionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccCurrencyConversionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCurrencyConversionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCurrencyConversionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccCurrencyConversion/Create",
            Update = "Configurations/AccCurrencyConversion/Update",
            Delete = "Configurations/AccCurrencyConversion/Delete",
            Retrieve = "Configurations/AccCurrencyConversion/Retrieve",
            List = "Configurations/AccCurrencyConversion/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccCurrencyConversionService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

