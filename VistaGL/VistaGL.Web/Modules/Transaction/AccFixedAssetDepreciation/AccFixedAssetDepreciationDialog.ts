
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccFixedAssetDepreciationDialog extends Serenity.EntityDialog<AccFixedAssetDepreciationRow, any> {
        protected getFormKey() { return AccFixedAssetDepreciationForm.formKey; }
        protected getIdProperty() { return AccFixedAssetDepreciationRow.idProperty; }
        protected getLocalTextPrefix() { return AccFixedAssetDepreciationRow.localTextPrefix; }
        protected getService() { return AccFixedAssetDepreciationService.baseUrl; }

        protected form = new AccFixedAssetDepreciationForm(this.idPrefix);

        onDialogOpen(): void {
            super.onDialogOpen();
            if (this.isNew()) {
                $('.reject').hide();
            }
            else {

            }
        }

        protected getToolbarButtons() {

            var buttons = super.getToolbarButtons();
            buttons = [];
            buttons.push({
                title: "Process", cssClass: "send-button",

                onClick: (x) => {

                    let message = "Are you sure you want to Process?";

                    Q.confirm(message, () => {
                        if (this.form.FinancialYearId.value == "") {
                            Q.alert("Please select leave year!");
                            return;
                        }

                        var allProcessRows = AccFixedAssetDepreciationRow.getLookup().items;
                        if (allProcessRows.length > 0)
                        {
                            let selectedFinancialYear = Configurations.AccAccountingPeriodInformationRow.getLookup().items.filter(x => x.Id == +this.form.FinancialYearId.value)[0];

                            let selectedYearName = selectedFinancialYear.YearName.split("-");

                            let nextYearName =  (Number(selectedYearName[0]) + 1) + "-" + (Number(selectedYearName[1]) + 1) ;
                            let previousYearName = (Number(selectedYearName[0]) - 1) + "-" + (Number(selectedYearName[1]) - 1);
                            let financialYearList = Configurations.AccAccountingPeriodInformationRow.getLookup().items;

                            let nextFinancialYear = financialYearList.filter(x => x.YearName == nextYearName);
                            let nextFinancialYearId = 0;
                            if (nextFinancialYear[0] != undefined)
                                 nextFinancialYearId = nextFinancialYear[0].Id;

                            let nextYearDepreciationP = AccFixedAssetDepreciationRow.getLookup().items.filter(x => x.FinancialYearId == nextFinancialYearId);
                            if (nextYearDepreciationP.length > 0) {
                                Q.warning("Depreciation can't process! Because " + nextYearName + " depreciation already processed.");
                                return;
                            }

                            let previousFinancialYear = financialYearList.filter(x => x.YearName == previousYearName);
                            let previousFinancialYearId = 0;
                            if (previousFinancialYear[0] != undefined)
                                previousFinancialYearId = previousFinancialYear[0].Id;

                            let previousYearDepreciationP = AccFixedAssetDepreciationRow.getLookup().items.filter(x => x.FinancialYearId == previousFinancialYearId);
                            if (previousYearDepreciationP.length == 0) {
                                Q.warning("Depreciation can't process! Because " + previousYearName + " depreciation is not process yet.");
                                return;
                            }
                        }
                        this.form.ProcessType.value = "P";
                        this.save(p => { Q.notifySuccess("Process successfull."); this.dialogClose(); });
                    });
                }
            });
            buttons.push({
                title: "Rollback", cssClass: "reject",

                onClick: (x) => {

                    let message = "Are you sure you want to Rollback?";

                    Q.confirm(message, () => {
                        if (this.form.FinancialYearId.value == "") {
                            Q.alert("Please select leave year!");
                            return;
                        }

                        let selectedFinancialYear = Configurations.AccAccountingPeriodInformationRow.getLookup().items.filter(x => x.Id == +this.form.FinancialYearId.value)[0];

                        let selectedYearName = selectedFinancialYear.YearName.split("-");

                        let nextYearName = (Number(selectedYearName[0]) + 1) + "-" + (Number(selectedYearName[1]) + 1);

                        let financialYearList = Configurations.AccAccountingPeriodInformationRow.getLookup().items;

                        let nextFinancialYear = financialYearList.filter(x => x.YearName == nextYearName);
                        let nextFinancialYearId = 0;
                        if (nextFinancialYear[0] != undefined)
                            nextFinancialYearId = nextFinancialYear[0].Id;

                        let nextYearDepreciationP = AccFixedAssetDepreciationRow.getLookup().items.filter(x => x.FinancialYearId == nextFinancialYearId);
                        if (nextYearDepreciationP.length != 0) {
                            Q.warning("Rollback can't process! Because " + nextYearName + " depreciation already processed.");
                            return;
                        }


                        this.form.ProcessType.value = "RB";
                        this.save(p => { Q.notifySuccess("Rollback successfull."); this.dialogClose(); });
                    });
                }
            });
            return buttons;
        }
    }
}