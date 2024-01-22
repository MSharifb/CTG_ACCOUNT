namespace VistaGL.Configurations {
    export interface AccFundControlZoneWiseApproverForm {
        FundControlId: Serenity.LookupEditor;
        ZoneInfoId: Serenity.LookupEditor;
        ApproverId: Serenity.LookupEditor;
        PostingById: Serenity.LookupEditor;
    }

    export class AccFundControlZoneWiseApproverForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccFundControlZoneWiseApprover';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccFundControlZoneWiseApproverForm.init)  {
                AccFundControlZoneWiseApproverForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;

                Q.initFormType(AccFundControlZoneWiseApproverForm, [
                    'FundControlId', w0,
                    'ZoneInfoId', w0,
                    'ApproverId', w0,
                    'PostingById', w0
                ]);
            }
        }
    }
}

