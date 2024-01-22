
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass([Serenity.IGetEditValue, Serenity.ISetEditValue])
    @Serenity.Decorators.editor()
    @Serenity.Decorators.element("<div/>")
    export class CoADebitEditor extends Serenity.Widget<any>
    implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchDebitInput: HTMLInputElement;
        jsTreeDebitDiv: HTMLDivElement;

        searchCreditInput: HTMLInputElement;
        jsTreeCreditDiv: HTMLDivElement;
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

        //    this.jsTreeDebitDiv.style.cssFloat = "left";

            this.searchCreditInput = document.createElement('input');
            this.searchCreditInput.type = 'text';
            this.searchCreditInput.id = 'searchCreditInput';
            this.searchCreditInput.style.width = '100%';
          //  this.searchCreditInput.style.cssFloat = 'right';

            this.jsTreeCreditDiv = document.createElement('div');
            this.jsTreeCreditDiv.id = 'jsTreeCreditDiv';
            //this.element.append(this.searchCreditInput);
            this.element.append(this.jsTreeCreditDiv);
         //   this.jsTreeCreditDiv.style.cssFloat = "right";
        }

        public getEditValue(property, target) {
            target[property.name] = this.value;
        }

        public setEditValue(source, property) {
            this.value = source[property.name];
        }

        protected DebitItems: AccTransactionTypeAssignRow[] = [];

        public get value(): AccTransactionTypeAssignRow[] {
            this.DebitItems = [];
            //var b: AccTransactionTypeAssignRow;
            //b = {};
            //b.TrType = "ZZZ";
            //this.DebitItems.push(b);
        //    this.DebitItems.forEach(f => f.Level = 1);

            var selectedNodes = $('#jsTreeDebitDiv').jstree().get_checked(true);
         //   var menuPermissionNodesOnly = selectedNodes.filter(f => f.id.startsWith('menuPermission_'));
          
            for (var i = 0; i < selectedNodes.length; i++){
                var menuPermission = selectedNodes[i].data;
                //console.log(menuPermission);
             //   var DebitItems = this.DebitItems.filter(f => f.CoaId == menuPermission.Id)
              //  if (DebitItems.length == 0) {
                    this.DebitItems.push({ CoaId: menuPermission.Id, TrType: "D", ParentId: this.TransactionTypeID});
              //  }
              
                //else if (DebitItems.length == 1) {
                //    DebitItems[0].Granted = true;
                //}
                //else {
                //    Q.alert('Invalid Data.');
                //}
            }

            var selectedNodesCredit = $('#jsTreeCreditDiv').jstree().get_checked(true);
            //   var menuPermissionNodesOnly = selectedNodes.filter(f => f.id.startsWith('menuPermission_'));

            for (var i = 0; i < selectedNodesCredit.length; i++) {
                var menuPermission = selectedNodesCredit[i].data;

                //var DebitItems1 = this.DebitItems.filter(f => f.CoaId == menuPermission.Id && f.TrType == "C");
                //console.log(DebitItems1.length);
                //if (DebitItems1.length == 0) {
                this.DebitItems.push({ CoaId: menuPermission.Id, TrType: "C", ParentId: this.TransactionTypeID});
                //} else {
                //  //  this.DebitItems.r
                //    this.DebitItems = this.DebitItems.filter(f => f.CoaId != menuPermission.Id && f.TrType == "C");
                //}

                //else if (DebitItems.length == 1) {
                //    DebitItems[0].Granted = true;
                //}
                //else {
                //    Q.alert('Invalid Data.');
                //}
            }

        //    console.log(this.DebitItems);
            return this.DebitItems;
        }

        public set value(value: AccTransactionTypeAssignRow[]) {
            value = value || [];
            this.DebitItems = value;

            var apps: Configurations.AccChartofAccountsRow[];
            apps = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
          //  Configurations.AccChartofAccountsRow.getLookup().items;
            //var modules = ModuleRow.getLookup().items;
            //var menus = MenuRow.getLookup().items;
            //var menuPermissions = MenuPermissionRow.getLookup().items;

            var treeData_Debit = [];

            var treeData_Credit = [];

            //App
            //for (var app of apps) {
            //    var appTreeId = 'app_' + app.Id

                //treeData.push({
                //    id: appTreeId,
                //    parent: "#",
                //    text: app.Name,
                //    icon: false, state: { opened: false }
                //});

            //Module
            var appModules = apps;//.filter(f => f.ApplicationId == app.Id);
                for (var module of appModules) {
                    var moduleTreeId = 'debit_' + module.Id;
                    var CreditmoduleTreeId = 'credit_' + module.Id;
                    var moduleParentAccountId = "";

                    var isSelectedDebit = value.filter(f => f.CoaId == module.Id
                        && f.TrType == "D").length > 0;

                    var isSelectedCredit = value.filter(f => f.CoaId == module.Id
                        && f.TrType == "C").length > 0;

                    if (module.ParentAccountId != undefined) {

                        moduleParentAccountId = 'debit_' + module.ParentAccountId;
                        treeData_Debit.push({
                            id: moduleTreeId,
                            parent: moduleParentAccountId,
                            text: module.AccountName,
                            icon: false, state: { opened: false, selected: isSelectedDebit },
                            data: module
                        });

                        var CreditmoduleParentAccountId = 'credit_' + module.ParentAccountId;
                        treeData_Credit.push({
                            id: CreditmoduleTreeId,
                            parent: CreditmoduleParentAccountId,
                            text: module.AccountName,
                            icon: false, state: { opened: false, selected: isSelectedCredit },
                            data: module
                        });

                    }
                    else {
                        treeData_Debit.push({
                            id: moduleTreeId,
                            text: module.AccountName,
                            parent: "#",
                            icon: false, state: { opened: false }
                        });

                        treeData_Credit.push({
                            id: CreditmoduleTreeId,
                            text: module.AccountName,
                            parent: "#",
                            icon: false, state: { opened: false }
                        });
                    }
                 
            }

          //  }

               // console.log(treeData);
            //    $('#searchDebitInput').keyup( (e) => {

            //        var searchDebitString = (e.currentTarget as HTMLInputElement).value;
            //        $('#jsTreeDebitDiv').jstree('search', searchDebitString);
            //});

                //$('#searchCreditInput').keyup((e) => {

                //    var searchCreditString = (e.currentTarget as HTMLInputElement).value;
                //    $('#jsTreeCreditDiv').jstree('search', searchCreditString);
                //});

                $('#jsTreeDebitDiv').jstree({
                plugins: ['checkbox',"search"],
                core: {
                    data: treeData_Debit
                },
                //search: {
                //    case_insensitive: true,
                //    show_only_matches: true
                //},
                });
                $('#jsTreeCreditDiv').jstree({
                plugins: ['checkbox',"search"],
                core: {
                    data: treeData_Credit
                },
                //search: {
                //    case_insensitive: true,
                //    show_only_matches: true
                //},
            });
        }
    }
}