namespace VistaGL.Transaction {
    export interface AccVoucherBankWiseForm {
        ApproverId: GetRecommenderInfoByApplicantVoucherEditor;
        approveStatus: Serenity.EnumEditor;
        IsBankWisePaymentVoucher: Serenity.BooleanEditor;
        IsBankWiseReceiptVoucher: Serenity.BooleanEditor;
        Id: Serenity.StringEditor;
        VoucherTypeId: Serenity.LookupEditor;
        TransactionMode: Serenity.StringEditor;
        PostingFinancialYearId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        VoucherDate: Serenity.DateEditor;
        VoucherNo: Serenity.StringEditor;
        AccountHeadBankCash: Serenity.LookupEditor;
        BankAccountInformationId: Serenity.LookupEditor;
        ChequeBookId: Serenity.LookupEditor;
        ChequeNumhdn: ChequeBookEditor;
        ChequeNo: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        ChequeType: ChequeTypeMappingEditor;
        ChequeRemarks: Serenity.StringEditor;
        PaytoOrReciveFrom: _Ext.AutoCompleteEditor;
        IsChequeFinished: Serenity.BooleanEditor;
        BankAmount: Serenity.DecimalEditor;
        PaytoForBankAdvice: Serenity.StringEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        PowerofAttorney: Serenity.StringEditor;
        NOAId: Serenity.LookupEditor;
        NOAId2: Serenity.IntegerEditor;
        LinkedWithAutoJV: Serenity.BooleanEditor;
        AutoPV_AccountHead: Serenity.LookupEditor;
        AutoBudgetAmountCOA: Serenity.DecimalEditor;
        AutoPV_CostCentreId: Serenity.LookupEditor;
        AutoBudgetAmountSUbledger: Serenity.DecimalEditor;
        AutoJVVoucherNo: Serenity.StringEditor;
        AutoJVVoucherNumber: Serenity.StringEditor;
        TransactionTypeEntityIdForAutoJV: Serenity.IntegerEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        AccountHead: Serenity.LookupEditor;
        BudgetAmountCOA: Serenity.DecimalEditor;
        CostCenterTypeId: Serenity.LookupEditor;
        ParentId: Serenity.LookupEditor;
        CostCentreId: Serenity.LookupEditor;
        BudgetAmountSUbledger: Serenity.DecimalEditor;
        MultipleCostCenter: Serenity.BooleanEditor;
        DebitAmount: Serenity.DecimalEditor;
        CreditAmount: Serenity.DecimalEditor;
        CalculationRate: Serenity.DecimalEditor;
        CalculationAmount: Serenity.DecimalEditor;
        Type: VoucherTemplateDrCrMappingEditor;
        DDescription: Serenity.StringEditor;
        AddtoGrid: Serenity.StringEditor;
        VoucherDetails: AccVoucherDetailsEditor;
        AccountBankCash: Serenity.StringEditor;
        AccountBankCashAmount: Serenity.DecimalEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        ProjectID: Serenity.LookupEditor;
        ClearDate: Serenity.DateEditor;
        IsClearDate: Serenity.IntegerEditor;
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
        MultiCurrency: Serenity.StringEditor;
        ApplicationInformationHistory: VoucherApprovalHistoryEditor;
    }

    export class AccVoucherBankWiseForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherBankWise';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherBankWiseForm.init)  {
                AccVoucherBankWiseForm.init = true;

                var s = Serenity;
                var w0 = GetRecommenderInfoByApplicantVoucherEditor;
                var w1 = s.EnumEditor;
                var w2 = s.BooleanEditor;
                var w3 = s.StringEditor;
                var w4 = s.LookupEditor;
                var w5 = s.DateEditor;
                var w6 = ChequeBookEditor;
                var w7 = ChequeTypeMappingEditor;
                var w8 = _Ext.AutoCompleteEditor;
                var w9 = s.DecimalEditor;
                var w10 = s.IntegerEditor;
                var w11 = VoucherTemplateDrCrMappingEditor;
                var w12 = AccVoucherDetailsEditor;
                var w13 = s.TextAreaEditor;
                var w14 = s.MultipleImageUploadEditor;
                var w15 = VoucherApprovalHistoryEditor;

                Q.initFormType(AccVoucherBankWiseForm, [
                    'ApproverId', w0,
                    'approveStatus', w1,
                    'IsBankWisePaymentVoucher', w2,
                    'IsBankWiseReceiptVoucher', w2,
                    'Id', w3,
                    'VoucherTypeId', w4,
                    'TransactionMode', w3,
                    'PostingFinancialYearId', w4,
                    'TransactionTypeEntityId', w4,
                    'VoucherDate', w5,
                    'VoucherNo', w3,
                    'AccountHeadBankCash', w4,
                    'BankAccountInformationId', w4,
                    'ChequeBookId', w4,
                    'ChequeNumhdn', w6,
                    'ChequeNo', w3,
                    'ChequeDate', w5,
                    'ChequeType', w7,
                    'ChequeRemarks', w3,
                    'PaytoOrReciveFrom', w8,
                    'IsChequeFinished', w2,
                    'BankAmount', w9,
                    'PaytoForBankAdvice', w3,
                    'ChequeRegisterId', w4,
                    'PowerofAttorney', w3,
                    'NOAId', w4,
                    'NOAId2', w10,
                    'LinkedWithAutoJV', w2,
                    'AutoPV_AccountHead', w4,
                    'AutoBudgetAmountCOA', w9,
                    'AutoPV_CostCentreId', w4,
                    'AutoBudgetAmountSUbledger', w9,
                    'AutoJVVoucherNo', w3,
                    'AutoJVVoucherNumber', w3,
                    'TransactionTypeEntityIdForAutoJV', w10,
                    'TransactionType', w3,
                    'VoucherType', w3,
                    'VoucherNumber', w3,
                    'AccountHead', w4,
                    'BudgetAmountCOA', w9,
                    'CostCenterTypeId', w4,
                    'ParentId', w4,
                    'CostCentreId', w4,
                    'BudgetAmountSUbledger', w9,
                    'MultipleCostCenter', w2,
                    'DebitAmount', w9,
                    'CreditAmount', w9,
                    'CalculationRate', w9,
                    'CalculationAmount', w9,
                    'Type', w11,
                    'DDescription', w3,
                    'AddtoGrid', w3,
                    'VoucherDetails', w12,
                    'AccountBankCash', w3,
                    'AccountBankCashAmount', w9,
                    'DAmount', w9,
                    'CAmount', w9,
                    'AmountInWords', w3,
                    'Amount', w9,
                    'ProjectID', w4,
                    'ClearDate', w5,
                    'IsClearDate', w10,
                    'Description', w13,
                    'PostedBy', w3,
                    'PostingDate', w5,
                    'EmpId', w10,
                    'TemplateStatus', w10,
                    'TemplateId', w10,
                    'TemplateCOAId', w10,
                    'TemplateChequeRegisterId', w10,
                    'RemainAmount', w9,
                    'TemplateCOAId2', w9,
                    'FileName', w14,
                    'ConversionRate', w9,
                    'ConversionAmount', w9,
                    'FileNo', w3,
                    'PageNo', w3,
                    'MultiCurrency', w3,
                    'ApplicationInformationHistory', w15
                ]);
            }
        }
    }
}

