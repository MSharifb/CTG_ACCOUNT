namespace VistaGL {
    export interface GetNewVoucherNoRequest extends Serenity.ServiceRequest {
        TransactionTypeId?: number;
        FundControlInformationId?: number;
        VoucherDate?: string;
        ZoneId?: number;
        FinancialYearId?: number;
        BankAccId?: number;
    }
}

