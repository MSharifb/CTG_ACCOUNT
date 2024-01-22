namespace VistaGL.Transaction {
    export namespace AccCostCentreOrInstituteInformationService {
        export const baseUrl = 'Transaction/AccCostCentreOrInstituteInformation';

        export declare function Create(request: Serenity.SaveRequest<AccCostCentreOrInstituteInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccCostCentreOrInstituteInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCostCentreOrInstituteInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCostCentreOrInstituteInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Transaction/AccCostCentreOrInstituteInformation/Create",
            Update = "Transaction/AccCostCentreOrInstituteInformation/Update",
            Delete = "Transaction/AccCostCentreOrInstituteInformation/Delete",
            Retrieve = "Transaction/AccCostCentreOrInstituteInformation/Retrieve",
            List = "Transaction/AccCostCentreOrInstituteInformation/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccCostCentreOrInstituteInformationService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

