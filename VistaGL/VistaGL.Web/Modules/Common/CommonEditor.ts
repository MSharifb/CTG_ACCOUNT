namespace VistaGL {

    @Serenity.Decorators.registerEditor()
    export class ReconciliationEditor extends Serenity.Select2Editor<any, any> {

        constructor(hidden: JQuery) {
            super(hidden, null);
            this.addItem({ id: '0', text: 'Not Reconciled' });
            this.addItem({ id: '1', text: 'Reconciled' });

        }
    }

    @Serenity.Decorators.registerEditor()
    export class COAMappingEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

            this.addOption("BANK", "Bank");
            this.addOption("CASH", "Cash");
            this.addOption("Other", "Other");
        }
    }

    @Serenity.Decorators.registerEditor()
    export class ChequeTypeMappingEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            // add option accepts a key (id) value and display text value
            this.addOption("AccountPayee", "Account Payee");
            this.addOption("CashCheque", "Cash Cheque");
        }
    }

    @Serenity.Decorators.registerEditor()
    export class RecChequeTypeMappingEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            // add option accepts a key (id) value and display text value
            this.addOption("Cheque", "Cheque");
            this.addOption("Cash", "Cash");
            this.addOption("DD", "DD");
            this.addOption("PO", "PO");
        }
    }

    @Serenity.Decorators.registerEditor()
    export class VoucherTemplateDrCrMappingEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            // add option accepts a key (id) value and display text value
            this.addOption("Dr", "Dr");
            this.addOption("Cr", "Cr");
        }
    }

    @Serenity.Decorators.registerEditor()
    export class TemplateNameEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            var items = Transaction.AccVoucherTemplateRow.getLookup().items;//.filter((v, i, a) => a.indexOf(v) === i);
            for (var str of items) {
                this.addOption(str.TemplateName, str.TemplateName);
            }
        }
    }


    //@Serenity.Decorators.registerEditor()
    //export class VoucherTemplateCostCenterMappingEditor extends Serenity.Select2Editor<any, any> {

    //    constructor(container: JQuery) {
    //        super(container, null);
    //        var items = Transaction.AccCostCentreOrInstituteInformationRow.getLookup().items;//.filter((v, i, a) => a.indexOf(v) === i);

    //        for (var item of items) {
    //            this.addItem({ id: item.Id.toString(), text: item.Name, source: null, disabled: false });
    //        }
    //    }
    //}

    //@Serenity.Decorators.registerEditor()
    //export class VoucherTemplateChequNoEditor extends Serenity.Select2Editor<any, any> {

    //    constructor(container: JQuery) {
    //        super(container, null);
    //        var items = Transaction.AccChequeRegisterRow.getLookup().items;//.filter((v, i, a) => a.indexOf(v) === i);
    //        for (var item of items) {
    //            this.addItem({ id: item.Id.toString(), text: item.ChequeNo, source: null, disabled: false });
    //        }
    //    }
    //}

    @Serenity.Decorators.registerEditor()
    export class BudgetTypeEditorDDL extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            // add option accepts a key (id) value and display text value
            this.addOption("Proposed", "Proposed");
            this.addOption("Revised", "Revised");
            this.addOption("Approved", "Approved");
        }
    }

    @Serenity.Decorators.registerEditor()
    export class BillTypeEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            // add option accepts a key (id) value and display text value
            this.addOption("New", "New");
            this.addOption("Advance", "Advance");
            this.addOption("Against", "Against");
        }
    }


    @Serenity.Decorators.registerEditor()
    export class BRTransactionTypeEditorDDL extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

            // add option accepts a key (id) value and display text value
            this.addOption("PAYMENT", "PAYMENT");
            this.addOption("RECEIVE", "RECEIVE");

        }
    }


    //@Serenity.Decorators.registerEditor()
    //export class GetApproverInfoByApplicantEditor extends Serenity.Select2Editor<any, any> {

    //    constructor(container: JQuery) {
    //        super(container, null);

    //        Transaction.AccBudgetSubmissionService.GetApproverInfoByApplicant({}, r => {

    //            var items = r.Entities;

    //            for (var str of items) {
    //                this.addOption(str.Id.toString(), str.FullName);
    //            }
    //        });


    //    }
    //}

    //@Serenity.Decorators.registerEditor()
    //export class GetApproverInfoByApplicantHQEditor extends Serenity.Select2Editor<any, any> {

    //    constructor(container: JQuery) {
    //        super(container, null);

    //        Transaction.AccBudgetHqMasterService.GetApproverInfoByApplicant({}, r => {

    //            var items = r.Entities;

    //            for (var str of items) {
    //                this.addOption(str.Id.toString(), str.FullName);
    //            }
    //        });


    //    }
    //}

    @Serenity.Decorators.registerEditor()
    export class GetRecommenderInfoByApplicantVoucherEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

            // ApprovalStepTypeId: 2 - recommender only
            // ApprovalStepTypeId: 1 - approver only
            // ApprovalStepTypeId: 0 - both
            Transaction.AccVoucherInformationService.GetApproverInfoByApplicant({ ApprovalStepTypeId: 0 }, r => {

                var items = r.Entities;

                for (var str of items) {
                    this.addOption(str.Id.toString(), str.FullName);
                }
            });


        }
    }

    @Serenity.Decorators.registerEditor()
    export class GetApproverInfoByApplicantVoucherEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

            // ApprovalStepTypeId: 2 - recommender only
            // ApprovalStepTypeId: 1 - approver only
            // ApprovalStepTypeId: 0 - both
            Transaction.AccVoucherInformationService.GetApproverInfoByApplicant({ ApprovalStepTypeId: 1 }, r => {

                var items = r.Entities;

                for (var str of items) {
                    this.addOption(str.Id.toString(), str.FullName);
                }
            });


        }
    }

    //@Serenity.Decorators.registerEditor()
    //export class GetApproverInfoByApplicantZoneEditor extends Serenity.Select2Editor<any, any> {

    //    constructor(container: JQuery) {
    //        super(container, null);

    //        Transaction.AccBudgetZoneMasterService.GetApproverInfoByApplicant({}, r => {

    //            var items = r.Entities;

    //            for (var str of items) {
    //                this.addOption(str.Id.toString(), str.FullName);
    //            }
    //        });


    //    }
    //}


    @Serenity.Decorators.registerEditor()
    export class ChequeBookEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

            // add option accepts a key (id) value and display text value
            //this.addOption("1", "1");
            //this.addOption("2", "2");
            //this.addOption("3", "3");
            //// you may also use addItem which accepts a Select2Item parameter
            //this.addItem({
            //    id: "key3",
            //    text: "Text 3"
            //});

            //// don't let selecting this one (disabled)
            //this.addItem({
            //    id: "key4",
            //    text: "Text 4",
            //    disabled: true
            //});
        }
    }


    @Serenity.Decorators.registerEditor()
    export class TrueFalseEditor extends Serenity.Select2Editor<Serenity.SelectEditorOptions, Serenity.Select2Item> {

        constructor(hidden: JQuery, opt: Serenity.SelectEditorOptions) {
            super(hidden, opt);

            super.addItem({ id: "true", text: "Yes", disabled: false, source: "common" });
            super.addItem({ id: "false", text: "No", disabled: false, source: "common" });
        }
    }

    @Serenity.Decorators.registerEditor()
    export class DebitCreditEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery) {
            super(container, null);

            this.addOption("Debit", "Debit");
            this.addOption("Credit", "Credit");
        }
    }

    @Serenity.Decorators.registerEditor()
    export class ApprovalStatusEditor extends Serenity.Select2Editor<Serenity.SelectEditorOptions, Serenity.Select2Item> {

        constructor(hidden: JQuery, opt: Serenity.SelectEditorOptions) {
            super(hidden, opt);

            super.addItem({ id: "1", text: "Draft", disabled: false, source: "common" });
            super.addItem({ id: "2", text: "Cancel", disabled: false, source: "common" });
            super.addItem({ id: "3", text: "Submit", disabled: false, source: "common" });
            super.addItem({ id: "4", text: "Regret", disabled: false, source: "common" });
            super.addItem({ id: "5", text: "Recommend", disabled: false, source: "common" });
            super.addItem({ id: "6", text: "Approved", disabled: false, source: "common" });
        }
    }


    @Serenity.Decorators.registerEditor()
    export class AccHeadTypeMappingEditor extends Serenity.Select2Editor<any, any> {
        constructor(hidden: JQuery) {
            super(hidden, null);

            this.addItem({ id: '1', text: 'S.D.' });
            this.addItem({ id: '2', text: 'I.TAX' });
            this.addItem({ id: '3', text: 'VAT' });
            this.addItem({ id: '4', text: 'ADVANCE' });
            this.addItem({ id: '5', text: 'WIP' });

        }
    }

    @Serenity.Decorators.registerEditor()
    export class FinancialReportEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            this.addOption("AR", "ACCOUNTS  RECEIVABLE");
            this.addOption("ADO", "Advance, Deposits & Others");
            this.addOption("LOF", "LIABILITIES FOR OTHER FINANCE");
        }
    }
}