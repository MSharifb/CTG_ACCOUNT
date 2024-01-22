namespace VistaGL.Transaction.Repositories {
    export interface GetNewMoneyReceiptNoRequest extends Serenity.ServiceRequest {
        FundControlId?: number;
        ZoneId?: number;
    }
}

