namespace VistaGL.Transaction {
    export namespace AccBudgetApprovalHistoryService {
        export const baseUrl = 'Transaction/AccBudgetApprovalHistory';

        export declare function Create(request: Serenity.SaveRequest<AccBudgetApprovalHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBudgetApprovalHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetApprovalHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetApprovalHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccBudgetApprovalHistory/Create",
            Update = "Transaction/AccBudgetApprovalHistory/Update",
            Delete = "Transaction/AccBudgetApprovalHistory/Delete",
            Retrieve = "Transaction/AccBudgetApprovalHistory/Retrieve",
            List = "Transaction/AccBudgetApprovalHistory/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccBudgetApprovalHistoryService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

