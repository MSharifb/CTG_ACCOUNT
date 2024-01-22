namespace VistaGL.Configurations {
    export namespace AccFinancialReportsDetailsService {
        export const baseUrl = 'Configurations/AccFinancialReportsDetails';

        export declare function Create(request: Serenity.SaveRequest<AccFinancialReportsDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccFinancialReportsDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFinancialReportsDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFinancialReportsDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccFinancialReportsDetails/Create",
            Update = "Configurations/AccFinancialReportsDetails/Update",
            Delete = "Configurations/AccFinancialReportsDetails/Delete",
            Retrieve = "Configurations/AccFinancialReportsDetails/Retrieve",
            List = "Configurations/AccFinancialReportsDetails/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccFinancialReportsDetailsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

