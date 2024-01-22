namespace VistaGL.Configurations {
    export interface AccUnitTypeRow {
        Id?: number;
        UnitName?: string;
        Remarks?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccUnitTypeRow {
        export const idProperty = 'Id';
        export const nameProperty = 'UnitName';
        export const localTextPrefix = 'Configurations.AccUnitType';
        export const lookupKey = 'Configurations.AccUnitType';

        export function getLookup(): Q.Lookup<AccUnitTypeRow> {
            return Q.getLookup<AccUnitTypeRow>('Configurations.AccUnitType');
        }

        export declare const enum Fields {
            Id = "Id",
            UnitName = "UnitName",
            Remarks = "Remarks",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

