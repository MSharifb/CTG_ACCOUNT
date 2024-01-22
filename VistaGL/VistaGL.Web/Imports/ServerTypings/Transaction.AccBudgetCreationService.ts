namespace VistaGL.Transaction {
    export namespace AccBudgetCreationService {
        export const baseUrl = 'Transaction/AccBudgetCreation';

        export declare function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetFinancialYearName(request: Transaction.Repositories.FinancialYearNamesListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.FinancialYearNames>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetBudgetApproverList(request: Transaction.Repositories.BudgetApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.BudgetApproverList>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccBudgetCreation/Create",
            Update = "Transaction/AccBudgetCreation/Update",
            Delete = "Transaction/AccBudgetCreation/Delete",
            Retrieve = "Transaction/AccBudgetCreation/Retrieve",
            List = "Transaction/AccBudgetCreation/List",
            GetFinancialYearName = "Transaction/AccBudgetCreation/GetFinancialYearName",
            GetBudgetApproverList = "Transaction/AccBudgetCreation/GetBudgetApproverList"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetFinancialYearName', 
            'GetBudgetApproverList'
        ].forEach(x => {
            (<any>AccBudgetCreationService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

