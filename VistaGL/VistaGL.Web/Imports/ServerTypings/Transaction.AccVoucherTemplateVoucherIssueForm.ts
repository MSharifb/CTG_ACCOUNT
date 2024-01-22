namespace VistaGL.Transaction {
    export interface AccVoucherTemplateVoucherIssueForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        TemplateName: TemplateNameEditor;
        CoaDebitHeadId: Serenity.LookupEditor;
        IsDebitHeadCheque: Serenity.BooleanEditor;
        DebitHeadChequeId: Serenity.LookupEditor;
        CoaCreditHeadId: Serenity.LookupEditor;
        IsCreditHeadCheque: Serenity.BooleanEditor;
        CreditHeadChequeId: Serenity.LookupEditor;
        IsBillReference: Serenity.BooleanEditor;
        BillReferenceNo: Serenity.StringEditor;
        IsCostCenter: Serenity.BooleanEditor;
        CostCenterId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        VoucherDate: Serenity.DateEditor;
        Remarks: Serenity.TextAreaEditor;
        IsSd: Serenity.BooleanEditor;
        CoaSdId: Serenity.LookupEditor;
        SdType: VoucherTemplateDrCrMappingEditor;
        SdRate: Serenity.DecimalEditor;
        SdAmount: Serenity.DecimalEditor;
        IsVat: Serenity.BooleanEditor;
        CoaVatId: Serenity.LookupEditor;
        VatType: VoucherTemplateDrCrMappingEditor;
        VatRate: Serenity.DecimalEditor;
        VatAmount: Serenity.DecimalEditor;
        IsTax: Serenity.BooleanEditor;
        CoaTaxId: Serenity.LookupEditor;
        TaxType: VoucherTemplateDrCrMappingEditor;
        TaxRate: Serenity.DecimalEditor;
        TaxAmount: Serenity.DecimalEditor;
    }

    export class AccVoucherTemplateVoucherIssueForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherTemplateVoucherIssue';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherTemplateVoucherIssueForm.init)  {
                AccVoucherTemplateVoucherIssueForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = COAMappingEditor;
                var w2 = TemplateNameEditor;
                var w3 = s.BooleanEditor;
                var w4 = s.StringEditor;
                var w5 = s.DecimalEditor;
                var w6 = s.DateEditor;
                var w7 = s.TextAreaEditor;
                var w8 = VoucherTemplateDrCrMappingEditor;

                Q.initFormType(AccVoucherTemplateVoucherIssueForm, [
                    'VoucherTypeId', w0,
                    'TransactionTypeId', w0,
                    'TransactionMode', w1,
                    'TemplateName', w2,
                    'CoaDebitHeadId', w0,
                    'IsDebitHeadCheque', w3,
                    'DebitHeadChequeId', w0,
                    'CoaCreditHeadId', w0,
                    'IsCreditHeadCheque', w3,
                    'CreditHeadChequeId', w0,
                    'IsBillReference', w3,
                    'BillReferenceNo', w4,
                    'IsCostCenter', w3,
                    'CostCenterId', w0,
                    'Amount', w5,
                    'VoucherDate', w6,
                    'Remarks', w7,
                    'IsSd', w3,
                    'CoaSdId', w0,
                    'SdType', w8,
                    'SdRate', w5,
                    'SdAmount', w5,
                    'IsVat', w3,
                    'CoaVatId', w0,
                    'VatType', w8,
                    'VatRate', w5,
                    'VatAmount', w5,
                    'IsTax', w3,
                    'CoaTaxId', w0,
                    'TaxType', w8,
                    'TaxRate', w5,
                    'TaxAmount', w5
                ]);
            }
        }
    }
}

