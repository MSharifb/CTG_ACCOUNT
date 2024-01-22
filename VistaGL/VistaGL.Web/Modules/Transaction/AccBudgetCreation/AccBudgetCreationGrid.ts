
namespace VistaGL.Transaction {
    import fld = AccBudgetForDepartmentDetailRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccBudgetCreationGrid extends EntityGridBase<AccBudgetForDepartmentDetailRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBudgetCreation'; }
        protected getDialogType() { return AccBudgetCreationDialog; }
        protected getIdProperty() { return AccBudgetForDepartmentDetailRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetForDepartmentDetailRow.localTextPrefix; }
        protected getService() { return AccBudgetCreationService.baseUrl; }

        private isEditedFlag = 'isEdited'
        public userInfo = Authorization.userDefinition;
        protected departmentFilter: Serenity.LookupEditor;
        protected zoneFilter: Serenity.LookupEditor;

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Budget Preparation");
            let employeeId = this.userInfo.EmpId;
            var tree = new _Ext.TreeGridMixin<AccBudgetForDepartmentDetailRow>({
                grid: this,
                getParentId: x => x.ParentId,
                idField: AccBudgetForDepartmentDetailRow.Fields.BudgetHeadId,
                toggleField: AccBudgetForDepartmentDetailRow.Fields.BudgetHeadName,
                initialCollapse: () => false
            });

            this.slickGrid.onCellChange.subscribe((e, args) => {
                let item = args.item as AccBudgetForDepartmentDetailRow;
                item[this.isEditedFlag] = true;
                this.view.updateItem(item[this.getIdProperty()], item);
            });

