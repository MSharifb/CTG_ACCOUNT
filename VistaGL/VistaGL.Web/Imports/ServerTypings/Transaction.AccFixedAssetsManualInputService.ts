namespace VistaGL.Transaction {
    export namespace AccFixedAssetsManualInputService {
        export const baseUrl = 'Transaction/AccFixedAssetsManualInput';

        export declare function Create(request: Serenity.SaveRequest<AccFixedAssetsManualInputRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccFixedAssetsManualInputRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFixedAssetsManualInputRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFixedAssetsManualInputRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccFixedAssetsManualInput/Create",
            Update = "Transaction/AccFixedAssetsManualInput/Update",
            Delete = "Transaction/AccFixedAssetsManualInput/Delete",
            Retrieve = "Transaction/AccFixedAssetsManualInput/Retrieve",
            List = "Transaction/AccFixedAssetsManualInput/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccFixedAssetsManualInputService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

