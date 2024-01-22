
namespace VistaGL.Transaction {
    import fld = AccBudgetForDepartmentDetailRow.Fields;

    @Serenity.Decorators.registerClass()
    export class BudgetCreationApprovalGrid extends EntityGridBase<AccBudgetForDepartmentRow, any> {
        protected getColumnsKey() { return 'Transaction.BudgetCreationApproval'; }
        protected getDialogType() { return BudgetCreationApprovalDialog; }
        protected getIdProperty() { return AccBudgetForDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetForDepartmentRow.localTextPrefix; }
        protected getService() { return BudgetCreationApprovalService.baseUrl; }

        AccBudgetApprovalHistoryGrid: AccBudgetApprovalHistoryGrid;

        public budgetforDeptId;

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Budget Approval");

            $('<div class="approver"></div>').appendTo('.buttons-inner');
        }

        protected getColumns() {
            var columns = super.getColumns();

            let rowSelectionCol = Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection);
            rowSelectionCol.width = rowSelectionCol.minWidth = rowSelectionCol.maxWidth = 25
            columns.unshift(rowSelectionCol);

            columns.splice(1, 0, {
                field: 'Print',
                name: 'Print',
                format: ctx => '<a class="inline-action Print-link" title="Print">' +
                    '<i class="fa fa-print text-blue"></i></a>',
                width: 50,
                minWidth: 50,
                maxWidth: 50
            });

            columns.splice(1, 0, {
                field: 'Edit',
                name: 'Edit',
                format: ctx => '<a class="inline-action Edit-link" title="Edit">' +
                    '<i class="fa fa-edit text-red"></i></a>',
                width: 50,
                minWidth: 50,
                maxWidth: 50
            });
            columns.splice(1, 0, {
                field: 'History',
                name: 'History',
                format: ctx => '<a class="inline-action History-link" title="History">' +
                    '<i class="fa fa-history text-green"></i></a>',
                width: 70,
                minWidth: 70,
                maxWidth: 70
            });

