namespace VistaGL.Configurations {
    export namespace AccBankAdviceLetterTemplateService {
        export const baseUrl = 'Configurations/AccBankAdviceLetterTemplate';

        export declare function Create(request: Serenity.SaveRequest<AccBankAdviceLetterTemplateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<AccBankAdviceLetterTemplateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBankAdviceLetterTemplateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBankAdviceLetterTemplateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Configurations/AccBankAdviceLetterTemplate/Create",
            Update = "Configurations/AccBankAdviceLetterTemplate/Update",
            Delete = "Configurations/AccBankAdviceLetterTemplate/Delete",
            Retrieve = "Configurations/AccBankAdviceLetterTemplate/Retrieve",
            List = "Configurations/AccBankAdviceLetterTemplate/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>AccBankAdviceLetterTemplateService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

