namespace VistaGL.Configurations {
    export interface AccReportTypeCostCenterMappingForm {
        ReportTypeId: Serenity.LookupEditor;
        GroupId: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        OpeningBalance: Serenity.DecimalEditor;
    }

    export class AccReportTypeCostCenterMappingForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccReportTypeCostCenterMapping';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccReportTypeCostCenterMappingForm.init)  {
                AccReportTypeCostCenterMappingForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccReportTypeCostCenterMappingForm, [
                    'ReportTypeId', w0,
                    'GroupId', w0,
                    'CostCenterId', w0,
                    'OpeningBalance', w1
                ]);
            }
        }
    }
}

