namespace VistaGL.Configurations {
    export namespace AccChartofAccountsService {
        export const baseUrl = 'Configurations/AccChartofAccounts';

        export declare function Create(request: Serenity.SaveRequest<AccChartofAccountsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccChartofAccountsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChartofAccountsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChartofAccountsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function SaveCoAList(request: SaveCoAListRequest, onSuccess?: (response: SaveCoAListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccChartofAccounts/Create",
            Update = "Configurations/AccChartofAccounts/Update",
            Delete = "Configurations/AccChartofAccounts/Delete",
            Retrieve = "Configurations/AccChartofAccounts/Retrieve",
            List = "Configurations/AccChartofAccounts/List",
            SaveCoAList = "Configurations/AccChartofAccounts/SaveCoAList"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'SaveCoAList'
        ].forEach(x => {
            (<any>AccChartofAccountsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

