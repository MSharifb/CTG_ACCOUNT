namespace VistaGL.Transaction {
    export namespace AccCreditVoucherFromMoneyReceiptService {
        export const baseUrl = 'Transaction/AccCreditVoucherFromMoneyReceipt';

        export declare function Create(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CreateCreditVoucher(request: CreditVoucherParametersRequest, onSuccess?: (response: StringMessageResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function BulkAction(request: BulkActionRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccCreditVoucherFromMoneyReceipt/Create",
            Update = "Transaction/AccCreditVoucherFromMoneyReceipt/Update",
            Delete = "Transaction/AccCreditVoucherFromMoneyReceipt/Delete",
            Retrieve = "Transaction/AccCreditVoucherFromMoneyReceipt/Retrieve",
            List = "Transaction/AccCreditVoucherFromMoneyReceipt/List",
            CreateCreditVoucher = "Transaction/AccCreditVoucherFromMoneyReceipt/CreateCreditVoucher",
            BulkAction = "Transaction/AccCreditVoucherFromMoneyReceipt/BulkAction"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'CreateCreditVoucher', 
            'BulkAction'
        ].forEach(x => {
            (<any>AccCreditVoucherFromMoneyReceiptService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

