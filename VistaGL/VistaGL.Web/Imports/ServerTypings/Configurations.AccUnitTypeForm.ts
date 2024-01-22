namespace VistaGL.Configurations {
    export interface AccUnitTypeForm {
        UnitName: Serenity.StringEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class AccUnitTypeForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccUnitType';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccUnitTypeForm.init)  {
                AccUnitTypeForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(AccUnitTypeForm, [
                    'UnitName', w0,
                    'Remarks', w1
                ]);
            }
        }
    }
}

