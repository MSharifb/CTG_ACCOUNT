namespace VistaGL.Configurations {
    export interface AccCostCenterTypeForm {
        CostCenterType: Serenity.StringEditor;
        SortOrder: Serenity.IntegerEditor;
    }

    export class AccCostCenterTypeForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccCostCenterType';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCostCenterTypeForm.init)  {
                AccCostCenterTypeForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.IntegerEditor;

                Q.initFormType(AccCostCenterTypeForm, [
                    'CostCenterType', w0,
                    'SortOrder', w1
                ]);
            }
        }
    }
}

