namespace VistaGL.Transaction {
    export namespace AccVoucherDtlBillRefService {
        export const baseUrl = 'Transaction/AccVoucherDtlBillRef';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherDtlBillRefRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherDtlBillRefRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherDtlBillRefRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherDtlBillRefRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccVoucherDtlBillRef/Create",
            Update = "Transaction/AccVoucherDtlBillRef/Update",
            Delete = "Transaction/AccVoucherDtlBillRef/Delete",
            Retrieve = "Transaction/AccVoucherDtlBillRef/Retrieve",
            List = "Transaction/AccVoucherDtlBillRef/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccVoucherDtlBillRefService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

