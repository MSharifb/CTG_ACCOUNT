
namespace VistaGL.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AuditLogDialog extends Serenity.EntityDialog<AuditLogRow, any> {
        protected getFormKey() { return AuditLogForm.formKey; }
        protected getIdProperty() { return AuditLogRow.idProperty; }
        protected getLocalTextPrefix() { return AuditLogRow.localTextPrefix; }
        protected getNameProperty() { return AuditLogRow.nameProperty; }
        protected getService() { return AuditLogService.baseUrl; }

        protected form = new AuditLogForm(this.idPrefix);



        protected getToolbarButtons(): Serenity.ToolButton[] {
            let buttons = super.getToolbarButtons();

            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "save-and-close-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "apply-changes-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "delete-button"), 1);

            return buttons;
        }

        protected updateInterface(): void {

            super.updateInterface();
            Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);

            // remove required asterisk (*)
            this.element.find('sup').hide();

            this.deleteButton.hide();
        }

        protected getEntityTitle(): string {

            if (!this.isEditMode()) {
                // we shouldn't hit here, but anyway for demo...
                return "How did you manage to open this dialog in new record mode?";
            }
            else {
                var entityType = super.getEntitySingular();

                // get name field value of record this dialog edits
                let name = this.getEntityNameFieldValue() || "";

                return 'View ' + entityType + " (" + name + ")";
            }
        }

        onDialogOpen(): void {
            super.onDialogOpen();

            let emp = Configurations.PrmEmploymentInfoRow.getLookup().items.filter(f => f.EmpId == this.form.UserName.value);
            console.log(emp);
            if (emp != undefined && emp.length > 0)
            {
                this.form.UserFullName.value = emp[0].FullName;
                this.form.ZoneName.value = emp[0].ZoneInfoZoneName;
            }

        }


    }
}