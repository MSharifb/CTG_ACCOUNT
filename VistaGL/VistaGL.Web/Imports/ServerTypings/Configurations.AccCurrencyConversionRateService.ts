namespace VistaGL.Configurations {
    export namespace AccCurrencyConversionRateService {
        export const baseUrl = 'Configurations/AccCurrencyConversionRate';

        export declare function Create(request: Serenity.SaveRequest<AccCurrencyConversionRateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccCurrencyConversionRateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCurrencyConversionRateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCurrencyConversionRateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccCurrencyConversionRate/Create",
            Update = "Configurations/AccCurrencyConversionRate/Update",
            Delete = "Configurations/AccCurrencyConversionRate/Delete",
            Retrieve = "Configurations/AccCurrencyConversionRate/Retrieve",
            List = "Configurations/AccCurrencyConversionRate/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccCurrencyConversionRateService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

