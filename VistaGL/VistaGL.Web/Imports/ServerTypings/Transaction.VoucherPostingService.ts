namespace VistaGL.Transaction {
    export namespace VoucherPostingService {
        export const baseUrl = 'Transaction/VoucherPosting';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function BulkAction(request: BulkActionRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/VoucherPosting/Create",
            Update = "Transaction/VoucherPosting/Update",
            Delete = "Transaction/VoucherPosting/Delete",
            Retrieve = "Transaction/VoucherPosting/Retrieve",
            List = "Transaction/VoucherPosting/List",
            BulkAction = "Transaction/VoucherPosting/BulkAction"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'BulkAction'
        ].forEach(x => {
            (<any>VoucherPostingService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

