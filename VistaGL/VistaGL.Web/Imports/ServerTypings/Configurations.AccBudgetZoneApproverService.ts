namespace VistaGL.Configurations {
    export namespace AccBudgetZoneApproverService {
        export const baseUrl = 'Configurations/AccBudgetZoneApprover';

        export declare function Create(request: Serenity.SaveRequest<AccBudgetZoneApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBudgetZoneApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetZoneApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetZoneApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccBudgetZoneApprover/Create",
            Update = "Configurations/AccBudgetZoneApprover/Update",
            Delete = "Configurations/AccBudgetZoneApprover/Delete",
            Retrieve = "Configurations/AccBudgetZoneApprover/Retrieve",
            List = "Configurations/AccBudgetZoneApprover/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccBudgetZoneApproverService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

