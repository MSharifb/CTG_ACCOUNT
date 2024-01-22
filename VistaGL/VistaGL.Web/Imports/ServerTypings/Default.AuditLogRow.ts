namespace VistaGL.Default {
    export interface AuditLogRow {
        Id?: number;
        UserId?: number;
        UserName?: string;
        Action?: string;
        ChangedOn?: string;
        DBTableName?: string;
        RowId?: number;
        Module?: string;
        Page?: string;
        Changes?: string;
    }

    export namespace AuditLogRow {
        export const idProperty = 'Id';
        export const nameProperty = 'UserName';
        export const localTextPrefix = 'Default.AuditLog';
        export const lookupKey = 'Default.AuditLog';

        export function getLookup(): Q.Lookup<AuditLogRow> {
            return Q.getLookup<AuditLogRow>('Default.AuditLog');
        }

        export declare const enum Fields {
            Id = "Id",
            UserId = "UserId",
            UserName = "UserName",
            Action = "Action",
            ChangedOn = "ChangedOn",
            DBTableName = "DBTableName",
            RowId = "RowId",
            Module = "Module",
            Page = "Page",
            Changes = "Changes"
        }
    }
}

