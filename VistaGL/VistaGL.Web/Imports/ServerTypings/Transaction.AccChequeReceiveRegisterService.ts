namespace VistaGL.Transaction {
    export namespace AccChequeReceiveRegisterService {
        export const baseUrl = 'Transaction/AccChequeReceiveRegister';

        export declare function Create(request: Serenity.SaveRequest<AccChequeReceiveRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccChequeReceiveRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChequeReceiveRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChequeReceiveRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccChequeReceiveRegister/Create",
            Update = "Transaction/AccChequeReceiveRegister/Update",
            Delete = "Transaction/AccChequeReceiveRegister/Delete",
            Retrieve = "Transaction/AccChequeReceiveRegister/Retrieve",
            List = "Transaction/AccChequeReceiveRegister/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccChequeReceiveRegisterService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