            columns = columns.filter(x => x.field != "inline-actions")
            return columns;
        }

        protected getButtons() {
            var buttons = super.getButtons();
            buttons.shift();

            buttons.push({
                title: 'Regret',
                cssClass: 'send-button regret-button',
                onClick: (x) => {

                    if ((<any>$('.selectApprover')).select2("val") == "") {
                        Q.notifyError("Select forward to Please!");
                        return;
                    }
                    let message = "Are you sure want to regret this budget?";

                    Q.confirm(message, () => {
                        if ((<any>$('.selectApprover')).select2("val") == "") {
                            Q.notifyError("Select submit to from dropdown please!");
                            return;
                        }
                        var selected = this.rowSelection.getSelectedKeys();
                        if (selected.length == 0) {
                            var rv = Q.warning("No row is selected!");
                            return;
                        }
                        else {
                            for (var i = 0; i < selected.length; i++) {
                                let id = selected[i];
                                var item: AccBudgetForDepartmentRow = {};
                                item.ApprovalStatusId = +ApprovalStatus.Regret;
                                item.ForwardToEmployeeId = (<any>$('.selectApprover')).select2("val");

                                BudgetCreationApprovalService.Update({ EntityId: id, Entity: item },
                                    response => {
                                    }, { async: false });
                            }
                            Q.notifySuccess("Application has been Regreted successfully!")
                        }
                    });

                },
                separator: true
            });

            buttons.push({
                title: 'Recommend',
                cssClass: 'send-button recommend-button',
                onClick: e => {

                    let message = "Are you sure want to recommend this budget?";

                    Q.confirm(message, () => {
                        if ((<any>$('.selectApprover')).select2("val") == "") {
                            Q.notifyError("Select submit to from dropdown please!");
                            return;
                        }
                        var selected = this.rowSelection.getSelectedKeys();
                        if (selected.length == 0) {
                            var rv = Q.warning("No row is selected!");
                            return;
                        }
                        else {
                            for (var i = 0; i < selected.length; i++) {
                                let id = selected[i];
                                var item: AccBudgetForDepartmentRow = {};
                                item.ApprovalStatusId = +ApprovalStatus.Recommend;
                                item.ForwardToEmployeeId = (<any>$('.selectApprover')).select2("val");

                                BudgetCreationApprovalService.Update({ EntityId: id, Entity: item },
                                    response => {
                                    }, { async: false });
                            }
                            Q.notifySuccess("Budget has been recommended successfully!")
                        }

                    })

                },
                separator: true
            });

            buttons.push({
                title: 'Approve',
                cssClass: 'approve-button',
                onClick: (x) => {

                    let message = "Are you sure want to Approve this budget?";

                    Q.confirm(message, () => {
                        var selected = this.rowSelection.getSelectedKeys();
                        if (selected.length == 0) {
                            var rv = Q.warning("No row is selected!");
                            return;
                        }
                        else {
                            for (var i = 0; i < selected.length; i++) {
                                let id = selected[i];
                                var item: AccBudgetForDepartmentRow = {};
                                item.ApprovalStatusId = +ApprovalStatus.Approved;

                                BudgetCreationApprovalService.Update({ EntityId: id, Entity: item },
                                    response => {
                                    }, { async: false });
                            }
                            Q.notifySuccess("Application has been Approved successfully!")
                        }
                    })
                },
                separator: true
            });

            return buttons;
        }

        protected onViewProcessData(response) {
            $('.export-pdf-button').hide();
            this.budgetforDeptId = response.Entities[0] == undefined ? 0 : response.Entities[0].Id;

            let budgetForDept = AccBudgetForDepartmentRow.getLookup().items.filter(x => x.Id == this.budgetforDeptId)[0];

            var approvalActionLookup = $('#ddl11');

            if (approvalActionLookup.length == 0) {

                $('.buttons-inner').append('');

                var ddl = $('<select />');
                ddl.addClass('selectApprover');
                ddl.attr('id', 'ddl11');
                ddl.css("width", 250);

                let currentApproverType = "Recommender";
                let defaultTextinDDL = '';
                defaultTextinDDL = '--- Submit To ---';

                //$('.approve-button').show();
                //$('.recommend-button').show();

                $('<option />', { value: '', text: defaultTextinDDL }).appendTo(ddl);

                Transaction.AccBudgetCreationService.GetBudgetApproverList({ ZoneId: budgetForDept.ZoneId, DepartmentId: budgetForDept.DepartmentId }, r => {
                    var items = r.Entities;
                    for (var item of items) {
                        $('<option />', { value: item.Id.toString(), text: item.LookupText }).appendTo(ddl);
                    }
                });

                ddl.appendTo('.approver');
                (<any>$('select.selectApprover')).select2();
                (<any>$('select.selectApprover')).select2('data', { id: '', text: defaultTextinDDL })
            }

            if (this.AccBudgetApprovalHistoryGrid) {
                this.AccBudgetApprovalHistoryGrid.loadByBudgetForDepartmentId(this.budgetforDeptId);
            }

            return super.onViewProcessData(response);
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number): void {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented()) {
                return;
            }

            var item = this.itemAt(row);
            var target = $(e.target);

            //-- History
            if (target.parent().hasClass('History-link'))
                target = target.parent();

            if (target.hasClass("History-link")) {
                e.preventDefault();
                var _url = "~/Reports/BudgetApprovalInfo/BudgetHistory?financialPeriodId=" + item.BudgetCircularFinancialYearId + "&zoneInfoId=" + + item.ZoneId + "&departmentId=" + item.DepartmentId;
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });
            }


            //-- Print
            if (target.parent().hasClass('Print-link'))
                target = target.parent();

            if (target.hasClass("Print-link")) {
                e.preventDefault();
                var _url = "~/Reports/ConsolidatedBudget/GetBudget?financialPeriodId=" + item.BudgetCircularFinancialYearId + "&zoneInfoId=" + + item.ZoneId + "&departmentId=" + item.DepartmentId;
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });
            }


            //-- Edit
            if (target.parent().hasClass('Edit-link'))
                target = target.parent();

            if (target.hasClass("Edit-link")) {
                e.preventDefault();
                var _url = "~/Transaction/AccBudgetCreation?BudgetForDepartmentDepartmentId=" + item.DepartmentId + "&BudgetForDepartmentZoneId=" + item.ZoneId;
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });

            }
        }

    }
}