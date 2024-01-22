namespace VistaGL.Configurations {
    export namespace AccReportTypeGroupSetupService {
        export const baseUrl = 'Configurations/AccReportTypeGroupSetup';

        export declare function Create(request: Serenity.SaveRequest<AccReportTypeGroupSetupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccReportTypeGroupSetupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeGroupSetupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeGroupSetupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccReportTypeGroupSetup/Create",
            Update = "Configurations/AccReportTypeGroupSetup/Update",
            Delete = "Configurations/AccReportTypeGroupSetup/Delete",
            Retrieve = "Configurations/AccReportTypeGroupSetup/Retrieve",
            List = "Configurations/AccReportTypeGroupSetup/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccReportTypeGroupSetupService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

