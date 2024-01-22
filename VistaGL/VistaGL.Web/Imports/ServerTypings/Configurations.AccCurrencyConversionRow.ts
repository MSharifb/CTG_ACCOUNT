namespace VistaGL.Configurations {
    export interface AccCurrencyConversionRow {
        Id?: number;
        Currency?: string;
        Remarks?: string;
        Symbol?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccCurrencyConversionRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Currency';
        export const localTextPrefix = 'Configurations.AccCurrencyConversion';
        export const lookupKey = 'Configurations.AccCurrencyConversion';

        export function getLookup(): Q.Lookup<AccCurrencyConversionRow> {
            return Q.getLookup<AccCurrencyConversionRow>('Configurations.AccCurrencyConversion');
        }

        export declare const enum Fields {
            Id = "Id",
            Currency = "Currency",
            Remarks = "Remarks",
            Symbol = "Symbol",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

