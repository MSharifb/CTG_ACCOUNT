
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass([Serenity.IGetEditValue, Serenity.ISetEditValue])
    @Serenity.Decorators.editor()
    @Serenity.Decorators.element("<div/>")
    export class CoAEditor extends Serenity.Widget<any>
        implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchDebitInput: HTMLInputElement;
        jsTreeDebitDiv: HTMLDivElement;


        public TransactionTypeID: number;
        constructor(container: JQuery) {
            super(container);
            this.searchDebitInput = document.createElement('input');
            this.searchDebitInput.type = 'text';
            this.searchDebitInput.id = 'searchDebitInput';
            this.searchDebitInput.style.width = '100%';
            // this.searchDebitInput.style.cssFloat = 'left';

            this.jsTreeDebitDiv = document.createElement('div');

            //
            this.jsTreeDebitDiv.id = 'jsTreeDebitDiv';
            //this.element.append(this.searchDebitInput);
            this.element.append(this.jsTreeDebitDiv);




        }

        public getEditValue(property, target) {
            target[property.name] = this.value;
        }

        public setEditValue(source, property) {
            this.value = source[property.name];
        }

        protected DebitItems: Transaction.AccTransactionTypeAssignRow[] = [];

        public get value(): Transaction.AccTransactionTypeAssignRow[] {
            this.DebitItems = [];
            //var b: AccTransactionTypeAssignRow;
            //b = {};
            //b.TrType = "ZZZ";
            //this.DebitItems.push(b);
            //    this.DebitItems.forEach(f => f.Level = 1);
            var apps_me: Configurations.AccChartofAccountsRow[];
            apps_me = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;

            var selectedNodes = $('#jsTreeDebitDiv').jstree().get_checked(true);
            //   var menuPermissionNodesOnly = selectedNodes.filter(f => f.id.startsWith('menuPermission_'));

            for (var i = 0; i < selectedNodes.length; i++) {
                var menuPermission = selectedNodes[i].data;

                //   var DebitItems = this.DebitItems.filter(f => f.CoaId == menuPermission.Id)
                //  if (DebitItems.length == 0) {
                //  var isSelectedDebit = apps_me.filter(f => f.Id == menuPermission.Id && f.IsControlhead == 0).length > 0;
                if (menuPermission.IsControlhead == 0) {
                    this.DebitItems.push({ CoaId: menuPermission.Id, TrType: menuPermission.iSCoAUsed, ParentId: this.TransactionTypeID });
                }
                //  }

                //else if (DebitItems.length == 1) {
                //    DebitItems[0].Granted = true;
                //}
                //else {
                //    Q.alert('Invalid Data.');
                //}
            }




            return this.DebitItems;
        }

        public set value(value: Transaction.AccTransactionTypeAssignRow[]) {
            value = value || [];
            this.DebitItems = value;
            Q.reloadLookup('Configurations.AccChartofAccounts_Lookup');
            var apps_me: Configurations.AccChartofAccountsRow[];
            apps_me = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;

            var apps: Configurations.AccChartofAccountsRow[];
            apps = Configurations.AccChartofAccountsRow.getLookup().items;
            //  Configurations.AccChartofAccountsRow.getLookup().items;
            //var modules = ModuleRow.getLookup().items;
            //var menus = MenuRow.getLookup().items;
            //var menuPermissions = MenuPermissionRow.getLookup().items;

            var treeData_Debit = [];



            //Module
            var appModules = apps;//.filter(f => f.ApplicationId == app.Id);
            for (var module of appModules) {
                var moduleTreeId = 'debit_' + module.Id;
                var CreditmoduleTreeId = 'credit_' + module.Id;
                var moduleParentAccountId = "";

                var isSelectedDebit = false;
                isSelectedDebit = apps_me.filter(f => f.Id == module.Id && f.IsControlhead == 0).length > 0;

                if (isSelectedDebit) {
                    module.iSCoAUsed = 1;
                }
                if (module.ParentAccountId != undefined) {

                    moduleParentAccountId = 'debit_' + module.ParentAccountId;
                    treeData_Debit.push({
                        id: moduleTreeId,
                        parent: moduleParentAccountId,
                        text: module.AccountName,
                        icon: false, state: { opened: false, selected: isSelectedDebit },
                        data: module
                    });


                }
                else {
                    treeData_Debit.push({
                        id: moduleTreeId,
                        text: module.AccountName,
                        parent: "#",
                        icon: false, state: { opened: false }, data: module
                    });


                }

            }

            //  }


            //    $('#searchDebitInput').keyup( (e) => {

            //        var searchDebitString = (e.currentTarget as HTMLInputElement).value;
            //        $('#jsTreeDebitDiv').jstree('search', searchDebitString);
            //});

            //$('#searchCreditInput').keyup((e) => {

            //    var searchCreditString = (e.currentTarget as HTMLInputElement).value;
            //    $('#jsTreeCreditDiv').jstree('search', searchCreditString);
            //});

            $('#jsTreeDebitDiv').jstree({
                plugins: ['checkbox', "search"],
                core: {
                    data: treeData_Debit
                },
                //search: {
                //    case_insensitive: true,
                //    show_only_matches: true
                //},
            });

        }
    }
}