namespace VistaGL.Configurations {
    export namespace AccCostCentreDepreciationOpeningBalanceService {
        export const baseUrl = 'Configurations/AccCostCentreDepreciationOpeningBalance';

        export declare function Create(request: Serenity.SaveRequest<AccCostCentreDepreciationOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccCostCentreDepreciationOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCostCentreDepreciationOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCostCentreDepreciationOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccCostCentreDepreciationOpeningBalance/Create",
            Update = "Configurations/AccCostCentreDepreciationOpeningBalance/Update",
            Delete = "Configurations/AccCostCentreDepreciationOpeningBalance/Delete",
            Retrieve = "Configurations/AccCostCentreDepreciationOpeningBalance/Retrieve",
            List = "Configurations/AccCostCentreDepreciationOpeningBalance/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccCostCentreDepreciationOpeningBalanceService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

