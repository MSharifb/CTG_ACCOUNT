namespace VistaGL.Transaction {
    export namespace AccEmpAdvanceService {
        export const baseUrl = 'Transaction/AccEmpAdvance';

        export declare function Create(request: Serenity.SaveRequest<AccEmpAdvanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccEmpAdvanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccEmpAdvanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccEmpAdvanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccEmpAdvance/Create",
            Update = "Transaction/AccEmpAdvance/Update",
            Delete = "Transaction/AccEmpAdvance/Delete",
            Retrieve = "Transaction/AccEmpAdvance/Retrieve",
            List = "Transaction/AccEmpAdvance/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccEmpAdvanceService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

