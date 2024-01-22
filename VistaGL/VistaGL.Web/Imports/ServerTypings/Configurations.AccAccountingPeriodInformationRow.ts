namespace VistaGL.Configurations {
    export interface AccAccountingPeriodInformationRow {
        Id?: number;
        IsActive?: boolean;
        IsClosed?: boolean;
        PeriodEndDate?: string;
        PeriodStartDate?: string;
        YearName?: string;
        FundControlInformationId?: number;
        FundControlInformationCode?: string;
        FundControlInformationFundControlName?: string;
        FundControlInformationRemarks?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }

    export namespace AccAccountingPeriodInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'YearName';
        export const localTextPrefix = 'Configurations.AccAccountingPeriodInformation';
        export const lookupKey = 'Configurations.AccAccountingPeriodInformation';

        export function getLookup(): Q.Lookup<AccAccountingPeriodInformationRow> {
            return Q.getLookup<AccAccountingPeriodInformationRow>('Configurations.AccAccountingPeriodInformation');
        }

        export declare const enum Fields {
            Id = "Id",
            IsActive = "IsActive",
            IsClosed = "IsClosed",
            PeriodEndDate = "PeriodEndDate",
            PeriodStartDate = "PeriodStartDate",
            YearName = "YearName",
            FundControlInformationId = "FundControlInformationId",
            FundControlInformationCode = "FundControlInformationCode",
            FundControlInformationFundControlName = "FundControlInformationFundControlName",
            FundControlInformationRemarks = "FundControlInformationRemarks",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName"
        }
    }
}

