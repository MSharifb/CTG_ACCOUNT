namespace VistaGL.Transaction {

    @Serenity.Decorators.registerEditor([Serenity.IGetEditValue, Serenity.ISetEditValue])
    @Serenity.Decorators.element("<div/>")
    export class VoucherApprovalHistoryEditor extends Serenity.TemplatedWidget<any>
        implements Serenity.IGetEditValue, Serenity.ISetEditValue {

        private isDirty: boolean;
        private items: ApvApplicationInformationRow[];

        constructor(div: JQuery) {
            super(div);
        }

        protected getTemplate() {
            return "<div><div id='~_Toolbar'></div><div id='~_NoteList'></div></div>";
        }

        protected updateContent() {
            var noteList = this.byId('NoteList');
            noteList.children().remove();

            if (this.items) {

                var html = '<table class="table table-sm table-striped table-hover">';

                html += '<tr style="background-color: gray; color: white; font-weight: bold;"><td>' + 'Date & Time' + '</td>' + '<td>' + 'Status' + '</td>' + '<td>' + 'Forword By' + '</td>' + '<td>' + 'Forword To' + ' </td>' + '<td>' + 'Comments' + ' </td>';

                for (let item of this.items) {
                    if (item.Status == undefined)
                        item.Status = "Pending";

                    html += '<tr>' +
                        '<td>' + Q.formatDate(item.IDate, 'g') + '</td>' +
                        '<td>' + item.Status + '</td>' +
                        '<td>' + item.ForwordBy + '(' + item.IUser + ')' + ' </td>' +
                        '<td>' + item.EmploymentInfoFullName + '(' + item.ApproverCode + ')' + '</td>' +
                        '<td>' + item.ApproverComments + '</td></tr>';
                };
                html += '</table>';

                noteList.append(html);
            }
        }

        public getEditValue(prop: Serenity.PropertyItem, target) {
            target[prop.name] = this.value;
        }

        public setEditValue(source, prop: Serenity.PropertyItem) {
            this.value = source[prop.name] || [];
        }

        public get value() {
            return this.items;
        }

        public set value(value: ApvApplicationInformationRow[]) {
            this.items = value || [];
            this.set_isDirty(false);
            this.updateContent();
        }

        public get_isDirty(): boolean {
            return this.isDirty;
        }

        public set_isDirty(value): void {
            this.isDirty = value;
        }

        public onChange: () => void;
    }
}