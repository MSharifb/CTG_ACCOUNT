namespace VistaGL.Transaction.Repositories {
    export interface BudgetApproverListRequest extends Serenity.ListRequest {
        ZoneId?: number;
        DepartmentId?: number;
    }
}

