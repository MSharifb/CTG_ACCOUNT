/// <reference path="../../Modules/_Ext/_q/_q.d.ts" />
/// <reference path="../typings/serenity/Serenity.CoreLib.d.ts" />
/// <reference path="../typings/jspdf/jspdf.autotable.d.ts" />
/// <reference path="../typings/jstree/jstree.d.ts" />
/// <reference types="jquery" />
/// <reference types="jqueryui" />
declare namespace _Ext {
    class GridBase<TItem, TOptions> extends Serenity.EntityGrid<TItem, TOptions> {
        protected get_ExtGridOptions(): ExtGridOptions;
        isReadOnly: boolean;
        isRequired: boolean;
        isAutosized: boolean;
        isChildGrid: boolean;
        nextRowNumber: number;
        autoColumnSizePlugin: any;
        rowSelection: Serenity.GridRowSelectionMixin;
        pickerDialog: GridItemPickerDialog;
        constructor(container: JQuery, options?: TOptions);
        protected markupReady(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getReportRequest(): any;
        protected getColumns(): Slick.Column[];
        protected createSlickGrid(): Slick.Grid;
        resetColumns(columns: Slick.Column[]): void;
        resizeAllCulumn(): void;
        protected getSlickOptions(): Slick.GridOptions;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected onInlineActionClick(target: JQuery, recordId: any, item: TItem): void;
        protected resetRowNumber(): void;
        protected setGrouping(groupInfo: Slick.GroupInfo<TItem>[]): void;
        protected onViewProcessData(response: Serenity.ListResponse<TItem>): Serenity.ListResponse<TItem>;
        initDialog(dialog: DialogBase<TItem, any>): void;
        readonly selectedItems: TItem[];
        selectedKeys: any[];
    }
}
declare namespace _Ext {
    class ReportGridBase<TItem, TOptions> extends _Ext.GridBase<TItem, TOptions> {
        protected getButtons(): Serenity.ToolButton[];
        protected getColumns(): Slick.Column[];
    }
}
declare namespace _Ext {
    class ReportPanelBase<TRequest> extends Serenity.PropertyPanel<TRequest, any> {
        protected getTemplateName(): string;
        protected getReportTitle(): string;
        protected getReportKey(): string;
        protected getReportRequest(): TRequest;
        constructor(container: JQuery);
    }
}
declare namespace _Ext {
    class DialogBase<TEntity, TOptions> extends Serenity.EntityDialog<TEntity, TOptions> {
        protected get_ExtDialogOptions(): ExtDialogOptions;
        private loadedState;
        isReadOnly: boolean;
        protected form: any;
        constructor(opt?: any);
        protected updateInterface(): void;
        protected onDialogOpen(): void;
        protected onDialogClose(): void;
        protected setReadOnly(value: boolean): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
        onRefreshClick(): void;
        protected getSaveState(): string;
        protected onSaveSuccess(response: any): void;
        loadResponse(data: any): void;
        maximize(): void;
        fullContentArea(): void;
        setDialogSize(width?: any, height?: any, top?: any, left?: any, $content?: any): void;
        onAfterSetDialogSize(): void;
        onAfterDialogClose(entity: TEntity): void;
        parentGrid: GridBase<TEntity, any>;
    }
}
declare namespace _Ext {
    class GridItemPickerDialog extends Serenity.TemplatedDialog<GridItemPickerEditorOptions> {
        getTemplate(): string;
        checkGrid: GridBase<any, GridItemPickerEditorOptions>;
        readonly selectedItems: any[];
        constructor(options: GridItemPickerEditorOptions);
        onSuccess: (selectedItems: any) => void;
        getDialogOptions(): JQueryUI.DialogOptions;
    }
}
declare namespace _Ext {
    class EditorDialogBase<TEntity> extends DialogBase<TEntity, any> {
        protected get_ExtDialogOptions(): ExtDialogOptions;
        protected getIdProperty(): string;
        onSave: (options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void) => void;
        onDelete: (options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void) => void;
        destroy(): void;
        protected updateInterface(): void;
        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void): void;
        protected deleteHandler(options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void): void;
        parentEditor: GridEditorBase<TEntity>;
    }
}
declare namespace _Ext {
    class GridEditorBase<TEntity> extends _Ext.GridBase<TEntity, any> implements Serenity.IGetEditValue, Serenity.ISetEditValue, Serenity.IReadOnly {
        protected get_ExtGridOptions(): ExtGridOptions;
        protected getIdProperty(): string;
        protected nextId: number;
        constructor(container: JQuery);
        private sortGridFunction(grid, column, field);
        protected getQuickFilters(): any[];
        protected id(entity: TEntity): any;
        protected save(opt: Serenity.ServiceOptions<any>, callback: (r: Serenity.ServiceResponse) => void): void;
        protected deleteEntity(id: number): boolean;
        protected validateEntity(row: TEntity, id: number): boolean;
        protected getNewEntity(): TEntity;
        protected getButtons(): Serenity.ToolButton[];
        protected addButtonClick(): void;
        protected editItem(entityOrId: any): void;
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        value: TEntity[];
        protected getGridCanLoad(): boolean;
        protected usePager(): boolean;
        protected getInitialTitle(): any;
        private searchText;
        protected createToolbarExtensions(): void;
        protected onViewFilter(row: any): boolean;
        private matchContains(item);
        protected enableFiltering(): boolean;
        protected onViewSubmit(): boolean;
        get_readOnly(): boolean;
        set_readOnly(value: boolean): void;
        protected getSlickOptions(): Slick.GridOptions;
        parentDialog: DialogBase<any, any>;
        onItemsChanged(): void;
        onBeforeGetValue(items: TEntity[]): void;
    }
}
declare namespace _Ext {
    enum AuditActionType {
        Insert = 1,
        Update = 2,
        Delete = 3,
    }
}
declare namespace _Ext {
}
declare namespace _Ext {
    interface AuditLogForm {
        EntityTableName: Serenity.StringEditor;
        VersionNo: Serenity.IntegerEditor;
        UserId: Serenity.LookupEditor;
        ActionType: Serenity.EnumEditor;
        ActionDate: Serenity.DateTimeEditor;
        EntityId: Serenity.IntegerEditor;
        OldEntity: Serenity.StringEditor;
        NewEntity: Serenity.StringEditor;
        Differences: StaticTextBlock;
        IpAddress: Serenity.StringEditor;
        SessionId: Serenity.StringEditor;
    }
    class AuditLogForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace _Ext {
    interface AuditLogRow {
        Id?: number;
        VersionNo?: number;
        UserId?: number;
        ActionType?: AuditActionType;
        ActionDate?: string;
        EntityTableName?: string;
        EntityId?: number;
        OldEntity?: string;
        NewEntity?: string;
        IpAddress?: string;
        SessionId?: string;
    }
    namespace AuditLogRow {
        const idProperty = "Id";
        const nameProperty = "EntityTableName";
        const localTextPrefix = "_Ext.AuditLog";
        const enum Fields {
            Id = "Id",
            VersionNo = "VersionNo",
            UserId = "UserId",
            ActionType = "ActionType",
            ActionDate = "ActionDate",
            EntityTableName = "EntityTableName",
            EntityId = "EntityId",
            OldEntity = "OldEntity",
            NewEntity = "NewEntity",
            IpAddress = "IpAddress",
            SessionId = "SessionId",
        }
    }
}
declare namespace _Ext {
    namespace AuditLogService {
        const baseUrl = "_Ext/AuditLog";
        function Create(request: Serenity.SaveRequest<AuditLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AuditLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AuditLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AuditLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "_Ext/AuditLog/Create",
            Update = "_Ext/AuditLog/Update",
            Delete = "_Ext/AuditLog/Delete",
            Retrieve = "_Ext/AuditLog/Retrieve",
            List = "_Ext/AuditLog/List",
        }
    }
}
declare namespace _Ext {
    interface AuditLogViewerRequest extends Serenity.ServiceRequest {
        FormKey?: string;
        EntityId?: number;
    }
}
declare namespace _Ext {
    interface AuditLogViewerResponse extends Serenity.ServiceResponse {
        EntityVersions?: AuditLogRow[];
    }
}
declare namespace _Ext {
    namespace AuditLogViewerService {
        const baseUrl = "AuditLogViewer";
        function List(request: AuditLogViewerRequest, onSuccess?: (response: AuditLogViewerResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "AuditLogViewer/List",
        }
    }
}
declare namespace _Ext.DevTools {
    interface SergenConnection {
        Key?: string;
    }
}
declare namespace _Ext.DevTools {
    interface SergenGenerateOptions {
        Row?: boolean;
        Service?: boolean;
        UI?: boolean;
    }
}
declare namespace _Ext.DevTools {
    interface SergenGenerateRequest extends Serenity.ServiceRequest {
        ConnectionKey?: string;
        Table?: SergenTable;
        GenerateOptions?: SergenGenerateOptions;
    }
}
declare namespace _Ext.DevTools {
    interface SergenListTablesRequest extends Serenity.ServiceRequest {
        ConnectionKey?: string;
    }
}
declare namespace _Ext.DevTools {
    namespace SergenService {
        const baseUrl = "DevTools/Sergen";
        function ListConnections(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<SergenConnection>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListTables(request: SergenListTablesRequest, onSuccess?: (response: Serenity.ListResponse<SergenTable>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Generate(request: SergenGenerateRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            ListConnections = "DevTools/Sergen/ListConnections",
            ListTables = "DevTools/Sergen/ListTables",
            Generate = "DevTools/Sergen/Generate",
        }
    }
}
declare namespace _Ext.DevTools {
    interface SergenTable {
        Tablename?: string;
        Identifier?: string;
        Module?: string;
        PermissionKey?: string;
    }
}
declare namespace _Ext {
    interface EntityReportRequest extends Serenity.RetrieveRequest {
        ReportKey?: string;
        ReportServiceMethodName?: string;
        ReportDesignPath?: string;
    }
}
declare namespace _Ext {
    interface ListReportRequest extends Serenity.ListRequest {
        ReportKey?: string;
        ReportServiceMethodName?: string;
        ListExcelServiceMethodName?: string;
        ReportDesignPath?: string;
        EqualityFilterWithTextValue?: {
            [key: string]: string;
        };
    }
}
declare namespace _Ext {
    enum Months {
        January = 0,
        February = 1,
        March = 2,
        April = 3,
        May = 4,
        June = 5,
        July = 6,
        August = 7,
        September = 8,
        October = 9,
        November = 10,
        December = 11,
    }
}
declare namespace _Ext {
    interface ReplaceRowForm {
        DeletedEntityName: Serenity.StringEditor;
        ReplaceWithEntityId: EmptyLookupEditor;
    }
    class ReplaceRowForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace _Ext {
    interface ReplaceRowRequest extends Serenity.ServiceRequest {
        FormKey?: string;
        IdProperty?: string;
        NameProperty?: string;
        EntityTypeTitle?: string;
        DeletedEntityId?: number;
        DeletedEntityName?: string;
        ReplaceWithEntityId?: number;
    }
}
declare namespace _Ext {
    interface ReplaceRowResponse extends Serenity.ServiceResponse {
    }
}
declare namespace _Ext {
    namespace ReplaceRowService {
        const baseUrl = "ReplaceRow";
        function Replace(request: ReplaceRowRequest, onSuccess?: (response: ReplaceRowResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Replace = "ReplaceRow/Replace",
        }
    }
}
declare namespace _Ext {
    enum TimeUoM {
        Hour = 1,
        Day = 2,
        Week = 3,
        Month = 4,
        CalenderMonth = 5,
        Year = 6,
    }
}
declare namespace VistaGL {
    enum AccHeadTypeMappingEnum {
        SD = 1,
        IncomeTax = 2,
        VAT = 3,
        Advance = 4,
        WIP = 5,
    }
}
declare namespace VistaGL.Administration {
}
declare namespace VistaGL.Administration {
    interface LanguageForm {
        LanguageId: Serenity.StringEditor;
        LanguageName: Serenity.StringEditor;
    }
    class LanguageForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Administration {
    interface LanguageRow {
        Id?: number;
        LanguageId?: string;
        LanguageName?: string;
    }
    namespace LanguageRow {
        const idProperty = "Id";
        const nameProperty = "LanguageName";
        const localTextPrefix = "Administration.Language";
        const lookupKey = "Administration.Language";
        function getLookup(): Q.Lookup<LanguageRow>;
        const enum Fields {
            Id = "Id",
            LanguageId = "LanguageId",
            LanguageName = "LanguageName",
        }
    }
}
declare namespace VistaGL.Administration {
    namespace LanguageService {
        const baseUrl = "Administration/Language";
        function Create(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Language/Create",
            Update = "Administration/Language/Update",
            Delete = "Administration/Language/Delete",
            Retrieve = "Administration/Language/Retrieve",
            List = "Administration/Language/List",
        }
    }
}
declare namespace VistaGL.Administration {
}
declare namespace VistaGL.Administration {
    interface RoleForm {
        RoleName: Serenity.StringEditor;
    }
    class RoleForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Administration {
    interface RolePermissionListRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace VistaGL.Administration {
    interface RolePermissionListResponse extends Serenity.ListResponse<string> {
    }
}
declare namespace VistaGL.Administration {
    interface RolePermissionRow {
        RolePermissionId?: number;
        RoleId?: number;
        PermissionKey?: string;
        RoleRoleName?: string;
    }
    namespace RolePermissionRow {
        const idProperty = "RolePermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.RolePermission";
        const enum Fields {
            RolePermissionId = "RolePermissionId",
            RoleId = "RoleId",
            PermissionKey = "PermissionKey",
            RoleRoleName = "RoleRoleName",
        }
    }
}
declare namespace VistaGL.Administration {
    namespace RolePermissionService {
        const baseUrl = "Administration/RolePermission";
        function Update(request: RolePermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: RolePermissionListRequest, onSuccess?: (response: RolePermissionListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/RolePermission/Update",
            List = "Administration/RolePermission/List",
        }
    }
}
declare namespace VistaGL.Administration {
    interface RolePermissionUpdateRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: string[];
    }
}
declare namespace VistaGL.Administration {
    interface RoleRow {
        RoleId?: number;
        RoleName?: string;
    }
    namespace RoleRow {
        const idProperty = "RoleId";
        const nameProperty = "RoleName";
        const localTextPrefix = "Administration.Role";
        const lookupKey = "Administration.Role";
        function getLookup(): Q.Lookup<RoleRow>;
        const enum Fields {
            RoleId = "RoleId",
            RoleName = "RoleName",
        }
    }
}
declare namespace VistaGL.Administration {
    namespace RoleService {
        const baseUrl = "Administration/Role";
        function Create(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Role/Create",
            Update = "Administration/Role/Update",
            Delete = "Administration/Role/Delete",
            Retrieve = "Administration/Role/Retrieve",
            List = "Administration/Role/List",
        }
    }
}
declare namespace VistaGL.Administration {
    interface TranslationItem {
        Key?: string;
        SourceText?: string;
        TargetText?: string;
        CustomText?: string;
    }
}
declare namespace VistaGL.Administration {
    interface TranslationListRequest extends Serenity.ListRequest {
        SourceLanguageID?: string;
        TargetLanguageID?: string;
    }
}
declare namespace VistaGL.Administration {
    namespace TranslationService {
        const baseUrl = "Administration/Translation";
        function List(request: TranslationListRequest, onSuccess?: (response: Serenity.ListResponse<TranslationItem>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: TranslationUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "Administration/Translation/List",
            Update = "Administration/Translation/Update",
        }
    }
}
declare namespace VistaGL.Administration {
    interface TranslationUpdateRequest extends Serenity.ServiceRequest {
        TargetLanguageID?: string;
        Translations?: {
            [key: string]: string;
        };
    }
}
declare namespace VistaGL.Administration {
}
declare namespace VistaGL.Administration {
    interface UserForm {
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        UserImage: Serenity.ImageUploadEditor;
        Password: Serenity.PasswordEditor;
        PasswordConfirm: Serenity.PasswordEditor;
        Source: Serenity.StringEditor;
    }
    class UserForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Administration {
    interface UserPermissionListRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace VistaGL.Administration {
    interface UserPermissionRow {
        UserPermissionId?: number;
        UserId?: number;
        PermissionKey?: string;
        Granted?: boolean;
        Username?: string;
        User?: string;
    }
    namespace UserPermissionRow {
        const idProperty = "UserPermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.UserPermission";
        const enum Fields {
            UserPermissionId = "UserPermissionId",
            UserId = "UserId",
            PermissionKey = "PermissionKey",
            Granted = "Granted",
            Username = "Username",
            User = "User",
        }
    }
}
declare namespace VistaGL.Administration {
    namespace UserPermissionService {
        const baseUrl = "Administration/UserPermission";
        function Update(request: UserPermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<UserPermissionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListRolePermissions(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListPermissionKeys(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/UserPermission/Update",
            List = "Administration/UserPermission/List",
            ListRolePermissions = "Administration/UserPermission/ListRolePermissions",
            ListPermissionKeys = "Administration/UserPermission/ListPermissionKeys",
        }
    }
}
declare namespace VistaGL.Administration {
    interface UserPermissionUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: UserPermissionRow[];
    }
}
declare namespace VistaGL.Administration {
    interface UserRoleListRequest extends Serenity.ServiceRequest {
        UserID?: number;
    }
}
declare namespace VistaGL.Administration {
    interface UserRoleListResponse extends Serenity.ListResponse<number> {
    }
}
declare namespace VistaGL.Administration {
    interface UserRoleRow {
        UserRoleId?: number;
        UserId?: number;
        RoleId?: number;
        Username?: string;
        User?: string;
    }
    namespace UserRoleRow {
        const idProperty = "UserRoleId";
        const localTextPrefix = "Administration.UserRole";
        const enum Fields {
            UserRoleId = "UserRoleId",
            UserId = "UserId",
            RoleId = "RoleId",
            Username = "Username",
            User = "User",
        }
    }
}
declare namespace VistaGL.Administration {
    namespace UserRoleService {
        const baseUrl = "Administration/UserRole";
        function Update(request: UserRoleUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserRoleListRequest, onSuccess?: (response: UserRoleListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/UserRole/Update",
            List = "Administration/UserRole/List",
        }
    }
}
declare namespace VistaGL.Administration {
    interface UserRoleUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Roles?: number[];
    }
}
declare namespace VistaGL.Administration {
    interface UserRow {
        UserId?: number;
        Username?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        DisplayName?: string;
        Email?: string;
        UserImage?: string;
        LastDirectoryUpdate?: string;
        IsActive?: number;
        Password?: string;
        PasswordConfirm?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }
    namespace UserRow {
        const idProperty = "UserId";
        const isActiveProperty = "IsActive";
        const nameProperty = "Username";
        const localTextPrefix = "Administration.User";
        const enum Fields {
            UserId = "UserId",
            Username = "Username",
            Source = "Source",
            PasswordHash = "PasswordHash",
            PasswordSalt = "PasswordSalt",
            DisplayName = "DisplayName",
            Email = "Email",
            UserImage = "UserImage",
            LastDirectoryUpdate = "LastDirectoryUpdate",
            IsActive = "IsActive",
            Password = "Password",
            PasswordConfirm = "PasswordConfirm",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate",
        }
    }
}
declare namespace VistaGL.Administration {
    namespace UserService {
        const baseUrl = "Administration/User";
        function Create(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Undelete(request: Serenity.UndeleteRequest, onSuccess?: (response: Serenity.UndeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/User/Create",
            Update = "Administration/User/Update",
            Delete = "Administration/User/Delete",
            Undelete = "Administration/User/Undelete",
            Retrieve = "Administration/User/Retrieve",
            List = "Administration/User/List",
        }
    }
}
declare namespace VistaGL {
    enum ApprovalStatus {
        Draft = 1,
        Cancel = 2,
        Submit = 3,
        Regret = 4,
        Recommend = 5,
        Approved = 6,
    }
}
declare namespace VistaGL {
    enum ApprovalStepType {
        Approval = 1,
        Recommendation = 2,
        Both = 3,
    }
}
declare namespace VistaGL {
    enum BudgetTypeenum {
        Proposed = 1,
        Revised = 2,
    }
}
declare namespace VistaGL {
    interface CheckIsApproverResponse extends Serenity.ServiceResponse {
        IsApprover?: boolean;
    }
}
declare namespace VistaGL {
    enum COAMapping {
        Bank = 0,
        Cash = 1,
        Other = 2,
    }
}
declare namespace VistaGL.Common.Pages {
    interface UploadResponse extends Serenity.ServiceResponse {
        TemporaryFile?: string;
        Size?: number;
        IsImage?: boolean;
        Width?: number;
        Height?: number;
    }
}
declare namespace VistaGL.Common {
    interface UserPreferenceRetrieveRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
    }
}
declare namespace VistaGL.Common {
    interface UserPreferenceRetrieveResponse extends Serenity.ServiceResponse {
        Value?: string;
    }
}
declare namespace VistaGL.Common {
    interface UserPreferenceRow {
        UserPreferenceId?: number;
        UserId?: number;
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
    namespace UserPreferenceRow {
        const idProperty = "UserPreferenceId";
        const nameProperty = "Name";
        const localTextPrefix = "Common.UserPreference";
        const enum Fields {
            UserPreferenceId = "UserPreferenceId",
            UserId = "UserId",
            PreferenceType = "PreferenceType",
            Name = "Name",
            Value = "Value",
        }
    }
}
declare namespace VistaGL.Common {
    namespace UserPreferenceService {
        const baseUrl = "Common/UserPreference";
        function Update(request: UserPreferenceUpdateRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: UserPreferenceRetrieveRequest, onSuccess?: (response: UserPreferenceRetrieveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Common/UserPreference/Update",
            Retrieve = "Common/UserPreference/Retrieve",
        }
    }
}
declare namespace VistaGL.Common {
    interface UserPreferenceUpdateRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccAccountingPeriodInformationForm {
        YearName: Serenity.StringEditor;
        PeriodStartDate: Serenity.DateEditor;
        PeriodEndDate: Serenity.DateEditor;
        IsActive: Serenity.BooleanEditor;
        IsClosed: Serenity.BooleanEditor;
    }
    class AccAccountingPeriodInformationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccAccountingPeriodInformationRow {
        Id?: number;
        IsActive?: boolean;
        IsClosed?: boolean;
        PeriodEndDate?: string;
        PeriodStartDate?: string;
        YearName?: string;
        FundControlInformationId?: number;
        FundControlInformationCode?: string;
        FundControlInformationFundControlName?: string;
        FundControlInformationRemarks?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccAccountingPeriodInformationRow {
        const idProperty = "Id";
        const nameProperty = "YearName";
        const localTextPrefix = "Configurations.AccAccountingPeriodInformation";
        const lookupKey = "Configurations.AccAccountingPeriodInformation";
        function getLookup(): Q.Lookup<AccAccountingPeriodInformationRow>;
        const enum Fields {
            Id = "Id",
            IsActive = "IsActive",
            IsClosed = "IsClosed",
            PeriodEndDate = "PeriodEndDate",
            PeriodStartDate = "PeriodStartDate",
            YearName = "YearName",
            FundControlInformationId = "FundControlInformationId",
            FundControlInformationCode = "FundControlInformationCode",
            FundControlInformationFundControlName = "FundControlInformationFundControlName",
            FundControlInformationRemarks = "FundControlInformationRemarks",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccAccountingPeriodInformationService {
        const baseUrl = "Configurations/AccAccountingPeriodInformation";
        function Create(request: Serenity.SaveRequest<AccAccountingPeriodInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccAccountingPeriodInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccAccountingPeriodInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccAccountingPeriodInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccAccountingPeriodInformation/Create",
            Update = "Configurations/AccAccountingPeriodInformation/Update",
            Delete = "Configurations/AccAccountingPeriodInformation/Delete",
            Retrieve = "Configurations/AccAccountingPeriodInformation/Retrieve",
            List = "Configurations/AccAccountingPeriodInformation/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccAdvanceDepositeReportForm {
        FinancialId: Serenity.LookupEditor;
        SubledgerId: Serenity.LookupEditor;
        OpeningBalance: Serenity.DecimalEditor;
        During: Serenity.DecimalEditor;
    }
    class AccAdvanceDepositeReportForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccAdvanceDepositeReportRow {
        Id?: number;
        FinancialId?: number;
        SubledgerId?: number;
        OpeningBalance?: number;
        During?: number;
        FinancialIsActive?: boolean;
        FinancialIsClosed?: boolean;
        FinancialPeriodEndDate?: string;
        FinancialPeriodStartDate?: string;
        FinancialYearName?: string;
        FinancialFundControlInformationId?: number;
        SubledgerCode?: string;
        SubledgerCodeCount?: number;
        SubledgerUserCode?: string;
        SubledgerIsInstitute?: boolean;
        SubledgerName?: string;
        SubledgerNameForBankAdviceLetter?: string;
        SubledgerPaAmmount?: number;
        SubledgerRemarks?: string;
        SubledgerParentId?: number;
        SubledgerCostCenterTypeId?: number;
        SubledgerEmpId?: number;
        SubledgerIsActive?: boolean;
        SubledgerEntityId?: number;
        SubledgerZoneInfoId?: number;
        SubledgerIsBudgetHead?: boolean;
        SubledgerBudgetGroupId?: number;
        SubledgerIsFixedAssetHead?: boolean;
        SubledgerIsFixedAssetDevWork?: boolean;
        SubledgerIsFixedAssetNonDevWork?: boolean;
        SubledgerDepreciationRate?: number;
        SubledgerBudgetCode?: string;
    }
    namespace AccAdvanceDepositeReportRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccAdvanceDepositeReport";
        const lookupKey = "Configurations.AccAdvanceDepositeReport";
        function getLookup(): Q.Lookup<AccAdvanceDepositeReportRow>;
        const enum Fields {
            Id = "Id",
            FinancialId = "FinancialId",
            SubledgerId = "SubledgerId",
            OpeningBalance = "OpeningBalance",
            During = "During",
            FinancialIsActive = "FinancialIsActive",
            FinancialIsClosed = "FinancialIsClosed",
            FinancialPeriodEndDate = "FinancialPeriodEndDate",
            FinancialPeriodStartDate = "FinancialPeriodStartDate",
            FinancialYearName = "FinancialYearName",
            FinancialFundControlInformationId = "FinancialFundControlInformationId",
            SubledgerCode = "SubledgerCode",
            SubledgerCodeCount = "SubledgerCodeCount",
            SubledgerUserCode = "SubledgerUserCode",
            SubledgerIsInstitute = "SubledgerIsInstitute",
            SubledgerName = "SubledgerName",
            SubledgerNameForBankAdviceLetter = "SubledgerNameForBankAdviceLetter",
            SubledgerPaAmmount = "SubledgerPaAmmount",
            SubledgerRemarks = "SubledgerRemarks",
            SubledgerParentId = "SubledgerParentId",
            SubledgerCostCenterTypeId = "SubledgerCostCenterTypeId",
            SubledgerEmpId = "SubledgerEmpId",
            SubledgerIsActive = "SubledgerIsActive",
            SubledgerEntityId = "SubledgerEntityId",
            SubledgerZoneInfoId = "SubledgerZoneInfoId",
            SubledgerIsBudgetHead = "SubledgerIsBudgetHead",
            SubledgerBudgetGroupId = "SubledgerBudgetGroupId",
            SubledgerIsFixedAssetHead = "SubledgerIsFixedAssetHead",
            SubledgerIsFixedAssetDevWork = "SubledgerIsFixedAssetDevWork",
            SubledgerIsFixedAssetNonDevWork = "SubledgerIsFixedAssetNonDevWork",
            SubledgerDepreciationRate = "SubledgerDepreciationRate",
            SubledgerBudgetCode = "SubledgerBudgetCode",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccAdvanceDepositeReportService {
        const baseUrl = "Configurations/AccAdvanceDepositeReport";
        function Create(request: Serenity.SaveRequest<AccAdvanceDepositeReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccAdvanceDepositeReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccAdvanceDepositeReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccAdvanceDepositeReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccAdvanceDepositeReport/Create",
            Update = "Configurations/AccAdvanceDepositeReport/Update",
            Delete = "Configurations/AccAdvanceDepositeReport/Delete",
            Retrieve = "Configurations/AccAdvanceDepositeReport/Retrieve",
            List = "Configurations/AccAdvanceDepositeReport/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccArDoubtfulDebtsForm {
        FinancialYearId: Serenity.LookupEditor;
        DoubtfulDebtsAmount: Serenity.DecimalEditor;
        Receivable: Serenity.DecimalEditor;
        Adjusted: Serenity.DecimalEditor;
    }
    class AccArDoubtfulDebtsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccArDoubtfulDebtsRow {
        Id?: number;
        FinancialYearId?: number;
        DoubtfulDebtsAmount?: number;
        Receivable?: number;
        Adjusted?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }
    namespace AccArDoubtfulDebtsRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccArDoubtfulDebts";
        const lookupKey = "Configurations.AccArDoubtfulDebts";
        function getLookup(): Q.Lookup<AccArDoubtfulDebtsRow>;
        const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            DoubtfulDebtsAmount = "DoubtfulDebtsAmount",
            Receivable = "Receivable",
            Adjusted = "Adjusted",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccArDoubtfulDebtsService {
        const baseUrl = "Configurations/AccArDoubtfulDebts";
        function Create(request: Serenity.SaveRequest<AccArDoubtfulDebtsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccArDoubtfulDebtsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccArDoubtfulDebtsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccArDoubtfulDebtsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccArDoubtfulDebts/Create",
            Update = "Configurations/AccArDoubtfulDebts/Update",
            Delete = "Configurations/AccArDoubtfulDebts/Delete",
            Retrieve = "Configurations/AccArDoubtfulDebts/Retrieve",
            List = "Configurations/AccArDoubtfulDebts/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccBankAccountInformationForm {
        Id: Serenity.IntegerEditor;
        BankId: Serenity.LookupEditor;
        BankBranchId: Serenity.LookupEditor;
        CoaId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        AccountNumber: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        AccountDescription: Serenity.TextAreaEditor;
    }
    class AccBankAccountInformationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccBankAccountInformationRow {
        Id?: number;
        OpeningBalance?: number;
        OpeningDate?: string;
        AccountDescription?: string;
        AccountName?: string;
        AccountNumber?: string;
        Code?: string;
        CoaId?: number;
        BankId?: number;
        BankBranchId?: number;
        EntityId?: number;
        ZoneInfoId?: number;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaAccountGroup?: string;
        CoaAccountName?: string;
        CoaAccountNameBangla?: string;
        CoaCoaMapping?: string;
        CoaIsBillRef?: number;
        CoaIsBudgetHead?: number;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaLevel?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaOpeningBalance?: number;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaFundControlId?: number;
        CoaParentAccountId?: number;
        BankBankName?: string;
        BankCode?: string;
        BankBranchAddress?: string;
        BankBranchBranchName?: string;
        BankBranchCode?: string;
        BankBranchContacts?: string;
        BankBranchEmail?: string;
        BankBranchBankId?: number;
        EntityCode?: string;
        EntityFundControlName?: string;
        EntityRemarks?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBankAccountInformationRow {
        const idProperty = "Id";
        const nameProperty = "AccountNumber";
        const localTextPrefix = "Configurations.AccBankAccountInformation";
        const lookupKey = "Configurations.AccBankAccountInformation";
        function getLookup(): Q.Lookup<AccBankAccountInformationRow>;
        const enum Fields {
            Id = "Id",
            OpeningBalance = "OpeningBalance",
            OpeningDate = "OpeningDate",
            AccountDescription = "AccountDescription",
            AccountName = "AccountName",
            AccountNumber = "AccountNumber",
            Code = "Code",
            CoaId = "CoaId",
            BankId = "BankId",
            BankBranchId = "BankBranchId",
            EntityId = "EntityId",
            ZoneInfoId = "ZoneInfoId",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountName = "CoaAccountName",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsBillRef = "CoaIsBillRef",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaLevel = "CoaLevel",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaFundControlId = "CoaFundControlId",
            CoaParentAccountId = "CoaParentAccountId",
            BankBankName = "BankBankName",
            BankCode = "BankCode",
            BankBranchAddress = "BankBranchAddress",
            BankBranchBranchName = "BankBranchBranchName",
            BankBranchCode = "BankBranchCode",
            BankBranchContacts = "BankBranchContacts",
            BankBranchEmail = "BankBranchEmail",
            BankBranchBankId = "BankBranchBankId",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
            EntityRemarks = "EntityRemarks",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccBankAccountInformationService {
        const baseUrl = "Configurations/AccBankAccountInformation";
        function Create(request: Serenity.SaveRequest<AccBankAccountInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBankAccountInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBankAccountInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBankAccountInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccBankAccountInformation/Create",
            Update = "Configurations/AccBankAccountInformation/Update",
            Delete = "Configurations/AccBankAccountInformation/Delete",
            Retrieve = "Configurations/AccBankAccountInformation/Retrieve",
            List = "Configurations/AccBankAccountInformation/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccBankAdviceLetterTemplateForm {
        Subject: Serenity.StringEditor;
        Body1: Serenity.TextAreaEditor;
        Body2: Serenity.TextAreaEditor;
    }
    class AccBankAdviceLetterTemplateForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccBankAdviceLetterTemplateRow {
        Id?: number;
        Subject?: string;
        Body1?: string;
        Body2?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBankAdviceLetterTemplateRow {
        const idProperty = "Id";
        const nameProperty = "Subject";
        const localTextPrefix = "Configurations.AccBankAdviceLetterTemplate";
        const lookupKey = "Configurations.AccBankAdviceLetterTemplate";
        function getLookup(): Q.Lookup<AccBankAdviceLetterTemplateRow>;
        const enum Fields {
            Id = "Id",
            Subject = "Subject",
            Body1 = "Body1",
            Body2 = "Body2",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccBankAdviceLetterTemplateService {
        const baseUrl = "Configurations/AccBankAdviceLetterTemplate";
        function Create(request: Serenity.SaveRequest<AccBankAdviceLetterTemplateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBankAdviceLetterTemplateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBankAdviceLetterTemplateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBankAdviceLetterTemplateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccBankAdviceLetterTemplate/Create",
            Update = "Configurations/AccBankAdviceLetterTemplate/Update",
            Delete = "Configurations/AccBankAdviceLetterTemplate/Delete",
            Retrieve = "Configurations/AccBankAdviceLetterTemplate/Retrieve",
            List = "Configurations/AccBankAdviceLetterTemplate/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccBankBranchInformationForm {
        BranchName: Serenity.StringEditor;
        Address: Serenity.TextAreaEditor;
        Contacts: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        Code: Serenity.StringEditor;
    }
    class AccBankBranchInformationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccBankBranchInformationRow {
        Id?: number;
        BranchName?: string;
        Address?: string;
        Contacts?: string;
        Email?: string;
        Code?: string;
        BankId?: number;
        BankBankName?: string;
        BankCode?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBankBranchInformationRow {
        const idProperty = "Id";
        const nameProperty = "BranchName";
        const localTextPrefix = "Configurations.AccBankBranchInformation";
        const lookupKey = "Configurations.AccBankBranchInformation";
        function getLookup(): Q.Lookup<AccBankBranchInformationRow>;
        const enum Fields {
            Id = "Id",
            BranchName = "BranchName",
            Address = "Address",
            Contacts = "Contacts",
            Email = "Email",
            Code = "Code",
            BankId = "BankId",
            BankBankName = "BankBankName",
            BankCode = "BankCode",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccBankBranchInformationService {
        const baseUrl = "Configurations/AccBankBranchInformation";
        function Create(request: Serenity.SaveRequest<AccBankBranchInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBankBranchInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBankBranchInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBankBranchInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccBankBranchInformation/Create",
            Update = "Configurations/AccBankBranchInformation/Update",
            Delete = "Configurations/AccBankBranchInformation/Delete",
            Retrieve = "Configurations/AccBankBranchInformation/Retrieve",
            List = "Configurations/AccBankBranchInformation/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccBankInformationForm {
        BankName: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        BankBranchInformations: AccBankBranchInformationEditor;
    }
    class AccBankInformationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccBankInformationRow {
        Id?: number;
        BankName?: string;
        Code?: string;
        BankBranchInformations?: AccBankBranchInformationRow[];
        ZoneInfoId?: number;
        ZoneInfoZoneName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBankInformationRow {
        const idProperty = "Id";
        const nameProperty = "BankName";
        const localTextPrefix = "Configurations.AccBankInformation";
        const lookupKey = "Configurations.AccBankInformation";
        function getLookup(): Q.Lookup<AccBankInformationRow>;
        const enum Fields {
            Id = "Id",
            BankName = "BankName",
            Code = "Code",
            BankBranchInformations = "BankBranchInformations",
            ZoneInfoId = "ZoneInfoId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccBankInformationService {
        const baseUrl = "Configurations/AccBankInformation";
        function Create(request: Serenity.SaveRequest<AccBankInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBankInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBankInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBankInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccBankInformation/Create",
            Update = "Configurations/AccBankInformation/Update",
            Delete = "Configurations/AccBankInformation/Delete",
            Retrieve = "Configurations/AccBankInformation/Retrieve",
            List = "Configurations/AccBankInformation/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccBudgetGroupForm {
        ParentId: Serenity.LookupEditor;
        BudgetCode: Serenity.StringEditor;
        GroupName: Serenity.StringEditor;
        SortingOrder: Serenity.IntegerEditor;
        IsHideChildrenFromThisLevel: Serenity.BooleanEditor;
        IsActive: Serenity.BooleanEditor;
        Type: VoucherTemplateDrCrMappingEditor;
    }
    class AccBudgetGroupForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccBudgetGroupRow {
        Id?: number;
        ParentId?: number;
        GroupName?: string;
        SortingOrder?: number;
        IsActive?: boolean;
        ParentGroupName?: string;
        BudgetCode?: string;
        IsHideChildrenFromThisLevel?: boolean;
        Type?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBudgetGroupRow {
        const idProperty = "Id";
        const nameProperty = "GroupName";
        const localTextPrefix = "Configurations.AccBudgetGroup";
        const lookupKey = "Configurations.AccBudgetGroup";
        function getLookup(): Q.Lookup<AccBudgetGroupRow>;
        const enum Fields {
            Id = "Id",
            ParentId = "ParentId",
            GroupName = "GroupName",
            SortingOrder = "SortingOrder",
            IsActive = "IsActive",
            ParentGroupName = "ParentGroupName",
            BudgetCode = "BudgetCode",
            IsHideChildrenFromThisLevel = "IsHideChildrenFromThisLevel",
            Type = "Type",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccBudgetGroupService {
        const baseUrl = "Configurations/AccBudgetGroup";
        function Create(request: Serenity.SaveRequest<AccBudgetGroupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetGroupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetGroupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetGroupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccBudgetGroup/Create",
            Update = "Configurations/AccBudgetGroup/Update",
            Delete = "Configurations/AccBudgetGroup/Delete",
            Retrieve = "Configurations/AccBudgetGroup/Retrieve",
            List = "Configurations/AccBudgetGroup/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccBudgetZoneApproverForm {
        ZoneId: Serenity.LookupEditor;
        EmployeeId: Serenity.LookupEditor;
        EntityId: Serenity.IntegerEditor;
    }
    class AccBudgetZoneApproverForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccBudgetZoneApproverRow {
        Id?: number;
        EmployeeId?: number;
        ZoneId?: number;
        EntityId?: number;
        EmployeeEmpId?: string;
        EmployeeEmployeeInitial?: string;
        EmployeeTitleId?: number;
        EmployeeFirstName?: string;
        EmployeeMiddleName?: string;
        EmployeeLastName?: string;
        EmployeeFullName?: string;
        EmployeeFullNameBangla?: string;
        EmployeeDateofJoining?: string;
        EmployeeProvisionMonth?: number;
        EmployeeDateofConfirmation?: string;
        EmployeeDateofPosition?: string;
        EmployeeDesignationId?: number;
        EmployeeStatusDesignationId?: number;
        EmployeeDisciplineId?: number;
        EmployeeDivisionId?: number;
        EmployeeSectionId?: number;
        EmployeeSubSectionId?: number;
        EmployeeJobLocationId?: number;
        EmployeeResourceLevelId?: number;
        EmployeeStaffCategoryId?: number;
        ZoneZoneName?: string;
        EntityCode?: string;
        EntityFundControlName?: string;
    }
    namespace AccBudgetZoneApproverRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccBudgetZoneApprover";
        const lookupKey = "Configurations.AccBudgetZoneApprover";
        function getLookup(): Q.Lookup<AccBudgetZoneApproverRow>;
        const enum Fields {
            Id = "Id",
            EmployeeId = "EmployeeId",
            ZoneId = "ZoneId",
            EntityId = "EntityId",
            EmployeeEmpId = "EmployeeEmpId",
            EmployeeEmployeeInitial = "EmployeeEmployeeInitial",
            EmployeeTitleId = "EmployeeTitleId",
            EmployeeFirstName = "EmployeeFirstName",
            EmployeeMiddleName = "EmployeeMiddleName",
            EmployeeLastName = "EmployeeLastName",
            EmployeeFullName = "EmployeeFullName",
            EmployeeFullNameBangla = "EmployeeFullNameBangla",
            EmployeeDateofJoining = "EmployeeDateofJoining",
            EmployeeProvisionMonth = "EmployeeProvisionMonth",
            EmployeeDateofConfirmation = "EmployeeDateofConfirmation",
            EmployeeDateofPosition = "EmployeeDateofPosition",
            EmployeeDesignationId = "EmployeeDesignationId",
            EmployeeStatusDesignationId = "EmployeeStatusDesignationId",
            EmployeeDisciplineId = "EmployeeDisciplineId",
            EmployeeDivisionId = "EmployeeDivisionId",
            EmployeeSectionId = "EmployeeSectionId",
            EmployeeSubSectionId = "EmployeeSubSectionId",
            EmployeeJobLocationId = "EmployeeJobLocationId",
            EmployeeResourceLevelId = "EmployeeResourceLevelId",
            EmployeeStaffCategoryId = "EmployeeStaffCategoryId",
            ZoneZoneName = "ZoneZoneName",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccBudgetZoneApproverService {
        const baseUrl = "Configurations/AccBudgetZoneApprover";
        function Create(request: Serenity.SaveRequest<AccBudgetZoneApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetZoneApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetZoneApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetZoneApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccBudgetZoneApprover/Create",
            Update = "Configurations/AccBudgetZoneApprover/Update",
            Delete = "Configurations/AccBudgetZoneApprover/Delete",
            Retrieve = "Configurations/AccBudgetZoneApprover/Retrieve",
            List = "Configurations/AccBudgetZoneApprover/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccCashFlowAdvTaxReportForm {
        FinancialYearId: Serenity.LookupEditor;
        AdvTaxAmount: Serenity.DecimalEditor;
        Opening: Serenity.DecimalEditor;
    }
    class AccCashFlowAdvTaxReportForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccCashFlowAdvTaxReportRow {
        Id?: number;
        FinancialYearId?: number;
        AdvTaxAmount?: number;
        Opening?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }
    namespace AccCashFlowAdvTaxReportRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccCashFlowAdvTaxReport";
        const lookupKey = "Configurations.AccCashFlowAdvTaxReport";
        function getLookup(): Q.Lookup<AccCashFlowAdvTaxReportRow>;
        const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            AdvTaxAmount = "AdvTaxAmount",
            Opening = "Opening",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccCashFlowAdvTaxReportService {
        const baseUrl = "Configurations/AccCashFlowAdvTaxReport";
        function Create(request: Serenity.SaveRequest<AccCashFlowAdvTaxReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCashFlowAdvTaxReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCashFlowAdvTaxReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCashFlowAdvTaxReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccCashFlowAdvTaxReport/Create",
            Update = "Configurations/AccCashFlowAdvTaxReport/Update",
            Delete = "Configurations/AccCashFlowAdvTaxReport/Delete",
            Retrieve = "Configurations/AccCashFlowAdvTaxReport/Retrieve",
            List = "Configurations/AccCashFlowAdvTaxReport/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccChartofAccountsForm {
        FundControlId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        UserCode: Serenity.StringEditor;
        ParentAccountId: Serenity.LookupEditor;
        AccountCode: Serenity.StringEditor;
        Level: Serenity.IntegerEditor;
        AccountCodeCount: Serenity.IntegerEditor;
        AccountGroup: Serenity.StringEditor;
        AccOpeningBalance: Serenity.DecimalEditor;
        AccOpeningBalanceId: Serenity.IntegerEditor;
        MultiCurrencyId: Serenity.LookupEditor;
        EffectCashFlow: Serenity.EnumEditor;
        CoaMapping: COAMappingEditor;
        TaxId: Serenity.StringEditor;
        IsCostCenterAllocate: Serenity.BooleanEditor;
        IsBillRef: Serenity.BooleanEditor;
        IsControlhead: Serenity.BooleanEditor;
        NoaAccTypeId: AccHeadTypeMappingEditor;
        Remarks: Serenity.StringEditor;
        NoaAccTypeId2: Serenity.IntegerEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        BudgetCode: Serenity.StringEditor;
        BudgetGroupId: Serenity.LookupEditor;
        SortOrder: Serenity.IntegerEditor;
        ShowSumInReceiptPaymentReport: Serenity.BooleanEditor;
        IsHideChildrenFromThisLevel: Serenity.BooleanEditor;
        IsBalanceSheet: Serenity.BooleanEditor;
        BalanceSheetNotes: Serenity.IntegerEditor;
        IsIncomeExpenditure: Serenity.BooleanEditor;
        IncomeExpenditureNotes: Serenity.IntegerEditor;
    }
    class AccChartofAccountsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccChartofAccountsRow {
        Id?: number;
        AccountCode?: string;
        UserCode?: string;
        AccountCodeCount?: number;
        AccountGroup?: string;
        AccountName?: string;
        AccountNameBangla?: string;
        CoaMapping?: string;
        IsBillRef?: number;
        IsBudgetHead?: number;
        IsControlhead?: number;
        IsCostCenterAllocate?: number;
        Level?: number;
        MailingAddress?: string;
        MailingName?: string;
        Remarks?: string;
        TaxId?: string;
        UgcCode?: string;
        FundControlId?: number;
        ParentAccountId?: number;
        MultiCurrencyId?: number;
        MultiCurrencyCurrency?: string;
        EffectCashFlow?: number;
        NoaAccTypeId?: number;
        SortOrder?: number;
        ShowSumInReceiptPaymentReport?: boolean;
        IsHideChildrenFromThisLevel?: boolean;
        BudgetCode?: string;
        IsIncomeExpenditure?: boolean;
        BalanceSheetNotes?: number;
        IncomeExpenditureNotes?: number;
        BudgetGroupId?: number;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlRemarks?: string;
        ParentAccountAccountCode?: string;
        ParentAccountAccountCodeCount?: number;
        ParentAccountAccountGroup?: string;
        ParentAccountAccountName?: string;
        ParentAccountAccountNameBangla?: string;
        ParentAccountCoaMapping?: string;
        ParentAccountIsBudgetHead?: number;
        ParentAccountIsControlhead?: number;
        ParentAccountIsCostCenterAllocate?: number;
        ParentAccountLevel?: number;
        ParentAccountOpeningBalance?: number;
        ParentAccountRemarks?: string;
        ParentAccountFundControlId?: number;
        ParentAccountParentAccountId?: number;
        AccOpeningBalanceId?: number;
        OpeningBalance?: number;
        AccOpeningBalance?: number;
        iSCoAUsed?: number;
        NoaAccTypeId2?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccChartofAccountsRow {
        const idProperty = "Id";
        const nameProperty = "AccountName";
        const localTextPrefix = "Configurations.AccChartofAccounts";
        const lookupKey = "Configurations.AccChartofAccounts";
        function getLookup(): Q.Lookup<AccChartofAccountsRow>;
        const enum Fields {
            Id = "Id",
            AccountCode = "AccountCode",
            UserCode = "UserCode",
            AccountCodeCount = "AccountCodeCount",
            AccountGroup = "AccountGroup",
            AccountName = "AccountName",
            AccountNameBangla = "AccountNameBangla",
            CoaMapping = "CoaMapping",
            IsBillRef = "IsBillRef",
            IsBudgetHead = "IsBudgetHead",
            IsControlhead = "IsControlhead",
            IsCostCenterAllocate = "IsCostCenterAllocate",
            Level = "Level",
            MailingAddress = "MailingAddress",
            MailingName = "MailingName",
            Remarks = "Remarks",
            TaxId = "TaxId",
            UgcCode = "UgcCode",
            FundControlId = "FundControlId",
            ParentAccountId = "ParentAccountId",
            MultiCurrencyId = "MultiCurrencyId",
            MultiCurrencyCurrency = "MultiCurrencyCurrency",
            EffectCashFlow = "EffectCashFlow",
            NoaAccTypeId = "NoaAccTypeId",
            SortOrder = "SortOrder",
            ShowSumInReceiptPaymentReport = "ShowSumInReceiptPaymentReport",
            IsHideChildrenFromThisLevel = "IsHideChildrenFromThisLevel",
            BudgetCode = "BudgetCode",
            IsIncomeExpenditure = "IsIncomeExpenditure",
            BalanceSheetNotes = "BalanceSheetNotes",
            IncomeExpenditureNotes = "IncomeExpenditureNotes",
            BudgetGroupId = "BudgetGroupId",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlRemarks = "FundControlRemarks",
            ParentAccountAccountCode = "ParentAccountAccountCode",
            ParentAccountAccountCodeCount = "ParentAccountAccountCodeCount",
            ParentAccountAccountGroup = "ParentAccountAccountGroup",
            ParentAccountAccountName = "ParentAccountAccountName",
            ParentAccountAccountNameBangla = "ParentAccountAccountNameBangla",
            ParentAccountCoaMapping = "ParentAccountCoaMapping",
            ParentAccountIsBudgetHead = "ParentAccountIsBudgetHead",
            ParentAccountIsControlhead = "ParentAccountIsControlhead",
            ParentAccountIsCostCenterAllocate = "ParentAccountIsCostCenterAllocate",
            ParentAccountLevel = "ParentAccountLevel",
            ParentAccountOpeningBalance = "ParentAccountOpeningBalance",
            ParentAccountRemarks = "ParentAccountRemarks",
            ParentAccountFundControlId = "ParentAccountFundControlId",
            ParentAccountParentAccountId = "ParentAccountParentAccountId",
            AccOpeningBalanceId = "AccOpeningBalanceId",
            OpeningBalance = "OpeningBalance",
            AccOpeningBalance = "AccOpeningBalance",
            iSCoAUsed = "iSCoAUsed",
            NoaAccTypeId2 = "NoaAccTypeId2",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccChartofAccountsService {
        const baseUrl = "Configurations/AccChartofAccounts";
        function Create(request: Serenity.SaveRequest<AccChartofAccountsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccChartofAccountsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChartofAccountsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChartofAccountsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function SaveCoAList(request: SaveCoAListRequest, onSuccess?: (response: SaveCoAListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccChartofAccounts/Create",
            Update = "Configurations/AccChartofAccounts/Update",
            Delete = "Configurations/AccChartofAccounts/Delete",
            Retrieve = "Configurations/AccChartofAccounts/Retrieve",
            List = "Configurations/AccChartofAccounts/List",
            SaveCoAList = "Configurations/AccChartofAccounts/SaveCoAList",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccCoACostCenterOpeningBalanceForm {
        CoAid: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        OBDebit: Serenity.DecimalEditor;
        OBCredit: Serenity.DecimalEditor;
    }
    class AccCoACostCenterOpeningBalanceForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccCoACostCenterOpeningBalanceRow {
        Id?: number;
        CoAid?: number;
        CostCenterId?: number;
        OBDebit?: number;
        OBCredit?: number;
        ZoneId?: number;
        FundControlId?: number;
        CoAidAccountCode?: string;
        CoAidAccountCodeCount?: number;
        CoAidAccountGroup?: string;
        CoAidAccountName?: string;
        CoAidOpeningBalance?: number;
        CoAidRemarks?: string;
        CoAidFundControlId?: number;
        CoAidParentAccountId?: number;
        CoAidUserCode?: string;
        CoAidNoaAccTypeId?: number;
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterEntityId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterIsActive?: boolean;
        ZoneZoneName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccCoACostCenterOpeningBalanceRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccCoACostCenterOpeningBalance";
        const lookupKey = "Configurations.AccCoACostCenterOpeningBalance";
        function getLookup(): Q.Lookup<AccCoACostCenterOpeningBalanceRow>;
        const enum Fields {
            Id = "Id",
            CoAid = "CoAid",
            CostCenterId = "CostCenterId",
            OBDebit = "OBDebit",
            OBCredit = "OBCredit",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            CoAidAccountCode = "CoAidAccountCode",
            CoAidAccountCodeCount = "CoAidAccountCodeCount",
            CoAidAccountGroup = "CoAidAccountGroup",
            CoAidAccountName = "CoAidAccountName",
            CoAidOpeningBalance = "CoAidOpeningBalance",
            CoAidRemarks = "CoAidRemarks",
            CoAidFundControlId = "CoAidFundControlId",
            CoAidParentAccountId = "CoAidParentAccountId",
            CoAidUserCode = "CoAidUserCode",
            CoAidNoaAccTypeId = "CoAidNoaAccTypeId",
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterIsActive = "CostCenterIsActive",
            ZoneZoneName = "ZoneZoneName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccCoACostCenterOpeningBalanceService {
        const baseUrl = "Configurations/AccCoACostCenterOpeningBalance";
        function Create(request: Serenity.SaveRequest<AccCoACostCenterOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCoACostCenterOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCoACostCenterOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCoACostCenterOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccCoACostCenterOpeningBalance/Create",
            Update = "Configurations/AccCoACostCenterOpeningBalance/Update",
            Delete = "Configurations/AccCoACostCenterOpeningBalance/Delete",
            Retrieve = "Configurations/AccCoACostCenterOpeningBalance/Retrieve",
            List = "Configurations/AccCoACostCenterOpeningBalance/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccCommonDescriptionForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        Description: Serenity.TextAreaEditor;
    }
    class AccCommonDescriptionForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccCommonDescriptionRow {
        Id?: number;
        Description?: string;
        TransactionTypeId?: number;
        VoucherTypeId?: number;
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
        TransactionTypeVoucherTypeId?: number;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccCommonDescriptionRow {
        const idProperty = "Id";
        const nameProperty = "Description";
        const localTextPrefix = "Configurations.AccCommonDescription";
        const lookupKey = "Configurations.AccCommonDescription";
        function getLookup(): Q.Lookup<AccCommonDescriptionRow>;
        const enum Fields {
            Id = "Id",
            Description = "Description",
            TransactionTypeId = "TransactionTypeId",
            VoucherTypeId = "VoucherTypeId",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId",
            TransactionTypeVoucherTypeId = "TransactionTypeVoucherTypeId",
            VoucherTypeName = "VoucherTypeName",
            VoucherTypeSortOrder = "VoucherTypeSortOrder",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccCommonDescriptionService {
        const baseUrl = "Configurations/AccCommonDescription";
        function Create(request: Serenity.SaveRequest<AccCommonDescriptionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCommonDescriptionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCommonDescriptionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCommonDescriptionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccCommonDescription/Create",
            Update = "Configurations/AccCommonDescription/Update",
            Delete = "Configurations/AccCommonDescription/Delete",
            Retrieve = "Configurations/AccCommonDescription/Retrieve",
            List = "Configurations/AccCommonDescription/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccCostCenterTypeForm {
        CostCenterType: Serenity.StringEditor;
        SortOrder: Serenity.IntegerEditor;
    }
    class AccCostCenterTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccCostCenterTypeRow {
        Id?: number;
        CostCenterType?: string;
        SortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccCostCenterTypeRow {
        const idProperty = "Id";
        const nameProperty = "CostCenterType";
        const localTextPrefix = "Configurations.AccCostCenterType";
        const lookupKey = "Configurations.AccCostCenterType";
        function getLookup(): Q.Lookup<AccCostCenterTypeRow>;
        const enum Fields {
            Id = "Id",
            CostCenterType = "CostCenterType",
            SortOrder = "SortOrder",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccCostCenterTypeService {
        const baseUrl = "Configurations/AccCostCenterType";
        function Create(request: Serenity.SaveRequest<AccCostCenterTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCostCenterTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCostCenterTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCostCenterTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccCostCenterType/Create",
            Update = "Configurations/AccCostCenterType/Update",
            Delete = "Configurations/AccCostCenterType/Delete",
            Retrieve = "Configurations/AccCostCenterType/Retrieve",
            List = "Configurations/AccCostCenterType/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccCostCentreDepreciationOpeningBalanceForm {
        CostCenterId: Serenity.LookupEditor;
        OpeningBalanceCost: Serenity.DecimalEditor;
        OpeningBalanceDepreciation: Serenity.DecimalEditor;
    }
    class AccCostCentreDepreciationOpeningBalanceForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccCostCentreDepreciationOpeningBalanceRow {
        Id?: number;
        CostCenterId?: number;
        OpeningBalanceDepreciation?: number;
        OpeningBalanceCost?: number;
        ZoneInfoId?: number;
        FundControlId?: number;
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterNameForBankAdviceLetter?: string;
        CostCenterPaAmmount?: number;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterEmpId?: number;
        CostCenterIsActive?: boolean;
        CostCenterEntityId?: number;
        CostCenterZoneInfoId?: number;
        CostCenterIsBudgetHead?: boolean;
        CostCenterBudgetGroupId?: number;
        CostCenterIsFixedAssetHead?: boolean;
        CostCenterIsFixedAssetDevWork?: boolean;
        CostCenterIsFixedAssetNonDevWork?: boolean;
        CostCenterDepreciationRate?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccCostCentreDepreciationOpeningBalanceRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccCostCentreDepreciationOpeningBalance";
        const lookupKey = "Configurations.AccCostCentreDepreciationOpeningBalance";
        function getLookup(): Q.Lookup<AccCostCentreDepreciationOpeningBalanceRow>;
        const enum Fields {
            Id = "Id",
            CostCenterId = "CostCenterId",
            OpeningBalanceDepreciation = "OpeningBalanceDepreciation",
            OpeningBalanceCost = "OpeningBalanceCost",
            ZoneInfoId = "ZoneInfoId",
            FundControlId = "FundControlId",
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterNameForBankAdviceLetter = "CostCenterNameForBankAdviceLetter",
            CostCenterPaAmmount = "CostCenterPaAmmount",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterEmpId = "CostCenterEmpId",
            CostCenterIsActive = "CostCenterIsActive",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterZoneInfoId = "CostCenterZoneInfoId",
            CostCenterIsBudgetHead = "CostCenterIsBudgetHead",
            CostCenterBudgetGroupId = "CostCenterBudgetGroupId",
            CostCenterIsFixedAssetHead = "CostCenterIsFixedAssetHead",
            CostCenterIsFixedAssetDevWork = "CostCenterIsFixedAssetDevWork",
            CostCenterIsFixedAssetNonDevWork = "CostCenterIsFixedAssetNonDevWork",
            CostCenterDepreciationRate = "CostCenterDepreciationRate",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccCostCentreDepreciationOpeningBalanceService {
        const baseUrl = "Configurations/AccCostCentreDepreciationOpeningBalance";
        function Create(request: Serenity.SaveRequest<AccCostCentreDepreciationOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCostCentreDepreciationOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCostCentreDepreciationOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCostCentreDepreciationOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccCostCentreDepreciationOpeningBalance/Create",
            Update = "Configurations/AccCostCentreDepreciationOpeningBalance/Update",
            Delete = "Configurations/AccCostCentreDepreciationOpeningBalance/Delete",
            Retrieve = "Configurations/AccCostCentreDepreciationOpeningBalance/Retrieve",
            List = "Configurations/AccCostCentreDepreciationOpeningBalance/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccCurrencyConversionForm {
        Currency: Serenity.StringEditor;
        Symbol: Serenity.StringEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class AccCurrencyConversionForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccCurrencyConversionRateForm {
        FirstAmout: Serenity.DecimalEditor;
        FirstCurrency: Serenity.LookupEditor;
        SecondAmout: Serenity.DecimalEditor;
        SecondCurrency: Serenity.LookupEditor;
    }
    class AccCurrencyConversionRateForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccCurrencyConversionRateRow {
        Id?: number;
        FirstCurrency?: number;
        SecondCurrency?: number;
        FirstAmout?: number;
        SecondAmout?: number;
        FirstCurrencyCurrency?: string;
        FirstCurrencyRemarks?: string;
        FirstCurrencySymbol?: string;
        SecondCurrencyCurrency?: string;
        SecondCurrencyRemarks?: string;
        SecondCurrencySymbol?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccCurrencyConversionRateRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccCurrencyConversionRate";
        const lookupKey = "Configurations.AccCurrencyConversionRate";
        function getLookup(): Q.Lookup<AccCurrencyConversionRateRow>;
        const enum Fields {
            Id = "Id",
            FirstCurrency = "FirstCurrency",
            SecondCurrency = "SecondCurrency",
            FirstAmout = "FirstAmout",
            SecondAmout = "SecondAmout",
            FirstCurrencyCurrency = "FirstCurrencyCurrency",
            FirstCurrencyRemarks = "FirstCurrencyRemarks",
            FirstCurrencySymbol = "FirstCurrencySymbol",
            SecondCurrencyCurrency = "SecondCurrencyCurrency",
            SecondCurrencyRemarks = "SecondCurrencyRemarks",
            SecondCurrencySymbol = "SecondCurrencySymbol",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccCurrencyConversionRateService {
        const baseUrl = "Configurations/AccCurrencyConversionRate";
        function Create(request: Serenity.SaveRequest<AccCurrencyConversionRateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCurrencyConversionRateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCurrencyConversionRateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCurrencyConversionRateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccCurrencyConversionRate/Create",
            Update = "Configurations/AccCurrencyConversionRate/Update",
            Delete = "Configurations/AccCurrencyConversionRate/Delete",
            Retrieve = "Configurations/AccCurrencyConversionRate/Retrieve",
            List = "Configurations/AccCurrencyConversionRate/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface AccCurrencyConversionRow {
        Id?: number;
        Currency?: string;
        Remarks?: string;
        Symbol?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccCurrencyConversionRow {
        const idProperty = "Id";
        const nameProperty = "Currency";
        const localTextPrefix = "Configurations.AccCurrencyConversion";
        const lookupKey = "Configurations.AccCurrencyConversion";
        function getLookup(): Q.Lookup<AccCurrencyConversionRow>;
        const enum Fields {
            Id = "Id",
            Currency = "Currency",
            Remarks = "Remarks",
            Symbol = "Symbol",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccCurrencyConversionService {
        const baseUrl = "Configurations/AccCurrencyConversion";
        function Create(request: Serenity.SaveRequest<AccCurrencyConversionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCurrencyConversionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCurrencyConversionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCurrencyConversionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccCurrencyConversion/Create",
            Update = "Configurations/AccCurrencyConversion/Update",
            Delete = "Configurations/AccCurrencyConversion/Delete",
            Retrieve = "Configurations/AccCurrencyConversion/Retrieve",
            List = "Configurations/AccCurrencyConversion/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccFinancialReportsDetailsForm {
        ReportType: FinancialReportEditor;
        ZoneInfoId: Serenity.LookupEditor;
        EntityId: Serenity.IntegerEditor;
        CoaId: Serenity.LookupEditor;
        SubledgerId: Serenity.LookupEditor;
        Opening: Serenity.DecimalEditor;
    }
    class AccFinancialReportsDetailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccFinancialReportsDetailsRow {
        Id?: number;
        ReportType?: string;
        ZoneInfoId?: number;
        EntityId?: number;
        CoaId?: number;
        SubledgerId?: number;
        Opening?: number;
        ZoneInfoZoneName?: string;
        ZoneInfoZoneNameInBengali?: string;
        ZoneInfoZoneCode?: string;
        ZoneInfoSortOrder?: number;
        ZoneInfoOrganogramCategoryTypeId?: number;
        ZoneInfoZoneAddress?: string;
        ZoneInfoZoneAddressInBengali?: string;
        ZoneInfoPrefix?: string;
        ZoneInfoIsHeadOffice?: boolean;
        ZoneInfoZoneCodeForBillingSystem?: string;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        CoaIsBalanceSheet?: boolean;
        CoaBalanceSheetNotes?: number;
        CoaIsIncomeExpenditure?: boolean;
        CoaIncomeExpenditureNotes?: number;
        CoaBudgetCode?: string;
        CoaIsHideChildrenFromThisLevel?: boolean;
        SubledgerCode?: string;
        SubledgerCodeCount?: number;
        SubledgerUserCode?: string;
        SubledgerIsInstitute?: boolean;
        SubledgerName?: string;
        SubledgerNameForBankAdviceLetter?: string;
        SubledgerPaAmmount?: number;
        SubledgerRemarks?: string;
        SubledgerParentId?: number;
        SubledgerCostCenterTypeId?: number;
        SubledgerEmpId?: number;
        SubledgerIsActive?: boolean;
        SubledgerEntityId?: number;
        SubledgerZoneInfoId?: number;
        SubledgerIsBudgetHead?: boolean;
        SubledgerBudgetGroupId?: number;
        SubledgerIsFixedAssetHead?: boolean;
        SubledgerIsFixedAssetDevWork?: boolean;
        SubledgerIsFixedAssetNonDevWork?: boolean;
        SubledgerDepreciationRate?: number;
        SubledgerBudgetCode?: string;
    }
    namespace AccFinancialReportsDetailsRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccFinancialReportsDetails";
        const lookupKey = "Configurations.AccFinancialReportsDetails";
        function getLookup(): Q.Lookup<AccFinancialReportsDetailsRow>;
        const enum Fields {
            Id = "Id",
            ReportType = "ReportType",
            ZoneInfoId = "ZoneInfoId",
            EntityId = "EntityId",
            CoaId = "CoaId",
            SubledgerId = "SubledgerId",
            Opening = "Opening",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            ZoneInfoZoneNameInBengali = "ZoneInfoZoneNameInBengali",
            ZoneInfoZoneCode = "ZoneInfoZoneCode",
            ZoneInfoSortOrder = "ZoneInfoSortOrder",
            ZoneInfoOrganogramCategoryTypeId = "ZoneInfoOrganogramCategoryTypeId",
            ZoneInfoZoneAddress = "ZoneInfoZoneAddress",
            ZoneInfoZoneAddressInBengali = "ZoneInfoZoneAddressInBengali",
            ZoneInfoPrefix = "ZoneInfoPrefix",
            ZoneInfoIsHeadOffice = "ZoneInfoIsHeadOffice",
            ZoneInfoZoneCodeForBillingSystem = "ZoneInfoZoneCodeForBillingSystem",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            CoaIsBalanceSheet = "CoaIsBalanceSheet",
            CoaBalanceSheetNotes = "CoaBalanceSheetNotes",
            CoaIsIncomeExpenditure = "CoaIsIncomeExpenditure",
            CoaIncomeExpenditureNotes = "CoaIncomeExpenditureNotes",
            CoaBudgetCode = "CoaBudgetCode",
            CoaIsHideChildrenFromThisLevel = "CoaIsHideChildrenFromThisLevel",
            SubledgerCode = "SubledgerCode",
            SubledgerCodeCount = "SubledgerCodeCount",
            SubledgerUserCode = "SubledgerUserCode",
            SubledgerIsInstitute = "SubledgerIsInstitute",
            SubledgerName = "SubledgerName",
            SubledgerNameForBankAdviceLetter = "SubledgerNameForBankAdviceLetter",
            SubledgerPaAmmount = "SubledgerPaAmmount",
            SubledgerRemarks = "SubledgerRemarks",
            SubledgerParentId = "SubledgerParentId",
            SubledgerCostCenterTypeId = "SubledgerCostCenterTypeId",
            SubledgerEmpId = "SubledgerEmpId",
            SubledgerIsActive = "SubledgerIsActive",
            SubledgerEntityId = "SubledgerEntityId",
            SubledgerZoneInfoId = "SubledgerZoneInfoId",
            SubledgerIsBudgetHead = "SubledgerIsBudgetHead",
            SubledgerBudgetGroupId = "SubledgerBudgetGroupId",
            SubledgerIsFixedAssetHead = "SubledgerIsFixedAssetHead",
            SubledgerIsFixedAssetDevWork = "SubledgerIsFixedAssetDevWork",
            SubledgerIsFixedAssetNonDevWork = "SubledgerIsFixedAssetNonDevWork",
            SubledgerDepreciationRate = "SubledgerDepreciationRate",
            SubledgerBudgetCode = "SubledgerBudgetCode",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccFinancialReportsDetailsService {
        const baseUrl = "Configurations/AccFinancialReportsDetails";
        function Create(request: Serenity.SaveRequest<AccFinancialReportsDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccFinancialReportsDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFinancialReportsDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFinancialReportsDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccFinancialReportsDetails/Create",
            Update = "Configurations/AccFinancialReportsDetails/Update",
            Delete = "Configurations/AccFinancialReportsDetails/Delete",
            Retrieve = "Configurations/AccFinancialReportsDetails/Retrieve",
            List = "Configurations/AccFinancialReportsDetails/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccFundControlInformationForm {
        FundControlName: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        CurrencyId: Serenity.LookupEditor;
    }
    class AccFundControlInformationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccFundControlInformationRow {
        Id?: number;
        Code?: string;
        FundControlName?: string;
        BookingDate?: string;
        Address?: string;
        Phone?: string;
        Mobile?: string;
        Fax?: string;
        Email?: string;
        WebUrl?: string;
        Remarks?: string;
        ZoneInfoId?: number;
        CurrencyId?: number;
        ZoneInfoZoneName?: string;
        ZoneInfoZoneNameInBengali?: string;
        ZoneInfoZoneCode?: string;
        ZoneInfoSortOrder?: number;
        ZoneInfoOrganogramCategoryTypeId?: number;
        ZoneInfoZoneAddress?: string;
        ZoneInfoZoneAddressInBengali?: string;
        ZoneInfoPrefix?: string;
        ZoneInfoIsHeadOffice?: boolean;
        CurrencySymbol?: string;
        CurrencyCurrency?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccFundControlInformationRow {
        const idProperty = "Id";
        const nameProperty = "FundControlName";
        const localTextPrefix = "Configurations.AccFundControlInformation";
        const lookupKey = "Configurations.AccFundControlInformation";
        function getLookup(): Q.Lookup<AccFundControlInformationRow>;
        const enum Fields {
            Id = "Id",
            Code = "Code",
            FundControlName = "FundControlName",
            BookingDate = "BookingDate",
            Address = "Address",
            Phone = "Phone",
            Mobile = "Mobile",
            Fax = "Fax",
            Email = "Email",
            WebUrl = "WebUrl",
            Remarks = "Remarks",
            ZoneInfoId = "ZoneInfoId",
            CurrencyId = "CurrencyId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            ZoneInfoZoneNameInBengali = "ZoneInfoZoneNameInBengali",
            ZoneInfoZoneCode = "ZoneInfoZoneCode",
            ZoneInfoSortOrder = "ZoneInfoSortOrder",
            ZoneInfoOrganogramCategoryTypeId = "ZoneInfoOrganogramCategoryTypeId",
            ZoneInfoZoneAddress = "ZoneInfoZoneAddress",
            ZoneInfoZoneAddressInBengali = "ZoneInfoZoneAddressInBengali",
            ZoneInfoPrefix = "ZoneInfoPrefix",
            ZoneInfoIsHeadOffice = "ZoneInfoIsHeadOffice",
            CurrencySymbol = "CurrencySymbol",
            CurrencyCurrency = "CurrencyCurrency",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccFundControlInformationService {
        const baseUrl = "Configurations/AccFundControlInformation";
        function Create(request: Serenity.SaveRequest<AccFundControlInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccFundControlInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFundControlInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFundControlInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function SetFundControl(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFundControlInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccFundControlInformation/Create",
            Update = "Configurations/AccFundControlInformation/Update",
            Delete = "Configurations/AccFundControlInformation/Delete",
            Retrieve = "Configurations/AccFundControlInformation/Retrieve",
            List = "Configurations/AccFundControlInformation/List",
            SetFundControl = "Configurations/AccFundControlInformation/SetFundControl",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccFundControlZoneWiseApproverForm {
        FundControlId: Serenity.LookupEditor;
        ZoneInfoId: Serenity.LookupEditor;
        ApproverId: Serenity.LookupEditor;
        PostingById: Serenity.LookupEditor;
    }
    class AccFundControlZoneWiseApproverForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccFundControlZoneWiseApproverRow {
        Id?: number;
        FundControlId?: number;
        ZoneInfoId?: number;
        ApproverId?: number;
        PostingById?: number;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlBookingDate?: string;
        FundControlCurrencyId?: number;
        FundControlAddress?: string;
        FundControlPhone?: string;
        FundControlMobile?: string;
        FundControlFax?: string;
        FundControlEmail?: string;
        FundControlWebUrl?: string;
        FundControlRemarks?: string;
        FundControlZoneInfoId?: number;
        ZoneInfoZoneName?: string;
        ZoneInfoZoneNameInBengali?: string;
        ZoneInfoZoneCode?: string;
        ZoneInfoSortOrder?: number;
        ZoneInfoOrganogramCategoryTypeId?: number;
        ZoneInfoZoneAddress?: string;
        ZoneInfoZoneAddressInBengali?: string;
        ZoneInfoPrefix?: string;
        ZoneInfoIsHeadOffice?: boolean;
        ZoneInfoZoneCodeForBillingSystem?: string;
        ApproverEmpId?: string;
        ApproverEmployeeInitial?: string;
        ApproverTitleId?: number;
        ApproverFirstName?: string;
        ApproverMiddleName?: string;
        ApproverLastName?: string;
        ApproverFullName?: string;
        ApproverFullNameBangla?: string;
        ApproverDateofJoining?: string;
        ApproverProvisionMonth?: number;
        ApproverDateofConfirmation?: string;
        ApproverDateofPosition?: string;
        ApproverDesignationId?: number;
        ApproverStatusDesignationId?: number;
        ApproverDisciplineId?: number;
        ApproverDivisionId?: number;
        ApproverSectionId?: number;
        ApproverSubSectionId?: number;
        ApproverJobLocationId?: number;
        ApproverResourceLevelId?: number;
        ApproverStaffCategoryId?: number;
        ApproverEmploymentTypeId?: number;
        ApproverReligionId?: number;
        ApproverIsContractual?: boolean;
        ApproverOvertimeRate?: number;
        ApproverMobileNo?: string;
        ApproverEmialAddress?: string;
        ApproverBankId?: number;
        ApproverBankBranchId?: number;
        ApproverBankAccountNo?: string;
        ApproverEmploymentStatusId?: number;
        ApproverDateofInactive?: string;
        ApproverIsConsultant?: boolean;
        ApproverIsOvertimeEligible?: boolean;
        ApproverIsRefreshmentEligible?: boolean;
        ApproverIsBonusEligible?: boolean;
        ApproverIsEligibleForCpf?: boolean;
        ApproverIsGpfEligible?: boolean;
        ApproverIsPensionEligible?: boolean;
        ApproverIsLeverageEligible?: boolean;
        ApproverIsGeneralShifted?: boolean;
        ApproverSalaryScaleId?: number;
        ApproverJobGradeId?: number;
        ApproverGender?: string;
        ApproverContractExpireDate?: string;
        ApproverDateofBirth?: string;
        ApproverContractDuration?: number;
        ApproverContractType?: number;
        ApproverOrganogramLevelId?: number;
        ApproverDateofAppointment?: string;
        ApproverOrderNo?: string;
        ApproverQuotaId?: number;
        ApproverEmployeeClassId?: number;
        ApproverEmploymentProcessId?: number;
        ApproverSeniorityPosition?: string;
        ApproverDateofSeniority?: string;
        ApproverPrlDate?: string;
        ApproverCardNo?: string;
        ApproverFingerPrintIdentiyNo?: string;
        ApproverAttendanceEffectiveDate?: string;
        ApproverAttendanceStatus?: boolean;
        ApproverZoneInfoId?: number;
        ApproverTelephoneOffice?: string;
        ApproverIntercom?: string;
        ApproverHonoraryDegree?: string;
        ApproverTaxRegionId?: number;
        ApproverTaxAssesseeType?: number;
        ApproverHavingChildWithDisability?: boolean;
        ApproverDateofRetirement?: string;
        ApproverSalaryWithdrawFromZoneId?: number;
        ApproverRegionId?: number;
        ApproverEtin?: string;
        ApproverIUser?: string;
        ApproverIDate?: string;
        ApproverEUser?: string;
        ApproverEDate?: string;
        PostingByEmpId?: string;
        PostingByEmployeeInitial?: string;
        PostingByTitleId?: number;
        PostingByFirstName?: string;
        PostingByMiddleName?: string;
        PostingByLastName?: string;
        PostingByFullName?: string;
        PostingByFullNameBangla?: string;
        PostingByDateofJoining?: string;
        PostingByProvisionMonth?: number;
        PostingByDateofConfirmation?: string;
        PostingByDateofPosition?: string;
        PostingByDesignationId?: number;
        PostingByStatusDesignationId?: number;
        PostingByDisciplineId?: number;
        PostingByDivisionId?: number;
        PostingBySectionId?: number;
        PostingBySubSectionId?: number;
        PostingByJobLocationId?: number;
        PostingByResourceLevelId?: number;
        PostingByStaffCategoryId?: number;
        PostingByEmploymentTypeId?: number;
        PostingByReligionId?: number;
        PostingByIsContractual?: boolean;
        PostingByOvertimeRate?: number;
        PostingByMobileNo?: string;
        PostingByEmialAddress?: string;
        PostingByBankId?: number;
        PostingByBankBranchId?: number;
        PostingByBankAccountNo?: string;
        PostingByEmploymentStatusId?: number;
        PostingByDateofInactive?: string;
        PostingByIsConsultant?: boolean;
        PostingByIsOvertimeEligible?: boolean;
        PostingByIsRefreshmentEligible?: boolean;
        PostingByIsBonusEligible?: boolean;
        PostingByIsEligibleForCpf?: boolean;
        PostingByIsGpfEligible?: boolean;
        PostingByIsPensionEligible?: boolean;
        PostingByIsLeverageEligible?: boolean;
        PostingByIsGeneralShifted?: boolean;
        PostingBySalaryScaleId?: number;
        PostingByJobGradeId?: number;
        PostingByGender?: string;
        PostingByContractExpireDate?: string;
        PostingByDateofBirth?: string;
        PostingByContractDuration?: number;
        PostingByContractType?: number;
        PostingByOrganogramLevelId?: number;
        PostingByDateofAppointment?: string;
        PostingByOrderNo?: string;
        PostingByQuotaId?: number;
        PostingByEmployeeClassId?: number;
        PostingByEmploymentProcessId?: number;
        PostingBySeniorityPosition?: string;
        PostingByDateofSeniority?: string;
        PostingByPrlDate?: string;
        PostingByCardNo?: string;
        PostingByFingerPrintIdentiyNo?: string;
        PostingByAttendanceEffectiveDate?: string;
        PostingByAttendanceStatus?: boolean;
        PostingByZoneInfoId?: number;
        PostingByTelephoneOffice?: string;
        PostingByIntercom?: string;
        PostingByHonoraryDegree?: string;
        PostingByTaxRegionId?: number;
        PostingByTaxAssesseeType?: number;
        PostingByHavingChildWithDisability?: boolean;
        PostingByDateofRetirement?: string;
        PostingBySalaryWithdrawFromZoneId?: number;
        PostingByRegionId?: number;
        PostingByEtin?: string;
        PostingByIUser?: string;
        PostingByIDate?: string;
        PostingByEUser?: string;
        PostingByEDate?: string;
    }
    namespace AccFundControlZoneWiseApproverRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccFundControlZoneWiseApprover";
        const lookupKey = "Configurations.AccFundControlZoneWiseApprover";
        function getLookup(): Q.Lookup<AccFundControlZoneWiseApproverRow>;
        const enum Fields {
            Id = "Id",
            FundControlId = "FundControlId",
            ZoneInfoId = "ZoneInfoId",
            ApproverId = "ApproverId",
            PostingById = "PostingById",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlBookingDate = "FundControlBookingDate",
            FundControlCurrencyId = "FundControlCurrencyId",
            FundControlAddress = "FundControlAddress",
            FundControlPhone = "FundControlPhone",
            FundControlMobile = "FundControlMobile",
            FundControlFax = "FundControlFax",
            FundControlEmail = "FundControlEmail",
            FundControlWebUrl = "FundControlWebUrl",
            FundControlRemarks = "FundControlRemarks",
            FundControlZoneInfoId = "FundControlZoneInfoId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            ZoneInfoZoneNameInBengali = "ZoneInfoZoneNameInBengali",
            ZoneInfoZoneCode = "ZoneInfoZoneCode",
            ZoneInfoSortOrder = "ZoneInfoSortOrder",
            ZoneInfoOrganogramCategoryTypeId = "ZoneInfoOrganogramCategoryTypeId",
            ZoneInfoZoneAddress = "ZoneInfoZoneAddress",
            ZoneInfoZoneAddressInBengali = "ZoneInfoZoneAddressInBengali",
            ZoneInfoPrefix = "ZoneInfoPrefix",
            ZoneInfoIsHeadOffice = "ZoneInfoIsHeadOffice",
            ZoneInfoZoneCodeForBillingSystem = "ZoneInfoZoneCodeForBillingSystem",
            ApproverEmpId = "ApproverEmpId",
            ApproverEmployeeInitial = "ApproverEmployeeInitial",
            ApproverTitleId = "ApproverTitleId",
            ApproverFirstName = "ApproverFirstName",
            ApproverMiddleName = "ApproverMiddleName",
            ApproverLastName = "ApproverLastName",
            ApproverFullName = "ApproverFullName",
            ApproverFullNameBangla = "ApproverFullNameBangla",
            ApproverDateofJoining = "ApproverDateofJoining",
            ApproverProvisionMonth = "ApproverProvisionMonth",
            ApproverDateofConfirmation = "ApproverDateofConfirmation",
            ApproverDateofPosition = "ApproverDateofPosition",
            ApproverDesignationId = "ApproverDesignationId",
            ApproverStatusDesignationId = "ApproverStatusDesignationId",
            ApproverDisciplineId = "ApproverDisciplineId",
            ApproverDivisionId = "ApproverDivisionId",
            ApproverSectionId = "ApproverSectionId",
            ApproverSubSectionId = "ApproverSubSectionId",
            ApproverJobLocationId = "ApproverJobLocationId",
            ApproverResourceLevelId = "ApproverResourceLevelId",
            ApproverStaffCategoryId = "ApproverStaffCategoryId",
            ApproverEmploymentTypeId = "ApproverEmploymentTypeId",
            ApproverReligionId = "ApproverReligionId",
            ApproverIsContractual = "ApproverIsContractual",
            ApproverOvertimeRate = "ApproverOvertimeRate",
            ApproverMobileNo = "ApproverMobileNo",
            ApproverEmialAddress = "ApproverEmialAddress",
            ApproverBankId = "ApproverBankId",
            ApproverBankBranchId = "ApproverBankBranchId",
            ApproverBankAccountNo = "ApproverBankAccountNo",
            ApproverEmploymentStatusId = "ApproverEmploymentStatusId",
            ApproverDateofInactive = "ApproverDateofInactive",
            ApproverIsConsultant = "ApproverIsConsultant",
            ApproverIsOvertimeEligible = "ApproverIsOvertimeEligible",
            ApproverIsRefreshmentEligible = "ApproverIsRefreshmentEligible",
            ApproverIsBonusEligible = "ApproverIsBonusEligible",
            ApproverIsEligibleForCpf = "ApproverIsEligibleForCpf",
            ApproverIsGpfEligible = "ApproverIsGpfEligible",
            ApproverIsPensionEligible = "ApproverIsPensionEligible",
            ApproverIsLeverageEligible = "ApproverIsLeverageEligible",
            ApproverIsGeneralShifted = "ApproverIsGeneralShifted",
            ApproverSalaryScaleId = "ApproverSalaryScaleId",
            ApproverJobGradeId = "ApproverJobGradeId",
            ApproverGender = "ApproverGender",
            ApproverContractExpireDate = "ApproverContractExpireDate",
            ApproverDateofBirth = "ApproverDateofBirth",
            ApproverContractDuration = "ApproverContractDuration",
            ApproverContractType = "ApproverContractType",
            ApproverOrganogramLevelId = "ApproverOrganogramLevelId",
            ApproverDateofAppointment = "ApproverDateofAppointment",
            ApproverOrderNo = "ApproverOrderNo",
            ApproverQuotaId = "ApproverQuotaId",
            ApproverEmployeeClassId = "ApproverEmployeeClassId",
            ApproverEmploymentProcessId = "ApproverEmploymentProcessId",
            ApproverSeniorityPosition = "ApproverSeniorityPosition",
            ApproverDateofSeniority = "ApproverDateofSeniority",
            ApproverPrlDate = "ApproverPrlDate",
            ApproverCardNo = "ApproverCardNo",
            ApproverFingerPrintIdentiyNo = "ApproverFingerPrintIdentiyNo",
            ApproverAttendanceEffectiveDate = "ApproverAttendanceEffectiveDate",
            ApproverAttendanceStatus = "ApproverAttendanceStatus",
            ApproverZoneInfoId = "ApproverZoneInfoId",
            ApproverTelephoneOffice = "ApproverTelephoneOffice",
            ApproverIntercom = "ApproverIntercom",
            ApproverHonoraryDegree = "ApproverHonoraryDegree",
            ApproverTaxRegionId = "ApproverTaxRegionId",
            ApproverTaxAssesseeType = "ApproverTaxAssesseeType",
            ApproverHavingChildWithDisability = "ApproverHavingChildWithDisability",
            ApproverDateofRetirement = "ApproverDateofRetirement",
            ApproverSalaryWithdrawFromZoneId = "ApproverSalaryWithdrawFromZoneId",
            ApproverRegionId = "ApproverRegionId",
            ApproverEtin = "ApproverEtin",
            ApproverIUser = "ApproverIUser",
            ApproverIDate = "ApproverIDate",
            ApproverEUser = "ApproverEUser",
            ApproverEDate = "ApproverEDate",
            PostingByEmpId = "PostingByEmpId",
            PostingByEmployeeInitial = "PostingByEmployeeInitial",
            PostingByTitleId = "PostingByTitleId",
            PostingByFirstName = "PostingByFirstName",
            PostingByMiddleName = "PostingByMiddleName",
            PostingByLastName = "PostingByLastName",
            PostingByFullName = "PostingByFullName",
            PostingByFullNameBangla = "PostingByFullNameBangla",
            PostingByDateofJoining = "PostingByDateofJoining",
            PostingByProvisionMonth = "PostingByProvisionMonth",
            PostingByDateofConfirmation = "PostingByDateofConfirmation",
            PostingByDateofPosition = "PostingByDateofPosition",
            PostingByDesignationId = "PostingByDesignationId",
            PostingByStatusDesignationId = "PostingByStatusDesignationId",
            PostingByDisciplineId = "PostingByDisciplineId",
            PostingByDivisionId = "PostingByDivisionId",
            PostingBySectionId = "PostingBySectionId",
            PostingBySubSectionId = "PostingBySubSectionId",
            PostingByJobLocationId = "PostingByJobLocationId",
            PostingByResourceLevelId = "PostingByResourceLevelId",
            PostingByStaffCategoryId = "PostingByStaffCategoryId",
            PostingByEmploymentTypeId = "PostingByEmploymentTypeId",
            PostingByReligionId = "PostingByReligionId",
            PostingByIsContractual = "PostingByIsContractual",
            PostingByOvertimeRate = "PostingByOvertimeRate",
            PostingByMobileNo = "PostingByMobileNo",
            PostingByEmialAddress = "PostingByEmialAddress",
            PostingByBankId = "PostingByBankId",
            PostingByBankBranchId = "PostingByBankBranchId",
            PostingByBankAccountNo = "PostingByBankAccountNo",
            PostingByEmploymentStatusId = "PostingByEmploymentStatusId",
            PostingByDateofInactive = "PostingByDateofInactive",
            PostingByIsConsultant = "PostingByIsConsultant",
            PostingByIsOvertimeEligible = "PostingByIsOvertimeEligible",
            PostingByIsRefreshmentEligible = "PostingByIsRefreshmentEligible",
            PostingByIsBonusEligible = "PostingByIsBonusEligible",
            PostingByIsEligibleForCpf = "PostingByIsEligibleForCpf",
            PostingByIsGpfEligible = "PostingByIsGpfEligible",
            PostingByIsPensionEligible = "PostingByIsPensionEligible",
            PostingByIsLeverageEligible = "PostingByIsLeverageEligible",
            PostingByIsGeneralShifted = "PostingByIsGeneralShifted",
            PostingBySalaryScaleId = "PostingBySalaryScaleId",
            PostingByJobGradeId = "PostingByJobGradeId",
            PostingByGender = "PostingByGender",
            PostingByContractExpireDate = "PostingByContractExpireDate",
            PostingByDateofBirth = "PostingByDateofBirth",
            PostingByContractDuration = "PostingByContractDuration",
            PostingByContractType = "PostingByContractType",
            PostingByOrganogramLevelId = "PostingByOrganogramLevelId",
            PostingByDateofAppointment = "PostingByDateofAppointment",
            PostingByOrderNo = "PostingByOrderNo",
            PostingByQuotaId = "PostingByQuotaId",
            PostingByEmployeeClassId = "PostingByEmployeeClassId",
            PostingByEmploymentProcessId = "PostingByEmploymentProcessId",
            PostingBySeniorityPosition = "PostingBySeniorityPosition",
            PostingByDateofSeniority = "PostingByDateofSeniority",
            PostingByPrlDate = "PostingByPrlDate",
            PostingByCardNo = "PostingByCardNo",
            PostingByFingerPrintIdentiyNo = "PostingByFingerPrintIdentiyNo",
            PostingByAttendanceEffectiveDate = "PostingByAttendanceEffectiveDate",
            PostingByAttendanceStatus = "PostingByAttendanceStatus",
            PostingByZoneInfoId = "PostingByZoneInfoId",
            PostingByTelephoneOffice = "PostingByTelephoneOffice",
            PostingByIntercom = "PostingByIntercom",
            PostingByHonoraryDegree = "PostingByHonoraryDegree",
            PostingByTaxRegionId = "PostingByTaxRegionId",
            PostingByTaxAssesseeType = "PostingByTaxAssesseeType",
            PostingByHavingChildWithDisability = "PostingByHavingChildWithDisability",
            PostingByDateofRetirement = "PostingByDateofRetirement",
            PostingBySalaryWithdrawFromZoneId = "PostingBySalaryWithdrawFromZoneId",
            PostingByRegionId = "PostingByRegionId",
            PostingByEtin = "PostingByEtin",
            PostingByIUser = "PostingByIUser",
            PostingByIDate = "PostingByIDate",
            PostingByEUser = "PostingByEUser",
            PostingByEDate = "PostingByEDate",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccFundControlZoneWiseApproverService {
        const baseUrl = "Configurations/AccFundControlZoneWiseApprover";
        function Create(request: Serenity.SaveRequest<AccFundControlZoneWiseApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccFundControlZoneWiseApproverRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFundControlZoneWiseApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFundControlZoneWiseApproverRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccFundControlZoneWiseApprover/Create",
            Update = "Configurations/AccFundControlZoneWiseApprover/Update",
            Delete = "Configurations/AccFundControlZoneWiseApprover/Delete",
            Retrieve = "Configurations/AccFundControlZoneWiseApprover/Retrieve",
            List = "Configurations/AccFundControlZoneWiseApprover/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccGovtLoanReportForm {
        CoaId: Serenity.LookupEditor;
        LoanOpening: Serenity.DecimalEditor;
        LoanRefundOpening: Serenity.DecimalEditor;
        IsInterestFree: Serenity.BooleanEditor;
    }
    class AccGovtLoanReportForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccGovtLoanReportRow {
        Id?: number;
        CoaId?: number;
        LoanOpening?: number;
        LoanRefundOpening?: number;
        IsInterestFree?: boolean;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        CoaIsBalanceSheet?: boolean;
        CoaBalanceSheetNotes?: number;
        CoaIsIncomeExpenditure?: boolean;
        CoaIncomeExpenditureNotes?: number;
        CoaBudgetCode?: string;
        CoaIsHideChildrenFromThisLevel?: boolean;
    }
    namespace AccGovtLoanReportRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccGovtLoanReport";
        const lookupKey = "Configurations.AccGovtLoanReport";
        function getLookup(): Q.Lookup<AccGovtLoanReportRow>;
        const enum Fields {
            Id = "Id",
            CoaId = "CoaId",
            LoanOpening = "LoanOpening",
            LoanRefundOpening = "LoanRefundOpening",
            IsInterestFree = "IsInterestFree",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            CoaIsBalanceSheet = "CoaIsBalanceSheet",
            CoaBalanceSheetNotes = "CoaBalanceSheetNotes",
            CoaIsIncomeExpenditure = "CoaIsIncomeExpenditure",
            CoaIncomeExpenditureNotes = "CoaIncomeExpenditureNotes",
            CoaBudgetCode = "CoaBudgetCode",
            CoaIsHideChildrenFromThisLevel = "CoaIsHideChildrenFromThisLevel",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccGovtLoanReportService {
        const baseUrl = "Configurations/AccGovtLoanReport";
        function Create(request: Serenity.SaveRequest<AccGovtLoanReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccGovtLoanReportRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccGovtLoanReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccGovtLoanReportRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccGovtLoanReport/Create",
            Update = "Configurations/AccGovtLoanReport/Update",
            Delete = "Configurations/AccGovtLoanReport/Delete",
            Retrieve = "Configurations/AccGovtLoanReport/Retrieve",
            List = "Configurations/AccGovtLoanReport/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface AccOpeningBalanceRow {
        Id?: number;
        OpeningBalance?: number;
        CoAid?: number;
        ZoneId?: number;
        FundControlId?: number;
        CoAidAccountCode?: string;
        CoAidAccountCodeCount?: number;
        CoAidAccountGroup?: string;
        CoAidAccountName?: string;
        CoAidAccountNameBangla?: string;
        CoAidCoaMapping?: string;
        CoAidIsBillRef?: number;
        CoAidIsBudgetHead?: number;
        CoAidIsControlhead?: number;
        CoAidIsCostCenterAllocate?: number;
        CoAidLevel?: number;
        CoAidMailingAddress?: string;
        CoAidMailingName?: string;
        CoAidOpeningBalance?: number;
        CoAidRemarks?: string;
        CoAidTaxId?: string;
        CoAidUgcCode?: string;
        CoAidFundControlId?: number;
        CoAidParentAccountId?: number;
        CoAidMultiCurrencyId?: number;
        CoAidEffectCashFlow?: number;
        ZoneZoneName?: string;
        ZoneZoneNameInBengali?: string;
        ZoneZoneCode?: string;
        ZoneSortOrder?: number;
        ZoneOrganogramCategoryTypeId?: number;
        ZoneZoneAddress?: string;
        ZoneZoneAddressInBengali?: string;
        ZonePrefix?: string;
        ZoneIsHeadOffice?: boolean;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlBookingDate?: string;
        FundControlAddress?: string;
        FundControlPhone?: string;
        FundControlMobile?: string;
        FundControlFax?: string;
        FundControlEmail?: string;
        FundControlWebUrl?: string;
        FundControlRemarks?: string;
        FundControlZoneInfoId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccOpeningBalanceRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccOpeningBalance";
        const lookupKey = "Configurations.AccOpeningBalance";
        function getLookup(): Q.Lookup<AccOpeningBalanceRow>;
        const enum Fields {
            Id = "Id",
            OpeningBalance = "OpeningBalance",
            CoAid = "CoAid",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            CoAidAccountCode = "CoAidAccountCode",
            CoAidAccountCodeCount = "CoAidAccountCodeCount",
            CoAidAccountGroup = "CoAidAccountGroup",
            CoAidAccountName = "CoAidAccountName",
            CoAidAccountNameBangla = "CoAidAccountNameBangla",
            CoAidCoaMapping = "CoAidCoaMapping",
            CoAidIsBillRef = "CoAidIsBillRef",
            CoAidIsBudgetHead = "CoAidIsBudgetHead",
            CoAidIsControlhead = "CoAidIsControlhead",
            CoAidIsCostCenterAllocate = "CoAidIsCostCenterAllocate",
            CoAidLevel = "CoAidLevel",
            CoAidMailingAddress = "CoAidMailingAddress",
            CoAidMailingName = "CoAidMailingName",
            CoAidOpeningBalance = "CoAidOpeningBalance",
            CoAidRemarks = "CoAidRemarks",
            CoAidTaxId = "CoAidTaxId",
            CoAidUgcCode = "CoAidUgcCode",
            CoAidFundControlId = "CoAidFundControlId",
            CoAidParentAccountId = "CoAidParentAccountId",
            CoAidMultiCurrencyId = "CoAidMultiCurrencyId",
            CoAidEffectCashFlow = "CoAidEffectCashFlow",
            ZoneZoneName = "ZoneZoneName",
            ZoneZoneNameInBengali = "ZoneZoneNameInBengali",
            ZoneZoneCode = "ZoneZoneCode",
            ZoneSortOrder = "ZoneSortOrder",
            ZoneOrganogramCategoryTypeId = "ZoneOrganogramCategoryTypeId",
            ZoneZoneAddress = "ZoneZoneAddress",
            ZoneZoneAddressInBengali = "ZoneZoneAddressInBengali",
            ZonePrefix = "ZonePrefix",
            ZoneIsHeadOffice = "ZoneIsHeadOffice",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlBookingDate = "FundControlBookingDate",
            FundControlAddress = "FundControlAddress",
            FundControlPhone = "FundControlPhone",
            FundControlMobile = "FundControlMobile",
            FundControlFax = "FundControlFax",
            FundControlEmail = "FundControlEmail",
            FundControlWebUrl = "FundControlWebUrl",
            FundControlRemarks = "FundControlRemarks",
            FundControlZoneInfoId = "FundControlZoneInfoId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccOpeningBalanceService {
        const baseUrl = "Configurations/AccOpeningBalance";
        function Create(request: Serenity.SaveRequest<AccOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccOpeningBalance/Create",
            Update = "Configurations/AccOpeningBalance/Update",
            Delete = "Configurations/AccOpeningBalance/Delete",
            Retrieve = "Configurations/AccOpeningBalance/Retrieve",
            List = "Configurations/AccOpeningBalance/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccPriorYearAdjustmentForm {
        FinancialYearId: Serenity.LookupEditor;
        IncomeTax: Serenity.DecimalEditor;
        Adjustment: Serenity.DecimalEditor;
    }
    class AccPriorYearAdjustmentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccPriorYearAdjustmentRow {
        Id?: number;
        FinancialYearId?: number;
        IncomeTax?: number;
        Adjustment?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }
    namespace AccPriorYearAdjustmentRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccPriorYearAdjustment";
        const lookupKey = "Configurations.AccPriorYearAdjustment";
        function getLookup(): Q.Lookup<AccPriorYearAdjustmentRow>;
        const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            IncomeTax = "IncomeTax",
            Adjustment = "Adjustment",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccPriorYearAdjustmentService {
        const baseUrl = "Configurations/AccPriorYearAdjustment";
        function Create(request: Serenity.SaveRequest<AccPriorYearAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccPriorYearAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccPriorYearAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccPriorYearAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccPriorYearAdjustment/Create",
            Update = "Configurations/AccPriorYearAdjustment/Update",
            Delete = "Configurations/AccPriorYearAdjustment/Delete",
            Retrieve = "Configurations/AccPriorYearAdjustment/Retrieve",
            List = "Configurations/AccPriorYearAdjustment/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeCoaMappingForm {
        ReportTypeId: Serenity.LookupEditor;
        GroupId: Serenity.LookupEditor;
        CoaId: Serenity.LookupEditor;
        OpeningBalance: Serenity.DecimalEditor;
    }
    class AccReportTypeCoaMappingForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeCoaMappingRow {
        Id?: number;
        GroupId?: number;
        CoaId?: number;
        GroupParentId?: number;
        ReportTypeId?: number;
        GroupGroupName?: string;
        GroupSortingOrder?: number;
        GroupShowAutoSum?: boolean;
        GroupNoteNo?: number;
        GroupAddBlankSpaceBefore?: boolean;
        GroupAddBlankSpaceAfter?: boolean;
        GroupShowBottomBorder?: boolean;
        GroupShowUpperBorder?: boolean;
        GroupShowLeftBorder?: boolean;
        GroupShowRightBorder?: boolean;
        GroupFundControlId?: number;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        CoaIsBalanceSheet?: boolean;
        CoaBalanceSheetNotes?: number;
        CoaIsIncomeExpenditure?: boolean;
        CoaIncomeExpenditureNotes?: number;
        CoaBudgetCode?: string;
        CoaIsHideChildrenFromThisLevel?: boolean;
        OpeningBalance?: number;
    }
    namespace AccReportTypeCoaMappingRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccReportTypeCoaMapping";
        const lookupKey = "Configurations.AccReportTypeCoaMapping";
        function getLookup(): Q.Lookup<AccReportTypeCoaMappingRow>;
        const enum Fields {
            Id = "Id",
            GroupId = "GroupId",
            CoaId = "CoaId",
            GroupParentId = "GroupParentId",
            ReportTypeId = "ReportTypeId",
            GroupGroupName = "GroupGroupName",
            GroupSortingOrder = "GroupSortingOrder",
            GroupShowAutoSum = "GroupShowAutoSum",
            GroupNoteNo = "GroupNoteNo",
            GroupAddBlankSpaceBefore = "GroupAddBlankSpaceBefore",
            GroupAddBlankSpaceAfter = "GroupAddBlankSpaceAfter",
            GroupShowBottomBorder = "GroupShowBottomBorder",
            GroupShowUpperBorder = "GroupShowUpperBorder",
            GroupShowLeftBorder = "GroupShowLeftBorder",
            GroupShowRightBorder = "GroupShowRightBorder",
            GroupFundControlId = "GroupFundControlId",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            CoaIsBalanceSheet = "CoaIsBalanceSheet",
            CoaBalanceSheetNotes = "CoaBalanceSheetNotes",
            CoaIsIncomeExpenditure = "CoaIsIncomeExpenditure",
            CoaIncomeExpenditureNotes = "CoaIncomeExpenditureNotes",
            CoaBudgetCode = "CoaBudgetCode",
            CoaIsHideChildrenFromThisLevel = "CoaIsHideChildrenFromThisLevel",
            OpeningBalance = "OpeningBalance",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccReportTypeCoaMappingService {
        const baseUrl = "Configurations/AccReportTypeCoaMapping";
        function Create(request: Serenity.SaveRequest<AccReportTypeCoaMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccReportTypeCoaMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeCoaMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeCoaMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccReportTypeCoaMapping/Create",
            Update = "Configurations/AccReportTypeCoaMapping/Update",
            Delete = "Configurations/AccReportTypeCoaMapping/Delete",
            Retrieve = "Configurations/AccReportTypeCoaMapping/Retrieve",
            List = "Configurations/AccReportTypeCoaMapping/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeCostCenterMappingForm {
        ReportTypeId: Serenity.LookupEditor;
        GroupId: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        OpeningBalance: Serenity.DecimalEditor;
    }
    class AccReportTypeCostCenterMappingForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeCostCenterMappingRow {
        Id?: number;
        GroupId?: number;
        CostCenterId?: number;
        GroupParentId?: number;
        GroupReportTypeId?: number;
        GroupGroupName?: string;
        GroupSortingOrder?: number;
        GroupShowAutoSum?: boolean;
        GroupNoteNo?: number;
        GroupAddBlankSpaceBefore?: boolean;
        GroupAddBlankSpaceAfter?: boolean;
        GroupShowBottomBorder?: boolean;
        GroupShowUpperBorder?: boolean;
        GroupShowLeftBorder?: boolean;
        GroupShowRightBorder?: boolean;
        GroupFundControlId?: number;
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterNameForBankAdviceLetter?: string;
        CostCenterPaAmmount?: number;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterEmpId?: number;
        CostCenterIsActive?: boolean;
        CostCenterEntityId?: number;
        CostCenterZoneInfoId?: number;
        CostCenterIsBudgetHead?: boolean;
        CostCenterBudgetGroupId?: number;
        CostCenterIsFixedAssetHead?: boolean;
        CostCenterIsFixedAssetDevWork?: boolean;
        CostCenterIsFixedAssetNonDevWork?: boolean;
        CostCenterDepreciationRate?: number;
        CostCenterBudgetCode?: string;
        OpeningBalance?: number;
        ReportTypeId?: number;
    }
    namespace AccReportTypeCostCenterMappingRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccReportTypeCostCenterMapping";
        const lookupKey = "Configurations.AccReportTypeCostCenterMapping";
        function getLookup(): Q.Lookup<AccReportTypeCostCenterMappingRow>;
        const enum Fields {
            Id = "Id",
            GroupId = "GroupId",
            CostCenterId = "CostCenterId",
            GroupParentId = "GroupParentId",
            GroupReportTypeId = "GroupReportTypeId",
            GroupGroupName = "GroupGroupName",
            GroupSortingOrder = "GroupSortingOrder",
            GroupShowAutoSum = "GroupShowAutoSum",
            GroupNoteNo = "GroupNoteNo",
            GroupAddBlankSpaceBefore = "GroupAddBlankSpaceBefore",
            GroupAddBlankSpaceAfter = "GroupAddBlankSpaceAfter",
            GroupShowBottomBorder = "GroupShowBottomBorder",
            GroupShowUpperBorder = "GroupShowUpperBorder",
            GroupShowLeftBorder = "GroupShowLeftBorder",
            GroupShowRightBorder = "GroupShowRightBorder",
            GroupFundControlId = "GroupFundControlId",
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterNameForBankAdviceLetter = "CostCenterNameForBankAdviceLetter",
            CostCenterPaAmmount = "CostCenterPaAmmount",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterEmpId = "CostCenterEmpId",
            CostCenterIsActive = "CostCenterIsActive",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterZoneInfoId = "CostCenterZoneInfoId",
            CostCenterIsBudgetHead = "CostCenterIsBudgetHead",
            CostCenterBudgetGroupId = "CostCenterBudgetGroupId",
            CostCenterIsFixedAssetHead = "CostCenterIsFixedAssetHead",
            CostCenterIsFixedAssetDevWork = "CostCenterIsFixedAssetDevWork",
            CostCenterIsFixedAssetNonDevWork = "CostCenterIsFixedAssetNonDevWork",
            CostCenterDepreciationRate = "CostCenterDepreciationRate",
            CostCenterBudgetCode = "CostCenterBudgetCode",
            OpeningBalance = "OpeningBalance",
            ReportTypeId = "ReportTypeId",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccReportTypeCostCenterMappingService {
        const baseUrl = "Configurations/AccReportTypeCostCenterMapping";
        function Create(request: Serenity.SaveRequest<AccReportTypeCostCenterMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccReportTypeCostCenterMappingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeCostCenterMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeCostCenterMappingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccReportTypeCostCenterMapping/Create",
            Update = "Configurations/AccReportTypeCostCenterMapping/Update",
            Delete = "Configurations/AccReportTypeCostCenterMapping/Delete",
            Retrieve = "Configurations/AccReportTypeCostCenterMapping/Retrieve",
            List = "Configurations/AccReportTypeCostCenterMapping/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeForm {
        ReportType: Serenity.StringEditor;
    }
    class AccReportTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeGroupOpeningBalanceForm {
        ReportTypeId: Serenity.LookupEditor;
        GroupId: Serenity.LookupEditor;
        ZoneId: Serenity.LookupEditor;
        FundControlId: Serenity.IntegerEditor;
        OpeningBalance: Serenity.DecimalEditor;
    }
    class AccReportTypeGroupOpeningBalanceForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeGroupOpeningBalanceRow {
        Id?: number;
        GroupId?: number;
        ZoneId?: number;
        FundControlId?: number;
        OpeningBalance?: number;
        GroupParentId?: number;
        ReportTypeId?: number;
        GroupGroupName?: string;
        GroupSortingOrder?: number;
        GroupShowAutoSum?: boolean;
        GroupNoteNo?: number;
        GroupAddBlankSpaceBefore?: boolean;
        GroupAddBlankSpaceAfter?: boolean;
        GroupShowBottomBorder?: boolean;
        GroupShowUpperBorder?: boolean;
        GroupShowLeftBorder?: boolean;
        GroupShowRightBorder?: boolean;
        GroupFundControlId?: number;
        ZoneZoneName?: string;
        ZoneZoneNameInBengali?: string;
        ZoneZoneCode?: string;
        ZoneSortOrder?: number;
        ZoneOrganogramCategoryTypeId?: number;
        ZoneZoneAddress?: string;
        ZoneZoneAddressInBengali?: string;
        ZonePrefix?: string;
        ZoneIsHeadOffice?: boolean;
        ZoneZoneCodeForBillingSystem?: string;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlBookingDate?: string;
        FundControlCurrencyId?: number;
        FundControlAddress?: string;
        FundControlPhone?: string;
        FundControlMobile?: string;
        FundControlFax?: string;
        FundControlEmail?: string;
        FundControlWebUrl?: string;
        FundControlRemarks?: string;
        FundControlZoneInfoId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccReportTypeGroupOpeningBalanceRow {
        const idProperty = "Id";
        const localTextPrefix = "Configurations.AccReportTypeGroupOpeningBalance";
        const lookupKey = "Configurations.AccReportTypeGroupOpeningBalance";
        function getLookup(): Q.Lookup<AccReportTypeGroupOpeningBalanceRow>;
        const enum Fields {
            Id = "Id",
            GroupId = "GroupId",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            OpeningBalance = "OpeningBalance",
            GroupParentId = "GroupParentId",
            ReportTypeId = "ReportTypeId",
            GroupGroupName = "GroupGroupName",
            GroupSortingOrder = "GroupSortingOrder",
            GroupShowAutoSum = "GroupShowAutoSum",
            GroupNoteNo = "GroupNoteNo",
            GroupAddBlankSpaceBefore = "GroupAddBlankSpaceBefore",
            GroupAddBlankSpaceAfter = "GroupAddBlankSpaceAfter",
            GroupShowBottomBorder = "GroupShowBottomBorder",
            GroupShowUpperBorder = "GroupShowUpperBorder",
            GroupShowLeftBorder = "GroupShowLeftBorder",
            GroupShowRightBorder = "GroupShowRightBorder",
            GroupFundControlId = "GroupFundControlId",
            ZoneZoneName = "ZoneZoneName",
            ZoneZoneNameInBengali = "ZoneZoneNameInBengali",
            ZoneZoneCode = "ZoneZoneCode",
            ZoneSortOrder = "ZoneSortOrder",
            ZoneOrganogramCategoryTypeId = "ZoneOrganogramCategoryTypeId",
            ZoneZoneAddress = "ZoneZoneAddress",
            ZoneZoneAddressInBengali = "ZoneZoneAddressInBengali",
            ZonePrefix = "ZonePrefix",
            ZoneIsHeadOffice = "ZoneIsHeadOffice",
            ZoneZoneCodeForBillingSystem = "ZoneZoneCodeForBillingSystem",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlBookingDate = "FundControlBookingDate",
            FundControlCurrencyId = "FundControlCurrencyId",
            FundControlAddress = "FundControlAddress",
            FundControlPhone = "FundControlPhone",
            FundControlMobile = "FundControlMobile",
            FundControlFax = "FundControlFax",
            FundControlEmail = "FundControlEmail",
            FundControlWebUrl = "FundControlWebUrl",
            FundControlRemarks = "FundControlRemarks",
            FundControlZoneInfoId = "FundControlZoneInfoId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccReportTypeGroupOpeningBalanceService {
        const baseUrl = "Configurations/AccReportTypeGroupOpeningBalance";
        function Create(request: Serenity.SaveRequest<AccReportTypeGroupOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccReportTypeGroupOpeningBalanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeGroupOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeGroupOpeningBalanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccReportTypeGroupOpeningBalance/Create",
            Update = "Configurations/AccReportTypeGroupOpeningBalance/Update",
            Delete = "Configurations/AccReportTypeGroupOpeningBalance/Delete",
            Retrieve = "Configurations/AccReportTypeGroupOpeningBalance/Retrieve",
            List = "Configurations/AccReportTypeGroupOpeningBalance/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeGroupSetupForm {
        ReportTypeId: Serenity.LookupEditor;
        ParentId: Serenity.LookupEditor;
        GroupName: Serenity.StringEditor;
        SortingOrder: Serenity.IntegerEditor;
        ShowAutoSum: Serenity.BooleanEditor;
        NoteNo: Serenity.DecimalEditor;
        AddBlankSpaceBefore: Serenity.BooleanEditor;
        AddBlankSpaceAfter: Serenity.BooleanEditor;
        ShowBottomBorder: Serenity.BooleanEditor;
        ShowUpperBorder: Serenity.BooleanEditor;
        ShowLeftBorder: Serenity.BooleanEditor;
        ShowRightBorder: Serenity.BooleanEditor;
        Symbol: Serenity.StringEditor;
        FontWeight: Serenity.StringEditor;
        FundControlId: Serenity.IntegerEditor;
    }
    class AccReportTypeGroupSetupForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeGroupSetupRow {
        Id?: number;
        ParentId?: number;
        ReportTypeId?: number;
        GroupName?: string;
        SortingOrder?: number;
        ShowAutoSum?: boolean;
        NoteNo?: number;
        AddBlankSpaceBefore?: boolean;
        AddBlankSpaceAfter?: boolean;
        ShowBottomBorder?: boolean;
        ShowUpperBorder?: boolean;
        ShowLeftBorder?: boolean;
        ShowRightBorder?: boolean;
        FundControlId?: number;
        ReportType?: string;
        ParentGroupName?: string;
        Symbol?: string;
        FontWeight?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccReportTypeGroupSetupRow {
        const idProperty = "Id";
        const nameProperty = "GroupName";
        const localTextPrefix = "Configurations.AccReportTypeGroupSetup";
        const lookupKey = "Configurations.AccReportTypeGroupSetup";
        function getLookup(): Q.Lookup<AccReportTypeGroupSetupRow>;
        const enum Fields {
            Id = "Id",
            ParentId = "ParentId",
            ReportTypeId = "ReportTypeId",
            GroupName = "GroupName",
            SortingOrder = "SortingOrder",
            ShowAutoSum = "ShowAutoSum",
            NoteNo = "NoteNo",
            AddBlankSpaceBefore = "AddBlankSpaceBefore",
            AddBlankSpaceAfter = "AddBlankSpaceAfter",
            ShowBottomBorder = "ShowBottomBorder",
            ShowUpperBorder = "ShowUpperBorder",
            ShowLeftBorder = "ShowLeftBorder",
            ShowRightBorder = "ShowRightBorder",
            FundControlId = "FundControlId",
            ReportType = "ReportType",
            ParentGroupName = "ParentGroupName",
            Symbol = "Symbol",
            FontWeight = "FontWeight",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccReportTypeGroupSetupService {
        const baseUrl = "Configurations/AccReportTypeGroupSetup";
        function Create(request: Serenity.SaveRequest<AccReportTypeGroupSetupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccReportTypeGroupSetupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeGroupSetupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeGroupSetupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccReportTypeGroupSetup/Create",
            Update = "Configurations/AccReportTypeGroupSetup/Update",
            Delete = "Configurations/AccReportTypeGroupSetup/Delete",
            Retrieve = "Configurations/AccReportTypeGroupSetup/Retrieve",
            List = "Configurations/AccReportTypeGroupSetup/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface AccReportTypeRow {
        Id?: number;
        ReportType?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccReportTypeRow {
        const idProperty = "Id";
        const nameProperty = "ReportType";
        const localTextPrefix = "Configurations.AccReportType";
        const lookupKey = "Configurations.AccReportType";
        function getLookup(): Q.Lookup<AccReportTypeRow>;
        const enum Fields {
            Id = "Id",
            ReportType = "ReportType",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccReportTypeService {
        const baseUrl = "Configurations/AccReportType";
        function Create(request: Serenity.SaveRequest<AccReportTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccReportTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccReportTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccReportTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccReportType/Create",
            Update = "Configurations/AccReportType/Update",
            Delete = "Configurations/AccReportType/Delete",
            Retrieve = "Configurations/AccReportType/Retrieve",
            List = "Configurations/AccReportType/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccSetupForBankAdviceLetterForm {
        CoaId: Serenity.LookupEditor;
        MemorandumNo: Serenity.StringEditor;
        Duplication: Serenity.TextAreaEditor;
        IsAutoBankAdvice: Serenity.BooleanEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        FundControlId: Serenity.IntegerEditor;
    }
    class AccSetupForBankAdviceLetterForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccSetupForBankAdviceLetterRow {
        Id?: number;
        CoaId?: number;
        MemorandumNo?: string;
        Duplication?: string;
        IsAutoBankAdvice?: boolean;
        ZoneInfoId?: number;
        FundControlId?: number;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccSetupForBankAdviceLetterRow {
        const idProperty = "Id";
        const nameProperty = "MemorandumNo";
        const localTextPrefix = "Configurations.AccSetupForBankAdviceLetter";
        const lookupKey = "Configurations.AccSetupForBankAdviceLetter";
        function getLookup(): Q.Lookup<AccSetupForBankAdviceLetterRow>;
        const enum Fields {
            Id = "Id",
            CoaId = "CoaId",
            MemorandumNo = "MemorandumNo",
            Duplication = "Duplication",
            IsAutoBankAdvice = "IsAutoBankAdvice",
            ZoneInfoId = "ZoneInfoId",
            FundControlId = "FundControlId",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccSetupForBankAdviceLetterService {
        const baseUrl = "Configurations/AccSetupForBankAdviceLetter";
        function Create(request: Serenity.SaveRequest<AccSetupForBankAdviceLetterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccSetupForBankAdviceLetterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccSetupForBankAdviceLetterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccSetupForBankAdviceLetterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccSetupForBankAdviceLetter/Create",
            Update = "Configurations/AccSetupForBankAdviceLetter/Update",
            Delete = "Configurations/AccSetupForBankAdviceLetter/Delete",
            Retrieve = "Configurations/AccSetupForBankAdviceLetter/Retrieve",
            List = "Configurations/AccSetupForBankAdviceLetter/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccTransactionTypeForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionType: Serenity.StringEditor;
        TransactionMode: COAMappingEditor;
        SortOrder: Serenity.IntegerEditor;
        IsbyDefault: Serenity.BooleanEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class AccTransactionTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccTransactionTypeRow {
        Id?: number;
        Remarks?: string;
        SortOrder?: number;
        TransactionType?: string;
        FundControlId?: number;
        VoucherTypeId?: number;
        TransactionMode?: string;
        IsbyDefault?: boolean;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlRemarks?: string;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccTransactionTypeRow {
        const idProperty = "Id";
        const nameProperty = "TransactionType";
        const localTextPrefix = "Configurations.AccTransactionType";
        const lookupKey = "Configurations.AccTransactionType";
        function getLookup(): Q.Lookup<AccTransactionTypeRow>;
        const enum Fields {
            Id = "Id",
            Remarks = "Remarks",
            SortOrder = "SortOrder",
            TransactionType = "TransactionType",
            FundControlId = "FundControlId",
            VoucherTypeId = "VoucherTypeId",
            TransactionMode = "TransactionMode",
            IsbyDefault = "IsbyDefault",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlRemarks = "FundControlRemarks",
            VoucherTypeName = "VoucherTypeName",
            VoucherTypeSortOrder = "VoucherTypeSortOrder",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccTransactionTypeService {
        const baseUrl = "Configurations/AccTransactionType";
        function Create(request: Serenity.SaveRequest<AccTransactionTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccTransactionTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccTransactionTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccTransactionTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccTransactionType/Create",
            Update = "Configurations/AccTransactionType/Update",
            Delete = "Configurations/AccTransactionType/Delete",
            Retrieve = "Configurations/AccTransactionType/Retrieve",
            List = "Configurations/AccTransactionType/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccUnitTypeForm {
        UnitName: Serenity.StringEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class AccUnitTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccUnitTypeRow {
        Id?: number;
        UnitName?: string;
        Remarks?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccUnitTypeRow {
        const idProperty = "Id";
        const nameProperty = "UnitName";
        const localTextPrefix = "Configurations.AccUnitType";
        const lookupKey = "Configurations.AccUnitType";
        function getLookup(): Q.Lookup<AccUnitTypeRow>;
        const enum Fields {
            Id = "Id",
            UnitName = "UnitName",
            Remarks = "Remarks",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccUnitTypeService {
        const baseUrl = "Configurations/AccUnitType";
        function Create(request: Serenity.SaveRequest<AccUnitTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccUnitTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccUnitTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccUnitTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccUnitType/Create",
            Update = "Configurations/AccUnitType/Update",
            Delete = "Configurations/AccUnitType/Delete",
            Retrieve = "Configurations/AccUnitType/Retrieve",
            List = "Configurations/AccUnitType/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiConfigDetailsForm {
        AccountHeadId: Serenity.LookupEditor;
        SubLedgerId: Serenity.LookupEditor;
        DrCr: Serenity.StringEditor;
        Description: Serenity.StringEditor;
    }
    class AccVoucherApiConfigDetailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiConfigDetailsRow {
        Id?: number;
        ConfigId?: number;
        AccountHeadId?: number;
        DrCr?: string;
        Description?: string;
        SubLedgerId?: number;
        ConfigConfigName?: string;
        ConfigModuleId?: string;
        ConfigFormName?: string;
        ConfigVouchrTypeId?: number;
        ConfigTransactionId?: number;
        ConfigTransactionMode?: string;
        ConfigNarration?: string;
        ConfigFundControlId?: number;
        AccountHeadAccountCode?: string;
        AccountHeadAccountCodeCount?: number;
        AccountHeadAccountGroup?: string;
        AccountHeadAccountName?: string;
        AccountHeadAccountNameBangla?: string;
        AccountHeadCoaMapping?: string;
        AccountHeadIsBillRef?: number;
        AccountHeadIsBudgetHead?: number;
        AccountHeadIsControlhead?: number;
        AccountHeadIsCostCenterAllocate?: number;
        AccountHeadLevel?: number;
        AccountHeadMailingAddress?: string;
        AccountHeadMailingName?: string;
        AccountHeadOpeningBalance?: number;
        AccountHeadRemarks?: string;
        AccountHeadTaxId?: string;
        AccountHeadUgcCode?: string;
        AccountHeadFundControlId?: number;
        AccountHeadParentAccountId?: number;
        AccountHeadMultiCurrencyId?: number;
        AccountHeadEffectCashFlow?: number;
        AccountHeadUserCode?: string;
    }
    namespace AccVoucherApiConfigDetailsRow {
        const idProperty = "Id";
        const nameProperty = "DrCr";
        const localTextPrefix = "Configurations.AccVoucherApiConfigDetails";
        const lookupKey = "Configurations.AccVoucherApiConfigDetails";
        function getLookup(): Q.Lookup<AccVoucherApiConfigDetailsRow>;
        const enum Fields {
            Id = "Id",
            ConfigId = "ConfigId",
            AccountHeadId = "AccountHeadId",
            DrCr = "DrCr",
            Description = "Description",
            SubLedgerId = "SubLedgerId",
            ConfigConfigName = "ConfigConfigName",
            ConfigModuleId = "ConfigModuleId",
            ConfigFormName = "ConfigFormName",
            ConfigVouchrTypeId = "ConfigVouchrTypeId",
            ConfigTransactionId = "ConfigTransactionId",
            ConfigTransactionMode = "ConfigTransactionMode",
            ConfigNarration = "ConfigNarration",
            ConfigFundControlId = "ConfigFundControlId",
            AccountHeadAccountCode = "AccountHeadAccountCode",
            AccountHeadAccountCodeCount = "AccountHeadAccountCodeCount",
            AccountHeadAccountGroup = "AccountHeadAccountGroup",
            AccountHeadAccountName = "AccountHeadAccountName",
            AccountHeadAccountNameBangla = "AccountHeadAccountNameBangla",
            AccountHeadCoaMapping = "AccountHeadCoaMapping",
            AccountHeadIsBillRef = "AccountHeadIsBillRef",
            AccountHeadIsBudgetHead = "AccountHeadIsBudgetHead",
            AccountHeadIsControlhead = "AccountHeadIsControlhead",
            AccountHeadIsCostCenterAllocate = "AccountHeadIsCostCenterAllocate",
            AccountHeadLevel = "AccountHeadLevel",
            AccountHeadMailingAddress = "AccountHeadMailingAddress",
            AccountHeadMailingName = "AccountHeadMailingName",
            AccountHeadOpeningBalance = "AccountHeadOpeningBalance",
            AccountHeadRemarks = "AccountHeadRemarks",
            AccountHeadTaxId = "AccountHeadTaxId",
            AccountHeadUgcCode = "AccountHeadUgcCode",
            AccountHeadFundControlId = "AccountHeadFundControlId",
            AccountHeadParentAccountId = "AccountHeadParentAccountId",
            AccountHeadMultiCurrencyId = "AccountHeadMultiCurrencyId",
            AccountHeadEffectCashFlow = "AccountHeadEffectCashFlow",
            AccountHeadUserCode = "AccountHeadUserCode",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccVoucherApiConfigDetailsService {
        const baseUrl = "Configurations/AccVoucherApiConfigDetails";
        function Create(request: Serenity.SaveRequest<AccVoucherApiConfigDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherApiConfigDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherApiConfigDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherApiConfigDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccVoucherApiConfigDetails/Create",
            Update = "Configurations/AccVoucherApiConfigDetails/Update",
            Delete = "Configurations/AccVoucherApiConfigDetails/Delete",
            Retrieve = "Configurations/AccVoucherApiConfigDetails/Retrieve",
            List = "Configurations/AccVoucherApiConfigDetails/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiConfigForm {
        ConfigName: Serenity.StringEditor;
        ModuleId: Serenity.StringEditor;
        FormName: Serenity.StringEditor;
        VouchrTypeId: Serenity.LookupEditor;
        TransactionId: Serenity.LookupEditor;
        TransactionMode: Serenity.StringEditor;
        Narration: Serenity.StringEditor;
        FundControlId: Serenity.LookupEditor;
        VoucherApiConfigDetails: AccVoucherApiConfigDetailsEditor;
    }
    class AccVoucherApiConfigForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiConfigRow {
        Id?: number;
        ConfigName?: string;
        ModuleId?: string;
        FormName?: string;
        VouchrTypeId?: number;
        TransactionId?: number;
        TransactionMode?: string;
        Narration?: string;
        FundControlId?: number;
        ZoneInfoId?: number;
        VoucherApiConfigDetails?: AccVoucherApiConfigDetailsRow[];
        VouchrTypeName?: string;
        VouchrTypeSortOrder?: number;
        TransactionRemarks?: string;
        TransactionSortOrder?: number;
        TransactionTransactionType?: string;
        TransactionFundControlId?: number;
        TransactionVoucherTypeId?: number;
        TransactionTransactionMode?: string;
        FundControlCode?: string;
        FundControlFundControlName?: string;
        FundControlBookingDate?: string;
        FundControlCurrencyId?: number;
        FundControlAddress?: string;
        FundControlPhone?: string;
        FundControlMobile?: string;
        FundControlFax?: string;
        FundControlEmail?: string;
        FundControlWebUrl?: string;
        FundControlRemarks?: string;
        FundControlZoneInfoId?: number;
    }
    namespace AccVoucherApiConfigRow {
        const idProperty = "Id";
        const nameProperty = "ConfigName";
        const localTextPrefix = "Configurations.AccVoucherApiConfig";
        const lookupKey = "Configurations.AccVoucherApiConfig";
        function getLookup(): Q.Lookup<AccVoucherApiConfigRow>;
        const enum Fields {
            Id = "Id",
            ConfigName = "ConfigName",
            ModuleId = "ModuleId",
            FormName = "FormName",
            VouchrTypeId = "VouchrTypeId",
            TransactionId = "TransactionId",
            TransactionMode = "TransactionMode",
            Narration = "Narration",
            FundControlId = "FundControlId",
            ZoneInfoId = "ZoneInfoId",
            VoucherApiConfigDetails = "VoucherApiConfigDetails",
            VouchrTypeName = "VouchrTypeName",
            VouchrTypeSortOrder = "VouchrTypeSortOrder",
            TransactionRemarks = "TransactionRemarks",
            TransactionSortOrder = "TransactionSortOrder",
            TransactionTransactionType = "TransactionTransactionType",
            TransactionFundControlId = "TransactionFundControlId",
            TransactionVoucherTypeId = "TransactionVoucherTypeId",
            TransactionTransactionMode = "TransactionTransactionMode",
            FundControlCode = "FundControlCode",
            FundControlFundControlName = "FundControlFundControlName",
            FundControlBookingDate = "FundControlBookingDate",
            FundControlCurrencyId = "FundControlCurrencyId",
            FundControlAddress = "FundControlAddress",
            FundControlPhone = "FundControlPhone",
            FundControlMobile = "FundControlMobile",
            FundControlFax = "FundControlFax",
            FundControlEmail = "FundControlEmail",
            FundControlWebUrl = "FundControlWebUrl",
            FundControlRemarks = "FundControlRemarks",
            FundControlZoneInfoId = "FundControlZoneInfoId",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccVoucherApiConfigService {
        const baseUrl = "Configurations/AccVoucherApiConfig";
        function Create(request: Serenity.SaveRequest<AccVoucherApiConfigRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherApiConfigRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherApiConfigRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherApiConfigRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccVoucherApiConfig/Create",
            Update = "Configurations/AccVoucherApiConfig/Update",
            Delete = "Configurations/AccVoucherApiConfig/Delete",
            Retrieve = "Configurations/AccVoucherApiConfig/Retrieve",
            List = "Configurations/AccVoucherApiConfig/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiDetailsForm {
        ConfigId: Serenity.IntegerEditor;
        AccountHeadId: Serenity.LookupEditor;
        DrCr: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        EmpId: Serenity.IntegerEditor;
    }
    class AccVoucherApiDetailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiDetailsRow {
        Id?: number;
        VoucherApiId?: number;
        AccountHeadId?: number;
        DrCr?: string;
        Description?: string;
        Amount?: number;
        VoucherApiConfigId?: number;
        VoucherApiVouchrTypeId?: number;
        VoucherApiTransactionId?: number;
        VoucherApiNarration?: string;
        VoucherApiTransactionMode?: string;
        VoucherApiEmpId?: number;
        AccountHeadAccountCode?: string;
        AccountHeadAccountCodeCount?: number;
        AccountHeadAccountGroup?: string;
        AccountHeadAccountName?: string;
        AccountHeadAccountNameBangla?: string;
        AccountHeadCoaMapping?: string;
        AccountHeadIsBillRef?: number;
        AccountHeadIsBudgetHead?: number;
        AccountHeadIsControlhead?: number;
        AccountHeadIsCostCenterAllocate?: number;
        AccountHeadLevel?: number;
        AccountHeadMailingAddress?: string;
        AccountHeadMailingName?: string;
        AccountHeadOpeningBalance?: number;
        AccountHeadRemarks?: string;
        AccountHeadTaxId?: string;
        AccountHeadUgcCode?: string;
        AccountHeadFundControlId?: number;
        AccountHeadParentAccountId?: number;
        AccountHeadMultiCurrencyId?: number;
        AccountHeadEffectCashFlow?: number;
        AccountHeadUserCode?: string;
    }
    namespace AccVoucherApiDetailsRow {
        const idProperty = "Id";
        const nameProperty = "DrCr";
        const localTextPrefix = "Configurations.AccVoucherApiDetails";
        const lookupKey = "Configurations.AccVoucherApiDetails";
        function getLookup(): Q.Lookup<AccVoucherApiDetailsRow>;
        const enum Fields {
            Id = "Id",
            VoucherApiId = "VoucherApiId",
            AccountHeadId = "AccountHeadId",
            DrCr = "DrCr",
            Description = "Description",
            Amount = "Amount",
            VoucherApiConfigId = "VoucherApiConfigId",
            VoucherApiVouchrTypeId = "VoucherApiVouchrTypeId",
            VoucherApiTransactionId = "VoucherApiTransactionId",
            VoucherApiNarration = "VoucherApiNarration",
            VoucherApiTransactionMode = "VoucherApiTransactionMode",
            VoucherApiEmpId = "VoucherApiEmpId",
            AccountHeadAccountCode = "AccountHeadAccountCode",
            AccountHeadAccountCodeCount = "AccountHeadAccountCodeCount",
            AccountHeadAccountGroup = "AccountHeadAccountGroup",
            AccountHeadAccountName = "AccountHeadAccountName",
            AccountHeadAccountNameBangla = "AccountHeadAccountNameBangla",
            AccountHeadCoaMapping = "AccountHeadCoaMapping",
            AccountHeadIsBillRef = "AccountHeadIsBillRef",
            AccountHeadIsBudgetHead = "AccountHeadIsBudgetHead",
            AccountHeadIsControlhead = "AccountHeadIsControlhead",
            AccountHeadIsCostCenterAllocate = "AccountHeadIsCostCenterAllocate",
            AccountHeadLevel = "AccountHeadLevel",
            AccountHeadMailingAddress = "AccountHeadMailingAddress",
            AccountHeadMailingName = "AccountHeadMailingName",
            AccountHeadOpeningBalance = "AccountHeadOpeningBalance",
            AccountHeadRemarks = "AccountHeadRemarks",
            AccountHeadTaxId = "AccountHeadTaxId",
            AccountHeadUgcCode = "AccountHeadUgcCode",
            AccountHeadFundControlId = "AccountHeadFundControlId",
            AccountHeadParentAccountId = "AccountHeadParentAccountId",
            AccountHeadMultiCurrencyId = "AccountHeadMultiCurrencyId",
            AccountHeadEffectCashFlow = "AccountHeadEffectCashFlow",
            AccountHeadUserCode = "AccountHeadUserCode",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccVoucherApiDetailsService {
        const baseUrl = "Configurations/AccVoucherApiDetails";
        function Create(request: Serenity.SaveRequest<AccVoucherApiDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherApiDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherApiDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherApiDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccVoucherApiDetails/Create",
            Update = "Configurations/AccVoucherApiDetails/Update",
            Delete = "Configurations/AccVoucherApiDetails/Delete",
            Retrieve = "Configurations/AccVoucherApiDetails/Retrieve",
            List = "Configurations/AccVoucherApiDetails/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiForm {
        ConfigId: Serenity.LookupEditor;
        VouchrTypeId: Serenity.IntegerEditor;
        TransactionId: Serenity.IntegerEditor;
        Narration: Serenity.StringEditor;
        TransactionMode: Serenity.StringEditor;
        EmpId: Serenity.LookupEditor;
    }
    class AccVoucherApiForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccVoucherApiRow {
        Id?: number;
        ConfigId?: number;
        VouchrTypeId?: number;
        TransactionId?: number;
        Narration?: string;
        TransactionMode?: string;
        EmpId?: number;
        ConfigConfigName?: string;
        ConfigModuleId?: string;
        ConfigFormName?: string;
        ConfigVouchrTypeId?: number;
        ConfigTransactionId?: number;
        ConfigTransactionMode?: string;
        ConfigNarration?: string;
        ConfigFundControlId?: number;
        EmpEmpId?: string;
        EmpEmployeeInitial?: string;
        EmpTitleId?: number;
        EmpFirstName?: string;
        EmpMiddleName?: string;
        EmpLastName?: string;
        EmpFullName?: string;
        EmpFullNameBangla?: string;
        EmpDateofJoining?: string;
        EmpProvisionMonth?: number;
        EmpDateofConfirmation?: string;
        EmpDateofPosition?: string;
        EmpDesignationId?: number;
        EmpStatusDesignationId?: number;
        EmpDisciplineId?: number;
        EmpDivisionId?: number;
        EmpSectionId?: number;
        EmpSubSectionId?: number;
        EmpJobLocationId?: number;
        EmpResourceLevelId?: number;
        EmpStaffCategoryId?: number;
        EmpEmploymentTypeId?: number;
        EmpReligionId?: number;
        EmpIsContractual?: boolean;
        EmpIsConsultant?: boolean;
        EmpIsOvertimeEligible?: boolean;
        EmpOvertimeRate?: number;
        EmpMobileNo?: string;
        EmpEmialAddress?: string;
        EmpBankId?: number;
        EmpBankBranchId?: number;
        EmpBankAccountNo?: string;
        EmpEmploymentStatusId?: number;
        EmpDateofInactive?: string;
        EmpIsBonusEligible?: boolean;
        EmpSalaryScaleId?: number;
        EmpJobGradeId?: number;
        EmpGender?: string;
        EmpContractExpireDate?: string;
        EmpDateofBirth?: string;
        EmpContractDuration?: number;
        EmpContractType?: number;
        EmpOrganogramLevelId?: number;
        EmpDateofAppointment?: string;
        EmpOrderNo?: string;
        EmpQuotaId?: number;
        EmpEmployeeClassId?: number;
        EmpEmploymentProcessId?: number;
        EmpSeniorityPosition?: string;
        EmpDateofSeniority?: string;
        EmpPrlDate?: string;
        EmpIsPensionEligible?: boolean;
        EmpIsLeverageEligible?: boolean;
        EmpCardNo?: string;
        EmpFingerPrintIdentiyNo?: string;
        EmpAttendanceEffectiveDate?: string;
        EmpAttendanceStatus?: boolean;
        EmpIUser?: string;
        EmpIDate?: string;
        EmpEUser?: string;
        EmpEDate?: string;
        EmpIsGeneralShifted?: boolean;
        EmpZoneInfoId?: number;
        EmpTelephoneOffice?: string;
        EmpIntercom?: string;
        EmpHonoraryDegree?: string;
        EmpIsEligibleForCpf?: boolean;
        EmpTaxRegionId?: number;
        EmpTaxAssesseeType?: number;
        EmpHavingChildWithDisability?: boolean;
        EmpDateofRetirement?: string;
        EmpSalaryWithdrawFromZoneId?: number;
        EmpRegionId?: number;
    }
    namespace AccVoucherApiRow {
        const idProperty = "Id";
        const nameProperty = "Narration";
        const localTextPrefix = "Configurations.AccVoucherApi";
        const lookupKey = "Configurations.AccVoucherApiRow";
        function getLookup(): Q.Lookup<AccVoucherApiRow>;
        const enum Fields {
            Id = "Id",
            ConfigId = "ConfigId",
            VouchrTypeId = "VouchrTypeId",
            TransactionId = "TransactionId",
            Narration = "Narration",
            TransactionMode = "TransactionMode",
            EmpId = "EmpId",
            ConfigConfigName = "ConfigConfigName",
            ConfigModuleId = "ConfigModuleId",
            ConfigFormName = "ConfigFormName",
            ConfigVouchrTypeId = "ConfigVouchrTypeId",
            ConfigTransactionId = "ConfigTransactionId",
            ConfigTransactionMode = "ConfigTransactionMode",
            ConfigNarration = "ConfigNarration",
            ConfigFundControlId = "ConfigFundControlId",
            EmpEmpId = "EmpEmpId",
            EmpEmployeeInitial = "EmpEmployeeInitial",
            EmpTitleId = "EmpTitleId",
            EmpFirstName = "EmpFirstName",
            EmpMiddleName = "EmpMiddleName",
            EmpLastName = "EmpLastName",
            EmpFullName = "EmpFullName",
            EmpFullNameBangla = "EmpFullNameBangla",
            EmpDateofJoining = "EmpDateofJoining",
            EmpProvisionMonth = "EmpProvisionMonth",
            EmpDateofConfirmation = "EmpDateofConfirmation",
            EmpDateofPosition = "EmpDateofPosition",
            EmpDesignationId = "EmpDesignationId",
            EmpStatusDesignationId = "EmpStatusDesignationId",
            EmpDisciplineId = "EmpDisciplineId",
            EmpDivisionId = "EmpDivisionId",
            EmpSectionId = "EmpSectionId",
            EmpSubSectionId = "EmpSubSectionId",
            EmpJobLocationId = "EmpJobLocationId",
            EmpResourceLevelId = "EmpResourceLevelId",
            EmpStaffCategoryId = "EmpStaffCategoryId",
            EmpEmploymentTypeId = "EmpEmploymentTypeId",
            EmpReligionId = "EmpReligionId",
            EmpIsContractual = "EmpIsContractual",
            EmpIsConsultant = "EmpIsConsultant",
            EmpIsOvertimeEligible = "EmpIsOvertimeEligible",
            EmpOvertimeRate = "EmpOvertimeRate",
            EmpMobileNo = "EmpMobileNo",
            EmpEmialAddress = "EmpEmialAddress",
            EmpBankId = "EmpBankId",
            EmpBankBranchId = "EmpBankBranchId",
            EmpBankAccountNo = "EmpBankAccountNo",
            EmpEmploymentStatusId = "EmpEmploymentStatusId",
            EmpDateofInactive = "EmpDateofInactive",
            EmpIsBonusEligible = "EmpIsBonusEligible",
            EmpSalaryScaleId = "EmpSalaryScaleId",
            EmpJobGradeId = "EmpJobGradeId",
            EmpGender = "EmpGender",
            EmpContractExpireDate = "EmpContractExpireDate",
            EmpDateofBirth = "EmpDateofBirth",
            EmpContractDuration = "EmpContractDuration",
            EmpContractType = "EmpContractType",
            EmpOrganogramLevelId = "EmpOrganogramLevelId",
            EmpDateofAppointment = "EmpDateofAppointment",
            EmpOrderNo = "EmpOrderNo",
            EmpQuotaId = "EmpQuotaId",
            EmpEmployeeClassId = "EmpEmployeeClassId",
            EmpEmploymentProcessId = "EmpEmploymentProcessId",
            EmpSeniorityPosition = "EmpSeniorityPosition",
            EmpDateofSeniority = "EmpDateofSeniority",
            EmpPrlDate = "EmpPrlDate",
            EmpIsPensionEligible = "EmpIsPensionEligible",
            EmpIsLeverageEligible = "EmpIsLeverageEligible",
            EmpCardNo = "EmpCardNo",
            EmpFingerPrintIdentiyNo = "EmpFingerPrintIdentiyNo",
            EmpAttendanceEffectiveDate = "EmpAttendanceEffectiveDate",
            EmpAttendanceStatus = "EmpAttendanceStatus",
            EmpIUser = "EmpIUser",
            EmpIDate = "EmpIDate",
            EmpEUser = "EmpEUser",
            EmpEDate = "EmpEDate",
            EmpIsGeneralShifted = "EmpIsGeneralShifted",
            EmpZoneInfoId = "EmpZoneInfoId",
            EmpTelephoneOffice = "EmpTelephoneOffice",
            EmpIntercom = "EmpIntercom",
            EmpHonoraryDegree = "EmpHonoraryDegree",
            EmpIsEligibleForCpf = "EmpIsEligibleForCpf",
            EmpTaxRegionId = "EmpTaxRegionId",
            EmpTaxAssesseeType = "EmpTaxAssesseeType",
            EmpHavingChildWithDisability = "EmpHavingChildWithDisability",
            EmpDateofRetirement = "EmpDateofRetirement",
            EmpSalaryWithdrawFromZoneId = "EmpSalaryWithdrawFromZoneId",
            EmpRegionId = "EmpRegionId",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccVoucherApiService {
        const baseUrl = "Configurations/AccVoucherApi";
        function Create(request: Serenity.SaveRequest<AccVoucherApiRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherApiRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherApiRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherApiRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccVoucherApi/Create",
            Update = "Configurations/AccVoucherApi/Update",
            Delete = "Configurations/AccVoucherApi/Delete",
            Retrieve = "Configurations/AccVoucherApi/Retrieve",
            List = "Configurations/AccVoucherApi/List",
        }
    }
}
declare namespace VistaGL.Configurations {
}
declare namespace VistaGL.Configurations {
    interface AccVoucherTypeForm {
        Name: Serenity.StringEditor;
        SortOrder: Serenity.IntegerEditor;
    }
    class AccVoucherTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface AccVoucherTypeRow {
        Id?: number;
        Name?: string;
        SortOrder?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccVoucherTypeRow {
        const idProperty = "Id";
        const nameProperty = "Name";
        const localTextPrefix = "Configurations.AccVoucherType";
        const lookupKey = "Configurations.AccVoucherType";
        function getLookup(): Q.Lookup<AccVoucherTypeRow>;
        const enum Fields {
            Id = "Id",
            Name = "Name",
            SortOrder = "SortOrder",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace AccVoucherTypeService {
        const baseUrl = "Configurations/AccVoucherType";
        function Create(request: Serenity.SaveRequest<AccVoucherTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/AccVoucherType/Create",
            Update = "Configurations/AccVoucherType/Update",
            Delete = "Configurations/AccVoucherType/Delete",
            Retrieve = "Configurations/AccVoucherType/Retrieve",
            List = "Configurations/AccVoucherType/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface ImportCoAForm {
        CoADebit: CoAEditor;
    }
    class ImportCoAForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface PrmDepartmentRow {
        Id?: number;
        Name?: string;
        SortOrder?: number;
        Remarks?: string;
        ZoneInfoId?: number;
        ZoneInfoZoneName?: string;
    }
    namespace PrmDepartmentRow {
        const idProperty = "Id";
        const nameProperty = "Name";
        const localTextPrefix = "Configurations.PrmDepartment";
        const enum Fields {
            Id = "Id",
            Name = "Name",
            SortOrder = "SortOrder",
            Remarks = "Remarks",
            ZoneInfoId = "ZoneInfoId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface PrmEmploymentInfoRow {
        Id?: number;
        EmpId?: string;
        EmployeeInitial?: string;
        TitleId?: number;
        FirstName?: string;
        MiddleName?: string;
        LastName?: string;
        FullName?: string;
        FullNameBangla?: string;
        DateofJoining?: string;
        ProvisionMonth?: number;
        DateofConfirmation?: string;
        DateofPosition?: string;
        DesignationId?: number;
        StatusDesignationId?: number;
        DisciplineId?: number;
        DivisionId?: number;
        StaffCategoryId?: number;
        SectionId?: number;
        BankId?: number;
        BankBranchId?: number;
        BankAccountNo?: string;
        EmploymentStatusId?: number;
        DateofInactive?: string;
        Gender?: string;
        ZoneInfoId?: number;
        LookupText?: string;
        DesignationName?: string;
        ZoneInfoZoneName?: string;
        StatusDesignationName?: string;
        DivisionName?: string;
        StaffCategoryName?: string;
    }
    namespace PrmEmploymentInfoRow {
        const idProperty = "Id";
        const nameProperty = "LookupText";
        const localTextPrefix = "Configurations.PrmEmploymentInfo";
        const lookupKey = "Configurations.PrmEmploymentInfo";
        function getLookup(): Q.Lookup<PrmEmploymentInfoRow>;
        const enum Fields {
            Id = "Id",
            EmpId = "EmpId",
            EmployeeInitial = "EmployeeInitial",
            TitleId = "TitleId",
            FirstName = "FirstName",
            MiddleName = "MiddleName",
            LastName = "LastName",
            FullName = "FullName",
            FullNameBangla = "FullNameBangla",
            DateofJoining = "DateofJoining",
            ProvisionMonth = "ProvisionMonth",
            DateofConfirmation = "DateofConfirmation",
            DateofPosition = "DateofPosition",
            DesignationId = "DesignationId",
            StatusDesignationId = "StatusDesignationId",
            DisciplineId = "DisciplineId",
            DivisionId = "DivisionId",
            StaffCategoryId = "StaffCategoryId",
            SectionId = "SectionId",
            BankId = "BankId",
            BankBranchId = "BankBranchId",
            BankAccountNo = "BankAccountNo",
            EmploymentStatusId = "EmploymentStatusId",
            DateofInactive = "DateofInactive",
            Gender = "Gender",
            ZoneInfoId = "ZoneInfoId",
            LookupText = "LookupText",
            DesignationName = "DesignationName",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            StatusDesignationName = "StatusDesignationName",
            DivisionName = "DivisionName",
            StaffCategoryName = "StaffCategoryName",
        }
    }
}
declare namespace VistaGL.Configurations {
    namespace PrmEmploymentInfoService {
        const baseUrl = "Configurations/PrmEmploymentInfo";
        function Create(request: Serenity.SaveRequest<PrmEmploymentInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<PrmEmploymentInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PrmEmploymentInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PrmEmploymentInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Configurations/PrmEmploymentInfo/Create",
            Update = "Configurations/PrmEmploymentInfo/Update",
            Delete = "Configurations/PrmEmploymentInfo/Delete",
            Retrieve = "Configurations/PrmEmploymentInfo/Retrieve",
            List = "Configurations/PrmEmploymentInfo/List",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface PrmZoneInfoRow {
        Id?: number;
        ZoneName?: string;
        ZoneNameInBengali?: string;
        ZoneCode?: string;
        SortOrder?: number;
        OrganogramCategoryTypeId?: number;
        ZoneAddress?: string;
        ZoneAddressInBengali?: string;
        Prefix?: string;
        IsHeadOffice?: boolean;
    }
    namespace PrmZoneInfoRow {
        const idProperty = "Id";
        const nameProperty = "ZoneName";
        const localTextPrefix = "Configurations.PrmZoneInfo";
        const lookupKey = "Configurations.PrmZoneInfoRow";
        function getLookup(): Q.Lookup<PrmZoneInfoRow>;
        const enum Fields {
            Id = "Id",
            ZoneName = "ZoneName",
            ZoneNameInBengali = "ZoneNameInBengali",
            ZoneCode = "ZoneCode",
            SortOrder = "SortOrder",
            OrganogramCategoryTypeId = "OrganogramCategoryTypeId",
            ZoneAddress = "ZoneAddress",
            ZoneAddressInBengali = "ZoneAddressInBengali",
            Prefix = "Prefix",
            IsHeadOffice = "IsHeadOffice",
        }
    }
}
declare namespace VistaGL.Configurations {
    interface SaveCoAListRequest extends Serenity.ServiceRequest {
        List?: Transaction.AccTransactionTypeAssignRow[];
    }
}
declare namespace VistaGL.Configurations {
    interface SaveCoAListResponse extends Serenity.ServiceResponse {
    }
}
declare namespace VistaGL.Configurations {
    interface selectFundControlInformationsForm {
        FundControlInformationId: Serenity.LookupEditor;
    }
    class selectFundControlInformationsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Configurations {
    interface VoucherPreviewForm {
        FundControlInformationId: Serenity.LookupEditor;
    }
    class VoucherPreviewForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Default {
}
declare namespace VistaGL.Default {
    interface AuditLogForm {
        UserId: Serenity.IntegerEditor;
        UserName: Serenity.StringEditor;
        UserFullName: Serenity.StringEditor;
        ZoneName: Serenity.StringEditor;
        Action: Serenity.LookupEditor;
        ChangedOn: Serenity.DateTimeEditor;
        Module: Serenity.StringEditor;
        Page: Serenity.StringEditor;
        RowId: Serenity.IntegerEditor;
        DBTableName: Serenity.LookupEditor;
        Changes: Serenity.TextAreaEditor;
    }
    class AuditLogForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Default {
    interface AuditLogRow {
        Id?: number;
        UserId?: number;
        UserName?: string;
        Action?: string;
        ChangedOn?: string;
        DBTableName?: string;
        RowId?: number;
        Module?: string;
        Page?: string;
        Changes?: string;
    }
    namespace AuditLogRow {
        const idProperty = "Id";
        const nameProperty = "UserName";
        const localTextPrefix = "Default.AuditLog";
        const lookupKey = "Default.AuditLog";
        function getLookup(): Q.Lookup<AuditLogRow>;
        const enum Fields {
            Id = "Id",
            UserId = "UserId",
            UserName = "UserName",
            Action = "Action",
            ChangedOn = "ChangedOn",
            DBTableName = "DBTableName",
            RowId = "RowId",
            Module = "Module",
            Page = "Page",
            Changes = "Changes",
        }
    }
}
declare namespace VistaGL.Default {
    namespace AuditLogService {
        const baseUrl = "Default/AuditLog";
        function Create(request: Serenity.SaveRequest<AuditLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AuditLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AuditLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AuditLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/AuditLog/Create",
            Update = "Default/AuditLog/Update",
            Delete = "Default/AuditLog/Delete",
            Retrieve = "Default/AuditLog/Retrieve",
            List = "Default/AuditLog/List",
        }
    }
}
declare namespace VistaGL {
    enum EffectinCashFlow {
        Investing = 0,
        Operating = 1,
        Financing = 2,
    }
}
declare namespace VistaGL {
    interface ExcelImportRequest extends Serenity.ServiceRequest {
        FileName?: string;
    }
}
declare namespace VistaGL {
    interface ExcelImportResponse extends Serenity.ServiceResponse {
        Inserted?: number;
        Updated?: number;
        ErrorList?: string[];
    }
}
declare namespace VistaGL {
    enum FixedAssetDevWorkType {
        IsFixedAssetDevWork = 1,
        IsFixedAssetNonDevWork = 2,
    }
}
declare namespace VistaGL {
    interface GetApproverInfoByApplicantRequest extends Serenity.ServiceRequest {
        ApprovalStepTypeId?: number;
    }
}
declare namespace VistaGL {
    interface GetNewVoucherNoRequest extends Serenity.ServiceRequest {
        TransactionTypeId?: number;
        FundControlInformationId?: number;
        VoucherDate?: string;
        ZoneId?: number;
        FinancialYearId?: number;
        BankAccId?: number;
    }
}
declare namespace VistaGL {
    interface GetNewVoucherNoResponse extends Serenity.ServiceResponse {
        VoucherNo?: string;
        VoucherNumber?: string;
    }
}
declare namespace VistaGL.HRM {
    interface EmploymentInfoRow {
        Id?: number;
        EmpId?: string;
        EmployeeInitial?: string;
        TitleId?: number;
        FirstName?: string;
        MiddleName?: string;
        LastName?: string;
        FullName?: string;
        DesignationId?: number;
        DisciplineId?: number;
        DivisionId?: number;
        EmploymentStatusId?: number;
        PrlDate?: string;
        RegionId?: number;
        TitleName?: string;
        LookupText?: string;
        DesignationName?: string;
        DisciplineName?: string;
        DivisionName?: string;
        EmploymentStatusName?: string;
    }
    namespace EmploymentInfoRow {
        const idProperty = "Id";
        const nameProperty = "LookupText";
        const localTextPrefix = "HRM.EmploymentInfo";
        const lookupKey = "HRM.EmploymentInfo";
        function getLookup(): Q.Lookup<EmploymentInfoRow>;
        const enum Fields {
            Id = "Id",
            EmpId = "EmpId",
            EmployeeInitial = "EmployeeInitial",
            TitleId = "TitleId",
            FirstName = "FirstName",
            MiddleName = "MiddleName",
            LastName = "LastName",
            FullName = "FullName",
            DesignationId = "DesignationId",
            DisciplineId = "DisciplineId",
            DivisionId = "DivisionId",
            EmploymentStatusId = "EmploymentStatusId",
            PrlDate = "PrlDate",
            RegionId = "RegionId",
            TitleName = "TitleName",
            LookupText = "LookupText",
            DesignationName = "DesignationName",
            DisciplineName = "DisciplineName",
            DivisionName = "DivisionName",
            EmploymentStatusName = "EmploymentStatusName",
        }
    }
}
declare namespace VistaGL.HRM {
    namespace EmploymentInfoService {
        const baseUrl = "HRM/EmploymentInfo";
        function Create(request: Serenity.SaveRequest<EmploymentInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<EmploymentInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<EmploymentInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<EmploymentInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "HRM/EmploymentInfo/Create",
            Update = "HRM/EmploymentInfo/Update",
            Delete = "HRM/EmploymentInfo/Delete",
            Retrieve = "HRM/EmploymentInfo/Retrieve",
            List = "HRM/EmploymentInfo/List",
        }
    }
}
declare namespace VistaGL.Membership {
    interface ChangePasswordForm {
        OldPassword: Serenity.PasswordEditor;
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class ChangePasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Membership {
    interface ChangePasswordRequest extends Serenity.ServiceRequest {
        OldPassword?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace VistaGL.Membership {
    interface ForgotPasswordForm {
        Email: Serenity.EmailEditor;
    }
    class ForgotPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Membership {
    interface ForgotPasswordRequest extends Serenity.ServiceRequest {
        Email?: string;
    }
}
declare namespace VistaGL.Membership {
    interface LoginForm {
        Username: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
    }
    class LoginForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Membership {
    interface LoginRequest extends Serenity.ServiceRequest {
        Username?: string;
        Password?: string;
    }
}
declare namespace VistaGL.Membership {
    interface ResetPasswordForm {
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class ResetPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Membership {
    interface ResetPasswordRequest extends Serenity.ServiceRequest {
        Token?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace VistaGL.Membership {
    interface SignUpForm {
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ConfirmEmail: Serenity.EmailEditor;
        Password: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class SignUpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Membership {
    interface SignUpRequest extends Serenity.ServiceRequest {
        DisplayName?: string;
        Email?: string;
        Password?: string;
    }
}
declare namespace VistaGL {
    enum RTransferType {
        BanktoBank = 0,
        BanktoCash = 1,
        CashtoBank = 2,
    }
}
declare namespace VistaGL {
    interface ScriptUserDefinition {
        Username?: string;
        DisplayName?: string;
        IsAdmin?: boolean;
        FundControlInformationId?: number;
        BaseCurrencyId?: number;
        BaseCurrency?: string;
        ZoneID?: number;
        FundControlName?: string;
        ZoneName?: string;
        FinancialYearName?: string;
        EmpId?: number;
        Permissions?: {
            [key: string]: boolean;
        };
        DesignationName?: string;
    }
}
declare namespace VistaGL {
    enum SignatureType {
        PreparedBy = 1,
        CheckedBy = 2,
        ApprovedBy = 3,
        PostedBy = 4,
    }
}
declare namespace VistaGL {
    interface StringMessageResponse extends Serenity.ServiceResponse {
        OutoutMessage?: string;
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    namespace AccBankAdviceLetterService {
        const baseUrl = "Transaction/AccBankAdviceLetter";
        function Create(request: Serenity.SaveRequest<AccChequeRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccChequeRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChequeRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChequeRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBankAdviceLetter/Create",
            Update = "Transaction/AccBankAdviceLetter/Update",
            Delete = "Transaction/AccBankAdviceLetter/Delete",
            Retrieve = "Transaction/AccBankAdviceLetter/Retrieve",
            List = "Transaction/AccBankAdviceLetter/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccBankReconciliationDirectForm {
        VoucherDate: Serenity.DateEditor;
        VoucherNumber: Serenity.StringEditor;
        TransactionType: BRTransactionTypeEditorDDL;
        BankAccountInformationId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        PaytoOrReciveFrom: _Ext.AutoCompleteEditor;
        ChequeNo: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        ClearDate: Serenity.DateEditor;
        Description: Serenity.StringEditor;
        FundControlInformationId: Serenity.LookupEditor;
    }
    class AccBankReconciliationDirectForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccBankReconciliationDirectRow {
        Id?: number;
        Amount?: number;
        ChequeDate?: string;
        ChequeNo?: string;
        ClearDate?: string;
        Description?: string;
        IsBankReconcile?: boolean;
        IsCash?: boolean;
        PaytoOrReciveFrom?: string;
        TransactionMode?: string;
        TransactionType?: string;
        VoucherDate?: string;
        VoucherNumber?: string;
        FundControlInformationId?: number;
        BankAccountInformationId?: number;
        ZoneInfoId?: number;
        VoucherDetailId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBankReconciliationDirectRow {
        const idProperty = "Id";
        const nameProperty = "ChequeNo";
        const localTextPrefix = "Transaction.AccBankReconciliationDirect";
        const lookupKey = "Transaction.AccBankReconciliationDirect";
        function getLookup(): Q.Lookup<AccBankReconciliationDirectRow>;
        const enum Fields {
            Id = "Id",
            Amount = "Amount",
            ChequeDate = "ChequeDate",
            ChequeNo = "ChequeNo",
            ClearDate = "ClearDate",
            Description = "Description",
            IsBankReconcile = "IsBankReconcile",
            IsCash = "IsCash",
            PaytoOrReciveFrom = "PaytoOrReciveFrom",
            TransactionMode = "TransactionMode",
            TransactionType = "TransactionType",
            VoucherDate = "VoucherDate",
            VoucherNumber = "VoucherNumber",
            FundControlInformationId = "FundControlInformationId",
            BankAccountInformationId = "BankAccountInformationId",
            ZoneInfoId = "ZoneInfoId",
            VoucherDetailId = "VoucherDetailId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBankReconciliationDirectService {
        const baseUrl = "Transaction/AccBankReconciliationDirect";
        function Create(request: Serenity.SaveRequest<AccBankReconciliationDirectRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBankReconciliationDirectRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBankReconciliationDirectRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBankReconciliationDirectRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBankReconciliationDirect/Create",
            Update = "Transaction/AccBankReconciliationDirect/Update",
            Delete = "Transaction/AccBankReconciliationDirect/Delete",
            Retrieve = "Transaction/AccBankReconciliationDirect/Retrieve",
            List = "Transaction/AccBankReconciliationDirect/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccBudgetApprovalHistoryForm {
        BudgetForDepartmentId: Serenity.IntegerEditor;
        FromAppoverId: Serenity.IntegerEditor;
        ApprovalStatusId: Serenity.EnumEditor;
        ToApproverId: Serenity.IntegerEditor;
    }
    class AccBudgetApprovalHistoryForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetApprovalHistoryRow {
        Id?: number;
        BudgetForDepartmentId?: number;
        FromAppoverId?: number;
        ApprovalStatusId?: ApprovalStatus;
        ToApproverId?: number;
        BudgetBudgetCircularId?: number;
        BudgetZoneId?: number;
        BudgetDepartmentId?: number;
        BudgetApprovalStatusId?: number;
        BudgetForwardToEmployeeId?: number;
        FromEmpFullName?: string;
        ToEmpFullName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBudgetApprovalHistoryRow {
        const idProperty = "Id";
        const localTextPrefix = "Transaction.AccBudgetApprovalHistory";
        const enum Fields {
            Id = "Id",
            BudgetForDepartmentId = "BudgetForDepartmentId",
            FromAppoverId = "FromAppoverId",
            ApprovalStatusId = "ApprovalStatusId",
            ToApproverId = "ToApproverId",
            BudgetBudgetCircularId = "BudgetBudgetCircularId",
            BudgetZoneId = "BudgetZoneId",
            BudgetDepartmentId = "BudgetDepartmentId",
            BudgetApprovalStatusId = "BudgetApprovalStatusId",
            BudgetForwardToEmployeeId = "BudgetForwardToEmployeeId",
            FromEmpFullName = "FromEmpFullName",
            ToEmpFullName = "ToEmpFullName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBudgetApprovalHistoryService {
        const baseUrl = "Transaction/AccBudgetApprovalHistory";
        function Create(request: Serenity.SaveRequest<AccBudgetApprovalHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetApprovalHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetApprovalHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetApprovalHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBudgetApprovalHistory/Create",
            Update = "Transaction/AccBudgetApprovalHistory/Update",
            Delete = "Transaction/AccBudgetApprovalHistory/Delete",
            Retrieve = "Transaction/AccBudgetApprovalHistory/Retrieve",
            List = "Transaction/AccBudgetApprovalHistory/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccBudgetCircularForm {
        FinancialYearId: Serenity.LookupEditor;
        IsActive: Serenity.BooleanEditor;
    }
    class AccBudgetCircularForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetCircularRow {
        Id?: number;
        FinancialYearId?: number;
        FundControlId?: number;
        IsActive?: boolean;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBudgetCircularRow {
        const idProperty = "Id";
        const nameProperty = "FinancialYearYearName";
        const localTextPrefix = "Transaction.AccBudgetCircular";
        const lookupKey = "Transaction.AccBudgetCircular";
        function getLookup(): Q.Lookup<AccBudgetCircularRow>;
        const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            FundControlId = "FundControlId",
            IsActive = "IsActive",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBudgetCircularService {
        const baseUrl = "Transaction/AccBudgetCircular";
        function Create(request: Serenity.SaveRequest<AccBudgetCircularRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetCircularRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetCircularRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetCircularRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBudgetCircular/Create",
            Update = "Transaction/AccBudgetCircular/Update",
            Delete = "Transaction/AccBudgetCircular/Delete",
            Retrieve = "Transaction/AccBudgetCircular/Retrieve",
            List = "Transaction/AccBudgetCircular/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccBudgetCreationForm {
        BudgetForDepartmentId: Serenity.IntegerEditor;
        BudgetGroupId: Serenity.IntegerEditor;
        ParentId: Serenity.IntegerEditor;
        BudgetHeadId: Serenity.IntegerEditor;
        IsCoa: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        BudgetHeadName: Serenity.StringEditor;
        ProposedBudgetAmount: Serenity.DecimalEditor;
        RevisedEstimateAmount: Serenity.DecimalEditor;
    }
    class AccBudgetCreationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBudgetCreationService {
        const baseUrl = "Transaction/AccBudgetCreation";
        function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetFinancialYearName(request: Transaction.Repositories.FinancialYearNamesListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.FinancialYearNames>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetBudgetApproverList(request: Transaction.Repositories.BudgetApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.BudgetApproverList>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBudgetCreation/Create",
            Update = "Transaction/AccBudgetCreation/Update",
            Delete = "Transaction/AccBudgetCreation/Delete",
            Retrieve = "Transaction/AccBudgetCreation/Retrieve",
            List = "Transaction/AccBudgetCreation/List",
            GetFinancialYearName = "Transaction/AccBudgetCreation/GetFinancialYearName",
            GetBudgetApproverList = "Transaction/AccBudgetCreation/GetBudgetApproverList",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccBudgetDetailsForm {
        BudgetId: Serenity.IntegerEditor;
        BudgetGroupId: Serenity.IntegerEditor;
        BudgetHeadId: Serenity.LookupEditor;
        ParentId: Serenity.IntegerEditor;
        IsCoa: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        IsCostCenter: Serenity.BooleanEditor;
        BudgetAmount: Serenity.DecimalEditor;
        BudgetCode: Serenity.StringEditor;
        BgSortOrder: Serenity.IntegerEditor;
    }
    class AccBudgetDetailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetDetailsRow {
        Id?: number;
        BudgetId?: number;
        BudgetGroupId?: number;
        BudgetHeadId?: number;
        ParentId?: number;
        IsCoa?: boolean;
        IsBudgetHead?: boolean;
        IsCostCenter?: boolean;
        BudgetAmount?: number;
        BudgetCode?: string;
        BgSortOrder?: number;
        BudgetHeadName?: string;
        ZoneInfoId?: number;
        FinancialYearId?: number;
        EntityId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBudgetDetailsRow {
        const idProperty = "Id";
        const nameProperty = "BudgetHeadName";
        const localTextPrefix = "Transaction.AccBudgetDetails";
        const lookupKey = "Transaction.AccBudgetDetails";
        function getLookup(): Q.Lookup<AccBudgetDetailsRow>;
        const enum Fields {
            Id = "Id",
            BudgetId = "BudgetId",
            BudgetGroupId = "BudgetGroupId",
            BudgetHeadId = "BudgetHeadId",
            ParentId = "ParentId",
            IsCoa = "IsCoa",
            IsBudgetHead = "IsBudgetHead",
            IsCostCenter = "IsCostCenter",
            BudgetAmount = "BudgetAmount",
            BudgetCode = "BudgetCode",
            BgSortOrder = "BgSortOrder",
            BudgetHeadName = "BudgetHeadName",
            ZoneInfoId = "ZoneInfoId",
            FinancialYearId = "FinancialYearId",
            EntityId = "EntityId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBudgetDetailsService {
        const baseUrl = "Transaction/AccBudgetDetails";
        function Create(request: Serenity.SaveRequest<AccBudgetDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBudgetDetails/Create",
            Update = "Transaction/AccBudgetDetails/Update",
            Delete = "Transaction/AccBudgetDetails/Delete",
            Retrieve = "Transaction/AccBudgetDetails/Retrieve",
            List = "Transaction/AccBudgetDetails/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccBudgetForDepartmentDetailForm {
        BudgetForDepartmentId: Serenity.IntegerEditor;
        BudgetGroupId: Serenity.IntegerEditor;
        ParentId: Serenity.IntegerEditor;
        BudgetHeadId: Serenity.IntegerEditor;
        IsCoa: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
    }
    class AccBudgetForDepartmentDetailForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetForDepartmentDetailRow {
        BGSortOrder?: number;
        BudgetCode?: string;
        _collapsed?: string;
        _indent?: string;
        Id?: number;
        BudgetForDepartmentId?: number;
        BudgetGroupId?: number;
        ParentId?: number;
        BudgetHeadId?: number;
        IsCoa?: boolean;
        IsBudgetHead?: boolean;
        IsCostCenter?: boolean;
        BudgetForDepartmentBudgetCircularId?: number;
        BudgetForDepartmentZoneId?: number;
        BudgetForDepartmentDepartmentId?: number;
        BudgetForDepartmentForwardToEmployeeId?: number;
        BudgetForDepartmentApprovalStatusId?: number;
        ProposedBudgetFinancialYearId?: number;
        BudgetGroupParentId?: number;
        BudgetGroupGroupName?: string;
        BudgetGroupSortingOrder?: number;
        BudgetGroupIsActive?: boolean;
        BudgetHeadName?: string;
        ProposedBudgetAmount?: number;
        RevisedEstimateAmount?: number;
        ActualFirstSixMonths?: number;
        BudgetApproved?: number;
        ActualDuring?: number;
        CircularFundControlId?: number;
        CircularFinancialYearId?: number;
        CircularIsActive?: boolean;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBudgetForDepartmentDetailRow {
        const idProperty = "Id";
        const nameProperty = "BudgetHeadName";
        const localTextPrefix = "Transaction.AccBudgetForDepartmentDetail";
        const lookupKey = "Transaction.AccBudgetForDepartmentDetail";
        function getLookup(): Q.Lookup<AccBudgetForDepartmentDetailRow>;
        const enum Fields {
            BGSortOrder = "BGSortOrder",
            BudgetCode = "BudgetCode",
            _collapsed = "_collapsed",
            _indent = "_indent",
            Id = "Id",
            BudgetForDepartmentId = "BudgetForDepartmentId",
            BudgetGroupId = "BudgetGroupId",
            ParentId = "ParentId",
            BudgetHeadId = "BudgetHeadId",
            IsCoa = "IsCoa",
            IsBudgetHead = "IsBudgetHead",
            IsCostCenter = "IsCostCenter",
            BudgetForDepartmentBudgetCircularId = "BudgetForDepartmentBudgetCircularId",
            BudgetForDepartmentZoneId = "BudgetForDepartmentZoneId",
            BudgetForDepartmentDepartmentId = "BudgetForDepartmentDepartmentId",
            BudgetForDepartmentForwardToEmployeeId = "BudgetForDepartmentForwardToEmployeeId",
            BudgetForDepartmentApprovalStatusId = "BudgetForDepartmentApprovalStatusId",
            ProposedBudgetFinancialYearId = "ProposedBudgetFinancialYearId",
            BudgetGroupParentId = "BudgetGroupParentId",
            BudgetGroupGroupName = "BudgetGroupGroupName",
            BudgetGroupSortingOrder = "BudgetGroupSortingOrder",
            BudgetGroupIsActive = "BudgetGroupIsActive",
            BudgetHeadName = "BudgetHeadName",
            ProposedBudgetAmount = "ProposedBudgetAmount",
            RevisedEstimateAmount = "RevisedEstimateAmount",
            ActualFirstSixMonths = "ActualFirstSixMonths",
            BudgetApproved = "BudgetApproved",
            ActualDuring = "ActualDuring",
            CircularFundControlId = "CircularFundControlId",
            CircularFinancialYearId = "CircularFinancialYearId",
            CircularIsActive = "CircularIsActive",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBudgetForDepartmentDetailService {
        const baseUrl = "Transaction/AccBudgetForDepartmentDetail";
        function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBudgetForDepartmentDetail/Create",
            Update = "Transaction/AccBudgetForDepartmentDetail/Update",
            Delete = "Transaction/AccBudgetForDepartmentDetail/Delete",
            Retrieve = "Transaction/AccBudgetForDepartmentDetail/Retrieve",
            List = "Transaction/AccBudgetForDepartmentDetail/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetForDepartmentForm {
        BudgetCircularId: Serenity.LookupEditor;
        ZoneId: Serenity.IntegerEditor;
        BudgetCircularFinancialYearId: Serenity.LookupEditor;
        DepartmentId: Serenity.LookupEditor;
        AccBudgetForDepartmentDetailList: AccBudgetForDepartmentDetailEditor;
    }
    class AccBudgetForDepartmentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetForDepartmentRow {
        Id?: number;
        BudgetCircularId?: number;
        ZoneId?: number;
        EntityId?: number;
        DepartmentId?: number;
        ForwardToEmployeeId?: number;
        ApprovalStatusId?: ApprovalStatus;
        BudgetCircularFinancialYearId?: number;
        BudgetCircularFundControlId?: number;
        BudgetCircularIsActive?: boolean;
        DepartmentName?: string;
        FinancialYearName?: string;
        ZoneName?: string;
        AccBudgetForDepartmentDetailList?: AccBudgetForDepartmentDetailRow[];
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBudgetForDepartmentRow {
        const idProperty = "Id";
        const localTextPrefix = "Transaction.AccBudgetForDepartment";
        const lookupKey = "Transaction.AccBudgetForDepartment";
        function getLookup(): Q.Lookup<AccBudgetForDepartmentRow>;
        const enum Fields {
            Id = "Id",
            BudgetCircularId = "BudgetCircularId",
            ZoneId = "ZoneId",
            EntityId = "EntityId",
            DepartmentId = "DepartmentId",
            ForwardToEmployeeId = "ForwardToEmployeeId",
            ApprovalStatusId = "ApprovalStatusId",
            BudgetCircularFinancialYearId = "BudgetCircularFinancialYearId",
            BudgetCircularFundControlId = "BudgetCircularFundControlId",
            BudgetCircularIsActive = "BudgetCircularIsActive",
            DepartmentName = "DepartmentName",
            FinancialYearName = "FinancialYearName",
            ZoneName = "ZoneName",
            AccBudgetForDepartmentDetailList = "AccBudgetForDepartmentDetailList",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBudgetForDepartmentService {
        const baseUrl = "Transaction/AccBudgetForDepartment";
        function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function BudgetHeadList(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBudgetForDepartment/Create",
            Update = "Transaction/AccBudgetForDepartment/Update",
            Delete = "Transaction/AccBudgetForDepartment/Delete",
            Retrieve = "Transaction/AccBudgetForDepartment/Retrieve",
            List = "Transaction/AccBudgetForDepartment/List",
            BudgetHeadList = "Transaction/AccBudgetForDepartment/BudgetHeadList",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetForm {
        FinancialYearId: Serenity.LookupEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        EntityId: Serenity.IntegerEditor;
        IsApproved: Serenity.BooleanEditor;
        BudgetDetails: AccBudgetDetailsEditor;
        Attachment: Serenity.MultipleImageUploadEditor;
    }
    class AccBudgetForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccBudgetRow {
        Id?: number;
        FinancialYearId?: number;
        ZoneInfoId?: number;
        EntityId?: number;
        IsApproved?: boolean;
        Attachment?: string;
        FinancialYearYearName?: string;
        ZoneInfoZoneName?: string;
        BudgetDetails?: AccBudgetDetailsRow[];
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccBudgetRow {
        const idProperty = "Id";
        const nameProperty = "FinancialYearYearName";
        const localTextPrefix = "Transaction.AccBudget";
        const lookupKey = "Transaction.AccBudget";
        function getLookup(): Q.Lookup<AccBudgetRow>;
        const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            ZoneInfoId = "ZoneInfoId",
            EntityId = "EntityId",
            IsApproved = "IsApproved",
            Attachment = "Attachment",
            FinancialYearYearName = "FinancialYearYearName",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            BudgetDetails = "BudgetDetails",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccBudgetService {
        const baseUrl = "Transaction/AccBudget";
        function Create(request: Serenity.SaveRequest<AccBudgetRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccBudget/Create",
            Update = "Transaction/AccBudget/Update",
            Delete = "Transaction/AccBudget/Delete",
            Retrieve = "Transaction/AccBudget/Retrieve",
            List = "Transaction/AccBudget/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccChequeBookForm {
        BankAccountInformationId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        BankName: Serenity.StringEditor;
        BranchName: Serenity.StringEditor;
        CheckBookName: Serenity.StringEditor;
        CBDate: Serenity.DateEditor;
        StartingNo: Serenity.StringEditor;
        Prefix: Serenity.StringEditor;
        PageNo: Serenity.IntegerEditor;
        EndingNo: Serenity.IntegerEditor;
        HasFinished: Serenity.BooleanEditor;
    }
    class AccChequeBookForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccChequeBookRow {
        Id?: number;
        CheckBookName?: string;
        EndingNo?: number;
        HasFinished?: boolean;
        StartingNo?: string;
        EntityId?: number;
        BankAccountInformationId?: number;
        PageNo?: number;
        Prefix?: string;
        ZoneInfoId?: number;
        CBDate?: string;
        EntityCode?: string;
        EntityFundControlName?: string;
        EntityRemarks?: string;
        BankAccountInformationAccountDescription?: string;
        BankAccountInformationAccountName?: string;
        BankAccountInformationAccountNumber?: string;
        BankAccountInformationCode?: string;
        BankAccountInformationCoaId?: number;
        BankAccountInformationBankId?: number;
        BankAccountInformationBankBranchId?: number;
        BankAccountInformationEntityId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccChequeBookRow {
        const idProperty = "Id";
        const nameProperty = "CheckBookName";
        const localTextPrefix = "Transaction.AccChequeBook";
        const lookupKey = "Transaction.AccChequeBook";
        function getLookup(): Q.Lookup<AccChequeBookRow>;
        const enum Fields {
            Id = "Id",
            CheckBookName = "CheckBookName",
            EndingNo = "EndingNo",
            HasFinished = "HasFinished",
            StartingNo = "StartingNo",
            EntityId = "EntityId",
            BankAccountInformationId = "BankAccountInformationId",
            PageNo = "PageNo",
            Prefix = "Prefix",
            ZoneInfoId = "ZoneInfoId",
            CBDate = "CBDate",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
            EntityRemarks = "EntityRemarks",
            BankAccountInformationAccountDescription = "BankAccountInformationAccountDescription",
            BankAccountInformationAccountName = "BankAccountInformationAccountName",
            BankAccountInformationAccountNumber = "BankAccountInformationAccountNumber",
            BankAccountInformationCode = "BankAccountInformationCode",
            BankAccountInformationCoaId = "BankAccountInformationCoaId",
            BankAccountInformationBankId = "BankAccountInformationBankId",
            BankAccountInformationBankBranchId = "BankAccountInformationBankBranchId",
            BankAccountInformationEntityId = "BankAccountInformationEntityId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccChequeBookService {
        const baseUrl = "Transaction/AccChequeBook";
        function Create(request: Serenity.SaveRequest<AccChequeBookRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccChequeBookRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChequeBookRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChequeBookRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccChequeBook/Create",
            Update = "Transaction/AccChequeBook/Update",
            Delete = "Transaction/AccChequeBook/Delete",
            Retrieve = "Transaction/AccChequeBook/Retrieve",
            List = "Transaction/AccChequeBook/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    namespace AccChequePreparationService {
        const baseUrl = "Transaction/AccChequePreparation";
        function Create(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccChequePreparation/Create",
            Update = "Transaction/AccChequePreparation/Update",
            Delete = "Transaction/AccChequePreparation/Delete",
            Retrieve = "Transaction/AccChequePreparation/Retrieve",
            List = "Transaction/AccChequePreparation/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccChequeReceiveRegisterForm {
        RecieveFrom: Serenity.StringEditor;
        ChequeReceiveDate: Serenity.DateEditor;
        AccountNo: Serenity.StringEditor;
        ReceiveType: RecChequeTypeMappingEditor;
        AccountName: Serenity.StringEditor;
        ChequeNo: Serenity.StringEditor;
        BankName: Serenity.StringEditor;
        ChequeType: ChequeTypeMappingEditor;
        BranchName: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        Amount: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
        IsCancelled: Serenity.BooleanEditor;
        IsUsed: Serenity.BooleanEditor;
    }
    class AccChequeReceiveRegisterForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccChequeReceiveRegisterRow {
        Id?: number;
        AccountName?: string;
        AccountNo?: string;
        Amount?: number;
        AmountInWords?: string;
        BankName?: string;
        BranchName?: string;
        ChequeDate?: string;
        ChequeNo?: string;
        ChequeReceiveDate?: string;
        ChequeType?: string;
        IsCancelled?: boolean;
        IsUsed?: boolean;
        ReceiveType?: string;
        RecieveFrom?: string;
        EntityId?: number;
        Remarks?: string;
        ZoneInfoId?: number;
        EntityCode?: string;
        EntityFundControlName?: string;
        EntityRemarks?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccChequeReceiveRegisterRow {
        const idProperty = "Id";
        const nameProperty = "AccountName";
        const localTextPrefix = "Transaction.AccChequeReceiveRegister";
        const lookupKey = "Transaction.AccChequeReceiveRegister";
        function getLookup(): Q.Lookup<AccChequeReceiveRegisterRow>;
        const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            AccountNo = "AccountNo",
            Amount = "Amount",
            AmountInWords = "AmountInWords",
            BankName = "BankName",
            BranchName = "BranchName",
            ChequeDate = "ChequeDate",
            ChequeNo = "ChequeNo",
            ChequeReceiveDate = "ChequeReceiveDate",
            ChequeType = "ChequeType",
            IsCancelled = "IsCancelled",
            IsUsed = "IsUsed",
            ReceiveType = "ReceiveType",
            RecieveFrom = "RecieveFrom",
            EntityId = "EntityId",
            Remarks = "Remarks",
            ZoneInfoId = "ZoneInfoId",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
            EntityRemarks = "EntityRemarks",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccChequeReceiveRegisterService {
        const baseUrl = "Transaction/AccChequeReceiveRegister";
        function Create(request: Serenity.SaveRequest<AccChequeReceiveRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccChequeReceiveRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChequeReceiveRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChequeReceiveRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccChequeReceiveRegister/Create",
            Update = "Transaction/AccChequeReceiveRegister/Update",
            Delete = "Transaction/AccChequeReceiveRegister/Delete",
            Retrieve = "Transaction/AccChequeReceiveRegister/Retrieve",
            List = "Transaction/AccChequeReceiveRegister/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccChequeRegisterForm {
        ChequeIssueDate: Serenity.DateEditor;
        PayTo: _Ext.AutoCompleteEditor;
        BankAccountInformationId: Serenity.LookupEditor;
        ChequeBookId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        ChequeNo: ChequeBookEditor;
        BankName: Serenity.StringEditor;
        ChequeType: ChequeTypeMappingEditor;
        BranchName: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        Amount: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
        IsBankAdvice: Serenity.BooleanEditor;
        BankAdviceDate: Serenity.DateEditor;
        IsFinished: Serenity.BooleanEditor;
        ChequeNumhdn: Serenity.DecimalEditor;
        ChequeNoTemp: Serenity.StringEditor;
        IsCancelled: Serenity.BooleanEditor;
        isAdjusted: Serenity.BooleanEditor;
    }
    class AccChequeRegisterForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccChequeRegisterRow {
        Id?: number;
        ChequeDate?: string;
        ChequeIssueDate?: string;
        BankAdviceDate?: string;
        ChequeNo?: string;
        ChequeType?: string;
        Amount?: number;
        PayTo?: string;
        ChequeNumhdn?: number;
        ChequeNoTemp?: string;
        AmountInWords?: string;
        IsCancelled?: boolean;
        IsPayment?: boolean;
        IsUsed?: boolean;
        isAdjusted?: boolean;
        PayeeBankName?: string;
        Remarks?: string;
        VoucherNo?: string;
        BankAccountInformationId?: number;
        VoucherInformationId?: number;
        EntityId?: number;
        ChequeBookId?: number;
        IsBankAdvice?: boolean;
        IsFinished?: boolean;
        ZoneInfoId?: number;
        BankAccountInformationAccountNumber?: string;
        BankAccountInformationCoaId?: number;
        VoucherInformationVoucherDate?: string;
        VoucherInformationVoucherNo?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccChequeRegisterRow {
        const idProperty = "Id";
        const nameProperty = "ChequeNo";
        const localTextPrefix = "Transaction.AccChequeRegister";
        const lookupKey = "Transaction.AccChequeRegister";
        function getLookup(): Q.Lookup<AccChequeRegisterRow>;
        const enum Fields {
            Id = "Id",
            ChequeDate = "ChequeDate",
            ChequeIssueDate = "ChequeIssueDate",
            BankAdviceDate = "BankAdviceDate",
            ChequeNo = "ChequeNo",
            ChequeType = "ChequeType",
            Amount = "Amount",
            PayTo = "PayTo",
            ChequeNumhdn = "ChequeNumhdn",
            ChequeNoTemp = "ChequeNoTemp",
            AmountInWords = "AmountInWords",
            IsCancelled = "IsCancelled",
            IsPayment = "IsPayment",
            IsUsed = "IsUsed",
            isAdjusted = "isAdjusted",
            PayeeBankName = "PayeeBankName",
            Remarks = "Remarks",
            VoucherNo = "VoucherNo",
            BankAccountInformationId = "BankAccountInformationId",
            VoucherInformationId = "VoucherInformationId",
            EntityId = "EntityId",
            ChequeBookId = "ChequeBookId",
            IsBankAdvice = "IsBankAdvice",
            IsFinished = "IsFinished",
            ZoneInfoId = "ZoneInfoId",
            BankAccountInformationAccountNumber = "BankAccountInformationAccountNumber",
            BankAccountInformationCoaId = "BankAccountInformationCoaId",
            VoucherInformationVoucherDate = "VoucherInformationVoucherDate",
            VoucherInformationVoucherNo = "VoucherInformationVoucherNo",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccChequeRegisterService {
        const baseUrl = "Transaction/AccChequeRegister";
        function Create(request: Serenity.SaveRequest<AccChequeRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccChequeRegisterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccChequeRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccChequeRegisterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccChequeRegister/Create",
            Update = "Transaction/AccChequeRegister/Update",
            Delete = "Transaction/AccChequeRegister/Delete",
            Retrieve = "Transaction/AccChequeRegister/Retrieve",
            List = "Transaction/AccChequeRegister/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccCostCentreOrInstituteInformationForm {
        IsInstitute: Serenity.BooleanEditor;
        CostCenterTypeId: Serenity.LookupEditor;
        EmpId: Serenity.LookupEditor;
        UserCode: Serenity.StringEditor;
        AccountCodeClient: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        CodeCount: Serenity.IntegerEditor;
        Name: Serenity.StringEditor;
        NameForBankAdviceLetter: Serenity.StringEditor;
        ParentId: Serenity.LookupEditor;
        Remarks: Serenity.TextAreaEditor;
        IsActive: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        BudgetCode: Serenity.StringEditor;
        BudgetGroupId: Serenity.LookupEditor;
        FromCostCenter: Serenity.LookupEditor;
        ToCostCenter: Serenity.LookupEditor;
        ZoneName: Serenity.StringEditor;
        IsFixedAssetHead: Serenity.BooleanEditor;
        FixedAssetDevWorkTypeSelector: Serenity.RadioButtonEditor;
        DepreciationRate: Serenity.DecimalEditor;
    }
    class AccCostCentreOrInstituteInformationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccCostCentreOrInstituteInformationRow {
        Id?: number;
        AccountCodeClient?: string;
        Code?: string;
        CodeCount?: number;
        UserCode?: string;
        IsInstitute?: boolean;
        NameForBankAdviceLetter?: string;
        Name?: string;
        PaAmmount?: number;
        Remarks?: string;
        ParentId?: number;
        CostCenterTypeId?: number;
        EmpId?: number;
        IsActive?: boolean;
        TotalVoucherDtlAlo?: number;
        ZoneInfoId?: number;
        EntityId?: number;
        IsBudgetHead?: number;
        BudgetGroupId?: number;
        BudgetCode?: string;
        LookupText?: string;
        FromCostCenter?: number;
        ToCostCenter?: number;
        IsFixedAssetHead?: boolean;
        IsFixedAssetDevWork?: boolean;
        IsFixedAssetNonDevWork?: boolean;
        DepreciationRate?: number;
        FixedAssetDevWorkTypeSelector?: number;
        ParentCode?: string;
        ParentIsInstitute?: boolean;
        ParentName?: string;
        ParentPaAmmount?: number;
        ParentRemarks?: string;
        ParentParentId?: number;
        ParentEntityId?: number;
        ParentCostCenterTypeId?: number;
        EntityCode?: string;
        EntityFundControlName?: string;
        EntityRemarks?: string;
        CostCenterType?: string;
        CostCenterTypeSortOrder?: number;
        ZoneName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccCostCentreOrInstituteInformationRow {
        const idProperty = "Id";
        const nameProperty = "LookupText";
        const localTextPrefix = "Transaction.AccCostCentreOrInstituteInformation";
        const lookupKey = "Transaction.AccCostCentreOrInstituteInformation";
        function getLookup(): Q.Lookup<AccCostCentreOrInstituteInformationRow>;
        const enum Fields {
            Id = "Id",
            AccountCodeClient = "AccountCodeClient",
            Code = "Code",
            CodeCount = "CodeCount",
            UserCode = "UserCode",
            IsInstitute = "IsInstitute",
            NameForBankAdviceLetter = "NameForBankAdviceLetter",
            Name = "Name",
            PaAmmount = "PaAmmount",
            Remarks = "Remarks",
            ParentId = "ParentId",
            CostCenterTypeId = "CostCenterTypeId",
            EmpId = "EmpId",
            IsActive = "IsActive",
            TotalVoucherDtlAlo = "TotalVoucherDtlAlo",
            ZoneInfoId = "ZoneInfoId",
            EntityId = "EntityId",
            IsBudgetHead = "IsBudgetHead",
            BudgetGroupId = "BudgetGroupId",
            BudgetCode = "BudgetCode",
            LookupText = "LookupText",
            FromCostCenter = "FromCostCenter",
            ToCostCenter = "ToCostCenter",
            IsFixedAssetHead = "IsFixedAssetHead",
            IsFixedAssetDevWork = "IsFixedAssetDevWork",
            IsFixedAssetNonDevWork = "IsFixedAssetNonDevWork",
            DepreciationRate = "DepreciationRate",
            FixedAssetDevWorkTypeSelector = "FixedAssetDevWorkTypeSelector",
            ParentCode = "ParentCode",
            ParentIsInstitute = "ParentIsInstitute",
            ParentName = "ParentName",
            ParentPaAmmount = "ParentPaAmmount",
            ParentRemarks = "ParentRemarks",
            ParentParentId = "ParentParentId",
            ParentEntityId = "ParentEntityId",
            ParentCostCenterTypeId = "ParentCostCenterTypeId",
            EntityCode = "EntityCode",
            EntityFundControlName = "EntityFundControlName",
            EntityRemarks = "EntityRemarks",
            CostCenterType = "CostCenterType",
            CostCenterTypeSortOrder = "CostCenterTypeSortOrder",
            ZoneName = "ZoneName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccCostCentreOrInstituteInformationService {
        const baseUrl = "Transaction/AccCostCentreOrInstituteInformation";
        function Create(request: Serenity.SaveRequest<AccCostCentreOrInstituteInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccCostCentreOrInstituteInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccCostCentreOrInstituteInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccCostCentreOrInstituteInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccCostCentreOrInstituteInformation/Create",
            Update = "Transaction/AccCostCentreOrInstituteInformation/Update",
            Delete = "Transaction/AccCostCentreOrInstituteInformation/Delete",
            Retrieve = "Transaction/AccCostCentreOrInstituteInformation/Retrieve",
            List = "Transaction/AccCostCentreOrInstituteInformation/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    namespace AccCreditVoucherFromMoneyReceiptService {
        const baseUrl = "Transaction/AccCreditVoucherFromMoneyReceipt";
        function Create(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function CreateCreditVoucher(request: CreditVoucherParametersRequest, onSuccess?: (response: StringMessageResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function BulkAction(request: BulkActionRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccCreditVoucherFromMoneyReceipt/Create",
            Update = "Transaction/AccCreditVoucherFromMoneyReceipt/Update",
            Delete = "Transaction/AccCreditVoucherFromMoneyReceipt/Delete",
            Retrieve = "Transaction/AccCreditVoucherFromMoneyReceipt/Retrieve",
            List = "Transaction/AccCreditVoucherFromMoneyReceipt/List",
            CreateCreditVoucher = "Transaction/AccCreditVoucherFromMoneyReceipt/CreateCreditVoucher",
            BulkAction = "Transaction/AccCreditVoucherFromMoneyReceipt/BulkAction",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccCreditVoucherParametersForm {
        CreditVoucherDate: Serenity.DateEditor;
        ReceiveFrom: _Ext.AutoCompleteEditor;
        CreditVoucherNarration: Serenity.TextAreaEditor;
    }
    class AccCreditVoucherParametersForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccEmpAdvanceForm {
        EmpId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        CoAId: Serenity.LookupEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        CoAId2: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        RemainAmount: Serenity.DecimalEditor;
        Narration: Serenity.TextAreaEditor;
    }
    class AccEmpAdvanceForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccEmpAdvanceRow {
        Id?: number;
        EmpId?: number;
        TransactionMode?: string;
        CoAId?: number;
        ChequeRegisterId?: number;
        Amount?: number;
        RemainAmount?: number;
        Status?: number;
        ZoneId?: number;
        Narration?: string;
        CoAId2?: number;
        EmpEmpId?: string;
        EmpEmployeeInitial?: string;
        EmpTitleId?: number;
        EmpFirstName?: string;
        EmpMiddleName?: string;
        EmpLastName?: string;
        EmpFullName?: string;
        EmpDesignationId?: number;
        EmpStatusDesignationId?: number;
        EmpDisciplineId?: number;
        EmpDivisionId?: number;
        EmpSectionId?: number;
        EmpSubSectionId?: number;
        EmpJobLocationId?: number;
        EmpResourceLevelId?: number;
        EmpStaffCategoryId?: number;
        EmpEmploymentTypeId?: number;
        EmpBankId?: number;
        EmpBankBranchId?: number;
        EmpBankAccountNo?: string;
        EmpEmploymentStatusId?: number;
        EmpZoneInfoId?: number;
        CoAAccountName?: string;
        CoACoaMapping?: string;
        CoAIsBudgetHead?: number;
        CoAIsControlhead?: number;
        CoAIsCostCenterAllocate?: number;
        CoAOpeningBalance?: number;
        CoAFundControlId?: number;
        CoAParentAccountId?: number;
        ChequeRegisterAmount?: number;
        ChequeRegisterAmountInWords?: string;
        ChequeRegisterChequeDate?: string;
        ChequeRegisterChequeIssueDate?: string;
        ChequeRegisterChequeNo?: string;
        ChequeRegisterChequeNumhdn?: number;
        ChequeRegisterChequeType?: string;
        ChequeRegisterIsCancelled?: boolean;
        ChequeRegisterIsPayment?: boolean;
        ChequeRegisterIsUsed?: boolean;
        ChequeRegisterPayTo?: string;
        ChequeRegisterPayeeBankName?: string;
        ChequeRegisterRemarks?: string;
        ChequeRegisterVoucherNo?: string;
        ChequeRegisterBankAccountInformationId?: number;
        ChequeRegisterVoucherInformationId?: number;
        ChequeRegisterEntityId?: number;
        ChequeRegisterChequeBookId?: number;
        ChequeRegisterIsBankAdvice?: boolean;
        ChequeRegisterZoneInfoId?: number;
        CoA2AccountCode?: string;
        CoA2AccountName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccEmpAdvanceRow {
        const idProperty = "Id";
        const nameProperty = "TransactionMode";
        const localTextPrefix = "Transaction.AccEmpAdvance";
        const lookupKey = "Transaction.AccEmpAdvanceRow";
        function getLookup(): Q.Lookup<AccEmpAdvanceRow>;
        const enum Fields {
            Id = "Id",
            EmpId = "EmpId",
            TransactionMode = "TransactionMode",
            CoAId = "CoAId",
            ChequeRegisterId = "ChequeRegisterId",
            Amount = "Amount",
            RemainAmount = "RemainAmount",
            Status = "Status",
            ZoneId = "ZoneId",
            Narration = "Narration",
            CoAId2 = "CoAId2",
            EmpEmpId = "EmpEmpId",
            EmpEmployeeInitial = "EmpEmployeeInitial",
            EmpTitleId = "EmpTitleId",
            EmpFirstName = "EmpFirstName",
            EmpMiddleName = "EmpMiddleName",
            EmpLastName = "EmpLastName",
            EmpFullName = "EmpFullName",
            EmpDesignationId = "EmpDesignationId",
            EmpStatusDesignationId = "EmpStatusDesignationId",
            EmpDisciplineId = "EmpDisciplineId",
            EmpDivisionId = "EmpDivisionId",
            EmpSectionId = "EmpSectionId",
            EmpSubSectionId = "EmpSubSectionId",
            EmpJobLocationId = "EmpJobLocationId",
            EmpResourceLevelId = "EmpResourceLevelId",
            EmpStaffCategoryId = "EmpStaffCategoryId",
            EmpEmploymentTypeId = "EmpEmploymentTypeId",
            EmpBankId = "EmpBankId",
            EmpBankBranchId = "EmpBankBranchId",
            EmpBankAccountNo = "EmpBankAccountNo",
            EmpEmploymentStatusId = "EmpEmploymentStatusId",
            EmpZoneInfoId = "EmpZoneInfoId",
            CoAAccountName = "CoAAccountName",
            CoACoaMapping = "CoACoaMapping",
            CoAIsBudgetHead = "CoAIsBudgetHead",
            CoAIsControlhead = "CoAIsControlhead",
            CoAIsCostCenterAllocate = "CoAIsCostCenterAllocate",
            CoAOpeningBalance = "CoAOpeningBalance",
            CoAFundControlId = "CoAFundControlId",
            CoAParentAccountId = "CoAParentAccountId",
            ChequeRegisterAmount = "ChequeRegisterAmount",
            ChequeRegisterAmountInWords = "ChequeRegisterAmountInWords",
            ChequeRegisterChequeDate = "ChequeRegisterChequeDate",
            ChequeRegisterChequeIssueDate = "ChequeRegisterChequeIssueDate",
            ChequeRegisterChequeNo = "ChequeRegisterChequeNo",
            ChequeRegisterChequeNumhdn = "ChequeRegisterChequeNumhdn",
            ChequeRegisterChequeType = "ChequeRegisterChequeType",
            ChequeRegisterIsCancelled = "ChequeRegisterIsCancelled",
            ChequeRegisterIsPayment = "ChequeRegisterIsPayment",
            ChequeRegisterIsUsed = "ChequeRegisterIsUsed",
            ChequeRegisterPayTo = "ChequeRegisterPayTo",
            ChequeRegisterPayeeBankName = "ChequeRegisterPayeeBankName",
            ChequeRegisterRemarks = "ChequeRegisterRemarks",
            ChequeRegisterVoucherNo = "ChequeRegisterVoucherNo",
            ChequeRegisterBankAccountInformationId = "ChequeRegisterBankAccountInformationId",
            ChequeRegisterVoucherInformationId = "ChequeRegisterVoucherInformationId",
            ChequeRegisterEntityId = "ChequeRegisterEntityId",
            ChequeRegisterChequeBookId = "ChequeRegisterChequeBookId",
            ChequeRegisterIsBankAdvice = "ChequeRegisterIsBankAdvice",
            ChequeRegisterZoneInfoId = "ChequeRegisterZoneInfoId",
            CoA2AccountCode = "CoA2AccountCode",
            CoA2AccountName = "CoA2AccountName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccEmpAdvanceService {
        const baseUrl = "Transaction/AccEmpAdvance";
        function Create(request: Serenity.SaveRequest<AccEmpAdvanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccEmpAdvanceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccEmpAdvanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccEmpAdvanceRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccEmpAdvance/Create",
            Update = "Transaction/AccEmpAdvance/Update",
            Delete = "Transaction/AccEmpAdvance/Delete",
            Retrieve = "Transaction/AccEmpAdvance/Retrieve",
            List = "Transaction/AccEmpAdvance/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccFixedAssetDepreciationForm {
        FinancialYearId: Serenity.LookupEditor;
        ProcessType: Serenity.StringEditor;
    }
    class AccFixedAssetDepreciationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccFixedAssetDepreciationRow {
        Id?: number;
        FinancialYearId?: number;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
        ProcessType?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccFixedAssetDepreciationRow {
        const idProperty = "Id";
        const localTextPrefix = "Transaction.AccFixedAssetDepreciation";
        const lookupKey = "Transaction.AccFixedAssetDepreciation";
        function getLookup(): Q.Lookup<AccFixedAssetDepreciationRow>;
        const enum Fields {
            Id = "Id",
            FinancialYearId = "FinancialYearId",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
            ProcessType = "ProcessType",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccFixedAssetDepreciationService {
        const baseUrl = "Transaction/AccFixedAssetDepreciation";
        function Create(request: Serenity.SaveRequest<AccFixedAssetDepreciationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccFixedAssetDepreciationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFixedAssetDepreciationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFixedAssetDepreciationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccFixedAssetDepreciation/Create",
            Update = "Transaction/AccFixedAssetDepreciation/Update",
            Delete = "Transaction/AccFixedAssetDepreciation/Delete",
            Retrieve = "Transaction/AccFixedAssetDepreciation/Retrieve",
            List = "Transaction/AccFixedAssetDepreciation/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccFixedAssetRefurbishmentForm {
        CoaId: Serenity.LookupEditor;
        FinancialYearId: Serenity.LookupEditor;
        CostOpening: Serenity.DecimalEditor;
        CostAddition: Serenity.DecimalEditor;
        CostAdjustment: Serenity.DecimalEditor;
        CostClosing: Serenity.DecimalEditor;
        DepOpening: Serenity.DecimalEditor;
        DepCharge: Serenity.DecimalEditor;
        DepAdjustment: Serenity.DecimalEditor;
        DepClosing: Serenity.DecimalEditor;
        BookValue: Serenity.DecimalEditor;
    }
    class AccFixedAssetRefurbishmentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccFixedAssetRefurbishmentRow {
        Id?: number;
        CoaId?: number;
        FinancialYearId?: number;
        CostOpening?: number;
        CostAddition?: number;
        CostAdjustment?: number;
        CostClosing?: number;
        DepOpening?: number;
        DepCharge?: number;
        DepAdjustment?: number;
        DepClosing?: number;
        BookValue?: number;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        CoaIsBalanceSheet?: boolean;
        CoaBalanceSheetNotes?: number;
        CoaIsIncomeExpenditure?: boolean;
        CoaIncomeExpenditureNotes?: number;
        CoaBudgetCode?: string;
        CoaIsHideChildrenFromThisLevel?: boolean;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
    }
    namespace AccFixedAssetRefurbishmentRow {
        const idProperty = "Id";
        const localTextPrefix = "Transaction.AccFixedAssetRefurbishment";
        const lookupKey = "Transaction.AccFixedAssetRefurbishment";
        function getLookup(): Q.Lookup<AccFixedAssetRefurbishmentRow>;
        const enum Fields {
            Id = "Id",
            CoaId = "CoaId",
            FinancialYearId = "FinancialYearId",
            CostOpening = "CostOpening",
            CostAddition = "CostAddition",
            CostAdjustment = "CostAdjustment",
            CostClosing = "CostClosing",
            DepOpening = "DepOpening",
            DepCharge = "DepCharge",
            DepAdjustment = "DepAdjustment",
            DepClosing = "DepClosing",
            BookValue = "BookValue",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            CoaIsBalanceSheet = "CoaIsBalanceSheet",
            CoaBalanceSheetNotes = "CoaBalanceSheetNotes",
            CoaIsIncomeExpenditure = "CoaIsIncomeExpenditure",
            CoaIncomeExpenditureNotes = "CoaIncomeExpenditureNotes",
            CoaBudgetCode = "CoaBudgetCode",
            CoaIsHideChildrenFromThisLevel = "CoaIsHideChildrenFromThisLevel",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccFixedAssetRefurbishmentService {
        const baseUrl = "Transaction/AccFixedAssetRefurbishment";
        function Create(request: Serenity.SaveRequest<AccFixedAssetRefurbishmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccFixedAssetRefurbishmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFixedAssetRefurbishmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFixedAssetRefurbishmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccFixedAssetRefurbishment/Create",
            Update = "Transaction/AccFixedAssetRefurbishment/Update",
            Delete = "Transaction/AccFixedAssetRefurbishment/Delete",
            Retrieve = "Transaction/AccFixedAssetRefurbishment/Retrieve",
            List = "Transaction/AccFixedAssetRefurbishment/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccFixedAssetsManualInputForm {
        CostCenterId: Serenity.LookupEditor;
        FinancialYearId: Serenity.LookupEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        AdditionAmount: Serenity.DecimalEditor;
        AdjustmentAmount: Serenity.DecimalEditor;
        DepCharge: Serenity.DecimalEditor;
        DepAdjustment: Serenity.DecimalEditor;
        FundControlId: Serenity.IntegerEditor;
    }
    class AccFixedAssetsManualInputForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccFixedAssetsManualInputRow {
        Id?: number;
        CostCenterId?: number;
        FinancialYearId?: number;
        ZoneInfoId?: number;
        AdditionAmount?: number;
        AdjustmentAmount?: number;
        DepCharge?: number;
        DepAdjustment?: number;
        FundControlId?: number;
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterNameForBankAdviceLetter?: string;
        CostCenterPaAmmount?: number;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterEmpId?: number;
        CostCenterIsActive?: boolean;
        CostCenterEntityId?: number;
        CostCenterZoneInfoId?: number;
        CostCenterIsBudgetHead?: boolean;
        CostCenterBudgetGroupId?: number;
        CostCenterIsFixedAssetHead?: boolean;
        CostCenterIsFixedAssetDevWork?: boolean;
        CostCenterIsFixedAssetNonDevWork?: boolean;
        CostCenterDepreciationRate?: number;
        CostCenterBudgetCode?: string;
        FinancialYearIsActive?: boolean;
        FinancialYearIsClosed?: boolean;
        FinancialYearPeriodEndDate?: string;
        FinancialYearPeriodStartDate?: string;
        FinancialYearYearName?: string;
        FinancialYearFundControlInformationId?: number;
        ZoneInfoZoneName?: string;
        ZoneInfoZoneNameInBengali?: string;
        ZoneInfoZoneCode?: string;
        ZoneInfoSortOrder?: number;
        ZoneInfoOrganogramCategoryTypeId?: number;
        ZoneInfoZoneAddress?: string;
        ZoneInfoZoneAddressInBengali?: string;
        ZoneInfoPrefix?: string;
        ZoneInfoIsHeadOffice?: boolean;
        ZoneInfoZoneCodeForBillingSystem?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccFixedAssetsManualInputRow {
        const idProperty = "Id";
        const localTextPrefix = "Transaction.AccFixedAssetsManualInput";
        const lookupKey = "Transaction.AccFixedAssetsManualInput";
        function getLookup(): Q.Lookup<AccFixedAssetsManualInputRow>;
        const enum Fields {
            Id = "Id",
            CostCenterId = "CostCenterId",
            FinancialYearId = "FinancialYearId",
            ZoneInfoId = "ZoneInfoId",
            AdditionAmount = "AdditionAmount",
            AdjustmentAmount = "AdjustmentAmount",
            DepCharge = "DepCharge",
            DepAdjustment = "DepAdjustment",
            FundControlId = "FundControlId",
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterNameForBankAdviceLetter = "CostCenterNameForBankAdviceLetter",
            CostCenterPaAmmount = "CostCenterPaAmmount",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterEmpId = "CostCenterEmpId",
            CostCenterIsActive = "CostCenterIsActive",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterZoneInfoId = "CostCenterZoneInfoId",
            CostCenterIsBudgetHead = "CostCenterIsBudgetHead",
            CostCenterBudgetGroupId = "CostCenterBudgetGroupId",
            CostCenterIsFixedAssetHead = "CostCenterIsFixedAssetHead",
            CostCenterIsFixedAssetDevWork = "CostCenterIsFixedAssetDevWork",
            CostCenterIsFixedAssetNonDevWork = "CostCenterIsFixedAssetNonDevWork",
            CostCenterDepreciationRate = "CostCenterDepreciationRate",
            CostCenterBudgetCode = "CostCenterBudgetCode",
            FinancialYearIsActive = "FinancialYearIsActive",
            FinancialYearIsClosed = "FinancialYearIsClosed",
            FinancialYearPeriodEndDate = "FinancialYearPeriodEndDate",
            FinancialYearPeriodStartDate = "FinancialYearPeriodStartDate",
            FinancialYearYearName = "FinancialYearYearName",
            FinancialYearFundControlInformationId = "FinancialYearFundControlInformationId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            ZoneInfoZoneNameInBengali = "ZoneInfoZoneNameInBengali",
            ZoneInfoZoneCode = "ZoneInfoZoneCode",
            ZoneInfoSortOrder = "ZoneInfoSortOrder",
            ZoneInfoOrganogramCategoryTypeId = "ZoneInfoOrganogramCategoryTypeId",
            ZoneInfoZoneAddress = "ZoneInfoZoneAddress",
            ZoneInfoZoneAddressInBengali = "ZoneInfoZoneAddressInBengali",
            ZoneInfoPrefix = "ZoneInfoPrefix",
            ZoneInfoIsHeadOffice = "ZoneInfoIsHeadOffice",
            ZoneInfoZoneCodeForBillingSystem = "ZoneInfoZoneCodeForBillingSystem",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccFixedAssetsManualInputService {
        const baseUrl = "Transaction/AccFixedAssetsManualInput";
        function Create(request: Serenity.SaveRequest<AccFixedAssetsManualInputRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccFixedAssetsManualInputRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccFixedAssetsManualInputRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccFixedAssetsManualInputRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccFixedAssetsManualInput/Create",
            Update = "Transaction/AccFixedAssetsManualInput/Update",
            Delete = "Transaction/AccFixedAssetsManualInput/Delete",
            Retrieve = "Transaction/AccFixedAssetsManualInput/Retrieve",
            List = "Transaction/AccFixedAssetsManualInput/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccIbcsJsondataHistoryForm {
        JsonData: Serenity.TextAreaEditor;
    }
    class AccIbcsJsondataHistoryForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccIbcsJsondataHistoryRow {
        Id?: number;
        VoucherNo?: string;
        VoucherDate?: string;
        ZoneId?: number;
        FundControlId?: number;
        JsonData?: string;
        CreateDate?: string;
        IsSuccess?: boolean;
        ZoneInfoZoneName?: string;
        EntityName?: string;
    }
    namespace AccIbcsJsondataHistoryRow {
        const idProperty = "Id";
        const nameProperty = "VoucherNo";
        const localTextPrefix = "Transaction.AccIbcsJsondataHistory";
        const lookupKey = "Transaction.AccIbcsJsondataHistoryRow";
        function getLookup(): Q.Lookup<AccIbcsJsondataHistoryRow>;
        const enum Fields {
            Id = "Id",
            VoucherNo = "VoucherNo",
            VoucherDate = "VoucherDate",
            ZoneId = "ZoneId",
            FundControlId = "FundControlId",
            JsonData = "JsonData",
            CreateDate = "CreateDate",
            IsSuccess = "IsSuccess",
            ZoneInfoZoneName = "ZoneInfoZoneName",
            EntityName = "EntityName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccIbcsJsondataHistoryService {
        const baseUrl = "Transaction/AccIbcsJsondataHistory";
        function Create(request: Serenity.SaveRequest<AccIbcsJsondataHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccIbcsJsondataHistoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccIbcsJsondataHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccIbcsJsondataHistoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccIbcsJsondataHistory/Create",
            Update = "Transaction/AccIbcsJsondataHistory/Update",
            Delete = "Transaction/AccIbcsJsondataHistory/Delete",
            Retrieve = "Transaction/AccIbcsJsondataHistory/Retrieve",
            List = "Transaction/AccIbcsJsondataHistory/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccMoneyReceiptDatailsForm {
        MoneyReceiptId: Serenity.StringEditor;
        CoaId: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        Description: Serenity.StringEditor;
    }
    class AccMoneyReceiptDatailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccMoneyReceiptDatailsRow {
        Id?: number;
        MoneyReceiptId?: number;
        CoaId?: number;
        CostCenterId?: number;
        Amount?: number;
        MoneyReceiptSerialNo?: string;
        MoneyReceiptMonryReceiptDate?: string;
        MoneyReceiptAmount?: number;
        MoneyReceiptAmountInWord?: string;
        MoneyReceiptNarration?: string;
        MoneyReceiptChequeReceiveRegisterId?: number;
        MoneyReceiptAccHeadBankId?: number;
        MoneyReceiptIsCancelled?: boolean;
        MoneyReceiptIsUsed?: boolean;
        MoneyReceiptVoucherId?: number;
        MoneyReceiptEntityId?: number;
        MoneyReceiptZoneInfoId?: number;
        CoaParentAccountId?: number;
        CoaLevel?: number;
        CoaAccountGroup?: string;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaUserCode?: string;
        CoaAccountName?: string;
        CoaCoaMapping?: string;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaOpeningBalance?: number;
        CoaAccountNameBangla?: string;
        CoaIsBillRef?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaMultiCurrencyId?: number;
        CoaEffectCashFlow?: number;
        CoaNoaAccTypeId?: number;
        CoaFundControlId?: number;
        CoaSortOrder?: number;
        CoaShowSumInReceiptPaymentReport?: boolean;
        CoaIsBudgetHead?: boolean;
        CoaBudgetGroupId?: number;
        CoaIsBalanceSheet?: boolean;
        CoaBalanceSheetNotes?: number;
        CoaIsIncomeExpenditure?: boolean;
        CoaIncomeExpenditureNotes?: number;
        CoaBudgetCode?: string;
        CoaIsHideChildrenFromThisLevel?: boolean;
        CostCenterCode?: string;
        CostCenterCodeCount?: number;
        CostCenterUserCode?: string;
        CostCenterIsInstitute?: boolean;
        CostCenterName?: string;
        CostCenterNameForBankAdviceLetter?: string;
        CostCenterPaAmmount?: number;
        CostCenterRemarks?: string;
        CostCenterParentId?: number;
        CostCenterCostCenterTypeId?: number;
        CostCenterEmpId?: number;
        CostCenterIsActive?: boolean;
        CostCenterEntityId?: number;
        CostCenterZoneInfoId?: number;
        CostCenterIsBudgetHead?: boolean;
        CostCenterBudgetGroupId?: number;
        CostCenterIsFixedAssetHead?: boolean;
        CostCenterIsFixedAssetDevWork?: boolean;
        CostCenterIsFixedAssetNonDevWork?: boolean;
        CostCenterDepreciationRate?: number;
        CostCenterBudgetCode?: string;
        Description?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccMoneyReceiptDatailsRow {
        const idProperty = "Id";
        const localTextPrefix = "Transaction.AccMoneyReceiptDatails";
        const lookupKey = "Transaction.AccMoneyReceiptDatails";
        function getLookup(): Q.Lookup<AccMoneyReceiptDatailsRow>;
        const enum Fields {
            Id = "Id",
            MoneyReceiptId = "MoneyReceiptId",
            CoaId = "CoaId",
            CostCenterId = "CostCenterId",
            Amount = "Amount",
            MoneyReceiptSerialNo = "MoneyReceiptSerialNo",
            MoneyReceiptMonryReceiptDate = "MoneyReceiptMonryReceiptDate",
            MoneyReceiptAmount = "MoneyReceiptAmount",
            MoneyReceiptAmountInWord = "MoneyReceiptAmountInWord",
            MoneyReceiptNarration = "MoneyReceiptNarration",
            MoneyReceiptChequeReceiveRegisterId = "MoneyReceiptChequeReceiveRegisterId",
            MoneyReceiptAccHeadBankId = "MoneyReceiptAccHeadBankId",
            MoneyReceiptIsCancelled = "MoneyReceiptIsCancelled",
            MoneyReceiptIsUsed = "MoneyReceiptIsUsed",
            MoneyReceiptVoucherId = "MoneyReceiptVoucherId",
            MoneyReceiptEntityId = "MoneyReceiptEntityId",
            MoneyReceiptZoneInfoId = "MoneyReceiptZoneInfoId",
            CoaParentAccountId = "CoaParentAccountId",
            CoaLevel = "CoaLevel",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaUserCode = "CoaUserCode",
            CoaAccountName = "CoaAccountName",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaIsBillRef = "CoaIsBillRef",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaMultiCurrencyId = "CoaMultiCurrencyId",
            CoaEffectCashFlow = "CoaEffectCashFlow",
            CoaNoaAccTypeId = "CoaNoaAccTypeId",
            CoaFundControlId = "CoaFundControlId",
            CoaSortOrder = "CoaSortOrder",
            CoaShowSumInReceiptPaymentReport = "CoaShowSumInReceiptPaymentReport",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaBudgetGroupId = "CoaBudgetGroupId",
            CoaIsBalanceSheet = "CoaIsBalanceSheet",
            CoaBalanceSheetNotes = "CoaBalanceSheetNotes",
            CoaIsIncomeExpenditure = "CoaIsIncomeExpenditure",
            CoaIncomeExpenditureNotes = "CoaIncomeExpenditureNotes",
            CoaBudgetCode = "CoaBudgetCode",
            CoaIsHideChildrenFromThisLevel = "CoaIsHideChildrenFromThisLevel",
            CostCenterCode = "CostCenterCode",
            CostCenterCodeCount = "CostCenterCodeCount",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterIsInstitute = "CostCenterIsInstitute",
            CostCenterName = "CostCenterName",
            CostCenterNameForBankAdviceLetter = "CostCenterNameForBankAdviceLetter",
            CostCenterPaAmmount = "CostCenterPaAmmount",
            CostCenterRemarks = "CostCenterRemarks",
            CostCenterParentId = "CostCenterParentId",
            CostCenterCostCenterTypeId = "CostCenterCostCenterTypeId",
            CostCenterEmpId = "CostCenterEmpId",
            CostCenterIsActive = "CostCenterIsActive",
            CostCenterEntityId = "CostCenterEntityId",
            CostCenterZoneInfoId = "CostCenterZoneInfoId",
            CostCenterIsBudgetHead = "CostCenterIsBudgetHead",
            CostCenterBudgetGroupId = "CostCenterBudgetGroupId",
            CostCenterIsFixedAssetHead = "CostCenterIsFixedAssetHead",
            CostCenterIsFixedAssetDevWork = "CostCenterIsFixedAssetDevWork",
            CostCenterIsFixedAssetNonDevWork = "CostCenterIsFixedAssetNonDevWork",
            CostCenterDepreciationRate = "CostCenterDepreciationRate",
            CostCenterBudgetCode = "CostCenterBudgetCode",
            Description = "Description",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccMoneyReceiptDatailsService {
        const baseUrl = "Transaction/AccMoneyReceiptDatails";
        function Create(request: Serenity.SaveRequest<AccMoneyReceiptDatailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccMoneyReceiptDatailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccMoneyReceiptDatailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccMoneyReceiptDatailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccMoneyReceiptDatails/Create",
            Update = "Transaction/AccMoneyReceiptDatails/Update",
            Delete = "Transaction/AccMoneyReceiptDatails/Delete",
            Retrieve = "Transaction/AccMoneyReceiptDatails/Retrieve",
            List = "Transaction/AccMoneyReceiptDatails/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccMoneyReceiptForm {
        SerialNo: Serenity.StringEditor;
        MonryReceiptDate: Serenity.DateEditor;
        ReceiveFrom: _Ext.AutoCompleteEditor;
        AccMoneyReceiptDatailsList: AccMoneyReceiptDatailsEditor;
        Amount: Serenity.DecimalEditor;
        Dollar: Serenity.DecimalEditor;
        AmountInWord: Serenity.StringEditor;
        Narration: Serenity.TextAreaEditor;
        ChequeType: RecChequeTypeMappingEditor;
        ChequeDate: Serenity.DateEditor;
        ChequeNo: Serenity.StringEditor;
        AccHeadBankId: Serenity.LookupEditor;
        IsCancelled: Serenity.BooleanEditor;
        IsConfirmed: Serenity.BooleanEditor;
        IsUsed: Serenity.BooleanEditor;
        VoucherNo: Serenity.StringEditor;
        MoneyReceiptNo: Serenity.StringEditor;
    }
    class AccMoneyReceiptForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccMoneyReceiptRow {
        Id?: number;
        MonryReceiptDate?: string;
        Amount?: number;
        AmountInWord?: string;
        Narration?: string;
        ChequeReceiveRegisterId?: number;
        SerialNo?: string;
        ReceiveFrom?: string;
        AccHeadBankId?: number;
        AccHeadBankName?: string;
        IsCancelled?: boolean;
        IsUsed?: boolean;
        VoucherId?: number;
        VoucherNo?: string;
        EntityId?: number;
        ZoneInfoId?: number;
        MoneyReceiptNo?: string;
        Dollar?: number;
        IsConfirmed?: boolean;
        CreditVoucherDate?: string;
        CreditVoucherNarration?: string;
        AccMoneyReceiptDatailsList?: AccMoneyReceiptDatailsRow[];
        ChequeReceiveRegisterAccountName?: string;
        ChequeReceiveRegisterAccountNo?: string;
        ChequeReceiveRegisterAmount?: number;
        ChequeReceiveRegisterAmountInWords?: string;
        ChequeReceiveRegisterBankName?: string;
        ChequeReceiveRegisterBranchName?: string;
        ChequeDate?: string;
        ChequeNo?: string;
        ChequeReceiveRegisterChequeReceiveDate?: string;
        ChequeType?: string;
        ChequeReceiveRegisterIsCancelled?: boolean;
        ChequeReceiveRegisterIsUsed?: boolean;
        ChequeReceiveRegisterReceiveType?: string;
        ChequeReceiveRegisterRemarks?: string;
        ChequeReceiveRegisterRecieveFrom?: string;
        ChequeReceiveRegisterEntityId?: number;
        ChequeReceiveRegisterZoneInfoId?: number;
        VouchervoucherNo?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccMoneyReceiptRow {
        const idProperty = "Id";
        const nameProperty = "AmountInWord";
        const localTextPrefix = "Transaction.AccMoneyReceipt";
        const lookupKey = "Transaction.AccMoneyReceipt";
        function getLookup(): Q.Lookup<AccMoneyReceiptRow>;
        const enum Fields {
            Id = "Id",
            MonryReceiptDate = "MonryReceiptDate",
            Amount = "Amount",
            AmountInWord = "AmountInWord",
            Narration = "Narration",
            ChequeReceiveRegisterId = "ChequeReceiveRegisterId",
            SerialNo = "SerialNo",
            ReceiveFrom = "ReceiveFrom",
            AccHeadBankId = "AccHeadBankId",
            AccHeadBankName = "AccHeadBankName",
            IsCancelled = "IsCancelled",
            IsUsed = "IsUsed",
            VoucherId = "VoucherId",
            VoucherNo = "VoucherNo",
            EntityId = "EntityId",
            ZoneInfoId = "ZoneInfoId",
            MoneyReceiptNo = "MoneyReceiptNo",
            Dollar = "Dollar",
            IsConfirmed = "IsConfirmed",
            CreditVoucherDate = "CreditVoucherDate",
            CreditVoucherNarration = "CreditVoucherNarration",
            AccMoneyReceiptDatailsList = "AccMoneyReceiptDatailsList",
            ChequeReceiveRegisterAccountName = "ChequeReceiveRegisterAccountName",
            ChequeReceiveRegisterAccountNo = "ChequeReceiveRegisterAccountNo",
            ChequeReceiveRegisterAmount = "ChequeReceiveRegisterAmount",
            ChequeReceiveRegisterAmountInWords = "ChequeReceiveRegisterAmountInWords",
            ChequeReceiveRegisterBankName = "ChequeReceiveRegisterBankName",
            ChequeReceiveRegisterBranchName = "ChequeReceiveRegisterBranchName",
            ChequeDate = "ChequeDate",
            ChequeNo = "ChequeNo",
            ChequeReceiveRegisterChequeReceiveDate = "ChequeReceiveRegisterChequeReceiveDate",
            ChequeType = "ChequeType",
            ChequeReceiveRegisterIsCancelled = "ChequeReceiveRegisterIsCancelled",
            ChequeReceiveRegisterIsUsed = "ChequeReceiveRegisterIsUsed",
            ChequeReceiveRegisterReceiveType = "ChequeReceiveRegisterReceiveType",
            ChequeReceiveRegisterRemarks = "ChequeReceiveRegisterRemarks",
            ChequeReceiveRegisterRecieveFrom = "ChequeReceiveRegisterRecieveFrom",
            ChequeReceiveRegisterEntityId = "ChequeReceiveRegisterEntityId",
            ChequeReceiveRegisterZoneInfoId = "ChequeReceiveRegisterZoneInfoId",
            VouchervoucherNo = "VouchervoucherNo",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccMoneyReceiptService {
        const baseUrl = "Transaction/AccMoneyReceipt";
        function Create(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccMoneyReceiptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccMoneyReceiptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetNewMoneyReceiptNo(request: Transaction.Repositories.GetNewMoneyReceiptNoRequest, onSuccess?: (response: Transaction.Repositories.GetNewMoneyReceiptResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccMoneyReceipt/Create",
            Update = "Transaction/AccMoneyReceipt/Update",
            Delete = "Transaction/AccMoneyReceipt/Delete",
            Retrieve = "Transaction/AccMoneyReceipt/Retrieve",
            List = "Transaction/AccMoneyReceipt/List",
            GetNewMoneyReceiptNo = "Transaction/AccMoneyReceipt/GetNewMoneyReceiptNo",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccNoaForm {
        NoaNumber: Serenity.StringEditor;
        NoaDate: Serenity.DateEditor;
        CostCenterId: Serenity.LookupEditor;
        ContactValue: Serenity.DecimalEditor;
        NameofContract: Serenity.StringEditor;
        ContractDate: Serenity.DateEditor;
        BudgetProvision: Serenity.DecimalEditor;
        TenderNo: Serenity.StringEditor;
        AdministrativeApproved: Serenity.StringEditor;
        AdministrativeDate: Serenity.DateEditor;
        TechnicalApproved: Serenity.StringEditor;
        TechnicalDate: Serenity.DateEditor;
        FinancialApproved: Serenity.StringEditor;
        FinancialDate: Serenity.DateEditor;
        NameofContractor: Serenity.StringEditor;
        ContractorAddress: Serenity.StringEditor;
        SecurityMoney: Serenity.DecimalEditor;
        MBNo: Serenity.StringEditor;
        WorkStartOn: Serenity.DateEditor;
        CompilationDate: Serenity.DateEditor;
        ZoneInfoId: Serenity.IntegerEditor;
    }
    class AccNoaForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccNoaRow {
        Id?: number;
        NoaNumber?: string;
        NoaDate?: string;
        CostCenterId?: number;
        ContactValue?: number;
        NameofContract?: string;
        ContractDate?: string;
        AdministrativeDate?: string;
        TechnicalDate?: string;
        FinancialDate?: string;
        BudgetProvision?: number;
        AdministrativeApproved?: string;
        TechnicalApproved?: string;
        FinancialApproved?: string;
        TenderNo?: string;
        NameofContractor?: string;
        ContractorAddress?: string;
        SecurityMoney?: number;
        WorkStartOn?: string;
        CompilationDate?: string;
        MBNo?: string;
        ZoneInfoId?: number;
        ZoneInfoZoneName?: string;
    }
    namespace AccNoaRow {
        const idProperty = "Id";
        const nameProperty = "NoaNumber";
        const localTextPrefix = "Transaction.AccNoa";
        const lookupKey = "Transaction.AccNoa";
        function getLookup(): Q.Lookup<AccNoaRow>;
        const enum Fields {
            Id = "Id",
            NoaNumber = "NoaNumber",
            NoaDate = "NoaDate",
            CostCenterId = "CostCenterId",
            ContactValue = "ContactValue",
            NameofContract = "NameofContract",
            ContractDate = "ContractDate",
            AdministrativeDate = "AdministrativeDate",
            TechnicalDate = "TechnicalDate",
            FinancialDate = "FinancialDate",
            BudgetProvision = "BudgetProvision",
            AdministrativeApproved = "AdministrativeApproved",
            TechnicalApproved = "TechnicalApproved",
            FinancialApproved = "FinancialApproved",
            TenderNo = "TenderNo",
            NameofContractor = "NameofContractor",
            ContractorAddress = "ContractorAddress",
            SecurityMoney = "SecurityMoney",
            WorkStartOn = "WorkStartOn",
            CompilationDate = "CompilationDate",
            MBNo = "MBNo",
            ZoneInfoId = "ZoneInfoId",
            ZoneInfoZoneName = "ZoneInfoZoneName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccNoaService {
        const baseUrl = "Transaction/AccNoa";
        function Create(request: Serenity.SaveRequest<AccNoaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccNoaRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccNoaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccNoaRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccNoa/Create",
            Update = "Transaction/AccNoa/Update",
            Delete = "Transaction/AccNoa/Delete",
            Retrieve = "Transaction/AccNoa/Retrieve",
            List = "Transaction/AccNoa/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccPartyPaymentForm {
        PartyId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        CoAId: Serenity.LookupEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        CoAId2: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        RemainAmount: Serenity.DecimalEditor;
        Narration: Serenity.TextAreaEditor;
    }
    class AccPartyPaymentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccPartyPaymentRow {
        Id?: number;
        PartyId?: number;
        TransactionMode?: string;
        CoAId?: number;
        ChequeRegisterId?: number;
        Amount?: number;
        Status?: number;
        ZoneId?: number;
        RemainAmount?: number;
        Narration?: string;
        CoAId2?: number;
        PartyCode?: string;
        PartyCodeCount?: number;
        PartyUserCode?: string;
        PartyIsInstitute?: boolean;
        PartyName?: string;
        PartyPaAmmount?: number;
        PartyRemarks?: string;
        PartyParentId?: number;
        PartyEntityId?: number;
        PartyCostCenterTypeId?: number;
        CoAAccountCode?: string;
        CoAAccountCodeCount?: number;
        CoAAccountGroup?: string;
        CoAAccountName?: string;
        CoAAccountNameBangla?: string;
        CoACoaMapping?: string;
        CoAIsBillRef?: number;
        CoAIsBudgetHead?: number;
        CoAIsControlhead?: number;
        CoAIsCostCenterAllocate?: number;
        CoALevel?: number;
        CoAMailingAddress?: string;
        CoAMailingName?: string;
        CoAOpeningBalance?: number;
        CoARemarks?: string;
        CoATaxId?: string;
        CoAUgcCode?: string;
        CoAFundControlId?: number;
        CoAParentAccountId?: number;
        CoAMultiCurrencyId?: number;
        CoAEffectCashFlow?: number;
        CoAUserCode?: string;
        ChequeRegisterAmount?: number;
        ChequeRegisterAmountInWords?: string;
        ChequeRegisterChequeDate?: string;
        ChequeRegisterChequeIssueDate?: string;
        ChequeRegisterChequeNo?: string;
        ChequeRegisterChequeNumhdn?: number;
        ChequeRegisterChequeType?: string;
        ChequeRegisterIsCancelled?: boolean;
        ChequeRegisterIsPayment?: boolean;
        ChequeRegisterIsUsed?: boolean;
        ChequeRegisterPayTo?: string;
        ChequeRegisterPayeeBankName?: string;
        ChequeRegisterRemarks?: string;
        ChequeRegisterVoucherNo?: string;
        ChequeRegisterBankAccountInformationId?: number;
        ChequeRegisterVoucherInformationId?: number;
        ChequeRegisterEntityId?: number;
        ChequeRegisterChequeBookId?: number;
        ChequeRegisterIsBankAdvice?: boolean;
        ChequeRegisterZoneInfoId?: number;
        CoA2AccountCode?: string;
        CoA2AccountName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccPartyPaymentRow {
        const idProperty = "Id";
        const nameProperty = "TransactionMode";
        const localTextPrefix = "Transaction.AccPartyPayment";
        const lookupKey = "Transaction.AccPartyPayment";
        function getLookup(): Q.Lookup<AccPartyPaymentRow>;
        const enum Fields {
            Id = "Id",
            PartyId = "PartyId",
            TransactionMode = "TransactionMode",
            CoAId = "CoAId",
            ChequeRegisterId = "ChequeRegisterId",
            Amount = "Amount",
            Status = "Status",
            ZoneId = "ZoneId",
            RemainAmount = "RemainAmount",
            Narration = "Narration",
            CoAId2 = "CoAId2",
            PartyCode = "PartyCode",
            PartyCodeCount = "PartyCodeCount",
            PartyUserCode = "PartyUserCode",
            PartyIsInstitute = "PartyIsInstitute",
            PartyName = "PartyName",
            PartyPaAmmount = "PartyPaAmmount",
            PartyRemarks = "PartyRemarks",
            PartyParentId = "PartyParentId",
            PartyEntityId = "PartyEntityId",
            PartyCostCenterTypeId = "PartyCostCenterTypeId",
            CoAAccountCode = "CoAAccountCode",
            CoAAccountCodeCount = "CoAAccountCodeCount",
            CoAAccountGroup = "CoAAccountGroup",
            CoAAccountName = "CoAAccountName",
            CoAAccountNameBangla = "CoAAccountNameBangla",
            CoACoaMapping = "CoACoaMapping",
            CoAIsBillRef = "CoAIsBillRef",
            CoAIsBudgetHead = "CoAIsBudgetHead",
            CoAIsControlhead = "CoAIsControlhead",
            CoAIsCostCenterAllocate = "CoAIsCostCenterAllocate",
            CoALevel = "CoALevel",
            CoAMailingAddress = "CoAMailingAddress",
            CoAMailingName = "CoAMailingName",
            CoAOpeningBalance = "CoAOpeningBalance",
            CoARemarks = "CoARemarks",
            CoATaxId = "CoATaxId",
            CoAUgcCode = "CoAUgcCode",
            CoAFundControlId = "CoAFundControlId",
            CoAParentAccountId = "CoAParentAccountId",
            CoAMultiCurrencyId = "CoAMultiCurrencyId",
            CoAEffectCashFlow = "CoAEffectCashFlow",
            CoAUserCode = "CoAUserCode",
            ChequeRegisterAmount = "ChequeRegisterAmount",
            ChequeRegisterAmountInWords = "ChequeRegisterAmountInWords",
            ChequeRegisterChequeDate = "ChequeRegisterChequeDate",
            ChequeRegisterChequeIssueDate = "ChequeRegisterChequeIssueDate",
            ChequeRegisterChequeNo = "ChequeRegisterChequeNo",
            ChequeRegisterChequeNumhdn = "ChequeRegisterChequeNumhdn",
            ChequeRegisterChequeType = "ChequeRegisterChequeType",
            ChequeRegisterIsCancelled = "ChequeRegisterIsCancelled",
            ChequeRegisterIsPayment = "ChequeRegisterIsPayment",
            ChequeRegisterIsUsed = "ChequeRegisterIsUsed",
            ChequeRegisterPayTo = "ChequeRegisterPayTo",
            ChequeRegisterPayeeBankName = "ChequeRegisterPayeeBankName",
            ChequeRegisterRemarks = "ChequeRegisterRemarks",
            ChequeRegisterVoucherNo = "ChequeRegisterVoucherNo",
            ChequeRegisterBankAccountInformationId = "ChequeRegisterBankAccountInformationId",
            ChequeRegisterVoucherInformationId = "ChequeRegisterVoucherInformationId",
            ChequeRegisterEntityId = "ChequeRegisterEntityId",
            ChequeRegisterChequeBookId = "ChequeRegisterChequeBookId",
            ChequeRegisterIsBankAdvice = "ChequeRegisterIsBankAdvice",
            ChequeRegisterZoneInfoId = "ChequeRegisterZoneInfoId",
            CoA2AccountCode = "CoA2AccountCode",
            CoA2AccountName = "CoA2AccountName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccPartyPaymentService {
        const baseUrl = "Transaction/AccPartyPayment";
        function Create(request: Serenity.SaveRequest<AccPartyPaymentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccPartyPaymentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccPartyPaymentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccPartyPaymentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccPartyPayment/Create",
            Update = "Transaction/AccPartyPayment/Update",
            Delete = "Transaction/AccPartyPayment/Delete",
            Retrieve = "Transaction/AccPartyPayment/Retrieve",
            List = "Transaction/AccPartyPayment/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccTransactionTypeAssignForm {
        TrType: Serenity.StringEditor;
        ParentId: Serenity.LookupEditor;
        CoaId: Serenity.LookupEditor;
    }
    class AccTransactionTypeAssignForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccTransactionTypeAssignMasterForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        Remarks: Serenity.StringEditor;
        CoADebit: CoADebitEditor;
        Credit: Serenity.StringEditor;
    }
    class AccTransactionTypeAssignMasterForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccTransactionTypeAssignMasterRow {
        Id?: number;
        VoucherTypeId?: number;
        TransactionTypeId?: number;
        Remarks?: string;
        CoADebit?: AccTransactionTypeAssignRow[];
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
    }
    namespace AccTransactionTypeAssignMasterRow {
        const idProperty = "Id";
        const nameProperty = "Remarks";
        const localTextPrefix = "Transaction.AccTransactionTypeAssignMaster";
        const lookupKey = "Transaction.AccTransactionTypeAssignMaster";
        function getLookup(): Q.Lookup<AccTransactionTypeAssignMasterRow>;
        const enum Fields {
            Id = "Id",
            VoucherTypeId = "VoucherTypeId",
            TransactionTypeId = "TransactionTypeId",
            Remarks = "Remarks",
            CoADebit = "CoADebit",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccTransactionTypeAssignMasterService {
        const baseUrl = "Transaction/AccTransactionTypeAssignMaster";
        function Create(request: Serenity.SaveRequest<AccTransactionTypeAssignMasterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccTransactionTypeAssignMasterRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccTransactionTypeAssignMasterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccTransactionTypeAssignMasterRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccTransactionTypeAssignMaster/Create",
            Update = "Transaction/AccTransactionTypeAssignMaster/Update",
            Delete = "Transaction/AccTransactionTypeAssignMaster/Delete",
            Retrieve = "Transaction/AccTransactionTypeAssignMaster/Retrieve",
            List = "Transaction/AccTransactionTypeAssignMaster/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccTransactionTypeAssignRow {
        Id?: number;
        TrType?: string;
        ParentId?: number;
        CoaId?: number;
        MasterID?: number;
        ParentRemarks?: string;
        ParentSortOrder?: number;
        ParentTransactionType?: string;
        ParentFundControlId?: number;
        ParentVoucherTypeId?: number;
        CoaAccountCode?: string;
        CoaAccountCodeCount?: number;
        CoaAccountGroup?: string;
        CoaAccountName?: string;
        CoaAccountNameBangla?: string;
        CoaCoaMapping?: string;
        CoaIsBillRef?: number;
        CoaIsBudgetHead?: number;
        CoaIsControlhead?: number;
        CoaIsCostCenterAllocate?: number;
        CoaLevel?: number;
        CoaMailingAddress?: string;
        CoaMailingName?: string;
        CoaOpeningBalance?: number;
        CoaRemarks?: string;
        CoaTaxId?: string;
        CoaUgcCode?: string;
        CoaFundControlId?: number;
        CoaParentAccountId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccTransactionTypeAssignRow {
        const idProperty = "Id";
        const nameProperty = "CoaAccountName";
        const localTextPrefix = "Transaction.AccTransactionTypeAssign";
        const lookupKey = "Transaction.AccTransactionTypeAssign";
        function getLookup(): Q.Lookup<AccTransactionTypeAssignRow>;
        const enum Fields {
            Id = "Id",
            TrType = "TrType",
            ParentId = "ParentId",
            CoaId = "CoaId",
            MasterID = "MasterID",
            ParentRemarks = "ParentRemarks",
            ParentSortOrder = "ParentSortOrder",
            ParentTransactionType = "ParentTransactionType",
            ParentFundControlId = "ParentFundControlId",
            ParentVoucherTypeId = "ParentVoucherTypeId",
            CoaAccountCode = "CoaAccountCode",
            CoaAccountCodeCount = "CoaAccountCodeCount",
            CoaAccountGroup = "CoaAccountGroup",
            CoaAccountName = "CoaAccountName",
            CoaAccountNameBangla = "CoaAccountNameBangla",
            CoaCoaMapping = "CoaCoaMapping",
            CoaIsBillRef = "CoaIsBillRef",
            CoaIsBudgetHead = "CoaIsBudgetHead",
            CoaIsControlhead = "CoaIsControlhead",
            CoaIsCostCenterAllocate = "CoaIsCostCenterAllocate",
            CoaLevel = "CoaLevel",
            CoaMailingAddress = "CoaMailingAddress",
            CoaMailingName = "CoaMailingName",
            CoaOpeningBalance = "CoaOpeningBalance",
            CoaRemarks = "CoaRemarks",
            CoaTaxId = "CoaTaxId",
            CoaUgcCode = "CoaUgcCode",
            CoaFundControlId = "CoaFundControlId",
            CoaParentAccountId = "CoaParentAccountId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccTransactionTypeAssignService {
        const baseUrl = "Transaction/AccTransactionTypeAssign";
        function Create(request: Serenity.SaveRequest<AccTransactionTypeAssignRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccTransactionTypeAssignRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccTransactionTypeAssignRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccTransactionTypeAssignRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccTransactionTypeAssign/Create",
            Update = "Transaction/AccTransactionTypeAssign/Update",
            Delete = "Transaction/AccTransactionTypeAssign/Delete",
            Retrieve = "Transaction/AccTransactionTypeAssign/Retrieve",
            List = "Transaction/AccTransactionTypeAssign/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetDetailsDeptForm {
        Id: Serenity.IntegerEditor;
        AccountName: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        BudgetYearId: Serenity.IntegerEditor;
        BudgetStatus: Serenity.IntegerEditor;
        BudgetDepartmentInfoId: Serenity.IntegerEditor;
        BudgetDept: Serenity.StringEditor;
        YearName: Serenity.StringEditor;
        ActualDuring: Serenity.DecimalEditor;
        Actual1stSixMonths: Serenity.DecimalEditor;
        BudgetApproved: Serenity.DecimalEditor;
        RevisedEstimate: Serenity.DecimalEditor;
        BudgetApproved1Step: Serenity.DecimalEditor;
    }
    class AccViewBudgetDetailsDeptForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetDetailsDeptRow {
        Id?: number;
        AccountName?: string;
        Quantity?: number;
        Amount?: number;
        ZoneInfoId?: number;
        BudgetYearId?: number;
        BudgetStatus?: number;
        BudgetDepartmentInfoId?: number;
        BudgetDept?: string;
        YearName?: string;
        ActualDuring?: number;
        Actual1stSixMonths?: number;
        BudgetApproved?: number;
        RevisedEstimate?: number;
    }
    namespace AccViewBudgetDetailsDeptRow {
        const idProperty = "Id";
        const nameProperty = "AccountName";
        const localTextPrefix = "Transaction.AccViewBudgetDetailsDept";
        const lookupKey = "Transaction.AccViewBudgetDetailsDeptRow";
        function getLookup(): Q.Lookup<AccViewBudgetDetailsDeptRow>;
        const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            Quantity = "Quantity",
            Amount = "Amount",
            ZoneInfoId = "ZoneInfoId",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus",
            BudgetDepartmentInfoId = "BudgetDepartmentInfoId",
            BudgetDept = "BudgetDept",
            YearName = "YearName",
            ActualDuring = "ActualDuring",
            Actual1stSixMonths = "Actual1stSixMonths",
            BudgetApproved = "BudgetApproved",
            RevisedEstimate = "RevisedEstimate",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccViewBudgetDetailsDeptService {
        const baseUrl = "Transaction/AccViewBudgetDetailsDept";
        function Create(request: Serenity.SaveRequest<AccViewBudgetDetailsDeptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccViewBudgetDetailsDeptRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccViewBudgetDetailsDeptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccViewBudgetDetailsDeptRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccViewBudgetDetailsDept/Create",
            Update = "Transaction/AccViewBudgetDetailsDept/Update",
            Delete = "Transaction/AccViewBudgetDetailsDept/Delete",
            Retrieve = "Transaction/AccViewBudgetDetailsDept/Retrieve",
            List = "Transaction/AccViewBudgetDetailsDept/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetDetailsForm {
        Id: Serenity.IntegerEditor;
        AccountName: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        BudgetRevisionNo: Serenity.IntegerEditor;
        BudgetDepartmentInfoId: Serenity.IntegerEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        EntityId: Serenity.IntegerEditor;
        BudgetYearId: Serenity.IntegerEditor;
        BudgetStatus: Serenity.IntegerEditor;
        BudgetDept: Serenity.StringEditor;
        YearName: Serenity.StringEditor;
        FundControlName: Serenity.StringEditor;
    }
    class AccViewBudgetDetailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetDetailsRow {
        Id?: number;
        AccountName?: string;
        Quantity?: number;
        Amount?: number;
        ActualDuring?: number;
        Actual1stSixMonths?: number;
        BudgetApproved?: number;
        RevisedEstimate?: number;
        ZoneInfoId?: number;
        BudgetYearId?: number;
        BudgetStatus?: number;
        YearName?: string;
        ZoneName?: string;
        ZoneCode?: string;
    }
    namespace AccViewBudgetDetailsRow {
        const idProperty = "AccountName";
        const nameProperty = "AccountName";
        const localTextPrefix = "Transaction.AccViewBudgetDetails";
        const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            Quantity = "Quantity",
            Amount = "Amount",
            ActualDuring = "ActualDuring",
            Actual1stSixMonths = "Actual1stSixMonths",
            BudgetApproved = "BudgetApproved",
            RevisedEstimate = "RevisedEstimate",
            ZoneInfoId = "ZoneInfoId",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus",
            YearName = "YearName",
            ZoneName = "ZoneName",
            ZoneCode = "ZoneCode",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccViewBudgetDetailsService {
        const baseUrl = "Transaction/AccViewBudgetDetails";
        function Create(request: Serenity.SaveRequest<AccViewBudgetDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccViewBudgetDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccViewBudgetDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccViewBudgetDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccViewBudgetDetails/Create",
            Update = "Transaction/AccViewBudgetDetails/Update",
            Delete = "Transaction/AccViewBudgetDetails/Delete",
            Retrieve = "Transaction/AccViewBudgetDetails/Retrieve",
            List = "Transaction/AccViewBudgetDetails/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetForm {
        Id: Serenity.IntegerEditor;
        AccountName: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        BudgetRevisionNo: Serenity.IntegerEditor;
        BudgetDepartmentInfoId: Serenity.IntegerEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        EntityId: Serenity.IntegerEditor;
        BudgetYearId: Serenity.IntegerEditor;
        BudgetStatus: Serenity.IntegerEditor;
    }
    class AccViewBudgetForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetRow {
        Id?: number;
        AccountName?: string;
        Quantity?: number;
        Amount?: number;
        BudgetYearId?: number;
        BudgetStatus?: number;
    }
    namespace AccViewBudgetRow {
        const idProperty = "AccountName";
        const nameProperty = "AccountName";
        const localTextPrefix = "Transaction.AccViewBudget";
        const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            Quantity = "Quantity",
            Amount = "Amount",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccViewBudgetService {
        const baseUrl = "Transaction/AccViewBudget";
        function Create(request: Serenity.SaveRequest<AccViewBudgetRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccViewBudgetRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccViewBudgetRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccViewBudgetRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccViewBudget/Create",
            Update = "Transaction/AccViewBudget/Update",
            Delete = "Transaction/AccViewBudget/Delete",
            Retrieve = "Transaction/AccViewBudget/Retrieve",
            List = "Transaction/AccViewBudget/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetZoneForm {
        Id: Serenity.IntegerEditor;
        AccountName: Serenity.StringEditor;
        BudgetYearId: Serenity.IntegerEditor;
        BudgetStatus: Serenity.IntegerEditor;
        Quantity: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        ZoneInfoId: Serenity.IntegerEditor;
    }
    class AccViewBudgetZoneForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccViewBudgetZoneRow {
        Id?: number;
        AccountName?: string;
        BudgetYearId?: number;
        BudgetStatus?: number;
        Quantity?: number;
        Amount?: number;
        ZoneInfoId?: number;
    }
    namespace AccViewBudgetZoneRow {
        const idProperty = "Id";
        const nameProperty = "AccountName";
        const localTextPrefix = "Transaction.AccViewBudgetZone";
        const lookupKey = "Transaction.AccViewBudgetZoneRow";
        function getLookup(): Q.Lookup<AccViewBudgetZoneRow>;
        const enum Fields {
            Id = "Id",
            AccountName = "AccountName",
            BudgetYearId = "BudgetYearId",
            BudgetStatus = "BudgetStatus",
            Quantity = "Quantity",
            Amount = "Amount",
            ZoneInfoId = "ZoneInfoId",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccViewBudgetZoneService {
        const baseUrl = "Transaction/AccViewBudgetZone";
        function Create(request: Serenity.SaveRequest<AccViewBudgetZoneRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccViewBudgetZoneRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccViewBudgetZoneRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccViewBudgetZoneRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccViewBudgetZone/Create",
            Update = "Transaction/AccViewBudgetZone/Update",
            Delete = "Transaction/AccViewBudgetZone/Delete",
            Retrieve = "Transaction/AccViewBudgetZone/Retrieve",
            List = "Transaction/AccViewBudgetZone/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccViewProjectListRow {
        Id?: number;
        NameOfWorks?: string;
        ZoneOrProjectId?: number;
    }
    namespace AccViewProjectListRow {
        const idProperty = "Id";
        const nameProperty = "NameOfWorks";
        const localTextPrefix = "Transaction.AccViewProjectList";
        const lookupKey = "Transaction.AccViewProjectList";
        function getLookup(): Q.Lookup<AccViewProjectListRow>;
        const enum Fields {
            Id = "Id",
            NameOfWorks = "NameOfWorks",
            ZoneOrProjectId = "ZoneOrProjectId",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherBankWiseForm {
        ApproverId: GetRecommenderInfoByApplicantVoucherEditor;
        approveStatus: Serenity.EnumEditor;
        IsBankWisePaymentVoucher: Serenity.BooleanEditor;
        IsBankWiseReceiptVoucher: Serenity.BooleanEditor;
        Id: Serenity.StringEditor;
        VoucherTypeId: Serenity.LookupEditor;
        TransactionMode: Serenity.StringEditor;
        PostingFinancialYearId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        VoucherDate: Serenity.DateEditor;
        VoucherNo: Serenity.StringEditor;
        AccountHeadBankCash: Serenity.LookupEditor;
        BankAccountInformationId: Serenity.LookupEditor;
        ChequeBookId: Serenity.LookupEditor;
        ChequeNumhdn: ChequeBookEditor;
        ChequeNo: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        ChequeType: ChequeTypeMappingEditor;
        ChequeRemarks: Serenity.StringEditor;
        PaytoOrReciveFrom: _Ext.AutoCompleteEditor;
        IsChequeFinished: Serenity.BooleanEditor;
        BankAmount: Serenity.DecimalEditor;
        PaytoForBankAdvice: Serenity.StringEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        PowerofAttorney: Serenity.StringEditor;
        NOAId: Serenity.LookupEditor;
        NOAId2: Serenity.IntegerEditor;
        LinkedWithAutoJV: Serenity.BooleanEditor;
        AutoPV_AccountHead: Serenity.LookupEditor;
        AutoBudgetAmountCOA: Serenity.DecimalEditor;
        AutoPV_CostCentreId: Serenity.LookupEditor;
        AutoBudgetAmountSUbledger: Serenity.DecimalEditor;
        AutoJVVoucherNo: Serenity.StringEditor;
        AutoJVVoucherNumber: Serenity.StringEditor;
        TransactionTypeEntityIdForAutoJV: Serenity.IntegerEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        AccountHead: Serenity.LookupEditor;
        BudgetAmountCOA: Serenity.DecimalEditor;
        CostCenterTypeId: Serenity.LookupEditor;
        ParentId: Serenity.LookupEditor;
        CostCentreId: Serenity.LookupEditor;
        BudgetAmountSUbledger: Serenity.DecimalEditor;
        MultipleCostCenter: Serenity.BooleanEditor;
        DebitAmount: Serenity.DecimalEditor;
        CreditAmount: Serenity.DecimalEditor;
        CalculationRate: Serenity.DecimalEditor;
        CalculationAmount: Serenity.DecimalEditor;
        Type: VoucherTemplateDrCrMappingEditor;
        DDescription: Serenity.StringEditor;
        AddtoGrid: Serenity.StringEditor;
        VoucherDetails: AccVoucherDetailsEditor;
        AccountBankCash: Serenity.StringEditor;
        AccountBankCashAmount: Serenity.DecimalEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        ProjectID: Serenity.LookupEditor;
        ClearDate: Serenity.DateEditor;
        IsClearDate: Serenity.IntegerEditor;
        Description: Serenity.TextAreaEditor;
        PostedBy: Serenity.StringEditor;
        PostingDate: Serenity.DateEditor;
        EmpId: Serenity.IntegerEditor;
        TemplateStatus: Serenity.IntegerEditor;
        TemplateId: Serenity.IntegerEditor;
        TemplateCOAId: Serenity.IntegerEditor;
        TemplateChequeRegisterId: Serenity.IntegerEditor;
        RemainAmount: Serenity.DecimalEditor;
        TemplateCOAId2: Serenity.DecimalEditor;
        FileName: Serenity.MultipleImageUploadEditor;
        ConversionRate: Serenity.DecimalEditor;
        ConversionAmount: Serenity.DecimalEditor;
        FileNo: Serenity.StringEditor;
        PageNo: Serenity.StringEditor;
        MultiCurrency: Serenity.StringEditor;
        ApplicationInformationHistory: VoucherApprovalHistoryEditor;
    }
    class AccVoucherBankWiseForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccVoucherConfigurationForm {
        VoucherTypeId: Serenity.LookupEditor;
        AutoNumbering: Serenity.BooleanEditor;
        TransactionTypeId: Serenity.LookupEditor;
        PreparedByInfo: Serenity.BooleanEditor;
        AccountingPeriodId: Serenity.LookupEditor;
        IsUserFinancialAtTheEnd: Serenity.BooleanEditor;
        StartingNumber: Serenity.IntegerEditor;
        NewNumber: Serenity.BooleanEditor;
        NumberLength: Serenity.IntegerEditor;
        CommonDescription: Serenity.BooleanEditor;
        Prefix: Serenity.StringEditor;
        EachAccounting: Serenity.BooleanEditor;
        Suffix: Serenity.StringEditor;
        IsAutoPost: Serenity.BooleanEditor;
        Separators: Serenity.StringEditor;
        IsUserFinancialAtStart: Serenity.BooleanEditor;
        IsMonth: Serenity.BooleanEditor;
        IsDate: Serenity.BooleanEditor;
        Date: Serenity.DateEditor;
        NewNumberforEveryBankAccount: Serenity.BooleanEditor;
        IsActive: Serenity.BooleanEditor;
        AddZoneShortCode: Serenity.BooleanEditor;
        AddBankACShortCode: Serenity.BooleanEditor;
    }
    class AccVoucherConfigurationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherConfigurationRow {
        Id?: number;
        AutoNumbering?: boolean;
        CommonDescription?: boolean;
        EachAccounting?: boolean;
        IsActive?: boolean;
        IsUserFinancialAtTheEnd?: boolean;
        MaxMonthSerialNumber?: string;
        MaxSerialNumber?: number;
        NewNumber?: boolean;
        NumberLength?: number;
        PostingNumber?: number;
        Prefix?: string;
        PreparedByInfo?: boolean;
        Separators?: string;
        StartingNumber?: number;
        Suffix?: string;
        TransactionTypeId?: number;
        VoucherTypeId?: number;
        FundControlInformationId?: number;
        AccountingPeriodId?: number;
        Date?: string;
        ZoneInfoId?: number;
        IsAutoPost?: boolean;
        IsUserFinancialAtStart?: boolean;
        IsMonth?: boolean;
        IsDate?: boolean;
        NewNumberforEveryBankAccount?: boolean;
        AddZoneShortCode?: boolean;
        AddBankACShortCode?: boolean;
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
        TransactionTypeVoucherTypeId?: number;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        FundControlInformationCode?: string;
        FundControlInformationFundControlName?: string;
        FundControlInformationRemarks?: string;
        AccountingPeriodIsActive?: number;
        AccountingPeriodIsClosed?: number;
        AccountingPeriodPeriodEndDate?: string;
        AccountingPeriodPeriodStartDate?: string;
        AccountingPeriodYearName?: string;
        AccountingPeriodFundControlInformationId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccVoucherConfigurationRow {
        const idProperty = "Id";
        const nameProperty = "AccountingPeriodYearName";
        const localTextPrefix = "Transaction.AccVoucherConfiguration";
        const lookupKey = "Transaction.AccVoucherConfiguration";
        function getLookup(): Q.Lookup<AccVoucherConfigurationRow>;
        const enum Fields {
            Id = "Id",
            AutoNumbering = "AutoNumbering",
            CommonDescription = "CommonDescription",
            EachAccounting = "EachAccounting",
            IsActive = "IsActive",
            IsUserFinancialAtTheEnd = "IsUserFinancialAtTheEnd",
            MaxMonthSerialNumber = "MaxMonthSerialNumber",
            MaxSerialNumber = "MaxSerialNumber",
            NewNumber = "NewNumber",
            NumberLength = "NumberLength",
            PostingNumber = "PostingNumber",
            Prefix = "Prefix",
            PreparedByInfo = "PreparedByInfo",
            Separators = "Separators",
            StartingNumber = "StartingNumber",
            Suffix = "Suffix",
            TransactionTypeId = "TransactionTypeId",
            VoucherTypeId = "VoucherTypeId",
            FundControlInformationId = "FundControlInformationId",
            AccountingPeriodId = "AccountingPeriodId",
            Date = "Date",
            ZoneInfoId = "ZoneInfoId",
            IsAutoPost = "IsAutoPost",
            IsUserFinancialAtStart = "IsUserFinancialAtStart",
            IsMonth = "IsMonth",
            IsDate = "IsDate",
            NewNumberforEveryBankAccount = "NewNumberforEveryBankAccount",
            AddZoneShortCode = "AddZoneShortCode",
            AddBankACShortCode = "AddBankACShortCode",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId",
            TransactionTypeVoucherTypeId = "TransactionTypeVoucherTypeId",
            VoucherTypeName = "VoucherTypeName",
            VoucherTypeSortOrder = "VoucherTypeSortOrder",
            FundControlInformationCode = "FundControlInformationCode",
            FundControlInformationFundControlName = "FundControlInformationFundControlName",
            FundControlInformationRemarks = "FundControlInformationRemarks",
            AccountingPeriodIsActive = "AccountingPeriodIsActive",
            AccountingPeriodIsClosed = "AccountingPeriodIsClosed",
            AccountingPeriodPeriodEndDate = "AccountingPeriodPeriodEndDate",
            AccountingPeriodPeriodStartDate = "AccountingPeriodPeriodStartDate",
            AccountingPeriodYearName = "AccountingPeriodYearName",
            AccountingPeriodFundControlInformationId = "AccountingPeriodFundControlInformationId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccVoucherConfigurationService {
        const baseUrl = "Transaction/AccVoucherConfiguration";
        function Create(request: Serenity.SaveRequest<AccVoucherConfigurationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherConfigurationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherConfigurationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherConfigurationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccVoucherConfiguration/Create",
            Update = "Transaction/AccVoucherConfiguration/Update",
            Delete = "Transaction/AccVoucherConfiguration/Delete",
            Retrieve = "Transaction/AccVoucherConfiguration/Retrieve",
            List = "Transaction/AccVoucherConfiguration/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccVoucherDetailsForm {
        ChartofAccountsId: Serenity.LookupEditor;
        DebitAmount: Serenity.DecimalEditor;
        CreditAmount: Serenity.DecimalEditor;
        CalculationAmount: Serenity.DecimalEditor;
        CalculationRate: Serenity.DecimalEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        EffectiveValue: Serenity.DecimalEditor;
        CCreditAmount: Serenity.DecimalEditor;
        CDebitAmount: Serenity.DecimalEditor;
        Description: Serenity.TextAreaEditor;
        AdjustedChequeRegisterId: Serenity.LookupEditor;
        VoucherDtlAllocation: AccVoucherDtlAllocationEditor;
        VoucherDtlBillRef: AccVoucherDtlBillRefEditor;
        ConversionRate: Serenity.DecimalEditor;
        ConversionAmount: Serenity.DecimalEditor;
    }
    class AccVoucherDetailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherDetailsRow {
        Id?: number;
        CreditAmount?: number;
        DebitAmount?: number;
        Description?: string;
        IsPayorReceiveHead?: number;
        PaymentVoucherHead?: boolean;
        Mid?: number;
        ChartofAccountsId?: number;
        VoucherInformationId?: number;
        VoucherDtlAllocation?: AccVoucherDtlAllocationRow[];
        VoucherDtlBillRef?: AccVoucherDtlBillRefRow[];
        ConversionRate?: number;
        ConversionAmount?: number;
        EffectiveValue?: number;
        CCreditAmount?: number;
        CDebitAmount?: number;
        BankAccountInformationId?: number;
        ChequeRegisterId?: number;
        ClearDate?: string;
        IsClearDate?: number;
        CalculationAmount?: number;
        CalculationRate?: number;
        IsAccountHeadBankCash?: boolean;
        LinkedJVDetailId?: number;
        AdjustedChequeRegisterId?: number;
        ChartofAccountsUserCode?: string;
        ChartofAccountsAccountName?: string;
        ChartofAccountsCoaMapping?: string;
        ChartofAccountsFundControlId?: number;
        VoucherInformationAmount?: number;
        VoucherInformationAmountInWords?: string;
        VoucherInformationClearDate?: string;
        VoucherInformationDescription?: string;
        VoucherInformationHeadDescription?: string;
        VoucherInformationIsApproved?: number;
        VoucherInformationIsAuto?: number;
        VoucherInformationIsBankReconcile?: number;
        VoucherInformationIsSubmitted?: number;
        VoucherInformationPaymentAmount?: number;
        VoucherInformationPaytoOrReciveFrom?: string;
        VoucherInformationPostToLedger?: number;
        VoucherInformationPostedBy?: string;
        VoucherInformationPostingDate?: string;
        VoucherInformationPostingNumber?: string;
        VoucherInformationPreparedBy?: string;
        VoucherInformationTransactionMode?: string;
        VoucherInformationTransactionType?: string;
        VoucherInformationVoucherDate?: string;
        VoucherInformationVoucherNo?: string;
        VoucherInformationVoucherNumber?: string;
        VoucherInformationVoucherType?: string;
        VoucherInformationVoucherTypeId?: number;
        VoucherInformationCostCentreId?: number;
        VoucherInformationChequeRegisterId?: number;
        VoucherInformationChequeRegisterNo?: string;
        VoucherInformationTransactionTypeEntityId?: number;
        VoucherInformationBankAccountInformationId?: number;
        VoucherInformationFundControlInformationId?: number;
        VoucherInformationZoneID?: number;
        VoucherTypeName?: string;
        PaytoOrReciveFrom?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccVoucherDetailsRow {
        const idProperty = "Id";
        const nameProperty = "Description";
        const localTextPrefix = "Transaction.AccVoucherDetails";
        const lookupKey = "Transaction.AccVoucherDetails";
        function getLookup(): Q.Lookup<AccVoucherDetailsRow>;
        const enum Fields {
            Id = "Id",
            CreditAmount = "CreditAmount",
            DebitAmount = "DebitAmount",
            Description = "Description",
            IsPayorReceiveHead = "IsPayorReceiveHead",
            PaymentVoucherHead = "PaymentVoucherHead",
            Mid = "Mid",
            ChartofAccountsId = "ChartofAccountsId",
            VoucherInformationId = "VoucherInformationId",
            VoucherDtlAllocation = "VoucherDtlAllocation",
            VoucherDtlBillRef = "VoucherDtlBillRef",
            ConversionRate = "ConversionRate",
            ConversionAmount = "ConversionAmount",
            EffectiveValue = "EffectiveValue",
            CCreditAmount = "CCreditAmount",
            CDebitAmount = "CDebitAmount",
            BankAccountInformationId = "BankAccountInformationId",
            ChequeRegisterId = "ChequeRegisterId",
            ClearDate = "ClearDate",
            IsClearDate = "IsClearDate",
            CalculationAmount = "CalculationAmount",
            CalculationRate = "CalculationRate",
            IsAccountHeadBankCash = "IsAccountHeadBankCash",
            LinkedJVDetailId = "LinkedJVDetailId",
            AdjustedChequeRegisterId = "AdjustedChequeRegisterId",
            ChartofAccountsUserCode = "ChartofAccountsUserCode",
            ChartofAccountsAccountName = "ChartofAccountsAccountName",
            ChartofAccountsCoaMapping = "ChartofAccountsCoaMapping",
            ChartofAccountsFundControlId = "ChartofAccountsFundControlId",
            VoucherInformationAmount = "VoucherInformationAmount",
            VoucherInformationAmountInWords = "VoucherInformationAmountInWords",
            VoucherInformationClearDate = "VoucherInformationClearDate",
            VoucherInformationDescription = "VoucherInformationDescription",
            VoucherInformationHeadDescription = "VoucherInformationHeadDescription",
            VoucherInformationIsApproved = "VoucherInformationIsApproved",
            VoucherInformationIsAuto = "VoucherInformationIsAuto",
            VoucherInformationIsBankReconcile = "VoucherInformationIsBankReconcile",
            VoucherInformationIsSubmitted = "VoucherInformationIsSubmitted",
            VoucherInformationPaymentAmount = "VoucherInformationPaymentAmount",
            VoucherInformationPaytoOrReciveFrom = "VoucherInformationPaytoOrReciveFrom",
            VoucherInformationPostToLedger = "VoucherInformationPostToLedger",
            VoucherInformationPostedBy = "VoucherInformationPostedBy",
            VoucherInformationPostingDate = "VoucherInformationPostingDate",
            VoucherInformationPostingNumber = "VoucherInformationPostingNumber",
            VoucherInformationPreparedBy = "VoucherInformationPreparedBy",
            VoucherInformationTransactionMode = "VoucherInformationTransactionMode",
            VoucherInformationTransactionType = "VoucherInformationTransactionType",
            VoucherInformationVoucherDate = "VoucherInformationVoucherDate",
            VoucherInformationVoucherNo = "VoucherInformationVoucherNo",
            VoucherInformationVoucherNumber = "VoucherInformationVoucherNumber",
            VoucherInformationVoucherType = "VoucherInformationVoucherType",
            VoucherInformationVoucherTypeId = "VoucherInformationVoucherTypeId",
            VoucherInformationCostCentreId = "VoucherInformationCostCentreId",
            VoucherInformationChequeRegisterId = "VoucherInformationChequeRegisterId",
            VoucherInformationChequeRegisterNo = "VoucherInformationChequeRegisterNo",
            VoucherInformationTransactionTypeEntityId = "VoucherInformationTransactionTypeEntityId",
            VoucherInformationBankAccountInformationId = "VoucherInformationBankAccountInformationId",
            VoucherInformationFundControlInformationId = "VoucherInformationFundControlInformationId",
            VoucherInformationZoneID = "VoucherInformationZoneID",
            VoucherTypeName = "VoucherTypeName",
            PaytoOrReciveFrom = "PaytoOrReciveFrom",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccVoucherDetailsService {
        const baseUrl = "Transaction/AccVoucherDetails";
        function Create(request: Serenity.SaveRequest<AccVoucherDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccVoucherDetails/Create",
            Update = "Transaction/AccVoucherDetails/Update",
            Delete = "Transaction/AccVoucherDetails/Delete",
            Retrieve = "Transaction/AccVoucherDetails/Retrieve",
            List = "Transaction/AccVoucherDetails/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccVoucherDtlAllocationForm {
        CostCenterTypeId: Serenity.LookupEditor;
        CostCenterParentId: Serenity.LookupEditor;
        CostCenterId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
    }
    class AccVoucherDtlAllocationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherDtlAllocationRow {
        Id?: number;
        Amount?: number;
        CostCenterTypeId?: number;
        CostCenterParentId?: number;
        CostCenterId?: number;
        VoucherDetailId?: number;
        DebitAmount?: number;
        CreditAmount?: number;
        AdjustedChequeRegisterId?: number;
        CostCenterCode?: string;
        CostCenterUserCode?: string;
        CostCenterName?: string;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccVoucherDtlAllocationRow {
        const idProperty = "Id";
        const localTextPrefix = "Transaction.AccVoucherDtlAllocation";
        const lookupKey = "Transaction.AccVoucherDtlAllocationRow";
        function getLookup(): Q.Lookup<AccVoucherDtlAllocationRow>;
        const enum Fields {
            Id = "Id",
            Amount = "Amount",
            CostCenterTypeId = "CostCenterTypeId",
            CostCenterParentId = "CostCenterParentId",
            CostCenterId = "CostCenterId",
            VoucherDetailId = "VoucherDetailId",
            DebitAmount = "DebitAmount",
            CreditAmount = "CreditAmount",
            AdjustedChequeRegisterId = "AdjustedChequeRegisterId",
            CostCenterCode = "CostCenterCode",
            CostCenterUserCode = "CostCenterUserCode",
            CostCenterName = "CostCenterName",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccVoucherDtlAllocationService {
        const baseUrl = "Transaction/AccVoucherDtlAllocation";
        function Create(request: Serenity.SaveRequest<AccVoucherDtlAllocationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherDtlAllocationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherDtlAllocationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherDtlAllocationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccVoucherDtlAllocation/Create",
            Update = "Transaction/AccVoucherDtlAllocation/Update",
            Delete = "Transaction/AccVoucherDtlAllocation/Delete",
            Retrieve = "Transaction/AccVoucherDtlAllocation/Retrieve",
            List = "Transaction/AccVoucherDtlAllocation/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccVoucherDtlBillRefForm {
        BillDate: Serenity.DateEditor;
        BillType: BillTypeEditor;
        BillRefNo: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        Description: Serenity.TextAreaEditor;
    }
    class AccVoucherDtlBillRefForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherDtlBillRefRow {
        Id?: number;
        Amount?: number;
        BillDate?: string;
        BillRefNo?: string;
        BillType?: string;
        Description?: string;
        IsPaymentComplete?: number;
        VoucherDetailId?: number;
        VoucherDetailCreditAmount?: number;
        VoucherDetailDebitAmount?: number;
        VoucherDetailDescription?: string;
        VoucherDetailIsPayorReceiveHead?: number;
        VoucherDetailChartofAccountsId?: number;
        VoucherDetailVoucherInformationId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccVoucherDtlBillRefRow {
        const idProperty = "Id";
        const nameProperty = "BillRefNo";
        const localTextPrefix = "Transaction.AccVoucherDtlBillRef";
        const lookupKey = "Transaction.AccVoucherDtlBillRefRow";
        function getLookup(): Q.Lookup<AccVoucherDtlBillRefRow>;
        const enum Fields {
            Id = "Id",
            Amount = "Amount",
            BillDate = "BillDate",
            BillRefNo = "BillRefNo",
            BillType = "BillType",
            Description = "Description",
            IsPaymentComplete = "IsPaymentComplete",
            VoucherDetailId = "VoucherDetailId",
            VoucherDetailCreditAmount = "VoucherDetailCreditAmount",
            VoucherDetailDebitAmount = "VoucherDetailDebitAmount",
            VoucherDetailDescription = "VoucherDetailDescription",
            VoucherDetailIsPayorReceiveHead = "VoucherDetailIsPayorReceiveHead",
            VoucherDetailChartofAccountsId = "VoucherDetailChartofAccountsId",
            VoucherDetailVoucherInformationId = "VoucherDetailVoucherInformationId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccVoucherDtlBillRefService {
        const baseUrl = "Transaction/AccVoucherDtlBillRef";
        function Create(request: Serenity.SaveRequest<AccVoucherDtlBillRefRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherDtlBillRefRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherDtlBillRefRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherDtlBillRefRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccVoucherDtlBillRef/Create",
            Update = "Transaction/AccVoucherDtlBillRef/Update",
            Delete = "Transaction/AccVoucherDtlBillRef/Delete",
            Retrieve = "Transaction/AccVoucherDtlBillRef/Retrieve",
            List = "Transaction/AccVoucherDtlBillRef/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccVoucherInformationForm {
        ApproverId: GetRecommenderInfoByApplicantVoucherEditor;
        approveStatus: Serenity.EnumEditor;
        Id: Serenity.StringEditor;
        VoucherTypeId: Serenity.LookupEditor;
        PostingFinancialYearId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        VoucherDate: Serenity.DateEditor;
        VoucherNo: Serenity.StringEditor;
        PaytoOrReciveFrom: _Ext.AutoCompleteEditor;
        NOAId: Serenity.LookupEditor;
        NOAId2: Serenity.IntegerEditor;
        ChequeRegisterId: Serenity.LookupEditor;
        LinkedWithAutoJV: Serenity.BooleanEditor;
        LinkedPaymentVoucherNo: Serenity.StringEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        AccountHead: Serenity.LookupEditor;
        CostCenterTypeId: Serenity.LookupEditor;
        ParentId: Serenity.LookupEditor;
        CostCentreId: Serenity.LookupEditor;
        MultipleCostCenter: Serenity.BooleanEditor;
        MultiCurrency: Serenity.StringEditor;
        DebitAmount: Serenity.DecimalEditor;
        CreditAmount: Serenity.DecimalEditor;
        DDescription: Serenity.StringEditor;
        AdjustedChequeRegisterId: Serenity.LookupEditor;
        AddtoGrid: Serenity.StringEditor;
        VoucherDetails: AccVoucherDetailsEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        ProjectID: Serenity.LookupEditor;
        Description: Serenity.TextAreaEditor;
        PostedBy: Serenity.StringEditor;
        PostingDate: Serenity.DateEditor;
        EmpId: Serenity.IntegerEditor;
        TemplateStatus: Serenity.IntegerEditor;
        TemplateId: Serenity.IntegerEditor;
        TemplateCOAId: Serenity.IntegerEditor;
        TemplateChequeRegisterId: Serenity.IntegerEditor;
        RemainAmount: Serenity.DecimalEditor;
        TemplateCOAId2: Serenity.DecimalEditor;
        FileName: Serenity.MultipleImageUploadEditor;
        ConversionRate: Serenity.DecimalEditor;
        ConversionAmount: Serenity.DecimalEditor;
        FileNo: Serenity.StringEditor;
        PageNo: Serenity.StringEditor;
        ApplicationInformationHistory: VoucherApprovalHistoryEditor;
    }
    class AccVoucherInformationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherInformationRow {
        Id?: number;
        Amount?: number;
        AmountInWords?: string;
        ClearDate?: string;
        IsClearDate?: number;
        Description?: string;
        FileNo?: string;
        HeadDescription?: string;
        IsApproved?: number;
        IsAuto?: number;
        IsBankReconcile?: number;
        IsCash?: number;
        IsSubmitted?: number;
        MenuName?: string;
        Mid?: number;
        NoteType?: string;
        PageNo?: string;
        PaymentAmount?: number;
        PaymentamountInWords?: string;
        PostToLedger?: number;
        PostToLedgerBoolean?: boolean;
        PostedBy?: string;
        PostedByName?: string;
        PostingDate?: string;
        PostingNumber?: string;
        PreparedBy?: string;
        SubModule?: string;
        TransactionMode?: string;
        TransactionType?: string;
        TransferType?: string;
        VoucherDate?: string;
        VoucherNo?: string;
        VoucherNumber?: string;
        VoucherTag?: number;
        VoucherType?: string;
        Type?: string;
        CostCenterTypeId?: number;
        ParentId?: number;
        CostCentreId?: number;
        VoucherTypeId?: number;
        FileName?: string;
        TransactionTypeEntityId?: number;
        PostingFinancialYearId?: number;
        FundControlInformationId?: number;
        VoucherDetails?: AccVoucherDetailsRow[];
        ZoneId?: number;
        approveStatus?: ApprovalStatus;
        EmpId?: number;
        ProjectID?: number;
        TemplateId?: number;
        postingSendTo?: number;
        AccountBankCash?: string;
        AccountBankCashAmount?: number;
        PowerofAttorney?: string;
        LinkedWithAutoJV?: boolean;
        LinkedVoucherIdForAutoJV?: number;
        LinkedJournalVoucherNo?: string;
        LinkedDebitVoucherNo?: string;
        LinkedWithDebitVoucher?: boolean;
        JVAmount?: number;
        JVAmountInWords?: string;
        NOAId?: number;
        NoaNumber?: string;
        IsBankWisePaymentVoucher?: boolean;
        IsBankWiseReceiptVoucher?: boolean;
        BankAccountInformationId?: number;
        PaytoOrReciveFrom?: string;
        PaytoForBankAdvice?: string;
        ChequeRegisterId?: number;
        IsChequePrepared?: boolean;
        ChequePreparedBy?: string;
        ChequePrepareDate?: string;
        CostCentreCode?: string;
        CostCentreIsInstitute?: number;
        CostCentreName?: string;
        CostCentrePaAmmount?: number;
        CostCentreParentId?: number;
        CostCentreEntityId?: number;
        ChequeRegisterAmount?: number;
        ChequeRegisterAmountInWords?: string;
        ChequeRegisterChequeDate?: string;
        ChequeRegisterChequeIssueDate?: string;
        ChequeRegisterChequeNo?: string;
        ChequeRegisterChequeType?: string;
        ChequeRegisterIsCancelled?: number;
        ChequeRegisterIsPayment?: number;
        ChequeRegisterIsUsed?: number;
        ChequeRegisterPayTo?: string;
        ChequeRegisterPayeeBankName?: string;
        ChequeRegisterRemarks?: string;
        ChequeRegisterVoucherNo?: string;
        ChequeRegisterBankAccountInformationId?: number;
        ChequeRegisterVoucherInformationId?: number;
        ChequeRegisterEntityId?: number;
        ChequeRegisterChequeBookId?: number;
        TransactionTypeEntityTransactionType?: string;
        TransactionTypeEntityFundControlId?: number;
        TransactionTypeEntityVoucherTypeId?: number;
        BankAccountInformationAccountName?: string;
        BankAccountInformationAccountNumber?: string;
        BankAccountInformationCode?: string;
        BankAccountInformationCoaId?: number;
        BankAccountInformationBankId?: number;
        BankAccountInformationBankBranchId?: number;
        BankAccountInformationEntityId?: number;
        PostingFinancialYearIsActive?: number;
        PostingFinancialYearIsClosed?: number;
        PostingFinancialYearPeriodEndDate?: string;
        PostingFinancialYearPeriodStartDate?: string;
        PostingFinancialYearYearName?: string;
        PostingFinancialYearFundControlInformationId?: number;
        FundControlInformationCode?: string;
        FundControlInformationFundControlName?: string;
        FundControlInformationRemarks?: string;
        ZoneZoneName?: string;
        ZoneZoneCode?: string;
        VoucherTypeName?: string;
        ApprovalAction?: string;
        ApprovalComments?: string;
        ApplicationInformationHistory?: ApvApplicationInformationRow[];
        ApproverId?: number;
        TemplateStatus?: number;
        TemplateCOAId?: number;
        TemplateChequeRegisterId?: number;
        RemainAmount?: number;
        TemplateCOAId2?: number;
        AutoJVVoucherNo?: string;
        AutoJVVoucherNumber?: string;
        TransactionTypeEntityIdForAutoJV?: number;
        AutoPV_AccountHead?: number;
        AutoPV_CostCentreId?: number;
        MinAmount?: number;
        MaxAmount?: number;
        PostingSing?: number[];
        PreparedSing?: number[];
        CheckedSing?: number[];
        ApprovedSing?: number[];
        PostedEmployee?: string;
        PreparedEmployee?: string;
        CheckedEmployee?: string;
        ApprovedEmployee?: string;
        RegretSendTo?: number;
        AccountHeadBankCash?: number;
        ChequeBookId?: number;
        ChequeNumhdn?: number;
        ChequeNo?: string;
        IsChequeFinished?: boolean;
        ChequeType?: string;
        ChequeDate?: string;
        ChequeRemarks?: string;
        BankAmount?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccVoucherInformationRow {
        const idProperty = "Id";
        const nameProperty = "AmountInWords";
        const localTextPrefix = "Transaction.AccVoucherInformation";
        const lookupKey = "Transaction.AccVoucherInformation";
        function getLookup(): Q.Lookup<AccVoucherInformationRow>;
        const enum Fields {
            Id = "Id",
            Amount = "Amount",
            AmountInWords = "AmountInWords",
            ClearDate = "ClearDate",
            IsClearDate = "IsClearDate",
            Description = "Description",
            FileNo = "FileNo",
            HeadDescription = "HeadDescription",
            IsApproved = "IsApproved",
            IsAuto = "IsAuto",
            IsBankReconcile = "IsBankReconcile",
            IsCash = "IsCash",
            IsSubmitted = "IsSubmitted",
            MenuName = "MenuName",
            Mid = "Mid",
            NoteType = "NoteType",
            PageNo = "PageNo",
            PaymentAmount = "PaymentAmount",
            PaymentamountInWords = "PaymentamountInWords",
            PostToLedger = "PostToLedger",
            PostToLedgerBoolean = "PostToLedgerBoolean",
            PostedBy = "PostedBy",
            PostedByName = "PostedByName",
            PostingDate = "PostingDate",
            PostingNumber = "PostingNumber",
            PreparedBy = "PreparedBy",
            SubModule = "SubModule",
            TransactionMode = "TransactionMode",
            TransactionType = "TransactionType",
            TransferType = "TransferType",
            VoucherDate = "VoucherDate",
            VoucherNo = "VoucherNo",
            VoucherNumber = "VoucherNumber",
            VoucherTag = "VoucherTag",
            VoucherType = "VoucherType",
            Type = "Type",
            CostCenterTypeId = "CostCenterTypeId",
            ParentId = "ParentId",
            CostCentreId = "CostCentreId",
            VoucherTypeId = "VoucherTypeId",
            FileName = "FileName",
            TransactionTypeEntityId = "TransactionTypeEntityId",
            PostingFinancialYearId = "PostingFinancialYearId",
            FundControlInformationId = "FundControlInformationId",
            VoucherDetails = "VoucherDetails",
            ZoneId = "ZoneId",
            approveStatus = "approveStatus",
            EmpId = "EmpId",
            ProjectID = "ProjectID",
            TemplateId = "TemplateId",
            postingSendTo = "postingSendTo",
            AccountBankCash = "AccountBankCash",
            AccountBankCashAmount = "AccountBankCashAmount",
            PowerofAttorney = "PowerofAttorney",
            LinkedWithAutoJV = "LinkedWithAutoJV",
            LinkedVoucherIdForAutoJV = "LinkedVoucherIdForAutoJV",
            LinkedJournalVoucherNo = "LinkedJournalVoucherNo",
            LinkedDebitVoucherNo = "LinkedDebitVoucherNo",
            LinkedWithDebitVoucher = "LinkedWithDebitVoucher",
            JVAmount = "JVAmount",
            JVAmountInWords = "JVAmountInWords",
            NOAId = "NOAId",
            NoaNumber = "NoaNumber",
            IsBankWisePaymentVoucher = "IsBankWisePaymentVoucher",
            IsBankWiseReceiptVoucher = "IsBankWiseReceiptVoucher",
            BankAccountInformationId = "BankAccountInformationId",
            PaytoOrReciveFrom = "PaytoOrReciveFrom",
            PaytoForBankAdvice = "PaytoForBankAdvice",
            ChequeRegisterId = "ChequeRegisterId",
            IsChequePrepared = "IsChequePrepared",
            ChequePreparedBy = "ChequePreparedBy",
            ChequePrepareDate = "ChequePrepareDate",
            CostCentreCode = "CostCentreCode",
            CostCentreIsInstitute = "CostCentreIsInstitute",
            CostCentreName = "CostCentreName",
            CostCentrePaAmmount = "CostCentrePaAmmount",
            CostCentreParentId = "CostCentreParentId",
            CostCentreEntityId = "CostCentreEntityId",
            ChequeRegisterAmount = "ChequeRegisterAmount",
            ChequeRegisterAmountInWords = "ChequeRegisterAmountInWords",
            ChequeRegisterChequeDate = "ChequeRegisterChequeDate",
            ChequeRegisterChequeIssueDate = "ChequeRegisterChequeIssueDate",
            ChequeRegisterChequeNo = "ChequeRegisterChequeNo",
            ChequeRegisterChequeType = "ChequeRegisterChequeType",
            ChequeRegisterIsCancelled = "ChequeRegisterIsCancelled",
            ChequeRegisterIsPayment = "ChequeRegisterIsPayment",
            ChequeRegisterIsUsed = "ChequeRegisterIsUsed",
            ChequeRegisterPayTo = "ChequeRegisterPayTo",
            ChequeRegisterPayeeBankName = "ChequeRegisterPayeeBankName",
            ChequeRegisterRemarks = "ChequeRegisterRemarks",
            ChequeRegisterVoucherNo = "ChequeRegisterVoucherNo",
            ChequeRegisterBankAccountInformationId = "ChequeRegisterBankAccountInformationId",
            ChequeRegisterVoucherInformationId = "ChequeRegisterVoucherInformationId",
            ChequeRegisterEntityId = "ChequeRegisterEntityId",
            ChequeRegisterChequeBookId = "ChequeRegisterChequeBookId",
            TransactionTypeEntityTransactionType = "TransactionTypeEntityTransactionType",
            TransactionTypeEntityFundControlId = "TransactionTypeEntityFundControlId",
            TransactionTypeEntityVoucherTypeId = "TransactionTypeEntityVoucherTypeId",
            BankAccountInformationAccountName = "BankAccountInformationAccountName",
            BankAccountInformationAccountNumber = "BankAccountInformationAccountNumber",
            BankAccountInformationCode = "BankAccountInformationCode",
            BankAccountInformationCoaId = "BankAccountInformationCoaId",
            BankAccountInformationBankId = "BankAccountInformationBankId",
            BankAccountInformationBankBranchId = "BankAccountInformationBankBranchId",
            BankAccountInformationEntityId = "BankAccountInformationEntityId",
            PostingFinancialYearIsActive = "PostingFinancialYearIsActive",
            PostingFinancialYearIsClosed = "PostingFinancialYearIsClosed",
            PostingFinancialYearPeriodEndDate = "PostingFinancialYearPeriodEndDate",
            PostingFinancialYearPeriodStartDate = "PostingFinancialYearPeriodStartDate",
            PostingFinancialYearYearName = "PostingFinancialYearYearName",
            PostingFinancialYearFundControlInformationId = "PostingFinancialYearFundControlInformationId",
            FundControlInformationCode = "FundControlInformationCode",
            FundControlInformationFundControlName = "FundControlInformationFundControlName",
            FundControlInformationRemarks = "FundControlInformationRemarks",
            ZoneZoneName = "ZoneZoneName",
            ZoneZoneCode = "ZoneZoneCode",
            VoucherTypeName = "VoucherTypeName",
            ApprovalAction = "ApprovalAction",
            ApprovalComments = "ApprovalComments",
            ApplicationInformationHistory = "ApplicationInformationHistory",
            ApproverId = "ApproverId",
            TemplateStatus = "TemplateStatus",
            TemplateCOAId = "TemplateCOAId",
            TemplateChequeRegisterId = "TemplateChequeRegisterId",
            RemainAmount = "RemainAmount",
            TemplateCOAId2 = "TemplateCOAId2",
            AutoJVVoucherNo = "AutoJVVoucherNo",
            AutoJVVoucherNumber = "AutoJVVoucherNumber",
            TransactionTypeEntityIdForAutoJV = "TransactionTypeEntityIdForAutoJV",
            AutoPV_AccountHead = "AutoPV_AccountHead",
            AutoPV_CostCentreId = "AutoPV_CostCentreId",
            MinAmount = "MinAmount",
            MaxAmount = "MaxAmount",
            PostingSing = "PostingSing",
            PreparedSing = "PreparedSing",
            CheckedSing = "CheckedSing",
            ApprovedSing = "ApprovedSing",
            PostedEmployee = "PostedEmployee",
            PreparedEmployee = "PreparedEmployee",
            CheckedEmployee = "CheckedEmployee",
            ApprovedEmployee = "ApprovedEmployee",
            RegretSendTo = "RegretSendTo",
            AccountHeadBankCash = "AccountHeadBankCash",
            ChequeBookId = "ChequeBookId",
            ChequeNumhdn = "ChequeNumhdn",
            ChequeNo = "ChequeNo",
            IsChequeFinished = "IsChequeFinished",
            ChequeType = "ChequeType",
            ChequeDate = "ChequeDate",
            ChequeRemarks = "ChequeRemarks",
            BankAmount = "BankAmount",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccVoucherInformationService {
        const baseUrl = "Transaction/AccVoucherInformation";
        function Create(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetNewVoucherNo(request: GetNewVoucherNoRequest, onSuccess?: (response: GetNewVoucherNoResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetApproverInfoByApplicant(request: GetApproverInfoByApplicantRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.AVP_InitialStep>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccVoucherInformation/Create",
            Update = "Transaction/AccVoucherInformation/Update",
            Delete = "Transaction/AccVoucherInformation/Delete",
            Retrieve = "Transaction/AccVoucherInformation/Retrieve",
            List = "Transaction/AccVoucherInformation/List",
            GetNewVoucherNo = "Transaction/AccVoucherInformation/GetNewVoucherNo",
            GetApproverInfoByApplicant = "Transaction/AccVoucherInformation/GetApproverInfoByApplicant",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface AccVoucherTemplateForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        TemplateName: Serenity.StringEditor;
        CoaDebitHeadId: Serenity.LookupEditor;
        IsDebitHeadCheque: Serenity.BooleanEditor;
        CoaCreditHeadId: Serenity.LookupEditor;
        IsCreditHeadCheque: Serenity.BooleanEditor;
        IsBillReference: Serenity.BooleanEditor;
        IsCostCenter: Serenity.BooleanEditor;
        IsSd: Serenity.BooleanEditor;
        CoaSdId: Serenity.LookupEditor;
        SdType: VoucherTemplateDrCrMappingEditor;
        SdRate: Serenity.DecimalEditor;
        IsVat: Serenity.BooleanEditor;
        CoaVatId: Serenity.LookupEditor;
        VatType: VoucherTemplateDrCrMappingEditor;
        VatRate: Serenity.DecimalEditor;
        IsTax: Serenity.BooleanEditor;
        CoaTaxId: Serenity.LookupEditor;
        TaxType: VoucherTemplateDrCrMappingEditor;
        TaxRate: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class AccVoucherTemplateForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherTemplateRow {
        Id?: number;
        VoucherTypeId?: number;
        TransactionTypeId?: number;
        TransactionMode?: string;
        TemplateName?: string;
        CoaDebitHeadId?: number;
        IsDebitHeadCheque?: boolean;
        CoaCreditHeadId?: number;
        IsCreditHeadCheque?: boolean;
        IsBillReference?: boolean;
        IsCostCenter?: boolean;
        IsSd?: boolean;
        CoaSdId?: number;
        SdType?: string;
        SdRate?: number;
        IsVat?: boolean;
        CoaVatId?: number;
        VatType?: string;
        VatRate?: number;
        IsTax?: boolean;
        CoaTaxId?: number;
        TaxType?: string;
        TaxRate?: number;
        Remarks?: string;
        VoucherTypeName?: string;
        VoucherTypeSortOrder?: number;
        TransactionTypeRemarks?: string;
        TransactionTypeSortOrder?: number;
        TransactionType?: string;
        TransactionTypeFundControlId?: number;
        TransactionTypeVoucherTypeId?: number;
        CoaDebitHeadAccountCode?: string;
        CoaDebitHeadAccountCodeCount?: number;
        CoaDebitHeadAccountGroup?: string;
        CoaDebitHeadAccountName?: string;
        CoaDebitHeadAccountNameBangla?: string;
        CoaDebitHeadCoaMapping?: string;
        CoaDebitHeadIsBillRef?: number;
        CoaDebitHeadIsBudgetHead?: number;
        CoaDebitHeadIsControlhead?: number;
        CoaDebitHeadIsCostCenterAllocate?: number;
        CoaDebitHeadLevel?: number;
        CoaDebitHeadMailingAddress?: string;
        CoaDebitHeadMailingName?: string;
        CoaDebitHeadOpeningBalance?: number;
        CoaDebitHeadRemarks?: string;
        CoaDebitHeadTaxId?: string;
        CoaDebitHeadUgcCode?: string;
        CoaDebitHeadFundControlId?: number;
        CoaDebitHeadParentAccountId?: number;
        CoaCreditHeadAccountCode?: string;
        CoaCreditHeadAccountCodeCount?: number;
        CoaCreditHeadAccountGroup?: string;
        CoaCreditHeadAccountName?: string;
        CoaCreditHeadAccountNameBangla?: string;
        CoaCreditHeadCoaMapping?: string;
        CoaCreditHeadIsBillRef?: number;
        CoaCreditHeadIsBudgetHead?: number;
        CoaCreditHeadIsControlhead?: number;
        CoaCreditHeadIsCostCenterAllocate?: number;
        CoaCreditHeadLevel?: number;
        CoaCreditHeadMailingAddress?: string;
        CoaCreditHeadMailingName?: string;
        CoaCreditHeadOpeningBalance?: number;
        CoaCreditHeadRemarks?: string;
        CoaCreditHeadTaxId?: string;
        CoaCreditHeadUgcCode?: string;
        CoaCreditHeadFundControlId?: number;
        CoaCreditHeadParentAccountId?: number;
        CoaSdAccountCode?: string;
        CoaSdAccountCodeCount?: number;
        CoaSdAccountGroup?: string;
        CoaSdAccountName?: string;
        CoaSdAccountNameBangla?: string;
        CoaSdCoaMapping?: string;
        CoaSdIsBillRef?: number;
        CoaSdIsBudgetHead?: number;
        CoaSdIsControlhead?: number;
        CoaSdIsCostCenterAllocate?: number;
        CoaSdLevel?: number;
        CoaSdMailingAddress?: string;
        CoaSdMailingName?: string;
        CoaSdOpeningBalance?: number;
        CoaSdRemarks?: string;
        CoaSdTaxId?: string;
        CoaSdUgcCode?: string;
        CoaSdFundControlId?: number;
        CoaSdParentAccountId?: number;
        CoaVatAccountCode?: string;
        CoaVatAccountCodeCount?: number;
        CoaVatAccountGroup?: string;
        CoaVatAccountName?: string;
        CoaVatAccountNameBangla?: string;
        CoaVatCoaMapping?: string;
        CoaVatIsBillRef?: number;
        CoaVatIsBudgetHead?: number;
        CoaVatIsControlhead?: number;
        CoaVatIsCostCenterAllocate?: number;
        CoaVatLevel?: number;
        CoaVatMailingAddress?: string;
        CoaVatMailingName?: string;
        CoaVatOpeningBalance?: number;
        CoaVatRemarks?: string;
        CoaVatTaxId?: string;
        CoaVatUgcCode?: string;
        CoaVatFundControlId?: number;
        CoaVatParentAccountId?: number;
        CoaTaxAccountCode?: string;
        CoaTaxAccountCodeCount?: number;
        CoaTaxAccountGroup?: string;
        CoaTaxAccountName?: string;
        CoaTaxAccountNameBangla?: string;
        CoaTaxCoaMapping?: string;
        CoaTaxIsBillRef?: number;
        CoaTaxIsBudgetHead?: number;
        CoaTaxIsControlhead?: number;
        CoaTaxIsCostCenterAllocate?: number;
        CoaTaxLevel?: number;
        CoaTaxMailingAddress?: string;
        CoaTaxMailingName?: string;
        CoaTaxOpeningBalance?: number;
        CoaTaxRemarks?: string;
        CoaTaxTaxId?: string;
        CoaTaxUgcCode?: string;
        CoaTaxFundControlId?: number;
        CoaTaxParentAccountId?: number;
        __id?: number;
        createdUserId?: string;
        updatedUserId?: string;
        createdUserDate?: string;
        updatedUserDate?: string;
        createdUserName?: string;
    }
    namespace AccVoucherTemplateRow {
        const idProperty = "Id";
        const nameProperty = "TemplateName";
        const localTextPrefix = "Transaction.AccVoucherTemplate";
        const lookupKey = "Transaction.AccVoucherTemplateRow";
        function getLookup(): Q.Lookup<AccVoucherTemplateRow>;
        const enum Fields {
            Id = "Id",
            VoucherTypeId = "VoucherTypeId",
            TransactionTypeId = "TransactionTypeId",
            TransactionMode = "TransactionMode",
            TemplateName = "TemplateName",
            CoaDebitHeadId = "CoaDebitHeadId",
            IsDebitHeadCheque = "IsDebitHeadCheque",
            CoaCreditHeadId = "CoaCreditHeadId",
            IsCreditHeadCheque = "IsCreditHeadCheque",
            IsBillReference = "IsBillReference",
            IsCostCenter = "IsCostCenter",
            IsSd = "IsSd",
            CoaSdId = "CoaSdId",
            SdType = "SdType",
            SdRate = "SdRate",
            IsVat = "IsVat",
            CoaVatId = "CoaVatId",
            VatType = "VatType",
            VatRate = "VatRate",
            IsTax = "IsTax",
            CoaTaxId = "CoaTaxId",
            TaxType = "TaxType",
            TaxRate = "TaxRate",
            Remarks = "Remarks",
            VoucherTypeName = "VoucherTypeName",
            VoucherTypeSortOrder = "VoucherTypeSortOrder",
            TransactionTypeRemarks = "TransactionTypeRemarks",
            TransactionTypeSortOrder = "TransactionTypeSortOrder",
            TransactionType = "TransactionType",
            TransactionTypeFundControlId = "TransactionTypeFundControlId",
            TransactionTypeVoucherTypeId = "TransactionTypeVoucherTypeId",
            CoaDebitHeadAccountCode = "CoaDebitHeadAccountCode",
            CoaDebitHeadAccountCodeCount = "CoaDebitHeadAccountCodeCount",
            CoaDebitHeadAccountGroup = "CoaDebitHeadAccountGroup",
            CoaDebitHeadAccountName = "CoaDebitHeadAccountName",
            CoaDebitHeadAccountNameBangla = "CoaDebitHeadAccountNameBangla",
            CoaDebitHeadCoaMapping = "CoaDebitHeadCoaMapping",
            CoaDebitHeadIsBillRef = "CoaDebitHeadIsBillRef",
            CoaDebitHeadIsBudgetHead = "CoaDebitHeadIsBudgetHead",
            CoaDebitHeadIsControlhead = "CoaDebitHeadIsControlhead",
            CoaDebitHeadIsCostCenterAllocate = "CoaDebitHeadIsCostCenterAllocate",
            CoaDebitHeadLevel = "CoaDebitHeadLevel",
            CoaDebitHeadMailingAddress = "CoaDebitHeadMailingAddress",
            CoaDebitHeadMailingName = "CoaDebitHeadMailingName",
            CoaDebitHeadOpeningBalance = "CoaDebitHeadOpeningBalance",
            CoaDebitHeadRemarks = "CoaDebitHeadRemarks",
            CoaDebitHeadTaxId = "CoaDebitHeadTaxId",
            CoaDebitHeadUgcCode = "CoaDebitHeadUgcCode",
            CoaDebitHeadFundControlId = "CoaDebitHeadFundControlId",
            CoaDebitHeadParentAccountId = "CoaDebitHeadParentAccountId",
            CoaCreditHeadAccountCode = "CoaCreditHeadAccountCode",
            CoaCreditHeadAccountCodeCount = "CoaCreditHeadAccountCodeCount",
            CoaCreditHeadAccountGroup = "CoaCreditHeadAccountGroup",
            CoaCreditHeadAccountName = "CoaCreditHeadAccountName",
            CoaCreditHeadAccountNameBangla = "CoaCreditHeadAccountNameBangla",
            CoaCreditHeadCoaMapping = "CoaCreditHeadCoaMapping",
            CoaCreditHeadIsBillRef = "CoaCreditHeadIsBillRef",
            CoaCreditHeadIsBudgetHead = "CoaCreditHeadIsBudgetHead",
            CoaCreditHeadIsControlhead = "CoaCreditHeadIsControlhead",
            CoaCreditHeadIsCostCenterAllocate = "CoaCreditHeadIsCostCenterAllocate",
            CoaCreditHeadLevel = "CoaCreditHeadLevel",
            CoaCreditHeadMailingAddress = "CoaCreditHeadMailingAddress",
            CoaCreditHeadMailingName = "CoaCreditHeadMailingName",
            CoaCreditHeadOpeningBalance = "CoaCreditHeadOpeningBalance",
            CoaCreditHeadRemarks = "CoaCreditHeadRemarks",
            CoaCreditHeadTaxId = "CoaCreditHeadTaxId",
            CoaCreditHeadUgcCode = "CoaCreditHeadUgcCode",
            CoaCreditHeadFundControlId = "CoaCreditHeadFundControlId",
            CoaCreditHeadParentAccountId = "CoaCreditHeadParentAccountId",
            CoaSdAccountCode = "CoaSdAccountCode",
            CoaSdAccountCodeCount = "CoaSdAccountCodeCount",
            CoaSdAccountGroup = "CoaSdAccountGroup",
            CoaSdAccountName = "CoaSdAccountName",
            CoaSdAccountNameBangla = "CoaSdAccountNameBangla",
            CoaSdCoaMapping = "CoaSdCoaMapping",
            CoaSdIsBillRef = "CoaSdIsBillRef",
            CoaSdIsBudgetHead = "CoaSdIsBudgetHead",
            CoaSdIsControlhead = "CoaSdIsControlhead",
            CoaSdIsCostCenterAllocate = "CoaSdIsCostCenterAllocate",
            CoaSdLevel = "CoaSdLevel",
            CoaSdMailingAddress = "CoaSdMailingAddress",
            CoaSdMailingName = "CoaSdMailingName",
            CoaSdOpeningBalance = "CoaSdOpeningBalance",
            CoaSdRemarks = "CoaSdRemarks",
            CoaSdTaxId = "CoaSdTaxId",
            CoaSdUgcCode = "CoaSdUgcCode",
            CoaSdFundControlId = "CoaSdFundControlId",
            CoaSdParentAccountId = "CoaSdParentAccountId",
            CoaVatAccountCode = "CoaVatAccountCode",
            CoaVatAccountCodeCount = "CoaVatAccountCodeCount",
            CoaVatAccountGroup = "CoaVatAccountGroup",
            CoaVatAccountName = "CoaVatAccountName",
            CoaVatAccountNameBangla = "CoaVatAccountNameBangla",
            CoaVatCoaMapping = "CoaVatCoaMapping",
            CoaVatIsBillRef = "CoaVatIsBillRef",
            CoaVatIsBudgetHead = "CoaVatIsBudgetHead",
            CoaVatIsControlhead = "CoaVatIsControlhead",
            CoaVatIsCostCenterAllocate = "CoaVatIsCostCenterAllocate",
            CoaVatLevel = "CoaVatLevel",
            CoaVatMailingAddress = "CoaVatMailingAddress",
            CoaVatMailingName = "CoaVatMailingName",
            CoaVatOpeningBalance = "CoaVatOpeningBalance",
            CoaVatRemarks = "CoaVatRemarks",
            CoaVatTaxId = "CoaVatTaxId",
            CoaVatUgcCode = "CoaVatUgcCode",
            CoaVatFundControlId = "CoaVatFundControlId",
            CoaVatParentAccountId = "CoaVatParentAccountId",
            CoaTaxAccountCode = "CoaTaxAccountCode",
            CoaTaxAccountCodeCount = "CoaTaxAccountCodeCount",
            CoaTaxAccountGroup = "CoaTaxAccountGroup",
            CoaTaxAccountName = "CoaTaxAccountName",
            CoaTaxAccountNameBangla = "CoaTaxAccountNameBangla",
            CoaTaxCoaMapping = "CoaTaxCoaMapping",
            CoaTaxIsBillRef = "CoaTaxIsBillRef",
            CoaTaxIsBudgetHead = "CoaTaxIsBudgetHead",
            CoaTaxIsControlhead = "CoaTaxIsControlhead",
            CoaTaxIsCostCenterAllocate = "CoaTaxIsCostCenterAllocate",
            CoaTaxLevel = "CoaTaxLevel",
            CoaTaxMailingAddress = "CoaTaxMailingAddress",
            CoaTaxMailingName = "CoaTaxMailingName",
            CoaTaxOpeningBalance = "CoaTaxOpeningBalance",
            CoaTaxRemarks = "CoaTaxRemarks",
            CoaTaxTaxId = "CoaTaxTaxId",
            CoaTaxUgcCode = "CoaTaxUgcCode",
            CoaTaxFundControlId = "CoaTaxFundControlId",
            CoaTaxParentAccountId = "CoaTaxParentAccountId",
            __id = "__id",
            createdUserId = "createdUserId",
            updatedUserId = "updatedUserId",
            createdUserDate = "createdUserDate",
            updatedUserDate = "updatedUserDate",
            createdUserName = "createdUserName",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace AccVoucherTemplateService {
        const baseUrl = "Transaction/AccVoucherTemplate";
        function Create(request: Serenity.SaveRequest<AccVoucherTemplateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherTemplateRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherTemplateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherTemplateRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/AccVoucherTemplate/Create",
            Update = "Transaction/AccVoucherTemplate/Update",
            Delete = "Transaction/AccVoucherTemplate/Delete",
            Retrieve = "Transaction/AccVoucherTemplate/Retrieve",
            List = "Transaction/AccVoucherTemplate/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface AccVoucherTemplateVoucherIssueForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        TransactionMode: COAMappingEditor;
        TemplateName: TemplateNameEditor;
        CoaDebitHeadId: Serenity.LookupEditor;
        IsDebitHeadCheque: Serenity.BooleanEditor;
        DebitHeadChequeId: Serenity.LookupEditor;
        CoaCreditHeadId: Serenity.LookupEditor;
        IsCreditHeadCheque: Serenity.BooleanEditor;
        CreditHeadChequeId: Serenity.LookupEditor;
        IsBillReference: Serenity.BooleanEditor;
        BillReferenceNo: Serenity.StringEditor;
        IsCostCenter: Serenity.BooleanEditor;
        CostCenterId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        VoucherDate: Serenity.DateEditor;
        Remarks: Serenity.TextAreaEditor;
        IsSd: Serenity.BooleanEditor;
        CoaSdId: Serenity.LookupEditor;
        SdType: VoucherTemplateDrCrMappingEditor;
        SdRate: Serenity.DecimalEditor;
        SdAmount: Serenity.DecimalEditor;
        IsVat: Serenity.BooleanEditor;
        CoaVatId: Serenity.LookupEditor;
        VatType: VoucherTemplateDrCrMappingEditor;
        VatRate: Serenity.DecimalEditor;
        VatAmount: Serenity.DecimalEditor;
        IsTax: Serenity.BooleanEditor;
        CoaTaxId: Serenity.LookupEditor;
        TaxType: VoucherTemplateDrCrMappingEditor;
        TaxRate: Serenity.DecimalEditor;
        TaxAmount: Serenity.DecimalEditor;
    }
    class AccVoucherTemplateVoucherIssueForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    interface ApvApplicationInformationRow {
        Id?: number;
        ModuleId?: number;
        ApprovalProcessId?: number;
        ApplicationId?: number;
        IsOnlineApplication?: boolean;
        ApprovalStepId?: number;
        ApproverId?: number;
        ApprovalStatusId?: number;
        ApproverComments?: string;
        IUser?: string;
        IDate?: string;
        EUser?: string;
        EDate?: string;
        ForwordBy?: string;
        Status?: string;
        EmploymentInfoFullName?: string;
        ApproverCode?: string;
    }
    namespace ApvApplicationInformationRow {
        const idProperty = "Id";
        const nameProperty = "ApproverComments";
        const localTextPrefix = "Transaction.ApvApplicationInformation";
        const enum Fields {
            Id = "Id",
            ModuleId = "ModuleId",
            ApprovalProcessId = "ApprovalProcessId",
            ApplicationId = "ApplicationId",
            IsOnlineApplication = "IsOnlineApplication",
            ApprovalStepId = "ApprovalStepId",
            ApproverId = "ApproverId",
            ApprovalStatusId = "ApprovalStatusId",
            ApproverComments = "ApproverComments",
            IUser = "IUser",
            IDate = "IDate",
            EUser = "EUser",
            EDate = "EDate",
            ForwordBy = "ForwordBy",
            Status = "Status",
            EmploymentInfoFullName = "EmploymentInfoFullName",
            ApproverCode = "ApproverCode",
        }
    }
}
declare namespace VistaGL.Transaction {
    namespace ApvApplicationInformationService {
        const baseUrl = "Transaction/ApvApplicationInformation";
        function Create(request: Serenity.SaveRequest<ApvApplicationInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ApvApplicationInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ApvApplicationInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ApvApplicationInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/ApvApplicationInformation/Create",
            Update = "Transaction/ApvApplicationInformation/Update",
            Delete = "Transaction/ApvApplicationInformation/Delete",
            Retrieve = "Transaction/ApvApplicationInformation/Retrieve",
            List = "Transaction/ApvApplicationInformation/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    namespace BankReconciliationVoucherService {
        const baseUrl = "Transaction/BankReconciliationVoucher";
        function Create(request: Serenity.SaveRequest<AccVoucherDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/BankReconciliationVoucher/Create",
            Update = "Transaction/BankReconciliationVoucher/Update",
            Delete = "Transaction/BankReconciliationVoucher/Delete",
            Retrieve = "Transaction/BankReconciliationVoucher/Retrieve",
            List = "Transaction/BankReconciliationVoucher/List",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface BudgetCreationApprovalForm {
        FinancialYearName: Serenity.StringEditor;
        DepartmentName: Serenity.StringEditor;
    }
    class BudgetCreationApprovalForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    namespace BudgetCreationApprovalService {
        const baseUrl = "Transaction/BudgetCreationApproval";
        function Create(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccBudgetForDepartmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccBudgetForDepartmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/BudgetCreationApproval/Create",
            Update = "Transaction/BudgetCreationApproval/Update",
            Delete = "Transaction/BudgetCreationApproval/Delete",
            Retrieve = "Transaction/BudgetCreationApproval/Retrieve",
            List = "Transaction/BudgetCreationApproval/List",
        }
    }
}
declare namespace VistaGL.Transaction {
    interface BulkActionRequest extends Serenity.ServiceRequest {
        IDs?: number[];
    }
}
declare namespace VistaGL.Transaction {
    interface CreditVoucherParametersRequest extends Serenity.ServiceRequest {
        MoneyReceiptIds?: number[];
        Narration?: string;
        VoucherDate?: string;
        ReceiveFrom?: string;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface AVP_InitialStep {
        Id?: number;
        FullName?: string;
        InitialStepId?: number;
        StepName?: string;
        ApproverTypeName?: string;
        MinAmount?: number;
        MaxAmount?: number;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface BudgetApproverList {
        Id?: number;
        EmpId?: string;
        LookupText?: string;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface BudgetApproverListRequest extends Serenity.ListRequest {
        ZoneId?: number;
        DepartmentId?: number;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface eNextApprover {
        Id?: number;
        FullName?: string;
        ApproverTypeName?: string;
        NextStepId?: number;
        StepTypeId?: number;
        StepTypeName?: string;
        RequiredActionId?: number;
        ApplicationId?: number;
        ApplicantId?: number;
        CurrentRecommenderApproverId?: number;
        MinAmount?: number;
        MaxAmount?: number;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface eNextApproverListRequest extends Serenity.ListRequest {
        Id?: number;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface FinancialYearNames {
        CurrentYearName?: string;
        PreviousYearName?: string;
        NextYearName?: string;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface FinancialYearNamesListRequest extends Serenity.ListRequest {
        Id?: number;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface GetNewMoneyReceiptNoRequest extends Serenity.ServiceRequest {
        FundControlId?: number;
        ZoneId?: number;
    }
}
declare namespace VistaGL.Transaction.Repositories {
    interface GetNewMoneyReceiptResponse extends Serenity.ServiceResponse {
        MoneyReceiptNo?: string;
        MoneyReceiptNumber?: string;
    }
}
declare namespace VistaGL.Transaction {
    interface selectCalculationForm {
        Type: VoucherTemplateDrCrMappingEditor;
        Amount: Serenity.DecimalEditor;
        Rate: Serenity.DecimalEditor;
    }
    class selectCalculationForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface TransferVoucherForm {
        TransferType: Serenity.RadioButtonEditor;
        VoucherTypeId: Serenity.LookupEditor;
        PostingFinancialYearId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        VoucherNo: Serenity.StringEditor;
        VoucherDate: Serenity.DateEditor;
        TransactionMode: Serenity.StringEditor;
        FileNo: Serenity.StringEditor;
        PageNo: Serenity.StringEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        AccountHeadFrom: Serenity.LookupEditor;
        AccountHeadTo: Serenity.LookupEditor;
        TransferAmount: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        DDescription: Serenity.TextAreaEditor;
        AddtoGrid: Serenity.StringEditor;
        VoucherDetails: TransferDetailesEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        PostedBy: Serenity.StringEditor;
        PostingDate: Serenity.DateEditor;
    }
    class TransferVoucherForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    interface VoucherApprovalForm {
        approveStatus: Serenity.EnumEditor;
        ApproverId: GetApproverInfoByApplicantVoucherEditor;
        postingSendTo: Serenity.LookupEditor;
        RegretSendTo: Serenity.LookupEditor;
        ApprovalAction: Serenity.StringEditor;
        ApprovalComments: Serenity.TextAreaEditor;
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        VoucherDate: Serenity.DateEditor;
        TransactionMode: COAMappingEditor;
        VoucherNo: Serenity.StringEditor;
        PaytoOrReciveFrom: Serenity.StringEditor;
        ChequeRegisterChequeNo: Serenity.IntegerEditor;
        ChequeRegisterChequeDate: Serenity.DateEditor;
        AutoJVVoucherNo: Serenity.StringEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        VoucherDetails: AccVoucherDetailsEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        PostedBy: Serenity.StringEditor;
        PostingDate: Serenity.DateEditor;
        PostToLedger: Serenity.IntegerEditor;
        EmpId: Serenity.IntegerEditor;
        FileName: Serenity.MultipleImageUploadEditor;
        ApplicationInformationHistory: VoucherApprovalHistoryEditor;
    }
    class VoucherApprovalForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace VistaGL.Transaction {
    namespace VoucherApprovalService {
        const baseUrl = "Transaction/VoucherApproval";
        function Create(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function IsVoucherApprover(request: Serenity.ListRequest, onSuccess?: (response: CheckIsApproverResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetNextApprover(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetAmountByApprover(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetPostingSendTo(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetRegretList(request: Transaction.Repositories.eNextApproverListRequest, onSuccess?: (response: Serenity.ListResponse<Transaction.Repositories.eNextApprover>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/VoucherApproval/Create",
            Update = "Transaction/VoucherApproval/Update",
            Delete = "Transaction/VoucherApproval/Delete",
            Retrieve = "Transaction/VoucherApproval/Retrieve",
            List = "Transaction/VoucherApproval/List",
            IsVoucherApprover = "Transaction/VoucherApproval/IsVoucherApprover",
            GetNextApprover = "Transaction/VoucherApproval/GetNextApprover",
            GetAmountByApprover = "Transaction/VoucherApproval/GetAmountByApprover",
            GetPostingSendTo = "Transaction/VoucherApproval/GetPostingSendTo",
            GetRegretList = "Transaction/VoucherApproval/GetRegretList",
        }
    }
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
}
declare namespace VistaGL.Transaction {
    namespace VoucherPostingService {
        const baseUrl = "Transaction/VoucherPosting";
        function Create(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AccVoucherInformationRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AccVoucherInformationRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function BulkAction(request: BulkActionRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Transaction/VoucherPosting/Create",
            Update = "Transaction/VoucherPosting/Update",
            Delete = "Transaction/VoucherPosting/Delete",
            Retrieve = "Transaction/VoucherPosting/Retrieve",
            List = "Transaction/VoucherPosting/List",
            BulkAction = "Transaction/VoucherPosting/BulkAction",
        }
    }
}
declare namespace VistaGL {
    enum VoucherType {
        Payment_Voucher = 1,
        Receipt_Voucher = 2,
        Journal_Voucher = 3,
        Transfer_Voucher = 4,
    }
}
declare namespace VistaGL {
    class EntityDialogBase<TEntity, TOptions> extends _Ext.DialogBase<TEntity, TOptions> {
    }
}
declare namespace VistaGL {
    class EntityGridBase<TItem, TOptions> extends _Ext.GridBase<TItem, TOptions> {
    }
}
declare namespace Slick {
}
declare namespace VistaGL {
    class EntityGridBaseNew<TItem, TOptions> extends Serenity.EntityGrid<TItem, TOptions> {
        isAutosized: boolean;
        constructor(container: JQuery, options?: TOptions);
        autoColumnSizePlugin: any;
        protected createSlickGrid(): Slick.Grid;
        protected markupReady(): void;
        resizeAllCulumn(): void;
        protected getSlickOptions(): Slick.GridOptions;
        protected getButtons(): Serenity.ToolButton[];
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected onInlineActionClick(target: JQuery, recordId: any, item: TItem): void;
        protected onViewProcessData(response: Serenity.ListResponse<TItem>): Serenity.ListResponse<TItem>;
    }
}
declare namespace VistaGL {
    class GridEditorBase<TEntity> extends _Ext.GridEditorBase<TEntity> {
    }
}
declare namespace VistaGL {
    class GridEditorDialog<TEntity> extends _Ext.EditorDialogBase<TEntity> {
    }
}
declare namespace q {
    function groupBy(xs: any[], key: any): any;
    function sortBy<T>(xs: T[], key: any): T[];
    function sortByDesc<T>(xs: T[], key: any): T[];
}
declare namespace q {
    function nextTick(date: any): Date;
    function addMinutes(date: Date, minutes: number): Date;
    function addHours(date: Date, hours: number): Date;
    function getHours(fromDate: Date, toDate: Date): number;
    function getDays24HourPulse(fromDate: Date, toDate: Date): number;
    function getDays(pFromDate: Date, pToDate: Date): number;
    function getMonths(fromDate: Date, toDate: Date): number;
    function getCalenderMonths(fromDate: Date, toDate: Date): number;
    function getCalenderMonthsCeil(fromDate: Date, toDate: Date): number;
    function addDays(date: Date, days: number): Date;
    function addMonths(date: Date, months: number): Date;
    function addYear(date: Date, years: number): Date;
    function getPeriods(fromDate: Date, toDate: Date, periodUnit: _Ext.TimeUoM): number;
    function addPeriod(date: Date, period: number, periodUnit: _Ext.TimeUoM): Date;
    function formatISODate(date: Date): string;
    function bindDateTimeEditorChange(editor: any, handler: any): void;
    function initDateRangeEditor(fromDateEditor: Serenity.DateEditor, toDateEditor: Serenity.DateEditor, onChangeHandler?: (e: JQueryEventObject) => void): void;
    function initDateTimeRangeEditor(fromDateTimeEditor: _Ext.DateTimePickerEditor, toDateTimeEditor: _Ext.DateTimePickerEditor, onChangeHandler?: (e: JQueryEventObject) => void): void;
    function formatDate(d: Date | string, format?: string): string;
}
declare namespace q {
    function initDetailEditor(dialog: _Ext.DialogBase<any, any>, editor: _Ext.GridEditorBase<any>, options?: ExtGridEditorOptions): void;
    function setGridEditorHeight(editor: JQuery, heightInPx: number): void;
    function addNotificationIcon(editor: Serenity.StringEditor, isSuccess: boolean): void;
    function setEditorLabel(editor: Serenity.Widget<any>, value: string): void;
    function hideEditorLabel(editor: Serenity.Widget<any>): void;
    function setEditorCategoryLabel(editor: Serenity.Widget<any>, value: string): void;
    function hideEditorCategory(editor: Serenity.Widget<any>, value?: boolean): void;
    function hideCategories(containerElement: JQuery, value?: boolean): void;
    function hideFields(containerElement: JQuery, value?: boolean): void;
    function hideFieldsAndCategories(containerElement: JQuery, value?: boolean): void;
    function hideField(editor: Serenity.Widget<any>, value?: boolean): void;
    function showField(editor: Serenity.Widget<any>, value?: boolean): void;
    function showFieldAndCategory(editor: Serenity.Widget<any>, value?: boolean): void;
    function hideEditorTab(editor: Serenity.Widget<any>, value?: boolean): void;
    function readOnlyEditorTab(editor: Serenity.Widget<any>, value?: boolean): void;
    function readOnlyEditorCategory(editor: Serenity.Widget<any>, value?: boolean): void;
    function readonlyEditorCategory($editor: JQuery, value?: boolean): void;
    function readOnlyEditor(editor: Serenity.Widget<any>, value?: boolean): void;
    function readonlyEditor($editor: JQuery, value?: boolean): void;
    function moveEditorFromTab(editor: Serenity.Widget<any>, toElement: JQuery, isPrepend?: boolean): void;
    function moveEditorCategoryFromTab(editor: Serenity.Widget<any>, toElement: JQuery, isPrepend?: boolean): void;
    function selectEditorTab(editor: Serenity.Widget<any>): void;
    function getSelectedRow<TRow>(e: JQueryEventObject): TRow;
}
declare namespace q {
    function getEnumText(enumKey: any, value: any): string;
    function getEnumValues(enumType: any): string[];
    function getEnumKeys(enumType: any): string[];
}
declare namespace q {
    function isCosmicThemeApplied(): boolean;
    function getSelectedLanguage(): string;
    function formatDecimal(value: any): string;
    function formatInt(value: any): string;
    function ToNumber(value: any): any;
    function ToBool(value: any): boolean;
    function getRandomColor(hexLetters: any): string;
}
declare var isPageRefreshRequired: boolean;
declare namespace q {
    var queryString: {};
    var jsPDFHeaderImageData: string;
    var jsPDFHeaderTitle: string;
    var useSerenityInlineEditors: boolean;
    var DefaultMainGridOptions: ExtGridOptions;
    var DefaultEditorGridOptions: ExtGridOptions;
    var DefaultEntityDialogOptions: ExtDialogOptions;
    var DefaultEditorDialogOptions: ExtDialogOptions;
    var fiscalYearMonths: number[];
}
declare namespace _Ext {
    class AuditLogActionTypeFormatter implements Slick.Formatter {
        static format(ctx: Slick.FormatterContext): string;
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace _Ext {
    class AuditLogDialog extends DialogBase<AuditLogRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AuditLogForm;
        protected afterLoadEntity(): void;
    }
}
declare namespace _Ext {
    class AuditLogGrid extends GridBase<AuditLogRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AuditLogDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare var jsondiffpatch: any;
declare namespace _Ext {
    class AuditLogViewer {
        el: string;
        data: {
            entityVersions: any[];
        };
        entity: any;
        entityId: any;
        constructor(el: string, entityVersions: AuditLogRow[]);
        mounted: () => void;
        computed: {
            test: () => string;
        };
        filters: {
            filterByYardId: () => any[];
        };
        methods: {
            showDiff: (versionInfo: AuditLogRow) => void;
            getDiff: (versionInfo: AuditLogRow) => any;
        };
        destroyed(): void;
    }
}
declare namespace _Ext {
    class AuditLogViewerDialog extends Serenity.TemplatedDialog<any> {
        request: AuditLogViewerRequest;
        constructor(request: AuditLogViewerRequest);
        protected getTemplateName(): string;
    }
}
declare namespace _Ext {
    class ReplaceRowDialog extends _Ext.DialogBase<any, any> {
        request: ReplaceRowRequest;
        entityList: Array<any>;
        protected getFormKey(): string;
        protected form: ReplaceRowForm;
        constructor(request: ReplaceRowRequest, entityList: Array<any>);
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare var Vue: any;
declare namespace _Ext.DevTools {
    class SergenPanel extends Serenity.Widget<any> {
        constructor(container: JQuery);
    }
}
declare namespace _Ext {
    class AutoCompleteEditor extends Serenity.StringEditor {
        constructor(input: JQuery, options: AutoCompleteOptions);
        protected bindAutoComplete(input: any): void;
    }
    interface AutoCompleteOptions {
        lookupKey: string;
        sourceArray: string[];
        sourceCSV: string;
        minSearchLength: number;
    }
}
declare namespace _Ext {
    class ColorEditor extends Serenity.TemplatedWidget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        protected getTemplate(): string;
        constructor(container: JQuery);
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
    }
}
declare namespace _Ext {
    class DateTimePickerEditor extends Serenity.Widget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue, Serenity.IReadOnly {
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        constructor(container: JQuery);
        value: string;
        valueAsDate: Date;
        get_readOnly(): boolean;
        set_readOnly(value: boolean): void;
        set_minDate(date: Date): void;
        set_maxDate(date: Date): void;
        set_minDateTime(date: Date): void;
        set_maxDateTime(date: Date): void;
    }
}
declare namespace _Ext {
    class EmptyLookupEditor extends Serenity.Select2Editor<any, any> {
        setSelect2Items(items: Serenity.Select2Item[]): void;
        setLookupItems(lookup: Q.Lookup<any>): void;
    }
}
declare namespace _Ext {
    class HardCodedLookupEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery, options: HardCodedLookupEditorOptions);
        protected getSelect2Options(): Select2Options;
    }
    interface HardCodedLookupEditorOptions {
        sourceArray: string[];
        sourceCSV: string;
        allowOtherValue: boolean;
    }
}
declare namespace _Ext {
    class HtmlTemplateEditor extends Serenity.HtmlContentEditor {
        constructor(textArea: JQuery, opt?: HtmlTemplateEditorOptions);
        protected getConfig(): Serenity.CKEditorConfig;
    }
    interface HtmlTemplateEditorOptions extends Serenity.HtmlContentEditorOptions {
        cols?: any;
        rows?: any;
        placeholders?: any;
    }
}
declare namespace _Ext {
    class StaticTextBlock extends Serenity.Widget<StaticTextBlockOptions> implements Serenity.ISetEditValue {
        private _value;
        constructor(container: JQuery, options: StaticTextBlockOptions);
        private updateElementContent();
        /**
         * By implementing ISetEditValue interface, we allow this editor to display its field value.
         * But only do this when our text content is not explicitly set in options
         */
        setEditValue(source: any, property: Serenity.PropertyItem): void;
        value: string;
    }
    interface StaticTextBlockOptions {
        text: string;
        isHtml: boolean;
        isLocalText: boolean;
        hideLabel: boolean;
    }
}
declare namespace _Ext {
    class GridItemPickerEditor extends Serenity.TemplatedWidget<GridItemPickerEditorOptions> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        protected getTemplate(): string;
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        constructor(container: JQuery, options: GridItemPickerEditorOptions);
        protected: any;
        value: string;
        text: string;
    }
    interface GridItemPickerEditorOptions {
        gridType: any;
        nameFieldInThisRow?: string;
        rowType?: string;
        nameFieldInGridRow?: string;
        multiple: boolean;
        preSelectedKeys?: any[];
    }
}
declare namespace _Ext {
    class CardViewMixin<TItem> {
        private options;
        private dataGrid;
        private getId;
        private vm;
        private cardContainer;
        viewType: ('list' | 'card');
        constructor(options: CardViewMixinOptions<TItem>);
        switchView(viewType: ('grid' | 'card')): void;
        updateCardItems(): void;
        resizeCardView(): void;
    }
    interface CardViewMixinOptions<TItem> {
        grid: Serenity.DataGrid<TItem, any>;
        containerTemplate?: string;
        itemTemplate?: string;
        methods?: any;
        itemCssClass?: string;
        defaultViewType?: ('list' | 'card');
        itemsCssStyle?: string;
        itemCssStyle?: string;
    }
}
declare namespace _Ext {
    /**
     * A mixin that can be applied to a DataGrid for excel style filtering functionality
     */
    class HeaderFiltersMixin<TItem> {
        private options;
        private dataGrid;
        constructor(options: HeaderFiltersMixinOptions<TItem>);
    }
    interface HeaderFiltersMixinOptions<TItem> {
        grid: Serenity.DataGrid<TItem, any>;
    }
}
declare namespace _Ext {
    /**
     * A mixin that can be applied to a DataGrid for tree functionality
     */
    class TreeGridMixin<TItem> {
        private options;
        private dataGrid;
        private getId;
        constructor(options: TreeGridMixinOptions<TItem>);
        /**
         * Expands / collapses all rows in a grid automatically
         */
        toggleAll(): void;
        expandAll(): void;
        collapsedAll(): void;
        /**
         * Reorders a set of items so that parents comes before their children.
         * This method is required for proper tree ordering, as it is not so easy to perform with SQL.
         * @param items list of items to be ordered
         * @param getId a delegate to get ID of a record (must return same ID with grid identity field)
         * @param getParentId a delegate to get parent ID of a record
         */
        static applyTreeOrdering<TItem>(items: TItem[], getId: (item: TItem) => any, getParentId: (item: TItem) => any): TItem[];
        static filterById<TItem>(item: TItem, view: Slick.RemoteView<TItem>, idProperty: any, getParentId: (x: TItem) => any): boolean;
        static treeToggle<TItem>(getView: () => Slick.RemoteView<TItem>, getId: (x: TItem) => any, formatter: Slick.Format): Slick.Format;
        static toggleClick<TItem>(e: JQueryEventObject, row: number, cell: number, view: Slick.RemoteView<TItem>, getId: (x: TItem) => any): void;
    }
    interface TreeGridMixinOptions<TItem> {
        grid: Serenity.DataGrid<TItem, any>;
        idField?: string;
        getParentId: (item: TItem) => any;
        toggleField: string;
        initialCollapse?: () => boolean;
    }
}
declare namespace _Ext {
    interface ExcelExportOptions {
        grid: Serenity.DataGrid<any, any>;
        service: string;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
    }
    namespace ExcelExportHelper {
        function createToolButton(options: ExcelExportOptions): Serenity.ToolButton;
    }
}
declare var jsPDF: any;
declare namespace _Ext {
    interface PdfExportOptions {
        grid: Serenity.DataGrid<any, any>;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
        reportTitle?: string;
        titleTop?: number;
        titleFontSize?: number;
        fileName?: string;
        pageNumbers?: boolean;
        columnTitles?: {
            [key: string]: string;
        };
        tableOptions?: jsPDF.AutoTableOptions;
        output?: string;
        autoPrint?: boolean;
    }
    namespace PdfExportHelper {
        function exportToPdf(options: PdfExportOptions): void;
        function createToolButton(options: PdfExportOptions): Serenity.ToolButton;
    }
}
declare namespace Slick {
    interface RemoteView<TEntity> {
        getGroups(): Slick.Group<TEntity>[];
        getGrouping(): Slick.GroupInfo<TEntity>[];
    }
}
declare namespace _Ext {
    interface ReportExecuteOptions {
        reportKey: string;
        download?: boolean;
        extension?: 'pdf' | 'htm' | 'html' | 'xlsx' | 'docx';
        getParams?: () => any;
        params?: {
            [key: string]: any;
        };
        target?: string;
    }
    interface ReportButtonOptions extends ReportExecuteOptions {
        title?: string;
        cssClass?: string;
        icon?: string;
    }
    namespace ReportHelper {
        function createToolButton(options: ReportButtonOptions): Serenity.ToolButton;
        function execute(options: ReportExecuteOptions): void;
    }
}
declare namespace _Ext.DialogUtils {
    function pendingChangesConfirmation(element: JQuery, hasPendingChanges: () => boolean): void;
}
declare function loadScriptAsync(url: any, callback: any): void;
declare function loadScript(url: any): void;
declare function usingVuejs(): void;
declare function includeBootstrapColorPickerCss(): void;
declare function usingBootstrapColorPicker(): void;
declare function includeJqueryUITimepickerAddonCss(): void;
declare function usingJqueryUITimepickerAddon(): void;
declare function usingBabylonjs(): void;
declare function usingChartjs(): void;
declare function includeCustomMarkerCss(): void;
declare function usingCustomMarker(): void;
declare function includeGoogleMap(callback?: Function, callbackFullName?: string): void;
declare function includeMarkerWithLabel(): void;
declare function includeVisCss(): void;
declare function usingVisjs(): void;
declare function usingJsonDiffPatch(): void;
declare function usingSlickGridEditors(): void;
declare function usingSlickAutoColumnSize(): void;
declare function usingSlickHeaderFilters(): void;
declare namespace VistaGL.Administration {
    class LanguageDialog extends EntityDialogBase<LanguageRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: LanguageForm;
    }
}
declare namespace VistaGL.Administration {
    class LanguageGrid extends EntityGridBase<LanguageRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LanguageDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): LanguageRow.Fields[];
    }
}
declare namespace VistaGL.Administration {
    class RoleDialog extends EntityDialogBase<RoleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: RoleForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
    }
}
declare namespace VistaGL.Administration {
    class RoleGrid extends EntityGridBase<RoleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof RoleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): RoleRow.Fields[];
    }
}
declare namespace VistaGL.Administration {
    class RolePermissionDialog extends Serenity.TemplatedDialog<RolePermissionDialogOptions> {
        private permissions;
        constructor(opt: RolePermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface RolePermissionDialogOptions {
        roleID?: number;
        title?: string;
    }
}
declare namespace VistaGL.Administration {
    class TranslationGrid extends EntityGridBase<TranslationItem, any> {
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private hasChanges;
        private searchText;
        private sourceLanguage;
        private targetLanguage;
        private targetLanguageKey;
        constructor(container: JQuery);
        protected onClick(e: JQueryEventObject, row: number, cell: number): any;
        protected getColumns(): Slick.Column[];
        protected createToolbarExtensions(): void;
        protected saveChanges(language: string): RSVP.Promise<any>;
        protected onViewSubmit(): boolean;
        protected getButtons(): Serenity.ToolButton[];
        protected createQuickSearchInput(): void;
        protected onViewFilter(item: TranslationItem): boolean;
        protected usePager(): boolean;
    }
}
declare namespace VistaGL.Administration {
    class UserDialog extends EntityDialogBase<UserRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: UserForm;
        constructor();
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
        protected afterLoadEntity(): void;
    }
}
declare namespace VistaGL.Administration {
    class UserGrid extends EntityGridBase<UserRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDialog;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): UserRow.Fields[];
    }
}
declare namespace VistaGL.Authorization {
    let userDefinition: ScriptUserDefinition;
    function hasPermission(permissionKey: string): boolean;
}
declare namespace VistaGL.Administration {
    class PermissionCheckEditor extends Serenity.DataGrid<PermissionCheckItem, PermissionCheckEditorOptions> {
        protected getIdProperty(): string;
        private searchText;
        private byParentKey;
        private rolePermissions;
        constructor(container: JQuery, opt: PermissionCheckEditorOptions);
        private getItemGrantRevokeClass(item, grant);
        private getItemEffectiveClass(item);
        protected getColumns(): Slick.Column[];
        setItems(items: PermissionCheckItem[]): void;
        protected onViewSubmit(): boolean;
        protected onViewFilter(item: PermissionCheckItem): boolean;
        private matchContains(item);
        private getDescendants(item, excludeGroups);
        protected onClick(e: any, row: any, cell: any): void;
        private getParentKey(key);
        protected getButtons(): Serenity.ToolButton[];
        protected createToolbarExtensions(): void;
        private getSortedGroupAndPermissionKeys(titleByKey);
        get_value(): UserPermissionRow[];
        set_value(value: UserPermissionRow[]): void;
        get_rolePermissions(): string[];
        set_rolePermissions(value: string[]): void;
    }
    interface PermissionCheckEditorOptions {
        showRevoke?: boolean;
    }
    interface PermissionCheckItem {
        ParentKey?: string;
        Key?: string;
        Title?: string;
        IsGroup?: boolean;
        GrantRevoke?: boolean;
    }
}
declare namespace VistaGL.Administration {
    class UserPermissionDialog extends Serenity.TemplatedDialog<UserPermissionDialogOptions> {
        private permissions;
        constructor(opt: UserPermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserPermissionDialogOptions {
        userID?: number;
        username?: string;
    }
}
declare namespace VistaGL.Administration {
    class RoleCheckEditor extends Serenity.CheckTreeEditor<Serenity.CheckTreeItem<any>, any> {
        private searchText;
        constructor(div: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): any[];
        protected getTreeItems(): Serenity.CheckTreeItem<any>[];
        protected onViewFilter(item: any): boolean;
    }
}
declare namespace VistaGL.Administration {
    class UserRoleDialog extends Serenity.TemplatedDialog<UserRoleDialogOptions> {
        private permissions;
        constructor(opt: UserRoleDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserRoleDialogOptions {
        userID: number;
        username: string;
    }
}
declare namespace VistaGL {
    class ReconciliationEditor extends Serenity.Select2Editor<any, any> {
        constructor(hidden: JQuery);
    }
    class COAMappingEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class ChequeTypeMappingEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class RecChequeTypeMappingEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class VoucherTemplateDrCrMappingEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class TemplateNameEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class BudgetTypeEditorDDL extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class BillTypeEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class BRTransactionTypeEditorDDL extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class GetRecommenderInfoByApplicantVoucherEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class GetApproverInfoByApplicantVoucherEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class ChequeBookEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class TrueFalseEditor extends Serenity.Select2Editor<Serenity.SelectEditorOptions, Serenity.Select2Item> {
        constructor(hidden: JQuery, opt: Serenity.SelectEditorOptions);
    }
    class DebitCreditEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
    class ApprovalStatusEditor extends Serenity.Select2Editor<Serenity.SelectEditorOptions, Serenity.Select2Item> {
        constructor(hidden: JQuery, opt: Serenity.SelectEditorOptions);
    }
    class AccHeadTypeMappingEditor extends Serenity.Select2Editor<any, any> {
        constructor(hidden: JQuery);
    }
    class FinancialReportEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare var multiplicationFactor: number;
declare const containerWidth = 8;
declare const containerHeight = 8.6;
declare namespace VistaGL.ScriptInitialization {
}
declare class VoucherUtil {
    constructor();
    static currencyToWords(s: any): string;
    static newVoucherNumberFactory(voucherConfiguration: any, transactionTypeId: any, voucherDate: any, financialYearId: any, fundControlId: any, zoneId: any, bankAccId: any, _callback: any): void;
    static convertNumber(num: any): string;
}
declare namespace VistaGL {
    class BasicProgressDialog extends Serenity.TemplatedDialog<any> {
        constructor();
        cancelled: boolean;
        max: number;
        value: number;
        title: string;
        cancelTitle: string;
        getDialogOptions(): JQueryUI.DialogOptions;
        initDialog(): void;
        getTemplate(): string;
    }
}
declare namespace VistaGL.Common {
    class BulkServiceAction {
        protected keys: string[];
        protected queue: string[];
        protected queueIndex: number;
        protected progressDialog: BasicProgressDialog;
        protected pendingRequests: number;
        protected completedRequests: number;
        protected errorByKey: Q.Dictionary<Serenity.ServiceError>;
        private successCount;
        private errorCount;
        done: () => void;
        protected createProgressDialog(): void;
        protected getConfirmationFormat(): string;
        protected getConfirmationMessage(targetCount: any): string;
        protected confirm(targetCount: any, action: any): void;
        protected getNothingToProcessMessage(): string;
        protected nothingToProcess(): void;
        protected getParallelRequests(): number;
        protected getBatchSize(): number;
        protected startParallelExecution(): void;
        protected serviceCallCleanup(): void;
        protected executeForBatch(batch: string[]): void;
        protected executeNextBatch(): void;
        protected getAllHadErrorsFormat(): string;
        protected showAllHadErrors(): void;
        protected getSomeHadErrorsFormat(): string;
        protected showSomeHadErrors(): void;
        protected getAllSuccessFormat(): string;
        protected showAllSuccess(): void;
        protected showResults(): void;
        execute(keys: string[]): void;
        get_successCount(): any;
        set_successCount(value: number): void;
        get_errorCount(): any;
        set_errorCount(value: number): void;
    }
}
declare namespace VistaGL.DialogUtils {
    function pendingChangesConfirmation(element: JQuery, hasPendingChanges: () => boolean): void;
}
declare namespace VistaGL.Common {
    interface ExcelExportOptions {
        grid: Serenity.DataGrid<any, any>;
        service: string;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
    }
    namespace ExcelExportHelper {
        function createToolButton(options: ExcelExportOptions): Serenity.ToolButton;
    }
}
declare namespace VistaGL.LanguageList {
    function getValue(): string[][];
}
declare namespace VistaGL.Common {
    interface ReportButtonOptions {
        title?: string;
        cssClass?: string;
        icon?: string;
        download?: boolean;
        reportKey: string;
        extension?: string;
        getParams?: () => any;
        target?: string;
    }
    namespace ReportHelper {
        function createToolButton(options: ReportButtonOptions): Serenity.ToolButton;
    }
}
declare namespace VistaGL.Common {
    class LanguageSelection extends Serenity.Widget<any> {
        constructor(select: JQuery, currentLanguage: string);
    }
}
declare namespace VistaGL.Common {
    class SidebarSearch extends Serenity.Widget<any> {
        private menuUL;
        constructor(input: JQuery, menuUL: JQuery);
        protected updateMatchFlags(text: string): void;
    }
}
declare namespace VistaGL.Common {
    class ThemeSelection extends Serenity.Widget<any> {
        constructor(select: JQuery);
        protected getCurrentTheme(): string;
    }
}
declare var jsPDF: any;
declare namespace VistaGL.Common {
    interface PdfExportOptions {
        grid: Serenity.DataGrid<any, any>;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
        reportTitle?: string;
        titleTop?: number;
        titleFontSize?: number;
        fileName?: string;
        pageNumbers?: boolean;
        columnTitles?: {
            [key: string]: string;
        };
        tableOptions?: jsPDF.AutoTableOptions;
        output?: string;
        autoPrint?: boolean;
    }
    namespace PdfExportHelper {
        function exportToPdf(options: PdfExportOptions): void;
        function createToolButton(options: PdfExportOptions): Serenity.ToolButton;
    }
}
declare namespace Slick {
    interface RemoteView<TEntity> {
        getGroups(): Slick.Group<TEntity>[];
        getGrouping(): Slick.GroupInfo<TEntity>[];
    }
}
declare var jsPDF: any;
declare namespace VistaGL.Common {
    class ReportDialog extends Serenity.TemplatedDialog<ReportDialogOptions> {
        private report;
        private propertyItems;
        private propertyGrid;
        constructor(options: ReportDialogOptions);
        protected getDialogButtons(): any;
        protected createPropertyGrid(): void;
        protected loadReport(reportKey: string): void;
        protected updateInterface(): void;
        executeReport(target: string, ext: string, download: boolean): void;
        getToolbarButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
    }
    interface ReportDialogOptions {
        reportKey: string;
    }
}
declare namespace VistaGL.Common {
    interface ReportExecuteOptions {
        reportKey: string;
        download?: boolean;
        extension?: 'pdf' | 'htm' | 'html' | 'xlsx' | 'docx';
        getParams?: () => any;
        params?: {
            [key: string]: any;
        };
        target?: string;
    }
    namespace ReportHelper {
        function execute(options: ReportExecuteOptions): void;
    }
}
declare var jsPDF: any;
declare namespace VistaGL.Common {
    class ReportPage extends Serenity.Widget<any> {
        private reportKey;
        private propertyItems;
        private propertyGrid;
        constructor(element: JQuery);
        protected updateMatchFlags(text: string): void;
        protected categoryClick(e: any): void;
        protected reportLinkClick(e: any): void;
    }
}
declare namespace VistaGL.Common {
    class UserPreferenceStorage implements Serenity.SettingStorage {
        getItem(key: string): string;
        setItem(key: string, data: string): void;
    }
}
declare namespace VistaGL.Configurations {
    class AccAccountingPeriodInformationDialog extends EntityDialogBase<AccAccountingPeriodInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccAccountingPeriodInformationForm;
        constructor();
    }
}
declare namespace VistaGL.Configurations {
    class AccAccountingPeriodInformationGrid extends EntityGridBase<AccAccountingPeriodInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccAccountingPeriodInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccAdvanceDepositeReportDialog extends Serenity.EntityDialog<AccAdvanceDepositeReportRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccAdvanceDepositeReportForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccAdvanceDepositeReportGrid extends EntityGridBase<AccAdvanceDepositeReportRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccAdvanceDepositeReportDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccArDoubtfulDebtsDialog extends Serenity.EntityDialog<AccArDoubtfulDebtsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccArDoubtfulDebtsForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccArDoubtfulDebtsGrid extends EntityGridBase<AccArDoubtfulDebtsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccArDoubtfulDebtsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccBankAccountInformationDialog extends Serenity.EntityDialog<AccBankAccountInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBankAccountInformationForm;
        validateBeforeSave(): boolean;
    }
}
declare namespace VistaGL.Configurations {
    class AccBankAccountInformationGrid extends EntityGridBase<AccBankAccountInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBankAccountInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccBankAdviceLetterTemplateDialog extends Serenity.EntityDialog<AccBankAdviceLetterTemplateRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBankAdviceLetterTemplateForm;
        constructor();
    }
}
declare namespace VistaGL.Configurations {
    class AccBankAdviceLetterTemplateGrid extends Serenity.EntityGrid<AccBankAdviceLetterTemplateRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBankAdviceLetterTemplateDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccBankBranchInformationDialog extends EntityDialogBase<AccBankBranchInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBankBranchInformationForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccBankBranchInformationEditor extends GridEditorBase<AccBankBranchInformationRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBankBranchInformationEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccBankBranchInformationEditorDialog extends GridEditorDialog<AccBankBranchInformationRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccBankBranchInformationForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccBankBranchInformationGrid extends Serenity.EntityGrid<AccBankBranchInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBankBranchInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccBankInformationDialog extends EntityDialogBase<AccBankInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBankInformationForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccBankInformationGrid extends EntityGridBaseNew<AccBankInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBankInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccBudgetGroupDialog extends Serenity.EntityDialog<AccBudgetGroupRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBudgetGroupForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccBudgetGroupGrid extends EntityGridBase<AccBudgetGroupRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetGroupDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccBudgetZoneApproverDialog extends Serenity.EntityDialog<AccBudgetZoneApproverRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccBudgetZoneApproverForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccBudgetZoneApproverGrid extends EntityGridBase<AccBudgetZoneApproverRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetZoneApproverDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccCashFlowAdvTaxReportDialog extends Serenity.EntityDialog<AccCashFlowAdvTaxReportRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccCashFlowAdvTaxReportForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccCashFlowAdvTaxReportGrid extends EntityGridBase<AccCashFlowAdvTaxReportRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCashFlowAdvTaxReportDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccChartofAccountsDialog extends EntityDialogBase<AccChartofAccountsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        isGroup: boolean;
        protected form: AccChartofAccountsForm;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        onDialogOpen(): void;
    }
}
declare namespace VistaGL.Configurations {
    class AccChartofAccountsGrid extends EntityGridBase<AccChartofAccountsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccChartofAccountsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        createSlickGrid(): Slick.Grid;
        protected subDialogDataChange(): void;
        protected usePager(): boolean;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected getButtons(): Serenity.ToolButton[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
        getItemCssClass(item: Configurations.AccChartofAccountsRow, index: number): string;
    }
}
declare namespace VistaGL.Configurations {
    class AccChartofAccountsGroupGrid extends EntityGridBase<AccChartofAccountsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccChartofAccountsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected subDialogDataChange(): void;
        protected usePager(): boolean;
        protected getColumns(): Slick.Column[];
        protected addButtonClick(): void;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected onViewSubmit(): boolean;
    }
}
declare namespace VistaGL.Configurations {
    class CoAEditor extends Serenity.Widget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchDebitInput: HTMLInputElement;
        jsTreeDebitDiv: HTMLDivElement;
        TransactionTypeID: number;
        constructor(container: JQuery);
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        protected DebitItems: Transaction.AccTransactionTypeAssignRow[];
        value: Transaction.AccTransactionTypeAssignRow[];
    }
}
declare namespace VistaGL.Configurations {
    class ImportCoADialog extends Serenity.EntityDialog<any, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ImportCoAForm;
        constructor();
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Configurations {
    class AccCoACostCenterOpeningBalanceDialog extends Serenity.EntityDialog<AccCoACostCenterOpeningBalanceRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccCoACostCenterOpeningBalanceForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccCoACostCenterOpeningBalanceGrid extends EntityGridBase<AccCoACostCenterOpeningBalanceRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCoACostCenterOpeningBalanceDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccCommonDescriptionDialog extends EntityDialogBase<AccCommonDescriptionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccCommonDescriptionForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccCommonDescriptionGrid extends EntityGridBase<AccCommonDescriptionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCommonDescriptionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccCostCenterTypeDialog extends EntityDialogBase<AccCostCenterTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccCostCenterTypeForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccCostCenterTypeGrid extends EntityGridBase<AccCostCenterTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCostCenterTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccCostCentreDepreciationOpeningBalanceDialog extends Serenity.EntityDialog<AccCostCentreDepreciationOpeningBalanceRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccCostCentreDepreciationOpeningBalanceForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccCostCentreDepreciationOpeningBalanceGrid extends Serenity.EntityGrid<AccCostCentreDepreciationOpeningBalanceRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCostCentreDepreciationOpeningBalanceDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccCurrencyConversionDialog extends Serenity.EntityDialog<AccCurrencyConversionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccCurrencyConversionForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccCurrencyConversionGrid extends EntityGridBase<AccCurrencyConversionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCurrencyConversionDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccCurrencyConversionRateDialog extends Serenity.EntityDialog<AccCurrencyConversionRateRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccCurrencyConversionRateForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccCurrencyConversionRateGrid extends EntityGridBase<AccCurrencyConversionRateRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCurrencyConversionRateDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccFinancialReportsDetailsDialog extends EntityDialogBase<AccFinancialReportsDetailsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccFinancialReportsDetailsForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccFinancialReportsDetailsGrid extends EntityGridBase<AccFinancialReportsDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccFinancialReportsDetailsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccFundControlInformationDialog extends Serenity.EntityDialog<AccFundControlInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccFundControlInformationForm;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccFundControlInformationGrid extends EntityGridBase<AccFundControlInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccFundControlInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class selectFundControlInformationsDialog extends Serenity.PropertyDialog<any, any> {
        protected getFormKey(): string;
        constructor();
    }
}
declare namespace VistaGL.Configurations {
    class AccFundControlZoneWiseApproverDialog extends Serenity.EntityDialog<AccFundControlZoneWiseApproverRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccFundControlZoneWiseApproverForm;
        onDialogOpen(): void;
    }
}
declare namespace VistaGL.Configurations {
    class AccFundControlZoneWiseApproverGrid extends Serenity.EntityGrid<AccFundControlZoneWiseApproverRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccFundControlZoneWiseApproverDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccGovtLoanReportDialog extends Serenity.EntityDialog<AccGovtLoanReportRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccGovtLoanReportForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccGovtLoanReportGrid extends EntityGridBase<AccGovtLoanReportRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccGovtLoanReportDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccPriorYearAdjustmentDialog extends Serenity.EntityDialog<AccPriorYearAdjustmentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccPriorYearAdjustmentForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccPriorYearAdjustmentGrid extends Serenity.EntityGrid<AccPriorYearAdjustmentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccPriorYearAdjustmentDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeDialog extends Serenity.EntityDialog<AccReportTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccReportTypeForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeGrid extends Serenity.EntityGrid<AccReportTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccReportTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeCoaMappingDialog extends Serenity.EntityDialog<AccReportTypeCoaMappingRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccReportTypeCoaMappingForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeCoaMappingGrid extends Serenity.EntityGrid<AccReportTypeCoaMappingRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccReportTypeCoaMappingDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeCostCenterMappingDialog extends Serenity.EntityDialog<AccReportTypeCostCenterMappingRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccReportTypeCostCenterMappingForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeCostCenterMappingGrid extends Serenity.EntityGrid<AccReportTypeCostCenterMappingRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccReportTypeCostCenterMappingDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeGroupOpeningBalanceDialog extends Serenity.EntityDialog<AccReportTypeGroupOpeningBalanceRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccReportTypeGroupOpeningBalanceForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeGroupOpeningBalanceGrid extends Serenity.EntityGrid<AccReportTypeGroupOpeningBalanceRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccReportTypeGroupOpeningBalanceDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeGroupSetupDialog extends Serenity.EntityDialog<AccReportTypeGroupSetupRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccReportTypeGroupSetupForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccReportTypeGroupSetupGrid extends EntityGridBase<AccReportTypeGroupSetupRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccReportTypeGroupSetupDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccSetupForBankAdviceLetterDialog extends Serenity.EntityDialog<AccSetupForBankAdviceLetterRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccSetupForBankAdviceLetterForm;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        constructor();
        LoanAccountHeadBank(): void;
    }
}
declare namespace VistaGL.Configurations {
    class AccSetupForBankAdviceLetterGrid extends EntityGridBase<AccSetupForBankAdviceLetterRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccSetupForBankAdviceLetterDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccTransactionTypeDialog extends EntityDialogBase<AccTransactionTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccTransactionTypeForm;
        protected validateBeforeSave(): boolean;
    }
}
declare namespace VistaGL.Configurations {
    class AccTransactionTypeGrid extends EntityGridBase<AccTransactionTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccTransactionTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccUnitTypeDialog extends Serenity.EntityDialog<AccUnitTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccUnitTypeForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccUnitTypeGrid extends EntityGridBase<AccUnitTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccUnitTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiDialog extends Serenity.EntityDialog<AccVoucherApiRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherApiForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiEditor extends GridEditorBase<AccVoucherApiRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiEditorDialog extends GridEditorDialog<AccVoucherApiRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccVoucherApiForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiGrid extends Serenity.EntityGrid<AccVoucherApiRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigDialog extends Serenity.EntityDialog<AccVoucherApiConfigRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherApiConfigForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigEditor extends GridEditorBase<AccVoucherApiConfigRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiConfigEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigEditorDialog extends GridEditorDialog<AccVoucherApiConfigRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccVoucherApiConfigForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigGrid extends Serenity.EntityGrid<AccVoucherApiConfigRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiConfigDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigDetailsDialog extends Serenity.EntityDialog<AccVoucherApiConfigDetailsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherApiConfigDetailsForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigDetailsEditor extends GridEditorBase<AccVoucherApiConfigDetailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiConfigDetailsEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigDetailsEditorDialog extends GridEditorDialog<AccVoucherApiConfigDetailsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccVoucherApiConfigDetailsForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiConfigDetailsGrid extends Serenity.EntityGrid<AccVoucherApiConfigDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiConfigDetailsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiDetailsDialog extends Serenity.EntityDialog<AccVoucherApiDetailsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherApiDetailsForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiDetailsEditor extends GridEditorBase<AccVoucherApiDetailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiDetailsEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiDetailsEditorDialog extends GridEditorDialog<AccVoucherApiDetailsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccVoucherApiDetailsForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherApiDetailsGrid extends Serenity.EntityGrid<AccVoucherApiDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherApiDetailsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherTypeDialog extends EntityDialogBase<AccVoucherTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherTypeForm;
    }
}
declare namespace VistaGL.Configurations {
    class AccVoucherTypeGrid extends Serenity.EntityGrid<AccVoucherTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Default {
    class AuditLogDialog extends Serenity.EntityDialog<AuditLogRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AuditLogForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
        protected getEntityTitle(): string;
        onDialogOpen(): void;
    }
}
declare namespace VistaGL.Default {
    class AuditLogGrid extends EntityGridBaseNew<AuditLogRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AuditLogDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
    }
}
declare namespace VistaGL.Membership {
    class LoginPanel extends Serenity.PropertyPanel<LoginRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Membership {
    class ChangePasswordPanel extends Serenity.PropertyPanel<ChangePasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Membership {
    class ForgotPasswordPanel extends Serenity.PropertyPanel<ForgotPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Membership {
    class ResetPasswordPanel extends Serenity.PropertyPanel<ResetPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Membership {
    class SignUpPanel extends Serenity.PropertyPanel<SignUpRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class VoucherPreviewDialog extends Serenity.TemplatedDialog<any> {
        _url: string;
        constructor();
        static initializePage(): void;
        protected onDialogOpen(): void;
        protected arrange(): void;
        protected getTemplate(): string;
        protected getDialogOptions(): JQueryUI.DialogOptions;
    }
}
declare namespace VistaGL.Transaction {
    class AccBankAdviceLetterGrid extends EntityGridBase<AccChequeRegisterRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private pendingChanges;
        constructor(container: JQuery);
        protected createToolbarExtensions(): void;
        protected markupReady(): void;
        protected getItemCssClass(item: any, index: number): string;
        protected getButtons(): Serenity.ToolButton[];
        protected onViewProcessData(response: any): Serenity.ListResponse<AccChequeRegisterRow>;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected getColumns(): Slick.Column[];
        private inputsChange(e);
        private setSaveButtonState();
        private saveClick();
        private dateInputFormatter(ctx);
        private getEffectiveValue(item, field);
    }
}
declare namespace VistaGL.Transaction {
    class AccBankReconciliationDirectDialog extends EntityDialogBase<AccBankReconciliationDirectRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBankReconciliationDirectForm;
        constructor();
        protected onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccBankReconciliationDirectGrid extends EntityGridBase<AccBankReconciliationDirectRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBankReconciliationDirectDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getSlickOptions(): Slick.GridOptions;
    }
}
declare namespace VistaGL.Transaction {
    class BankReconciliationVoucherGrid extends EntityGridBase<AccVoucherDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private pendingChanges;
        constructor(container: JQuery);
        createSlickGrid(): Slick.Grid;
        protected markupReady(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected onViewProcessData(response: any): Serenity.ListResponse<AccVoucherDetailsRow>;
        protected getSlickOptions(): Slick.GridOptions;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        private inputsChange(e);
        private setSaveButtonState();
        private saveClick();
        private dateInputFormatter(ctx);
        private getEffectiveValue(item, field);
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetDialog extends EntityDialogBase<AccBudgetRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBudgetForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetGrid extends EntityGridBaseNew<AccBudgetRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetApprovalHistoryDialog extends Serenity.EntityDialog<AccBudgetApprovalHistoryRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccBudgetApprovalHistoryForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetApprovalHistoryGrid extends EntityGridBase<AccBudgetApprovalHistoryRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetApprovalHistoryDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        BudgetForDepartmentId: number;
        constructor(container: JQuery);
        loadByBudgetForDepartmentId(budgetForDeptId: any): void;
        protected getColumns(): Slick.Column[];
        protected onViewSubmit(): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetCircularDialog extends Serenity.EntityDialog<AccBudgetCircularRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccBudgetCircularForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetCircularGrid extends Serenity.EntityGrid<AccBudgetCircularRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetCircularDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetCreationDialog extends Serenity.EntityDialog<AccBudgetForDepartmentDetailRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccBudgetCreationForm;
        constructor();
        protected onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetCreationGrid extends EntityGridBase<AccBudgetForDepartmentDetailRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetCreationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private isEditedFlag;
        userInfo: ScriptUserDefinition;
        protected departmentFilter: Serenity.LookupEditor;
        protected zoneFilter: Serenity.LookupEditor;
        constructor(container: JQuery);
        protected getItemCssClass(item: AccBudgetForDepartmentDetailRow, index: number): string;
        protected getSlickOptions(): Slick.GridOptions;
        protected getColumns(): Slick.Column[];
        protected getButtons(): Serenity.ToolButton[];
        protected onViewProcessData(response: any): Serenity.ListResponse<AccBudgetForDepartmentDetailRow>;
        updateColumnHeader(Id: any): void;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected createQuickFilters(): void;
        set_shippingState(value: number): void;
        set_zone(value: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class BudgetCreationApprovalDialog extends Serenity.EntityDialog<AccBudgetForDepartmentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: BudgetCreationApprovalForm;
    }
}
declare namespace VistaGL.Transaction {
    class BudgetCreationApprovalGrid extends EntityGridBase<AccBudgetForDepartmentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BudgetCreationApprovalDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        AccBudgetApprovalHistoryGrid: AccBudgetApprovalHistoryGrid;
        budgetforDeptId: any;
        constructor(container: JQuery);
        protected getColumns(): Slick.Column[];
        protected getButtons(): Serenity.ToolButton[];
        protected onViewProcessData(response: any): Serenity.ListResponse<AccBudgetForDepartmentRow>;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetDetailsDialog extends Serenity.EntityDialog<AccBudgetDetailsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccBudgetDetailsForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetDetailsEditor extends GridEditorBase<AccBudgetDetailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetDetailsEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetDetailsEditorDialog extends GridEditorDialog<AccBudgetDetailsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccBudgetDetailsForm;
        protected budgetHeadList: AccBudgetDetailsRow[];
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        items_CostCenter: AccCostCentreOrInstituteInformationRow[];
        protected onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetDetailsGrid extends Serenity.EntityGrid<AccBudgetDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetDetailsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetForDepartmentDialog extends Serenity.EntityDialog<AccBudgetForDepartmentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccBudgetForDepartmentForm;
        onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetForDepartmentGrid extends Serenity.EntityGrid<AccBudgetForDepartmentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetForDepartmentDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetForDepartmentDetailDialog extends Serenity.EntityDialog<AccBudgetForDepartmentDetailRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccBudgetForDepartmentDetailForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetForDepartmentDetailEditor extends Serenity.Widget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchInput: HTMLInputElement;
        jsTreeDiv: HTMLDivElement;
        allClusterInput: HTMLInputElement;
        budgetDetails: AccBudgetForDepartmentDetailRow[];
        constructor(container: JQuery);
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        protected budgetHeads: AccBudgetForDepartmentDetailRow[];
        value: AccBudgetForDepartmentDetailRow[];
    }
}
declare namespace VistaGL.Transaction {
    class AccBudgetForDepartmentDetailGrid extends Serenity.EntityGrid<AccBudgetForDepartmentDetailRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccBudgetForDepartmentDetailDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccChequeBookDialog extends Serenity.EntityDialog<AccChequeBookRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccChequeBookForm;
        constructor(container: JQuery);
        protected CalculateEndingPageNo_Change(): void;
        protected BankAccountInformation_Change(): void;
        protected onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccChequeBookGrid extends EntityGridBaseNew<AccChequeBookRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccChequeBookDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class AccChequePreparationGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getButtons(): Serenity.ToolButton[];
        getColumns(): Slick.Column[];
        protected getSlickOptions(): Slick.GridOptions;
        onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccChequeReceiveRegisterDialog extends Serenity.EntityDialog<AccChequeReceiveRegisterRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccChequeReceiveRegisterForm;
        dig: Transaction.AccVoucherBankWiseDialog;
        digforOnlyPayment: AccVoucherInformationDialog;
        _isFromVoucher: boolean;
        _isPaymentOrReceiptVoucherOnly: boolean;
        constructor();
        protected onDialogOpen(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccChequeReceiveRegisterGrid extends EntityGridBase<AccChequeReceiveRegisterRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccChequeReceiveRegisterDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class AccChequeRegisterDialog extends Serenity.EntityDialog<AccChequeRegisterRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccChequeRegisterForm;
        dig: Transaction.AccVoucherBankWiseDialog;
        digforOnlyPayment: AccVoucherInformationDialog;
        _isFromVoucher: boolean;
        _isPaymentOrReceiptVoucherOnly: boolean;
        constructor();
        protected onDialogOpen(): void;
        protected BankAccountInformation_Change(): void;
        protected ChequeBookInformation_Change(): void;
        protected validateBeforeSave(): boolean;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccChequeRegisterGrid extends EntityGridBaseNew<AccChequeRegisterRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccChequeRegisterDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private pendingChanges;
        constructor(container: JQuery);
        protected subDialogDataChange(): void;
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class AccCostCentreOrInstituteInformationDialog extends _Ext.DialogBase<AccCostCentreOrInstituteInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccCostCentreOrInstituteInformationForm;
        constructor();
        onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccCostCentreOrInstituteInformationGrid extends EntityGridBase<AccCostCentreOrInstituteInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccCostCentreOrInstituteInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected subDialogDataChange(): void;
        protected usePager(): boolean;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccCreditVoucherFromMoneyReceiptBulkAction extends Common.BulkServiceAction {
        /**
         * This controls how many service requests will be used in parallel.
         * Determine this number based on how many requests your server
         * might be able to handle, and amount of wait on external resources.
         */
        protected getParallelRequests(): number;
        /**
         * These number of records IDs will be sent to your service in one
         * service call. If your service is designed to handle one record only,
         * set it to 1. But note that, if you have 5000 records, this will
         * result in 5000 service calls / requests.
         */
        protected getBatchSize(): number;
        /**
         * This is where you should call your service.
         * Batch parameter contains the selected order IDs
         * that should be processed in this service call.
         */
        protected executeForBatch(batch: any): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccCreditVoucherFromMoneyReceiptGrid extends Serenity.EntityGrid<AccMoneyReceiptRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private rowSelection;
        constructor(container: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getSlickOptions(): Slick.GridOptions;
        protected getColumns(): Slick.Column[];
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected onViewSubmit(): boolean;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccCreditVoucherParametersDialog extends Serenity.EntityDialog<AccMoneyReceiptRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccCreditVoucherParametersForm;
        private selectedItems;
        constructor();
        SendSelected(selected: any): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccEmpAdvanceDialog extends EntityDialogBase<AccEmpAdvanceRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        AccChequeRegister: AccChequeRegisterRow[];
        protected form: AccEmpAdvanceForm;
        constructor();
        onDialogOpen(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccEmpAdvanceEditor extends GridEditorBase<AccEmpAdvanceRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccEmpAdvanceEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccEmpAdvanceEditorDialog extends GridEditorDialog<AccEmpAdvanceRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccEmpAdvanceForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccEmpAdvanceGrid extends EntityGridBase<AccEmpAdvanceRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccEmpAdvanceDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected subDialogDataChange(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccFixedAssetDepreciationDialog extends Serenity.EntityDialog<AccFixedAssetDepreciationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccFixedAssetDepreciationForm;
        onDialogOpen(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccFixedAssetDepreciationGrid extends Serenity.EntityGrid<AccFixedAssetDepreciationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccFixedAssetDepreciationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccFixedAssetRefurbishmentDialog extends EntityDialogBase<AccFixedAssetRefurbishmentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccFixedAssetRefurbishmentForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccFixedAssetRefurbishmentGrid extends EntityGridBaseNew<AccFixedAssetRefurbishmentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccFixedAssetRefurbishmentDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccFixedAssetsManualInputDialog extends Serenity.EntityDialog<AccFixedAssetsManualInputRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccFixedAssetsManualInputForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccFixedAssetsManualInputGrid extends Serenity.EntityGrid<AccFixedAssetsManualInputRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccFixedAssetsManualInputDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccIbcsJsondataHistoryDialog extends Serenity.EntityDialog<AccIbcsJsondataHistoryRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccIbcsJsondataHistoryForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccIbcsJsondataHistoryGrid extends EntityGridBaseNew<AccIbcsJsondataHistoryRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccIbcsJsondataHistoryDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccMoneyReceiptDialog extends EntityDialogBase<AccMoneyReceiptRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccMoneyReceiptForm;
        constructor();
        onDialogOpen(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccMoneyReceiptGrid extends EntityGridBaseNew<AccMoneyReceiptRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccMoneyReceiptDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        protected getColumns(): Slick.Column[];
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccMoneyReceiptDatailsDialog extends Serenity.EntityDialog<AccMoneyReceiptDatailsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccMoneyReceiptDatailsForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccMoneyReceiptDatailsEditor extends GridEditorBase<AccMoneyReceiptDatailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccMoneyReceiptDatailsEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace VistaGL.Transaction {
    class AccMoneyReceiptDatailsEditorDialog extends GridEditorDialog<AccMoneyReceiptDatailsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: AccMoneyReceiptDatailsForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccMoneyReceiptDatailsGrid extends Serenity.EntityGrid<AccMoneyReceiptDatailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccMoneyReceiptDatailsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccNoaDialog extends EntityDialogBase<AccNoaRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccNoaForm;
        protected onDialogOpen(): void;
        protected validateBeforeSave(): boolean;
    }
}
declare namespace VistaGL.Transaction {
    class AccNoaGrid extends EntityGridBase<AccNoaRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccNoaDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccPartyPaymentDialog extends Serenity.EntityDialog<AccPartyPaymentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        AccChequeRegister: AccChequeRegisterRow[];
        protected form: AccPartyPaymentForm;
        onDialogOpen(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class AccPartyPaymentGrid extends Serenity.EntityGrid<AccPartyPaymentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccPartyPaymentDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccTransactionTypeAssignDialog extends Serenity.EntityDialog<AccTransactionTypeAssignRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccTransactionTypeAssignForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccTransactionTypeAssignGrid extends Serenity.EntityGrid<AccTransactionTypeAssignRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccTransactionTypeAssignDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class CoACreditEditor extends Serenity.Widget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchInput: HTMLInputElement;
        jsTreeDiv: HTMLDivElement;
        constructor(container: JQuery);
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        protected CreditItems: AccTransactionTypeAssignRow[];
        value: AccTransactionTypeAssignRow[];
    }
}
declare namespace VistaGL.Transaction {
    class CoADebitEditor extends Serenity.Widget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        searchDebitInput: HTMLInputElement;
        jsTreeDebitDiv: HTMLDivElement;
        searchCreditInput: HTMLInputElement;
        jsTreeCreditDiv: HTMLDivElement;
        TransactionTypeID: number;
        constructor(container: JQuery);
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        protected DebitItems: AccTransactionTypeAssignRow[];
        value: AccTransactionTypeAssignRow[];
    }
}
declare namespace VistaGL.Transaction {
    class AccTransactionTypeAssignMasterDialog extends Serenity.EntityDialog<AccTransactionTypeAssignMasterRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccTransactionTypeAssignMasterForm;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccTransactionTypeAssignMasterGrid extends EntityGridBase<AccTransactionTypeAssignMasterRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccTransactionTypeAssignMasterDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDialog extends Serenity.EntityDialog<AccViewBudgetRow, any> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        COAID: number;
        COAName: string;
        protected form: AccViewBudgetForm;
        private ViewBudgetDetailsGrid;
        protected onDialogOpen(): void;
        protected getToolbarButtons(): any[];
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetGrid extends Serenity.EntityGrid<AccViewBudgetRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccViewBudgetDialog;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getIdProperty(): string;
        constructor(container: JQuery);
        private nextId;
        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<AccViewBudgetRow>): Serenity.ListResponse<AccViewBudgetRow>;
        protected getButtons(): Serenity.ToolButton[];
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsDialog extends Serenity.EntityDialog<AccViewBudgetDetailsRow, any> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccViewBudgetDetailsForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsEditor extends GridEditorBase<AccViewBudgetDetailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccViewBudgetDetailsEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsEditorDialog extends GridEditorDialog<AccViewBudgetDetailsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccViewBudgetDetailsForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsGrid extends Serenity.EntityGrid<AccViewBudgetDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccViewBudgetDetailsDialog;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getIdProperty(): string;
        private pendingChanges;
        constructor(container: JQuery);
        private nextId;
        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<AccViewBudgetDetailsRow>): Serenity.ListResponse<AccViewBudgetDetailsRow>;
        protected getButtons(): Serenity.ToolButton[];
        private _CoAID;
        CoAID: number;
        protected usePager(): boolean;
        private getEffectiveValue(item, field);
        protected getColumns(): Slick.Column[];
        private numericInputFormatter(ctx);
        private inputsChange(e);
        private setSaveButtonState();
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsDeptDialog extends Serenity.EntityDialog<AccViewBudgetDetailsDeptRow, any> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccViewBudgetDetailsDeptForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsDeptEditor extends GridEditorBase<AccViewBudgetDetailsDeptRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccViewBudgetDetailsDeptEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsDeptEditorDialog extends GridEditorDialog<AccViewBudgetDetailsDeptRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccViewBudgetDetailsDeptForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetDetailsDeptGrid extends Serenity.EntityGrid<AccViewBudgetDetailsDeptRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccViewBudgetDetailsDeptDialog;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetZoneDialog extends Serenity.EntityDialog<AccViewBudgetZoneRow, any> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccViewBudgetZoneForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetZoneEditor extends GridEditorBase<AccViewBudgetZoneRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccViewBudgetZoneEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetZoneEditorDialog extends GridEditorDialog<AccViewBudgetZoneRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccViewBudgetZoneForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccViewBudgetZoneGrid extends Serenity.EntityGrid<AccViewBudgetZoneRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccViewBudgetZoneDialog;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherConfigurationDialog extends EntityDialogBase<AccVoucherConfigurationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherConfigurationForm;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherConfigurationGrid extends EntityGridBase<AccVoucherConfigurationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherConfigurationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDetailsDialog extends EntityDialogBase<AccVoucherDetailsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherDetailsForm;
        onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDetailsEditor extends GridEditorBase<AccVoucherDetailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherDetailsEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        onItemsChanged(): void;
        deleteEntity(id: number): boolean;
        editItem(entityOrId: any): void;
        C_editItem(id: number): void;
        C_NewItem(_row: AccVoucherDetailsRow): void;
        validateEntity(row: AccVoucherDetailsRow, id: any): boolean;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDetailsEditorDialog extends GridEditorDialog<AccVoucherDetailsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccVoucherDetailsForm;
        protected items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        _TransactionMode: string;
        _VoucherTypeId: string;
        protected timeLoad: any;
        protected Amount: number;
        protected onDialogClose(): void;
        protected onDialogOpen(): void;
        protected FocusDrCr(VoucherTypeId: any, CoaMapping: any): void;
        protected getSaveEntity(): AccVoucherDetailsRow;
        protected validateBeforeSave(): boolean;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDetailsGrid extends Serenity.EntityGrid<AccVoucherDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherDetailsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class TransferDetailesEditor extends GridEditorBase<AccVoucherDetailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlAllocationDialog extends Serenity.EntityDialog<AccVoucherDtlAllocationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: AccVoucherDtlAllocationForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlAllocationEditor extends GridEditorBase<AccVoucherDtlAllocationRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherDtlAllocationEditorDialog;
        protected getLocalTextPrefix(): string;
        isDrCr: string;
        constructor(container: JQuery);
        protected initEntityDialog(itemType: string, dialog: Serenity.Widget<any>): void;
        validateEntity(row: AccVoucherDtlAllocationRow, id: any): boolean;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlAllocationEditorDialog extends GridEditorDialog<AccVoucherDtlAllocationRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: AccVoucherDtlAllocationForm;
        isDrCr: string;
        onDialogOpen(): void;
        protected getSaveEntity(): AccVoucherDtlAllocationRow;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlAllocationGrid extends EntityGridBaseNew<AccVoucherDtlAllocationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherDtlAllocationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlBillRefDialog extends Serenity.EntityDialog<AccVoucherDtlBillRefRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherDtlBillRefForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlBillRefEditor extends GridEditorBase<AccVoucherDtlBillRefRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherDtlBillRefEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlBillRefEditorDialog extends GridEditorDialog<AccVoucherDtlBillRefRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: AccVoucherDtlBillRefForm;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherDtlBillRefGrid extends Serenity.EntityGrid<AccVoucherDtlBillRefRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherDtlBillRefDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherBankWiseDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        form: AccVoucherBankWiseForm;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        items_CurrencyConversionRate: Configurations.AccCurrencyConversionRateRow[];
        CheckAutoVoucher: boolean;
        AccTransactionTypeAssign: AccTransactionTypeAssignRow[];
        _VoucherConfiguration: AccVoucherConfigurationRow[];
        _AccountingPeriod: Configurations.AccAccountingPeriodInformationRow[];
        protected nextId: number;
        protected HeadId: number;
        protected selectedApproverId: number;
        _IsCostCenterAllocate: number;
        _IsBillRef: number;
        IsAutoPost: boolean;
        _VoucherDtlAllocation: AccVoucherDtlAllocationRow[];
        budgetHeadList: AccBudgetDetailsRow[];
        transactionMode: string;
        protected baseCurrency: string;
        protected fundControlId: number;
        protected zoneId: number;
        protected userId: number;
        constructor();
        onDialogOpen(): void;
        addtoGrid(): void;
        protected afterLoadEntity(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected getSaveEntity(): AccVoucherInformationRow;
        protected validateBeforeSave(): boolean;
        protected onSaveSuccess(response: Serenity.SaveResponse): void;
        onAfterSaveSuccess(): void;
        loadAccountHead(): void;
        loadAccountHeadBankCash(): void;
        loadCheque(): void;
        populateChequeBook(accountHeadBank: any): void;
        populateChequeNumber(chequeBookId: any): void;
        changePvSubLedger(): void;
        setMultiCurrencyCurrency(MultiCurrencyCurrency: any, MultiCurrencyId: any, thisform: any): void;
        sumDebitCredit(): void;
        setNewVoucherNumber(transactionTypeId: any): void;
        private VoucherDateChange();
        protected clearData(): void;
        getBudgetAmount(headId: any, IsCoa: boolean, IsAutoJV: boolean): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherBankWiseGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherBankWiseDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        OpenVoucher(id: any): void;
        protected getColumns(): Slick.Column[];
        protected getSlickOptions(): Slick.GridOptions;
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherInformationDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        form: AccVoucherInformationForm;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        items_CurrencyConversionRate: Configurations.AccCurrencyConversionRateRow[];
        CheckAutoVoucher: boolean;
        AccChequeRegister: AccChequeRegisterRow[];
        AccChequeReceiveRegister: AccChequeReceiveRegisterRow[];
        AccTransactionTypeAssign: AccTransactionTypeAssignRow[];
        _VoucherConfiguration: AccVoucherConfigurationRow[];
        _AccountingPeriod: Configurations.AccAccountingPeriodInformationRow[];
        protected nextId: number;
        protected isFristTime: boolean;
        _IsCostCenterAllocate: number;
        _IsBillRef: number;
        IsAutoPost: boolean;
        _VoucherDtlAllocation: AccVoucherDtlAllocationRow[];
        protected baseCurrency: string;
        protected fundControlId: number;
        protected zoneId: number;
        protected userId: number;
        transactionMode: string;
        protected selectedApproverId: number;
        protected HeadId: number;
        constructor();
        onDialogOpen(): void;
        addtoGrid(): void;
        protected afterLoadEntity(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected getSaveEntity(): AccVoucherInformationRow;
        protected validateBeforeSave(): boolean;
        protected onSaveSuccess(response: Serenity.SaveResponse): void;
        onAfterSaveSuccess(): void;
        setMultiCurrencyCurrency(MultiCurrencyCurrency: any, MultiCurrencyId: any, thisform: any): void;
        private VoucherDateChange();
        loadAccountHead(): void;
        loadCheque(): void;
        sumDebitCredit(): void;
        protected clearData(): void;
        setNewVoucherNumber(): void;
        setNewVoucherNumberByTransactionType(transactionTypeId: any): void;
        protected currencyToWords(s: any): string;
        convertNumber(num: any): string;
        transactionModeChange(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherInformationGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        OpenVoucher(id: any): void;
        protected getColumns(): Slick.Column[];
        protected getSlickOptions(): Slick.GridOptions;
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherInformationSearchGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherInformationDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected VoucherTempId: number;
        set_VoucherTempId(value: number): void;
        OpenVoucher(id: any): void;
        constructor(container: JQuery);
        protected getColumns(): Slick.Column[];
        protected getSlickOptions(): Slick.GridOptions;
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
        protected getButtons(): Serenity.ToolButton[];
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class selectCalculationDialog extends Serenity.EntityDialog<any, any> {
        protected getFormKey(): string;
        protected form: selectCalculationForm;
        constructor();
        protected getToolbarButtons(): any[];
    }
}
declare namespace VistaGL.Transaction {
    class VoucherApprovalHistoryEditor extends Serenity.TemplatedWidget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        private isDirty;
        private items;
        constructor(div: JQuery);
        protected getTemplate(): string;
        protected updateContent(): void;
        getEditValue(prop: Serenity.PropertyItem, target: any): void;
        setEditValue(source: any, prop: Serenity.PropertyItem): void;
        value: ApvApplicationInformationRow[];
        get_isDirty(): boolean;
        set_isDirty(value: any): void;
        onChange: () => void;
    }
}
declare namespace VistaGL.Transaction {
    class VoucherAuditLogEditor extends Serenity.TemplatedWidget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        private isDirty;
        private items;
        constructor(div: JQuery);
        protected getTemplate(): string;
        protected updateContent(): void;
        getEditValue(prop: Serenity.PropertyItem, target: any): void;
        setEditValue(source: any, prop: Serenity.PropertyItem): void;
        value: ApvApplicationInformationRow[];
        get_isDirty(): boolean;
        set_isDirty(value: any): void;
        onChange: () => void;
    }
}
declare namespace VistaGL.Transaction {
    class JournalVoucherGrid extends AccVoucherInformationGrid {
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        protected addButtonClick(): void;
        protected onViewSubmit(): boolean;
        getColumns(): Slick.Column[];
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class PaymentGrid extends Transaction.AccVoucherBankWiseGrid {
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        protected addButtonClick(): void;
        protected onViewSubmit(): boolean;
        protected subDialogDataChange(): void;
    }
}
declare namespace VistaGL.Transaction {
    class PaymentVoucherGrid extends AccVoucherInformationGrid {
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        /**
         * This method is called when New Item button is clicked.
         * By default, it calls EditItem with an empty entity.
         * This is a good place to fill in default values for New Item button.
         */
        protected addButtonClick(): void;
        protected onViewSubmit(): boolean;
        getColumns(): Slick.Column[];
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected subDialogDataChange(): void;
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class ReceiptGrid extends Transaction.AccVoucherBankWiseGrid {
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        /**
         * This method is called when New Item button is clicked.
         * By default, it calls EditItem with an empty entity.
         * This is a good place to fill in default values for New Item button.
         */
        protected addButtonClick(): void;
        protected onViewSubmit(): boolean;
        protected subDialogDataChange(): void;
    }
}
declare namespace VistaGL.Transaction {
    class ReceiptVoucherGrid extends AccVoucherInformationGrid {
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        /**
         * This method is called when New Item button is clicked.
         * By default, it calls EditItem with an empty entity.
         * This is a good place to fill in default values for New Item button.
         */
        protected addButtonClick(): void;
        protected onViewSubmit(): boolean;
        getColumns(): Slick.Column[];
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected subDialogDataChange(): void;
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class TransferVoucherDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        form: TransferVoucherForm;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        _VoucherConfiguration: AccVoucherConfigurationRow[];
        _AccountingPeriod: Configurations.AccAccountingPeriodInformationRow[];
        protected nextId: number;
        protected isFristTime: boolean;
        _IsCostCenterAllocate: number;
        _IsBillRef: number;
        constructor();
        protected AddtoGrid(): void;
        onDialogOpen(): void;
        protected ClearData(): void;
        protected getSaveEntity(): AccVoucherInformationRow;
        private getNextNumber();
        protected toWords(s: any): string;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace VistaGL.Transaction {
    class TransferVoucherGrid extends EntityGridBase<AccVoucherInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TransferVoucherDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        protected onViewSubmit(): boolean;
        getColumns(): Slick.Column[];
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace VistaGL.Transaction {
    class VoucherApprovalDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        form: VoucherApprovalForm;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        items_CurrencyConversionRate: Configurations.AccCurrencyConversionRateRow[];
        AccChequeRegister: {}[];
        AccTransactionTypeAssign: AccTransactionTypeAssignRow[];
        _VoucherConfiguration: AccVoucherConfigurationRow[];
        protected nextId: number;
        protected isFristTime: boolean;
        _IsCostCenterAllocate: number;
        _IsBillRef: number;
        _VoucherDtlAllocation: AccVoucherDtlAllocationRow[];
        constructor();
        onDialogOpen(): void;
        protected validateBeforeSave(): boolean;
        protected afterLoadEntity(): void;
        protected getToolbarButtons(): any[];
        protected toWords(s: any): string;
    }
}
declare namespace VistaGL.Transaction {
    class VoucherApprovalGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VoucherApprovalDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private rowSelection;
        private pendingChanges;
        constructor(container: JQuery);
        onViewSubmit(): boolean;
        usePager(): boolean;
        protected onViewProcessData(response: Serenity.ListResponse<AccVoucherInformationRow>): Serenity.ListResponse<AccVoucherInformationRow>;
        protected createToolbarExtensions(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getSlickOptions(): Slick.GridOptions;
        protected getColumns(): Slick.Column[];
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        private saveClick(approveType);
        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherTemplateDialog extends Serenity.EntityDialog<AccVoucherTemplateRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: AccVoucherTemplateForm;
        constructor(container: JQuery);
        protected onDialogOpen(): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherTemplateGrid extends EntityGridBase<AccVoucherTemplateRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AccVoucherTemplateDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace VistaGL.Transaction {
    class AccVoucherTemplateVoucherIssueDialog extends _Ext.DialogBase<AccVoucherTemplateRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        protected form: AccVoucherTemplateVoucherIssueForm;
        protected items_VoucherTemplate: AccVoucherTemplateRow[];
        constructor();
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected hide_VoucherTypeId_TransactionTypeId_Change(): void;
        protected isCheckBankHead_Change(): void;
        protected calculate_SDAmount(): void;
        protected calculate_VATAmount(): void;
        protected calculate_TAXAmount(): void;
        protected onDialogOpen(): void;
        private setTemplateDetails(details);
    }
}
declare namespace VistaGL.Transaction {
    class VoucherPostingBulkAction extends Common.BulkServiceAction {
        /**
         * This controls how many service requests will be used in parallel.
         * Determine this number based on how many requests your server
         * might be able to handle, and amount of wait on external resources.
         */
        protected getParallelRequests(): number;
        /**
         * These number of records IDs will be sent to your service in one
         * service call. If your service is designed to handle one record only,
         * set it to 1. But note that, if you have 5000 records, this will
         * result in 5000 service calls / requests.
         */
        protected getBatchSize(): number;
        /**
         * This is where you should call your service.
         * Batch parameter contains the selected order IDs
         * that should be processed in this service call.
         */
        protected executeForBatch(batch: any): void;
    }
}
declare namespace VistaGL.Transaction {
    class VoucherPostingGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private rowSelection;
        constructor(container: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getSlickOptions(): Slick.GridOptions;
        protected getColumns(): Slick.Column[];
        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected onViewSubmit(): boolean;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        getQuickSearchFields(): Serenity.QuickSearchField[];
    }
}
