namespace VistaGL.Configurations {
    export namespace AccArDoubtfulDebtsService {
        export const baseUrl = 'Configurations/AccArDoubtfulDebts';

        export declare function Create(request: Serenity.SaveRequest<AccArDoubtfulDebtsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccArDoubtfulDebtsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccArDoubtfulDebtsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccArDoubtfulDebtsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccArDoubtfulDebts/Create",
            Update = "Configurations/AccArDoubtfulDebts/Update",
            Delete = "Configurations/AccArDoubtfulDebts/Delete",
            Retrieve = "Configurations/AccArDoubtfulDebts/Retrieve",
            List = "Configurations/AccArDoubtfulDebts/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccArDoubtfulDebtsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

