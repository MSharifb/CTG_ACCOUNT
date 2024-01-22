namespace VistaGL.Configurations {
    export namespace AccPriorYearAdjustmentService {
        export const baseUrl = 'Configurations/AccPriorYearAdjustment';

        export declare function Create(request: Serenity.SaveRequest<AccPriorYearAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccPriorYearAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccPriorYearAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccPriorYearAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccPriorYearAdjustment/Create",
            Update = "Configurations/AccPriorYearAdjustment/Update",
            Delete = "Configurations/AccPriorYearAdjustment/Delete",
            Retrieve = "Configurations/AccPriorYearAdjustment/Retrieve",
            List = "Configurations/AccPriorYearAdjustment/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccPriorYearAdjustmentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

