namespace VistaGL.Transaction {
    export namespace AccFixedAssetDepreciationService {
        export const baseUrl = 'Transaction/AccFixedAssetDepreciation';

        export declare function Create(request: Serenity.SaveRequest<AccFixedAssetDepreciationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccFixedAssetDepreciationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFixedAssetDepreciationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFixedAssetDepreciationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccFixedAssetDepreciation/Create",
            Update = "Transaction/AccFixedAssetDepreciation/Update",
            Delete = "Transaction/AccFixedAssetDepreciation/Delete",
            Retrieve = "Transaction/AccFixedAssetDepreciation/Retrieve",
            List = "Transaction/AccFixedAssetDepreciation/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccFixedAssetDepreciationService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

