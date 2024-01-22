namespace VistaGL.Transaction {
    export interface AccIbcsJsondataHistoryRow {
        Id?: number;
        VoucherNo?: string;
        VoucherDate?: string;
        ZoneId?: number;
        FundControlId?: number;
        JsonData?: string;
        CreateDate?: string;
        IsSuccess?: boolean;
        ZoneInfoZoneName?: string;
        EntityName?: string;
    }

    export namespace AccIbcsJsondataHistoryRow {
        export const idProperty = 'Id';
        export const nameProperty = 'VoucherNo';
        export const localTextPrefix = 'Transaction.AccIbcsJsondataHistory';
        export const lookupKey = 'Transaction.AccIbcsJsondataHistoryRow';

        export function getLookup(): Q.Lookup<AccIbcsJsondataHistoryRow> {
            return Q.getLookup<AccIbcsJsondataHistoryRow>('Transaction.AccIbcsJsondataHistoryRow');
        }

        export declare const enum Fields {
            Id = "Id",
            VoucherNo = "VoucherNo",
            VoucherDate = "VoucherDate",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            JsonData = "JsonData",
            CreateDate = "CreateDate",
            IsSuccess = "IsSuccess",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            EntityName = "EntityName"
        }
    }
}

