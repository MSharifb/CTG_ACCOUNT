namespace VistaGL.Configurations {
    export namespace AccAdvanceDepositeReportService {
        export const baseUrl = 'Configurations/AccAdvanceDepositeReport';

        export declare function Create(request: Serenity.SaveRequest<AccAdvanceDepositeReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccAdvanceDepositeReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccAdvanceDepositeReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccAdvanceDepositeReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccAdvanceDepositeReport/Create",
            Update = "Configurations/AccAdvanceDepositeReport/Update",
            Delete = "Configurations/AccAdvanceDepositeReport/Delete",
            Retrieve = "Configurations/AccAdvanceDepositeReport/Retrieve",
            List = "Configurations/AccAdvanceDepositeReport/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccAdvanceDepositeReportService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

