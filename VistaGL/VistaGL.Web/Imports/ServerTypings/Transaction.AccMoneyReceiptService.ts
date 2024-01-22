namespace VistaGL.Transaction {
    export namespace AccMoneyReceiptService {
        export const baseUrl = 'Transaction/AccMoneyReceipt';

        export declare function Create(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetNewMoneyReceiptNo(request: Transaction.Repositories.GetNewMoneyReceiptNoRequest, onSuccess?: (response: Transaction.Repositories.GetNewMoneyReceiptResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccMoneyReceipt/Create",
            Update = "Transaction/AccMoneyReceipt/Update",
            Delete = "Transaction/AccMoneyReceipt/Delete",
            Retrieve = "Transaction/AccMoneyReceipt/Retrieve",
            List = "Transaction/AccMoneyReceipt/List",
            GetNewMoneyReceiptNo = "Transaction/AccMoneyReceipt/GetNewMoneyReceiptNo"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetNewMoneyReceiptNo'
        ].forEach(x => {
            (<any>AccMoneyReceiptService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

