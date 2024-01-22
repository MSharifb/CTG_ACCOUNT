namespace VistaGL.Configurations {
    export namespace AccReportTypeGroupOpeningBalanceService {
        export const baseUrl = 'Configurations/AccReportTypeGroupOpeningBalance';

        export declare function Create(request: Serenity.SaveRequest<AccReportTypeGroupOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccReportTypeGroupOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeGroupOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeGroupOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccReportTypeGroupOpeningBalance/Create",
            Update = "Configurations/AccReportTypeGroupOpeningBalance/Update",
            Delete = "Configurations/AccReportTypeGroupOpeningBalance/Delete",
            Retrieve = "Configurations/AccReportTypeGroupOpeningBalance/Retrieve",
            List = "Configurations/AccReportTypeGroupOpeningBalance/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccReportTypeGroupOpeningBalanceService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

