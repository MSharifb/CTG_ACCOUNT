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

    [ConnectionKey("ACCDB"), DisplayName("Unit"), InstanceName("Unit"), TwoLevelCached]
    [ReadPermission("Configurations:AccUnitType:Read")]
    [InsertPermission("Configurations:AccUnitType:Insert")]
    [UpdatePermission("Configurations:AccUnitType:Update")]
    [DeletePermission("Configurations:AccUnitType:Delete")]
    [LookupScript("Configurations.AccUnitType",Permission ="?")]
    public sealed class AccUnitTypeRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Unit
        [DisplayName("Unit"), Size(255), NotNull, QuickSearch,LookupInclude]
        public String UnitName { get { return Fields.UnitName[this]; } set { Fields.UnitName[this] = value; } }
        public partial class RowFields { public StringField UnitName; }
        #endregion UnitName

        #region Remarks
        [DisplayName("Remarks"), Size(255)]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks


        #region Foreign Fields

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.UnitName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccUnitTypeRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_UnitType]")
            {
                LocalTextPrefix = "Configurations.AccUnitType";
            }
        }
        #endregion RowFields
    }
}
