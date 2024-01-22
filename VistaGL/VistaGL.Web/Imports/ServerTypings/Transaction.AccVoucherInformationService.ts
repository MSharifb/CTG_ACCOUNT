namespace VistaGL.Transaction {
    export namespace AccVoucherInformationService {
        export const baseUrl = 'Transaction/AccVoucherInformation';

        export declare function Create(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetNewVoucherNo(request: GetNewVoucherNoRequest, onSuccess?: (response: GetNewVoucherNoResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetApproverInfoByApplicant(request: GetApproverInfoByApplicantRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.AVP_InitialStep>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccVoucherInformation/Create",
            Update = "Transaction/AccVoucherInformation/Update",
            Delete = "Transaction/AccVoucherInformation/Delete",
            Retrieve = "Transaction/AccVoucherInformation/Retrieve",
            List = "Transaction/AccVoucherInformation/List",
            GetNewVoucherNo = "Transaction/AccVoucherInformation/GetNewVoucherNo",
            GetApproverInfoByApplicant = "Transaction/AccVoucherInformation/GetApproverInfoByApplicant"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetNewVoucherNo', 
            'GetApproverInfoByApplicant'
        ].forEach(x => {
            (<any>AccVoucherInformationService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

