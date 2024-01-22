namespace VistaGL.Transaction {
    export namespace AccBankReconciliationDirectService {
        export const baseUrl = 'Transaction/AccBankReconciliationDirect';

        export declare function Create(request: Serenity.SaveRequest<AccBankReconciliationDirectRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBankReconciliationDirectRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBankReconciliationDirectRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBankReconciliationDirectRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccBankReconciliationDirect/Create",
            Update = "Transaction/AccBankReconciliationDirect/Update",
            Delete = "Transaction/AccBankReconciliationDirect/Delete",
            Retrieve = "Transaction/AccBankReconciliationDirect/Retrieve",
            List = "Transaction/AccBankReconciliationDirect/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccBankReconciliationDirectService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

