namespace VistaGL.Transaction {
    export namespace AccFixedAssetRefurbishmentService {
        export const baseUrl = 'Transaction/AccFixedAssetRefurbishment';

        export declare function Create(request: Serenity.SaveRequest<AccFixedAssetRefurbishmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccFixedAssetRefurbishmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFixedAssetRefurbishmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFixedAssetRefurbishmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccFixedAssetRefurbishment/Create",
            Update = "Transaction/AccFixedAssetRefurbishment/Update",
            Delete = "Transaction/AccFixedAssetRefurbishment/Delete",
            Retrieve = "Transaction/AccFixedAssetRefurbishment/Retrieve",
            List = "Transaction/AccFixedAssetRefurbishment/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccFixedAssetRefurbishmentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

