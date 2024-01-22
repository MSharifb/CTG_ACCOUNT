namespace VistaGL.Configurations {
    export interface AccBankAdviceLetterTemplateRow {
        Id?: number;
        Subject?: string;
        Body1?: string;
        Body2?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccBankAdviceLetterTemplateRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Subject';
        export const localTextPrefix = 'Configurations.AccBankAdviceLetterTemplate';
        export const lookupKey = 'Configurations.AccBankAdviceLetterTemplate';

        export function getLookup(): Q.Lookup<AccBankAdviceLetterTemplateRow> {
            return Q.getLookup<AccBankAdviceLetterTemplateRow>('Configurations.AccBankAdviceLetterTemplate');
        }

        export declare const enum Fields {
            Id = "Id",
            Subject = "Subject",
            Body1 = "Body1",
            Body2 = "Body2",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

