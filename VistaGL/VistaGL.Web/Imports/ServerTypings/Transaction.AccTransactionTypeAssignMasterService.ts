namespace VistaGL.Transaction {
    export namespace AccTransactionTypeAssignMasterService {
        export const baseUrl = 'Transaction/AccTransactionTypeAssignMaster';

        export declare function Create(request: Serenity.SaveRequest<AccTransactionTypeAssignMasterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccTransactionTypeAssignMasterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccTransactionTypeAssignMasterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccTransactionTypeAssignMasterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccTransactionTypeAssignMaster/Create",
            Update = "Transaction/AccTransactionTypeAssignMaster/Update",
            Delete = "Transaction/AccTransactionTypeAssignMaster/Delete",
            Retrieve = "Transaction/AccTransactionTypeAssignMaster/Retrieve",
            List = "Transaction/AccTransactionTypeAssignMaster/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccTransactionTypeAssignMasterService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

