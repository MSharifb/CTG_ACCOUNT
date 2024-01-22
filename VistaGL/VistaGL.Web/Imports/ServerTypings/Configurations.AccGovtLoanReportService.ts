namespace VistaGL.Configurations {
    export namespace AccGovtLoanReportService {
        export const baseUrl = 'Configurations/AccGovtLoanReport';

        export declare function Create(request: Serenity.SaveRequest<AccGovtLoanReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccGovtLoanReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccGovtLoanReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccGovtLoanReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccGovtLoanReport/Create",
            Update = "Configurations/AccGovtLoanReport/Update",
            Delete = "Configurations/AccGovtLoanReport/Delete",
            Retrieve = "Configurations/AccGovtLoanReport/Retrieve",
            List = "Configurations/AccGovtLoanReport/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccGovtLoanReportService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