            this.slickGrid.onBeforeEditCell.subscribe(function (e, args) {
                let item = args.item as AccBudgetForDepartmentDetailRow;
                console.log(item.BudgetForDepartmentForwardToEmployeeId);
                let column = args.column as Slick.Column;
                if (!item.IsBudgetHead)
                    return false;
                if (!item.CircularIsActive)
                    return false;
                if (item.BudgetForDepartmentForwardToEmployeeId == +'' || item.BudgetForDepartmentForwardToEmployeeId == undefined)
                    return true;
                else if (employeeId != item.BudgetForDepartmentForwardToEmployeeId)
                    return false;
            });
        }

        protected getItemCssClass(item: AccBudgetForDepartmentDetailRow, index: number): string {
            let klass: string = "";
            let IsEdited = item[this.isEditedFlag] as boolean;
            if (!IsEdited) {
                IsEdited = false;
            }

            if (IsEdited == true) {
                klass += " text-bold";
            }

            if (item.IsBudgetHead == true)
                klass += " budget-heads";
            else
                klass += " non-budget-heads";

            return Q.trimToNull(klass);
        }

        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = true;
            opt.autoEdit = true;
            return opt;
        }

        protected getColumns() {
            return super.getColumns().filter(x => x.field != "inline-actions")
        }

        protected getButtons() {
            var buttons = super.getButtons();
            buttons.shift();
            buttons.push({
                title: 'Draft',
                cssClass: 'apply-changes-button',
                onClick: e => {
                    (this.slickGrid as any).getEditController().commitCurrentEdit();
                    let success: boolean;
                    success = false;
                    var items = this.view.getItems().filter(q => q[this.isEditedFlag] == true);
                    items.forEach(item => {
                        if (item['RowNum'])
                            delete item['RowNum'];

                        if (item['_indent'])
                            delete item['_indent'];

                        if (item['_collapsed'])
                            delete item['_collapsed'];

                        if (item[this.isEditedFlag])
                            delete item[this.isEditedFlag];

                        item.BudgetForDepartmentApprovalStatusId = ApprovalStatus.Draft;
                        AccBudgetCreationService.Update({ EntityId: item.Id, Entity: item },
                            response => {
                            }, { async: false });
                        success = true;
                    })

                    if (success) Q.notifySuccess("Draft Success !");
                },
                separator: true
            });

            buttons.push({
                title: "Submit", cssClass: "send-button",

                onClick: (x) => {

                    let message = "Are you want to submit this budget?";

                    Q.confirm(message, () => {
                        if ((<any>$('.selectApprover')).select2("val") == "") {
                            Q.notifyError("Select submit to from dropdown please!");
                            return;
                        }
                        (this.slickGrid as any).getEditController().commitCurrentEdit();

                        let success: boolean;
                        success = false;

                        var items = this.view.getItems().filter(q => q[this.isEditedFlag] == true);
                        let i = 0;
                        items.forEach(item => {
                            i++;
                            if (item['RowNum'])
                                delete item['RowNum'];

                            if (item['_indent'])
                                delete item['_indent'];

                            if (item['_collapsed'])
                                delete item['_collapsed'];

                            if (item[this.isEditedFlag])
                                delete item[this.isEditedFlag];

                            if (items.length == i) {
                                item.BudgetForDepartmentApprovalStatusId = ApprovalStatus.Submit;
                                item.BudgetForDepartmentForwardToEmployeeId = (<any>$('.selectApprover')).select2("val");
                            }
                            AccBudgetCreationService.Update({ EntityId: item.Id, Entity: item },
                                response => {
                                }, { async: false });
                            success = true;
                        })
                        if (items.length == 0) {
                            items = this.view.getItems();
                            console.log(items[0]);
                            if (items[0]['RowNum'])
                                delete items[0]['RowNum'];

                            if (items[0]['_indent'])
                                delete items[0]['_indent'];

                            if (items[0]['_collapsed'])
                                delete items[0]['_collapsed'];

                            items[0].BudgetForDepartmentApprovalStatusId = ApprovalStatus.Submit;
                            items[0].BudgetForDepartmentForwardToEmployeeId = (<any>$('.selectApprover')).select2("val");

                            AccBudgetCreationService.Update({ EntityId: items[0].Id, Entity: items[0] },
                                response => {
                                }, { async: false });
                                success = true;
                        }

                        if (success) Q.notifySuccess("Application has been submitted successfully!")

                    });
                },
                separator: true
            });

            return buttons;
        }

        protected onViewProcessData(response) {
            let budgetForDeptId = response.Entities[0] == undefined ? 0 : response.Entities[0].BudgetForDepartmentId;

            let budgetForDept = AccBudgetForDepartmentRow.getLookup().items.filter(x => x.Id == budgetForDeptId)[0];
            this.updateColumnHeader(budgetForDept == undefined ? 0 : budgetForDept.BudgetCircularFinancialYearId);

            //let entity = response.Entities[0];
            //console.log(entity);
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

                ddl.appendTo('.buttons-inner');
                (<any>$('select.selectApprover')).select2();
                (<any>$('select.selectApprover')).select2('data', { id: '', text: defaultTextinDDL })
            }

            return super.onViewProcessData(response);
        }

        updateColumnHeader(Id) {
            if (Id == 0 || Id == null) {
                Q.warning("You may not have permission or no budget is setup for your department of this financial year. Please check.");
                return;
            }
            else {
                AccBudgetCreationService.GetFinancialYearName({ Id: Id }, r => {
                    var items = r.Entities[0];
                    this.slickGrid.updateColumnHeader(fld.ProposedBudgetAmount, 'Proposed Budget </br>' + items.NextYearName, 'Proposed Budget ' + items.NextYearName);
                    this.slickGrid.updateColumnHeader(fld.RevisedEstimateAmount, 'Revised Estimate </br>' + items.CurrentYearName, 'Revised Estimate ' + items.CurrentYearName);
                    this.slickGrid.updateColumnHeader(fld.ActualFirstSixMonths, 'Actual 1st Six Months </br>' + items.CurrentYearName, 'Actual 1st Six Months ' + items.CurrentYearName);
                    this.slickGrid.updateColumnHeader(fld.BudgetApproved, 'Budget (Approved) </br>' + items.CurrentYearName, 'Budget (Approved) ' + items.CurrentYearName);
                    this.slickGrid.updateColumnHeader(fld.ActualDuring, 'Actual During </br>' + items.PreviousYearName, 'Actual During ' + items.PreviousYearName);
                });
            }
        }

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            var ur = Authorization.userDefinition;
            let filters = super.getQuickFilters();

            Q.first(filters, x => x.field == fld.CircularFinancialYearId).init = w => {
                (w as Serenity.LookupEditor).value = AccBudgetCircularRow.getLookup().items.filter(x => x.IsActive == true)[0].FinancialYearId.toString();
            };

            Q.first(filters, x => x.field == fld.BudgetForDepartmentDepartmentId).init = w => {
                (w as Serenity.LookupEditor).value = Configurations.PrmEmploymentInfoRow.getLookup().items.filter(x => x.Id == ur.EmpId)[0].DivisionId.toString();
            };
            return filters;
        }

        protected createQuickFilters() {
            super.createQuickFilters();
            this.departmentFilter = this.findQuickFilter(Serenity.LookupEditor, fld.BudgetForDepartmentDepartmentId);
            this.zoneFilter = this.findQuickFilter(Serenity.LookupEditor, fld.BudgetForDepartmentZoneId);
        }
        public set_shippingState(value: number): void {
            this.departmentFilter.value = value == null ? '' : value.toString();
        }
        public set_zone(value: number): void {
            this.zoneFilter.value = value == null ? '' : value.toString();
        }

    }
}