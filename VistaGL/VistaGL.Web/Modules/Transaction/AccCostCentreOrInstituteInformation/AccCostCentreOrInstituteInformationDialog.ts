
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCostCentreOrInstituteInformationDialog extends _Ext.DialogBase<AccCostCentreOrInstituteInformationRow, any> {
        protected getFormKey() { return AccCostCentreOrInstituteInformationForm.formKey; }
        protected getIdProperty() { return AccCostCentreOrInstituteInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccCostCentreOrInstituteInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccCostCentreOrInstituteInformationRow.nameProperty; }
        protected getService() { return AccCostCentreOrInstituteInformationService.baseUrl; }

        protected form = new AccCostCentreOrInstituteInformationForm(this.idPrefix);

        constructor() {
            super();

            $('.EmpId').hide();
            // Q.reloadLookup(AccCostCentreOrInstituteInformationRow.lookupKey);
            this.form.CostCenterTypeId.changeSelect2(p => {

                if (this.form.CostCenterTypeId.value == "4") {

                    $('.EmpId').show();
                } else {
                    $('.EmpId').hide();
                    this.form.EmpId.value = "";
                }
            });

            this.form.EmpId.changeSelect2(p => {
                var empCOde = this.form.EmpId.get_text().split('-');
                this.form.UserCode.value = empCOde[0].trim();
                this.form.Name.value = empCOde[1].trim();
            });
        }

        onDialogOpen(): void {
            super.onDialogOpen();

            if (this.entity.IsFixedAssetDevWork == true)
            {
                this.form.FixedAssetDevWorkTypeSelector.value = FixedAssetDevWorkType.IsFixedAssetDevWork.toString();
            }
            else if (this.entity.IsFixedAssetNonDevWork == true) {
                this.form.FixedAssetDevWorkTypeSelector.value = FixedAssetDevWorkType.IsFixedAssetNonDevWork.toString();
            }

            if (this.isNew()) {
                this.form.Name.change(e => {
                    //
                    this.form.NameForBankAdviceLetter.value = this.form.Name.value;
                });
            }
        }


    }
}