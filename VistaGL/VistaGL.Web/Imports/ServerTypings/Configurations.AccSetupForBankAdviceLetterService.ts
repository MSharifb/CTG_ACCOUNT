namespace VistaGL.Configurations {
    export namespace AccSetupForBankAdviceLetterService {
        export const baseUrl = 'Configurations/AccSetupForBankAdviceLetter';

        export declare function Create(request: Serenity.SaveRequest<AccSetupForBankAdviceLetterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccSetupForBankAdviceLetterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccSetupForBankAdviceLetterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccSetupForBankAdviceLetterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccSetupForBankAdviceLetter/Create",
            Update = "Configurations/AccSetupForBankAdviceLetter/Update",
            Delete = "Configurations/AccSetupForBankAdviceLetter/Delete",
            Retrieve = "Configurations/AccSetupForBankAdviceLetter/Retrieve",
            List = "Configurations/AccSetupForBankAdviceLetter/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccSetupForBankAdviceLetterService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

