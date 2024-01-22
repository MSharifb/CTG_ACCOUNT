namespace VistaGL.Transaction {
    export namespace AccBankAdviceLetterService {
        export const baseUrl = 'Transaction/AccBankAdviceLetter';

        export declare function Create(request: Serenity.SaveRequest<AccChequeRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccChequeRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChequeRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChequeRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccBankAdviceLetter/Create",
            Update = "Transaction/AccBankAdviceLetter/Update",
            Delete = "Transaction/AccBankAdviceLetter/Delete",
            Retrieve = "Transaction/AccBankAdviceLetter/Retrieve",
            List = "Transaction/AccBankAdviceLetter/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccBankAdviceLetterService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

