namespace VistaGL.Transaction {
    export interface AccVoucherTemplateForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        TemplateName: Serenity.StringEditor;
        CoaDebitHeadId: Serenity.LookupEditor;
        IsDebitHeadCheque: Serenity.BooleanEditor;
        CoaCreditHeadId: Serenity.LookupEditor;
        IsCreditHeadCheque: Serenity.BooleanEditor;
        IsBillReference: Serenity.BooleanEditor;
        IsCostCenter: Serenity.BooleanEditor;
        IsSd: Serenity.BooleanEditor;
        CoaSdId: Serenity.LookupEditor;
        SdType: VoucherTemplateDrCrMappingEditor;
        SdRate: Serenity.DecimalEditor;
        IsVat: Serenity.BooleanEditor;
        CoaVatId: Serenity.LookupEditor;
        VatType: VoucherTemplateDrCrMappingEditor;
        VatRate: Serenity.DecimalEditor;
        IsTax: Serenity.BooleanEditor;
        CoaTaxId: Serenity.LookupEditor;
        TaxType: VoucherTemplateDrCrMappingEditor;
        TaxRate: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class AccVoucherTemplateForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherTemplate';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherTemplateForm.init)  {
                AccVoucherTemplateForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = COAMappingEditor;
                var w2 = s.StringEditor;
                var w3 = s.BooleanEditor;
                var w4 = VoucherTemplateDrCrMappingEditor;
                var w5 = s.DecimalEditor;
                var w6 = s.TextAreaEditor;

                Q.initFormType(AccVoucherTemplateForm, [
                    'VoucherTypeId', w0,
                    'TransactionTypeId', w0,
                    'TransactionMode', w1,
                    'TemplateName', w2,
                    'CoaDebitHeadId', w0,
                    'IsDebitHeadCheque', w3,
                    'CoaCreditHeadId', w0,
                    'IsCreditHeadCheque', w3,
                    'IsBillReference', w3,
                    'IsCostCenter', w3,
                    'IsSd', w3,
                    'CoaSdId', w0,
                    'SdType', w4,
                    'SdRate', w5,
                    'IsVat', w3,
                    'CoaVatId', w0,
                    'VatType', w4,
                    'VatRate', w5,
                    'IsTax', w3,
                    'CoaTaxId', w0,
                    'TaxType', w4,
                    'TaxRate', w5,
                    'Remarks', w6
                ]);
            }
        }
    }
}

