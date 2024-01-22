
namespace VistaGL.Default {

    import fld = AuditLogRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AuditLogGrid extends EntityGridBaseNew<AuditLogRow, any> {
        protected getColumnsKey() { return 'Default.AuditLog'; }
        protected getDialogType() { return AuditLogDialog; }
        protected getIdProperty() { return AuditLogRow.idProperty; }
        protected getLocalTextPrefix() { return AuditLogRow.localTextPrefix; }
        protected getService() { return AuditLogService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);

            return buttons;
        }

        //createQuickFilters(): void {
        //    super.createQuickFilters();

        //    this.addQuickFilter({
        //        type: Serenity.TimeEditor,
        //        field: AuditLogRow.Fields.ChangedOn
        //    });
        //}

        getQuickSearchFields(): Serenity.QuickSearchField[] {
            let txt = (s) => Q.text("Db." + AuditLogRow.localTextPrefix + "." + s).toLowerCase();

            return [
                { name: "", title: "all" },
                { name: fld.Action, title: txt(fld.Action) },
                { name: fld.DBTableName, title: txt(fld.DBTableName) },
                { name: fld.Changes, title: txt(fld.Changes) }
            ];

        }

    }
}