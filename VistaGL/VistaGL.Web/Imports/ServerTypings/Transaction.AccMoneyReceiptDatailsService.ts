namespace VistaGL.Transaction {
    export namespace AccMoneyReceiptDatailsService {
        export const baseUrl = 'Transaction/AccMoneyReceiptDatails';

        export declare function Create(request: Serenity.SaveRequest<AccMoneyReceiptDatailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccMoneyReceiptDatailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccMoneyReceiptDatailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccMoneyReceiptDatailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccMoneyReceiptDatails/Create",
            Update = "Transaction/AccMoneyReceiptDatails/Update",
            Delete = "Transaction/AccMoneyReceiptDatails/Delete",
            Retrieve = "Transaction/AccMoneyReceiptDatails/Retrieve",
            List = "Transaction/AccMoneyReceiptDatails/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccMoneyReceiptDatailsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

