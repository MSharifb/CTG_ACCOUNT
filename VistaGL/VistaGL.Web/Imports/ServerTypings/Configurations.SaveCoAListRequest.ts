namespace VistaGL.Configurations {
    export interface SaveCoAListRequest extends Serenity.ServiceRequest {
        List?: Transaction.AccTransactionTypeAssignRow[];
    }
}

