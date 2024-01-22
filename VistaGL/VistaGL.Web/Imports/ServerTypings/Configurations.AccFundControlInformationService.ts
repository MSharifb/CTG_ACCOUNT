namespace VistaGL.Configurations {
    export namespace AccFundControlInformationService {
        export const baseUrl = 'Configurations/AccFundControlInformation';

        export declare function Create(request: Serenity.SaveRequest<AccFundControlInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccFundControlInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFundControlInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFundControlInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function SetFundControl(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFundControlInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccFundControlInformation/Create",
            Update = "Configurations/AccFundControlInformation/Update",
            Delete = "Configurations/AccFundControlInformation/Delete",
            Retrieve = "Configurations/AccFundControlInformation/Retrieve",
            List = "Configurations/AccFundControlInformation/List",
            SetFundControl = "Configurations/AccFundControlInformation/SetFundControl"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'SetFundControl'
        ].forEach(x => {
            (<any>AccFundControlInformationService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

