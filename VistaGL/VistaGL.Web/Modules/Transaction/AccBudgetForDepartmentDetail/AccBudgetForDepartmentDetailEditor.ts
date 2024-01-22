
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass([Serenity.IGetEditValue, Serenity.ISetEditValue])
    @Serenity.Decorators.editor()
    @Serenity.Decorators.element("<div/>")
    export class AccBudgetForDepartmentDetailEditor extends Serenity.Widget<any>
        implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchInput: HTMLInputElement;
        jsTreeDiv: HTMLDivElement;
        allClusterInput: HTMLInputElement;
        public budgetDetails: AccBudgetForDepartmentDetailRow[];

        constructor(container: JQuery) {
            super(container);

            this.searchInput = document.createElement('input');
            this.searchInput.type = 'text';
            this.searchInput.id = 'searchInput';
            this.searchInput.style.width = '100%';

            this.jsTreeDiv = document.createElement('div');
            this.jsTreeDiv.id = 'jsTreeDiv';
            this.element.append(this.searchInput);
            this.element.append(this.jsTreeDiv);
        }

        public getEditValue(property, target) {
                target[property.name] = this.value;
        }

        public setEditValue(source, property) {
                this.value = source[property.name];
        }
        protected budgetHeads: AccBudgetForDepartmentDetailRow[] = [];

        public get value(): AccBudgetForDepartmentDetailRow[] {
            this.budgetHeads = [];
            var selectedNodes = $('#jsTreeDiv').jstree().get_checked(true);

            for (var i = 0; i < selectedNodes.length; i++) {

                var budget = selectedNodes[i].data as AccBudgetForDepartmentDetailRow;
                if (this.budgetHeads.some(f => f == budget.Id) == false) {
                    this.budgetHeads.push({ BudgetHeadId: budget.BudgetHeadId, ParentId: budget.ParentId, IsCoa: budget.IsCoa, BudgetGroupId: budget.IsBudgetHead == false ? budget.BudgetHeadId : null, IsBudgetHead: budget.IsBudgetHead, IsCostCenter: budget.IsCostCenter, BGSortOrder: budget.BGSortOrder, BudgetCode: budget.BudgetCode });;
                }
            }
            return this.budgetHeads;
        }

        public set value(value: AccBudgetForDepartmentDetailRow[]) {
            value = value || [];
            this.budgetHeads = value;
            AccBudgetForDepartmentService.BudgetHeadList({}, r => {

                this.budgetDetails = r.Entities;

                var treeData = [];

                for (var budgetItem of this.budgetDetails) {

                    //var bHeads = AccBudgetForDepartmentRow.getLookup().items;

                    var isSelected = value.some(f => f.BudgetHeadId == budgetItem.BudgetHeadId);

                    treeData.push({
                        id: budgetItem.BudgetHeadId,
                        parent: budgetItem.ParentId || '#',
                        text: budgetItem.BudgetHeadName,
                        icon: false, state: { opened: false, selected: isSelected },
                        data: budgetItem
                    });

                }

                //to enable searching
                $('#searchInput').keyup((e) => {

                    var searchString = (e.currentTarget as HTMLInputElement).value;

                    $('#jsTreeDiv').jstree('search', searchString, true, true);
                });

                $('#jsTreeDiv').jstree({
                    plugins: ['checkbox', "search"],
                    core: {
                        data: treeData
                    },
                    search: {
                        case_insensitive: true,
                        show_only_matches: true
                    },
                    checkbox: {
                        three_state: false
                    }
                }).on('search.jstree before_open.jstree', function (e, data) { // to Allow to open found subnodes
                    if (data.instance.settings.search.show_only_matches) {
                        data.instance._data.search.dom.find('.jstree-node')
                            .show().filter('.jstree-last').filter(function () { return this.nextSibling; }).removeClass('jstree-last')
                            .end().end().end().find(".jstree-children").each(function () { $(this).children(".jstree-node:visible").eq(-1).addClass("jstree-last"); });
                    }
                    });

                $('#jsTreeDiv').on('click', '.jstree-anchor', function (e) {
                    var anchorId = $(this).parent().attr('id');
                    var parent = $('#jsTreeDiv').jstree().get_node(anchorId).parents;
                    let isSelected = $('#jsTreeDiv').jstree(true).get_node(anchorId).state.selected;

                    if (isSelected) {
                        for (var i = 0; i < parent.length; i++) {
                            $('#jsTreeDiv').jstree(true).select_node(parent[i]);
                        }
                    }

                    var allChildren = $('#jsTreeDiv').jstree(true).get_children_dom(this);
                    if (isSelected) {
                        for (var i = 0; i < allChildren.length; i++) {
                            $('#jsTreeDiv').jstree(true).select_node(allChildren[i].id);
                        }
                    }
                    else {
                        for (var i = 0; i < allChildren.length; i++) {
                            $('#jsTreeDiv').jstree(true).deselect_node(allChildren[i].id);
                        }
                    }
                })

            }, { async: false });       
        }
    }
}