namespace VistaGL.Transaction {
    export interface VoucherApprovalForm {
        approveStatus: Serenity.EnumEditor;
        ApproverId: GetApproverInfoByApplicantVoucherEditor;
        postingSendTo: Serenity.LookupEditor;
        RegretSendTo: Serenity.LookupEditor;
        ApprovalAction: Serenity.StringEditor;
        ApprovalComments: Serenity.TextAreaEditor;
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        VoucherDate: Serenity.DateEditor;
        TransactionMode: COAMappingEditor;
        VoucherNo: Serenity.StringEditor;
        PaytoOrReciveFrom: Serenity.StringEditor;
        ChequeRegisterChequeNo: Serenity.IntegerEditor;
        ChequeRegisterChequeDate: Serenity.DateEditor;
        AutoJVVoucherNo: Serenity.StringEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        VoucherDetails: AccVoucherDetailsEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        PostedBy: Serenity.StringEditor;
        PostingDate: Serenity.DateEditor;
        PostToLedger: Serenity.IntegerEditor;
        EmpId: Serenity.IntegerEditor;
        FileName: Serenity.MultipleImageUploadEditor;
        ApplicationInformationHistory: VoucherApprovalHistoryEditor;
    }

    export class VoucherApprovalForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.VoucherApproval';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VoucherApprovalForm.init)  {
                VoucherApprovalForm.init = true;

                var s = Serenity;
                var w0 = s.EnumEditor;
                var w1 = GetApproverInfoByApplicantVoucherEditor;
                var w2 = s.LookupEditor;
                var w3 = s.StringEditor;
                var w4 = s.TextAreaEditor;
                var w5 = s.DateEditor;
                var w6 = COAMappingEditor;
                var w7 = s.IntegerEditor;
                var w8 = AccVoucherDetailsEditor;
                var w9 = s.DecimalEditor;
                var w10 = s.MultipleImageUploadEditor;
                var w11 = VoucherApprovalHistoryEditor;

                Q.initFormType(VoucherApprovalForm, [
                    'approveStatus', w0,
                    'ApproverId', w1,
                    'postingSendTo', w2,
                    'RegretSendTo', w2,
                    'ApprovalAction', w3,
                    'ApprovalComments', w4,
                    'VoucherTypeId', w2,
                    'TransactionTypeEntityId', w2,
                    'VoucherDate', w5,
                    'TransactionMode', w6,
                    'VoucherNo', w3,
                    'PaytoOrReciveFrom', w3,
                    'ChequeRegisterChequeNo', w7,
                    'ChequeRegisterChequeDate', w5,
                    'AutoJVVoucherNo', w3,
                    'TransactionType', w3,
                    'VoucherType', w3,
                    'VoucherNumber', w3,
                    'VoucherDetails', w8,
                    'DAmount', w9,
                    'CAmount', w9,
                    'Amount', w9,
                    'AmountInWords', w3,
                    'Description', w4,
                    'PostedBy', w3,
                    'PostingDate', w5,
                    'PostToLedger', w7,
                    'EmpId', w7,
                    'FileName', w10,
                    'ApplicationInformationHistory', w11
                ]);
            }
        }
    }
}

