
namespace VistaGL.Configurations.Entities
{
    using Modules.Common;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Budget Group"), InstanceName("Budget Group"), TwoLevelCached]
    [ReadPermission("Configurations:AccBudgetGroup:Read")]
    [InsertPermission("Configurations:AccBudgetGroup:Insert")]
    [UpdatePermission("Configurations:AccBudgetGroup:Update")]
    [DeletePermission("Configurations:AccBudgetGroup:Delete")]
    [LookupScript("Configurations.AccBudgetGroup", Permission = "?")]
    public sealed class AccBudgetGroupRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Parent Id
        [DisplayName("Parent Group"), ForeignKey("[dbo].[acc_Budget_Group]", "id"), LeftJoin("jParentGroup")]
        [LookupEditor("Configurations.AccBudgetGroup"), LookupInclude]
        public Int32? ParentId { get { return Fields.ParentId[this]; } set { Fields.ParentId[this] = value; } }
        public partial class RowFields { public Int32Field ParentId; }
        #endregion ParentId

        #region Group Name
        [DisplayName("Group Name"), Size(-1), NotNull, QuickSearch]
        [Unique]
        public String GroupName { get { return Fields.GroupName[this]; } set { Fields.GroupName[this] = value; } }
        public partial class RowFields { public StringField GroupName; }
        #endregion GroupName

        #region Sorting Order
        [DisplayName("Sorting Order")]
        public Int32? SortingOrder { get { return Fields.SortingOrder[this]; } set { Fields.SortingOrder[this] = value; } }
        public partial class RowFields { public Int32Field SortingOrder; }
        #endregion SortingOrder

        #region Is Active
        [DisplayName("Is Active"), NotNull]
        public Boolean? IsActive { get { return Fields.IsActive[this]; } set { Fields.IsActive[this] = value; } }
        public partial class RowFields { public BooleanField IsActive; }
        #endregion IsActive

        [DisplayName("Parent Group"), Expression("jParentGroup.[GroupName]"), QuickSearch()]
        [MinSelectLevel(SelectLevel.List)]
        public String ParentGroupName { get { return Fields.ParentGroupName[this]; } set { Fields.ParentGroupName[this] = value; } }
        public partial class RowFields { public StringField ParentGroupName; }


        #region Budget Code
        [DisplayName("Budget Code"), Column("BudgetCode"), Size(50)]
        public String BudgetCode { get { return Fields.BudgetCode[this]; } set { Fields.BudgetCode[this] = value; } }
        public partial class RowFields { public StringField BudgetCode; }
        #endregion BudgetCode

        #region Hide Children From This Level?
        [DisplayName("Hide Children From This Level?"), Column("IsHideChildrenFromThisLevel"), LookupInclude, DefaultValue(false)]
        public Boolean? IsHideChildrenFromThisLevel { get { return Fields.IsHideChildrenFromThisLevel[this]; } set { Fields.IsHideChildrenFromThisLevel[this] = value; } }
        public partial class RowFields { public BooleanField IsHideChildrenFromThisLevel; }
        #endregion IsHideChildrenFromThisLevel

        #region Type
        [DisplayName("Type"), Column("Type"), LookupInclude]
        public String Type { get { return Fields.Type[this]; } set { Fields.Type[this] = value; } }
        public partial class RowFields { public StringField Type; }
        #endregion Type


        #region Foreign Fields

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.GroupName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccBudgetGroupRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public const string TableName = "[dbo].[acc_Budget_Group]";

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_Budget_Group]")
            {
                LocalTextPrefix = "Configurations.AccBudgetGroup";
            }
        }
        #endregion RowFields
    }
}
