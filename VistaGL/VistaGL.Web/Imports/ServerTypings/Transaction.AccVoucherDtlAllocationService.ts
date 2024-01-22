namespace VistaGL.Transaction {
    export namespace AccVoucherDtlAllocationService {
        export const baseUrl = 'Transaction/AccVoucherDtlAllocation';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherDtlAllocationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherDtlAllocationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherDtlAllocationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherDtlAllocationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccVoucherDtlAllocation/Create",
            Update = "Transaction/AccVoucherDtlAllocation/Update",
            Delete = "Transaction/AccVoucherDtlAllocation/Delete",
            Retrieve = "Transaction/AccVoucherDtlAllocation/Retrieve",
            List = "Transaction/AccVoucherDtlAllocation/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccVoucherDtlAllocationService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

