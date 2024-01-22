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

    [ConnectionKey("ACCDB"), DisplayName("Voucher Type"), InstanceName("Voucher Type"), TwoLevelCached]
    [ReadPermission("Configurations:AccVoucherType:Read")]
    [InsertPermission("Configurations:AccVoucherType:Insert")]
    [UpdatePermission("Configurations:AccVoucherType:Update")]
    [DeletePermission("Configurations:AccVoucherType:Delete")]
    [LookupScript("Configurations.AccVoucherType", Permission = "?")]
    public sealed class AccVoucherTypeRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Name
        [DisplayName("Name"), Column("name"), Size(100), NotNull, QuickSearch]
        public String Name { get { return Fields.Name[this]; } set { Fields.Name[this] = value; } }
        public partial class RowFields { public StringField Name; }
        #endregion Name

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
            get { return Fields.Name; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccVoucherTypeRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_voucher_type]")
            {
                LocalTextPrefix = "Configurations.AccVoucherType";
            }
        }
        #endregion RowFields
    }
}
