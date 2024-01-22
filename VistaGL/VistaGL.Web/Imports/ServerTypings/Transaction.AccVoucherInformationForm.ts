namespace VistaGL.Transaction {
    export interface AccVoucherInformationForm {
        ApproverId: GetRecommenderInfoByApplicantVoucherEditor;
        approveStatus: Serenity.EnumEditor;
        Id: Serenity.StringEditor;
        VoucherTypeId: Serenity.LookupEditor;
        PostingFinancialYearId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        VoucherDate: Serenity.DateEditor;
        VoucherNo: Serenity.StringEditor;
        PaytoOrReciveFrom: _Ext.AutoCompleteEditor;
        NOAId: Serenity.LookupEditor;
        NOAId2: Serenity.IntegerEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        LinkedWithAutoJV: Serenity.BooleanEditor;
        LinkedPaymentVoucherNo: Serenity.StringEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        AccountHead: Serenity.LookupEditor;
        CostCenterTypeId: Serenity.LookupEditor;
        ParentId: Serenity.LookupEditor;
        CostCentreId: Serenity.LookupEditor;
        MultipleCostCenter: Serenity.BooleanEditor;
        MultiCurrency: Serenity.StringEditor;
        DebitAmount: Serenity.DecimalEditor;
        CreditAmount: Serenity.DecimalEditor;
        DDescription: Serenity.StringEditor;
        AdjustedChequeRegisterId: Serenity.LookupEditor;
        AddtoGrid: Serenity.StringEditor;
        VoucherDetails: AccVoucherDetailsEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        ProjectID: Serenity.LookupEditor;
        Description: Serenity.TextAreaEditor;
        PostedBy: Serenity.StringEditor;
        PostingDate: Serenity.DateEditor;
        EmpId: Serenity.IntegerEditor;
        TemplateStatus: Serenity.IntegerEditor;
        TemplateId: Serenity.IntegerEditor;
        TemplateCOAId: Serenity.IntegerEditor;
        TemplateChequeRegisterId: Serenity.IntegerEditor;
        RemainAmount: Serenity.DecimalEditor;
        TemplateCOAId2: Serenity.DecimalEditor;
        FileName: Serenity.MultipleImageUploadEditor;
        ConversionRate: Serenity.DecimalEditor;
        ConversionAmount: Serenity.DecimalEditor;
        FileNo: Serenity.StringEditor;
        PageNo: Serenity.StringEditor;
        ApplicationInformationHistory: VoucherApprovalHistoryEditor;
    }

    export class AccVoucherInformationForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherInformation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherInformationForm.init)  {
                AccVoucherInformationForm.init = true;

                var s = Serenity;
                var w0 = GetRecommenderInfoByApplicantVoucherEditor;
                var w1 = s.EnumEditor;
                var w2 = s.StringEditor;
                var w3 = s.LookupEditor;
                var w4 = COAMappingEditor;
                var w5 = s.DateEditor;
                var w6 = _Ext.AutoCompleteEditor;
                var w7 = s.IntegerEditor;
                var w8 = s.BooleanEditor;
                var w9 = s.DecimalEditor;
                var w10 = AccVoucherDetailsEditor;
                var w11 = s.TextAreaEditor;
                var w12 = s.MultipleImageUploadEditor;
                var w13 = VoucherApprovalHistoryEditor;

                Q.initFormType(AccVoucherInformationForm, [
                    'ApproverId', w0,
                    'approveStatus', w1,
                    'Id', w2,
                    'VoucherTypeId', w3,
                    'PostingFinancialYearId', w3,
                    'TransactionTypeEntityId', w3,
                    'TransactionMode', w4,
                    'VoucherDate', w5,
                    'VoucherNo', w2,
                    'PaytoOrReciveFrom', w6,
                    'NOAId', w3,
                    'NOAId2', w7,
                    'ChequeRegisterId', w3,
                    'LinkedWithAutoJV', w8,
                    'LinkedPaymentVoucherNo', w2,
                    'TransactionType', w2,
                    'VoucherType', w2,
                    'VoucherNumber', w2,
                    'AccountHead', w3,
                    'CostCenterTypeId', w3,
                    'ParentId', w3,
                    'CostCentreId', w3,
                    'MultipleCostCenter', w8,
                    'MultiCurrency', w2,
                    'DebitAmount', w9,
                    'CreditAmount', w9,
                    'DDescription', w2,
                    'AdjustedChequeRegisterId', w3,
                    'AddtoGrid', w2,
                    'VoucherDetails', w10,
                    'DAmount', w9,
                    'CAmount', w9,
                    'AmountInWords', w2,
                    'Amount', w9,
                    'ProjectID', w3,
                    'Description', w11,
                    'PostedBy', w2,
                    'PostingDate', w5,
                    'EmpId', w7,
                    'TemplateStatus', w7,
                    'TemplateId', w7,
                    'TemplateCOAId', w7,
                    'TemplateChequeRegisterId', w7,
                    'RemainAmount', w9,
                    'TemplateCOAId2', w9,
                    'FileName', w12,
                    'ConversionRate', w9,
                    'ConversionAmount', w9,
                    'FileNo', w2,
                    'PageNo', w2,
                    'ApplicationInformationHistory', w13
                ]);
            }
        }
    }
}

