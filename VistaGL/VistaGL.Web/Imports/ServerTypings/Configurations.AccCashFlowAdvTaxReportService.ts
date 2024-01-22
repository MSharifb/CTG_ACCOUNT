namespace VistaGL.Configurations {
    export namespace AccCashFlowAdvTaxReportService {
        export const baseUrl = 'Configurations/AccCashFlowAdvTaxReport';

        export declare function Create(request: Serenity.SaveRequest<AccCashFlowAdvTaxReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccCashFlowAdvTaxReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCashFlowAdvTaxReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCashFlowAdvTaxReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccCashFlowAdvTaxReport/Create",
            Update = "Configurations/AccCashFlowAdvTaxReport/Update",
            Delete = "Configurations/AccCashFlowAdvTaxReport/Delete",
            Retrieve = "Configurations/AccCashFlowAdvTaxReport/Retrieve",
            List = "Configurations/AccCashFlowAdvTaxReport/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccCashFlowAdvTaxReportService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

