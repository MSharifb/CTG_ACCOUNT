namespace VistaGL.Transaction {
    export interface ApvApplicationInformationRow {
        Id?: number;
        ModuleId?: number;
        ApprovalProcessId?: number;
        ApplicationId?: number;
        IsOnlineApplication?: boolean;
        ApprovalStepId?: number;
        ApproverId?: number;
        ApprovalStatusId?: number;
        ApproverComments?: string;
        IUser?: string;
        IDate?: string;
        EUser?: string;
        EDate?: string;
        ForwordBy?: string;
        Status?: string;
        EmploymentInfoFullName?: string;
        ApproverCode?: string;
    }

    export namespace ApvApplicationInformationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ApproverComments';
        export const localTextPrefix = 'Transaction.ApvApplicationInformation';

        export declare const enum Fields {
            Id = "Id",
            ModuleId = "ModuleId",
            ApprovalProcessId = "ApprovalProcessId",
            ApplicationId = "ApplicationId",
            IsOnlineApplication = "IsOnlineApplication",
            ApprovalStepId = "ApprovalStepId",
            ApproverId = "ApproverId",
            ApprovalStatusId = "ApprovalStatusId",
            ApproverComments = "ApproverComments",
            IUser = "IUser",
            IDate = "IDate",
            EUser = "EUser",
            EDate = "EDate",
            ForwordBy = "ForwordBy",
            Status = "Status",
            EmploymentInfoFullName = "EmploymentInfoFullName",
            ApproverCode = "ApproverCode"
        }
    }
}

