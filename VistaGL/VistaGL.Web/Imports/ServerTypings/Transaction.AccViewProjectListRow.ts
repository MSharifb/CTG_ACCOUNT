namespace VistaGL.Transaction {
    export interface AccViewProjectListRow {
        Id?: number;
        NameOfWorks?: string;
        ZoneOrProjectId?: number;
    }

    export namespace AccViewProjectListRow {
        export const idProperty = 'Id';
        export const nameProperty = 'NameOfWorks';
        export const localTextPrefix = 'Transaction.AccViewProjectList';
        export const lookupKey = 'Transaction.AccViewProjectList';

        export function getLookup(): Q.Lookup<AccViewProjectListRow> {
            return Q.getLookup<AccViewProjectListRow>('Transaction.AccViewProjectList');
        }

        export declare const enum Fields {
            Id = "Id",
            NameOfWorks = "NameOfWorks",
            ZoneOrProjectId = "ZoneOrProjectId"
        }
    }
}

