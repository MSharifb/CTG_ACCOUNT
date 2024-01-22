using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Sub Ledger Type"), InstanceName("Sub Ledger Type"), TwoLevelCached]
    [ReadPermission("Configurations:AccCostCenterType:Read")]
    [InsertPermission("Configurations:AccCostCenterType:Insert")]
    [UpdatePermission("Configurations:AccCostCenterType:Update")]
    [DeletePermission("Configurations:AccCostCenterType:Delete")]
    [LookupScript("Configurations.AccCostCenterType", Permission = "?")]
    public sealed class AccCostCenterTypeRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Sub Ledger Type
        [DisplayName("Sub Ledger Type"), Column("costCenterType"), Size(150), NotNull]
        public String CostCenterType { get { return Fields.CostCenterType[this]; } set { Fields.CostCenterType[this] = value; } }
        public partial class RowFields { public StringField CostCenterType; }
        #endregion CostCenterType

        #region Sort Order
        [DisplayName("Sort Order"), Column("sortOrder"), SortOrder(1)]
        public Int32? SortOrder { get { return Fields.SortOrder[this]; } set { Fields.SortOrder[this] = value; } }
        public partial class RowFields { public Int32Field SortOrder; }
        #endregion SortOrder

        #region Foreign Fields

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CostCenterType; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccCostCenterTypeRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_CostCenterType]")
            {
                LocalTextPrefix = "Configurations.AccCostCenterType";
            }
        }
        #endregion RowFields
    }
}
