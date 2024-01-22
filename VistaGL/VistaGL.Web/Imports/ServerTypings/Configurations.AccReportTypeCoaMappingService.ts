namespace VistaGL.Configurations {
    export namespace AccReportTypeCoaMappingService {
        export const baseUrl = 'Configurations/AccReportTypeCoaMapping';

        export declare function Create(request: Serenity.SaveRequest<AccReportTypeCoaMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccReportTypeCoaMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeCoaMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeCoaMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccReportTypeCoaMapping/Create",
            Update = "Configurations/AccReportTypeCoaMapping/Update",
            Delete = "Configurations/AccReportTypeCoaMapping/Delete",
            Retrieve = "Configurations/AccReportTypeCoaMapping/Retrieve",
            List = "Configurations/AccReportTypeCoaMapping/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccReportTypeCoaMappingService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

