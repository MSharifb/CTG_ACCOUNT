namespace VistaGL.Transaction {
    export namespace VoucherApprovalService {
        export const baseUrl = 'Transaction/VoucherApproval';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function IsVoucherApprover(request: Serenity.ListRequest, onSuccess?: (response: CheckIsApproverResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetNextApprover(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetAmountByApprover(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetPostingSendTo(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetRegretList(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/VoucherApproval/Create",
            Update = "Transaction/VoucherApproval/Update",
            Delete = "Transaction/VoucherApproval/Delete",
            Retrieve = "Transaction/VoucherApproval/Retrieve",
            List = "Transaction/VoucherApproval/List",
            IsVoucherApprover = "Transaction/VoucherApproval/IsVoucherApprover",
            GetNextApprover = "Transaction/VoucherApproval/GetNextApprover",
            GetAmountByApprover = "Transaction/VoucherApproval/GetAmountByApprover",
            GetPostingSendTo = "Transaction/VoucherApproval/GetPostingSendTo",
            GetRegretList = "Transaction/VoucherApproval/GetRegretList"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'IsVoucherApprover', 
            'GetNextApprover', 
            'GetAmountByApprover', 
            'GetPostingSendTo', 
            'GetRegretList'
        ].forEach(x => {
            (<any>VoucherApprovalService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

