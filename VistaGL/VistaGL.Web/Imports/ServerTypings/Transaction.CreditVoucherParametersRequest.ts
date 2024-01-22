namespace VistaGL.Transaction {
    export interface CreditVoucherParametersRequest extends Serenity.ServiceRequest {
        MoneyReceiptIds?: number[];
        Narration?: string;
        VoucherDate?: string;
        ReceiveFrom?: string;
    }
}

