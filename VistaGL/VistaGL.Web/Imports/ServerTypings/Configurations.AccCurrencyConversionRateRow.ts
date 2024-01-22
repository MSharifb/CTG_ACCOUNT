namespace VistaGL.Configurations {
    export interface AccCurrencyConversionRateRow {
        Id?: number;
        FirstCurrency?: number;
        SecondCurrency?: number;
        FirstAmout?: number;
        SecondAmout?: number;
        FirstCurrencyCurrency?: string;
        FirstCurrencyRemarks?: string;
        FirstCurrencySymbol?: string;
        SecondCurrencyCurrency?: string;
        SecondCurrencyRemarks?: string;
        SecondCurrencySymbol?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccCurrencyConversionRateRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Configurations.AccCurrencyConversionRate';
        export const lookupKey = 'Configurations.AccCurrencyConversionRate';

        export function getLookup(): Q.Lookup<AccCurrencyConversionRateRow> {
            return Q.getLookup<AccCurrencyConversionRateRow>('Configurations.AccCurrencyConversionRate');
        }

        export declare const enum Fields {
            Id = "Id",
            FirstCurrency = "FirstCurrency",
            SecondCurrency = "SecondCurrency",
            FirstAmout = "FirstAmout",
            SecondAmout = "SecondAmout",
            FirstCurrencyCurrency = "FirstCurrencyCurrency",
            FirstCurrencyRemarks = "FirstCurrencyRemarks",
            FirstCurrencySymbol = "FirstCurrencySymbol",
            SecondCurrencyCurrency = "SecondCurrencyCurrency",
            SecondCurrencyRemarks = "SecondCurrencyRemarks",
            SecondCurrencySymbol = "SecondCurrencySymbol",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

