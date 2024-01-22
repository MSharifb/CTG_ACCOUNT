using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Bank Information"), InstanceName("Bank Information"), TwoLevelCached]
    [ReadPermission("Configurations:AccBankInformation:Read")]
    [InsertPermission("Configurations:AccBankInformation:Insert")]
    [UpdatePermission("Configurations:AccBankInformation:Update")]
    [DeletePermission("Configurations:AccBankInformation:Delete")]
    [LookupScript("Configurations.AccBankInformation",Permission ="?")]
    public sealed class AccBankInformationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Bank Name
        [DisplayName("Bank Name"), Column("bankName"), Size(50), NotNull, QuickSearch]
        public String BankName { get { return Fields.BankName[this]; } set { Fields.BankName[this] = value; } }
        public partial class RowFields { public StringField BankName; }
        #endregion BankName

        #region Code
        [DisplayName("Code"), Column("code"), Size(100), NotNull]
        public String Code { get { return Fields.Code[this]; } set { Fields.Code[this] = value; } }
        public partial class RowFields { public StringField Code; }
        #endregion Code

        #region Branch list Detail
        [DisplayName("Bank Branch Information"), MasterDetailRelation(foreignKey: "bankId"), NotMapped]
        public List<AccBankBranchInformationRow> BankBranchInformations
        {
            get { return Fields.BankBranchInformations[this]; }
            set { Fields.BankBranchInformations[this] = value; }
        }
        public partial class RowFields { public RowListField<AccBankBranchInformationRow> BankBranchInformations; }
        #endregion

        #region Zone Info
        [Column("ZoneInfoId"), ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        [DisplayName("Zone Name"), Expression("jZoneInfo.[ZoneName]"), QuickSearch(SearchType.Contains)]
        public String ZoneInfoZoneName { get { return Fields.ZoneInfoZoneName[this]; } set { Fields.ZoneInfoZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneName; }

        #region Foreign Fields

        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.BankName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccBankInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_BankInformation]")
            {
                LocalTextPrefix = "Configurations.AccBankInformation";
            }
        }
        #endregion RowFields
    }
}
