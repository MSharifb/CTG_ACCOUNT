namespace VistaGL.Transaction {
    export namespace AccIbcsJsondataHistoryService {
        export const baseUrl = 'Transaction/AccIbcsJsondataHistory';

        export declare function Create(request: Serenity.SaveRequest<AccIbcsJsondataHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccIbcsJsondataHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccIbcsJsondataHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccIbcsJsondataHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccIbcsJsondataHistory/Create",
            Update = "Transaction/AccIbcsJsondataHistory/Update",
            Delete = "Transaction/AccIbcsJsondataHistory/Delete",
            Retrieve = "Transaction/AccIbcsJsondataHistory/Retrieve",
            List = "Transaction/AccIbcsJsondataHistory/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccIbcsJsondataHistoryService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

