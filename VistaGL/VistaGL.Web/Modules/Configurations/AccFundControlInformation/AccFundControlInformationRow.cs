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

    [ConnectionKey("ACCDB"), DisplayName("Entity Information"), InstanceName("Entity Information")]
    // [ReadPermission("Configurations:AccFundControlInformation:Read")]
    [ReadPermission("?")]
    [InsertPermission("Configurations:AccFundControlInformation:Insert")]
    [UpdatePermission("Configurations:AccFundControlInformation:Update")]
    [DeletePermission("Configurations:AccFundControlInformation:Delete")]
    [LookupScript("Configurations.AccFundControlInformation", Permission = "?", Expiration = -1)]
    public sealed class AccFundControlInformationRow : NRow, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Code
        [DisplayName("Code"), Column("code"), Size(20), NotNull, Unique, QuickSearch]
        public String Code { get { return Fields.Code[this]; } set { Fields.Code[this] = value; } }
        public partial class RowFields { public StringField Code; }
        #endregion Code

        #region Entity Name
        [DisplayName("Entity Name"), Column("fundControlName"), Size(50), NotNull]
        public String FundControlName { get { return Fields.FundControlName[this]; } set { Fields.FundControlName[this] = value; } }
        public partial class RowFields { public StringField FundControlName; }
        #endregion FundControlName

        #region Books Beginning From
        [DisplayName("Books Beginning From"), Column("bookingDate")]
        public DateTime? BookingDate { get { return Fields.BookingDate[this]; } set { Fields.BookingDate[this] = value; } }
        public partial class RowFields { public DateTimeField BookingDate; }
        #endregion BooksBeginningFrom


        #region Address
        [DisplayName("Address"), Column("address"), Size(250)]
        public String Address { get { return Fields.Address[this]; } set { Fields.Address[this] = value; } }
        public partial class RowFields { public StringField Address; }
        #endregion Address

        #region Phone
        [DisplayName("Phone"), Column("phone"), Size(50)]
        public String Phone { get { return Fields.Phone[this]; } set { Fields.Phone[this] = value; } }
        public partial class RowFields { public StringField Phone; }
        #endregion Phone

        #region Mobile
        [DisplayName("Mobile"), Column("mobile"), Size(50)]
        public String Mobile { get { return Fields.Mobile[this]; } set { Fields.Mobile[this] = value; } }
        public partial class RowFields { public StringField Mobile; }
        #endregion Mobile

        #region Fax
        [DisplayName("Fax"), Column("fax"), Size(50)]
        public String Fax { get { return Fields.Fax[this]; } set { Fields.Fax[this] = value; } }
        public partial class RowFields { public StringField Fax; }
        #endregion Fax

        #region Email
        [DisplayName("Email"), Column("email"), Size(150)]
        public String Email { get { return Fields.Email[this]; } set { Fields.Email[this] = value; } }
        public partial class RowFields { public StringField Email; }
        #endregion Email

        #region Web
        [DisplayName("Web"), Column("webUrl"), Size(500)]
        public String WebUrl { get { return Fields.WebUrl[this]; } set { Fields.WebUrl[this] = value; } }
        public partial class RowFields { public StringField WebUrl; }
        #endregion WebUrl

        #region Remarks
        [DisplayName("Remarks"), Column("remarks"), Size(200)]
        public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
        public partial class RowFields { public StringField Remarks; }
        #endregion Remarks

        #region Zone Info
        [DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        // [LookupEditor(typeof(Entities.PrmZoneInfoRow))]
        //[DisplayName("Zone Info"), NotNull, ForeignKey("[dbo].[PRM_ZoneInfo]", "Id")]
        public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoId; }
        #endregion ZoneInfoId

        #region Currency
        [DisplayName("Currency"), Column("currencyId"), NotNull, ForeignKey("[dbo].[acc_currency_conversion]", "id"), LeftJoin("jCurrency"), TextualField("Currency")]
        [LookupEditor(typeof(Configurations.Entities.AccCurrencyConversionRow)), LookupInclude]
        public Int32? CurrencyId { get { return Fields.CurrencyId[this]; } set { Fields.CurrencyId[this] = value; } }
        public partial class RowFields { public Int32Field CurrencyId; }
        #endregion CurrencyId

        #region Foreign Fields

        [DisplayName("Zone Info Zone Name"), Expression("jZoneInfo.[ZoneName]")]
        public String ZoneInfoZoneName { get { return Fields.ZoneInfoZoneName[this]; } set { Fields.ZoneInfoZoneName[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneName; }


        [DisplayName("Zone Info Zone Name In Bengali"), Expression("jZoneInfo.[ZoneNameInBengali]")]
        public String ZoneInfoZoneNameInBengali { get { return Fields.ZoneInfoZoneNameInBengali[this]; } set { Fields.ZoneInfoZoneNameInBengali[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneNameInBengali; }


        [DisplayName("Zone Info Zone Code"), Expression("jZoneInfo.[ZoneCode]")]
        public String ZoneInfoZoneCode { get { return Fields.ZoneInfoZoneCode[this]; } set { Fields.ZoneInfoZoneCode[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneCode; }


        [DisplayName("Zone Info Sort Order"), Expression("jZoneInfo.[SortOrder]")]
        public Int32? ZoneInfoSortOrder { get { return Fields.ZoneInfoSortOrder[this]; } set { Fields.ZoneInfoSortOrder[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoSortOrder; }


        [DisplayName("Zone Info Organogram Category Type Id"), Expression("jZoneInfo.[OrganogramCategoryTypeId]")]
        public Int32? ZoneInfoOrganogramCategoryTypeId { get { return Fields.ZoneInfoOrganogramCategoryTypeId[this]; } set { Fields.ZoneInfoOrganogramCategoryTypeId[this] = value; } }
        public partial class RowFields { public Int32Field ZoneInfoOrganogramCategoryTypeId; }


        [DisplayName("Zone Info Zone Address"), Expression("jZoneInfo.[ZoneAddress]")]
        public String ZoneInfoZoneAddress { get { return Fields.ZoneInfoZoneAddress[this]; } set { Fields.ZoneInfoZoneAddress[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneAddress; }


        [DisplayName("Zone Info Zone Address In Bengali"), Expression("jZoneInfo.[ZoneAddressInBengali]")]
        public String ZoneInfoZoneAddressInBengali { get { return Fields.ZoneInfoZoneAddressInBengali[this]; } set { Fields.ZoneInfoZoneAddressInBengali[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoZoneAddressInBengali; }


        [DisplayName("Zone Info Prefix"), Expression("jZoneInfo.[Prefix]")]
        public String ZoneInfoPrefix { get { return Fields.ZoneInfoPrefix[this]; } set { Fields.ZoneInfoPrefix[this] = value; } }
        public partial class RowFields { public StringField ZoneInfoPrefix; }


        [DisplayName("Zone Info Is Head Office"), Expression("jZoneInfo.[IsHeadOffice]")]
        public Boolean? ZoneInfoIsHeadOffice { get { return Fields.ZoneInfoIsHeadOffice[this]; } set { Fields.ZoneInfoIsHeadOffice[this] = value; } }
        public partial class RowFields { public BooleanField ZoneInfoIsHeadOffice; }

        [DisplayName("Currency Symbol"), Expression("jCurrency.[symbol]")]
        public String CurrencySymbol { get { return Fields.CurrencySymbol[this]; } set { Fields.CurrencySymbol[this] = value; } }
        public partial class RowFields { public StringField CurrencySymbol; }


        [DisplayName("Currency"), Expression("jCurrency.[currency]"), LookupInclude]
        [MinSelectLevel(SelectLevel.List)]
        public String CurrencyCurrency { get { return Fields.CurrencyCurrency[this]; } set { Fields.CurrencyCurrency[this] = value; } }
        public partial class RowFields { public StringField CurrencyCurrency; }
        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.FundControlName; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccFundControlInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_FundControlInformation]")
            {
                LocalTextPrefix = "Configurations.AccFundControlInformation";
            }
        }
        #endregion RowFields
    }
}
