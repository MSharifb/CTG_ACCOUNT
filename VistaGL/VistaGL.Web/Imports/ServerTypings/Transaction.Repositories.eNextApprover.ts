namespace VistaGL.Transaction.Repositories {
    export interface eNextApprover {
        Id?: number;
        FullName?: string;
        ApproverTypeName?: string;
        NextStepId?: number;
        StepTypeId?: number;
        StepTypeName?: string;
        RequiredActionId?: number;
        ApplicationId?: number;
        ApplicantId?: number;
        CurrentRecommenderApproverId?: number;
        MinAmount?: number;
        MaxAmount?: number;
    }
}

