
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccChartofAccountsDialog extends EntityDialogBase<AccChartofAccountsRow, any> {

        protected getFormKey() { return AccChartofAccountsForm.formKey; }
        protected getIdProperty() { return AccChartofAccountsRow.idProperty; }
        protected getLocalTextPrefix() { return AccChartofAccountsRow.localTextPrefix; }
        protected getNameProperty() { return AccChartofAccountsRow.nameProperty; }
        protected getService() { return AccChartofAccountsService.baseUrl; }

        public isGroup = false;
        protected form = new AccChartofAccountsForm(this.idPrefix);
        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];

        onDialogOpen(): void {
            super.onDialogOpen();

            this.form.NoaAccTypeId2.element.hide();
            this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
            Serenity.EditorUtils.setReadonly(this.element.find(this.form.IsControlhead.element), true);

            if (this.isNew()) {
                this.form.IsControlhead.value = this.isGroup;
                var items = this.items_ChartofAccounts.filter(f => f.IsControlhead == 1 && f.Level > 0);
            }
            else {
                if (this.form.Level.value == 0 || this.form.Level.value == 1) {
                    this.toolbar.findButton('delete-button').toggleClass('disabled');
                    var items = this.items_ChartofAccounts.filter(f => f.IsControlhead == 1 && f.Level < 1);

                } else
                    var items = this.items_ChartofAccounts.filter(f => f.IsControlhead == 1 && f.Level > 0);

                if (this.entity.iSCoAUsed > 0) {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.IsControlhead.element), true);
                }
            }

            if (this.form.IsControlhead.value) {
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.AccOpeningBalance.element), true);
            }

            this.form.ParentAccountId.clearItems();

            for (var item of items) {
                this.form.ParentAccountId.addItem({ id: item.Id.toString(), text: item.AccountName, source: null, disabled: false });
            }


            this.form.FundControlId.value = Authorization.userDefinition.FundControlInformationId.toString();
            this.form.AccountName.element.focus();

            this.form.ParentAccountId.changeSelect2(p => {

                var _items = this.items_ChartofAccounts.filter(p => p.ParentAccountId == +this.form.ParentAccountId.value);

                var max_ = Math.max.apply(Math, _items.map(function (o) { return o.AccountCodeCount; }));
                if (max_.toString() == "NaN" || max_.toString() == "-Infinity")
                    max_ = 1;
                else
                    max_++;

                var _pitems = this.items_ChartofAccounts.filter(p => p.Id == +this.form.ParentAccountId.value);

                this.form.AccountGroup.value = _pitems[0].AccountGroup;
                this.form.AccountCode.value = _pitems[0].AccountCode + "." + max_;
                this.form.AccountCodeCount.value = max_;
                this.form.Level.value = _pitems[0].Level + 1;
            });

        }
    }
}