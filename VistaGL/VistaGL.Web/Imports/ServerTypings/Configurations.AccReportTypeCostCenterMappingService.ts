namespace VistaGL.Configurations {
    export namespace AccReportTypeCostCenterMappingService {
        export const baseUrl = 'Configurations/AccReportTypeCostCenterMapping';

        export declare function Create(request: Serenity.SaveRequest<AccReportTypeCostCenterMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccReportTypeCostCenterMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeCostCenterMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeCostCenterMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccReportTypeCostCenterMapping/Create",
            Update = "Configurations/AccReportTypeCostCenterMapping/Update",
            Delete = "Configurations/AccReportTypeCostCenterMapping/Delete",
            Retrieve = "Configurations/AccReportTypeCostCenterMapping/Retrieve",
            List = "Configurations/AccReportTypeCostCenterMapping/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccReportTypeCostCenterMappingService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

