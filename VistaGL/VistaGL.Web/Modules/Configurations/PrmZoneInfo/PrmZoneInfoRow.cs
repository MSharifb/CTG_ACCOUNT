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

    [ConnectionKey("ACCDB"), DisplayName("PRM_ZoneInfo"), InstanceName("PRM_ZoneInfo"), TwoLevelCached]
    [ReadPermission("Configurations:PRM_ZoneInfo:Read")]
    [InsertPermission("Configurations:PRM_ZoneInfo:Insert")]
    [UpdatePermission("Configurations:PRM_ZoneInfo:Update")]
    [DeletePermission("Configurations:PRM_ZoneInfo:Delete")]
    [LookupScript("Configurations.PrmZoneInfoRow", Permission = "?")]
    public sealed class PrmZoneInfoRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Zone Name
        [DisplayName("Zone Name"), Size(150), NotNull, QuickSearch]
        public String ZoneName { get { return Fields.ZoneName[this]; } set { Fields.ZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneName; }
        #endregion ZoneName

        #region Zone Name In Bengali
        [DisplayName("Zone Name In Bengali"), Size(200)]
        public String ZoneNameInBengali { get { return Fields.ZoneNameInBengali[this]; } set { Fields.ZoneNameInBengali[this] = value; } }
        public partial class RowFields { public StringField ZoneNameInBengali; }
        #endregion ZoneNameInBengali

        #region Zone Code
        [DisplayName("Zone Code"), Size(50), NotNull]
        public String ZoneCode { get { return Fields.ZoneCode[this]; } set { Fields.ZoneCode[this] = value; } }
        public partial class RowFields { public StringField ZoneCode; }
        #endregion ZoneCode

        #region Sort Order
        [DisplayName("Sort Order"), NotNull, SortOrder(1)]
        public Int32? SortOrder { get { return Fields.SortOrder[this]; } set { Fields.SortOrder[this] = value; } }
        public partial class RowFields { public Int32Field SortOrder; }
        #endregion SortOrder

        #region Organogram Category Type
        [DisplayName("Organogram Category Type"), NotNull, ForeignKey("[dbo].[PRM_OrganogramCategoryType]", "Id"), LeftJoin("jOrganogramCategoryType"), TextualField("OrganogramCategoryTypeName")]
        //[LookupEditor(typeof(Configurations.Entities.PrmOrganogramCategoryTypeRow), InplaceAdd = true)]
        public Int32? OrganogramCategoryTypeId { get { return Fields.OrganogramCategoryTypeId[this]; } set { Fields.OrganogramCategoryTypeId[this] = value; } }
        public partial class RowFields { public Int32Field OrganogramCategoryTypeId; }
        #endregion OrganogramCategoryTypeId

        #region Zone Address
        [DisplayName("Zone Address")]
        public String ZoneAddress { get { return Fields.ZoneAddress[this]; } set { Fields.ZoneAddress[this] = value; } }
        public partial class RowFields { public StringField ZoneAddress; }
        #endregion ZoneAddress

        #region Zone Address In Bengali
        [DisplayName("Zone Address In Bengali")]
        public String ZoneAddressInBengali { get { return Fields.ZoneAddressInBengali[this]; } set { Fields.ZoneAddressInBengali[this] = value; } }
        public partial class RowFields { public StringField ZoneAddressInBengali; }
        #endregion ZoneAddressInBengali

        #region Prefix
        [DisplayName("Prefix"), Size(50)]
        public String Prefix { get { return Fields.Prefix[this]; } set { Fields.Prefix[this] = value; } }
        public partial class RowFields { public StringField Prefix; }
        #endregion Prefix

        #region Is Head Office
        [DisplayName("Is Head Office"), NotNull]
        public Boolean? IsHeadOffice { get { return Fields.IsHeadOffice[this]; } set { Fields.IsHeadOffice[this] = value; } }
        public partial class RowFields { public BooleanField IsHeadOffice; }
        #endregion IsHeadOffice


        #region Foreign Fields


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ZoneName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public PrmZoneInfoRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[PRM_ZoneInfo]")
            {
                LocalTextPrefix = "Configurations.PrmZoneInfo";
            }
        }
        #endregion RowFields
    }
}
