namespace VistaGL.Transaction {
    export namespace AccTransactionTypeAssignService {
        export const baseUrl = 'Transaction/AccTransactionTypeAssign';

        export declare function Create(request: Serenity.SaveRequest<AccTransactionTypeAssignRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccTransactionTypeAssignRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccTransactionTypeAssignRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccTransactionTypeAssignRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccTransactionTypeAssign/Create",
            Update = "Transaction/AccTransactionTypeAssign/Update",
            Delete = "Transaction/AccTransactionTypeAssign/Delete",
            Retrieve = "Transaction/AccTransactionTypeAssign/Retrieve",
            List = "Transaction/AccTransactionTypeAssign/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccTransactionTypeAssignService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

