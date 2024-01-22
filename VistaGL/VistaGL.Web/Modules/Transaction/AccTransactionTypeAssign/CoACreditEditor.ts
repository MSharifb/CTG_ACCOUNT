
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass([Serenity.IGetEditValue, Serenity.ISetEditValue])
    @Serenity.Decorators.editor()
    @Serenity.Decorators.element("<div/>")
    export class CoACreditEditor extends Serenity.Widget<any>
    implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchInput: HTMLInputElement;
        jsTreeDiv: HTMLDivElement;

        constructor(container: JQuery) {
            super(container);
            this.searchInput = document.createElement('input');
            this.searchInput.type = 'text';
            this.searchInput.id = 'searchInputCredit';
            this.searchInput.style.width = '100%';

            this.jsTreeDiv = document.createElement('div');
            this.jsTreeDiv.id = 'jsTreeDivCredit';
            this.element.append(this.searchInput);
            this.element.append(this.jsTreeDiv);

        }

        public getEditValue(property, target) {
            target[property.name] = this.value;
        }

        public setEditValue(source, property) {
            this.value = source[property.name];
        }

        protected CreditItems: AccTransactionTypeAssignRow[] = [];

        public get value(): AccTransactionTypeAssignRow[] {
            var selectedNodes = $('#jsTreeDivCredit').jstree().get_checked(true);
            //   var menuPermissionNodesOnly = selectedNodes.filter(f => f.id.startsWith('menuPermission_'));

            for (var i = 0; i < selectedNodes.length; i++) {
                var menuPermission = selectedNodes[i].data;
                //console.log(menuPermission);
                var CreditItems = this.CreditItems.filter(f => f.CoaId == menuPermission.Id)
                if (CreditItems.length == 0) {
                    this.CreditItems.push({ CoaId: menuPermission.Id, TrType: "C" });
                }

                //else if (CreditItems.length == 1) {
                //    CreditItems[0].Granted = true;
                //}
                //else {
                //    Q.alert('Invalid Data.');
                //}
            }

            return this.CreditItems;
        }

        public set value(value: AccTransactionTypeAssignRow[]) {
            value = value || [];
            this.CreditItems = value;

            var apps = Configurations.AccChartofAccountsRow.getLookup().items;
            //var modules = ModuleRow.getLookup().items;
            //var menus = MenuRow.getLookup().items;
            //var menuPermissions = MenuPermissionRow.getLookup().items;

            var treeData = [];

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
                    var moduleTreeId = 'Credit_' + module.Id;
                    var moduleParentAccountId = "";
                    var isSelected = value.filter(f => f.CoaId == module.Id
                        && f.TrType == "C").length > 0;

                    if (module.ParentAccountId != undefined) {

                        moduleParentAccountId = 'Credit_' + module.ParentAccountId;
                        treeData.push({
                            id: moduleTreeId,
                            parent: moduleParentAccountId,
                            text: module.AccountName,
                            icon: false, state: { opened: false, selected: isSelected },
                            data: module
                        });
                    }
                    else {
                        treeData.push({
                            id: moduleTreeId,
                            text: module.AccountName,
                            parent: "#",
                            icon: false, state: { opened: false }
                        });
                    }
                   // console.log(moduleParentAccountId);
                  

                    ////Menu - open tree
                    //var moduleMenus = menus.filter(f => f.ModuleId == module.Id);
                    //for (var menu of moduleMenus) {
                    //    var menuTreeId = 'menu_' + menu.Id;
                    //    var menuParentTreeId = menu.ParentId != undefined || menu.ParentId != null ? ('menu_' + menu.ParentId) : moduleTreeId;

                    //    treeData.push({
                    //        id: menuTreeId,
                    //        parent: menuParentTreeId,
                    //        text: menu.Name,
                    //        icon: false, state: { opened: false }
                    //    });

                    //    //MenuPermisson
                    //    var _menuPermissions = menuPermissions.filter(f => f.MenuId == menu.Id);

                    //    for (var menuPermission of _menuPermissions) {
                    //        var isSelected = value.filter(f => f.MenuId == menuPermission.MenuId
                    //            && f.PermissionId == menuPermission.PermissionId
                    //            && f.Granted == true).length > 0;
                    //        treeData.push({
                    //            id: 'menuPermission_' + menuPermission.Id,
                    //            parent: menuTreeId,
                    //            text: menuPermission.PermissionName,
                    //            icon: false, state: { opened: false, selected: isSelected },
                    //            data: menuPermission
                    //        });
                    //    }
                    //}
            }

          //  }

               // console.log(treeData);
                $('#searchInputCredit').keyup( (e) => {

                var searchString = (e.currentTarget as HTMLInputElement).value;
                $('#jsTreeDivCredit').jstree('search', searchString);
            });

            $('#jsTreeDivCredit').jstree({
                plugins: ['checkbox',"search"],
                core: {
                    data: treeData
                },
                search: {
                    case_insensitive: true,
                    show_only_matches: true
                },
            });
        }
    }
}