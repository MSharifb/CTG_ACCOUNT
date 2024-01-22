namespace VistaGL.Transaction {
    export interface AccVoucherDtlAllocationForm {
        CostCenterTypeId: Serenity.LookupEditor;
        CostCenterParentId: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
    }

    export class AccVoucherDtlAllocationForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherDtlAllocation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherDtlAllocationForm.init)  {
                AccVoucherDtlAllocationForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccVoucherDtlAllocationForm, [
                    'CostCenterTypeId', w0,
                    'CostCenterParentId', w0,
                    'CostCenterId', w0,
                    'Amount', w1
                ]);
            }
        }
    }
}

